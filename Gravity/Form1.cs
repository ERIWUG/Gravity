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
            

        }

        Set_grav[] g =
        {
            new Set_grav(),
            new Set_grav()
        };
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            g[0] = new Set_grav(1, 0, button1);
            g[0].get_v(Convert.ToDouble(numericUpDown1.Value));
            g[0].get_vx(Convert.ToDouble(numericUpDown2.Value));

            g[1] = new Set_grav(1, 0, button2);
            g[1].get_v(Convert.ToDouble(numericUpDown1.Value));
            g[1].get_vx(Convert.ToDouble(numericUpDown2.Value));
        }
        bool c = true;
        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (c) { c = false;button1_MouseClick(button1, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1)); }
            for (int i = 0; i < 2; i++)
            {
                if (g[i].isTrue)
                {
                    if (g[i].isRest) { }
                    else { g[i].check_up(); }
                }
            }
        }
    }
}
