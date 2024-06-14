using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MachineToolMaintenance.Pages;

namespace MachineToolMaintenance
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TypesOfMachinesPage());
        }

        private void btnTypesOfMachines_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TypesOfMachinesPage());
        }

        private void btnTypesOfRepairs_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TypesOfRepairsPage());
        }

        private void btnRepair_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RepairPage());
        }

        private void btnPower_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
