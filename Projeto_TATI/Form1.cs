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
using System.Threading;
namespace Projeto_TATI
{
    public partial class Estoque : Form
    {
        Thread t1;
        
        public Estoque()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void janelanovo(object obj)
        {
            Application.Run(new Novo_cadastro());
        }
        private void janelaconsultar(object obj)
        {
            Application.Run(new consultar());
        }
        private void janelaeditar(object obj)
        {
            Application.Run(new editar());
        }
        private void janelaexcluir(object obj)
        {
            Application.Run(new excluir());
        }
        private void janelaexibir(object obj)
        {
            Application.Run(new exibir());
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
           t1 = new Thread(janelanovo);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
            
        }
        
        private void btn_editar_Click(object sender, EventArgs e)
        {
            
            t1 = new Thread(janelaeditar);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {

            t1 = new Thread(janelaexcluir);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        
        private void btn_exibir_Click(object sender, EventArgs e)
        {

            t1 = new Thread(janelaexibir);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            t1 = new Thread(janelaconsultar);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();

           }
     



        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
    }
}
