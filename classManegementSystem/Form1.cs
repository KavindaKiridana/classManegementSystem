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
    public partial class Form1 : Form
    {
        StudentClass student = new StudentClass();

        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentCount();
        }

        //function to dispaly student count
        private void studentCount()
        {
            lbl_total.Text = "Total Student : " + student.totalStudent();
            lbl_male.Text = "Male : " + student.totFemaleStudent();//there is an error 
            lbl_femal.Text = "Female : " + student.totFemaleStudent();//there is an error
        }

        private void customizeDesign()
        {
            panel_studentmenu.Visible = false;
            panel_coursemenu.Visible = false;
            panel_scoremenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panel_studentmenu.Visible == true)
                panel_studentmenu.Visible = false;
            if (panel_coursemenu.Visible == true)
                panel_coursemenu.Visible = false;
            if (panel_scoremenu.Visible == true)
                panel_scoremenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }



        private void panel_side_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_studentmenu);
        }

        private void btn_course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_coursemenu);
        }

        private void btn_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_scoremenu);
        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            //directing to registerform
            RegisterForm register = new RegisterForm();
            this.Hide();
            register.Show();
            //openChildForm(new RegisterForm());
        }

        private void btn_managestd_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            //directing to managestudent form
            ManageStudent ms = new ManageStudent();
            this.Hide();
            ms.Show();
        }

        private void btn_status_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_stdPrint_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_newCourse_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            CourseForm courseForm = new CourseForm();
            this.Hide();
            courseForm.Show();
        }

        private void btn_manageCourse_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            MenageCourseForm menageCourseForm = new MenageCourseForm();
            this.Hide();
            menageCourseForm.Show();
        }

        private void btn_coursePrint_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_newScore_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_manageScore_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_scorePrint_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //this is unwanted code 
            //delete this if you can
        }

        /*
        //to show registerform in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        */
    }
}
