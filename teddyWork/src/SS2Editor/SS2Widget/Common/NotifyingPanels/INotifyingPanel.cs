using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Common
{
	internal interface INotifyingPanel
	{
		NotifyingUIElementCollection NotifyingChildren { get; }
		event EventHandler ChildrenCreated;
	}
}
