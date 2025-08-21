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

namespace Tron
{
    public partial class FormTron : Form
    {
        #region variables
        private Bike player1;
        private Bike player2;
        private string winner;
        private Graphics g;
        private bool gameover = false, start = false;
        private static int up = 0, down = 1, right = 2, left = 3;
        private int playerDirection1 = right;
        private int playerDirection2 = left;
        private int points1 = 0, points2 = 0, rounds = 0;
        private int moveOffset;
        private Size playerSize;
        private List<Rectangle> paths1 = new List<Rectangle>();
        private List<Rectangle> paths2 = new List<Rectangle>();
        private SolidBrush playerColor1 = new SolidBrush(Color.Red);
        private SolidBrush playerColor2 = new SolidBrush(Color.Blue);
        private SolidBrush pathColor1 = new SolidBrush(Color.DarkRed);
        private SolidBrush pathColor2 = new SolidBrush(Color.DarkBlue);
        Keys W = Keys.W;
        Keys S = Keys.S;
        Keys D = Keys.D;
        Keys A = Keys.A;
        Keys Up = Keys.Up;
        Keys Dn = Keys.Down;
        Keys Rt = Keys.Right;
        Keys Lt = Keys.Left;
        Keys k;
        #endregion
        public FormTron()
        {
            InitializeComponent();
            Init();
            SpawnPlayers();
        }
        private void Init()
        {
            WindowState = FormWindowState.Maximized;
            pb1.Dock = DockStyle.Fill;
        }
        private void SpawnPlayers()
        {
            playerSize = new Size(Convert.ToInt32(pb1.Width * 0.015), Convert.ToInt32(pb1.Width * 0.015));
            player1 = new Bike(new Point(pb1.Width / 2 - Convert.ToInt32(pb1.Width * 0.25), pb1.Height / 2), playerSize, playerColor1);
            player2 = new Bike(new Point(pb1.Width / 2 + Convert.ToInt32(pb1.Width * 0.25), pb1.Height / 2), playerSize, playerColor2);
        }
        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            pb1.Refresh();
        }
        private bool checkBounds(Bike player)
        {
            return !(player.location.Y >= 0 && player.location.Y <= pb1.Size.Height - player.size.Height && player.location.X >= 0 && player.location.X <= pb1.Size.Width - player.size.Width);
        }
        private bool checkIntersection(Bike player)
        {
            foreach (Rectangle path in paths1)
            {
                if (player.Intersect(path))
                {
                    return true;
                }
            }
            foreach (Rectangle path in paths2)
            {
                if (player.Intersect(path))
                {
                    return true;
                }
            }
            return false;
        }
        private bool checkTie()
        {
            return player1.Intersect(player2.Rectangle);
        }
        private void tmCollision_Tick(object sender, EventArgs e)
        {
            if (checkBounds(player1) || checkIntersection(player1) && checkTie() != true)
            {
                winner = "Player 2 (modrý)";
                gameover = true;
                points2++;
            }
            else if (checkBounds(player2) || checkIntersection(player2) && checkTie() != true)
            {
                winner = "Player 1 (červený)";
                gameover = true;
                points1++;
            }
            else if (checkTie())
            {
                winner = "Oba";
                gameover = true;
                points1++;
                points2++;
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            if (start)
            {
                moveOffset = player1.size.Width;
                if (gameover == false)
                {
                    paths1.Add(player1.Rectangle);
                    paths2.Add(player2.Rectangle);
                    foreach (var item in paths1)
                    {
                        g.FillRectangle(pathColor1, item);
                    }
                    foreach (var item in paths2)
                    {
                        g.FillRectangle(pathColor2, item);
                    }
                    if (playerDirection1 == up)
                    {
                        paths1.Add(player1.Rectangle);
                        player1.location.Y -= moveOffset;
                    }
                    else if (playerDirection1 == down)
                    {
                        paths1.Add(player1.Rectangle);
                        player1.location.Y += moveOffset;
                    }
                    else if (playerDirection1 == right)
                    {
                        paths1.Add(player1.Rectangle);
                        player1.location.X += moveOffset;
                    }
                    else if (playerDirection1 == left)
                    {
                        paths1.Add(player1.Rectangle);
                        player1.location.X -= moveOffset;
                    }
                    if (playerDirection2 == up)
                    {
                        paths2.Add(player2.Rectangle);
                        player2.location.Y -= moveOffset;
                    }
                    else if (playerDirection2 == down)
                    {
                        paths2.Add(player2.Rectangle);
                        player2.location.Y += moveOffset;

                    }
                    else if (playerDirection2 == right)
                    {
                        paths2.Add(player2.Rectangle);
                        player2.location.X += moveOffset;
                    }
                    else if (playerDirection2 == left)
                    {
                        paths2.Add(player2.Rectangle);
                        player2.location.X -= moveOffset;
                    }
                    player1.Draw(g);
                    player2.Draw(g);
                }
                else
                {
                    tmCollision.Stop();
                    tmRefresh.Stop();
                    rounds++;
                    MessageBox.Show($"Vítěz kola: {winner}", $"Konec kola ({rounds} / 3)!");
                    Text = $"TRON - {points1} / {points2}";
                    if (rounds == 3)
                    {
                        if (points1 > points2)
                        {
                            winner = "Player 1 (červený)";
                        }
                        else if (points2 > points1)
                        {
                            winner = "Player 2 (modrý)";
                        }
                        else
                        {
                            winner = "Oba";
                        }
                        MessageBox.Show($"Vítěz: {winner}", "Konec hry!");
                        rounds = 0;
                        points1 = 0;
                        points2 = 0;
                        Text = $"TRON - {points1} / {points2}";
                    }
                    paths1.Clear();
                    paths2.Clear();
                    SpawnPlayers();
                    player1.Draw(g);
                    player2.Draw(g);
                    playerDirection1 = right;
                    playerDirection2 = left;
                    gameover = false;
                }
            }
            else
            {
                player1.Draw(g);
                player2.Draw(g);
            }
        }
        private void FormTron_SizeChanged(object sender, EventArgs e)
        {
            paths1.Clear();
            paths2.Clear();
            SpawnPlayers();
            start = false;
            tmRefresh.Enabled = false;
            tmCollision.Enabled = false;
        }
        private void FormTron_KeyDown(object sender, KeyEventArgs e)
        {
            k = e.KeyCode;
            if (k == W && playerDirection1 != down && tmRefresh.Enabled == true)
            {
                playerDirection1 = up;
            }
            else if (k == S && playerDirection1 != up && tmRefresh.Enabled == true)
            {
                playerDirection1 = down;
            }
            else if (k == D && playerDirection1 != left && tmRefresh.Enabled == true) 
            {
                playerDirection1 = right;
            }
            else if (k == A && playerDirection1 != right && tmRefresh.Enabled == true)
            {
                playerDirection1 = left;
            }

            if (k == Up && playerDirection2 != down && tmRefresh.Enabled == true)
            {
                playerDirection2 = up;
            }
            else if (k == Dn && playerDirection2 != up && tmRefresh.Enabled == true)
            {
                playerDirection2 = down;
            }
            else if (k == Rt && playerDirection2 != left && tmRefresh.Enabled == true)
            {
                playerDirection2 = right;
            }
            else if (k == Lt && playerDirection2 != right && tmRefresh.Enabled == true)
            {
                playerDirection2 = left;
            }
            if (k == Keys.Space)
            {
                start = true;
                tmRefresh.Enabled = !tmRefresh.Enabled;
                tmCollision.Enabled = true;
            }
        }
    }
}
