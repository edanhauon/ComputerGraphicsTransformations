using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CGTransformer
{
	class RotateTransformer : Transformer
	{
		public override Shape Transform(Shape shape, Dictionary<string, double> tranferInfo)
		{
			double deltaY = tranferInfo["deltaY"];
			double cosAlpha = Math.Cos(Math.Sign(deltaY) * Math.PI / 32);
			double sinAlpha = Math.Sin(Math.Sign(deltaY) * Math.PI / 32);
			double Xc = tranferInfo["Xc"], Yc = tranferInfo["Yc"];
			double[,] scaleMatrix =
			{
				{ cosAlpha, -1 * sinAlpha, 0 },
				{ sinAlpha, cosAlpha, 0 },
				{ Xc - Xc * cosAlpha - Yc * sinAlpha, Yc - Yc * cosAlpha + Xc * sinAlpha, 1 },
			};
			switch (shape)
			{
				case Circle circle:
					double[,] pointMatric = { { circle.X, circle.Y, 1 } };
					double[,] result = MultiplyMatrix(pointMatric, scaleMatrix);
					circle.X = result[0, 0];
					circle.Y = result[0, 1];
					return circle;
				case Line line:
					double[,] firstPointMatric = { { line.X1, line.Y1, 1} };
					double[,] secondPointMatric = { { line.X2, line.Y2, 1 } };
					double[,] firstResult = MultiplyMatrix(firstPointMatric, scaleMatrix);
					double[,] secondResult = MultiplyMatrix(secondPointMatric, scaleMatrix);
					line.X1 = firstResult[0, 0];
					line.X2 = secondResult[0, 0];
					line.Y1 = firstResult[0, 1];
					line.Y2 = secondResult[0, 1];
					return line;
			}

			return shape;
		}
	}
}