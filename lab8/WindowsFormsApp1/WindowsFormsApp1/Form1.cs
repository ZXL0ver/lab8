using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ICircle _circle;
        public Form1()
        {
            InitializeComponent();
            _circle = new Circle(50, 50, 25);
            _circle = new ConsoleDecorator(_circle);
            _circle = new VisualDecorator(_circle, this);

            this.Paint += Client_Paint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Client_Paint(object sender, PaintEventArgs e)
        {
            _circle.Draw(e.Graphics);
        }
    }
}
