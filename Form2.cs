using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1106305劉宣甫_期末專案_小遊戲21點
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.StartPosition = FormStartPosition.Manual;
            f1.Location =new Point (this.Location.X, this.Location.Y);

            f1.Show();
            this.Hide();

        }
    }
}
