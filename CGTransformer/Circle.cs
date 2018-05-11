
using System;

namespace CGTransformer
{
	class Circle : Shape
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Radius { get; set; }
		public override double GetXc => X;
		public override double GetYc => Y;
	}
}
