using Caja_Tienda.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja_Tienda
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Crear_Usuario crear = new Crear_Usuario();
            crear.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Inicio inicio = new Inicio();
            UsuarioTableAdapter usuario = new UsuarioTableAdapter();
            bool R = false;

            foreach (var item in usuario.GetData().Where(C=> Usuario_1.Text == C.nombreUsuario && textBox1.Text == C.Contrasena && C.empleado == true))
            {
                R = true;
            }

            if (R == false)
                MessageBox.Show("USUARIO/CONTRASEÑA INCORRECTA!!");
            else
            {
                LOGINTableAdapter adapter = new LOGINTableAdapter();
                adapter.Update(true, 1, false);
                Close();
            }
        }

        private void Usuario_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
