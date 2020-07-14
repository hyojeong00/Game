using System.Windows.Forms;
using System.Drawing;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int WTileSize = 16;
        const int HTileSize = 9;

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
        public Form1()
        {
            InitializeComponent();

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
                                 "          #    #",
                                 "###### B  .  ## ",
                                 "#BBB ###########",
                                 "####   #####  ##",
                                 "#              #",
                                 "## B###        #",
                                 "#B        ###   ",
                                 "#######         "};
            Map = TempMap;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int j = 0; j < HTileSize; ++j)
            {
                for (int i = 0; i < WTileSize; ++i)
                {
                    if ('#' == Map[j][i])
                    {
                        e.Graphics.DrawImage(Wall, WTile * i, HTile * j);
                    }
                    else if ('B' == Map[j][i])
                    {
                        e.Graphics.DrawImage(Box, WTile * i, HTile * j);
                    }
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    XHuman = XHuman - 10;
                    Human = HumanL;
                    break;
                case Keys.Right:
                    XHuman = XHuman + 10;
                    Human = HumanR;
                    break;
                case Keys.Up:
                    YHuman = YHuman - 10;
                    Human = HumanB;
                    break;
                case Keys.Down:
                    YHuman = YHuman + 10;
                    Human = HumanF;
                    break;
                default:
                    return;
            }

            Refresh();

        }
    }
}