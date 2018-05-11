using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CGTransformer
{
	public class TransformHandler
	{
		private Transformer _transformer;
		private Dictionary<string, double> _intermediateEventDictionary;

		public TransformHandler() {}
		public TransformHandler(List<CheckBox> listOfTransformerCheckBoxs)
		{
			SetTransformMethod(listOfTransformerCheckBoxs);
		}

		public void SetTransformMethod(List<CheckBox> listOfTransformerCheckBoxs)
		{
			CheckBox tranformMethod = listOfTransformerCheckBoxs.FirstOrDefault(t => t.Checked);
			if (tranformMethod is null)
				throw new ArgumentException("Should Choose at least one transform method");
			if (tranformMethod.Name.Equals("Tranfer"))
			{
				_transformer = new TransferTranformer();
			} else if (tranformMethod.Name.Equals("Scale"))
			{
				_transformer = new ScaleTransformer();
			} else if (tranformMethod.Name.Equals("Rotate"))
			{
				_transformer = new RotateTransformer();
			} else if (tranformMethod.Name.Equals("Mirror"))
			{
				_transformer = new MirrorTransformer();
			}
		}

		public GraphicObject Transform(GraphicObject graphicObject)
		{
			GraphicObject transformedGraphicObject = new GraphicObject();

			if (_transformer is null || _intermediateEventDictionary is null)
				return graphicObject;

			Dictionary<string, double> tranferInfo = new Dictionary<string, double>
			{
				["Xc"] = graphicObject.Xc,
				["Yc"] = graphicObject.Yc
			};
			switch (_transformer)
			{
				case TransferTranformer _:
					tranferInfo["deltaX"] = _intermediateEventDictionary["X2"] - _intermediateEventDictionary["X1"];
					tranferInfo["deltaY"] = _intermediateEventDictionary["Y2"] - _intermediateEventDictionary["Y1"];
					_intermediateEventDictionary["X1"] = _intermediateEventDictionary["X2"];
					_intermediateEventDictionary["Y1"] = _intermediateEventDictionary["Y2"];
					break;
				case ScaleTransformer _:
					tranferInfo["scale"] = Math.Max(Math.Log(Math.Abs(_intermediateEventDictionary["X2"] - _intermediateEventDictionary["X1"]), 10), 1.005);
					tranferInfo["scale"] = _intermediateEventDictionary["X2"] - _intermediateEventDictionary["X1"] > 0
						? tranferInfo["scale"]
						: 1 / tranferInfo["scale"];
					_intermediateEventDictionary["X1"] = _intermediateEventDictionary["X2"];
					_intermediateEventDictionary["Y1"] = _intermediateEventDictionary["Y2"];
					break;
				case RotateTransformer _:
					tranferInfo["deltaX"] = _intermediateEventDictionary["X2"] - _intermediateEventDictionary["X1"];
					tranferInfo["deltaY"] = _intermediateEventDictionary["Y2"] - _intermediateEventDictionary["Y1"];
					break;
				case MirrorTransformer _:
					tranferInfo["XAxis"] = _intermediateEventDictionary["XAxis"];
					tranferInfo["YAxis"] = _intermediateEventDictionary["YAxis"];
					break;
			}
			foreach (Shape shape in graphicObject.ListOfShapes)
			{
				transformedGraphicObject.AddShape(_transformer.Transform(shape, tranferInfo));
			}
			return transformedGraphicObject;
		}

		public void HandleCanvasClickEvent(Dictionary<string, double> eventDictionary)
		{
			if (_intermediateEventDictionary is null)
				_intermediateEventDictionary = new Dictionary<string, double>();
			if (eventDictionary.TryGetValue("X", out _) && !_intermediateEventDictionary.TryGetValue("X1", out _))
			{
				_intermediateEventDictionary["X1"] = eventDictionary["X"];
				_intermediateEventDictionary["Y1"] = eventDictionary["Y"];
			} else if (eventDictionary.TryGetValue("XAxis", out _))
			{
				_intermediateEventDictionary["XAxis"] = eventDictionary["XAxis"];
				_intermediateEventDictionary["YAxis"] = eventDictionary["YAxis"];
			}
			else if (eventDictionary.TryGetValue("X", out _) && _intermediateEventDictionary.TryGetValue("X1", out _))
			{
				_intermediateEventDictionary["X2"] = eventDictionary["X"];
				_intermediateEventDictionary["Y2"] = eventDictionary["Y"];
			}
		}

		public void HandleResetCanvasEvent()
		{
			_intermediateEventDictionary.Remove("X1");
			_intermediateEventDictionary.Remove("Y1");
		}
	}
}
