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
    public partial class INSERT : Form
    {
        private SqlConnection sqlConnection = null;
        public INSERT(SqlConnection connection)
        {
            InitializeComponent();
            sqlConnection = connection;
        }

        private void INSERT_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlCommand insertWeaponCommand = new SqlCommand("INSERT INTO [Weapons] (Name, Type, Description)VALUES(@Name,@Type,@Description)", sqlConnection);
            insertWeaponCommand.Parameters.AddWithValue("Name", textBox1.Text);
            insertWeaponCommand.Parameters.AddWithValue("Type", comboBox1.SelectedItem);
            insertWeaponCommand.Parameters.AddWithValue("Description", textBox3.Text);

            try
            {
                await insertWeaponCommand.ExecuteNonQueryAsync();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
