using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Linq;

namespace CGTransformer
{
	class DrawShapeHandler
	{
		public static void DrawObject (GraphicObject graphicObject, PictureBox canvas)
		{
			Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);

			using (Graphics grf = Graphics.FromImage(bmp))
			{
				foreach (Shape shape in graphicObject.ListOfShapes)
				{
					switch (shape)
					{
						case Circle circle:
							grf.DrawEllipse(
								Pens.Black,
								x: (float)(circle.X - (circle.Radius * circle.Scale)),
								y: (float)(circle.Y - (circle.Radius * circle.Scale)),
								width: (float)(circle.Radius * 2 * circle.Scale),
								height: (float)(circle.Radius * 2 * circle.Scale));
							break;
						case Line line:
							grf.DrawLine(
								pen: Pens.Black,
								x1: (float)(line.X1),
								y1: (float)(line.Y1),
								x2: (float)(line.X2),
								y2: (float)(line.Y2));
							break;
					}
				}
			}
			canvas.Image?.Dispose();
			canvas.Image = bmp;
		}


	}
}
