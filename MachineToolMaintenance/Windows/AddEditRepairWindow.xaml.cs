using System;
using System.Text;
using System.Windows;
using MachineToolMaintenance.Etities;

namespace MachineToolMaintenance.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditRepairWindow.xaml
    /// </summary>
    public partial class AddEditRepairWindow : Window
    {
        private Repair _currentRepair = new Repair();
        public AddEditRepairWindow(Repair repair)
        {
            InitializeComponent();
            if (repair != null)
            {
                _currentRepair = repair;
            }
            else
            {
                _currentRepair.StartDate = DateTime.Now;
            }
            // задаем контекст данных для привязки
            DataContext = _currentRepair;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // проверка полей
                StringBuilder error = CheckError();
                // при наличии ошибок, выводим ошибки и прерываем операцию 
                // добавления / редактирования
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                if (_currentRepair.RepairId == 0)
                    MachineToolMaintenanceEntities.GetContext().Repair.Add(_currentRepair);
                MachineToolMaintenanceEntities.GetContext().SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private StringBuilder CheckError()
        {
            StringBuilder str = new StringBuilder();
            // метод проверки полей на корректность ввода
            if (_currentRepair.TypesOfMachinesId == 0)
                str.AppendLine("Укажите вид станка (id)");
            if (_currentRepair.StartDate == null)
                str.AppendLine("Укажите дату начала");
            if (string.IsNullOrWhiteSpace(_currentRepair.RepairNote))
                str.AppendLine("Добавьте примечание");
            return str;
        }
    }
}
