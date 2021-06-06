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
    public partial class editar : Form
    {

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;

        

        public editar()
        {
            InitializeComponent();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=estoqueProd;Uid=mireli;Pwd=root2#;");
                strSQL = "UPDATE produto SET NOME = @NOME,PRECO = @PRECO , CATEGORIA = @CATEGORIA , QUANTIDADE = @QUANTIDADE  WHERE ID = @ID";
                comando = new MySqlCommand(strSQL, conexao);
                string valor = txt_preco.Text.Replace(',', '.');
                comando.Parameters.AddWithValue("@ID", txt_id.Text);
                comando.Parameters.AddWithValue("@NOME", txt_nome.Text);
                comando.Parameters.AddWithValue("@PRECO", valor);
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
                System.Windows.Forms.MessageBox.Show("Editado com Sucesso");
                txt_id.Text = " ";
                txt_nome.Text = " ";
                txt_preco.Text = " ";
                txt_categoria.Text = " ";
                txt_quantidade.Text = " ";

            }


        }

        private void btn_visualizar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=estoqueProd;Uid=mireli;Pwd=root2#;");
                strSQL = "select * FROM PRODUTO ";
                da = new MySqlDataAdapter(strSQL, conexao);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_result.DataSource = dt;


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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgv_result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
