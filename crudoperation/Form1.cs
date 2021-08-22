using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crudoperation
{   
    public partial class Form1 : Form
    {
        public int rno;
        public string gender;
      
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-L48O798\sqlexpress;Initial Catalog=crud;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dispdata();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gender;
            if (radioButton1.Checked == true) { gender="Male";}else{gender="Female";}
                     if (textBox1.Text == "")
                MessageBox.Show("Please fill the Roll no");
            else if (textBox2.Text == "")
                MessageBox.Show("Please fill the Name");
            else if(comboBox1.SelectedItem==null)
                         MessageBox.Show("Select the class");
           else if (textBox3.Text == "")
                MessageBox.Show("Please fill the Mobile Number");
           else if (textBox5.Text == "")
                MessageBox.Show("Please enter the age ");
                     
                     
            else
           {
                 conn.Open();
                 try
                 {

                     SqlCommand comm = conn.CreateCommand();
                     comm.CommandType = CommandType.Text;
                     comm.CommandText = "insert into crudprotuple values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "','" + textBox3.Text + "','" + gender + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                     comm.ExecuteNonQuery();
                     
                     dispdata();
                     MessageBox.Show("Data are succefully insert");
                     
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
                 finally
                 {
                     conn.Close();
                     clear(); 
                 }
            }
           
            }
        public void dispdata()
        {
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from crudprotuple ";
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            dataGridView1.DataSource=dt;
          conn.Close();
           
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.ResetText();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gender1;
            rno = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            gender1 = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (gender1 == "Male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if (radioButton1.Checked == true)
                { gender = "Male"; }
            else if (radioButton2.Checked == true) 
                { gender = "Female"; } 
            else { MessageBox.Show("select the gender"); }
            if (textBox1.Text == "")
                MessageBox.Show("Please fill the Roll no");
            else if (textBox2.Text == "")
                MessageBox.Show("Please fill the Name");
            else if (comboBox1.SelectedItem == null)
                MessageBox.Show("Select the class");
            else if (textBox3.Text == "")
                MessageBox.Show("Please fill the Mobile Number");
            else if (textBox5.Text == "")
                MessageBox.Show("Please enter the age ");
            else
            {
                conn.Open();

                try
                {
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update crudprotuple set name='" + textBox2.Text + "',class='" + comboBox1.SelectedItem + "',mobileno='" + textBox3.Text + "' ,gender='" + gender + "',city='" + textBox4.Text + "',age='" + textBox5.Text + "' where rollno='" + textBox1.Text + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Data Updated Successfully");

                }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
                finally
                {
                    conn.Close();
                    clear();
                    dispdata();
                }

            }
     
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
                MessageBox.Show("Please select the Roll No");
            else
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "delete from crudprotuple where crudprotuple.rollno='" + textBox1.Text + "'";
                comm.ExecuteNonQuery();
                conn.Close();
                dispdata();
                MessageBox.Show("Data are succefully Delete");
            }

            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dispdata();
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select * from crudprotuple where rollno like  '" + textBox1.Text + "%'";
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();     
            }
        }

      
    }
}
