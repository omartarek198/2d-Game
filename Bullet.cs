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
    class Bullet
    {
        public int x, y, xDir, w, h;
        public Bitmap img = new Bitmap("FemaleBullet.bmp");
        public int ct = 0;
        public Bullet()
        {
            img.MakeTransparent(img.GetPixel(0, 0));
            img = new Bitmap(img, img.Width / 8, img.Height / 8);
        }

    }
}
