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
using Entidades;
using Negocios;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for Pasteleria.xaml
    /// </summary>
    public partial class Pasteleria : Window
    {
        private nPasteleria pastel = new nPasteleria();
        private nPlatos plato = new nPlatos();
        private nCliente clien = new nCliente();
        ePasteleria pas = null;
        ePlatos pla = null;
        eCliente cli = null;
        int idpasteleria;
        public Pasteleria() {
            InitializeComponent();
            pasteleria();
            platos();
            cliente();

        }
        private void pasteleria() {
            dataGrid.ItemsSource = pastel.listarpasteleria();
        }
        private void platos() {
            comboBox1.ItemsSource = plato.listarplatos();
        }
        private void cliente() {
            comboBox.ItemsSource = clien.listarclientes();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            if (comboBox.SelectedIndex != -1 && comboBox1.SelectedIndex != -1) {
                MessageBox.Show(pastel.RegistrarPasteleria(cli.DNI, pla.idPlatos));
                pasteleria();
            } else MessageBox.Show("Completar datos");
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            if (pas != null) {
                if (comboBox.SelectedIndex != -1 && comboBox1.SelectedIndex != -1) {
                    MessageBox.Show(pastel.ModificarPasteleria(pas.idpasteleria, pla.idPlatos, cli.DNI));
                    pasteleria();
                } else
                    MessageBox.Show("Completar datos");
            } else {
                MessageBox.Show("Seleccionar pasajero");
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            cli = comboBox.SelectedItem as eCliente;
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            pla = comboBox1.SelectedItem as ePlatos;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            pas = dataGrid.SelectedItem as ePasteleria;
            if (pas != null) {
                idpasteleria = pas.idpasteleria;
                comboBox.SelectedItem = Convert.ToString(pas.dniCliente);
                comboBox1.Text = Convert.ToString(pas.idplatos);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            if (pas != null) {
                MessageBox.Show(pastel.Eliminarpasteleria(pas.idpasteleria));
            } else
                MessageBox.Show("Seleccionar pedido que desea eliminar");
        }

        private void button3_Click(object sender, RoutedEventArgs e) {

        }
    }
}
