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
    public partial class Frm_Cadastrar_Livros : Form
    {
        public Frm_Cadastrar_Livros()
        {
            InitializeComponent();
        }

        //caso o usuário selecione o botão retornar, os comandos abaixo deverão ocorrer
        private void btnRetornar_Click(object sender, EventArgs e)
        {
            //retornando a tela home
            Frm_Home home = new Frm_Home();
            home.Show();
            this.Dispose();
        }

        private void txtTitulo_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtSubtitulo_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtDtLivro_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtPaginas_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtAutor_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtEditora_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtComentario_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtSinopse_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        //caso o usuário selecione o botão cadastrar, os comandos abaixo deverão ocorrer
        private void btnCadastrar_Livro_Click(object sender, EventArgs e)
        {
            //primeiramente verificando se todos campos foram preenchidos
            if (txtTitulo_Cadastro.Text == "" || txtSinopse_Cadastro.Text == "" || txtSubtitulo_Cadastro.Text == "" || txtCodigo_Cadastro.Text == "" || txtComentario_Cadastro.Text == "" || txtDtLivro_Cadastro.Text == "" || txtAutor_Cadastro.Text == "" || txtCidade_Cadastro.Text == "" || txtEditora_Cadastro.Text == "" || txtPaginas_Cadastro.Text == "" || cmbClassInd_Cadastro.SelectedIndex == -1 || cmbIdioma_Cadastro.SelectedIndex == -1 || cmbVolume_Cadastro.SelectedIndex == -1 || cmbGenero_Cadastro.SelectedIndex == -1)
            {
                //se não, pedirá o preenchimento correto de todos
                MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //caso foram, a lista de comandos a seguir ocorrerá:

                //primeiramente criadas variaveis que serão utilizadas posteriormente
                int RowAffect = 0;
                String Livro;
                //inserindo valor na variavel através da classe acesso
                String Usuario = Acesso.Usuario;
                String Classificacao, Idioma, Volume, Genero;
                bool valiAno = false, valiCDLivro = false;
                String validaCodigo, codigo = "";

                //comando de conexão com o banco
                MySqlCommand comando = new MySqlCommand();
                //comando de leitura do banco
                MySqlDataReader DataR;
                //conectando com o banco
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //inserindo valores nas variaveis selecionados durante o cadastro
                Classificacao = cmbClassInd_Cadastro.SelectedItem.ToString();
                Idioma = cmbIdioma_Cadastro.SelectedItem.ToString();
                Volume = cmbVolume_Cadastro.SelectedItem.ToString();
                Genero = cmbGenero_Cadastro.SelectedItem.ToString();

                //validação do código do livro (se o código já existe)
                //criando comando que realiza um select no banco
                validaCodigo = "SELECT cd_livro FROM tb_livro";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando o comando de select criado no banco
                comando.CommandText = validaCodigo;

                //realizando leitura no banco
                DataR = comando.ExecuteReader();
                while (DataR.Read())
                {
                    //guardando na variavel o código do livro através da leitura no banco
                    codigo = DataR.GetString(0);
                }

                //caso o código do livro corresponda com um código ja existente, os comandos a seguir ocorrerão
                if (txtCodigo_Cadastro.Text == codigo)
                {
                    //em caso de corresponder, será apresentado o erro através da mudança de cor do background da textbox
                    txtCodigo_Cadastro.BackColor = Color.Red;
                }
                else
                {
                    //caso não exista, a boolean será marcada como true para ser utilizada posteriormente
                    txtCodigo_Cadastro.BackColor = Color.White;
                    valiCDLivro = true;
                }

                //fechando conexão com o banco
                conexao.Close();

                //validação do ano de publicação do livro
                int anoPublicacao = int.Parse(txtDtLivro_Cadastro.Text);
                //pegando valor do ano atual
                int ano = DateTime.Now.Year;
                //verificando se o usuário digitou o número necessário para o ano
                if (txtDtLivro_Cadastro.Text.Length == 4)
                {
                    //verificando se o livro existe em uma linha de tempo existente
                    if (anoPublicacao >= 1 && anoPublicacao <= ano)
                    {
                        //caso sim, a bool será marcada como true para ser usada posteriormente
                        txtDtLivro_Cadastro.BackColor = Color.White;
                        valiAno = true;
                    }
                    else
                    {
                        //em caso de erro, será apresentado uma mudança de cor no background da textbox
                        //além de um exemplo de escrita da data
                        txtDtLivro_Cadastro.Text = "0001";
                        txtDtLivro_Cadastro.BackColor = Color.Red;
                    }
                }
                else
                {
                    //em caso de erro, será apresentado uma mudança de cor no background da textbox
                    txtDtLivro_Cadastro.BackColor = Color.Red;
                }

                //caso as validações acima demonstrem que o cadastro está correto, ocorrerá os comandos abaixo
                if (valiAno == true && valiCDLivro == true)
                {
                    //criando o insert para cadastrar o livro na conta do usuário
                    Livro = "INSERT INTO tb_livro(cd_livro, nm_livro, nm_livrosub, nm_autor, nm_genero, nm_idioma, yy_publicacao, nm_cidadepub, nm_editora, qt_paginas, qt_volume, nm_classificacao, ds_comentario, ds_sinopse, cd_usuario) VALUES ("+txtCodigo_Cadastro.Text+", '"+txtTitulo_Cadastro.Text+"', '"+txtSubtitulo_Cadastro.Text+"', '"+txtAutor_Cadastro.Text+"', '"+Genero+"', '"+Idioma+"', "+txtDtLivro_Cadastro.Text+", '"+txtCidade_Cadastro.Text+"', '"+txtEditora_Cadastro.Text+"', "+txtPaginas_Cadastro.Text+", '"+Volume+"', '"+Classificacao+"', '"+txtComentario_Cadastro.Text+"', '"+txtSinopse_Cadastro.Text+"', '"+Usuario+"')";

                    //abrindo conexão com o banco
                    conexao.Open();
                    comando.Connection = conexao;
                    comando.CommandText = Livro;

                    //caso alguma linha tenha sido afetada (ou seja, algum comando realizado com sucesso) os comandos abaixo serão realizados
                    RowAffect = comando.ExecuteNonQuery();
                    if (RowAffect > 0)
                    {
                        //mensagem apresentando que o cadastro foi realizado com sucesso
                        MessageBox.Show("Cadastro realizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //fechando conexão com o banco
                    conexao.Close();
                }
            }
        }

        private void txtCidade_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validação nos campos, evitando que o usuário digite caracteres indesejados
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
