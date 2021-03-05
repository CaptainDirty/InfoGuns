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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Алгоритмы и структуры данных\InfoGuns v2\InfoBase.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.AllowColumnReorder = true;

            listView1.Columns.Add("Id", 0);
            listView1.Columns.Add("Имя", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Тип", 130, HorizontalAlignment.Left);
            listView1.Columns.Add("Описание", -2, HorizontalAlignment.Left);
            
            

            await LoadWeaponsAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        
        private async Task LoadWeaponsAsync() //SELECT
        {
            SqlDataReader sqlReader = null;
            SqlCommand getWeaponsCommand = new SqlCommand("SELECT * FROM [Weapons]", sqlConnection);
            try
            {
                sqlReader = await getWeaponsCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        Convert.ToString(sqlReader["Id"]),
                        Convert.ToString(sqlReader["Name"]),
                        Convert.ToString(sqlReader["Type"]),
                        Convert.ToString(sqlReader["Description"])
                    });

                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }
        }

        
        
        private async void toolStripButton5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            await LoadWeaponsAsync();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //INSERT
        {
            INSERT insert = new INSERT(sqlConnection);

            insert.Show();

        }

    
        private void toolStripButton2_Click(object sender, EventArgs e)
        {   if (listView1.SelectedItems.Count > 0)

            {
                UPDATE update = new UPDATE(sqlConnection, Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));

                update.Show();
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {   if (listView1.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                switch (res)
                {
                    case DialogResult.OK:
                        SqlCommand deleteWeaponCommand = new SqlCommand("DELETE FROM [Weapons] WHERE [Id]=@Id", sqlConnection);
                        deleteWeaponCommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        try
                        {
                            await deleteWeaponCommand.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        listView1.Items.Clear();
                        await LoadWeaponsAsync();
                        break;
                }
            }
        else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("InfoGuns\nАлександр Болотов, НМТ-283907, ТИМ\n 2019", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)

            {
                SELECT select = new SELECT(sqlConnection, Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));

                select.Show();
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand getWeaponsCommand = new SqlCommand("SELECT * FROM [Weapons] WHERE [Name]=@Name", sqlConnection);
            getWeaponsCommand.Parameters.AddWithValue("Name", SearchBox.Text);
            try
            {
                sqlReader = await getWeaponsCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        Convert.ToString(sqlReader["Id"]),
                        Convert.ToString(sqlReader["Name"]),
                        Convert.ToString(sqlReader["Type"]),
                        Convert.ToString(sqlReader["Description"])
                    });

                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }


        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Report form = new frm_Report();
            form.Show();
        }
    }
}
