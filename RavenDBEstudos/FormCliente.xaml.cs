using Model;
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

namespace RavenDBEstudos
{
    /// <summary>
    /// Interaction logic for FormCliente.xaml
    /// </summary>
    public partial class FormCliente : Window
    {
        public Cliente Cliente { get; set; }
        public FormCliente()
        {
            InitializeComponent();
            this.DataContext = new Cliente();
        }

        public FormCliente( Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = cliente;
            Cliente = cliente;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cliente = (Cliente) this.DataContext;
            this.Close();
        }
    }
}
