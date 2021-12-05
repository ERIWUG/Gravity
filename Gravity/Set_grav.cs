using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gravity
{

   

    class Set_grav
    {
        double m;
        int id;
        Button c;
        double v_s,h_s,h_m;
        double v,h,h_p;
        public double vx;
        int kf = 6;
        public bool isFall, isRest;
        public bool isTrue;
        int xmax = 969;
        int xmin = 9;
        public Set_grav() { isTrue = false; }
        public Set_grav(int m,int id,Button c)
        {
            isTrue = true;
            this.m = m;
            this.id = id;
            this.c = c;
            isFall = false;
            isRest = true;
            
        }

        public void get_v(double v)
        {
            v_s = v;
            
            this.v = -v;
            h_p = 528;
            h_m = c.Location.Y;
            isFall = false;
            isRest = false;
        }

        double min(double x,int y)
        {
            return x < y ? x : y;
        }

        public void change(int x,int y)
        {
            c.Location = new Point(x,y);
        }
        public void change(int y)
        {
            c.Location = new Point(c.Location.X, y);
        }
        public void check_up()
        {

            change(Convert.ToInt32(c.Location.X + vx/kf), Convert.ToInt32(c.Location.Y + v / kf));
            h = h_m - c.Location.Y;
            if (c.Location.X >= xmax) { if (vx > 0) { vx = -vx; } vx *= 0.7;v *= 0.9; }
            if (c.Location.X <= xmin) { if (vx < 0) { vx = -vx; } vx *= 0.7;v *= 0.9; }
            if (isFall)
            {

                v = Math.Sqrt(2 * 9.81 * ((h_s+h_p) - (h+h_p)));
                if (c.Location.Y + v / kf > h_p)
                {
                    change(Convert.ToInt32(h_p));
                    v = -v;
                   
                    v_s=-v*0.6;
                    v *= 0.6;
                    vx *= 0.7;
                    if (v_s/2+(Math.Max(vx,-vx)/2)< kf) { isRest = true; }
                   
                    else { isRest = false; }
                    h = 0;h_m = h_p;
                    isFall = false; 
                }

                
            }
            else
            {
                if (2 * 9.81 * h > v_s * v_s)
                {
                    change(Convert.ToInt32(h_m-v_s * v_s / (2 * 9.81)));
                    h_s = h_m-c.Location.Y + 2;
                    isFall = true;
                    v = 6;
                    
                }
                else { v=min((-1)* Math.Sqrt(v_s * v_s - 2 * 9.81 * h),-kf); }

            }
        }
        public void get_vx(double x)
        {
            vx = x;
        }
        
    }
}
