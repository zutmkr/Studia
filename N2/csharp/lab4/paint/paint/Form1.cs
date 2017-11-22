using System;
using System.Drawing;
using System.Windows.Forms;


namespace paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics gr_ob;
        Pen p;
        bool mouseIsDown, draw_line = true, draw_rectangle, draw_circle;
        int? initX = null;
        int? initY = null;
        int pressedLocationX;
        int pressedLocationY;
        int releasedLocationX;
        int releasedLocationY;


        private void btn_PenColor_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                btn_PenColor.BackColor = c.Color;
                p.Color = c.Color;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gr_ob.Clear(panel1.BackColor);
            panel1.BackColor = Color.White;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                if (draw_line)
                {
                    gr_ob.DrawLine(p, new Point(initX ?? e.X , initY ?? e.Y), new Point(e.X , e.Y));
                    initX = e.X;
                    initY = e.Y;
                }
                else if (draw_circle)
                {
                    int x = e.X;
                    int y = e.Y;
                    Rectangle rectangle = new Rectangle();
                    PaintEventArgs arg = new PaintEventArgs(gr_ob, rectangle);

                    DrawCircle(arg, x, y, 100, 100);
                }
                else if (draw_rectangle)
                {
                    gr_ob.DrawRectangle(p,
                            Math.Min(pressedLocationX, releasedLocationX), // Left
                            Math.Min(pressedLocationY, releasedLocationY), // Top
                            Math.Abs(releasedLocationX - pressedLocationX), // Width
                            Math.Abs(releasedLocationY - pressedLocationY)); // Height
                }
            }
            
        }

        private void DrawCircle(PaintEventArgs e, int x, int y, int width, int height)
        {
            p = new Pen(Color.Red, 3);
            gr_ob.DrawEllipse(p, x - width / 2, y - height / 2, width, height);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gr_ob = panel1.CreateGraphics();
            p = new Pen(Color.Red, 5);
            //panel1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            draw_line = true;
            draw_rectangle = false;
            draw_circle = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            draw_line = false;
            draw_rectangle = false;
            draw_circle = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            draw_line = false;
            draw_rectangle = true;
            draw_circle = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseIsDown = true;
            pressedLocationX = e.X;
            pressedLocationY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            releasedLocationX = e.X;
            releasedLocationY = e.Y;

        }
    }
}
