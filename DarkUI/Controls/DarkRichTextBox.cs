using DarkUI.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class MyScrollEvent : EventArgs
    {
        /// <summary>
        /// The value of Scroll.
        /// </summary>
        public int Value { get; private set; }

        public MyScrollEvent(int value)
        {
            Value = value;
        }
    }

    public class DarkRichTextBox : RichTextBox
    {
        #region Events

        /// <summary>
        /// Occurs, when the Scroll property changes
        /// </summary>
        [Description("Occurs, when the Scroll property changes")]
        public event EventHandler<MyScrollEvent> Scroll;

        #endregion

        #region Constructor Region
        private Timer _scrollTimer;

        public DarkRichTextBox()
        {
            BackColor = Colors.LightBackground;
            ForeColor = Colors.LightText;
            SelectionColor = Colors.BlueSelection;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.None;

            _scrollTimer = new Timer();
            _scrollTimer.Interval = 1;
            _scrollTimer.Tick += ScrollTimerTick;
            _scrollTimer.Enabled = true;
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        struct ScrollInfo
        {
            public int cbSize; // (uint) int is because of Marshal.SizeOf
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        public enum ScrollInfoMask : uint
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
        }

        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(int hWnd, int nBar);
        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32.dll")]
        private static extern bool PostMessageA(IntPtr hWnd, int nBar, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int GetScrollInfo(IntPtr hWnd, int nBar, ref ScrollInfo Info);

        private int internal_HScrollPos;
        public int HScrollPos
        {
            get
            {
                internal_HScrollPos = GetScrollPos((int)this.Handle, SB_HORZ);
                return internal_HScrollPos;
            }
            set
            {
                SetScrollPos((IntPtr)this.Handle, SB_HORZ, value, true);
                PostMessageA((IntPtr)this.Handle, WM_HSCROLL, SB_THUMBPOSITION + 0x10000 * value, 0);
            }
        }

        private int internal_VScrollPos;
        public int VScrollPos
        {
            get
            {
                internal_VScrollPos = GetScrollPos((int)this.Handle, SB_VERT);
                return internal_VScrollPos;
            }
            set
            {
                SetScrollPos((IntPtr)this.Handle, SB_VERT, value, true);
                PostMessageA((IntPtr)this.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * value, 0);
            }
        }

        private int internal_MaxVScroll;
        public int MaxVScroll
        {
            get
            {
                ScrollInfo ScrollInfo = new ScrollInfo();
                ScrollInfo.cbSize = Marshal.SizeOf(ScrollInfo);
                ScrollInfo.fMask = (int)ScrollInfoMask.SIF_ALL;
                GetScrollInfo(this.Handle, SB_VERT, ref ScrollInfo);

                return internal_MaxVScroll = ScrollInfo.nMax;
            }
        }

        private int OldVScrollPos = 0;
        private void ScrollTimerTick(object sender, EventArgs e)
        {
            internal_VScrollPos = GetScrollPos((int)this.Handle, SB_VERT);
            if (internal_VScrollPos != OldVScrollPos)
            {
                if (Scroll != null)
                    Scroll(this, new MyScrollEvent(internal_VScrollPos));

                OldVScrollPos = internal_VScrollPos;
            }
        }

        public void AppendText(string text, Color color)
        {
            SelectionStart = TextLength;
            SelectionLength = 0;

            SelectionColor = color;
            AppendText(text);
            SelectionColor = ForeColor;
        }

        #endregion
    }
}
