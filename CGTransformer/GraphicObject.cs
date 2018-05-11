using System;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace CGTransformer
{
	public class GraphicObject
	{
		public List<Shape> ListOfShapes { get;  }
		public double Xc { get; set; }
		public double Yc { get; set; }

		public GraphicObject()
		{
			ListOfShapes = new List<Shape>();
			Xc = 2000;
			Yc = 2000;
		}

		public void AddShape(Shape shape)
		{
			ListOfShapes.Add(shape);
			Xc = Math.Min(Xc, shape.GetXc);
			Yc = Math.Min(Yc, shape.GetYc);
		}
	}
}
