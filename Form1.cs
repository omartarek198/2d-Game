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
      
      
      

       
      
    
  

       

    

        public partial class Form1 : Form
        {
            Bitmap off;
            Hero hero = new Hero();
            List<Image> test = new List<Image>();
            Timer t = new Timer();
            bool Pressed = false;
            bool IsIdle = false;
            bool Scroll = false;
            int xScroll = 0;
            int IdleCt = 0;
            Random R = new Random();
            List<Tile> Ltiles = new List<Tile>();
            List<Kunai> Lkunais = new List<Kunai>();
            List<MaleZombie> LMzombies = new List<MaleZombie>();
            List<FemaleZombie> LFzombies = new List<FemaleZombie>();
            List<Bullet> Lbullets = new List<Bullet>();
            MovingTile movingTile = new MovingTile();
            int tCt = 0;
            bool ZombiesDead = false;
            Bitmap bg = new Bitmap("bg1.bmp");
            List<Bitmap> Lcloud = new List<Bitmap>();
            List<Orb> LOrbs = new List<Orb>();
            List<Orb> LBossBullet = new List<Orb>();
            bool DKunai = false;
            bool IsClicked = false;
            Boss boss = new Boss();


            int temp = 0;
            int ctClick = 0;
            int ShootCt = 0;
            bool ThrowWhileShoot = true;
            bool Cloud = false;
            bool winner = false;


            bool jump = false;

            int ctjump = 0;
            bool Throw = false;
            int ctThrow = 0;
            int gameover = 0;
            bool level2 = false;

            public List<Keys> Lkeys = new List<Keys>();
            public Form1()
            {
                boss = null;
                t.Start();
                this.BackColor = Color.NavajoWhite;
                this.WindowState = FormWindowState.Maximized;
                bg = new Bitmap(bg, 2000, 1000);
                // AdjustHeroImages();
                this.Paint += Form1_Paint;
                this.Load += Form1_Load;
                this.KeyDown += Form1_KeyDown;
                this.KeyUp += Form1_KeyUp;
                this.MouseClick += Form1_MouseClick;
                this.MouseMove += Form1_MouseMove;
                t.Tick += T_Tick;
            
                MakeZombies();
                hero.UpdateWandH();
                int t1, t2, j, k,n;
                n = 1;
                Bitmap temp = new Bitmap("cloud1.bmp");
                t1 = temp.Width;
                t2 = temp.Height;
                j = t1 / n;
                k = t2 / n;
                temp = new Bitmap(temp, new Size(j*2, k));
                temp.MakeTransparent(temp.GetPixel(1, 1));
                Lcloud.Add(temp);
                temp = new Bitmap("cloud1.bmp");
                t1 = temp.Width;
                t2 = temp.Height;
                j = t1 / n;
                k = t2 / n;
                temp = new Bitmap(temp, new Size(j*2, k));
                temp.MakeTransparent(temp.GetPixel(1, 1));
                Lcloud.Add(temp);

            }

            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                for (int i = 0; i < LOrbs.Count; i++)
                {
                    if (LOrbs[i].IsClicked(e.X, e.Y))
                    {
                        Cursor.Current = Cursors.Hand;
                        break;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }

            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
              for (int i=0;i<LOrbs.Count;i++)
                {
                    if (LOrbs[i].IsClicked(e.X,e.Y) && !IsClicked )
                    {
                        IsClicked = true;
                        if (i == 0)
                        {
                            hero.Health += 200;
                        }
                        if ( i == 1)
                        {
                            DKunai = true;
                        }
                        if (i==2)
                        {
                            hero.speed += 30;
                        }

                    }    
                }
            }

            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {

                Pressed = false;

            }

            private void T_Tick(object sender, EventArgs e)
            {
                if (gameover == 0)
                {
                    if (hero.IsDead)
                    {
                        if (hero.iFrame < 40)
                        {
                            hero.iFrame = 40;
                        }
                        if (hero.iFrame >= 42)
                        {
                            gameover = 1;
                        }
                        else
                        {
                            hero.iFrame++;
                        }


                    }
                    if (!Pressed && !jump && !Throw && !hero.IsDead)
                    {
                        IdleCt++;
                        hero.UpdateWandH();
                        if (IdleCt > 10)
                        {
                            if (!IsIdle)
                            {
                                IsIdle = true;
                                hero.iFrame = 0;

                            }
                            else
                            {
                                hero.iFrame++;
                                if (hero.iFrame > 7)
                                {
                                    hero.iFrame = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        IdleCt = 0;
                    }

                    if (jump && !IsIdle && !Throw && !hero.IsDead)
                    {
                        if (ctjump == 0)
                        {
                            hero.iFrame = 30;
                        }

                        else
                        {
                            hero.iFrame++;
                        }
                        if (ctjump < 5)
                        {

                            if (hero.xDir == 1)
                            {
                                hero.x += 30;
                                if (Scroll)
                                {
                                    xScroll += 30;
                                }
                           
                            }
                            else
                            {
                                hero.x -= 30;
                                if (xScroll - 30 > 0)
                                {
                                    if (Scroll)
                                    {

                                        xScroll -= 30;
                                    }
                                }

                            }
                            hero.y -= 50;
                        }
                        else
                        {
                            if (hero.xDir == 1)
                            {
                                hero.x += 30;
                                //xScroll += 30;
                            }
                            else
                            {
                                hero.x -= 30;
                                //xScroll -= 30;
                            }
                            hero.y += 10;
                        }



                        if (hero.iFrame > 39)
                        {
                            if (ctjump == 10)
                            {
                                hero.iFrame--;

                            }
                            else
                            {

                                ctjump = -1;
                                jump = false;
                                hero.iFrame = 0;
                                if (hero.xDir == 1) hero.x += 30;
                                else hero.x -= 30;

                            }



                        }
                        ctjump++;
                    }
                    if (jump && IsIdle && !hero.IsDead)
                    {
                        if (ctjump < 5)
                        {
                            hero.y -= 20;
                        }

                        if (ctjump > 9)
                        {
                            ctjump = -1;
                            jump = false;


                        }

                        ctjump++;

                    }
                    if (Throw && !hero.IsDead)
                    {
                        if (!jump)
                        {
                            if (ctThrow == 0)
                            {
                                hero.iFrame = 20;
                            }
                            else
                            {
                                hero.iFrame++;
                            }
                            if (ctThrow == 4)
                            {
                                MakeKunai();
                            }
                            if (ctThrow == 9)
                            {

                                Throw = false;
                                ctThrow = -1;
                                hero.iFrame = 0;
                                ThrowWhileShoot = true;
                            }
                            ctThrow++;
                        }
                        else
                        {
                            if (ThrowWhileShoot)
                            {
                                MakeKunai();
                                ThrowWhileShoot = false;
                                Throw = false;


                            }
                        }

                    }

                    IsKunaiCollid();
                    for (int i = 0; i < Lkunais.Count; i++)
                    {
                        if (!Lkunais[i].IsTooFar())
                        {
                            Lkunais[i].Move();

                        }
                        else
                        {
                            Lkunais.RemoveAt(i);
                        }

                    }
                    for (int i = 0; i < LMzombies.Count; i++)
                    {
                        if (LMzombies[i].IsDead)
                        {

                            if (LMzombies[i].iDead > 1)
                            {

                                LMzombies.RemoveAt(i);

                                break;
                            }
                            LMzombies[i].iDead++;


                        }
                    }

                    for (int i = 0; i < LFzombies.Count; i++)
                    {
                        if (LFzombies[i].IsDead)
                        {

                            if (LFzombies[i].iDead > 1)
                            {

                                LFzombies.RemoveAt(i);

                                break;
                            }
                            LFzombies[i].iDead++;


                        }
                    }
                    for (int i = 0; i < LMzombies.Count(); i++)
                    {
                        if (LMzombies[i].CanMove)
                        {
                            LMzombies[i].DetectHero(hero);
                            if (LMzombies[i].HeroClose)
                            {
                                LMzombies[i].Move(hero);
                            }
                            else
                            {
                                LMzombies[i].Move();
                            }
                        }




                    }
                    for (int i = 0; i < LFzombies.Count(); i++)
                    {
                        if (LFzombies[i].CanMove)
                        {
                            LFzombies[i].DetectHero(hero);
                            if (LFzombies[i].HeroClose)
                            {
                                LFzombies[i].Move(hero);
                            }
                            else
                            {
                                LFzombies[i].Move();
                            }
                        }
                        else
                        {

                        }



                    }
                    if (ShootCt == 40)

                    {
                        for (int i = 0; i < LFzombies.Count; i++)
                        {
                            LFzombies[i].IsAttack = true;
                        }
                        ShootCt = 0;
                    }

                    if (hero.Health < 0)
                    {
                        hero.IsDead = true;
                    }
                    if (hero.Teleport)
                    {
                      if (tCt >1)
                        {
                            hero.Teleport = false;
                        }

                        tCt++;
                    }
                    if (LFzombies.Count + LMzombies.Count == 0 && !ZombiesDead)
                    {
                        MakeOrbs();
                        ZombiesDead = true;
                    }
                    if (IsClicked)
                    {
                  
                            if (ctClick == 10)
                            {
                            //make new level
                        
                            Cloud = true;
                       
                            }
                       if (ctClick == 11)
                        {
                            CreateNewLevel();
                        }
                       if (ctClick == 20)
                        {
                            Cloud = false;
                        }
                        ctClick++;
                    }
                    if (boss != null)
                    {
                        if (boss.x > hero.x)
                        {
                            boss.xDir = 0;
                        }
                        else
                        {
                            boss.xDir = 1;
                        }
                        if (boss.IsShoot && !boss.IsDead)
                        {
                            if (boss.iFrame <3)
                            {
                                boss.iFrame++;
                            }
                            else
                            {
                                boss.iFrame = 0;
                                boss.IsShoot = false;
                            }
                        }
                        if (R.Next(0,100) % 10 == 0)
                        {
                            if (!boss.IsDead)
                            {
                                boss.IsShoot = true;
                                boss.iFrame = 1;

                                MakeBossBullet();
                            }
                      
                        }
                        if (boss.IsDead)
                        {
                            if (boss.iFrame <4)
                            {
                                boss.iFrame = 4;
                            }
                            else
                            {
                                if (boss.iFrame <7)
                                {
                                    boss.iFrame++;
                                }
                                if (boss.iFrame >6)
                                {
                                    boss = null;
                                }
                            }
                        }
                        MoveBossBullet();
                    }

                    if (level2 && boss == null)
                    {
                        winner = true;
                    }
                    ShootCt++;
                    MakeBullets();
                    MoveBullets();
                    IsBulletCollid();
                    Gravity();
                    movingTile.Move();
                    CheckHeroCanMove();

                    DrawDubb(CreateGraphics());
                    if (hero.y > this.Height + 100)
                    {

                        this.Close();
                        t.Stop();
                    }
                    if (winner || gameover == 1)
                    {
                        t.Stop();
                    }


                }
           

            }
            void MakeBossBullet()
            {
                Orb pn = new Orb();
                if (boss.xDir == 0)
                {
                    pn.x = boss.x - 30;
             
                }
                else
                {
                    pn.x = boss.x + 30;
                }
                pn.xDir = boss.xDir;
                pn.w = 35;
                pn.h = 35;
            
                pn.y = boss.y + 50;
                LBossBullet.Add(pn);

            }
            void MoveBossBullet()
            {
                for (int i=0;i<LBossBullet.Count;i++)

                {
                    if (LBossBullet[i].xDir == 0)
                    {
                        LBossBullet[i].x -= 30;
                    }
                    else
                    {
                        LBossBullet[i].x += 30;

                    }
                }
            }
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {

                Pressed = true;
                if (winner || gameover == 1)
                {
                    hero.CanMove = false;
                }
                // up left right  down space slide glide throw
                if (hero.CanMove)
                {
                    if (e.KeyCode == Lkeys[2] && !jump  && !Throw)
                    {

                        IsIdle = false;
                        hero.xDir = 1;
                        if (hero.x < this.ClientSize.Width * 2)
                        {
                            if (hero.iFrame < 19)
                            {
                                if (hero.iFrame < 10)
                                {
                                    hero.iFrame = 10;
                                }
                                hero.iFrame++;
                                hero.UpdateWandH();
                                if (hero.CanMove)
                                {
                                    hero.x += hero.speed;
                                }


                            }
                            else
                            {
                                hero.iFrame = 10;
                            }
                            scroll();
                        }


                    }
                    if (e.KeyCode == Lkeys[1] && !jump && !Throw)
                    {

                        IsIdle = false;
                        hero.xDir = 0;
                        if (hero.x > 10)
                        {
                            if (hero.iFrame < 19)
                            {
                                if (hero.iFrame < 10)
                                {
                                    hero.iFrame = 10;
                                }
                                hero.iFrame++;
                                hero.UpdateWandH();
                                if (hero.CanMove)
                                {
                                    hero.x -= hero.speed;
                                }


                            }
                            else
                            {
                                hero.iFrame = 10;
                            }
                            scroll();
                        }


                    }
                }

                if (e.KeyCode == Lkeys[4] && !Throw)
                {
              
                    jump = true;
                    ThrowWhileShoot = true;

                }
                if (e.KeyCode == Lkeys[7])
                {
                    //MakeKunai();
                    if (jump)
                    {
                        if (ThrowWhileShoot )
                        {
                            Throw = true;
                        }
                    }
                    else
                    {
                        Throw = true;
                    }
                
                }
                if (e.KeyCode == Keys.T)
                {
                    if (Lkunais.Count > 0)
                    {
                        hero.x = Lkunais[Lkunais.Count - 1].x;
                        Lkunais.RemoveAt(Lkunais.Count - 1);
                        Throw = false;
                        ctThrow = -1;

                        hero.iFrame = 0;
                        hero.Teleport = true;
                    }
               
                }
                if (e.KeyCode == Keys.K)
                {
                    for (int i=0;i<LFzombies.Count;i++)
                    {
                        LFzombies.RemoveAt(i);
                    }

                    for (int i = 0; i < LMzombies.Count; i++)
                    {
                        LMzombies.RemoveAt(i);
                    }
                }


            }

            public void SetControls(List<Keys> Lk)
            {
                Lkeys = Lk;
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                off = new Bitmap(ClientSize.Width * 2, ClientSize.Height);
                MakeTiles();
            }

            void MakeKunai()
            {

                hero.UpdateWandH();

                Kunai pnn = new Kunai();
                //1 left

                if (hero.xDir == 1)
                {
                    pnn.x = hero.x + hero.w;
                    pnn.y = hero.y + 50;
                    pnn.xDir = hero.xDir;
                    pnn.InitialX = pnn.x;
                }
                if (hero.xDir == 0)
                {

                    pnn.x = hero.x - hero.w;
                    pnn.y = hero.y + 50;
                    pnn.xDir = hero.xDir;
                    pnn.InitialX = pnn.x;
                }

                Lkunais.Add(pnn);
                if (DKunai)
                {
                    hero.UpdateWandH();

                   pnn = new Kunai();
                    //1 left

                    if (hero.xDir == 1)
                    {
                        pnn.x = hero.x + hero.w;
                        pnn.y = hero.y + 30;
                        pnn.xDir = hero.xDir;
                        pnn.InitialX = pnn.x;
                    }
                    if (hero.xDir == 0)
                    {

                        pnn.x = hero.x - hero.w;
                        pnn.y = hero.y + 30;
                        pnn.xDir = hero.xDir;
                        pnn.InitialX = pnn.x;
                    }
                    Lkunais.Add(pnn);
                }
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                DrawDubb(e.Graphics);
            }
            Bitmap FlipImage(Bitmap i)
            {
                Bitmap temp = i;
                temp.RotateFlip(RotateFlipType.Rotate180FlipY);
                return temp;
            }
            void MakeTiles()
            {
                int x = 0, y = 335;
                for (int j = 0; j < 4; j++)
                {
                    if (j == 1)
                    {
                        y = 835;
                    }
                    for (int i = 0; i < 22; i++)
                    {
                        Tile pnn = new Tile();
                        pnn.x = x;
                        pnn.y = y;
                        Ltiles.Add(pnn);

                        x += pnn.img.Width - 1;
                        if (i == 21 && j == 0)
                        {

                            movingTile.x = x;
                            movingTile.y = y;
                            movingTile.img = new Bitmap(movingTile.img, movingTile.img.Width * 3, movingTile.img.Height);
                            movingTile.w = movingTile.img.Width;
                            Ltiles.Add(movingTile);
                        }

                    }
                    x = 0;
                    y += Ltiles[0].img.Height - 1;
                }



            }
        
            void CheckHeroCanMove()
            {

                int k = 0;
                int j = 0;
                for (int i = 0; i < LMzombies.Count(); i++)
                {
                    k = hero.x - LMzombies[i].x;
                    j = hero.y - LMzombies[i].y;
                    if (k < 0) k *= -1;
                    if (j < 0) k *= -1;

                    //if (k <=30)
                    //{
                    //    LMzombies[i].IsAttack = true;
                    //hero.Health -= 25;


                    //}
                    if (hero.x > LMzombies[i].x - 50 && hero.xDir == 0 && hero.x <= LMzombies[i].x + LMzombies[i].Lwalk[0].Width - 50 && j <40 )
                    {


                        hero.x += 20;
                        LMzombies[i].x -= 20;
                        hero.CanMove = false;
                        LMzombies[i].CanMove = false;
                        LMzombies[i].IsAttack = true;
                        hero.Health -= 5;
                        break;

                    }
                    else
                    {
                        LMzombies[i].CanMove = true;
                        LMzombies[i].IsAttack = false;
                    }

                    if (hero.x > LMzombies[i].x - 50 && hero.xDir == 1 && hero.x <= LMzombies[i].x + LMzombies[i].Lwalk[0].Width - 50 && j <40)
                    {

                        hero.x -= 20;
                        LMzombies[i].x += 20;
                        hero.CanMove = false;
                        LMzombies[i].CanMove = false;
                        LMzombies[i].IsAttack = true;
                        hero.Health -= 5;
                        break;


                    }
                    else
                    {
                        LMzombies[i].CanMove = true;
                        LMzombies[i].IsAttack = false;
                    }
                    if (i + 1 == LMzombies.Count)
                    {
                        hero.CanMove = true;

                    }
                }

                k = 0;
                 for (int i = 0; i < LFzombies.Count() && hero.CanMove; i++)
                {
                    k = hero.x - LFzombies[i].x;
                    j = hero.x - LFzombies[i].y;
                    if (k < 0) k *= -1;
                    if (j < 0) k *= -1;

                    //if (k <=30)
                    //{
                    //    LFzombies[i].IsAttack = true;
                    //hero.Health -= 25;


                    //}
                    if (hero.x > LFzombies[i].x - 50 && hero.xDir == 0 && hero.x <= LFzombies[i].x + LFzombies[i].Lwalk[0].Width - 50  && j <40)
                    {


                        hero.x += 20;
                        LFzombies[i].x -= 20;
                        hero.CanMove = false;
                        LFzombies[i].CanMove = false;
               
                        break;

                    }
                    else
                    {
                        LFzombies[i].CanMove = true;
                        LFzombies[i].IsAttack = false;
                    }

                    if (hero.x > LFzombies[i].x - 50 && hero.xDir == 1 && hero.x <= LFzombies[i].x + LFzombies[i].Lwalk[0].Width - 50 && j<40)
                    {
                        hero.x -= 20;
                        LFzombies[i].x += 20;
                        hero.CanMove = false;
                        LFzombies[i].CanMove = false;
                        break;
                    }
                    else
                    {
                        LFzombies[i].CanMove = true;
          
                    }
                    if (i + 1 == LFzombies.Count)
                    {
                        hero.CanMove = true;

                    }
                }
          
            }
            void MakeZombies()
            {
                int N1 = 3  ;
                int N2 = R.Next(1, 10);
                int t = 0;
                int q = 500;
                for (int i = 0; i < N1; i++)
                {
                    if (R.Next(0, 10) % 2 == 0)
                    {
                        MaleZombie pn = new MaleZombie();
                        pn.x = 700 + (i * q);
                        pn.y = 835 - pn.Lwalk[0].Height;
                        pn.OgX = pn.x;
                        pn.xDir = 1;
                        LMzombies.Add(pn);
                        //Make Male
                    }
                    else
                    {
                        FemaleZombie pn = new FemaleZombie();
                        pn.x = 700 + (i * q);
                        pn.y = 835 - pn.Lwalk[0].Height;
                        pn.OgX = pn.x;
                        pn.xDir = 1;
                        LFzombies.Add(pn);
                        //Make Male
                    }
                }
           
                for (int i=0;i<3;i++)
                {
                    if (R.Next(0, 10) % 2 == 0)
                    {
                        MaleZombie pn = new MaleZombie();
                        //pn.x = R.Next(500, 2500
                        //    );
                        pn.x = q + (i * q);
                        pn.y = 135 - pn.Lwalk[0].Height;
                        pn.OgX = pn.x;
                        pn.xDir = 1;
                        LMzombies.Add(pn);
                        //Make Male
                    }
                    else
                    {
                        FemaleZombie pn = new FemaleZombie();
                        //pn.x = R.Next(500, 2500);
                        pn.x = q + (i * q);
                        pn.y = 135 - pn.Lwalk[0].Height;
                        pn.OgX = pn.x;
                        pn.xDir = 1;
                        LFzombies.Add(pn);
                        //Make Male
                    }
                }

          
            }

            void Gravity()
            {
                hero.UpdateWandH();
                bool Hovering = true;
                for (int i = 0; i < Ltiles.Count()-1; i++)
                {
                    if (hero.x >= Ltiles[i].x - 25 && hero.x <= Ltiles[i].x + Ltiles[i].w)
                    {

                        if (hero.y <= Ltiles[i].y && hero.y + hero.h >= Ltiles[i].y)
                        {
                            hero.UpdateWandH();
                            hero.y = Ltiles[i].y - hero.h + 10;
                            Hovering = false;
                    
                       
                                movingTile.hero = null;

                            break;
                        }
                    }
                    if (hero.x >= movingTile.x && hero.x < movingTile.x + movingTile.img.Width)
                    {
                        if (hero.y < movingTile.y && hero.y + hero.h >= movingTile.y )
                        {
                            Hovering = false;
                            movingTile.AttachHero(hero);
                            hero.y = movingTile.y - hero.h + 10;

                        }
                    }

                }
                for (int i = 0; i < Ltiles.Count() - 1; i++)
                {
                    if (boss != null)
                    {
                        if (boss.x >= Ltiles[i].x - 25 && boss.x <= Ltiles[i].x + Ltiles[i].w)
                        {
                            boss.UpdateWandH();
                            if (boss.y <= Ltiles[i].y && boss.y + boss.h >= Ltiles[i].y)
                            {
                            
                                boss.y = Ltiles[i].y - boss.h + 10;
                           


                        

                                break;
                            }
                        }
              
                    }
             

                }

                for (int i = 0; i < LMzombies.Count(); i++)
                {
                    int flag = 0;
                    for (int a = 0; a < Ltiles.Count ;a++)
                    {

                        if (LMzombies[i].x >= Ltiles[a].x && LMzombies[i].x <= Ltiles[a].x + Ltiles[a].w && LMzombies[i].y < 835 )
                        {
                            flag = 1;
                      
                            if (LMzombies[i].y < 335)
                            {
                                LMzombies[i].y = 335 - LMzombies[i].Lwalk[0].Height;
                            }
                            if (LMzombies[i].y < 835 && LMzombies[i].y > 335)
                            {
                                LMzombies[i].y = 835 - LMzombies[i].Lwalk[0].Height;
                            }
                            if (Ltiles[a].TileType == 1)
                            {
                                if (LMzombies[i].y > Ltiles[a].y)
                                {
                                    LMzombies[i].y += 20;
                                    flag = 0;
                                }
                            }

                        }
                        if (a + 1 == Ltiles.Count() - 1 && flag == 0)
                        {
                            LMzombies[i].y += 20;
                        }
                    }

                }
                for (int i=0;i<LFzombies.Count;i++)
                {
                    int flag = 0;
                    for (int a = 0; a < Ltiles.Count ; a++)
                    {

                        if (LFzombies[i].x >= Ltiles[a].x && LFzombies[i].x <= Ltiles[a].x + Ltiles[a].w && LFzombies[i].y < 835)
                        {
                            flag = 1;
                            if (LFzombies[i].y < 335)
                            {
                                LFzombies[i].y = 335 - LFzombies[i].Lwalk[0].Height;
                            }
                            if (LFzombies[i].y < 835 && LFzombies[i].y >335)
                            {
                                LFzombies[i].y = 835 - LFzombies[i].Lwalk[0].Height;
                            }
                        }
                        if (a + 1 == Ltiles.Count() - 1 && flag == 0)
                        {
                            LFzombies[i].y += 20;
                        }
                    }
                }

                if (Hovering)
                {
                    if (!jump)
                    {
                        hero.y += 20;
                    }
                    hero.y += 10;
                }

            }
            void scroll()
            {

                //if (Scroll &&hero.x > xScroll+this.Width/2 && hero.x < this.Width*2 -this.Width / 2 )
                //{

                //        Scroll = true;
                //        xScroll += 40;


                //}
                //if (Scroll && hero.x < xScroll + this.Width / 2)
                //{
                //    xScroll -= 40;
                //}
                //if (Scroll && hero.x - this.Width/2 <=0)
                //{
                //    xScroll = 0;
                //}
                if (hero.x > xScroll + this.Width / 2)
                {
                    Scroll = true;
                }
                else if (hero.xDir ==0 )
                {
                    if (hero.x- xScroll <this.Width-xScroll)
                    {
                        Scroll = true;
                    }
                }
                if (Scroll)
                {
                    if (hero.xDir == 1)
                    {
                        if (hero.x + xScroll <= 3 * this.Width / 2)
                        {
                            xScroll += 40;
                        }
                        else
                        {
                            Scroll = false;
                        }

                    }
                        if (hero.xDir == 0)
                        {

                            if (xScroll <= 0)
                            {
                                xScroll = 0;
                                Scroll = false;
                            }
                            else
                            {
                                xScroll -= 40;
                            }
                        }

                }
            }
            public void MakeBullets()
            {
                for (int i=0;i<LFzombies.Count;i++)
                {
                    if (LFzombies[i].IsAttack)
                    {
                        Bullet pnn = new Bullet();
                        if (LFzombies[i].xDir == 0)
                        {
                            pnn.x = LFzombies[i].x - 10;
                            pnn.xDir = 0;
                     
                        }
                        else
                        {
                            pnn.x = LFzombies[i].x + 10;
                            pnn.xDir = 1;
                        }
                        pnn.y = LFzombies[i].y + 70;
                        pnn.w = pnn.img.Width;
                        pnn.h = pnn.img.Height;
                        Lbullets.Add(pnn);
                        LFzombies[i].IsAttack = false;

                    }
                }
            }
            void IsBulletCollid()
            {
                for (int i = 0; i < Lbullets.Count; i++)
                {
                    if (Lbullets[i].xDir == 0)
                    {
                        if (hero.x> Lbullets[i].x && hero.x< Lbullets[i].x + Lbullets[i].img.Width)
                        {
                            if( hero.y < Lbullets[i].y && hero.y + hero.Limg[0].Height > Lbullets[i].y)
                            {
                                Lbullets.RemoveAt(i);
                                hero.Health -= 5;
                            }
                        }
                    }
                    else
                    {
                        if (hero.x > Lbullets[i].x && hero.x < Lbullets[i].x + Lbullets[i].img.Width)
                        {
                            if (hero.y < Lbullets[i].y && hero.y + hero.Limg[0].Height > Lbullets[i].y)
                            {
                                Lbullets.RemoveAt(i);
                                hero.Health -= 5;
                            }
                        }
                    }
                }
            
                for (int i = 0; i < LBossBullet.Count; i++)
                {
                    if (LBossBullet[i].xDir == 0)
                    {
                        if (hero.x-20<= LBossBullet[i].x && hero.x + hero.w-20 >= LBossBullet[i].x)
                        {
                            if (hero.y < LBossBullet[i].y && hero.y + hero.Limg[0].Height > LBossBullet[i].y)
                            {
                                LBossBullet.RemoveAt(i);
                                hero.Health -= 5;
                            }
                        }
                    }
                    else
                    {
                        hero.UpdateWandH();
                        if (hero.x <= LBossBullet[i].x && hero.x + hero.w>= LBossBullet[i].x)
                        {
                            if (hero.y < LBossBullet[i].y && hero.y + hero.Limg[0].Height > LBossBullet[i].y)
                            {
                                LBossBullet.RemoveAt(i);
                                hero.Health -= 5;
                            }
                        }
                    }
                }
            }   
            public void IsKunaiCollid()
            {
                for (int i = 0; i < Lkunais.Count(); i++)
                {
                    for (int a = 0; a < LMzombies.Count(); a++)
                    {
                        if (Lkunais[i].xDir == 1)

                        {

                            if (Lkunais[i].x >= LMzombies[a].x && Lkunais[i].x <= LMzombies[a].Lwalk[0].Width + LMzombies[a].x && Lkunais[i].y >= LMzombies[a].y && Lkunais[i].y <= LMzombies[a].Lwalk[LMzombies[i].iWalk].Height + LMzombies[a].y)
                            {

                                Lkunais.RemoveAt(i);

                                LMzombies[a].TakeDamage();
                                if (LMzombies[a].Health <= 0)
                                {
                                    LMzombies[a].Die();

                                }
                                break;
                            }


                        }
                        try
                        {
                            if (Lkunais[i].xDir == 0)
                            {

                                if (Lkunais[i].x + 10 >= LMzombies[a].x && Lkunais[i].x <= LMzombies[a].Lwalk[0].Width + LMzombies[a].x

                                    && Lkunais[i].y >= LMzombies[a].y && Lkunais[i].y <= LMzombies[a].Lwalk[0].Height + LMzombies[a].y
                                    )
                                {

                                    Lkunais.RemoveAt(i);

                                    LMzombies[a].TakeDamage();
                                    if (LMzombies[a].Health <= 0)
                                    {
                                        LMzombies[a].Die();

                                    }
                                    break;
                                }
                            }

                        }

                        catch
                        {
                            MessageBox.Show("i " + i + " a" + a + " iwalk " + LMzombies[i].iWalk);
                            // (Lkunais[i].x >= LMzombies[a].x && Lkunais[i].x <=
                            // LMzombies[a].Lwalk[LMzombies[i].iWalk].Width + LMzombies[a].x
                            // && Lkunais[i].y >= LMzombies[a].y && Lkunais[i].y <=
                            // LMzombies[a].Lwalk[LMzombies[i].iWalk].Height + LMzombies[a].y)

                        }
                    }
                }

                for (int i = 0; i < Lkunais.Count; i++)
                {
                    for (int a = 0; a < LFzombies.Count(); a++)
                    {
                        if (Lkunais[i].xDir == 1)

                        {



                            if (Lkunais[i].x >= LFzombies[a].x && Lkunais[i].x <= LFzombies[a].Lwalk[0].Width + LFzombies[a].x
                                 && Lkunais[i].y >= LFzombies[a].y && Lkunais[i].y <= LFzombies[a].Lwalk[0].Height + LFzombies[a].y
                                )
                            {

                                Lkunais.RemoveAt(i);

                                LFzombies[a].TakeDamage();
                                if (LFzombies[a].Health <= 0)
                                {
                                    LFzombies[a].Die();

                                }
                                break;
                            }


                        }
                        if (Lkunais[i].xDir == 0)
                        {
                            try
                            {
                                if (Lkunais[i].x >= LFzombies[a].x && Lkunais[i].x <=
                                    LFzombies[a].Lwalk[0].Width + LFzombies[a].x
                                    && Lkunais[i].y
                                    >= LFzombies[a].y &&
                                    Lkunais[i].y <=
                                    LFzombies[a].Lwalk[0].Height + LFzombies[a].y)
                                {

                                    Lkunais.RemoveAt(i);

                                    LFzombies[a].TakeDamage();
                                    if (LFzombies[a].Health <= 0)
                                    {
                                        LFzombies[a].Die();

                                    }
                                    break;
                                }
                            }

                            catch
                            {
                                int z = 0;
                            }
                        }

                    }



                }
                for (int i = 0; i < Lkunais.Count && boss != null; i++ )
                {
              
                    {
                        if (Lkunais[i].xDir == 1)

                        {



                            if (Lkunais[i].x >= boss.x && Lkunais[i].x <= boss.Limg[0].Width + boss.x
                                 && Lkunais[i].y >= boss.y && Lkunais[i].y <= boss.Limg[0].Height + boss.y
                                )
                            {

                                Lkunais.RemoveAt(i);

                                boss.Health -= 50;
                                if (boss.Health <= 0)
                                {
                                    boss.IsDead = true;

                                }
                                break;
                            }


                        }
                        if (Lkunais[i].xDir == 0 && boss != null)
                        {
                            try
                            {
                                if (Lkunais[i].x >= boss.x && Lkunais[i].x <=
                                    boss.Limg[0].Width + boss.x
                                    && Lkunais[i].y
                                    >= boss.y &&
                                    Lkunais[i].y <=
                                    boss.Limg[0].Height + boss.y)
                                {

                                    Lkunais.RemoveAt(i);

                                    boss.Health -= 50;
                                    if (boss.Health <= 0)
                                    {
                                        boss.IsDead = false;

                                    }
                                    break;
                                }
                            }

                            catch
                            {
                                int z = 0;
                            }
                        }
                    }
                }
                for (int i = 0; i < Lkunais.Count() && boss!=null; i++)
                {
                    for (int a = 0; a < Lbullets.Count ; a++)
                    {
                        if (Lkunais[i].xDir == 1)
                        {
                            if (Lkunais[i].x > Lbullets[a].x && Lkunais[i].x < Lbullets[a].x + Lbullets[a].img.Width)
                            {
                                if (Lkunais[i].y > Lbullets[a].y && Lkunais[i].y < Lbullets[a].y + Lbullets[a].img.Height)
                                {

                                    Lbullets.RemoveAt(a);
                                    boss.Health -= 50;
                                    if (boss.Health <= 0)
                                    {
                                        boss.IsDead = false;

                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (Lbullets[a].x > Lkunais[i].x && Lbullets[a].x < Lkunais[i].x + Lkunais[i].img.Width)
                            {
                                if (Lbullets[a].y > Lkunais[i].y && Lbullets[a].y < Lkunais[i].y + Lkunais[i].img.Width)
                                {
                                    Lbullets.RemoveAt(a);
                                }
                            }
                        }
                    }
                }

        
        }
            public void CreateNewLevel()
            {
                level2 = true;
         

                    Ltiles.RemoveRange(0, Ltiles.Count);
                LOrbs.RemoveRange(0, LOrbs.Count);


          
                hero.x = 30;
                hero.y = 835 - 100;
                int x = 0, y = 835;
                for (int k=0;k<5;k++)
                {
                    for (int i = 0; i < 22; i++)
                    {

                        Tile pnn = new Tile();
                        pnn.x = x;
                        pnn.y = y;
                        Ltiles.Add(pnn);

                        x += pnn.img.Width - 1;


                    }
                    y += Ltiles[0].img.Height - 1;
                          x = 0;
                }
                boss = new Boss();
                boss.x = hero.x + 1000;
                boss.y = hero.y;
            }
            public void MakeOrbs()
            {
                // make orbs hero.x + 200 same x and + 100 y each 

                int t = hero.y-50;
                for (int i=0;i<3;i++)
                {
                    Orb pn = new Orb();
                    if (hero.xDir == 0)
                    {
                        pn.x = hero.x - 200;
                    }
                    else
                    {
                        pn.x = hero.x + 200;
                    }
                    pn.y = t;
                    t += 100;
                    LOrbs.Add(pn);
                }

                LOrbs[0].c = Color.Red;
                LOrbs[1].c = Color.Blue;
                LOrbs[2].c = Color.Green;

      
          
            }
            public void MoveBullets()
            {
                for (int i=0;i<Lbullets.Count;i++)
                {
                    if (Lbullets[i].xDir == 0)
                    {
                        Lbullets[i].x -= 30;
                        Lbullets[i].ct++;
                    }
                    else
                    {
                        Lbullets[i].x += 30;
                        Lbullets[i].ct++;
                    }
                    if (Lbullets[i].ct > 15)
                    {
                        Lbullets.RemoveAt(i);
                    }
                }
            }
            public void DrawScene(Graphics g)
            {

                g.Clear(Color.Black);
                Font s = new Font(SystemFonts.DefaultFont.FontFamily, 24, FontStyle.Regular);
                Font s2 = new Font(SystemFonts.DefaultFont.FontFamily, 20, FontStyle.Regular);
                Font s3 = new Font(SystemFonts.DefaultFont.FontFamily, 14, FontStyle.Regular);
                if (level2 == false)
                {
      g.DrawImage(bg, xScroll, 0);
                }
          

                if (hero.xDir == 1)
                {
                    g.DrawImage(hero.Limg[hero.iFrame], hero.x, hero.y);
                }
                else
                {
                    g.DrawImage(FlipImage(hero.Limg[hero.iFrame]), hero.x, hero.y);
                    FlipImage(hero.Limg[hero.iFrame]);
                }

                for (int i = 0; i < Ltiles.Count(); i++)
                {
                    g.DrawImage(Ltiles[i].img, Ltiles[i].x, Ltiles[i].y);
                }
                g.DrawImage(movingTile.img, movingTile.x, movingTile.y);

                for (int i = 0; i < Lkunais.Count; i++)
                {
                    if (Lkunais[i].xDir == 1)
                    {
                        g.DrawImage(Lkunais[i].img, Lkunais[i].x, Lkunais[i].y);
                    }
                    else
                    {
                        Lkunais[i].img.RotateFlip(RotateFlipType.Rotate180FlipY);

                        g.DrawImage(Lkunais[i].img, Lkunais[i].x, Lkunais[i].y

                            );
                        Lkunais[i].img.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }

                }
                Font f = new Font(Font, FontStyle.Bold);






                if (gameover == 0)
                {
                    g.DrawString("Death Shadow", Font, Brushes.DarkRed, hero.x - 10, hero.y - 50);
                }
            
           
                g.FillRectangle(Brushes.Red, hero.x - 5, hero.y - 20, hero.Health, 20);

                for (int i = 0; i < LMzombies.Count(); i++)
                {
                    if (!LMzombies[i].IsDead && !LMzombies[i].IsAttack)
                    {
                        if (LMzombies[i].xDir == 1)
                        {

                            g.DrawImage(LMzombies[i].Lwalk[LMzombies[i].iWalk], LMzombies[i].x, LMzombies[i].y);
                        }
                        else
                        {

                            g.DrawImage(FlipImage(LMzombies[i].Lwalk[LMzombies[i].iWalk]), LMzombies[i].x, LMzombies[i].y);
                            FlipImage(LMzombies[i].Lwalk[LMzombies[i].iWalk]);
                        }

                    }
                    if (LMzombies[i].IsDead)
                    {

                        g.DrawImage(LMzombies[i].Ldead[LMzombies[i].iDead], LMzombies[i].x, LMzombies[i].y);
                    }
                    if (LMzombies[i].IsAttack)
                    {
                        if (LMzombies[i].xDir == 1)
                        {
                            g.DrawImage(LMzombies[i].Lattack[0], LMzombies[i].x, LMzombies[i].y);
                        }
                        else
                        {
                            g.DrawImage(FlipImage(LMzombies[i].Lattack[0]), LMzombies[i].x, LMzombies[i].y);
                            FlipImage(LMzombies[i].Lattack[0]);
                        }

                    }

                }

                for (int i=0;i<LFzombies.Count();i++)
                {
                    if (!LFzombies[i].IsDead && !LFzombies[i].IsAttack)
                    {
                        if (LFzombies[i].xDir == 1)
                        {

                            g.DrawImage(LFzombies[i].Lwalk[LFzombies[i].iWalk], LFzombies[i].x, LFzombies[i].y);
                        }
                        else
                        {

                            g.DrawImage(FlipImage(LFzombies[i].Lwalk[LFzombies[i].iWalk]), LFzombies[i].x, LFzombies[i].y);
                            FlipImage(LFzombies[i].Lwalk[LFzombies[i].iWalk]);
                        }
                    }
                    if (LFzombies[i].IsDead)
                    {

                        g.DrawImage(LFzombies[i].Ldead[LFzombies[i].iDead], LFzombies[i].x, LFzombies[i].y);
                    }
                    if (LFzombies[i].IsAttack)
                    {
                        if (LFzombies[i].xDir == 1)
                        {
                            g.DrawImage(LFzombies[i].Lattack[0], LFzombies[i].x, LFzombies[i].y);
                        }
                        else
                        {
                            g.DrawImage(FlipImage(LFzombies[i].Lattack[0]), LFzombies[i].x, LFzombies[i].y);
                            FlipImage(LFzombies[i].Lattack[0]);
                        }

                    }

                }
     

                for (int i=0;i<Lbullets.Count;i++)
                {
                    g.DrawImage(Lbullets[i].img, Lbullets[i].x, Lbullets[i].y);
                }
                if (gameover == 1)
                {
                
                
                    g.DrawString("GAME OVER", s, Brushes.Red, hero.x, hero.y - 100);
                }

                for (int i=0;i<LOrbs.Count && ZombiesDead && !level2;i++)
                {
                    if ( i == 0)
                    {
                   
                        g.DrawString("Select ONE orb", s2, Brushes.White, LOrbs[0].x - 100, LOrbs[0].y - 100);
                        g.DrawString("plus 200 health", s3, Brushes.Red, LOrbs[0].x - 40, LOrbs[0].y - 40);
                        g.FillEllipse(Brushes.Red, LOrbs[i].x, LOrbs[i].y, LOrbs[i].w, LOrbs[i].h);
                    }
                    if (i==1)
                    {
                        g.DrawString("double kunai", s3, Brushes.Blue, LOrbs[1].x - 40, LOrbs[1].y - 40);
                        g.FillEllipse(Brushes.Blue, LOrbs[i].x, LOrbs[i].y, LOrbs[i].w, LOrbs[i].h);
                    }
                    if ( i==2)
                    {
                        g.DrawString("Boost Speed", s3, Brushes.Green, LOrbs[2].x - 40, LOrbs[2].y - 40);
                        g.FillEllipse(Brushes.Green, LOrbs[i].x, LOrbs[i].y, LOrbs[i].w, LOrbs[i].h);
                    }
                }

                if (boss != null)
                {
                    if (boss.xDir == 1)
                    {
                        g.DrawImage(boss.Limg[boss.iFrame], boss.x, boss.y);
                    }
                    else{ 
                        g.DrawImage(FlipImage(boss.Limg[boss.iFrame]), boss.x, boss.y);
                        FlipImage(boss.Limg[boss.iFrame]);

                    }
                    for (int i=0;i<LBossBullet.Count;i++)
                    {
                        g.FillEllipse(Brushes.LightGray, LBossBullet[i].x, LBossBullet[i].y, LBossBullet[i].w, LBossBullet[i].h);
                    }
                    g.FillRectangle(Brushes.Yellow, boss.x - (boss.Health/2 -boss.w/2), boss.y - 40, boss.Health, 20);

                }
                if (winner)
                {
                    g.DrawString("WINNER", s, Brushes.Red, hero.x + 300, hero.y - 300);
                }
                if (Cloud)
                {
                    g.DrawImage(Lcloud[0], xScroll, 0);
                }
           
                


            }

            void DrawDubb(Graphics g)
            {
                Graphics g2 = Graphics.FromImage(off);
                DrawScene(g2);
                Rectangle r1 = new Rectangle();
                Rectangle r2 = new Rectangle();
                r1.X = xScroll;
                r1.Y = 0;
                r1.Width = this.ClientSize.Width;
                r1.Height = this.Height;

                r2.X = 0;
                r2.Y = 0;
                r2.Width = this.ClientSize.Width;
                r2.Height = this.Height;
                g.DrawImage(off, r2, r1, GraphicsUnit.Pixel);



            }

     
        }

    }
