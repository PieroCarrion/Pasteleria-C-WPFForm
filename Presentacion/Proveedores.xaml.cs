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
    /// Interaction logic for Proveedores.xaml
    /// </summary>
    public partial class Proveedores : Window {
        nProveedores pro = new nProveedores();
        eProveedores prose = null;
        int idproveedores;
        public Proveedores() {
            InitializeComponent();
            MostrarProveedores();
        }
        private void MostrarProveedores() {
            dataGrid.ItemsSource = pro.listarProveedores();
        }
        private void button2_Click(object sender, RoutedEventArgs e) {
            if (prose != null) {
                MessageBox.Show(pro.EliminarProveedor(idproveedores));
            } else {
                MessageBox.Show("Seleccionar el proveedor que desea eliminar");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            if (prose != null) {
                if (textBox.Text != "") {
                    MessageBox.Show(pro.ModificarProveedor(textBox1.Text, textBox.Text, idproveedores));
                    MostrarProveedores();
                } else {
                    MessageBox.Show("ngresar empresa");
                }

            } else {
                MessageBox.Show("Seleccionar proveedor que desea modificar");
            }
            textBox.Clear();
            textBox1.Clear();
            textBox.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            if (textBox.Text != "") {
                MessageBox.Show(pro.RegistrarProveedor(textBox1.Text, textBox.Text));
                MostrarProveedores();
            } else {
                MessageBox.Show("Ingresar empresa");
            }
            textBox.Clear();
            textBox1.Clear();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            prose = dataGrid.SelectedItem as eProveedores;
            if (prose != null) {
                idproveedores = prose.idCompania;
                textBox.Text = prose.NombreEmpresa;
                textBox1.Text = prose.Nombreproducto;
            }
        }
    }
}

