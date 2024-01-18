using System.Data;
using System.Data.SqlClient;

namespace RecorderDiary
{
    public partial class Form1 : Form
    {
        static string constr = "Data Source=DESKTOP-9RN53EB\\SQLEXPRESS;Initial Catalog=RecorderDiary;Integrated Security=True";
        SqlConnection conn = new SqlConnection(constr);
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }
        public void DisplayData()
        {
            conn.Open();
            string query = "select * from diary";
            SqlDataAdapter adr = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;


            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                string query = ("insert into diary values (@id, @name, @age)");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Inserted successful");
                    }
                    else
                    {
                        MessageBox.Show("Inserted unsuccessful");
                    }
                }
                catch (Exception m)
                {

                    MessageBox.Show(m.Message);
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("Please enter a data.");
            }
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                string query = ("Update diary set name=@name, age=@age where id=@id");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Updated successful");
                }
                else
                {
                    MessageBox.Show("Update unsuccessful");
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("not a valid data.");
            }
            DisplayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                conn.Open();
                string query = ("delete diary where id=@id");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Deleted successful");
                }
                else
                {
                    MessageBox.Show("Delete unsuccessful");
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("not a valid data.");
            }
            DisplayData();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                int age = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

                textBox1.Text = id.ToString();
                textBox2.Text = name;
                textBox3.Text = age.ToString();
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }

           



        }
    }
}