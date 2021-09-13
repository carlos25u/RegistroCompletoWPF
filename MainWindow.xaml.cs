using RegistroCompletoWPF.BLL;
using RegistroCompletoWPF.Entidades;
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

namespace RegistroCompletoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Roles Role = new Roles();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Role;
        }

        private void Limpiar()
        {
            this.Role = new Roles();
            this.DataContext = Role;

            IDTextBox.Text = " ";
            NombreTextBox.Text = " ";
            EmailTextBox.Text = " ";
            ClaveTextBox.Text = " ";
            descripcionTextBox.Text = " ";
            CreacionDatePicker.Text = " ";
        }

        private bool Validar()
        {
            bool esvalido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (IDTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (EmailTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (descripcionTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ClaveTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CreacionDatePicker.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esvalido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var rol = RolesBLL.Buscar(Convert.ToInt32(IDTextBox.Text));

            if(rol != null)
            {
                this.Role = rol;
            }
            else
            {
                this.Role = new Roles();
            }
            this.DataContext = this.Role;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(Role);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Convert.ToInt32(IDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
