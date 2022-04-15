using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pen circlePen = new Pen(Color.Black, 2);
        Pen linePen = new Pen(Color.Black, 5);
        Label[] brojevi;
        int sati = 0, minuti = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            brojevi = new Label[] {
                label3,
                label2,
                label1,
                label12,
                label11,
                label10,
                label9,
                label8,
                label7,
                label6,
                label5,
                label4
            };
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = Math.Min(this.ClientRectangle.Width, this.ClientRectangle.Height) - 20;
            int r = d / 2;
            int C = r + 10;
            g.DrawEllipse(circlePen, 10, 10, d, d);
            for(int i = 0; i < 12; i++)
            {
                brojevi[i].Left = (int)Math.Round(C + Math.Cos(i * Math.PI / 6) * r - brojevi[i].Width / 2);
                brojevi[i].Top = (int)Math.Round(C - Math.Sin(i * Math.PI / 6) * r - brojevi[i].Height / 2);
            }
            double stepeni6 = Math.PI / 30;
            double stepeni90 = Math.PI / 2;
            double sinM = Math.Sin(stepeni90 - (minuti * stepeni6));
            double cosM = Math.Cos(stepeni90 - (minuti * stepeni6));
            double sinH = Math.Sin(stepeni90 - (sati * stepeni6));
            double cosH = Math.Cos(stepeni90 - (sati * stepeni6));
            int dxMV = (int)Math.Round(cosM * (r - 10));
            int dyMV = (int)Math.Round(sinM * (r - 10));
            int dxMM = (int)Math.Round(cosM * r / 10);
            int dyMM = (int)Math.Round(sinM * r / 10);
            int dxHV = (int)Math.Round(cosH * (r - 10) * 3 / 4);
            int dyHV = (int)Math.Round(sinH * (r - 10) * 3 / 4);
            int dxHM = (int)Math.Round(cosH * r / 10);
            int dyHM = (int)Math.Round(sinH * r / 10);
            Point M1 = new Point(C + dxMV, C - dyMV);
            Point M2 = new Point(C - dxMM, C + dyMM);
            Point H1 = new Point(C + dxHV, C - dyHV);
            Point H2 = new Point(C - dxHM, C + dyHM);
            g.DrawLine(linePen, M1, M2);
            g.DrawLine(linePen, H1, H2);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            minuti++;
            sati += minuti / 60;
            minuti %= 60;
            this.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

    }
}
