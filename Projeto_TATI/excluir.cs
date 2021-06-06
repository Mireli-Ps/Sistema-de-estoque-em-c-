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
    public partial class excluir : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dr;
        string strSQL;
        public excluir()
        {
            InitializeComponent();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=estoqueProd;Uid=root;Pwd=root;");
                strSQL = "DELETE FROM produto  WHERE ID = @ID";
                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txt_id.Text);

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
                MessageBox.Show("Excluido com Sucesso!");
                txt_id.Text = " ";
                txt_nome.Text = " ";
                txt_preco.Text = " ";
                txt_categoria.Text = " ";
                txt_quantidade.Text = " ";

            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=estoqueProd;Uid=root;Pwd=root;");
                strSQL = "select * FROM produto  WHERE ID = @ID";
                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txt_id.Text);

                conexao.Open();
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    txt_nome.Text = dr["nome"].ToString();
                    txt_preco.Text = dr["preco"].ToString();
                    txt_categoria.Text = dr["categoria"].ToString();
                    txt_quantidade.Text = dr["quantidade"].ToString();
                }
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
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
