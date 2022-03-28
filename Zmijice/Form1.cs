using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmijice
{
    public partial class forma : Form
    {
        int dimenzije = 10;
        SolidBrush snakeBrush;
        SolidBrush foodBrush;
        //Pen borderPen;
        //Point[] border;
        int score;
        int highScore;
        Graphics g;
        List<Rectangle> zmija;
        Rectangle food;
        Random r;
        int directionX = 1;
        int directionY = 0;
        Keys direction = Keys.Right;
        bool shouldPop = true;
        public forma()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            updateSnake();
            checkForEnd();
            Nacrtaj();
            checkForFood();
        }

        private void forma_Load(object sender, EventArgs e)
        {
            r = new Random();
            zmija = new List<Rectangle>();
            snakeBrush = new SolidBrush(Color.Black);
            foodBrush = new SolidBrush(Color.Red);
            g = tabla.CreateGraphics();
            highScore = 0;
            //borderPen = new Pen(Color.Black, dimenzije / 2);
            //border = new Point[] {
            //    new Point(0, 0),
            //    new Point(tabla.Width - dimenzije / 2, 0),
            //    new Point(tabla.Width - dimenzije / 2, tabla.Height - dimenzije / 2),
            //    new Point(0, tabla.Height - dimenzije / 2),
            //    new Point(0, 0)
            //};
        }
        private void Reset()
        {
            zmija.Clear();
            score = 0;
            scoreLabel.Text = "0";
            directionX = 1;
            directionY = 0;
            direction = Keys.Right;
            shouldPop = true;
            int x = tabla.Width / 2 - dimenzije / 2;
            int y = tabla.Height / 2 - dimenzije / 2;
            Rectangle glava = new Rectangle(x, y, dimenzije, dimenzije);
            zmija.Add(glava);
            createFood();
            Nacrtaj();
        }
        private void createFood()
        {
            int x = r.Next(0, (tabla.Width - dimenzije * 2) / dimenzije) * dimenzije + dimenzije / 2;
            int y = r.Next(0, (tabla.Height - dimenzije) / dimenzije) * dimenzije + dimenzije / 2;
            food = new Rectangle(x, y, dimenzije, dimenzije);
        }
        private void Nacrtaj()
        {
            tabla.Refresh();
            //g.DrawLines(borderPen, border);
            g.FillRectangle(foodBrush, food);
            foreach (Rectangle deo in zmija)
                g.FillRectangle(snakeBrush, deo);
        }

        private void start_Click(object sender, EventArgs e)
        {
            Reset();
            start.Enabled = false;
            this.Focus();
            start.Hide();
            Nacrtaj();
            timer.Start();
        }

        private void handleKeyDown(Keys key)
        {
            switch(key)
            {
                case Keys.Up:
                    if (direction == Keys.Down) return;
                    directionX = 0;
                    directionY = -1;
                    direction = key;
                    break;
                case Keys.Down:
                    if (direction == Keys.Up) return;
                    directionX = 0;
                    directionY = +1;
                    direction = key;
                    break;
                case Keys.Left:
                    if (direction == Keys.Right) return;
                    directionX = -1;
                    directionY = 0;
                    direction = key;
                    break;
                case Keys.Right:
                    if (direction == Keys.Left) return;
                    directionX = +1;
                    directionY = 0;
                    direction = key;
                    break;
                case Keys.Space:
                    timer.Enabled = !timer.Enabled;
                    break;
            }
        }

        private void updateSnake()
        {
            Rectangle newHead = new Rectangle(
                    zmija[0].X + directionX * dimenzije,
                    zmija[0].Y + directionY * dimenzije,
                    dimenzije,
                    dimenzije
                );
            if (shouldPop)
                zmija.RemoveAt(zmija.Count - 1);
            else
                shouldPop = true;
            zmija.Insert(0, newHead);
        }
        private void EndMessage()
        {
            if(score > highScore)
            {
                highScore = score;
                highScoreLabel.Text = highScore.ToString();
            }
            timer.Stop();
            start.Visible = true;
            start.Enabled = true;
            start.Focus();
        }
        private void checkForEnd()
        {
            int headX = zmija[0].X;
            int headY = zmija[0].Y;
            if ((headX < 0 || (headX + dimenzije) > tabla.Width) || (headY < 0 || (headY + dimenzije) > tabla.Height)) // border
                EndMessage();
            bool selfColision = false;
            for (int i = 1; i < zmija.Count; i++)
            {
                int x = zmija[i].X;
                int y = zmija[i].Y;
                if (headX == x && headY == y)
                {
                    selfColision = true;
                    break;
                }
            }
            if (selfColision)
                EndMessage();
        }
        private void checkForFood()
        {
            int x = zmija[0].X;
            int y = zmija[0].Y;
            if(food.X == x && food.Y == y)
            {
                score += 10;
                scoreLabel.Text = score.ToString();
                createFood();
                shouldPop = false;
            }
        }
        private void forma_KeyDown(object sender, KeyEventArgs e)
        {
            if (!timer.Enabled && e.KeyCode != Keys.Space) return;
            handleKeyDown(e.KeyCode);
        }
    }
}
