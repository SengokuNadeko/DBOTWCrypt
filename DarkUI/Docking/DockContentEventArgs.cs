using System;
using System.ComponentModel;

namespace DarkUI.Docking
{
    public class DockContentEventArgs : EventArgs
    {
        public DarkDockContent Content { get; private set; }

        public DockContentEventArgs(DarkDockContent content)
        {
            Content = content;
        }
    }
    public class DockContentRemovingEventArgs : EventArgs
    {
        public DarkDockContent Content { get; private set; }

        public Boolean Cancel { get; set; } = new Boolean(false);


        public DockContentRemovingEventArgs(DarkDockContent content, Boolean cancel)
        {
            Content = content;
            Cancel = cancel;
        }
    }

    public class Boolean
    {
        public bool Value { get; set; }
        public Boolean(bool value) { this.Value = value; }
    }
}
