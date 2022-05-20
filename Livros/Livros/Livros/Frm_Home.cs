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
    public partial class Frm_Home : Form
    {
        public Frm_Home()
        {
            InitializeComponent();
        }

        private void btnLogout_Home_Click(object sender, EventArgs e)
        {
            //direcionando de volta a tela de login, desconectando o usuario 
            Frm_Login login = new Frm_Login();
            login.Show();
            this.Dispose();
        }

        private void btnAbout_Home_Click(object sender, EventArgs e)
        {
            //direcionando a tela com informações sobre a aplicação
            Frm_About about = new Frm_About();
            about.Show();
            this.Dispose();
        }

        private void btnCadastrar_Home_Click(object sender, EventArgs e)
        {
            //direcionando o usuario a tela de cadastro de livros
            Frm_Cadastrar_Livros cadastro = new Frm_Cadastrar_Livros();
            cadastro.Show();
            this.Dispose();
        }

        private void btnAtualizar_Home_Click(object sender, EventArgs e)
        {
            //direcionando o usuario a tela de atualizar os dados cadastrados dos livros
            Frm_Atualizar atualizar = new Frm_Atualizar();
            atualizar.Show();
            this.Dispose();
        }

        private void btnVisualizar_Home_Click(object sender, EventArgs e)
        {
            //direcionando o usuario a tela de visualizar a lista de livros
            Frm_Ver_Lista lista = new Frm_Ver_Lista();
            lista.Show();
            this.Dispose();
        }
    }
}
