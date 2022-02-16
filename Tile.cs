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
    class Tile
    {
        public int x, y, w, h;
        public Bitmap img = new Bitmap("Tile1.bmp");
        public int TileType;
        public Tile()
        {
            img = new Bitmap(img, img.Width / 2, img.Height);
            img.MakeTransparent(img.GetPixel(0, 0));
            w = img.Width;
            h = img.Height;
            TileType = 0;
        }
        public void AttachHero(Hero obk)
        {
            MessageBox.Show("lol");
        }

    }
}
