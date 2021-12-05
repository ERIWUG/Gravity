using System;
using System.Windows.Forms;

namespace Gravity
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g[0] = new Set_grav(1, 0, button1);


            g[1] = new Set_grav(1, 0, button2);

        }

        Set_grav[] g =
        {
        new Set_grav(),
            new Set_grav()
        };
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
           
            
        }
        bool c = true;
        void con_check()
        {
            int b1x = button1.Location.X;
            int b2x = button2.Location.X;
            int b1w = button1.Size.Width;
            int b2w = button2.Size.Width;

            int b1y = button1.Location.Y;
            int b2y = button2.Location.Y;
            int b1h = button1.Size.Height;
            int b2h = button2.Size.Height;
            if ((b1x+b1w>=b2x && b1x + b1w <= b2x + b2w)||(b1x>=b2x&&b1x<=b2x+b2w))
            {
                if ((b1y + b1h >= b2y && b1y + b1h <= b2y + b2h) || (b1y >= b2y && b1y <= b2y + b2h))
                {
                    g[0].vx *= -1;
                    g[1].vx *= -1;
                    System.Drawing.Color f;
                    f=button1.BackColor;button1.BackColor=button2.BackColor;button2.BackColor = f;

                    if (b1x >= b2x)
                    {
                        button1.Location = new System.Drawing.Point(button2.Location.X + 12, button1.Location.Y);
                        button2.Location = new System.Drawing.Point(button2.Location.X - 12, button2.Location.Y);
                    }
                    else
                    {
                        button1.Location = new System.Drawing.Point(button2.Location.X -12, button1.Location.Y);
                        button2.Location = new System.Drawing.Point(button2.Location.X +12, button2.Location.Y);
                    }
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (c) { c = false;button1_MouseClick(button1, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1)); }
            for (int i = 0; i < 2; i++)
            {
                if (g[i].isTrue)
                {
                    if (g[i].isRest) { }
                    else { g[i].check_up();con_check(); }
                }
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void checkBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.Text = Convert.ToString(e.KeyChar);
            switch (e.KeyChar)
            {
                case 'd':
                    g[0].get_vx(50);
                    break;
                case 'a':
                    g[0].get_vx(-50);
                    break;
                case 'w':
                    g[0].get_v(50);
                    break;
                case '6':
                    g[1].get_vx(50);
                    break;
                case '4':
                    g[1].get_vx(-50);
                    break;
                case '8':
                    g[1].get_v(50);
                    break;
            }
        }
    }
}
