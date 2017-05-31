using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace csharpSnake
{
    class Snake
    {
        int x;
        public int X
        {
            get
            {
                return x;
            }
        }
        int y;
        public int Y
        {
            get
            {
                return y;
            }
        }
        int size;
        int xspeed;
        public int Xspeed
        {
            get
            {
                return xspeed;
            }
        }
        int yspeed;
        public int Yspeed
        {
            get
            {
                return yspeed;
            }
        }
        public int direction;
        Color color;
        Rectangle hitbox;
        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
        }

        public Snake(int x, int y, int size, int xspeed, int yspeed, int direction, Color color)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.xspeed = xspeed;
            this.yspeed = yspeed;
            this.direction = direction;
            this.color = color;
            hitbox = new Rectangle(x, y, size, size);
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(new SolidBrush(color), x, y, size, size);
        }

        public void erase(Graphics gfx, Color backcolor)
        {
            gfx.FillRectangle(new SolidBrush(backcolor), x, y, size, size);
        }
        public void move(int width, int height)
        {
            //out of bounds check (not used in snake class)
            if (x < 0 || x + size > width || y < 0 || y + size > height)
            {
            }

            if (direction == (int)Form1.Direction.Up)
            {
                xspeed = 0;
                yspeed = -25;
            }
            if (direction == (int)Form1.Direction.Down)
            {
                xspeed = 0;
                yspeed = 25;
            }
            if (direction == (int)Form1.Direction.Left)
            {
                xspeed = -25;
                yspeed = 0;
            }
            if (direction == (int)Form1.Direction.Right)
            {
                xspeed = 25;
                yspeed = 0;
            }

            x += xspeed;
            y += yspeed;

            hitbox = new Rectangle(x, y, size, size);
        }
    }
}
