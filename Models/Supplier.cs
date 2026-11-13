using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>Поставщик продуктов питания и сырья.</summary>
    public class Supplier : CatalogEntity
    {
        private string phone = string.Empty;

        public Supplier()
        {
        }

        public Supplier(int id, string name, string phone) : base(id, name)
        {
            Phone = phone;
        }

        public Supplier(string[] parts) : base(parts)
        {
            RecordFormat.RequireFields(parts, 4);
            Phone = RecordFormat.Unescape(parts[3]);
        }

        public string Phone
        {
            get { return phone; }
            set { phone = Validator.CheckPhone(value); }
        }

        public override string ToRecord()
        {
            return RecordFormat.Join("SUP", Id.ToString(), RecordFormat.Escape(Name), RecordFormat.Escape(phone));
        }
    }
}
