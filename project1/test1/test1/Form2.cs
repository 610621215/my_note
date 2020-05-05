using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form2 : Form
    {
        public int a = 0;
        public Boolean test = false;

        public Form2()
        {
            InitializeComponent();
        }
        public delegate void label_name(String name);
        public event label_name ln;
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "工作名稱";
            button1.Text = "Submit";
     //       button1.Click += new System.EventHandler(button1_Click);//將事件是為某一種屬性之設定 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(textBox1.Text);
            //textBox1.Text = "asdasdasd";
            ln(textBox1.Text);
            //test = true;
        }

        //public string TextBoxMsg
        //{
        //    set
        //    {
        //        textBox1.Text = value;
        //    }
        //    get
        //    {
        //        return textBox1.Text;
        //    }

        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
