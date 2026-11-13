using System;
using System.Collections;
using System.Collections.Generic;

namespace CafeFinance.Models
{
    /// <summary>
    /// Обобщённая коллекция справочника. Следит за уникальностью номеров и наименований
    /// и оповещает подписчиков об изменениях событием Changed (паттерн «Наблюдатель»).
    /// </summary>
    public class Catalog<T> : IEnumerable<T> where T : CatalogEntity
    {
        private readonly List<T> items = new List<T>();

        public event EventHandler Changed;

        public int Count
        {
            get { return items.Count; }
        }

        /// <summary>Индексатор: доступ к элементу по порядковому номеру в списке.</summary>
        public T this[int index]
        {
            get { return items[index]; }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (FindByName(item.Name) != null)
            {
                throw new ValidationException("Запись «" + item.Name + "» уже существует в справочнике.");
            }
            if (item.Id <= 0)
            {
                item.Id = NextId();
            }
            else if (FindById(item.Id) != null)
            {
                throw new ValidationException("Запись с номером " + item.Id + " уже существует в справочнике.");
            }
            items.Add(item);
            OnChanged();
        }

        public bool Remove(T item)
        {
            bool removed = items.Remove(item);
            if (removed)
            {
                OnChanged();
            }
            return removed;
        }

        public T FindById(int id)
        {
            foreach (T item in items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public T FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            string wanted = name.Trim();
            foreach (T item in items)
            {
                if (string.Equals(item.Name, wanted, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        public int NextId()
        {
            int max = 0;
            foreach (T item in items)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            return max + 1;
        }

        public void Clear()
        {
            items.Clear();
            OnChanged();
        }

        /// <summary>Сообщает подписчикам, что состояние элемента изменилось.</summary>
        public void MarkChanged()
        {
            OnChanged();
        }

        public List<T> ToList()
        {
            return new List<T>(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void OnChanged()
        {
            EventHandler handler = Changed;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
