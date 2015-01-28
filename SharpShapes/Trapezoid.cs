using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
    {
        public decimal LongBase { get; private set; }
        public decimal ShortBase { get; private set; }
        public decimal Height { get; private set; }
        public decimal AcuteAngle { get; private set; }
        public decimal ObtuseAngle { get; private set; }

        public Trapezoid(int longBase, int shortBase, int height)
        {
            if (height <= 0 || longBase <= 0 || shortBase <= 0 || longBase <= shortBase)
            {
                throw new ArgumentException();
            }
            this.LongBase = longBase;
            this.ShortBase = shortBase;
            this.Height = height;

            decimal wingLength = WingLength();
            this.AcuteAngle = Decimal.Round((decimal)(Math.Atan((double)(Height/wingLength)) * (180 / Math.PI)), 2);
            this.ObtuseAngle = 180 - AcuteAngle;
        }

        private decimal WingLength()
        {
            return (decimal)((LongBase - ShortBase) / 2);
        }

       

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.LongBase = LongBase * percent / 100;
            this.ShortBase = ShortBase * percent / 100;
            this.Height = Height * percent / 100;
        }

        public override decimal Area()
        {
            return ((LongBase + ShortBase ) / 2) * Height;
        }

        public override decimal Perimeter()
        {
            double squares = (double)((WingLength() * WingLength()) + (Height * Height));
            decimal legLength = Decimal.Round((decimal)Math.Sqrt(squares));
            return LongBase + ShortBase + 2 * legLength;
        }
    }
}
