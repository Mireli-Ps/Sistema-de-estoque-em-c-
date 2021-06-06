using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Projeto_TATI
{
    public partial class Novo_cadastro : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        string strSQL;
        public Novo_cadastro()
        {
            InitializeComponent();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                
                conexao = new MySqlConnection("Server=localhost;Database=estoqueProd;Uid=root;Pwd=root;");
                strSQL = "INSERT INTO produto (NOME,PRECO,CATEGORIA, QUANTIDADE) VALUES (@NOME,@PRECO,@CATEGORIA,@QUANTIDADE)";
                comando = new MySqlCommand(strSQL, conexao);
                string valor = txt_preco.Text.Replace(',', '.');
                comando.Parameters.AddWithValue("@NOME", txt_nome.Text);
                comando.Parameters.AddWithValue("PRECO",valor);
                comando.Parameters.AddWithValue("@CATEGORIA", txt_categoria.Text);
                comando.Parameters.AddWithValue("@QUANTIDADE", txt_quantidade.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
                System.Windows.Forms.MessageBox.Show("Cadastro Feito com Sucesso");

                this.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
