using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MachineToolMaintenance.Etities;
using MachineToolMaintenance.Windows;

namespace MachineToolMaintenance.Pages
{
    /// <summary>
    /// Логика взаимодействия для RepairPage.xaml
    /// </summary>
    public partial class RepairPage : Page
    {
        public RepairPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RepairDataGrid.ItemsSource = MachineToolMaintenanceEntities.GetContext().Repair.ToList();
        }

        //Событие добавления
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditRepairWindow addEditRepairWindow = new AddEditRepairWindow(null);
            addEditRepairWindow.Show();
        }

        //Событие редактирования/изменения
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(RepairDataGrid.SelectedItem is Repair repair)
            {
                AddEditRepairWindow addEditRepairWindow = new AddEditRepairWindow(repair);
                addEditRepairWindow.Show();
            }
        }

        //Событие удаления
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (RepairDataGrid.SelectedItem is Repair repair)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        MachineToolMaintenanceEntities.GetContext().Repair.Remove(repair);
                        MachineToolMaintenanceEntities.GetContext().SaveChanges();
                        MessageBox.Show("Запись удалена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Событие обновления
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }
    }
}
