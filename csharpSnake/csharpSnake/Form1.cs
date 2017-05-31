using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpSnake
{
    public partial class Form1 : Form
    {
        public enum Direction
        {
            None = 0,
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
        }
        Graphics gfx;
        Bitmap bmp;
        Snake head;
        List<Snake> body;
        Random rnd;
        Food food;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 165;
            pictureBox1.Dock = DockStyle.Fill;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);
            rnd = new Random();
            head = new Snake(0, 0, 25, 0, 0, 0, Color.LightGreen);
            body = new List<Snake>();
            body.Add(head);
            //generate first food
            food = new Food(rnd.Next(1, 19) * 25, rnd.Next(1, 19) * 25, 25, Color.Red);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    body[i].move(ClientSize.Width, ClientSize.Height);
                    body[i].draw(gfx);
                }
                else
                {

                    body[i].move(ClientSize.Width, ClientSize.Height);
                    body[i].draw(gfx);
                    body[i].direction = body[i - 1].direction;
                }
            }
            food.draw(gfx);

            for (int i = 0; i < body.Count; i++)
            {
                if (food.Hitbox.IntersectsWith(body[i].Hitbox))
                {
                    Snake temp = body[body.Count - 1];
                    if (temp.direction == (int)Direction.Up)
                    {
                        body.Add(new Snake(temp.X, temp.Y + 25, 25, temp.Xspeed, temp.Yspeed, (int)Direction.Up, Color.LightGreen));
                    }
                    if (temp.direction == (int)Direction.Down)
                    {
                        body.Add(new Snake(temp.X, temp.Y - 25, 25, temp.Xspeed, temp.Yspeed, (int)Direction.Down, Color.LightGreen));
                    }
                    if (temp.direction == (int)Direction.Left)
                    {
                        body.Add(new Snake(temp.X + 25, temp.Y, 25, temp.Xspeed, temp.Yspeed, (int)Direction.Left, Color.LightGreen));
                    }
                    if (temp.direction == (int)Direction.Right)
                    {
                        body.Add(new Snake(temp.X - 25, temp.Y, 25, temp.Xspeed, temp.Yspeed, (int)Direction.Right, Color.LightGreen));
                    }
                    regenFood();
                }
            }

            pictureBox1.Image = bmp;
        }

        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && head.direction != (int)Direction.Down)
            {
                body[0].direction = (int)Direction.Up;
            }
            if (e.KeyCode == Keys.Down && head.direction != (int)Direction.Up)
            {
                body[0].direction = (int)Direction.Down;
            }
            if (e.KeyCode == Keys.Left && head.direction != (int)Direction.Right)
            {
                body[0].direction = (int)Direction.Left;
            }
            if (e.KeyCode == Keys.Right && head.direction != (int)Direction.Left)
            {
                body[0].direction = (int)Direction.Right;
            }
        }

        public void gameOver()
        {
            MessageBox.Show("Game Over!");
        }

        public void regenFood()
        {
            do
            {
                food = new Food(rnd.Next(1, 19) * 25, rnd.Next(1, 19) * 25, 25, Color.Red);
            } while (!foodInSnake());
        }

        public bool foodInSnake()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (food.X == body[i].X || food.Y == body[i].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
