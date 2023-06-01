using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace classManegementSystem
{
    public partial class MenageCourseForm : Form
    {
        CourseClass objcourse = new CourseClass();
        SqlConnection sqlConnection = new SqlConnection(" Data Source=DESKTOP-64B0UVI\\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True ");


        public MenageCourseForm()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void showData()
        {
            //show data in dgv
            dgv_mcourse.DataSource = objcourse.getRecords();
        }

        private void MenageCourseForm_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_cName.Clear();
            txt_cid.Clear();
            txt_details.Clear();
            txt_hours.Clear();
        }

        bool validation()
        {
            if (string.IsNullOrWhiteSpace(txt_cName.Text) ||
                string.IsNullOrWhiteSpace(txt_details.Text) ||
                string.IsNullOrWhiteSpace(txt_cid.Text) ||
                string.IsNullOrWhiteSpace(txt_hours.Text))
            {
                MessageBox.Show("All fields are required");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if(validation())
            {
                try
                {
                    int id = int.Parse(txt_cid.Text);
                    string cname = txt_cName.Text;
                    int hours = int.Parse(txt_hours.Text);
                    string details = txt_details.Text;

                    string sql = "UPDATE course SET cname = '" + cname + "',chour='"+hours+"',details='"+details+"'  WHERE cid='" + id + "' ";
                    SqlCommand command = new SqlCommand(sql, sqlConnection);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    showData();

                    MessageBox.Show("Successfully updated");
                    btn_clear.PerformClick();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_cid.Text))
            {
                MessageBox.Show("Course id must required");
            }
            else
            {
                try
                {
                    int id = int.Parse(txt_cid.Text);
                    string sql = "DELETE FROM course WHERE cid = '" + id + "'";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    MessageBox.Show("Record deleted");
                    showData();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
