using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QLBG
{
    internal class RoundedPanel : Panel
    {
        private int topLeft, topRight, bottomRight, bottomLeft;
        private int borderWidth;
        private Color borderColor;

        public int BorderWidth
        {
            get => borderWidth;
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int TopLeft
        {
            get => topLeft;
            set
            {
                topLeft = value;
                Invalidate();
            }
        }

        public int TopRight
        {
            get => topRight;
            set
            {
                topRight = value;
                Invalidate();
            }
        }

        public int BottomRight
        {
            get => bottomRight;
            set
            {
                bottomRight = value;
                Invalidate();
            }
        }

        public int BottomLeft
        {
            get => bottomLeft;
            set
            {
                bottomLeft = value;
                Invalidate();
            }
        }

        public RoundedPanel()
        {
            TopLeft = TopRight = BottomLeft = BottomRight = 20;
            BorderWidth = 1;
            BorderColor = Color.Silver;
            this.Size = new Size(200, 200);
            this.BackColor = Color.White;
            this.ForeColor = Color.White;
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float gap)
        {
            GraphicsPath path = new GraphicsPath();

            if (TopLeft > 0)
                path.AddArc(rect.X, rect.Y, TopLeft - gap, TopLeft - gap, 180, 90);
            else
                path.AddLine(rect.X, rect.Y, rect.X, rect.Y);

            if (TopRight > 0)
                path.AddArc(rect.Right - TopRight + gap, rect.Y, TopRight - gap, TopRight - gap, 270, 90);
            else
                path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);

            if (BottomRight > 0)
                path.AddArc(rect.Right - BottomRight + gap, rect.Bottom - BottomRight + gap, BottomRight - gap, BottomRight - gap, 0, 90);
            else
                path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);

            if (BottomLeft > 0)
                path.AddArc(rect.X, rect.Bottom - BottomLeft + gap, BottomLeft - gap, BottomLeft - gap, 90, 90);
            else
                path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);

            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(BorderWidth / 2.0F, BorderWidth / 2.0F, this.Width - BorderWidth, this.Height - BorderWidth);

            if (TopLeft > 0 || TopRight > 0 || BottomLeft > 0 || BottomRight > 0)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, 0F))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, 1F))
                using (Pen penSurface = new Pen(this.BackColor, 1))
                using (Pen penBorder = new Pen(borderColor, borderWidth))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);

                    e.Graphics.DrawPath(penSurface, pathSurface);
                    if (borderWidth > 0)
                        e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderWidth > 0)
                {
                    using (Pen penBorder = new Pen(borderColor, borderWidth))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged += Container_BackColorChanged;
            }
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            if (DesignMode)
            {
                this.Invalidate();
            }
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}
