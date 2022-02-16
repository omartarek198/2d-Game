using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp11
{
    class Orb
    {
        public int x, y, w, h;
        public Color c = new Color();
        public int xDir = 0;
        public Orb()
        {
            w = 60;
            h = 60;
        }

        public bool IsClicked(int eX, int eY)
        {
            if (eX >= x && eX <= x + w)
            {
                if (eY >= y && eY <= y + h)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
