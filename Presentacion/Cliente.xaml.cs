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

namespace Presentacion {
    /// <summary>
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Window {
        nCliente cli = new nCliente();
        eCliente cliente = null;
        int idcliente;
        public Cliente() {
            InitializeComponent();
            RegistrarCli();
        }
        private void RegistrarCli() {
            if (cli.listarclientes() != null) {
                dataGrid.ItemsSource = cli.listarclientes();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            if (textBox.Text != "" && textBox1.Text != "" && textBox2.Text != "") {
                if (textBox2.Text.Count() != 8) {
                    MessageBox.Show(cli.RegistrarCliente(textBox2.Text, textBox.Text, textBox1.Text));
                    RegistrarCli();
                } else {
                    MessageBox.Show("Ingrese un DNI valido");
                }
            } else
                MessageBox.Show("Ingresar datos");

            textBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox.Focus();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            if (dataGrid.SelectedIndex != -1) {
                MessageBox.Show(cli.EliminarCliente(textBox2.Text));
            } else
                MessageBox.Show("Seleccione que desea eliminar");
            textBox.Focus();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            cliente = dataGrid.SelectedItem as eCliente;
            if (cliente != null) {
                //idcliente = cliente.DNI;
                textBox.Text = cliente.nombre;
                textBox1.Text = cliente.clave;
                textBox2.Text = cliente.DNI;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e) {
            if (textBox.Text != "" && textBox1.Text != "" && textBox2.Text != "") {
                if (textBox.Text != "") {
                    MessageBox.Show(cli.ActuzalizarCliente(textBox1.Text, textBox.Text, textBox2.Text));
                    textBox2.IsReadOnly = true;
                    RegistrarCli();
                } else
                    MessageBox.Show("Ingresar un nombre");
            } else
                MessageBox.Show("Seleccionar un cliente");
            textBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox.Focus();
            textBox2.IsReadOnly = false;
        }
    }
}