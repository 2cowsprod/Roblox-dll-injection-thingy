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

namespace TutorialInjector
{
    public partial class Form1 : Form
    {
        private bool isDown = false;
        private Point lastLoc;

        public static string dll = "Injector.dll"; // the name of your DLL

        public static void Inject()
        {
            switch(Injection.Injector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + dll))
            {
                case Injection.Injection_Results.InvalidDll:
                    MessageBox.Show("Invalid dll");
                    return;
                case Injection.Injection_Results.RobloxNotFound:
                    MessageBox.Show("Roblox cannot be found");
                    return;
                case Injection.Injection_Results.Failed:
                    MessageBox.Show("Injection failed!");
                    return;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InjectionButton_Click(object sender, EventArgs e)
        {
            Inject();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            Environment.Exit(0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            lastLoc = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                this.Location = new Point((this.Location.X - lastLoc.X) + e.X, (this.Location.Y - lastLoc.Y) + e.Y);
                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }
    }
}
