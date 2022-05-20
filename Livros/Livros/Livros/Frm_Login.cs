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
using System.Threading;


namespace Livros
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Login_Click(object sender, EventArgs e)
        {
            //Verificando se os campos estão vazios, se estiverem, deve apresentar uma mensagem pedindo para preencher
            if (txtSenha_Login.Text == "" || txtSenha_Login.Text == "")
            {
                MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //criando variaveis que serão utilizadas como forma de validação ou pra outras funcionalidades
                String usuario = "";
                String senha = "";
                String nickname = txtUsuario_Login.Text;   
                bool valiLogin = false;

                //variveis para utilização do banco
                MySqlDataReader DataR;
                //conexao com o banco
                MySqlCommand comando = new MySqlCommand();
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");
                //comando de select
                String SQLogin;
                SQLogin = "SELECT * FROM tb_usuario WHERE cd_usuario = '"+nickname+"' ";
                //abrindo conexao com o banco para realizaçao de comandos para o funcionamento do login
                conexao.Open();
                comando.Connection = conexao;
                comando.CommandText = SQLogin;
                DataR = comando.ExecuteReader();
                //dando valor as variaveis criada acima, puxando direto do banco
                while (DataR.Read())
                {
                    usuario = DataR.GetString("cd_usuario");
                    senha = DataR.GetString("cd_senha");
                }
                //verificando a existencia do usuario para ver se o login é valido de ocorrer
                if (usuario == txtUsuario_Login.Text && senha == txtSenha_Login.Text)
                {
                    valiLogin = true;
                }
                else
                {
                    //caso nao existe o usuario, o login apresentara esse erro
                    MessageBox.Show("Dados incorretos, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //caso o usuario existe, sera executado essa linha de comando
                if (valiLogin == true)
                {
                    //guardando o usuario para ser usado futuramente em outras telas (sendo guardado na classe de acesso usuario)
                    Acesso.Usuario = txtUsuario_Login.Text;
                    //limpando os respectivos campos de login
                    txtSenha_Login.Text = "";
                    txtUsuario_Login.Text = "";
                    //direcionando a tela do home
                    Frm_Home home = new Frm_Home();
                    home.Show();
                    this.Hide();

                }
                conexao.Close();
            }
        }

        private void btnCadastrar_Login_Click(object sender, EventArgs e)
        {
            //caso o usuario deseja cadastrar no lugar de realizar o login, ele sera direcionado para tela de cadastro
            txtSenha_Login.Text = "";
            txtUsuario_Login.Text = "";
            Frm_Cadastro_Usuário cadastro = new Frm_Cadastro_Usuário();
            cadastro.Show();
            this.Hide();
        }
    }
}
