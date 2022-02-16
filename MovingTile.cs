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
    class MovingTile : Tile
    {
        public Hero hero = null;
        public int xdir = -1;
        public MovingTile()
        {
            TileType = 1;
        }
        public void Move()
        {


            if (y >= 835 && xdir == 1)
            {
                xdir = -1;
            }
            if (y <= 335 && xdir == -1)
            {
                xdir = 1;
            }

            y += (10 * xdir);
            if (hero != null)
            {
                hero.y += (10 * xdir);
            }
        }
        public void AttachHero(Hero obj)
        {
            hero = obj;
        }

    }
}
