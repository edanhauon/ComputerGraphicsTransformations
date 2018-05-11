using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Shapes;
using CGTransformer.Properties;
// ReSharper disable All


namespace CGTransformer
{
	class GraphicOjectReader
	{
		private static readonly Regex LineRegex = new Regex(@"L:([0-9]+,){3}[0-9]+$");
		private static readonly Regex CircleRegex = new Regex(@"C:([0-9]+,){2}[0-9]+$");

		public static GraphicObject ReadGraphicObject()
		{
			GraphicObject graphicObject = new GraphicObject();
			using (StringReader reader = new StringReader(Resources.car))
			{
				for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
				{
					if (!LineRegex.IsMatch(line) && !CircleRegex.IsMatch(line))
						throw new ArgumentException("A line was caught violating the format, value:" + line);
					if (line.StartsWith("L"))
					{
						List<double> coords = line.Substring(2).Split(',').Select(double.Parse).ToList();
						graphicObject.AddShape(new Line
						{
							X1 = coords[0], Y1 = coords[1], X2 = coords[2], Y2 = coords[3], Scale = 1
						});
					}
					else if (line.StartsWith("C"))
					{
						List<double> coords = line.Substring(2).Split(',').Select(double.Parse).ToList();
						graphicObject.AddShape(new Circle
						{
							X = coords[0], Y = coords[1], Radius = coords[2], Scale = 1
						});
					}
				}

			}
			return graphicObject;
		}
	}
}
