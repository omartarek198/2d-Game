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
    class FemaleZombie : Zombie
    {
        public FemaleZombie()
        {
            Health = 100;
            Damage = 25;
            iWalk = 0;
            iDead = 0;
            iAttack = 0;
            int t1, t2;
            int j = 80, k = 140;
            int n = 3;
            //363*453
            Bitmap temp;
            temp = new Bitmap("FemaleWalk1.bmp");

            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("FemaleWalk3.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("FemaleWalk7.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("FemaleWalk9.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("FemaleDead2.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Ldead.Add(temp);

            temp = new Bitmap("FemaleDead7.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Ldead.Add(temp);

            temp = new Bitmap("FemaleDead12.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Ldead.Add(temp);

            temp = new Bitmap("FemaleAttack.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lattack.Add(temp);
        }
        public void Die()
        {
            IsDead = true;
        }
    }
}
