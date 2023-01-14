using System.Collections.Generic;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsAppClassWorkSokolov
{
    public partial class Form1 : Form
    {
        Timer Timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Random random = new Random();
            if (Timer != null)
            {
                Timer.Stop();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SetDesktopLocation(0,0);
                this.Size = new Size(300, 300);

                Timer = new Timer();
                Timer.Interval = 50;
                Timer.Tick += (s, e) => {
                    this.SetDesktopLocation(random.Next(0, 1920), random.Next(0, 1080));
                };
                Timer.Start();
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (Timer != null)
                {
                    Timer.Stop();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && this.Left > 0)
            {
                this.SetDesktopLocation(this.Left - 5, this.Top);
            }
            if (e.KeyCode == Keys.Right && (this.Left + this.Width) < Screen.PrimaryScreen.Bounds.Right)
            {
                this.SetDesktopLocation(this.Left + 5, this.Top);
            }
            if (e.KeyCode == Keys.Up && this.Top > 0)
            {
                this.SetDesktopLocation(this.Left, this.Top - 5);
            }
            if (e.KeyCode == Keys.Down && this.Top + this.Height < Screen.PrimaryScreen.Bounds.Bottom)
            {
                this.SetDesktopLocation(this.Left, this.Top + 5);
            }
        }
    }
}