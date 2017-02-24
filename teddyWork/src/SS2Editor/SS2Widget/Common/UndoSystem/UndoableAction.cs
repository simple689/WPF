using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Common.UndoSystem
{
	public abstract class UndoableAction
	{
		public abstract void Do();
		public abstract void Undo();
	}
}
