using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAJA
{
    public partial class Login : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbError.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            //var entity = new Dt();

            //var cedula = tbCedula.Text;
            //var contrasena = tbContrasena.Text;

            //var empleadoEncontrado = entity.spFIllByCedulaPasswordRol(contrasena, cedula);


            //if (empleadoEncontrado == null)
            //{
            //    // Open form
            //    lbError.Text = "Exito";

            //}

            //lbError.Text = "Cedula o contraseña no válidos.";
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
