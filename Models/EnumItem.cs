namespace CafeFinance.Models
{
    /// <summary>
    /// Элемент выпадающего списка: значение перечисления и его русское название.
    /// </summary>
    public class EnumItem<T>
    {
        public EnumItem(T value, string text)
        {
            Value = value;
            Text = text;
        }

        public T Value { get; private set; }

        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
