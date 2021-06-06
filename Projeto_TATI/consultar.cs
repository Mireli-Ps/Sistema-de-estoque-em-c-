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
    public partial class consultar : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;
        public consultar()
        {
            InitializeComponent();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
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
