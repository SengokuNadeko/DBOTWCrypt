using System.Drawing;
using System.Drawing.Drawing2D;

namespace DarkUI.Extensions
{
    public static class RoundRectangle
    {
        public static GraphicsPath RoundedTopRect(Rectangle Rectangle)
        {
            var p = new GraphicsPath();
            p.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, 1, 1), -180, 90);
            p.AddArc(new Rectangle(Rectangle.Width - 1 + Rectangle.X, Rectangle.Y, 1, 1), -90, 90);
            p.AddLine(new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + 1), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height - 1));
            p.AddLine(new Point(Rectangle.X, Rectangle.Height - 1 + Rectangle.Y), new Point(Rectangle.X, Rectangle.Y));
            return p;
        }
    }
}