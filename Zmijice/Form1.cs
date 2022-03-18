using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmijice
{
    public partial class forma : Form
    {
        int dimenzije = 10;
        SolidBrush brush;
        Graphics g;
        public forma()
        {
            InitializeComponent();
        }
        List<Rectangle> zmija;

        private void timer_Tick(object sender, EventArgs e)
        {
            Nacrtaj();
        }

        private void forma_Load(object sender, EventArgs e)
        {
            zmija = new List<Rectangle>();
            int x = tabla.Width / 2 - dimenzije / 2;
            int y = tabla.Height / 2 - dimenzije / 2;
            Rectangle glava = new Rectangle(x, y, dimenzije, dimenzije);
            zmija.Add(glava);
            brush = new SolidBrush(Color.Black);
            g = tabla.CreateGraphics();
            Nacrtaj();
            //timer.Start();
        }

        private void Nacrtaj()
        {
            tabla.Refresh();
            foreach (Rectangle deo in zmija)
                g.FillRectangle(brush, deo);
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Hide();
            Nacrtaj();
        }

        private void tabla_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KLIK");
        }
    }
}
