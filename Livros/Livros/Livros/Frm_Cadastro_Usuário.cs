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
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Livros
{
    public partial class Frm_Cadastro_Usuário : Form
    {
        public Frm_Cadastro_Usuário()
        {
            InitializeComponent();
        }

        //linha de comandos após selecionar o botão retornar
        private void btnRetornar_Cadastro_Click(object sender, EventArgs e)
        {
            //direcionando o usuario de volta a tela de login
            Frm_Login login = new Frm_Login();
            login.Show();
            this.Dispose();
        }

        //linha de comandos após selecionar o botão cadastrar
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //caso o usuario selecione o botao cadastrar, sera realizado primeiro uma serie de validaçoes dos dados cadastrados
            //como por exemplo a validaçao abaixo inicial, verificando se os campos estão preenchidos, se não estiverem, deverá apresentar uma mensagem demonstrando isso
            if (txtNome_Cadastro.Text == "" || txtCPF_Cadastro.Text == "" || txtNascimento_Cadastro.Text == "" || txtEmail_Cadastro.Text == "" || txtTelefone_Cadastro.Text == "" || txtUsuario_Cadastro.Text == "" || txtSenha_Cadastro.Text == "" || txtConfSenha_Cadastro.Text == "" || rdbSexo_Feminino.Checked == false && rdbSexo_Masculino.Checked == false || txtCidade_Cadastro.Text == "" || cmbUF_Cadastro.SelectedIndex == -1 || txtRua_Cadastro.Text == "" || txtNumRes_Cadastro.Text == "" || txtCEP_Cadastro.Text == "" || txtBairro_Cadastro.Text == "" || txtComplemento_Cadastro.Text == "")
            {
                MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //criação de variaveis e metodos de conexão com o banco para utlização posteriores
                int RowAffect = 0;
                MySqlCommand comando = new MySqlCommand();

                String Usuario, nickname = "";
                String Endereco;
                String validaUsu;

                MySqlDataReader DataR;

                MySqlConnection conexao = new MySqlConnection("Server = localhost; Database = db_livros; User ID = root; Password = root; ");
                //retirando a mascara das textbox e guardando em variaveis
                txtCPF_Cadastro.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                String cpf = txtCPF_Cadastro.Text;
                //retornando a mascara
                txtCPF_Cadastro.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                txtNascimento_Cadastro.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                String nascimento = txtNascimento_Cadastro.Text;
                txtNascimento_Cadastro.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                txtTelefone_Cadastro.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                String telefone = txtTelefone_Cadastro.Text;
                txtTelefone_Cadastro.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //booleanas criadas para verificação e validação, de padrão como false e posteriormente deverão virar true caso o cadastro ocorra corretamente
                bool valiCPF = false, valiTel = false, valiCEP = false, valiNascimento = false, valiUsuario = false, valiEmail = false, valiSenha = false;

                char Sexo = ' ';
                String Estado;
                //guardando valores selecionados

                //guardando na variavel o estado selecionado pelo usuario
                Estado = cmbUF_Cadastro.SelectedItem.ToString();

                //guardando na variavel o sexo do usuario
                if (rdbSexo_Feminino.Checked == true)
                {
                    Sexo = 'F';
                }
                else if (rdbSexo_Masculino.Checked == true)
                {
                    Sexo = 'M';
                }
                //série de validações com utilização das booleans

                //validação da senha
                if (txtSenha_Cadastro.Text == txtConfSenha_Cadastro.Text)
                { 
                    txtConfSenha_Cadastro.BackColor = Color.White;
                    valiSenha = true;
                }
                else
                {
                    //em caso de erro a cor de background dos textbox serão mudadas para vermelho
                    txtConfSenha_Cadastro.BackColor = Color.Red;
                }

                //validação de email utilizando metodo criado mais abaixo no codigo
                if (RegexUtilities.IsValidEmail(txtEmail_Cadastro.Text) == true)
                {
                    txtEmail_Cadastro.BackColor = Color.White;
                    valiEmail = true;
                }
                else
                {
                    txtEmail_Cadastro.BackColor = Color.Red;
                }

                //validação de cpf utilizando metodo criado mais abaixo no codigo
                if (ValidacaoCPF.CPF(cpf) == true)
                {
                    txtCPF_Cadastro.BackColor = Color.White;
                    valiCPF = true;
                }
                else
                {
                    txtCPF_Cadastro.BackColor = Color.Red;
                }

                //validação da existência do usuario no banco
                //primeiramente um comando com conexão com banco para verificar se o usuário existe
                validaUsu = "SELECT cd_usuario FROM tb_usuario";
                //conexão com o banco
                conexao.Open();
                comando.Connection = conexao;
                //realização do comando
                comando.CommandText = validaUsu;
                DataR = comando.ExecuteReader();
                //guardando valor em uma variavel puxado direto do banco
                while (DataR.Read())
                {
                    nickname = DataR.GetString(0);
                }
                //agora, caso o usuario digitado já existe no banco, deverá marcar como existente, se não estará correto e o usuário poderá continuar o cadastro normalmente
                if (txtUsuario_Cadastro.Text == nickname)
                {
                    txtUsuario_Cadastro.BackColor = Color.Red;
                }
                else
                {
                    txtUsuario_Cadastro.BackColor = Color.White;
                    valiUsuario = true;
                }
                conexao.Close();

                //validação de CEP utilizando metodo criado mais abaixo no codigo
                if (RegexUtilities.ValidaCEP(txtCEP_Cadastro.Text) == true)
                {
                    txtCEP_Cadastro.BackColor = Color.White;
                    valiCEP = true;
                }
                else
                {
                    txtCEP_Cadastro.BackColor = Color.Red;
                }

                //validação de telefone
                if(telefone.Length == 10 || telefone.Length == 11)
                {
                    txtTelefone_Cadastro.BackColor = Color.White;
                    valiTel = true;
                }
                else
                {
                    txtTelefone_Cadastro.BackColor = Color.Red;
                }

                //validação da data de nascimento, utilizando comando de date time
                DateTime resultado = DateTime.MinValue;
                if (!DateTime.TryParse(txtNascimento_Cadastro.Text.Trim(), out resultado))
                {

                    txtNascimento_Cadastro.BackColor = Color.Red;
                    valiNascimento = false;
                    
                }
                else
                {
                    txtNascimento_Cadastro.BackColor = Color.White;
                    valiNascimento = true;
                    
                }

                //caso todos campos preenchidos estejam corretos e de acordo com as regras do sistema, será realizado a lista de comando abaixo
                if (valiCPF == true && valiNascimento == true && valiTel == true && valiCEP == true && valiUsuario == true && valiEmail == true && valiSenha == true)
                {
                    //comandos de insert para inserir o usuario no banco e realizar seu cadastro
                    Usuario = "INSERT INTO tb_usuario (cd_usuario, nm_usuario, cd_senha, cd_cpf, dt_nascimento, ic_sexo, cd_email, cd_telefone) VALUES ('"+txtUsuario_Cadastro.Text+"', '"+txtNome_Cadastro.Text+"', '"+txtSenha_Cadastro.Text +"', '"+txtCPF_Cadastro.Text+"', '"+txtNascimento_Cadastro.Text+"', '"+Sexo+"', '"+txtEmail_Cadastro.Text+"', '"+txtTelefone_Cadastro.Text+"'); ";
                    Endereco = "INSERT INTO tb_endereco (cd_numeroRes, ds_complemento, nm_rua, nm_bairro, cd_cep, nm_cidade, sg_estado, cd_usuario) VALUES ("+txtNumRes_Cadastro.Text+", '"+txtComplemento_Cadastro.Text+"', '"+txtRua_Cadastro.Text+"', '" + txtBairro_Cadastro.Text + "', '"+txtCEP_Cadastro.Text+"', '"+txtCidade_Cadastro.Text+"', '"+Estado+"', '"+txtUsuario_Cadastro.Text+"'); ";

                    //abrindo conexao com o banco
                    conexao.Open();
                    comando.Connection = conexao;
                    //realizando comando de inserção do usuario
                    comando.CommandText = Usuario;
                    RowAffect = comando.ExecuteNonQuery();
                    conexao.Close();
                    //abrindo novamente (eu fiz isso por que realizando os dois comandos juntos estava dando erro, então separei eles em duas conexões)
                    conexao.Open();
                    comando.Connection = conexao;
                    //realizando comando de inserção do endereço
                    comando.CommandText = Endereco;
                    //por fim um comando verificando se caso algum row foi afetado, mostrará uma mensagem que o cadastro foi realizado com sucesso
                    RowAffect = comando.ExecuteNonQuery();
                    if (RowAffect > 0)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    //fechando conexão
                    conexao.Close();
                }
            }
        }

        private void txtNome_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validações evitando o usuario de digitar valores indesejados
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtNumRes_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validações evitando o usuario de digitar valores indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCidade_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validações evitando o usuario de digitar valores indesejados
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtRua_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validações evitando o usuario de digitar valores indesejados
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtBairro_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validações evitando o usuario de digitar valores indesejados
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void txtComplemento_Cadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validações evitando o usuario de digitar valores indesejados
            if (!(char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
    //classe criada para validação do cpf
    public class ValidacaoCPF
    {
        public static bool CPF(string cpf)
        {
            try
            {
                int[] num = new int[11];
                int soma;
                int i;
                int resultado1;
                int resultado2;
                if (cpf.Length == 11)
                {
                    for (i = 0; i <= num.Length - 1; i++)
                    {
                        num[i] = Convert.ToInt32(cpf.Substring(i, 1));
                    }
                    soma = num[0] * 10 + num[1] * 9 + num[2] * 8 + num[3] * 7 + num[4] * 6 + num[5] * 5 + num[6] * 4 + num[7] * 3 + num[8] * 2;
                    soma = soma - (11 * ((int)(soma / 11)));
                    if (soma == 0 | soma == 1)
                    {
                        resultado1 = 0;
                    }
                    else
                    {
                        resultado1 = 11 - soma;
                    }
                    if (resultado1 == num[9])
                    {
                        soma = num[0] * 11 + num[1] * 10 + num[2] * 9 + num[3] * 8 + num[4] * 7 + num[5] * 6 + num[6] * 5 + num[7] * 4 + num[8] * 3 + num[9] * 2;
                        soma = soma - (11 * ((int)(soma / 11)));
                        if (soma == 0 | soma == 1)
                        {
                            resultado2 = 0;
                        }
                        else
                        {
                            resultado2 = 11 - soma;
                        }
                        if (resultado2 == num[10])
                        {
                            if (cpf == "11111111111" | cpf == "22222222222" | cpf == "33333333333" | cpf == "44444444444" | cpf == "55555555555" | cpf == "66666666666" | cpf == "77777777777" | cpf == "88888888888" | cpf == "99999999999" | cpf == "00000000000")
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    //classe criada para outras validações, utilizando os comandos Regex
    public class RegexUtilities
    {
        //validação do email
        public static bool IsValidEmail(string email)
        {
            bool validEmail = false;
            int indexArr = email.IndexOf('@');
            if (indexArr > 0)
            {
                int indexDot = email.IndexOf('.', indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            return validEmail;
        }

        //validação do CEP
        public static bool ValidaCEP(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}-\d{3}$");

            if (!Rgx.IsMatch(cep))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
