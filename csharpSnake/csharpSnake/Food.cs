using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace csharpSnake
{
    class Food
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
        Color color;
        Rectangle hitbox;
        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
        }

        public Food(int x, int y, int size, Color color)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.color = color;
            hitbox = new Rectangle(x, y, size, size);
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(new SolidBrush(Color.Red), x, y, size, size);

        }

        public void erase(Graphics gfx, Color backcolor)
        {
            gfx.FillRectangle(new SolidBrush(backcolor), x, y, size, size);
        }

    }
}
