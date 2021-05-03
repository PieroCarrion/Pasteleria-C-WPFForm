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
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Platos platos = new Platos();
            platos.ShowDialog();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente();
            cli.ShowDialog();

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Platos pla = new Platos();
            pla.ShowDialog();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Pasteleria pedidos = new Pasteleria();
            pedidos.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Proveedores pro = new Proveedores();
            pro.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click_1(object sender, RoutedEventArgs e)
        {
            Producto prod = new Producto();
            prod.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
