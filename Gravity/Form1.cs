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

        Set_grav g = new Set_grav();

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            g = new Set_grav(1, 0, button1);
            g.get_v(Convert.ToDouble(numericUpDown1.Value));
            g.get_vx(Convert.ToDouble(numericUpDown2.Value));
            g.check_up();
            textBox2.Text = Convert.ToString(button1.Location.X);
        }
        bool c = true;
        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (c) { c = false;button1_MouseClick(button1, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1)); }
            if (g.isTrue)
            {
                if (g.isRest) {  }
                else { g.check_up(); }
            }
        }
    }
}
