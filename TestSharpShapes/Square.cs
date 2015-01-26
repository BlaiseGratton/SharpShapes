using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    public class Square : Rectangle
    {
        private decimal width;
        public new decimal Width
        {
            get { return this.width; }
        }

        private decimal height;
        public new decimal Height
        {
            get { return this.height; }
        }

        public Square(int side) : base(side, side)
        {
            if (side <= 0)
            {
                throw new ArgumentException();
            }
            this.width = side;
            this.height = side;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }

            this.width = width * percent / 100;
            this.height = height * percent / 100;
        }
    }
}

