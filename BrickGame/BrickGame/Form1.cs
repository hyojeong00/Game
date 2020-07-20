using System.Windows.Forms;
using System.Drawing;
using System;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int WTileSize = 16;
        const int HTileSize = 9;
        const string Title = "푸시푸시 - 안드로이드의 모험";

        int Stage;
        bool EndGame = true;


        int KeyCount;

        char[][] MapReal;
        string[,] Map = { {       "################",
                                    "#              #",
                                    "##   ###  #    #",
                                    "#     ##    #  #",
                                    "#     ## @     #",
                                    "#     ##  B .  #",
                                    "#     ##  B .  #",
                                    "#              #",
                                    "################"
                               },
                               {    "################",
                                    "#              #",
                                    "##   ###  #    #",
                                    "#     ##    #  #",
                                    "#              #",
                                    "#        @B .  #",
                                    "#         B .  #",
                                    "#              #",
                                    "################"
                               },
                               {    "################",
                                    "#              #",
                                    "##   ###  #    #",
                                    "#     ##    #  #",
                                    "#        #     #",
                                    "#        @B .  #",
                                    "#         B .  #",
                                    "#              #",
                                    "################"
                               }
        };

        Image Human;
        Image HumanF;
        Image HumanL;
        Image HumanR;
        Image HumanB;

        Image Wall;
        Image Road;
        Image Box;
        Image Dot;

        int WTile;
        int HTile;

        int XHuman;
        int YHuman;
        int XHumanOld;
        int YHumanOld;
        public Form1()
        {
            InitializeComponent();
            Text = Title;
            Stage = 0;
         

            HumanF = new Bitmap(BrickGame.Properties.Resources.HumanF);
            WTile = HumanF.Width;
            HTile = HumanF.Height;
            ClientSize = new Size(WTileSize * WTile, HTileSize * HTile);
            HumanL = new Bitmap(BrickGame.Properties.Resources.HumanL);
            HumanR = new Bitmap(BrickGame.Properties.Resources.HumanR);
            HumanB = new Bitmap(BrickGame.Properties.Resources.HumanB);
            Human = HumanF;
            Wall = new Bitmap(BrickGame.Properties.Resources.Wall);
            Road = new Bitmap(BrickGame.Properties.Resources.Road);
            Box = new Bitmap(BrickGame.Properties.Resources.Box);
            Dot = new Bitmap(BrickGame.Properties.Resources.Dot);

            XHuman = 0;
            YHuman = 0;

            LoadMap();
           
        }

        private void LoadMap()
        {
            MapReal = new char[HTileSize][];
            for(int i =0;i<HTileSize;++i)
            {
                MapReal[i] = Map[Stage, i].ToCharArray();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            EndGame = true;

            Image Temp=Wall;
            for (int j = 0; j < HTileSize; ++j)
            {
                for (int i = 0; i < WTileSize; ++i)
                {
                    switch(MapReal[j][i])
                    {
                        case '#': Temp = Wall;
                            break;
                        case ' ':
                            Temp = Road;
                            break;
                        case '.':
                            Temp = Dot;
                            break;
                        case 'B':
                            Temp = Box;
                            if('.'!=Map[Stage,j][i])
                            {
                                EndGame = false;
                            }
                            break;
                        case '@':
                            Temp = Human;
                            XHuman=i;
                            YHuman=j;
                            Text = Title + "["+XHuman+","+YHuman+"]";
                            break;

                    }
                    e.Graphics.DrawImage(Temp, WTile * i, HTile * j);

                    //if ('#' == Map[j][i])
                    //{
                    //    Temp = Wall;
                    //}
                    //else if ('B' == Map[j][i])
                    //{
                    //    Temp = Box;
                    //}
                    //else if ('.' == Map[j][i])
                    //{
                    //    Temp = Dot;
                    //}
                    //else //if (' ' == Map[j][i])
                    //{
                    //    Temp = Road;                        
                    //}
                }
                
            }
        }

        private void Move()
        {
            if('#' == MapReal[YHuman][XHuman])
            {
                return;
            }
            if ('B' == MapReal[YHuman][XHuman])
            {
                if ('#' == MapReal[YHuman * 2 - YHumanOld][XHuman * 2 - XHumanOld])
                {
                    return;
                }
                if ('B' == MapReal[YHuman * 2 - YHumanOld][XHuman * 2 - XHumanOld])
                {
                    return;
                }
                MapReal[YHuman * 2 - YHumanOld][XHuman * 2 - XHumanOld] = 'B';
            }
            if ('.' == Map[Stage, YHumanOld][XHumanOld])
            {
                MapReal[YHumanOld][XHumanOld] = '.';
            }
            else
            {
                MapReal[YHumanOld][XHumanOld] = ' ';
            }

            MapReal[YHuman][XHuman] = '@';

        }
    

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            YHumanOld = YHuman;
            XHumanOld = XHuman;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (XHuman > 0)
                    {
                        XHuman = XHuman - 1;
                    }
                    Human = HumanL;
                    break;
                case Keys.Right:
                    if (XHuman < WTileSize)
                    {
                        XHuman = XHuman + 1;
                    }
                    Human = HumanR;
                    break;
                case Keys.Up:
                    if (YHuman > 0)
                    {
                        YHuman = YHuman - 1;
                    }
                    Human = HumanB;
                    break;
                case Keys.Down:
                    if(YHuman<HTileSize)
                    {
                        YHuman = YHuman + 1;
                    }
                    Human = HumanF;
                    break;

                case Keys.F5:
                    if(MessageBox.Show("다시 시작할까요?","다시 시작",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        LoadMap();
                    }
                    return;
                    default:
                    return;
            }
            Move();
            Refresh();

            if(true==EndGame)
            {
                ++Stage;
                if(Stage == (Map.Length/HTileSize))
                {
                    MessageBox.Show("게임을 종료합니다", "알림", MessageBoxButtons.OK);
                    Environment.Exit(0);
                }
                MessageBox.Show("다음판으로 이동합니다", "알림", MessageBoxButtons.OK);
                LoadMap();
                Refresh();
            }

           

        }
    }
}