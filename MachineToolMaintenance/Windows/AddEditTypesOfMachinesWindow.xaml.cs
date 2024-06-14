using System;
using System.Text;
using System.Windows;
using MachineToolMaintenance.Etities;

namespace MachineToolMaintenance.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditTypesOfMachinesWindow.xaml
    /// </summary>
    public partial class AddEditTypesOfMachinesWindow : Window
    {
        private TypesOfMachines _currentTypesOfMachines = new TypesOfMachines();
        public AddEditTypesOfMachinesWindow(TypesOfMachines typesOfMachines)
        {
            InitializeComponent();
            if (typesOfMachines != null)
            {
                _currentTypesOfMachines = typesOfMachines;
            }
            else
            {
                _currentTypesOfMachines.ReleaseDate = DateTime.Now;
            }
            // задаем контекст данных для привязки
            DataContext = _currentTypesOfMachines;
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
                if (_currentTypesOfMachines.TypesOfMachinesId == 0)
                    MachineToolMaintenanceEntities.GetContext().TypesOfMachines.Add(_currentTypesOfMachines);
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
            if (string.IsNullOrWhiteSpace(_currentTypesOfMachines.Country))
                str.AppendLine("Добавьте страну");
            if (_currentTypesOfMachines.ReleaseDate == null)
                str.AppendLine("Укажите дату выпуска");
            if (string.IsNullOrWhiteSpace(_currentTypesOfMachines.Stamp))
                str.AppendLine("Укажите марку");
            return str;
        }
    }
}
