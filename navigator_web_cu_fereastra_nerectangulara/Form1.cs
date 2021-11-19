using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace navigator_web_cu_fereastra_nerectangulara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wb.Navigate(tb.Text);
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) wb.Navigate(tb.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb.Focus();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
