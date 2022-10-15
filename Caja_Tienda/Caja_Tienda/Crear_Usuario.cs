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
    public partial class Crear_Usuario : Form
    {
        public Crear_Usuario()
        {
            InitializeComponent();
        }
        bool S = true;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crear_Usuario crear = new Crear_Usuario();
            if (listBox1.Text == "Masculino")
                S = true;
            else
                S = false;
            UsuarioTableAdapter usuario = new UsuarioTableAdapter();
            bool R = false;
            foreach (var item in usuario.GetData().Where(c => c.id == 1 && c.Contrasena == textBox5.Text))
            {
                R = true;
            }
            if (R == true)
            {
                usuario.Insert(textBox8.Text, textBox7.Text, textBox2.Text, int.Parse(textBox1.Text), textBox4.Text, DateTime.Parse(dateTimePicker1.Text), true, DateTime.Now, S, "Cajero", true, textBox3.Text);
                MessageBox.Show("Se a Creado!!");
            }
            else
                MessageBox.Show("Contraseña Incorrecta!!");

            crear.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Crear_Usuario_Load(object sender, EventArgs e)
        {

        }
    }
}
