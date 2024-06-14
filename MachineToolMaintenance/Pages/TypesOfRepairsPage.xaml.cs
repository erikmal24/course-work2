using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MachineToolMaintenance.Etities;
using MachineToolMaintenance.Windows;

namespace MachineToolMaintenance.Pages
{
    /// <summary>
    /// Логика взаимодействия для TypesOfRepairsPage.xaml
    /// </summary>
    public partial class TypesOfRepairsPage : Page
    {
        public TypesOfRepairsPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TypesOfRepairsDataGrid.ItemsSource = MachineToolMaintenanceEntities.GetContext().TypesOfRepairs.ToList();
        }

        //Событие добавления
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditTypesOfRepairsWindow addEditTypesOfRepairsWindow = new AddEditTypesOfRepairsWindow(null);
            addEditTypesOfRepairsWindow.Show();
        }

        //Событие редактирования/изменения
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(TypesOfRepairsDataGrid.SelectedItem is TypesOfRepairs typesOfRepairs)
            {
                AddEditTypesOfRepairsWindow addEditTypesOfRepairsWindow = new AddEditTypesOfRepairsWindow(typesOfRepairs);
                addEditTypesOfRepairsWindow.Show();
            }
        }

        //Событие удаления
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (TypesOfRepairsDataGrid.SelectedItem is TypesOfRepairs typesOfRepairs)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        MachineToolMaintenanceEntities.GetContext().TypesOfRepairs.Remove(typesOfRepairs);
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
