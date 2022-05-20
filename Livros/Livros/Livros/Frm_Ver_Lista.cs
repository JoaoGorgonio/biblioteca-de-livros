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
    public partial class Frm_Ver_Lista : Form
    {

        //série de comandos inicias para inserir os dados na lista existente quando a tela é aberta
        public Frm_Ver_Lista()
        {
            InitializeComponent();
            //comandos de conexão com o banco
            MySqlCommand comando = new MySqlCommand();

            //criação de variaveis que serão utilizadas posteriormente
            String validaCodigo;
            String nomeLivro;
            //inserindo valor da variavel retirando direto da classe acesso
            String Nickname = Acesso.Usuario;

            //comando de leitura do banco
            MySqlDataReader DataR;
            //conectando com o banco
            MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");
            
            //comando que realiza um select com o banco, especificando o usuario
            validaCodigo = "SELECT nm_livro FROM tb_livro WHERE cd_usuario = '"+Nickname+"' ";

            //abrindo conexão com o banco
            conexao.Open();
            comando.Connection = conexao;
            //realizando o comando de select
            comando.CommandText = validaCodigo;
            DataR = comando.ExecuteReader();
            //limpando a lista inicialmente
            lsbLivros_Visualizar.Items.Clear();
            while (DataR.Read())
            {
                //inserindo valor retirado direto do banco em uma variavel
                nomeLivro = DataR.GetString("nm_livro");
                //adicionando esse item a lista
                lsbLivros_Visualizar.Items.Add(nomeLivro);
            }
            //fechando conexão
            conexao.Close();
        }

        //criando uma string publica que devera ser utilizada posteriormente
        public string livro { get; set; }

        //comandos caso o usuario selecionar o botão retornar
        private void btnRetornar_Lista_Click(object sender, EventArgs e)
        {
            //retornando a tela home
            Frm_Home home = new Frm_Home();
            home.Show();
            this.Dispose();
        }

        //caso o usuario seleciona o botão visualizar dados
        private void btnVisualizar_Dados_Click(object sender, EventArgs e)
        {
            //primeiramente, será verificado se algum index foi selecionado
            if (lsbLivros_Visualizar.SelectedIndex == -1)
            {
                //em caso de não for selecionado, apresentará um erro
                MessageBox.Show("Selecione algum item da lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se não, realizara a lista de comandos a seguir

                //comando de conexão com o banco
                MySqlCommand comando = new MySqlCommand();

                //criando variaveis que deverão ser utilizadas posteriormente
                String visualizaItem;
                //dando valor a variavel livro, em relação ao item selecionado
                String Livro = lsbLivros_Visualizar.SelectedItem.ToString();
                String codigoLivro = "", nomeLivro = "", subLivro = "", nomeAutor = "", Genero = "", Idioma = "", dataPub = "", nomeEditora = "", qntPag = "", qntVol = "", Classificacao = "", Comentarios = "", Sinopse = "";
                //dando valor a variavel nickname utilizando a classe acesso (que contém o codigo de usuario)
                String Nickname = Acesso.Usuario;

                //comando de leitura do banco
                MySqlDataReader DataR;

                //comando que realiza a conexão com o banco
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");
                //comando de select, com especificações sobre o nome do livro (que é o livro selecionado) e o código do usuario (que é o usuário logado)
                visualizaItem = "SELECT * FROM tb_livro WHERE nm_livro = '" + Livro + "' and cd_usuario = '" + Nickname + "' ";

                //abrindo a conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando comando de select acima
                comando.CommandText = visualizaItem;
                DataR = comando.ExecuteReader();
                //realizando o comando de leitura do banco
                while (DataR.Read())
                {
                    //dando valores as variaveis criadas anteriormente
                    //puxando os valores direto do banco
                    codigoLivro = DataR.GetString("cd_livro");
                    nomeLivro = DataR.GetString("nm_livro");
                    subLivro = DataR.GetString("nm_livrosub");
                    nomeAutor = DataR.GetString("nm_autor");
                    Genero = DataR.GetString("nm_genero");
                    Idioma = DataR.GetString("nm_idioma");
                    dataPub = DataR.GetString("yy_publicacao");
                    nomeEditora = DataR.GetString("nm_editora");
                    qntPag = DataR.GetString("qt_paginas");
                    qntVol = DataR.GetString("qt_volume");
                    Classificacao = DataR.GetString("nm_classificacao");
                    Comentarios = DataR.GetString("ds_comentario");
                    Sinopse = DataR.GetString("ds_sinopse");
                }
                //fechando conexão com o banco
                conexao.Close();

                //abrindo uma caixa de dialogo que demonstra todos dados em relação ao livro selecionado
                //esses dados serão mostrados através das variaveis criadas anteriormente e com os valores dados através da realização de comandos de conexão e leitura com o banco
                MessageBox.Show("Código do Livro: " + codigoLivro + "\nNome do Livro: " + nomeLivro + "\nSubtítulo: " +subLivro+ "\nNome do Autor: " + nomeAutor + "\nPrincipal Gênero: " +Genero+ "\nIdioma do Livro: " +Idioma+ "\nAno de Publicação: " +dataPub+ "\nEditora: " + nomeEditora + "\nQuantidade de Páginas: " + qntPag + "\nQuantidade de Volumes: " + qntVol + "\nClassificação Indicativa: " +Classificacao+ "\nSinopse do Livro: " + Sinopse + "\nComentários do Usuário: " + Comentarios, "Dados do Livro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //comandos caso o usuario selecione o botão para marcar os livros como já lido
        private void btnExcluir_Lista_Click(object sender, EventArgs e)
        {
            //verificando se algum item foi selecionado
            if (lsbLivros_Visualizar.SelectedIndex == -1)
            {
                //se não, será indicado isso através da mensagem de erro a seguir
                MessageBox.Show("Selecione algum item da lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //caso algum item tenha sido, sera realizado os comandos abaixo

                //comando de conexão com o banco
                MySqlCommand comando = new MySqlCommand();

                //criação de variaveis que deverão ser utilizadas posteriormente
                String excluiLivro;
                //dando valor a variavel através do item selecionado da listbox
                String nomeLivro = lsbLivros_Visualizar.SelectedItem.ToString(); ;
                //dando valor a variavel através da classe acesso que contém o código do usuário
                String Nickname = Acesso.Usuario;
                int RowAffect = 0;

                //realizando conexão com o banco
                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");

                //comando de delete, com especificações do nome do livro e o código do usuario 
                excluiLivro = "DELETE FROM tb_livro where nm_livro = '" + nomeLivro + "' and cd_usuario = '" + Nickname + "' ";

                //abrindo conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realizando o comando de delete
                comando.CommandText = excluiLivro;
                //excluindo o item da lista após a realização do delete no banco
                this.lsbLivros_Visualizar.Items.Remove(this.lsbLivros_Visualizar.SelectedItem);

                //caso alguma linha tenha sido afetada (ou seja, algum comando realizado com sucesso) os comandos abaixo serão realizados
                RowAffect = comando.ExecuteNonQuery();
                if (RowAffect >= 1)
                {
                    //mensagem demonstrando que o comando ocorreu com sucesso
                    MessageBox.Show("O livro foi retirado da lista com sucesso!", "Aviso", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    //mensagem demonstrando que o comando ocorreu teve algum erro
                    MessageBox.Show("Ocorreu um erro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //adicionando um indicador que a lista esteja vazia caso não tenha mais nenhum livro nela
                if (lsbLivros_Visualizar.Items.Count == 0)
                {
                    //adicionando o item "lista vazia" como indicador
                    lsbLivros_Visualizar.Items.Add("Lista Vazia");
                }

                //fechando conexão com o banco
                conexao.Close();
            }
        }
    }
}
