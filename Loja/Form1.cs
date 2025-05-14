using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class Form1: Form
    {
        string[] nomeProdutos = {"Processador", "Placa de Vídeo","Placa Mãe","Memória" , "Gabinete", "SSD" , "WaterCooler","Fonte",  };
        string[] nomeImagens = { "processador", "placaDeVideo", "placaMae", "memoria", "gabinete", "ssd", "watercooler", "fonte" };
        string[] descricao = { "Ryzen 7", "RTX 4060", "Rog Maximos Z890", "Redragon 16 GB", "CoolerMaster Purple", "SSD WD 2TB", "NXTZ 240mm", "Corsair RM 1000" };
        double[] produtos = {1500,2000,800,250,500,450,300,620 };
        int[] estoque = {10,10,10,10,10,10,10,10 };
        double[] quantidade = { 0,0,0,0,0,0,0,0};
        public Form1()
        {
            InitializeComponent();
        }

        private void ChkP1_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(0);
        }

        public void trocarCheck(int num) {

            CheckBox chek = this.Controls.Find("ChkP" + (num + 1), true).FirstOrDefault() as CheckBox;

            if (chek.Checked == true)
            {
                chek.Text = nomeProdutos[num];
                PictureBox pic = this.Controls.Find("PicProduto" + (num+1), true).FirstOrDefault() as PictureBox;               
                var imagem = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagens[num]);                
                pic.Image = imagem;           
                ListProdutos.Items.Add(nomeProdutos[num]);
                ListDescricao.Items.Add(descricao[num]);
                ListPreco.Items.Add(produtos[num].ToString("c2"));
                NumericUpDown numa = this.Controls.Find("NumP" + (num + 1), true).FirstOrDefault() as NumericUpDown;
                numa.Visible = true;
                numa.Maximum = estoque[num];//Limitando a quantidade máxima disponível

            }
            else
            {
                chek.Text = "Produto1";
                PictureBox pic = this.Controls.Find("PicProduto" + (num + 1), true).FirstOrDefault() as PictureBox;
                var imagem = (Image)Properties.Resources.ResourceManager.GetObject("carrinho2");
                pic.Image = imagem;
                ListProdutos.Items.Remove(nomeProdutos[num]);
                ListDescricao.Items.Remove(descricao[num]);
                ListPreco.Items.Remove(produtos[num].ToString("c2"));
                NumericUpDown numa = this.Controls.Find("NumP" + (num + 1), true).FirstOrDefault() as NumericUpDown;
                numa.Visible = false;
                numa.Value = 0;
            }
        } 

        private void ChkP2_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(1);
        }

        private void ChkP3_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(2);
        }

        private void ChkP4_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(3);
        }

        private void ChkP5_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(4);
        }

        private void ChkP6_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(5);
        }

        private void ChkP7_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(6);
        }

        private void ChkP8_CheckedChanged(object sender, EventArgs e)
        {
            trocarCheck(7);
        }
        public void alterarNum(int num)
        {
            NumericUpDown numa = this.Controls.Find("NumP" + (num + 1), true).FirstOrDefault() as NumericUpDown;
            quantidade[num] = (double)numa.Value;
            Label labelestoque = this.Controls.Find("LBLP" + (num + 1), true).FirstOrDefault() as Label;
            labelestoque.Text = "Disponivel:" + (estoque[num] - quantidade[num]);
            total();
        }
        private void NumP1_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(0);
        }

        private void NumP2_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(1);
        }

        private void NumP3_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(2);
        }

        private void NumP4_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(3);
        }

        private void NumP5_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(4);
        }

        private void NumP6_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(5);
        }

        private void NumP7_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(6);
        }

        private void NumP8_ValueChanged(object sender, EventArgs e)
        {
            alterarNum(7);
        }
        public void total() {

            double resultado = 0;
            for (int i = 0; i < 8; i++) {
                resultado = resultado + (produtos[i] * quantidade[i]);            
            }
            LblTotal.Text = resultado.ToString("c2");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}