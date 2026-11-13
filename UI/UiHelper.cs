using System.Collections.Generic;
using System.Windows.Forms;
using CafeFinance.Models;

namespace CafeFinance.UI
{
    /// <summary>Вспомогательные методы интерфейса: сообщения пользователю и работа с ComboBox.</summary>
    public static class UiHelper
    {
        public const string Caption = "Кафе ПолесГУ";

        public static void ShowError(string message)
        {
            MessageBox.Show(message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Запрашивает подтверждение необратимого действия.</summary>
        public static bool Confirm(string message)
        {
            DialogResult result = MessageBox.Show(message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        /// <summary>Выбирает в списке элемент с заданным значением перечисления.</summary>
        public static void SelectEnum<T>(ComboBox combo, T value) where T : struct
        {
            foreach (object item in combo.Items)
            {
                EnumItem<T> enumItem = item as EnumItem<T>;
                if (enumItem != null && EqualityComparer<T>.Default.Equals(enumItem.Value, value))
                {
                    combo.SelectedItem = item;
                    return;
                }
            }
        }
    }
}
