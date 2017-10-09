using Model;
using Repositorio;
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

namespace RavenDBEstudos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string IdDoClienteSalvo { get; set; }
        public RespositorioDeCliente Repositorio { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Repositorio = new RespositorioDeCliente();
            CarregueElementosDoBancoDeDados();
        }


        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var cliente = ChameOEditorDeCliente(new Cliente());
            Repositorio.Cadastrar(cliente);
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item da lista!");
                return;
            }
            var cliente = ((Cliente)(lstClientes.SelectedItem));
            ChameOEditorDeCliente(cliente);
            Repositorio.Atualizar(cliente);
            CarregueElementosDoBancoDeDados();
        }

        private Cliente ChameOEditorDeCliente(Cliente cliente)
        {
           
            var formCliente = new FormCliente(cliente);
            formCliente.ShowDialog();
            cliente = formCliente.Cliente;
            return cliente;
        }

        private void CarregueElementosDoBancoDeDados()
        {
            lstClientes.DataContext = Repositorio.Liste();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if(lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item da lista!");
                return;
            }
            var cliente = ((Cliente)(lstClientes.SelectedItem));
            Repositorio.Remover(cliente.Id);
            CarregueElementosDoBancoDeDados();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }
    }
}
