using System;
using System.Collections.Generic;
using System.Text;
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
    class Hero
    {


        public int x, y, h, w;
        public List<Bitmap> Limg = new List<Bitmap>();
        public int iFrame;
        public int xDir = 1;
        public bool CanMove = true;
        public int Health = 200;
        public bool IsDead = false;
        public int x2, y2;
        public bool Teleport = false;
        public int speed = 50;
        public Hero()
        {
            int t1, t2;
            int j = 80, k = 140;
            int n = 3;
            //363*453
            Bitmap temp;

            temp = new Bitmap("Idle__000.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__001.bmp");

            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__002.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__003.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__004.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__005.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__006.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__007.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__008.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Idle__009.bmp");
            temp = new Bitmap(temp, new Size(j, k));

            Limg.Add(temp);

            temp = new Bitmap("Run__000.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__001.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__002.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__003.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__004.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__005.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__006.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__007.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run__008.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Run-009.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            //throw

            temp = new Bitmap("Throw__000.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__001.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__002.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__003.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__004.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__005.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__006.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__007.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__008.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Throw__009.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);

            //jump
            temp = new Bitmap("Jump__000.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__001.bmp");

            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__002.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__003.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__004.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__005.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__006.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__007.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__008.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Jump__009.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            Limg.Add(temp);
            temp = new Bitmap("Dead__001.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);
            temp = new Bitmap("Dead__003.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);

            temp = new Bitmap("Dead__006.bmp");
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Limg.Add(temp);
            x = 300;
            y = 600;
            iFrame = 0;
        }

        public void UpdateWandH()
        {
            w = Limg[iFrame].Width;
            h = Limg[iFrame].Height;

        }
    }
}
