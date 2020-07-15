using System.Windows.Forms;
using System.Drawing;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int WTileSize = 16;
        const int HTileSize = 9;
        const string Title = "푸시푸시 - 안드로이드의 모험";

        char[][] MapReal;
        string[] Map;

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

            string[] TempMap = { "################",
                                 "#         #    #",
                                 "###### B  .  ###",
                                 "#BBB ####    ###",
                                 "####   ####   ##",
                                 "#        @     #",
                                 "## B###        #",
                                 "#B        ###  #",
                                 "################"
                                };
            MapReal = new char[HTileSize][];
            for(int i = 0; i<HTileSize;++i) //9줄 반복
            {
                MapReal[i] = TempMap[i].ToCharArray();
            }
            Map = TempMap;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string t = "test";
            char[] ct = t.ToCharArray();

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
                MapReal[YHuman*2-YHumanOld][XHuman*2-XHumanOld] = 'B';
            }
            MapReal[YHumanOld][XHumanOld] = ' ';
            MapReal[YHuman][XHuman] = '@';
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            YHumanOld = YHuman;
            XHumanOld = XHuman;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    --XHuman;
                    Human = HumanL;
                    break;
                case Keys.Right:
                    ++XHuman;
                    Human = HumanR;
                    break;
                case Keys.Up:
                    --YHuman;
                    Human = HumanB;
                    break;
                case Keys.Down:
                    ++YHuman;
                    Human = HumanF;
                    break;
                default:
                    return;
            }
            Move();
            Refresh();

        }
    }
}