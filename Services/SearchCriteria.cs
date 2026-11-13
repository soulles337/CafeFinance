using System;
using CafeFinance.Models;

namespace CafeFinance.Services
{
    /// <summary>
    /// Параметры поиска по журналу операций. Незаполненный параметр (null или пустая строка)
    /// в отборе не участвует.
    /// </summary>
    public class SearchCriteria
    {
        public string Text { get; set; }

        public OperationKind? Kind { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public decimal? AmountFrom { get; set; }

        public decimal? AmountTo { get; set; }
    }
}
