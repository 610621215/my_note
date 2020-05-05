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
    public partial class Form1 : Form
    {
        Form2 f = new Form2();
        List<String> mylist = new List<String>();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Working window";
            f.Text = "新增工作";
            this.SetDesktopBounds(100, 100, 287, 350);
            //371, 344
            f.SetDesktopBounds(200, 100, 300, 200);
            button2.Click += new System.EventHandler(button1_Click);//將事件是為某一種屬性之設定 
            this.backgroundWorker1.WorkerReportsProgress = true;
           
            label1.Text = "Working List.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            button2.Text = "Add";
            f.ln += new Form2.label_name(set_label);

            //backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click");
            f.Visible = true;

        }
        public void set_label(String context)
        {
            //return context;
            if (!mylist.Contains(context))
            {
                mylist.Add(context);
                checkedListBox1.Items.Add(context, CheckState.Unchecked);

            }

        }
      
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            //Console.WriteLine((checkedListBox1.GetItemCheckState(0) == CheckState.Checked));
            //if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
            //{
            //    MessageBox.Show("Test");
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(mylist.Count);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine((checkedListBox1.GetItemCheckState(0) == CheckState.Checked));
            for(int i=0;i<mylist.Count;i++)
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    string caption = "Error Detected in Input";
                    result = MessageBox.Show("是否刪除", caption, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {   
                        // cancel the closure of the form.
                        mylist.RemoveAt(i);
                        checkedListBox1.Items.RemoveAt(i);
                    }
                }
        }
    }
}
