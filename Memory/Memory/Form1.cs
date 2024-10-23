using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;



namespace Memory
{//
    public partial class jogo : Form
    {
        private int recorde;
        private int vez_clicada;
        private int X, Y;
        private remove_array remove;
        private List<string> lista = new List<string>();
        private int movimentos, clicks, cartaEscrotada, index;
        private Image[] img = new Image[7];
        private int[] tags = new int[2];
        private Random rdn = new Random();
        private int[] numeros_sorteados = new int[8];

        public jogo()
        {
          
            InitializeComponent();
            start();
            posicao();

        }

        private void jogo_Load(object sender, EventArgs e)
        {
        }

        public void start()
        {
            textBox2.Visible = !true;
            label1.Text = "debug\n";
            button6.Text = "exit";
            credit.Visible = false;
            
            button4.Visible = !true;
            button6.Visible = !true;
            cred.Visible = !true;
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                index = int.Parse(item.Tag.ToString());
                img[index] = item.Image;
                item.Image = Properties.Resources.fundo;
                item.Enabled = true;
                item.SizeMode = item.SizeMode;
            }
           
        }


        void posicao()
        {

            Random rdn = new Random();

            // arrays de coordenadas
            int[] xp = { 3, 321, 99, 447, 591, 153, 199, 324, 446, 460,333,444 };
            int[] yp = { 55, 77, 99, 58, 184, 188, 337, 370 };
            string[] name = { "test","hello world" };
            label1.Text = name[0];//c# o primero numero é 0
            if (Controls.OfType<PictureBox>().Count() > xp.Length * yp.Length)
            {
                MessageBox.Show("erro\n");
                return;
            }

            
            HashSet<string> lista = new HashSet<string>();

           //loop qeu pecorre todas a carta para defini a posicao
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                
                if (lista.Count >= Math.Min(xp.Length, yp.Length))
                {
                  //  MessageBox.Show("Número de PictureBoxes excede posições únicas disponíveis.");
                    return;
                }

                int x, y;
                string posicao;

               
                do
                {
                    x = xp[rdn.Next(xp.Length)];
                    y = yp[rdn.Next(yp.Leng ;
                //    label1.Text += "new position\n"+posicao;//\n siginigca que vai salta linha
                } while (lista.Contains(posicao));

                
                item.Location = new Point(x, y);

                lista.Add(posicao);
            }

           
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {  if (textBox2.Text == "")
            {
                MessageBox.Show("please favor digite um nome");
            }
            else
            {
                t.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                textBox1.Visible = false;
                button5.Visible = false;
                button6.Visible = false;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            cred.Visible = true;
            button6.Visible = true;
           t.Visible = true;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cred.Visible = false;
            button6.Visible = false;
            
        }

        private void credit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void t_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cred_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void credit_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
        }

        private void verifica_clicks(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            clicks++;
            index = int.Parse(pictureBox.Tag.ToString());
            pictureBox.Image = img[index];
            //verica se a primera carta clicada tem a mesma tag do que a 2
            if (clicks == 1)
            {
                tags[0] = index;
            }
            else if (clicks == 2)
            {
                movimentos++;
                tags[1] = index;
                bool iguais = Par(0,1);
                devira(iguais);
            }
        }

        private bool Par(int x,int y)
        {
            //retona se a primera carta tem a mesma tag doque a seguda
            return tags[x] == tags[y];


        }

         private void devira(bool igual)
        {
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                if (int.Parse(item.Tag.ToString()) == tags[0] || int.Parse(item.Tag.ToString()) == tags[1])
                {
                   
                    clicks=0;// cotado de clicks
                    if (igual)//se a imagem corepote deixa a imagem ivisive
                    {
                      
                        
                        vez_clicada++;
                        
                       
                        posicao();
                        item.Visible = false;
                        cartaEscrotada++;
                        label1.Text +="cartas ecrotada\n" +cartaEscrotada.ToString();
                        
                    }
                    else
                    {
                        vez_clicada++;
                       
                        item.Image = Properties.Resources.fundo;

                    }//se as tag sao a mesma
                   
                    
                 
                    item.Refresh();//atualizado
                    if (cartaEscrotada == 10)
                    {

                        if (recorde>=vez_clicada)
                        {
                            recorde = vez_clicada;
                            MessageBox.Show("novo recorde",recorde.ToString());
                        }
                        else
                        {
                            MessageBox.Show("ultimo recorde"+recorde.ToString());

                        }
                      
                      

                          label1.Text = "recorde"+recorde.ToString();
                        var text = textBox1.ToString();  Tetativa"+"seu recorde:"+recorde);

                        MessageBox.Show($"{textBox1} voçê venceu" + vez_clicada + " 
                        this.Controls.Clear();//REICIA O JOGO
                        InitializeComponent();
                        start();
                        posicao();
                        cartaEscrotada = 0;
                        vez_clicada = 0;
                        recorde = vez_clicada;
                        this.Refresh();
                        

                    }
                }
            }
        }
    } 
}........