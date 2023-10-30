using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            btn0.Text = "";
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";

            rodadas = 0;
            jogo_final = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogo_final == false)
            {

                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = "X";
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = "O";
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                }//Final da estrutura
            }
        } //Final método botão

        void Vencedor(int PlayerQueGanhou)
        {
            jogo_final = true;// Nao deixa continuar o jogo

            if (PlayerQueGanhou == 1) 
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer); 
                MessageBox.Show("Jogador X Ganhou!");
                turno = true;
            }
            else 
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O Ganhou!");
                turno = false;
            }
        }

        void Checagem(int ChecagemPlayer)
        {
            string suporte;

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";

            }//Final do Suporte

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    //checagem horizontal

                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(ChecagemPlayer);
                        return;

                    }//Final da checagem Horizontal

                }// Final do loop horizontal

                // checagem vertical
                for (int vertical = 0; vertical < 3; vertical++)
                {
                    if (suporte == texto[vertical])
                    {
                        //checagem vertical

                        if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                        {
                            Vencedor(ChecagemPlayer);
                            return;

                        }//Final da checagem vertical

                    }// Final do loop vertical

                    // verificações nas diagonais
                    if (texto[0] == suporte)
                    {

                        if (texto[0] == texto[4] && texto[0] == texto[8])
                        {
                            Vencedor(ChecagemPlayer);
                            return;

                        }//Diagonal principal
                      
                    }
                    if (texto[2] == suporte)
                    {

                        if (texto[2] == texto[4] && texto[2] == texto[6])
                        {
                            Vencedor(ChecagemPlayer);
                            return;

                        }

                    }//Diagonal Secundária

                    if (rodadas == 9 && jogo_final == false)
                    {
                        empatesPontos++;
                        empate.Text = Convert.ToString(empatesPontos);
                        MessageBox.Show("Empate!");
                        jogo_final = true;
                        return;
                    }

                }
            }
        }
    }
}
