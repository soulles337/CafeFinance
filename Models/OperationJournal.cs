using System;
using System.Collections;
using System.Collections.Generic;

namespace CafeFinance.Models
{
    /// <summary>
    /// Журнал финансовых операций кафе. Хранит операции в оперативной памяти;
    /// при любом изменении генерирует событие Changed.
    /// </summary>
    public class OperationJournal : IEnumerable<FinancialOperation>
    {
        private readonly List<FinancialOperation> operations = new List<FinancialOperation>();

        public event EventHandler Changed;

        public int Count
        {
            get { return operations.Count; }
        }

        public void Add(FinancialOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            operation.Validate();
            if (operation.Id <= 0)
            {
                operation.Id = NextId();
            }
            else if (FindById(operation.Id) != null)
            {
                throw new ValidationException("Операция с номером " + operation.Id + " уже есть в журнале.");
            }
            operations.Add(operation);
            OnChanged();
        }

        public bool Remove(FinancialOperation operation)
        {
            bool removed = operations.Remove(operation);
            if (removed)
            {
                OnChanged();
            }
            return removed;
        }

        /// <summary>Заменяет операцию изменённой версией, сохраняя номер.</summary>
        public void Replace(FinancialOperation oldOperation, FinancialOperation newOperation)
        {
            int index = operations.IndexOf(oldOperation);
            if (index < 0)
            {
                throw new ValidationException("Редактируемая операция не найдена в журнале.");
            }
            newOperation.Validate();
            newOperation.Id = oldOperation.Id;
            operations[index] = newOperation;
            OnChanged();
        }

        public FinancialOperation FindById(int id)
        {
            foreach (FinancialOperation operation in operations)
            {
                if (operation.Id == id)
                {
                    return operation;
                }
            }
            return null;
        }

        public int NextId()
        {
            int max = 0;
            foreach (FinancialOperation operation in operations)
            {
                if (operation.Id > max)
                {
                    max = operation.Id;
                }
            }
            return max + 1;
        }

        public void Clear()
        {
            operations.Clear();
            OnChanged();
        }

        public IEnumerator<FinancialOperation> GetEnumerator()
        {
            return operations.GetEnumerator();
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
