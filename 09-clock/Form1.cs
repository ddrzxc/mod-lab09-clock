namespace _09_clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            g.TranslateTransform(w / 2, h / 2);
            DateTime now = DateTime.Now;
            Text = now.ToLongTimeString();
            int c = Math.Min(w, h) - 10;
            Pen black3 = new Pen(Color.Black, 3);
            Pen black5 = new Pen(Color.Black, 5);
            g.DrawEllipse(black5, -c / 2, -c / 2, c, c);
            double alpha = 0;
            for (int i = 0; i < 60; i++)
            {
                alpha = i * 6 * Math.PI / 180;
                int s = (i % 5 == 0) ? 24 : 12;
                int x1 = Convert.ToInt32((c / 2 - s) * Math.Cos(alpha)), y1 = Convert.ToInt32((c / 2 - s) * Math.Sin(alpha));
                int x2 = Convert.ToInt32((c / 2) * Math.Cos(alpha)), y2 = Convert.ToInt32((c / 2) * Math.Sin(alpha));
                g.DrawLine(black3, x1, y1, x2, y2);
            }
            for (int i = 1; i <= 12; i++)
            {
                alpha = i * 30 * Math.PI / 180 - Math.PI / 2;
                Font font = new Font(Font.FontFamily, 18);
                SizeF ts = g.MeasureString(i.ToString(), font);
                int x = Convert.ToInt32((c / 2 - 40) * Math.Cos(alpha));
                int y = Convert.ToInt32((c / 2 - 40) * Math.Sin(alpha));
                g.DrawString(i.ToString(), font, Brushes.DarkRed, x - ts.Width/2, y - ts.Height/2);
            }
            g.RotateTransform(-90);
            Pen blue5 = new Pen(Color.Blue, 5);
            alpha = now.Second * 6 * Math.PI / 180;
            g.DrawLine(black3, 0, 0, (float)(0.4 * c * Math.Cos(alpha)), (float)(0.4 * c * Math.Sin(alpha)));
            alpha = (now.Minute * 6 + now.Second / 10.0) * Math.PI / 180;
            g.DrawLine(blue5, 0, 0, (float)(0.35 * c * Math.Cos(alpha)), (float)(0.35 * c * Math.Sin(alpha)));
            alpha = (now.Hour * 30 + now.Minute / 2.0) * Math.PI / 180;
            g.DrawLine(blue5, 0, 0, (float)(0.22 * c * Math.Cos(alpha)), (float)(0.22 * c * Math.Sin(alpha)));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
