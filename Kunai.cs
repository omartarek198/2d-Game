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
    class Kunai
    {
        public int x, y, w, h;
        public int InitialX = 0;
        public Bitmap img = new Bitmap("Kunai.bmp");
        public int xDir;
        public Kunai()
        {
            img.MakeTransparent(img.GetPixel(0, 0));
            img = new Bitmap(img, img.Width / 2, img.Height / 2);
            img.RotateFlip(RotateFlipType.Rotate270FlipX);
            xDir = 1;
            w = img.Width;
            h = img.Height;
        }
        public bool IsTooFar()
        {
            int Distance = 750;
            if (InitialX + Distance <= x && xDir == 1)
            {
                return true;
            }
            if (InitialX - Distance >= x && xDir == 0)
            {
                return true;
            }

            return false;
        }
        public void Move()
        {
            if (xDir == 1)
            {
                x += 50;
            }
            if (xDir == 0)
            {
                x -= 50;
            }
        }

    }
}
