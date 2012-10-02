using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ReportSystem
{
    public partial class Form6 : Form
    {
        DBwork dbw1 = new DBwork(SqlConnectionParametrs.DataBaseName, SqlConnectionParametrs.DataBaseServiceName);
        DataSet dataSet21;
        DataSet dataSet11;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        string g_reportName;

        public Form6(string reportName)
        {
            g_reportName = reportName;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            BindingSource bindingSource1 = new BindingSource();
            DataSet dataSet1 = dbw1.ReadDataBaseToDataSet("QUIM", "select progName, CreationD_rep, percofend from Report where progName LIKE '" + g_reportName + "'");
            this.Text = dataSet1.Tables[0].Rows[0].ItemArray[0].ToString() + " " + dataSet1.Tables[0].Rows[0].ItemArray[1].ToString();
            dataSet21 = new DataSet();
            adapter = new SqlDataAdapter();
            dataSet11 = dbw1.ReadDataBaseToDataSet("QUIM", "select m.name_met, mr.MinValue, mr.Curvalue, MaxValue, mr.Rate, mr.Value, mr.Type from  metric m, MetrInRep mr where m.id_met = mr.id_met and mr.id_rep in (select r.id_rep from report r where r.progName like '" + g_reportName + "')");
            dataGridView8.DataSource = dataSet11.Tables[0];
            dataGridView8.Columns[0].HeaderText = "NAME METRIC:";
            dataGridView8.Columns[0].ReadOnly = true;
            dataGridView8.Columns[1].HeaderText = "MIN VALUE:";
            dataGridView8.Columns[2].HeaderText = "CUR VALUE:";
            dataGridView8.Columns[3].HeaderText = "MAX VALUE:";
            dataGridView8.Columns[4].HeaderText = "RATE:";
            dataGridView8.Columns[5].HeaderText = "VALUE:";
            dataGridView8.Columns[5].ReadOnly = true;
            dataGridView8.Columns[6].HeaderText = "TYPE:";
            adapter = dbw1.fillDataAdapter(temp.name_db, "select mr.MinValue, mr.Curvalue, MaxValue, mr.Rate, mr.Value, mr.Type from MetrInRep mr where mr.id_rep in (select r.id_rep from report r where r.progName like '" + g_reportName + "')");
            cmdBuilder = new SqlCommandBuilder(adapter);
            UseWaitCursor = false;
            dataGridView8_Resize(dataGridView8, null);
            try
            {
                dataSet21 = dataSet11.GetChanges();
                if (dataSet21 != null)
                    adapter.Update(dataSet21);
            }
            catch (Exception ee)
            {
                dataSet21 = null;
            }
        }

        private void dataGridView8_Resize(object sender, EventArgs e)
        {
            if (dataGridView8.Columns.Count != 0)
            {
                int visibilColumns = 2;
                for (int i = 0; i < dataGridView8.Columns.Count; i++)
                {
                    if (dataGridView8.Columns[i].Visible)
                        visibilColumns++;
                }
                int lenth = dataGridView8.Width / visibilColumns;
                dataGridView8.Columns[0].Width = lenth * 3;
                dataGridView8.Columns[1].Width = lenth;
                dataGridView8.Columns[2].Width = lenth;
                dataGridView8.Columns[3].Width = lenth;
                dataGridView8.Columns[4].Width = lenth;
                dataGridView8.Columns[5].Width = lenth;
                dataGridView8.Columns[6].Width = lenth;
            }
        }

        private void Form6_Resize(object sender, EventArgs e)
        {
            dataGridView8.Width = this.Width - 40;
            dataGridView8.Height = this.Height - 82;
        }

        private void tYPEToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView8.Columns[1].Visible = mINToolStripMenuItem.Checked;
            dataGridView8.Columns[3].Visible = mAXToolStripMenuItem.Checked;
            dataGridView8.Columns[4].Visible = rATEToolStripMenuItem.Checked;
            dataGridView8.Columns[5].Visible = vALUEToolStripMenuItem.Checked;
            dataGridView8.Columns[6].Visible = tYPEToolStripMenuItem.Checked;
            dataGridView8_Resize(dataGridView8, null);
        }
    }
}
