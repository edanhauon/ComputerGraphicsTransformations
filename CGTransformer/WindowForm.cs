using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace CGTransformer
{
	public partial class WindowForm : Form
	{
		private readonly List<CheckBox> _listOfTransformCheckBoxs = new List<CheckBox>();
		private GraphicObject _graphicObject = GraphicOjectReader.ReadGraphicObject();
		private readonly TransformHandler _transformHandler = new TransformHandler();
		public WindowForm()
		{
			InitializeComponent();
			this.Width = 950;
			this.Height = 850;
			_listOfTransformCheckBoxs.Add(Tranfer);
			_listOfTransformCheckBoxs.Add(Scale);
			_listOfTransformCheckBoxs.Add(Rotate);
			_listOfTransformCheckBoxs.Add(Mirror);
		}

		private void DrawButton_Click(object sender, System.EventArgs e)
		{
			if (_listOfTransformCheckBoxs.FirstOrDefault(t => t.Checked) != null)
			{
				_graphicObject = _transformHandler.Transform(_graphicObject);
				DrawShapeHandler.DrawObject(_graphicObject, Canvas);
			}
			DrawShapeHandler.DrawObject(_graphicObject, Canvas);
		}

		private void CheckedChanged(object sender, EventArgs e)
		{
			if (_listOfTransformCheckBoxs.FirstOrDefault(t => t.Checked) != null)
				_transformHandler.SetTransformMethod(_listOfTransformCheckBoxs);
			Axis.Visible = (_listOfTransformCheckBoxs.FirstOrDefault(t => t.Checked) == Mirror);
		}

		private void Canvas_MouseDown(object sender, MouseEventArgs e)
		{
			Dictionary<string, double> eventDictionary = new Dictionary<string, double>
			{
				["X"] = e.X,
				["Y"] = e.Y
			};
			_transformHandler.HandleCanvasClickEvent(eventDictionary);

			if (_listOfTransformCheckBoxs.FirstOrDefault(t => t.Checked) != Mirror) return;
			GraphicObject transformedGraphicObject = _transformHandler.Transform(_graphicObject);
			DrawShapeHandler.DrawObject(transformedGraphicObject, Canvas);
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			Dictionary<string, double> eventDictionary = new Dictionary<string, double>
			{
				["X"] = e.X,
				["Y"] = e.Y
			};
			_transformHandler.HandleCanvasClickEvent(eventDictionary);

			if (_listOfTransformCheckBoxs.FirstOrDefault(t => t.Checked) != null)
			{
				GraphicObject transformedGraphicObject = _transformHandler.Transform(_graphicObject);
				DrawShapeHandler.DrawObject(transformedGraphicObject, Canvas);
			} else
			{
				DrawShapeHandler.DrawObject(_graphicObject, Canvas);
			}
		}

		private void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			_transformHandler.HandleResetCanvasEvent();
		}

	}
}
