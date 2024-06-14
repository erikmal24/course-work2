using System;
using System.Text;
using System.Windows;
using MachineToolMaintenance.Etities;

namespace MachineToolMaintenance.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditTypesOfRepairsWindow.xaml
    /// </summary>
    public partial class AddEditTypesOfRepairsWindow : Window
    {
        private TypesOfRepairs _currentTypesOfRepairs = new TypesOfRepairs();
        public AddEditTypesOfRepairsWindow(TypesOfRepairs typesOfRepairs)
        {
            InitializeComponent();
            if (typesOfRepairs != null)
            {
                _currentTypesOfRepairs = typesOfRepairs;
            }
            // задаем контекст данных для привязки
            DataContext = _currentTypesOfRepairs;
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
                if (_currentTypesOfRepairs.TypesOfRepairsId == 0)
                    MachineToolMaintenanceEntities.GetContext().TypesOfRepairs.Add(_currentTypesOfRepairs);
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
            if (string.IsNullOrWhiteSpace(_currentTypesOfRepairs.TypesOfRepairsTitle))
                str.AppendLine("Укажите название");
            if (_currentTypesOfRepairs.Duration <= 0)
                str.AppendLine("Укажите продолжительность (дн.)");
            if (_currentTypesOfRepairs.Cost <= 0)
                str.AppendLine("Укажите стоимость");
            if (string.IsNullOrWhiteSpace(_currentTypesOfRepairs.Note))
                str.AppendLine("Добавьте примечание");
            return str;
        }
    }
}
