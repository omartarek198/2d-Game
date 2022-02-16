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
    class Boss
    {
        public int x, y, h, w;
        public List<Bitmap> Limg = new List<Bitmap>();
        public int iFrame = 0;
        public int xDir = 1;
        public bool CanMove = true;
        public int Health = 600;
        public bool IsDead = false;
        public bool IsShoot = false;
        public void UpdateWandH()
        {
            w = Limg[iFrame].Width;
            h = Limg[iFrame].Height;


        }
        public Boss()
        {
            int t1, t2;
            int j = 80, k = 140;
            int n = 3;
            //363*453
            Bitmap temp;

            temp = new Bitmap("CowboyIdle1.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp.MakeTransparent(temp.GetPixel(0, 0));
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("CowboyShoot1.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);
            temp = new Bitmap("CowboyShoot2.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);
            temp = new Bitmap("CowboyShoot3.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);
            temp = new Bitmap("CowboyDead4.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);
            temp = new Bitmap("CowboyDead7.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);
            temp = new Bitmap("CowboyDead10.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);


        }
    }
}
