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
    class MaleZombie : Zombie
    {
        public MaleZombie()
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
            temp = new Bitmap("MaleWalk1.bmp");

            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("MaleWalk3.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("MaleWalk7.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("MaleWalk9.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Lwalk.Add(temp);

            temp = new Bitmap("MaleDead2.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Ldead.Add(temp);

            temp = new Bitmap("MaleDead7.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Ldead.Add(temp);

            temp = new Bitmap("MaleDead12.bmp");
            t1 = temp.Width;
            t2 = temp.Height;
            j = t1 / n;
            k = t2 / n;
            temp = new Bitmap(temp, new Size(j, k));
            temp.MakeTransparent(temp.GetPixel(0, 0));
            Ldead.Add(temp);

            temp = new Bitmap("MaleAttack3.bmp");
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
