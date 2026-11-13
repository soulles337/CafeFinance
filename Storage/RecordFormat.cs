using System;
using System.Globalization;
using CafeFinance.Models;

namespace CafeFinance.Storage
{
    /// <summary>
    /// Правила представления данных в текстовом файле: разделители, экранирование,
    /// форматы чисел и дат. Используется всеми классами, умеющими читать и писать записи.
    /// </summary>
    public static class RecordFormat
    {
        public const char FieldSeparator = '|';
        public const char ItemSeparator = ';';
        public const char SubSeparator = '~';
        public const string DateFormat = "yyyy-MM-dd HH:mm";

        private static readonly CultureInfo culture = CultureInfo.InvariantCulture;

        public static string Escape(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            return text.Replace("%", "%25").Replace("|", "%7C").Replace(";", "%3B")
                       .Replace("~", "%7E").Replace("\r", string.Empty).Replace("\n", "%0A");
        }

        public static string Unescape(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            return text.Replace("%0A", "\n").Replace("%7E", "~").Replace("%3B", ";")
                       .Replace("%7C", "|").Replace("%25", "%");
        }

        public static string Join(params string[] fields)
        {
            return string.Join(FieldSeparator.ToString(), fields);
        }

        public static string FormatDecimal(decimal value)
        {
            return value.ToString("0.00", culture);
        }

        public static string FormatQuantity(decimal value)
        {
            return value.ToString("0.###", culture);
        }

        public static string FormatDate(DateTime value)
        {
            return value.ToString(DateFormat, culture);
        }

        public static void RequireFields(string[] parts, int count)
        {
            if (parts.Length < count)
            {
                throw new DataFileException($"Запись «{parts[0]}» содержит {parts.Length} полей вместо {count}.");
            }
        }

        public static int ParseInt(string text, string fieldName)
        {
            int result;
            if (!int.TryParse(text, NumberStyles.Integer, culture, out result))
            {
                throw new DataFileException($"Некорректное целое число в поле «{fieldName}»: «{text}».");
            }
            return result;
        }

        public static decimal ParseDecimal(string text, string fieldName)
        {
            decimal result;
            if (!decimal.TryParse(text, NumberStyles.Number, culture, out result))
            {
                throw new DataFileException($"Некорректное число в поле «{fieldName}»: «{text}».");
            }
            return result;
        }

        public static DateTime ParseDate(string text, string fieldName)
        {
            DateTime result;
            if (!DateTime.TryParseExact(text, DateFormat, culture, DateTimeStyles.None, out result))
            {
                throw new DataFileException($"Некорректная дата в поле «{fieldName}»: «{text}».");
            }
            return result;
        }

        public static T ParseEnum<T>(string text, string fieldName) where T : struct
        {
            int number = ParseInt(text, fieldName);
            if (!Enum.IsDefined(typeof(T), number))
            {
                throw new DataFileException($"Недопустимое значение поля «{fieldName}»: {number}.");
            }
            return (T)Enum.ToObject(typeof(T), number);
        }
    }
}
