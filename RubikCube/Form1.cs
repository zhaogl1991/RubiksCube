using RubikCube.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubikCube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TestObject a = new TestObject();
            a.data = 1;
            TestObject b = a;
            a.data = 2;
            MessageBox.Show(string.Format("a={0},b={1}",a.data,b.data));
        }
    }
}
