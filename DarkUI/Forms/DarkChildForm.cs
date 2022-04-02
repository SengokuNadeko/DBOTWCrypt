using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DarkUI.Forms
{

    // ColorStyle kan weg...
    public enum ColorStyle
    {
        // Token: 0x0400002B RID: 43
        Solid,
        // Token: 0x0400002C RID: 44
        HorizontalGradient,
        // Token: 0x0400002D RID: 45
        VerticalGradient,
        // Token: 0x0400002E RID: 46
        ForwardDiagonalGradient,
        // Token: 0x0400002F RID: 47
        BackwardDiagonalGradient
    }


    // Token: 0x02000002 RID: 2
    [DesignerCategory("Form")]
    [DesignTimeVisible(false)]
    [DefaultEvent("Load")]
    [ToolboxItem(false)]
    [Designer(typeof(DarkChildForm), typeof(IRootDesigner))]
    public partial class DarkChildForm : Form
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
        public DarkChildForm()
        {
            this.InitializeComponent();
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.Selectable, true);
            base.SetStyle(ControlStyles.StandardClick, true);
            base.SetStyle(ControlStyles.StandardDoubleClick, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.Opaque, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            base.UpdateStyles();
            this.hiddenForm = new Form();
            this.hiddenForm.Width = 1;
            this.hiddenForm.Height = 1;
            this.hiddenForm.StartPosition = FormStartPosition.Manual;
            this.hiddenForm.Top = 0;
            this.hiddenForm.Left = 0;
            this.hiddenForm.BackColor = this.transparentColor;
            this.hiddenForm.TransparencyKey = this.transparentColor;
            this.hiddenForm.FormBorderStyle = FormBorderStyle.None;
            this.hiddenForm.ShowInTaskbar = false;
        }

		// Token: 0x06000002 RID: 2 RVA: 0x000022AC File Offset: 0x000012AC
		private void InitializeComponent()
		{
			this.AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(304, 272);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "GoogleTalkForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Form1";
			base.Disposed += this.OnDisposed;
		}

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000003 RID: 3 RVA: 0x0000231C File Offset: 0x0000131C
        // (set) Token: 0x06000004 RID: 4 RVA: 0x00002334 File Offset: 0x00001334
        public bool IsWindowSnappable
        {
            get
            {
                return this.isWindowSnappable;
            }
            set
            {
                this.isWindowSnappable = value;
            }
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000005 RID: 5 RVA: 0x00002340 File Offset: 0x00001340
        // (set) Token: 0x06000006 RID: 6 RVA: 0x00002358 File Offset: 0x00001358
        public bool IsResizable
        {
            get
            {
                return this.isResizable;
            }
            set
            {
                if (this.isResizable != value)
                {
                    base.Invalidate();
                }
                this.isResizable = value;
            }
        }

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000007 RID: 7 RVA: 0x00002384 File Offset: 0x00001384
        // (set) Token: 0x06000008 RID: 8 RVA: 0x0000239C File Offset: 0x0000139C
        public Color ResizableColor
        {
            get
            {
                return this.resizableColor;
            }
            set
            {
                this.resizableColor = value;
            }
        }

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x06000009 RID: 9 RVA: 0x000023A8 File Offset: 0x000013A8
        // (set) Token: 0x0600000A RID: 10 RVA: 0x000023C0 File Offset: 0x000013C0
        public Color TitleColor
        {
            get
            {
                return this.titleColor;
            }
            set
            {
                this.titleColor = value;
            }
        }

        // Token: 0x17000005 RID: 5
        // (get) Token: 0x0600000B RID: 11 RVA: 0x000023CC File Offset: 0x000013CC
        // (set) Token: 0x0600000C RID: 12 RVA: 0x000023E4 File Offset: 0x000013E4
        public Font TitleFont
        {
            get
            {
                return this.titleFont;
            }
            set
            {
                this.titleFont = value;
            }
        }

        // Token: 0x17000006 RID: 6
        // (get) Token: 0x0600000D RID: 13 RVA: 0x000023F0 File Offset: 0x000013F0
        // (set) Token: 0x0600000E RID: 14 RVA: 0x00002408 File Offset: 0x00001408
        public Color TitleBackColor
        {
            get
            {
                return this.titleBackColor;
            }
            set
            {
                this.titleBackColor = value;
            }
        }

        // Token: 0x17000007 RID: 7
        // (get) Token: 0x0600000F RID: 15 RVA: 0x00002414 File Offset: 0x00001414
        // (set) Token: 0x06000010 RID: 16 RVA: 0x0000242C File Offset: 0x0000142C
        public Color TitleForeColor
        {
            get
            {
                return this.titleForeColor;
            }
            set
            {
                this.titleForeColor = value;
            }
        }

        // Token: 0x17000008 RID: 8
        // (get) Token: 0x06000011 RID: 17 RVA: 0x00002438 File Offset: 0x00001438
        // (set) Token: 0x06000012 RID: 18 RVA: 0x00002450 File Offset: 0x00001450
        public ColorStyle TitleStyle
        {
            get
            {
                return this.titleStyle;
            }
            set
            {
                this.titleStyle = value;
            }
        }

        // Token: 0x17000009 RID: 9
        // (get) Token: 0x06000013 RID: 19 RVA: 0x0000245C File Offset: 0x0000145C
        // (set) Token: 0x06000014 RID: 20 RVA: 0x00002474 File Offset: 0x00001474
        public Color BodyBackColor
        {
            get
            {
                return this.bodyBackColor;
            }
            set
            {
                this.bodyBackColor = value;
            }
        }

        // Token: 0x1700000A RID: 10
        // (get) Token: 0x06000015 RID: 21 RVA: 0x00002480 File Offset: 0x00001480
        // (set) Token: 0x06000016 RID: 22 RVA: 0x00002498 File Offset: 0x00001498
        public Color BodyForeColor
        {
            get
            {
                return this.bodyForeColor;
            }
            set
            {
                this.bodyForeColor = value;
            }
        }

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x06000017 RID: 23 RVA: 0x000024A4 File Offset: 0x000014A4
        // (set) Token: 0x06000018 RID: 24 RVA: 0x000024BC File Offset: 0x000014BC
        public ColorStyle BodyStyle
        {
            get
            {
                return this.bodyStyle;
            }
            set
            {
                this.bodyStyle = value;
            }
        }

        // Token: 0x1700000C RID: 12
        // (get) Token: 0x06000019 RID: 25 RVA: 0x000024C8 File Offset: 0x000014C8
        // (set) Token: 0x0600001A RID: 26 RVA: 0x000024E0 File Offset: 0x000014E0
        public Color OutlineColor
        {
            get
            {
                return this.outlineColor;
            }
            set
            {
                this.outlineColor = value;
            }
        }

        // Token: 0x1700000D RID: 13
        // (get) Token: 0x0600001B RID: 27 RVA: 0x000024EC File Offset: 0x000014EC
        // (set) Token: 0x0600001C RID: 28 RVA: 0x00002504 File Offset: 0x00001504
        public int OutlineSize
        {
            get
            {
                return this.outlineSize;
            }
            set
            {
                this.outlineSize = value;
            }
        }

        // Token: 0x1700000E RID: 14
        // (get) Token: 0x0600001D RID: 29 RVA: 0x00002510 File Offset: 0x00001510
        // (set) Token: 0x0600001E RID: 30 RVA: 0x00002528 File Offset: 0x00001528
        public Color IconsNormalColor
        {
            get
            {
                return this.iconsNormalColor;
            }
            set
            {
                this.iconsNormalColor = value;
            }
        }

        // Token: 0x1700000F RID: 15
        // (get) Token: 0x0600001F RID: 31 RVA: 0x00002534 File Offset: 0x00001534
        // (set) Token: 0x06000020 RID: 32 RVA: 0x0000254C File Offset: 0x0000154C
        public Color IconsHiLiteColor
        {
            get
            {
                return this.iconsHiLiteColor;
            }
            set
            {
                this.iconsHiLiteColor = value;
            }
        }

        // Token: 0x17000010 RID: 16
        // (get) Token: 0x06000021 RID: 33 RVA: 0x00002558 File Offset: 0x00001558
        // (set) Token: 0x06000022 RID: 34 RVA: 0x00002570 File Offset: 0x00001570
        public int MinimumHeight
        {
            get
            {
                return this.minimumHeight;
            }
            set
            {
                this.minimumHeight = value;
            }
        }

        // Token: 0x17000011 RID: 17
        // (get) Token: 0x06000023 RID: 35 RVA: 0x0000257C File Offset: 0x0000157C
        // (set) Token: 0x06000024 RID: 36 RVA: 0x00002594 File Offset: 0x00001594
        public int MinimumWidth
        {
            get
            {
                return this.minimumWidth;
            }
            set
            {
                this.minimumWidth = value;
            }
        }

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x06000025 RID: 37 RVA: 0x000025A0 File Offset: 0x000015A0
        public Rectangle BodyRectangle
        {
            get
            {
                return this.rectBody;
            }
        }

        // Token: 0x17000013 RID: 19
        // (get) Token: 0x06000026 RID: 38 RVA: 0x000025B8 File Offset: 0x000015B8
        public Rectangle ResizableRectangle
        {
            get
            {
                return this.rectResizableArea;
            }
        }

        // Token: 0x17000014 RID: 20
        // (get) Token: 0x06000027 RID: 39 RVA: 0x000025D0 File Offset: 0x000015D0
        private bool mouseInTitleArea
        {
            get
            {
                return this.isMousePointerInArea(Control.MousePosition, this.rectTitleArea);
            }
        }

        // Token: 0x17000015 RID: 21
        // (get) Token: 0x06000028 RID: 40 RVA: 0x000025F4 File Offset: 0x000015F4
        private bool mouseInResizeArea
        {
            get
            {
                return this.isMousePointerInArea(Control.MousePosition, this.rectResizableArea);
            }
        }

        // Token: 0x17000016 RID: 22
        // (get) Token: 0x06000029 RID: 41 RVA: 0x00002618 File Offset: 0x00001618
        private bool mouseInCloseIconArea
        {
            get
            {
                return this.isMousePointerInArea(Control.MousePosition, this.rectCloseIcon);
            }
        }

        // Token: 0x17000017 RID: 23
        // (get) Token: 0x0600002A RID: 42 RVA: 0x0000263C File Offset: 0x0000163C
        private bool mouseInMinimizeIconArea
        {
            get
            {
                return this.isMousePointerInArea(Control.MousePosition, this.rectMinimizeIcon);
            }
        }

        // Token: 0x0600002B RID: 43 RVA: 0x00002660 File Offset: 0x00001660
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush bGradient = null;
            Bitmap bmp = new Bitmap(base.Width, base.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.High;
            SolidBrush bSolid = new SolidBrush(this.transparentColor);
            g.FillRectangle(bSolid, 0, 0, base.Width, base.Height);
            bSolid.Dispose();
            Rectangle rectLeftCorner = new Rectangle(0, 0, 20, 20);
            Rectangle rectRightCorner = new Rectangle(base.Width - 20 - 1, 0, 20, 20);
            Rectangle rectTopArea = new Rectangle(10, 0, base.Width - 20, base.Height);
            Rectangle rectBottomArea = new Rectangle(0, 10, base.Width, base.Height);
            SizeF sizeTitleText = g.MeasureString(this.Text, this.TitleFont);
            Size sizeTitleBar = new Size(0, 0);
            sizeTitleBar.Width = base.Width;
            sizeTitleBar.Height = Convert.ToInt32(sizeTitleText.Height) + 6;
            if (base.Icon != null && sizeTitleBar.Height < 22)
            {
                sizeTitleBar.Height = 22;
            }
            Size sizeTitleBody = new Size(0, 0);
            sizeTitleBody.Width = base.Width;
            sizeTitleBody.Height = base.Height - sizeTitleBar.Height;
            Rectangle rectTitleBar = new Rectangle(0, 0, sizeTitleBar.Width, sizeTitleBar.Height);
            this.rectBody = new Rectangle(0, sizeTitleBar.Height, sizeTitleBody.Width, sizeTitleBody.Height);
            GraphicsPath gpTitlePath = new GraphicsPath();
            gpTitlePath.AddArc(rectLeftCorner, 180f, 90f);
            gpTitlePath.AddArc(rectRightCorner, 270f, 90f);
            GraphicsPath gTitlePath2 = new GraphicsPath();
            gTitlePath2.AddRectangle(new Rectangle(0, 10, rectTitleBar.Width - 1, rectTitleBar.Height));
            gTitlePath2.AddPath(gpTitlePath, true);
            gTitlePath2.Flatten();
            if (this.TitleStyle == ColorStyle.Solid)
            {
                bSolid = new SolidBrush(this.TitleForeColor);
                g.FillPath(bSolid, gTitlePath2);
                bSolid.Dispose();
            }
            else
            {
                switch (this.TitleStyle)
                {
                    case ColorStyle.HorizontalGradient:
                        bGradient = new LinearGradientBrush(rectTitleBar, this.TitleForeColor, this.TitleBackColor, LinearGradientMode.Horizontal);
                        break;
                    case ColorStyle.VerticalGradient:
                        bGradient = new LinearGradientBrush(rectTitleBar, this.TitleForeColor, this.TitleBackColor, LinearGradientMode.Vertical);
                        break;
                    case ColorStyle.ForwardDiagonalGradient:
                        bGradient = new LinearGradientBrush(rectTitleBar, this.TitleForeColor, this.TitleBackColor, LinearGradientMode.ForwardDiagonal);
                        break;
                    case ColorStyle.BackwardDiagonalGradient:
                        bGradient = new LinearGradientBrush(rectTitleBar, this.TitleForeColor, this.TitleBackColor, LinearGradientMode.BackwardDiagonal);
                        break;
                }
                g.FillPath(bGradient, gTitlePath2);
                bGradient.Dispose();
                bGradient = null;
            }
            bSolid = new SolidBrush(this.TitleColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            sf.Trimming = StringTrimming.None;
            this.rectTitleArea = new Rectangle(0, 0, 0, 0);
            this.rectTitleArea.X = 8;
            this.rectTitleArea.Y = Convert.ToInt32(((float)rectTitleBar.Height - sizeTitleText.Height) / 2f);
            this.rectTitleArea.Width = base.Width - 20 - 3;
            this.rectTitleArea.Height = 3 + Convert.ToInt32(sizeTitleText.Height);
            if (base.Icon != null)
            {
                if (this.bmpIcon == null)
                {
                    this.bmpIcon = base.Icon.ToBitmap();
                }
                Rectangle rectTitleIcon = new Rectangle(0, 0, 0, 0);
                rectTitleIcon.X = 8;
                rectTitleIcon.Y = Convert.ToInt32(((float)rectTitleBar.Height - sizeTitleText.Height) / 2f);
                rectTitleIcon.Width = 16;
                rectTitleIcon.Height = 16;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(this.bmpIcon, rectTitleIcon, 0, 0, 32, 32, GraphicsUnit.Pixel);
                g.SmoothingMode = SmoothingMode.None;
                this.rectTitleArea.X = this.rectTitleArea.X + 16 + 3;
            }
            this.rectCloseIcon = new Rectangle(0, 0, 0, 0);
            this.rectCloseIcon.X = base.Width - 10 - 3 - 16 + 2;
            this.rectCloseIcon.Y = Convert.ToInt32(((float)rectTitleBar.Height - sizeTitleText.Height) / 2f) + 2;
            this.rectCloseIcon.Width = 14;
            this.rectCloseIcon.Height = 14;
            Pen p;
            if (!this.onCloseIcon)
            {
                p = new Pen(this.IconsNormalColor, 1f);
            }
            else
            {
                p = new Pen(this.IconsHiLiteColor, 1f);
            }
            g.DrawLine(p, this.rectCloseIcon.X + 1, this.rectCloseIcon.Y, this.rectCloseIcon.X + this.rectCloseIcon.Width - 1, this.rectCloseIcon.Y);
            g.DrawLine(p, this.rectCloseIcon.X, this.rectCloseIcon.Y + 1, this.rectCloseIcon.X, this.rectCloseIcon.Y + this.rectCloseIcon.Height - 1);
            g.DrawLine(p, this.rectCloseIcon.X + this.rectCloseIcon.Width, this.rectCloseIcon.Y + 1, this.rectCloseIcon.X + this.rectCloseIcon.Width, this.rectCloseIcon.Y + this.rectCloseIcon.Height - 1);
            g.DrawLine(p, this.rectCloseIcon.X + 1, this.rectCloseIcon.Y + this.rectCloseIcon.Height, this.rectCloseIcon.X + this.rectCloseIcon.Width - 1, this.rectCloseIcon.Y + this.rectCloseIcon.Height);
            p.Dispose();
            if (!this.onCloseIcon)
            {
                p = new Pen(this.IconsNormalColor, 2f);
            }
            else
            {
                p = new Pen(this.IconsHiLiteColor, 2f);
            }
            g.DrawLine(p, this.rectCloseIcon.X + 3, this.rectCloseIcon.Y + 3, this.rectCloseIcon.X + this.rectCloseIcon.Width - 3, this.rectCloseIcon.Y + this.rectCloseIcon.Height - 3);
            g.DrawLine(p, this.rectCloseIcon.X + this.rectCloseIcon.Width - 3, this.rectCloseIcon.Y + 3, this.rectCloseIcon.X + 3, this.rectCloseIcon.Y + this.rectCloseIcon.Height - 3);
            this.rectCloseIcon.Width = this.rectCloseIcon.Width + 1;
            this.rectCloseIcon.Height = this.rectCloseIcon.Height + 1;
            this.rectMinimizeIcon = new Rectangle(0, 0, 0, 0);
            this.rectMinimizeIcon.X = base.Width - 10 - 6 - 32 + 2;
            this.rectMinimizeIcon.Y = Convert.ToInt32(((float)rectTitleBar.Height - sizeTitleText.Height) / 2f) + 2;
            this.rectMinimizeIcon.Width = 14;
            this.rectMinimizeIcon.Height = 14;
            if (!this.onMinimizeIcon)
            {
                p = new Pen(this.IconsNormalColor, 1f);
            }
            else
            {
                p = new Pen(this.IconsHiLiteColor, 1f);
            }
            g.DrawLine(p, this.rectMinimizeIcon.X + 1, this.rectMinimizeIcon.Y, this.rectMinimizeIcon.X + this.rectMinimizeIcon.Width - 1, this.rectMinimizeIcon.Y);
            g.DrawLine(p, this.rectMinimizeIcon.X, this.rectMinimizeIcon.Y + 1, this.rectMinimizeIcon.X, this.rectMinimizeIcon.Y + this.rectMinimizeIcon.Height - 1);
            g.DrawLine(p, this.rectMinimizeIcon.X + this.rectMinimizeIcon.Width, this.rectMinimizeIcon.Y + 1, this.rectMinimizeIcon.X + this.rectMinimizeIcon.Width, this.rectMinimizeIcon.Y + this.rectMinimizeIcon.Height - 1);
            g.DrawLine(p, this.rectMinimizeIcon.X + 1, this.rectMinimizeIcon.Y + this.rectMinimizeIcon.Height, this.rectMinimizeIcon.X + this.rectMinimizeIcon.Width - 1, this.rectMinimizeIcon.Y + this.rectMinimizeIcon.Height);
            p.Dispose();
            if (!this.onMinimizeIcon)
            {
                p = new Pen(this.IconsNormalColor, 2f);
            }
            else
            {
                p = new Pen(this.IconsHiLiteColor, 2f);
            }
            g.DrawLine(p, this.rectMinimizeIcon.X + 3, this.rectMinimizeIcon.Y + this.rectMinimizeIcon.Height - 3, this.rectMinimizeIcon.X + this.rectMinimizeIcon.Width - 2, this.rectMinimizeIcon.Y + this.rectMinimizeIcon.Height - 3);
            this.rectMinimizeIcon.Width = this.rectMinimizeIcon.Width + 1;
            this.rectMinimizeIcon.Height = this.rectMinimizeIcon.Height + 1;
            this.rectTitleArea.Width = this.rectTitleArea.Width - 50;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawString(this.Text, this.TitleFont, bSolid, this.rectTitleArea, sf);
            g.SmoothingMode = SmoothingMode.None;
            this.rectTitleArea.X = 0;
            this.rectTitleArea.Y = 0;
            this.rectTitleArea.Width = base.Width;
            sf.Dispose();
            bSolid.Dispose();
            if (this.windowMaximized)
            {
                if (this.BodyStyle == ColorStyle.Solid)
                {
                    bSolid = new SolidBrush(this.BodyForeColor);
                    g.FillRectangle(bSolid, this.rectBody);
                    bSolid.Dispose();
                }
                else
                {
                    switch (this.BodyStyle)
                    {
                        case ColorStyle.HorizontalGradient:
                            bGradient = new LinearGradientBrush(this.rectBody, this.BodyForeColor, this.BodyBackColor, LinearGradientMode.Horizontal);
                            break;
                        case ColorStyle.VerticalGradient:
                            bGradient = new LinearGradientBrush(this.rectBody, this.BodyForeColor, this.BodyBackColor, LinearGradientMode.Vertical);
                            break;
                        case ColorStyle.ForwardDiagonalGradient:
                            bGradient = new LinearGradientBrush(this.rectBody, this.BodyForeColor, this.BodyBackColor, LinearGradientMode.ForwardDiagonal);
                            break;
                        case ColorStyle.BackwardDiagonalGradient:
                            bGradient = new LinearGradientBrush(this.rectBody, this.BodyForeColor, this.BodyBackColor, LinearGradientMode.BackwardDiagonal);
                            break;
                    }
                    g.FillRectangle(bGradient, this.rectBody);
                    bGradient.Dispose();
                }
            }
            if (this.IsResizable && this.windowMaximized)
            {
                this.rectResizableArea = new Rectangle(0, 0, 0, 0);
                this.rectResizableArea.X = base.Width - 3 - 11;
                this.rectResizableArea.Y = base.Height - 3 - 11;
                this.rectResizableArea.Height = 14;
                this.rectResizableArea.Width = 14;
                p = new Pen(this.ResizableColor, 2f);
                g.DrawLine(p, base.Width - 3 - 11, base.Height - 3, base.Width - 3, base.Height - 3 - 11);
                g.DrawLine(p, base.Width - 3 - 7, base.Height - 3, base.Width - 3, base.Height - 3 - 7);
                g.DrawLine(p, base.Width - 3 - 3, base.Height - 3, base.Width - 3, base.Height - 3 - 3);
                p.Dispose();
            }
            p = new Pen(this.OutlineColor, (float)this.OutlineSize);
            g.DrawArc(p, rectLeftCorner, 180f, 90f);
            g.DrawArc(p, rectRightCorner, 270f, 90f);
            g.DrawLine(p, 10, 0, base.Width - 10, 0);
            g.DrawLine(p, 0, 10, 0, base.Height);
            g.DrawLine(p, base.Width - 1, 10, base.Width - 1, base.Height);
            g.DrawLine(p, 0, base.Height - 1, base.Width, base.Height - 1);
            p.Dispose();
            if (base.Region != null)
            {
                base.Region.Dispose();
                base.Region = null;
            }
            GraphicsPath gpRegion = new GraphicsPath();
            for (int x = rectLeftCorner.X; x < rectLeftCorner.Width; x++)
            {
                for (int y = rectLeftCorner.Y; y < rectLeftCorner.Height / 2; y++)
                {
                    if (!isSameColor(bmp.GetPixel(x, y), this.transparentColor))
                    {
                        gpRegion.AddRectangle(new Rectangle(x, y, 1, 1));
                    }
                }
            }
            for (int x = rectRightCorner.X + 1; x < rectRightCorner.X + rectRightCorner.Width + 1; x++)
            {
                for (int y = rectRightCorner.Y; y < rectRightCorner.Y + rectRightCorner.Height / 2; y++)
                {
                    if (!isSameColor(bmp.GetPixel(x, y), this.transparentColor))
                    {
                        gpRegion.AddRectangle(new Rectangle(x, y, 1, 1));
                    }
                }
            }
            gpRegion.AddRectangle(new Rectangle(rectLeftCorner.Width, 0, base.Width - 40, rectLeftCorner.Height / 2));
            gpRegion.AddRectangle(new Rectangle(0, rectLeftCorner.Height / 2, base.Width, base.Height));
            base.Region = new Region(gpRegion);
            e.Graphics.DrawImageUnscaled(bmp, 0, 0, base.Width, base.Height);
            g.Dispose();
            bmp.Dispose();
        }

        // Token: 0x0600002C RID: 44 RVA: 0x0000354C File Offset: 0x0000254C
        private void OnDisposed(object sender, EventArgs e)
        {
            this.isDisposing = true;
        }

        // Token: 0x0600002D RID: 45 RVA: 0x00003558 File Offset: 0x00002558
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDown = true;
                this.mousePosition = Control.MousePosition;
            }
        }

        // Token: 0x0600002E RID: 46 RVA: 0x00003590 File Offset: 0x00002590
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDown = false;
                this.windowMoving = false;
                this.windowResizing = false;
                if (this.mouseInCloseIconArea)
                {
                    base.Close();
                }
                if (this.mouseInMinimizeIconArea)
                {
                    this.onMinimizeIcon = false;
                    base.Region = null;
                    base.WindowState = FormWindowState.Minimized;
                }
            }
        }

        // Token: 0x0600002F RID: 47 RVA: 0x00003604 File Offset: 0x00002604
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point currentMousePosition = Control.MousePosition;
            if (this.mouseDown)
            {
                if (this.mouseInTitleArea || this.windowMoving)
                {
                    int x = currentMousePosition.X - this.mousePosition.X + base.Location.X;
                    int y = currentMousePosition.Y - this.mousePosition.Y + base.Location.Y;
                    if (this.IsWindowSnappable)
                    {
                        if (this.snapHitTest(x, 0))
                        {
                            x = 0;
                        }
                        else if (this.snapHitTest(x + base.Width, base.ClientRectangle.Width))
                        {
                            x = base.ClientRectangle.Width - base.Width;
                        }
                        else if (this.snapHitTest(x + base.Width, Screen.PrimaryScreen.WorkingArea.Width))
                        {
                            x = Screen.PrimaryScreen.WorkingArea.Width - base.Width;
                        }
                        else if (base.MdiParent != null && this.snapHitTest(x + base.Width, base.MdiParent.ClientRectangle.Width - 4))
                        {
                            x = base.MdiParent.ClientRectangle.Width - base.Width - 4;
                        }
                        if (this.snapHitTest(y, 0))
                        {
                            y = 0;
                        }
                        else if (this.snapHitTest(y + base.Height, base.ClientRectangle.Height))
                        {
                            y = base.ClientRectangle.Height - base.Height;
                        }
                        else if (this.snapHitTest(y + base.Height, Screen.PrimaryScreen.WorkingArea.Height))
                        {
                            y = Screen.PrimaryScreen.WorkingArea.Height - base.Height;
                        }
                        else if (base.MdiParent != null && this.snapHitTest(y + base.Height, base.MdiParent.ClientRectangle.Height - 4))
                        {
                            y = base.MdiParent.ClientRectangle.Height - base.Height - 4;
                        }
                    }
                    base.Location = new Point(x, y);
                    this.mousePosition = currentMousePosition;
                    this.windowMoving = true;
                }
                else if ((this.mouseInResizeArea || this.windowResizing) && this.IsResizable)
                {
                    int width = currentMousePosition.X - this.mousePosition.X + base.Size.Width;
                    int height = currentMousePosition.Y - this.mousePosition.Y + base.Size.Height;
                    if (width < this.MinimumWidth)
                    {
                        width = this.MinimumWidth;
                        this.windowResizing = false;
                    }
                    else if (height < this.MinimumHeight)
                    {
                        height = this.MinimumHeight;
                        this.windowResizing = false;
                    }
                    else
                    {
                        this.windowResizing = true;
                    }
                    base.Size = new Size(width, height);
                    this.mousePosition = currentMousePosition;
                }
            }
            else
            {
                if (this.mouseInResizeArea && this.IsResizable)
                {
                    this.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                }
                if (this.mouseInCloseIconArea)
                {
                    this.onCloseIcon = true;
                    base.Invalidate(this.rectCloseIcon, false);
                }
                else
                {
                    if (this.onCloseIcon)
                    {
                        base.Invalidate(this.rectCloseIcon, false);
                    }
                    this.onCloseIcon = false;
                }
                if (this.mouseInMinimizeIconArea)
                {
                    this.onMinimizeIcon = true;
                    base.Invalidate(this.rectMinimizeIcon, false);
                }
                else
                {
                    if (this.onMinimizeIcon)
                    {
                        base.Invalidate(this.rectMinimizeIcon, false);
                    }
                    this.onMinimizeIcon = false;
                }
            }
        }

        // Token: 0x06000030 RID: 48 RVA: 0x00003A68 File Offset: 0x00002A68
        protected override void OnDoubleClick(EventArgs e)
        {
            if (this.mouseInTitleArea)
            {
                if (!this.mouseInCloseIconArea)
                {
                    if (!this.mouseInMinimizeIconArea)
                    {
                        if (this.windowMaximized)
                        {
                            this.windowMaximized = false;
                            this.windowHeight = base.Height;
                            base.Height = this.rectTitleArea.Height + 3;
                        }
                        else
                        {
                            this.windowMaximized = true;
                            base.Height = this.windowHeight;
                        }
                    }
                }
            }
        }

        // Token: 0x06000031 RID: 49 RVA: 0x00003AF8 File Offset: 0x00002AF8
        private void OnMenuMeasureItem(object sender, MeasureItemEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item.Text == "-")
            {
                e.ItemHeight = 4;
            }
            else
            {
                e.ItemHeight = 18;
                e.ItemWidth = Convert.ToInt32(e.Graphics.MeasureString(item.Text, this.Font).Width) + 30;
            }
        }

        // Token: 0x06000032 RID: 50 RVA: 0x00003B69 File Offset: 0x00002B69
        private void OnMenuSeperatorDrawItem(object sender, DrawItemEventArgs e)
        {
            this.drawMenuItem((MenuItem)sender, e);
        }

        // Token: 0x06000033 RID: 51 RVA: 0x00003B7A File Offset: 0x00002B7A
        private void OnMenuRestoreClick(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Normal;
        }

        // Token: 0x06000034 RID: 52 RVA: 0x00003B88 File Offset: 0x00002B88
        private void OnMenuRestoreDrawItem(object sender, DrawItemEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            this.drawMenuItem(item, e);
            this.drawMenuIcon("StyledForms.restore.png", e);
        }

        // Token: 0x06000035 RID: 53 RVA: 0x00003BB3 File Offset: 0x00002BB3
        private void OnMenuMaximizeClick(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Maximized;
        }

        // Token: 0x06000036 RID: 54 RVA: 0x00003BC0 File Offset: 0x00002BC0
        private void OnMenuMaximizeDrawItem(object sender, DrawItemEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            this.drawMenuItem(item, e);
            this.drawMenuIcon("StyledForms.maximize.png", e);
        }

        // Token: 0x06000037 RID: 55 RVA: 0x00003BEB File Offset: 0x00002BEB
        private void OnMenuCloseClick(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000038 RID: 56 RVA: 0x00003BF8 File Offset: 0x00002BF8
        private void OnMenuCloseDrawItem(object sender, DrawItemEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            this.drawMenuItem(item, e);
            this.drawMenuIcon("StyledForms.close.png", e);
        }

        // Token: 0x06000039 RID: 57 RVA: 0x00003C24 File Offset: 0x00002C24
        protected override void WndProc(ref Message m)
        {
            int num = m.Msg;
            if (num == 787)
            {
                Point position = new Point(0);
                position.Y = Convert.ToInt32(m.LParam.ToInt64() >> 16);
                position.X = Convert.ToInt32(m.LParam.ToInt64() & 65535L);
                this.hiddenForm.Show();
                ContextMenu menu = this.createContextMenu();
                menu.Show(this.hiddenForm, position);
                this.hiddenForm.Hide();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        // Token: 0x0600003A RID: 58 RVA: 0x00003CCC File Offset: 0x00002CCC
        private bool isMousePointerInArea(Point mousePosition, Rectangle area)
        {
            return !this.isDisposing && area.Contains(base.PointToClient(mousePosition));
        }

        // Token: 0x0600003B RID: 59 RVA: 0x00003CFC File Offset: 0x00002CFC
        private bool snapHitTest(int value, int snapValue)
        {
            return value > snapValue - 5 && value < snapValue + 5;
        }

        // Token: 0x0600003C RID: 60 RVA: 0x00003D2C File Offset: 0x00002D2C
        private static bool isSameColor(Color color1, Color color2)
        {
            return color1.A == color2.A && color1.B == color2.B && color1.G == color2.G && color1.R == color2.R;
        }

        // Token: 0x0600003D RID: 61 RVA: 0x00003DA4 File Offset: 0x00002DA4
        private ContextMenu createContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Text = "Restore";
            item.Visible = false;
            item.OwnerDraw = true;
            item.DrawItem += this.OnMenuRestoreDrawItem;
            item.MeasureItem += this.OnMenuMeasureItem;
            item.Click += this.OnMenuRestoreClick;
            menu.MenuItems.Add(item);
            if (base.WindowState == FormWindowState.Minimized)
            {
                item.Visible = true;
            }
            item = new MenuItem();
            item.Text = "Maximize";
            item.OwnerDraw = true;
            item.DrawItem += this.OnMenuMaximizeDrawItem;
            item.MeasureItem += this.OnMenuMeasureItem;
            item.Click += this.OnMenuMaximizeClick;
            menu.MenuItems.Add(item);
            item = new MenuItem();
            item.Text = "-";
            item.OwnerDraw = true;
            item.DrawItem += this.OnMenuSeperatorDrawItem;
            item.MeasureItem += this.OnMenuMeasureItem;
            menu.MenuItems.Add(item);
            item = new MenuItem();
            item.Text = "Close";
            item.OwnerDraw = true;
            item.DrawItem += this.OnMenuCloseDrawItem;
            item.MeasureItem += this.OnMenuMeasureItem;
            item.Click += this.OnMenuCloseClick;
            menu.MenuItems.Add(item);
            if (this.RightToLeft == RightToLeft.Yes)
            {
                menu.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                menu.RightToLeft = RightToLeft.No;
            }
            return menu;
        }

        // Token: 0x0600003E RID: 62 RVA: 0x00003F70 File Offset: 0x00002F70
        private void drawMenuItem(MenuItem item, DrawItemEventArgs e)
        {
            SolidBrush b = new SolidBrush(Color.FromArgb(214, 211, 206));
            e.Graphics.FillRectangle(b, e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 1, e.Bounds.Height + 1);
            b.Dispose();
            if (item.Text == "-")
            {
                Pen p = new Pen(Color.FromArgb(132, 130, 132), 1f);
                e.Graphics.DrawLine(p, e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width + 1, e.Bounds.Y + 1);
                p.Dispose();
                p = new Pen(Color.White, 1f);
                e.Graphics.DrawLine(p, e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width + 1, e.Bounds.Y + 2);
                p.Dispose();
            }
            if (item.Text != "=")
            {
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                {
                    b = new SolidBrush(Color.FromArgb(8, 36, 107));
                    e.Graphics.FillRectangle(b, e.Bounds);
                    b.Dispose();
                    b = new SolidBrush(Color.White);
                    e.Graphics.DrawString(item.Text, e.Font, b, (float)(e.Bounds.X + 22), (float)(e.Bounds.Y + 2));
                    b.Dispose();
                }
                else
                {
                    b = new SolidBrush(Color.Black);
                    e.Graphics.DrawString(item.Text, e.Font, b, (float)(e.Bounds.X + 22), (float)(e.Bounds.Y + 2));
                    b.Dispose();
                }
            }
        }

        // Token: 0x0600003F RID: 63 RVA: 0x000041E4 File Offset: 0x000031E4
        private void drawMenuIcon(string iconPath, DrawItemEventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = null;
            Bitmap bmp = null;
            try
            {
                stream = assembly.GetManifestResourceStream(iconPath);
                stream.Position = 0L;
                bmp = (Bitmap)Image.FromStream(stream);
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            if (isSameColor(bmp.GetPixel(x, y), Color.Black))
                            {
                                bmp.SetPixel(x, y, Color.White);
                            }
                        }
                    }
                }
                e.Graphics.DrawImageUnscaled(bmp, e.Bounds.X, e.Bounds.Y + 2);
            }
            finally
            {
                if (bmp != null)
                {
                    bmp.Dispose();
                    bmp = null;
                }
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
            }
        }

        // Token: 0x06000040 RID: 64 RVA: 0x000042FC File Offset: 0x000032FC
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        // Token: 0x04000001 RID: 1
        private const int edgeRadius = 10;

        // Token: 0x04000002 RID: 2
        private const int padding = 3;

        // Token: 0x04000003 RID: 3
        private const int snapPixels = 5;

        // Token: 0x04000004 RID: 4
        private Color transparentColor = Color.Pink;

        // Token: 0x04000005 RID: 5
        private bool mouseDown = false;

        // Token: 0x04000006 RID: 6
        private bool windowMoving = false;

        // Token: 0x04000007 RID: 7
        private bool windowResizing = false;

        // Token: 0x04000008 RID: 8
        private bool windowMaximized = true;

        // Token: 0x04000009 RID: 9
        private bool onCloseIcon = false;

        // Token: 0x0400000A RID: 10
        private bool onMinimizeIcon = false;

        // Token: 0x0400000B RID: 11
        private int windowHeight;

        // Token: 0x0400000C RID: 12
        private Form hiddenForm = null;

        // Token: 0x0400000D RID: 13
        private Bitmap bmpIcon = null;

        // Token: 0x0400000E RID: 14
        private Point mousePosition;

        // Token: 0x0400000F RID: 15
        private Rectangle rectTitleArea;

        // Token: 0x04000010 RID: 16
        private Rectangle rectBody;

        // Token: 0x04000011 RID: 17
        private Rectangle rectCloseIcon;

        // Token: 0x04000012 RID: 18
        private Rectangle rectMinimizeIcon;

        // Token: 0x04000013 RID: 19
        private Rectangle rectResizableArea;

        // Token: 0x04000014 RID: 20
        private bool isDisposing = false;

        // Token: 0x04000015 RID: 21
        private Container components = null;

        // Token: 0x04000016 RID: 22
        private bool isWindowSnappable = true;

        // Token: 0x04000017 RID: 23
        private bool isResizable = true;

        // Token: 0x04000018 RID: 24
        private Color resizableColor = Color.LightGray;

        // Token: 0x04000019 RID: 25
        private Color titleColor = Color.FromArgb(16, 48, 107);

        // Token: 0x0400001A RID: 26
        private Font titleFont = new Font("Tahoma", 10f, FontStyle.Bold);

        // Token: 0x0400001B RID: 27
        private Color titleBackColor = Color.FromArgb(206, 211, 222);

        // Token: 0x0400001C RID: 28
        private Color titleForeColor = Color.White;

        // Token: 0x0400001D RID: 29
        private ColorStyle titleStyle = ColorStyle.VerticalGradient;

        // Token: 0x0400001E RID: 30
        private Color bodyBackColor = Color.FromArgb(239, 239, 239);

        // Token: 0x0400001F RID: 31
        private Color bodyForeColor = Color.White;

        // Token: 0x04000020 RID: 32
        private ColorStyle bodyStyle = ColorStyle.BackwardDiagonalGradient;

        // Token: 0x04000021 RID: 33
        private Color outlineColor = Color.FromArgb(148, 150, 148);

        // Token: 0x04000022 RID: 34
        private int outlineSize = 1;

        // Token: 0x04000023 RID: 35
        private Color iconsNormalColor = Color.FromArgb(148, 150, 148);

        // Token: 0x04000024 RID: 36
        private Color iconsHiLiteColor = Color.FromArgb(16, 48, 107);

        // Token: 0x04000025 RID: 37
        private int minimumHeight = 200;

        // Token: 0x04000026 RID: 38
        private int minimumWidth = 200;
    }
}
