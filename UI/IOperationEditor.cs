using System;
using System.Windows.Forms;
using CafeFinance.Models;

namespace CafeFinance.UI
{
    /// <summary>
    /// Общий интерфейс диалогов ввода операций. Главная форма работает с любым диалогом
    /// через этот интерфейс и не зависит от конкретного типа операции.
    /// </summary>
    public interface IOperationEditor : IDisposable
    {
        FinancialOperation Result { get; }

        DialogResult ShowDialog(IWin32Window owner);
    }
}
