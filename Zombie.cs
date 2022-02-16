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
    class Zombie
    {
        public int x, y, w, h;
        public List<Bitmap> Lwalk = new List<Bitmap>();
        public List<Bitmap> Ldead = new List<Bitmap>();
        public List<Bitmap> Lattack = new List<Bitmap>();
        public int xDir;
        public int Health;
        public int Damage;
        public int iFrame = 0;
        public int iWalk, iDead, iAttack;
        public bool IsDead = false;
        public bool HeroClose = false;
        public bool IsAttack = false;
        public bool CanMove = true;

        public int OgX;
        public void Move()
        {
            if (!HeroClose)
            {
                if (xDir == 1)
                {
                    x += 10;
                }
                else
                {
                    x -= 10;
                }
                if (x > OgX + 200 && xDir == 1)
                {
                    xDir = 0;


                }
                if (x < OgX - 200 && xDir == 0)

                {
                    xDir = 1;


                }


            }

            if (iWalk < Lwalk.Count() - 1)
            {
                iWalk++;
            }
            else
            {
                iWalk = 0;
            }
        }
        public void Move(Hero obj)
        {

            obj.CanMove = true;
            if (x < obj.x)
            {
                xDir = 1;
            }
            if (x > obj.x)
            {
                xDir = 0;
            }

            if (xDir == 1)
            {
                x += 10;
            }
            else
            {
                x -= 10;
            }
            if (iWalk < Lwalk.Count() - 1)
            {
                iWalk++;
            }
            else
            {
                iWalk = 0;
            }



        }
        public void TakeDamage()
        {
            Health -= 50;

        }
        public void DetectHero(Hero obj)
        {
            int j = x - obj.x;
            int k = y - obj.y;

            if (j < 0) j *= -1;
            if (k < 0) k *= -1;
            if (j <= 300 && k <= 300)
            {
                HeroClose = true;
            }
            else
            {
                HeroClose = false;
            }
        }

    }
}
