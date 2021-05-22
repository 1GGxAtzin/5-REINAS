using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//PACHECO ARELLANO ATZIN NATANAEL
//SEMINARIO DE ALGORITMIA
namespace _5_REINAS
{
    public partial class Form1 : Form
    {
        public Bitmap bmp;

        int r1 = 140;
        int r2 = 140;
        int r3 = 140;
        int r4 = 140;
        int r5 = 140;

        int solucion = 1;
        bool flag = false;
        bool flag2 = false;
        Thread hilo;
        public Form1()
        {
            
            InitializeComponent();
            Tablero();
            hilo = new Thread (reinas);
            CheckForIllegalCrossThreadCalls = false;
            inicio.Enabled = false;


        }
       
        


        void Tablero()
        {
            try
            {
                Bitmap bmp = new Bitmap(Width, Height);
                panel.Image = bmp;
                this.reina1.SizeMode = PictureBoxSizeMode.Zoom;
                this.reina2.SizeMode = PictureBoxSizeMode.Zoom;
                this.reina3.SizeMode = PictureBoxSizeMode.Zoom;
                this.reina4.SizeMode = PictureBoxSizeMode.Zoom;
                this.reina5.SizeMode = PictureBoxSizeMode.Zoom;
                int x, y;
                Color c;

                //DIBUJAR 
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width; x++)
                    {
                        c = bmp.GetPixel(x, y);
                        if (x % 160 == 0)
                        {

                            bmp.SetPixel(x, y, Color.Black);
                        }


                        if (y % 120 == 0)
                        {
                            bmp.SetPixel(x, y, Color.Black);
                        }

                    }

                }

            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the image file.");
            }
        }
 



        private void button1_Click(object sender, EventArgs e)
        {
            hilo.Suspend();
            
            reina1.Top = 58;
            reina1.Left = 140;

            reina2.Top = 155;
            reina2.Left = 140;

            reina3.Top = 257;
            reina3.Left = 140;

            reina4.Top = 350;
            reina4.Left = 140;

            reina5.Top = 451;
            reina5.Left = 140;
        
            panel.Refresh();
            Thread.Sleep(500);
            r1 = 140;
            r2 = 140;
            r3 = 140;
            r4 = 140;
            r5 = 140;
            solucion = 1;
            hilo.Resume();
            flag = true;
            flag2 = false;
        }
       
       
        private void button2_Click(object sender, EventArgs e)
        {


            inicio.Enabled = true;
            if (flag == false && flag2 == false)
            {
                hilo.Start();
                flag = true;
            }
            else if (flag == true && flag2==false)
            {
                hilo.Suspend();
                flag2 = true;
            }

            else if (flag == true && flag2 == true)
            {
                hilo.Resume();
                flag2 = false;

            }



        }
     
       
        void reinas()
        {
            int rr1 = 500;
            int rr2 = 400;
            int rr3 = 300;
            int rr4 = 200;
            int rr5 = 100;
            for (r1 = 140; r1 <= 540; r1 += 100)
            {
                for (r2 = 140; r2 <= 540; r2 += 100)
                {
                    for (r3 = 140; r3 <= 540; r3 += 100)
                    {
                        for (r4 = 140; r4 <= 540; r4 += 100)
                        {

                            for (r5 = 140; r5 <= 540; r5 += 100)
                            {
                                reina5.Left = r5;
                                reina4.Left = r4;
                                reina3.Left = r3;
                                reina2.Left = r2;
                                reina1.Left = r1;
                                if (r5 == 540 && r4 == 540 && r3 == 540 && r2 == 540 && r1 == 540)
                                {
                                    
                                    MessageBox.Show("TERMINADO");

                                    reina1.Top = 58;
                                    reina1.Left = 140;

                                    reina2.Top = 155;
                                    reina2.Left = 140;

                                    reina3.Top = 257;
                                    reina3.Left = 140;

                                    reina4.Top = 350;
                                    reina4.Left = 140;

                                    reina5.Top = 451;
                                    reina5.Left = 140;

                                    panel.Refresh();
                                    r1 = 140;
                                    r2 = 140;
                                    r3 = 140;
                                    r4 = 140;
                                    r5 = 140;
                                    solucion = 1;
                                    flag = true;
                                    flag2 = false;
                                }

                                if (r5 != r4 && r5 != r3 && r5 != r2 && r5 != r1 && r4 != r3 && r4 != r2 && r4 != r1 && r3 != r2 && r3 != r1 && r2 != r1)
                                {

                                    if (Math.Abs(rr5 - rr4) != Math.Abs(r5 - r4) && Math.Abs(rr5 - rr3) != Math.Abs(r5 - r3) && Math.Abs(rr5 - rr2) != Math.Abs(r5 - r2) && Math.Abs(rr5 - rr1) != Math.Abs(r5 - r1) && Math.Abs(rr4 - rr3) != Math.Abs(r4 - r3) && Math.Abs(rr4 - rr2) != Math.Abs(r4 - r2) && Math.Abs(rr4 - rr1) != Math.Abs(r4 - r1) && Math.Abs(rr3 - rr2) != Math.Abs(r3 - r2) && Math.Abs(rr3 - rr1) != Math.Abs(r3 - r1) && Math.Abs(rr2 - rr1) != Math.Abs(r2 - r1))
                                    {
                                        MessageBox.Show("ES SOLUCION NUMERO:  " + solucion++);

                                    }
                                    else
                                    {
                                       panel.Refresh();
                                       Thread.Sleep(150);


                                    }
                                }
                                else
                                {
                                    panel.Refresh();
                                    Thread.Sleep(150);





                                }
                            }
                        }
                    }

                }
            }
        }
       
       


    }
   
}

