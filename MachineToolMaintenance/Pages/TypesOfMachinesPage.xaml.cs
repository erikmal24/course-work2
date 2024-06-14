using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MachineToolMaintenance.Etities;
using MachineToolMaintenance.Windows;

namespace MachineToolMaintenance.Pages
{
    /// <summary>
    /// Логика взаимодействия для TypesOfMachinesPage.xaml
    /// </summary>
    public partial class TypesOfMachinesPage : Page
    {
        public TypesOfMachinesPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TypesOfMachinesDataGrid.ItemsSource = MachineToolMaintenanceEntities.GetContext().TypesOfMachines.ToList();
        }

        //Событие добавления
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditTypesOfMachinesWindow addEditTypesOfMachinesWindow = new AddEditTypesOfMachinesWindow(null);
            addEditTypesOfMachinesWindow.Show();
        }

        //Событие редактирования/изменения
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(TypesOfMachinesDataGrid.SelectedItem is TypesOfMachines machines)
            {
                AddEditTypesOfMachinesWindow addEditTypesOfMachinesWindow = new AddEditTypesOfMachinesWindow(machines);
                addEditTypesOfMachinesWindow.Show();
            }
        }

        //Событие удаления
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (TypesOfMachinesDataGrid.SelectedItem is TypesOfMachines machines)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        MachineToolMaintenanceEntities.GetContext().TypesOfMachines.Remove(machines);
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
