using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;
using DarkUI.Extensions;

namespace DarkUI.Controls
{
    public sealed class DarkTabControl : TabControl
    {
        public DarkTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            BackColor = Colors.GreyBackground;
            ForeColor = Colors.LightText;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            ItemSize = new Size(330, 30);
            Alignment = TabAlignment.Top;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = ClientRectangle;
            var bgColor = Colors.HeaderBackground;
            var darkColor = Colors.DarkBorder;
            var lightColor = Colors.LightBorder;

            // Draw header
            using (var b = new SolidBrush(bgColor))
            {
                var bgRect = new Rectangle(0, 0, rect.Width, 30);
                g.FillRectangle(b, bgRect);
            }

            //Header
            for (var tabIndex = 0; tabIndex <= TabCount - 1; tabIndex++)
            {
                GetTabRect(tabIndex);
                if (tabIndex != SelectedIndex)
                {
                    using (var brush = new SolidBrush(Colors.LightText))
                    {
                        var textRect = new Rectangle(GetTabRect(tabIndex).Location, GetTabRect(tabIndex).Size);
                        var format = new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center,
                            FormatFlags = StringFormatFlags.NoWrap,
                            Trimming = StringTrimming.EllipsisCharacter
                        };
                        g.DrawString(TabPages[tabIndex].Text, Font, brush, textRect, format);
                    }
                }
            }

            //Draw Border rectangle
            g.FillRectangle(new SolidBrush(bgColor), new Rectangle(0, 30, Width, Height - 24));

            for (var itemIndex = 0; itemIndex <= TabCount - 1; itemIndex++)
            {
                var itemBoundsRect = GetTabRect(itemIndex);
                if (itemIndex == SelectedIndex)
                {
                    // Background Selected Tab
                    g.FillPath(new SolidBrush(Colors.GreySelection),
                        RoundRectangle.RoundedTopRect(new Rectangle(new Point(itemBoundsRect.X - 1, itemBoundsRect.Y - 1), new Size(itemBoundsRect.Width + 1, itemBoundsRect.Height))));

                    // Border Selected Tab
                    using (var p = new Pen(darkColor))
                    {
                        g.DrawPath(p, RoundRectangle.RoundedTopRect(new Rectangle(new Point(itemBoundsRect.X - 1, itemBoundsRect.Y),
                                new Size(itemBoundsRect.Width + 1, itemBoundsRect.Height - 2))));
                    }

                    try
                    {
                        g.DrawString(TabPages[itemIndex].Text,
                            new Font(Font.Name, Font.Size, FontStyle.Regular),
                            new SolidBrush(Colors.LightText), new Rectangle(GetTabRect(itemIndex).Location, GetTabRect(itemIndex).Size), new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        TabPages[itemIndex].BackColor = bgColor;
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            //Draw Border
            using (var p = new Pen(darkColor, 1))
            {
                var modRect = new Rectangle(rect.Left + 1, rect.Top, rect.Width - 3, 30);
                g.DrawRectangle(p, modRect);
            }
            using (var p = new Pen(lightColor, 1))
            {
                var modRect = new Rectangle(rect.Left, rect.Top + 1, rect.Width - 1, 30 + 1);
                g.DrawRectangle(p, modRect);
            }

            using (var p = new Pen(darkColor, 1))
            {
                var modRect = new Rectangle(rect.Left + 1, rect.Top + 31, rect.Width - 3, rect.Height - 33);
                g.DrawRectangle(p, modRect);
            }

            using (var p = new Pen(lightColor, 1))
            {
                var modRect = new Rectangle(rect.Left, rect.Top + 30, rect.Width - 1, rect.Height - 31);
                g.DrawRectangle(p, modRect);
            }
        }
    }
}
