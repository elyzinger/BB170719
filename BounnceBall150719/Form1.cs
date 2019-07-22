using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BounnceBall150719
{
    public partial class Form1 : Form
    {
        int dx = 2;
        int dy = 2;
        bool stop = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)// start
        {

            Task.Run(() =>
            {
                stop = false;
                while (stop == false)
                {

                    Action a = () =>
                    {
                        if (pictureBox1 != null)
                        {
                            pictureBox1.Location = new Point(pictureBox1.Location.X + dx, pictureBox1.Location.Y + dy);
                        }
                        else
                        {

                        }
                    };
                       
                    pictureBox1.BeginInvoke(a);

                    if (pictureBox1.Location.X <= 0)
                        dx = 2;

                    if (pictureBox1.Location.Y <= 0)
                        dy = 2;

                    if (pictureBox1.Location.X >= panel1.Width - pictureBox1.Width)
                        dx = -2;
                    if (pictureBox1.Location.Y >= panel1.Height - pictureBox1.Height)
                        dy = -2;

                    Thread.Sleep(10);
                }
            });
        }
        private void button2_Click(object sender, EventArgs e) // stop
        {
            stop = true;
        }
        private void NewBall(PictureBox picture)
        {

        }
        private void button3_Click(object sender, EventArgs e) // add
        {
            stop = false;
            var picture = new PictureBox
            {
                Name = "picture box",
                Location = new Point(173, 105),
                Image = global::BounnceBall150719.Properties.Resources.pokaball1,
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                TabIndex = 1,
                Size = new System.Drawing.Size(136, 130),
                TabStop = false,

            };
            picture.Click += new System.EventHandler(this.pictureBox1_Click);
            this.Controls.Add(picture);
            Task.Run(() =>
            {

                while (stop == false)
                {

                    Action b = () =>
                 {
                     { picture.Location = new Point(picture.Location.X + dx, picture.Location.Y + dy); }
                 };
                    picture.BeginInvoke(b);
                    if (picture.Location.X <= 0)
                        dx = 2;
                    if (picture.Location.Y <= 0)
                        dy = 2;
                    if (picture.Location.X >= panel1.Width - picture.Width)
                        dx = -2;
                    if (picture.Location.Y >= panel1.Height - picture.Height)
                        dy = -2;
                    Thread.Sleep(10);
                }
            });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //var picture = new PictureBox
            //{
            //    Name = "explode",
            //    Location = new Point(173, 105),
            //    Image = Image.FromFile(@"C:\Users\USER\Desktop\explode.ping"),
            //    SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
            //    TabIndex = 1,
            //    Size = new System.Drawing.Size(136, 130),
            //    TabStop = false,

            //};
        }
    }
}
