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
    public partial class Frm_Atualizar : Form
    {
        public Frm_Atualizar()
        {
            InitializeComponent();
        }

        //criação de uma variavel publica que deverá ser utilizada posteriormente
        public string livro { get; set;}

        //caso o usuario selecione retornar, os comandos abaixo deverão ocorrer
        private void btnRetornar_Atualizar_Click(object sender, EventArgs e)
        {
            //retornando a tela home
            Frm_Home home = new Frm_Home();
            home.Show();
            this.Dispose();
        }

        private void txtTitulo_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtSubtitulo_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtEditora__Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtAutor__Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtCidade_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtPaginas_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtAno_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtComentario_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtSinopse_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtLivro_Atualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comandos evitando o usuario digitar dados indesejados nos campos
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void Frm_Atualizar_Load(object sender, EventArgs e)
        {
            //lista de comandos que quando a tela é carregada, os botões são desativados
            btnAtualizar_Comentario.Enabled = false;
            btnAtualizar_Livro.Enabled = false;
            btnAtualizar_Sinopse.Enabled = false;
            btnAtualizar_Subtitulo.Enabled = false;
            btnAtualizar_Titulo.Enabled = false;
        }

        //caso o usuario selecione o botão buscar, os comandos abaixo deverão ocorrer
        private void btnBuscar_Livro_Click(object sender, EventArgs e)
        {
            //primeiramente, verificando o campo necessário está vazio
            if (txtLivro_Atualizar.Text == "")
            {
                //caso esteja, será apresentado uma mensagem de erro
                MessageBox.Show("Preencha o campo em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se não, os comandos abaixo serão realizados

                //comando de conexão com o banco
                MySqlCommand comando = new MySqlCommand();

                //criando variaveis que deverão ser utilizadas posteriormente
                String validaCodigo, codigo = "";

                //comando de leitura do banco
                MySqlDataReader DataR;

                //realizando conexão com o banco
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //criando um comando que realiza um select
                validaCodigo = "SELECT cd_livro FROM tb_livro";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando o select no banco
                comando.CommandText = validaCodigo;
                //realizando a leitura no banco
                DataR = comando.ExecuteReader();
                while (DataR.Read())
                {
                    //através da leitura, o código do livro deverá ser guardado na variavel codigo
                    codigo = DataR.GetString(0);
                }

                //agora, caso o código do livro corresponda a algum código existente no banco
                //a linha de comando abaixo deverá ser realizada
                if (txtLivro_Atualizar.Text == codigo)
                {
                    //os botões inicialmente desativados serão ativados e código do livro selecionado será guardado na váriavel pública livro
                    livro = txtLivro_Atualizar.Text;
                    txtLivro_Atualizar.BackColor = Color.White;
                    btnAtualizar_Comentario.Enabled = true;
                    btnAtualizar_Livro.Enabled = true;
                    btnAtualizar_Sinopse.Enabled = true;
                    btnAtualizar_Subtitulo.Enabled = true;
                    btnAtualizar_Titulo.Enabled = true;
                }
                else
                {
                    //caso não seja correspondente, apresentará o erro através da mudança de cor do background do textbox
                    txtLivro_Atualizar.BackColor = Color.Red;
                }

                //fechando conexão com o banco
                conexao.Close();
            }
        }

        //caso o usuario selecione o botão atualizar titulo, os comandos a seguir ocorrerão:
        private void btnAtualizar_Titulo_Click(object sender, EventArgs e)
        {
            //verificando se o campo do titulo está vazio
            if (txtTitulo_Atualizar.Text == "")
            {
                //caso esteja, será apresentada uma mensagem requerindo que ele seja preenchido
                MessageBox.Show("Preencha o campo em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se estiver preenchido, será realizado os comandos a seguir:

                //criando variaveis que serão utilizadas posteriormente
                int RowAffect = 0;
                String Titulo;
                
                //comandos de conexão com o banco
                MySqlCommand comando = new MySqlCommand();
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //criando o comando update, correspondente ao código do livro digitado anteriormente (no buscar)
                Titulo = "UPDATE tb_livro SET nm_livro = '" + txtTitulo_Atualizar.Text + "' WHERE cd_livro = " + livro + " ";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando o comando de update diretamente no banco
                comando.CommandText = Titulo;

                //caso o update seja realizado com sucesso, mais de um row deverá ser afetado
                //então, se isso ocorrer será executado os comandos abaixo
                RowAffect = comando.ExecuteNonQuery();
                if (RowAffect > 0)
                {
                    //mensagem apresentando que o titulo foi atualizado com sucesso
                    MessageBox.Show("Titulo atualizado!", "Aviso", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                //fechando conexão com o banco
                conexao.Close();
            }
        }

        //caso o usuario selecione o botão atualizar subtitulo, os comandos a seguir ocorrerão:
        private void btnAtualizar_Subtitulo_Click(object sender, EventArgs e)
        {
            //verificando se o campo do subtitulo está vazio
            if (txtSubtitulo_Atualizar.Text == "")
            {
                //caso esteja, será apresentada uma mensagem requerindo que ele seja preenchido
                MessageBox.Show("Preencha o campo em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se estiver preenchido, será realizado os comandos a seguir:

                //criando variaveis que serão utilizadas posteriormente
                int RowAffect = 0;
                String Subtitulo;

                //comandos de conexão com o banco
                MySqlCommand comando = new MySqlCommand();
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //criando o comando update, correspondente ao código do livro digitado anteriormente (no buscar)
                Subtitulo = "UPDATE tb_livro SET nm_livrosub = '" + txtSubtitulo_Atualizar.Text + "' WHERE cd_livro = " + livro + " ";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando o comando de update diretamente no banco
                comando.CommandText = Subtitulo;

                //caso o update seja realizado com sucesso, mais de um row deverá ser afetado
                //então, se isso ocorrer será executado os comandos abaixo
                RowAffect = comando.ExecuteNonQuery();
                if (RowAffect > 0)
                {
                    //mensagem apresentando que o subtitulo foi atualizado com sucesso
                    MessageBox.Show("Subtitulo atualizado!", "Aviso", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                //fechando conexão com o banco
                conexao.Close(); 
            }
        }

        //caso o usuario selecione o botão atualizar comentarios, os comandos a seguir ocorrerão:
        private void btnAtualizar_Comentario_Click(object sender, EventArgs e)
        {
            //verificando se o campo do comentario está vazio
            if (txtComentario_Atualizar.Text == "")
            {
                //caso esteja, será apresentada uma mensagem requerindo que ele seja preenchido
                MessageBox.Show("Preencha o campo em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se estiver preenchido, será realizado os comandos a seguir:

                //criando variaveis que serão utilizadas posteriormente
                int RowAffect = 0;
                String Comentarios;

                //comandos de conexão com o banco
                MySqlCommand comando = new MySqlCommand();
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //criando o comando update, correspondente ao código do livro digitado anteriormente (no buscar)
                Comentarios = "UPDATE tb_livro SET ds_comentario = '" + txtComentario_Atualizar.Text + "' WHERE cd_livro = " + livro + " ";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando o comando de update diretamente no banco
                comando.CommandText = Comentarios;

                //caso o update seja realizado com sucesso, mais de um row deverá ser afetado
                //então, se isso ocorrer será executado os comandos abaixo
                RowAffect = comando.ExecuteNonQuery();
                if (RowAffect > 0)
                {
                    //mensagem apresentando que os comentarios foi atualizado com sucesso
                    MessageBox.Show("Comentários atualizados!", "Aviso", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                //fechando conexão com banco
                conexao.Close();
            }
        }

        //caso o usuario selecione o botão atualizar sinopse, os comandos a seguir ocorrerão:
        private void btnAtualizar_Sinopse_Click(object sender, EventArgs e)
        {
            //verificando se o campo da sinopse está vazio
            if (txtSinopse_Atualizar.Text == "")
            {
                //caso esteja, será apresentada uma mensagem requerindo que ele seja preenchido
                MessageBox.Show("Preencha o campo em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se estiver preenchido, será realizado os comandos a seguir:

                //criando variaveis que serão utilizadas posteriormente
                int RowAffect = 0;
                String Sinopse;

                //comandos de conexão com o banco
                MySqlCommand comando = new MySqlCommand();
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //criando comando de update da sinopse, correspondente ao código do livro guardado anteriormente (no buscar)
                Sinopse = "UPDATE tb_livro SET ds_sinopse = '" + txtSinopse_Atualizar.Text + "' WHERE cd_livro = " + livro + " ";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando comando de update direto no banco
                comando.CommandText = Sinopse;

                //caso o update seja realizado com sucesso, mais de um row deverá ser afetado
                //então, se isso ocorrer será executado os comandos abaixo
                RowAffect = comando.ExecuteNonQuery();
                if (RowAffect > 0)
                {
                    //mensagem apresentando que a sinopse foi atualizada com sucesso
                    MessageBox.Show("Sinopse atualizada!", "Aviso", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                //fechando conexão com o banco
                conexao.Close();
            }
        }

        //caso o usuario selecione o botão atualizar dados do livro, os comandos a seguir ocorrerão:
        private void btnAtualizar_Livro_Click(object sender, EventArgs e)
        {
            //verificando se o campos estão vazio
            if (txtAno_Atualizar.Text == "" || txtAutor__Atualizar.Text == "" || txtCidade_Atualizar.Text == "" || txtEditora__Atualizar.Text == "" || txtPaginas_Atualizar.Text == "" || cmbClassificacao_Atualizar.SelectedIndex == -1 || cmbIdioma_Atualizar.SelectedIndex == -1 || cmbVolume_Atualizar.SelectedIndex == -1 || cmbGenero_Atualizar.SelectedIndex == -1)
            {
                //caso estejam, será apresentada uma mensagem requerindo o preenchimento
                MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se estiver preenchido, será realizado os comandos a seguir:

                //criando variaveis que serão utilizadas posteriormente
                int RowAffect = 0;
                String Atualizacao;
                String classificacao, genero, idioma, volume;

                //comandos de conexão com o banco
                MySqlCommand comando = new MySqlCommand();
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //guardando os valores selecionados durante o cadastro em variaveis
                classificacao = cmbClassificacao_Atualizar.SelectedItem.ToString();
                idioma = cmbIdioma_Atualizar.SelectedItem.ToString();
                volume = cmbVolume_Atualizar.SelectedItem.ToString();
                genero = cmbGenero_Atualizar.SelectedItem.ToString();

                //criando comando de update, correspondente ao código do livro guardado anteriormente (no buscar)
                Atualizacao = "UPDATE tb_livro SET nm_autor = '" + txtAutor__Atualizar.Text + "', nm_editora = '" + txtEditora__Atualizar.Text + "', nm_classificacao = '" + classificacao + "', nm_genero = '" + genero + "', nm_cidadepub = '" + txtCidade_Atualizar.Text + "', nm_idioma = '" + idioma + "', qt_paginas = '" + txtPaginas_Atualizar.Text + "', yy_publicacao = '" + txtAno_Atualizar.Text + "', qt_volume = '" + volume + "' WHERE cd_livro = " + livro + " ";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                comando.CommandText = Atualizacao;

                //caso o update seja realizado com sucesso, mais de um row deverá ser afetado
                //então, se isso ocorrer será executado os comandos abaixo
                RowAffect = comando.ExecuteNonQuery();
                if (RowAffect > 0)
                {
                    //mensagem apresentando que os dados foram atualizados com sucesso
                    MessageBox.Show("Dados atualizados!", "Aviso", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                //fechando conexão com o banco
                conexao.Close();
            }
        }
    }
}
