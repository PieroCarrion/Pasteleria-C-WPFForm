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
    public partial class Producto : Window
    {
        private nProducto producto = new nProducto();
        private nPlatos plato = new nPlatos();
        private nProveedores prove = new nProveedores();
        eProducto pro = null;
        ePlatos pla = null;
        eProveedores prov = null;
        int idproducto;
        public Producto()
        {
            InitializeComponent();
            mosproducto();
            
            comboBox1.ItemsSource = prove.listarProveedores();
            comboBox.ItemsSource = plato.listarplatos();
        }
        private void mosproducto()
        {
            dataGrid.ItemsSource = producto.listarpasajero() ;
        }
        
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex != -1 && comboBox1.SelectedIndex != -1)
            {
                MessageBox.Show(producto.RegistrarProducto(comboBox1.SelectedItem.ToString(),comboBox.SelectedItem.ToString(), Convert.ToInt32(textBox.Text)));
                mosproducto();
                comboBox.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;
                textBox.Clear();
            }
            else MessageBox.Show("Completar datos");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (pro != null)
            {
                if (comboBox.SelectedIndex != -1 && comboBox1.SelectedIndex != -1 && textBox.Text != "")
                {
                    MessageBox.Show(producto.ModificarProducto(comboBox1.SelectedItem.ToString(), Convert.ToInt32(comboBox.Text), textBox.Text,idproducto));
                    mosproducto();
                    textBox.Clear();
                    comboBox.SelectedIndex = -1;
                    comboBox1.SelectedIndex = -1;
                }
                else
                    MessageBox.Show("Completar datos");
            }
            else
            {
                MessageBox.Show("Seleccionar producto");
            }
        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            pro = dataGrid.SelectedItem as eProducto;
            if (pro != null)
            {
                idproducto = pro.idProducto;
                comboBox.SelectedItem = Convert.ToString(pro.idCompania);
                comboBox1.SelectedItem = Convert.ToString(pro.idPlato);
                textBox.Text =Convert.ToString(pro.cantidad);
            }
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            if (prove != null)
            {
                MessageBox.Show(producto.EliminarProducto(pro.idProducto));
            }
            else
                MessageBox.Show("Seleccionar producto que desea eliminar");
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prov = comboBox.SelectedItem as eProveedores;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pla = comboBox1.SelectedItem as ePlatos;
        }
    }
}

