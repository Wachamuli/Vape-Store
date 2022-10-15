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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea salir?", "Sistema interno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var cuentasForm = new Form2();
            cuentasForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var cuadreForm = new Cuadre();
            cuadreForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var loginForm = new Login();
            loginForm.Show();
        }
    }
}
