

using System;

namespace CGTransformer
{
	public abstract class Shape
	{
		public double Scale { get; set; }
		public virtual double GetXc => throw new NotImplementedException();
		public virtual double GetYc => throw new NotImplementedException();
	}
}
