using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    class Trapezoid : Quadrilateral
    {
        private int p1;
        private int p2;
        private int p3;

        public Trapezoid(int p1, int p2, int p3)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public object LongBase { get; set; }

        public object ShortBase { get; set; }

        public object Height { get; set; }

        public object AcuteAngle { get; set; }

        public object ObtuseAngle { get; set; }

        public override void Scale(int percent)
        {
            throw new NotImplementedException();
        }

        public override decimal Area()
        {
            throw new NotImplementedException();
        }

        public override decimal Perimeter()
        {
            throw new NotImplementedException();
        }
    }
}
