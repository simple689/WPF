using System;
using System.Windows.Controls;
using System.Windows;

namespace SpeedShark2.Common {
    internal sealed class NotifyingStackPanel : StackPanel, INotifyingPanel {
        #region INotifyingPanel Members

        private NotifyingUIElementCollection notifyingChildren;
        public NotifyingUIElementCollection NotifyingChildren {
            get { return notifyingChildren; }
        }

        protected override UIElementCollection CreateUIElementCollection(FrameworkElement logicalParent) {
            notifyingChildren = new NotifyingUIElementCollection(this, logicalParent);
            ChildrenCreated.Raise(this);

            return notifyingChildren;
        }

        public event EventHandler ChildrenCreated;

        #endregion
    }
}
