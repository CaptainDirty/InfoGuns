using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace InfoGuns
{   
    public partial class SELECT : Form
    {
        private SqlConnection sqlConnection = null;
        private int id;
        public SELECT(SqlConnection connection, int id)
        {
            InitializeComponent();
            sqlConnection = connection;
            this.id = id;
        }

        private async void SELECT_Load(object sender, EventArgs e)
        {
            SqlCommand getWeaponInfoCommand = new SqlCommand("SELECT [Name], [Type], [Description] FROM [Weapons] WHERE [Id]=@Id", sqlConnection);
            getWeaponInfoCommand.Parameters.AddWithValue("Id", id);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await getWeaponInfoCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    textBox1.Text = Convert.ToString(sqlReader["Name"]);
                    textBox2.Text = Convert.ToString(sqlReader["Type"]);
                    textBox3.Text = Convert.ToString(sqlReader["Description"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                    sqlReader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
