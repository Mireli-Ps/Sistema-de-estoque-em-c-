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
    public partial class exibir : Form
    {

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        string strSQL;

        public exibir()
        {
            InitializeComponent();
        }

        private void btn_visualizar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=estoqueProd;Uid=root;Pwd=root;");
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

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
