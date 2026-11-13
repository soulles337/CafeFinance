using System;

namespace CafeFinance.Models
{
    /// <summary>Базовое исключение приложения.</summary>
    public class CafeException : Exception
    {
        public CafeException(string message) : base(message)
        {
        }

        public CafeException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    /// <summary>Ошибка проверки данных, введённых пользователем.</summary>
    public class ValidationException : CafeException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }

    /// <summary>Ошибка чтения, записи или разбора файла данных.</summary>
    public class DataFileException : CafeException
    {
        public DataFileException(string message) : base(message)
        {
        }

        public DataFileException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
