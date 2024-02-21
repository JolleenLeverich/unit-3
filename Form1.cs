using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1(string User)
        {
            InitializeComponent();
            if (User.Contains("Sales"))
            {
                OrdersRB.Enabled = true;
                CustomersRB.Enabled = true;
            }
            else if(User.Contains("HR"))
            {
                EmployeeRB.Enabled = true;

            }
            else if (User.Contains("CEO"))
            {
                OrdersRB.Enabled = true;
                CustomersRB.Enabled = true;
                EmployeeRB.Enabled = true;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string connString = @"Data Source=DESKTOP-L263P3K\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (var con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();
                    if (OrdersRB.Checked)
                    {
                        using (var command = new SqlCommand("SELECT * FROM Orders", con))
                        {
                            using (var da = new SqlDataAdapter(command))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                    if (CustomersRB.Checked)
                    {
                        using (var command = new SqlCommand("SELECT * FROM Customers", con))
                        {
                            using (var da = new SqlDataAdapter(command))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                    if (EmployeeRB.Checked)
                    {
                        using (var command = new SqlCommand("SELECT * FROM Employees", con))
                        {
                            using (var da = new SqlDataAdapter(command))
                            {
                                da.Fill(dt);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string connString = @"Data Source=DESKTOP-L263P3K\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (var con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();
                    using (var command = new SqlCommand("", con))
                    {
                        using (var da = new SqlDataAdapter(command))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            dataGridView1.DataSource = dt;
        }

        private void EmployeesChBx_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}