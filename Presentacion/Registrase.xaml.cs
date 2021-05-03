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
    /// Interaction logic for Registrase.xaml
    /// </summary>
    public partial class Registrase : Window
    {
        public Registrase()
        {
            InitializeComponent();
            textBox.Text = "user";
            textBox1.Text = "1234";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            if (textBox.Text == "user" && textBox1.Text == "1234")
            {
                Administrador ad = new Administrador();
                ad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Contraseña o usuario Inconrrecto");
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
