using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CafeFinance.Models;
using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.UI
{
    /// <summary>Форма формирования финансового отчёта за период и его сохранения в текстовый файл.</summary>
    public partial class ReportForm : Form
    {
        private readonly CafeData data;

        public ReportForm(CafeData data)
        {
            InitializeComponent();
            this.data = data;
            dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpTo.Value = DateTime.Today;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            if (from > to)
            {
                UiHelper.ShowError("Начальная дата периода не может быть позже конечной.");
                return;
            }

            SearchCriteria criteria = new SearchCriteria { DateFrom = from, DateTo = to };
            List<FinancialOperation> found = OperationSearcher.Find(data.Journal, criteria);
            txtReport.Text = ReportBuilder.Build(found, from, to);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReport.Text))
            {
                UiHelper.ShowInfo("Следует сначала сформировать отчёт.");
                return;
            }
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                dialog.FileName = "report.txt";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                try
                {
                    ReportBuilder.SaveToFile(dialog.FileName, txtReport.Text);
                    UiHelper.ShowInfo("Отчёт сохранён в файл: " + dialog.FileName);
                }
                catch (DataFileException ex)
                {
                    UiHelper.ShowError(ex.Message);
                }
            }
        }
    }
}
