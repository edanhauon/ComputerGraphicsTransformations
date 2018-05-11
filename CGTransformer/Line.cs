
using System;

namespace CGTransformer
{
	class Line : Shape
	{
		public double X1 { get; set; }
		public double Y1 { get; set; }
		public double X2 { get; set; }
		public double Y2 { get; set; }

		public override double GetXc => Math.Min(X1, X2);
		public override double GetYc => Math.Min(Y1, Y2);
	}
}
