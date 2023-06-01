using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classManegementSystem
{
    public partial class CourseForm : Form
    {
        CourseClass objcourse = new CourseClass();

        public CourseForm()
        {
            InitializeComponent();
        }

        bool validation()
        {
            if (string.IsNullOrWhiteSpace(txt_cName.Text) ||
                string.IsNullOrWhiteSpace(txt_details.Text) ||
                string.IsNullOrWhiteSpace(txt_hours.Text)  )
            {
                MessageBox.Show("All fields are required");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            

            if (validation())
            {
                try
                {
                    //add record
                    string cname = txt_cName.Text;
                    string dateils = txt_details.Text;
                    int hours = int.Parse(txt_hours.Text);

                    bool success = objcourse.addStudent(cname, hours, dateils);
                    MessageBox.Show("Data inserted successfully.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            btn_clear.PerformClick();
            showData();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_cName.Clear();
            txt_details.Clear();
            txt_hours.Clear();
        }

        private void dgv_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void showData()
        {
            //show data in dgv
            dgv_student.DataSource = objcourse.getRecords();
        }
    }
}
