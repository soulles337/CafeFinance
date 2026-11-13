using System;
using System.Globalization;
using System.Text.RegularExpressions;
using CafeFinance.Models;

namespace CafeFinance.Services
{
    /// <summary>
    /// Набор проверок вводимых данных. Все методы при нарушении ограничения
    /// генерируют исключение ValidationException с понятным пользователю текстом.
    /// </summary>
    public static class Validator
    {
        private static readonly Regex phonePattern = new Regex(@"^[0-9+()\-\s]{5,20}$");

        public static string RequireText(string value, string fieldName, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException($"Поле «{fieldName}» не может быть пустым.");
            }
            string text = value.Trim();
            if (text.Length > maxLength)
            {
                throw new ValidationException($"Поле «{fieldName}» не должно превышать {maxLength} символов.");
            }
            return text;
        }

        public static string OptionalText(string value, string fieldName, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            return RequireText(value, fieldName, maxLength);
        }

        public static decimal RequirePositive(decimal value, string fieldName)
        {
            if (value <= 0)
            {
                throw new ValidationException($"Значение поля «{fieldName}» должно быть больше нуля.");
            }
            return value;
        }

        public static decimal RequireNonNegative(decimal value, string fieldName)
        {
            if (value < 0)
            {
                throw new ValidationException($"Значение поля «{fieldName}» не может быть отрицательным.");
            }
            return value;
        }

        public static decimal RequireRange(decimal value, decimal min, decimal max, string fieldName)
        {
            if (value < min || value > max)
            {
                throw new ValidationException(
                    $"Значение поля «{fieldName}» должно находиться в диапазоне от {min} до {max}.");
            }
            return value;
        }

        public static DateTime RequireDate(DateTime value)
        {
            if (value.Year < 2000 || value > DateTime.Now.AddDays(1))
            {
                throw new ValidationException("Дата операции должна быть не ранее 2000 года и не позднее завтрашнего дня.");
            }
            return value;
        }

        public static string CheckPhone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            string text = value.Trim();
            if (!phonePattern.IsMatch(text))
            {
                throw new ValidationException("Телефон может содержать только цифры, пробелы и символы + ( ) -.");
            }
            return text;
        }

        /// <summary>Разбирает число, введённое пользователем (допускается запятая и точка).</summary>
        public static decimal ParseUserDecimal(string text, string fieldName)
        {
            decimal result;
            string normalized = (text ?? string.Empty).Trim().Replace(',', '.');
            if (!decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out result))
            {
                throw new ValidationException($"В поле «{fieldName}» следует ввести число.");
            }
            return result;
        }
    }
}
