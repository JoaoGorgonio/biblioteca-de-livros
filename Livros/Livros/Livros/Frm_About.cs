using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Livros
{
    public partial class Frm_About : Form
    {
        public Frm_About()
        {
            InitializeComponent();
        }

        //linha de comandos após selecionar o botão retornar 
        private void btnRetornar_About_Click(object sender, EventArgs e)
        {
            //retornando para a tela home
            Frm_Home home = new Frm_Home();
            home.Show();
            this.Dispose();
        }
    }
}
