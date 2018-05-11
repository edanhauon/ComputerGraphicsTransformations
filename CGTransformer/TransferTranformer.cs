using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CGTransformer
{
	class TransferTranformer : Transformer
	{
		public override Shape Transform(Shape shape, Dictionary<string, double> tranferInfo)
		{
			double deltaX = tranferInfo["deltaX"], deltaY = tranferInfo["deltaY"];
			switch (shape)
			{
				case Circle circle:
					circle.X += deltaX;
					circle.Y += deltaY;
					return circle;
				case Line line:
					line.X1 += deltaX;
					line.X2 += deltaX;
					line.Y1 += deltaY;
					line.Y2 += deltaY;
					return line;
			}

			return shape;
		}
	}
}
