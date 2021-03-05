using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoGuns
{
    public partial class frm_Report : Form
    {
        public frm_Report()
        {
            InitializeComponent();
        }

        private void frm_Report_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "InfoBaseDataSet.Weapons". При необходимости она может быть перемещена или удалена.
            this.WeaponsTableAdapter.Fill(this.InfoBaseDataSet.Weapons);
            // Заполнение таблицы
            InfoBaseDataSet uds = new InfoBaseDataSet();
            InfoBaseDataSet.WeaponsDataTable bs = new InfoBaseDataSet.WeaponsDataTable();

            InfoBaseDataSetTableAdapters.WeaponsTableAdapter sta = new InfoBaseDataSetTableAdapters.WeaponsTableAdapter();
            sta.Fill(bs);

            // Передача источника в отчет
            ReportDataSource rds = new ReportDataSource("DataSet1", (DataTable)bs);
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
