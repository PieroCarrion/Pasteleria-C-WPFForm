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
    /// Interaction logic for Platos.xaml
    /// </summary>
    public partial class Platos : Window {
        nPlatos pl = new nPlatos();
        ePlatos plato = null;
        int codplatos;
        public Platos() {
            InitializeComponent();
            MostrarPlatos();
            comboBox.Items.Add("Cupcake");
            comboBox.Items.Add("Pastel");
            comboBox.Items.Add("Bebida");
            comboBox.Items.Add("Postre");
        }
        private void MostrarPlatos() {
            if (pl.listarplatos() != null) {
                dataGrid.ItemsSource = pl.listarplatos();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            if (comboBox.Text != "") {
                MessageBox.Show(pl.RegistrarPlatos(comboBox.SelectedItem.ToString(), Convert.ToDecimal(textBox2.Text), textBox1.Text));
                MostrarPlatos();
            } else
                MessageBox.Show("Ingresar datos ");

            textBox1.Clear();
            textBox2.Clear();
            comboBox.SelectedItem = -1;
            textBox1.Focus();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            plato = dataGrid.SelectedItem as ePlatos;
            if (plato != null) {
                codplatos = plato.idPlatos;
                comboBox.SelectedValue = plato.postre;
                textBox1.Text = plato.nombre;
                textBox2.Text = Convert.ToString(plato.precio);

            }

        }

        private void button_Click(object sender, RoutedEventArgs e) {
            if (plato != null) {
                if (comboBox.Text != "") {
                    MessageBox.Show(pl.ModificarPlatos(Convert.ToDecimal(textBox2.Text), textBox1.Text, comboBox.SelectedItem.ToString(), codplatos));
                    MostrarPlatos();
                } else {
                    MessageBox.Show("Ingresar precio");
                }
            } else
                MessageBox.Show("Seleccione precio que desea modificar");
            textBox1.Clear();
            comboBox.SelectedItem = -1;
            textBox2.Clear();
            textBox1.Focus();

        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            if (plato != null) {
                MessageBox.Show(pl.EliminarPlatos(codplatos));
                MostrarPlatos();
            } else
                MessageBox.Show("Seleccione el plato que desea eliminar");
            textBox1.Clear();
            comboBox.SelectedItem = -1;
            textBox2.Clear();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
