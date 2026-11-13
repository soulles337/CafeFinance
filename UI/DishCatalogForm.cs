using System;
using System.Windows.Forms;
using CafeFinance.Models;

namespace CafeFinance.UI
{
    /// <summary>Справочник «Меню кафе»: просмотр, добавление, изменение и удаление блюд.</summary>
    public partial class DishCatalogForm : Form
    {
        private readonly CafeData data;

        public DishCatalogForm(CafeData data)
        {
            InitializeComponent();
            this.data = data;
            cmbCategory.DataSource = Localizer.Items<DishCategory>();
            cmbCategory.DisplayMember = "Text";
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvDishes.Rows.Clear();
            foreach (Dish dish in data.Dishes)
            {
                int index = dgvDishes.Rows.Add(dish.Id, dish.Name, Localizer.Name(dish.Category),
                    dish.Price.ToString("N2"), dish.Cost.ToString("N2"));
                dgvDishes.Rows[index].Tag = dish;
            }
        }

        private Dish GetSelectedDish()
        {
            if (dgvDishes.CurrentRow == null)
            {
                return null;
            }
            return dgvDishes.CurrentRow.Tag as Dish;
        }

        /// <summary>Создаёт блюдо из значений полей ввода с проверкой всех ограничений.</summary>
        private Dish ReadDish()
        {
            Dish dish = new Dish();
            dish.Name = txtName.Text;
            dish.Category = ((EnumItem<DishCategory>)cmbCategory.SelectedItem).Value;
            dish.Price = numPrice.Value;
            dish.Cost = numCost.Value;
            dish.Validate();
            return dish;
        }

        private void dgvDishes_SelectionChanged(object sender, EventArgs e)
        {
            Dish dish = GetSelectedDish();
            if (dish == null)
            {
                return;
            }
            txtName.Text = dish.Name;
            UiHelper.SelectEnum(cmbCategory, dish.Category);
            numPrice.Value = dish.Price;
            numCost.Value = dish.Cost;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                data.Dishes.Add(ReadDish());
                RefreshGrid();
            }
            catch (ValidationException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Dish selected = GetSelectedDish();
            if (selected == null)
            {
                UiHelper.ShowInfo("Следует выбрать блюдо в таблице.");
                return;
            }
            try
            {
                Dish candidate = ReadDish();
                Dish same = data.Dishes.FindByName(candidate.Name);
                if (same != null && !ReferenceEquals(same, selected))
                {
                    throw new ValidationException("Блюдо «" + candidate.Name + "» уже есть в меню.");
                }
                selected.Assign(candidate);
                data.Dishes.MarkChanged();
                RefreshGrid();
            }
            catch (ValidationException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dish selected = GetSelectedDish();
            if (selected == null)
            {
                UiHelper.ShowInfo("Следует выбрать блюдо в таблице.");
                return;
            }
            if (!UiHelper.Confirm("Вы действительно хотите удалить блюдо «" + selected.Name + "» из меню?"))
            {
                return;
            }
            data.Dishes.Remove(selected);
            RefreshGrid();
        }
    }
}
