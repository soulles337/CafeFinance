using System;
using System.IO;
using System.Text;
using CafeFinance.Models;

namespace CafeFinance.Storage
{
    /// <summary>
    /// Работа с файлом данных кафе (текстовый формат, кодировка UTF-8): создание,
    /// чтение, запись и удаление. Файл читается и записывается целиком, поэтому
    /// между этими операциями приложение работает только с объектами в памяти.
    /// </summary>
    public static class CafeDataFile
    {
        private const string Header = "#CAFEFIN;1";

        public static void Create(string path, CafeData data)
        {
            if (File.Exists(path))
            {
                throw new DataFileException("Файл с таким именем уже существует: " + path);
            }
            Save(path, data);
        }

        public static void Save(string path, CafeData data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
                {
                    writer.WriteLine(Header);
                    WriteRecords(writer, data.Dishes);
                    WriteRecords(writer, data.Employees);
                    WriteRecords(writer, data.Suppliers);
                    WriteRecords(writer, data.Journal);
                }
            }
            catch (IOException ex)
            {
                throw new DataFileException("Ошибка записи файла: " + ex.Message, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new DataFileException("Нет доступа к файлу: " + ex.Message, ex);
            }
        }

        public static CafeData Load(string path)
        {
            if (!File.Exists(path))
            {
                throw new DataFileException("Файл не найден: " + path);
            }

            string[] lines;
            try
            {
                lines = File.ReadAllLines(path, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                throw new DataFileException("Ошибка чтения файла: " + ex.Message, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new DataFileException("Нет доступа к файлу: " + ex.Message, ex);
            }

            return Parse(lines);
        }

        public static void Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (IOException ex)
            {
                throw new DataFileException("Не удалось удалить файл: " + ex.Message, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new DataFileException("Нет доступа к файлу: " + ex.Message, ex);
            }
        }

        private static CafeData Parse(string[] lines)
        {
            if (lines.Length == 0 || lines[0] != Header)
            {
                throw new DataFileException("Файл имеет неверный формат: отсутствует служебный заголовок.");
            }

            CafeData data = new CafeData();
            // Сначала читаются справочники, затем операции, ссылающиеся на справочники.
            for (int i = 1; i < lines.Length; i++)
            {
                ParseLine(lines[i], i + 1, data, false);
            }
            for (int i = 1; i < lines.Length; i++)
            {
                ParseLine(lines[i], i + 1, data, true);
            }
            return data;
        }

        private static void ParseLine(string line, int number, CafeData data, bool operationsPass)
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            {
                return;
            }

            string[] parts = line.Split(RecordFormat.FieldSeparator);
            bool isOperation = OperationFactory.IsOperationTag(parts[0]);
            if (isOperation != operationsPass)
            {
                return;
            }

            try
            {
                if (isOperation)
                {
                    data.Journal.Add(OperationFactory.FromRecord(parts, data));
                }
                else
                {
                    AddCatalogRecord(parts, data);
                }
            }
            catch (CafeException ex)
            {
                throw new DataFileException("Строка " + number + ": " + ex.Message, ex);
            }
        }

        private static void AddCatalogRecord(string[] parts, CafeData data)
        {
            switch (parts[0])
            {
                case "MENU":
                    data.Dishes.Add(new Dish(parts));
                    break;
                case "EMP":
                    data.Employees.Add(new Employee(parts));
                    break;
                case "SUP":
                    data.Suppliers.Add(new Supplier(parts));
                    break;
                default:
                    throw new DataFileException("Неизвестный тип записи: «" + parts[0] + "».");
            }
        }

        private static void WriteRecords<T>(TextWriter writer, System.Collections.Generic.IEnumerable<T> items)
            where T : IFileRecord
        {
            foreach (T item in items)
            {
                writer.WriteLine(item.ToRecord());
            }
        }
    }
}
