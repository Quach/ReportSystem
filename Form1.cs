using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ReportSystem
{
    public partial class Form1 : Form
    {
        DBwork dbw1 = new DBwork(SqlConnectionParametrs.DataBaseName, SqlConnectionParametrs.DataBaseServiceName);
        private DataSet dataSetTemp;
        private DataSet dataSetTemp1;
        private DataSet dataSetTemp2;
        private bool AllowEditInfo = false;

        public Form1()
        {
            InitializeComponent();
            listView2_ReadReports();
            Form1_Resize(this, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            splitContainer1.Width = this.Width - 36;
            splitContainer1.Height = this.Height - 90;
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            listView2.Width = splitContainer1.Panel1.Width - 13;
            listView2.Height = splitContainer1.Panel1.Height - 38;
            label9.Location = new Point(3, splitContainer1.Panel1.Height - 13);
        }

        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {
            groupBox1.Width = splitContainer2.Panel1.Width - 6;
            groupBox1.Height = splitContainer2.Panel1.Height - 6;
        }

        private void splitContainer3_Panel1_Resize(object sender, EventArgs e)
        {
            treeView1.Width = splitContainer3.Panel1.Width - 6;
            treeView1.Height = splitContainer3.Panel1.Height - 6;
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            splitContainer2.Width = splitContainer1.Panel2.Width - 6;
            splitContainer2.Height = splitContainer1.Panel2.Height - 6;
        }

        private void splitContainer2_Panel2_Resize(object sender, EventArgs e)
        {
            groupBox2.Width = splitContainer2.Panel2.Width - 6;
            groupBox2.Height = splitContainer2.Panel2.Height - 6;
        }

        private void splitContainer3_Panel2_Resize(object sender, EventArgs e)
        {
            groupBox6.Width = splitContainer3.Panel2.Width - 6;
            groupBox3.Width = splitContainer3.Panel2.Width - 6;
            groupBox5.Width = splitContainer3.Panel2.Width - 6;
            groupBox4.Width = splitContainer3.Panel2.Width - 6;
            groupBox6.Height = (splitContainer3.Panel2.Height / 4 - 6);
            groupBox3.Height = (splitContainer3.Panel2.Height / 4 - 6);
            groupBox5.Height = (splitContainer3.Panel2.Height / 4 - 6);
            groupBox4.Height = (splitContainer3.Panel2.Height / 4 - 6);
            groupBox3.Location = new Point(3, (splitContainer3.Panel2.Height / 4));
            groupBox5.Location = new Point(3, (splitContainer3.Panel2.Height / 4) * 2);
            groupBox4.Location = new Point(3, (splitContainer3.Panel2.Height / 4) * 3);
        }

        private void groupBox6_Resize(object sender, EventArgs e)
        {
            richTextBox1.Width = groupBox6.Width - 12;
            richTextBox1.Height = groupBox6.Height - 25;
        }

        private void groupBox3_Resize(object sender, EventArgs e)
        {
            richTextBox2.Width = groupBox3.Width - 12;
            richTextBox2.Height = groupBox3.Height - 25;
        }

        private void groupBox5_Resize(object sender, EventArgs e)
        {
            richTextBox3.Width = groupBox5.Width - 12;
            richTextBox3.Height = groupBox5.Height - 25;
        }

        private void groupBox4_Resize(object sender, EventArgs e)
        {
            richTextBox4.Width = groupBox4.Width - 12;
            richTextBox4.Height = groupBox4.Height - 25;
        }

        private void groupBox2_Resize(object sender, EventArgs e)
        {
            splitContainer3.Width = groupBox2.Width - 6;
            splitContainer3.Height = groupBox2.Height - 6;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Perform a window which ask exit
            toolStripStatusLabel1.Text = "Exiting...";
            Form3 f3 = new Form3();
            f3.ShowDialog();
            if (!f3.exit)
            {
                e.Cancel = true;
                toolStripStatusLabel1.Text = "Working...";
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Creating Report...";
            Form18 f18 = new Form18();
            f18.ShowDialog(this);
            listView2_ReadReports();
            toolStripStatusLabel1.Text = "Working...";
        }

        private void deleteReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Deleting Report...";
            Form19 f19 = new Form19();
            f19.ShowDialog(this);
            listView2_ReadReports();
            toolStripStatusLabel1.Text = "Working...";
        }

        private void modifyReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Modifing Report...";
            Form20 f20 = new Form20();
            f20.ShowDialog(this);
            listView2_ReadReports();
            toolStripStatusLabel1.Text = "Working...";
        }

        private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            оПрограммеToolStripMenuItem_Click(sender, hlpevent);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //info
            toolStripStatusLabel1.Text = "Informing...";
            Form4 f4 = new Form4();
            f4.ShowDialog();
            toolStripStatusLabel1.Text = "Working...";
        }

        void listView2_ReadReports()
        {
            measureToolStripMenuItem.Enabled = false;
            outputToolStripMenuItem.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            AllowEditInfo = false;
            listView2.Clear();
            treeView1.Nodes.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox8.Clear();
            richTextBox7.Clear();
            richTextBox13.Clear();
            richTextBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            richTextBox5.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            ReadReports();
        }

        private void ReadReports()
        {
            dataSetTemp = dbw1.ReadReports();
            for (int i = 0; i < dataSetTemp.Tables[0].Rows.Count; i++)
            {
                listView2.Items.Add(dataSetTemp.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            dataSetTemp = null;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0)
            {
                measureToolStripMenuItem.Enabled = false;
                outputToolStripMenuItem.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                AllowEditInfo = false;
                treeView1.Nodes.Clear();
                richTextBox1.Clear();
                richTextBox2.Clear();
                richTextBox3.Clear();
                richTextBox4.Clear();
                richTextBox8.Clear();
                richTextBox7.Clear();
                richTextBox13.Clear();
                richTextBox5.Clear();
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                richTextBox5.Enabled = false;
                maskedTextBox1.Enabled = false;
                maskedTextBox2.Enabled = false;
            }
            else
            {
                measureToolStripMenuItem.Enabled = true;
                outputToolStripMenuItem.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                dataSetTemp = dbw1.ReadNameCreationTimePercentOfEndReport(listView2.Items[listView2.SelectedIndices[0]].Text);
                richTextBox8.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                richTextBox7.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[1].ToString();
                richTextBox13.Text = (Double.Parse(dataSetTemp.Tables[0].Rows[0].ItemArray[2].ToString()) * 100).ToString("F0") + "% Value: " + dbw1.ReadGlobalReportValue(listView2.Items[listView2.SelectedIndices[0]].Text).ToString("F9");
                dataSetTemp = dbw1.ReadFartorsByReport(listView2.Items[listView2.SelectedIndices[0]].Text);
                for (int i = 0; i < dataSetTemp.Tables[0].Rows.Count; i++)
                {
                    TreeNode node = treeView1.Nodes.Add(dataSetTemp.Tables[0].Rows[i].ItemArray[0].ToString());
                    dataSetTemp1 = dbw1.ReadCriteriasByReportFactor(listView2.Items[listView2.SelectedIndices[0]].Text, dataSetTemp.Tables[0].Rows[i].ItemArray[0].ToString());
                    for (int j = 0; j < dataSetTemp1.Tables[0].Rows.Count; j++)
                    {
                        TreeNode node1 = node.Nodes.Add(dataSetTemp1.Tables[0].Rows[j].ItemArray[0].ToString());
                        dataSetTemp2 = dbw1.ReadMetricsByReportCriteria(listView2.Items[listView2.SelectedIndices[0]].Text, dataSetTemp1.Tables[0].Rows[j].ItemArray[0].ToString());
                        for (int k = 0; k < dataSetTemp2.Tables[0].Rows.Count; k++)
                        {
                            TreeNode node2 = node1.Nodes.Add(dataSetTemp2.Tables[0].Rows[k].ItemArray[0].ToString());
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AllowEditInfo = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            richTextBox5.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            switch (e.Node.Level)
            {
                case 0:
                    textBox1.Enabled = true;
                    maskedTextBox1.Enabled = true;
                    maskedTextBox2.Enabled = true;
                    dataSetTemp = dbw1.ReadNameDefFactor(e.Node.Text);
                    richTextBox1.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    richTextBox2.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[1].ToString();
                    textBox1.Text = "FACTOR: " + dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    dataSetTemp = dbw1.ReadInfoFactorByReportFactor(listView2.Items[listView2.SelectedIndices[0]].Text, e.Node.Text);
                    maskedTextBox2.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    maskedTextBox1.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[1].ToString();
                    break;
                case 1:
                    textBox1.Enabled = true;
                    maskedTextBox1.Enabled = true;
                    maskedTextBox2.Enabled = true;
                    dataSetTemp = dbw1.ReadNameDefCriteria(e.Node.Text);
                    richTextBox1.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    richTextBox2.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[1].ToString();
                    textBox1.Text = "CRITERIA: " + dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    dataSetTemp = dbw1.ReadInfoCriteriaByReportCriteriaFactor(listView2.Items[listView2.SelectedIndices[0]].Text, e.Node.Text, e.Node.Parent.Text);
                    maskedTextBox2.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    maskedTextBox1.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[1].ToString();
                    break;
                case 2:
                    checkBox1.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    richTextBox5.Enabled = true;
                    maskedTextBox1.Enabled = true;
                    maskedTextBox2.Enabled = true;
                    dataSetTemp = dbw1.ReadNameDefFormUnitMetric(e.Node.Text);
                    richTextBox1.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    richTextBox2.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[1].ToString();
                    richTextBox3.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[2].ToString();
                    richTextBox4.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[3].ToString();
                    textBox1.Text = "METRIC: " + dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    dataSetTemp = dbw1.ReadInfoMetricByReportMetric(listView2.Items[listView2.SelectedIndices[0]].Text, e.Node.Text);
                    textBox2.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[2].ToString();
                    textBox3.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[3].ToString();
                    textBox4.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[0].ToString();
                    richTextBox5.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[1].ToString();
                    maskedTextBox2.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[4].ToString();
                    maskedTextBox1.Text = dataSetTemp.Tables[0].Rows[0].ItemArray[5].ToString();
                    break;
                default:
                    break;
            }
            AllowEditInfo = true;
        }

        private void PerformInfoUpdate()
        {
            if (AllowEditInfo)
            {
                try
                {
                    switch (treeView1.SelectedNode.Level)
                    {
                        case 0:
                            dbw1.UpdateFactorInRep(listView2.Items[listView2.SelectedIndices[0]].Text, treeView1.SelectedNode.Text, Double.Parse(maskedTextBox1.Text), Double.Parse(maskedTextBox2.Text));
                            break;
                        case 1:
                            dbw1.UpdateCriteriaFactorInRep(listView2.Items[listView2.SelectedIndices[0]].Text, treeView1.SelectedNode.Text, treeView1.SelectedNode.Parent.Text, Double.Parse(maskedTextBox1.Text), Double.Parse(maskedTextBox2.Text));
                            break;
                        case 2:
                            maskedTextBox2.Text = dbw1.GetUniverseNumber(Double.Parse(textBox4.Text), Double.Parse(textBox2.Text), Double.Parse(textBox3.Text), checkBox1.Checked).ToString();
                            dbw1.UpdateMetrincInRep(listView2.Items[listView2.SelectedIndices[0]].Text, treeView1.SelectedNode.Text, Double.Parse(maskedTextBox1.Text), Double.Parse(maskedTextBox2.Text), Double.Parse(textBox2.Text), Double.Parse(textBox3.Text), Double.Parse(textBox4.Text), richTextBox5.Text);
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                }
            }
        }

        private void kiviatDiagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //diagramm
            toolStripStatusLabel1.Text = "Diagram...";
            Form5 f5 = new Form5(listView2.Items[listView2.SelectedIndices[0]].Text);
            f5.ShowDialog();
            toolStripStatusLabel1.Text = "Working...";
        }

        private void checkListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Check listing...";
            Form6 f6 = new Form6(listView2.Items[listView2.SelectedIndices[0]].Text);
            f6.ShowDialog();
            toolStripStatusLabel1.Text = "Working...";
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataSetTemp = dbw1.ReadInfoMetricByReportMetric(listView2.Items[listView2.SelectedIndices[0]].Text, "%");
                string temp = dataSetTemp.GetXml();
                System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(saveFileDialog1.FileName);
                dataSetTemp.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
                xmlSW.Close();
                string info = "XML file saved at\n" + saveFileDialog1.FileName;
                MessageBox.Show(this, info, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog2.Filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";
            saveFileDialog2.FilterIndex = 2;
            saveFileDialog2.RestoreDirectory = true;

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                Object missing = Type.Missing;
                Word.Document word1 = application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                //object text = "tesfsdfkslghsdgjh";
                //word1.Paragraphs[1].Range.InsertParagraphAfter();
                //word1.Paragraphs[1].Range.Text = "asaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                //word1.Footnotes.Location = Word.WdFootnoteLocation.wdBeneathText;
                //word1.Footnotes.NumberStyle = Word.WdNoteNumberStyle.wdNoteNumberStyleLowercaseRoman;
                //word1.Footnotes.Add(word1.Paragraphs[1].Range.Words[2].Characters[2], ref missing, ref text);
                Microsoft.Office.Interop.Word.Document doc = application.ActiveDocument;
                Microsoft.Office.Interop.Word.Range range = doc.Paragraphs[doc.Paragraphs.Count].Range;
                dataSetTemp = dbw1.ReadMetricsByReport(listView2.Items[listView2.SelectedIndices[0]].Text);
                doc.Tables.Add(range, dataSetTemp.Tables[0].Rows.Count + 1, 6, ref missing, ref missing);
                doc.Tables[1].Cell(1, 1).Range.Text = "NAME metric";
                doc.Tables[1].Cell(1, 2).Range.Text = "MIN value";
                doc.Tables[1].Cell(1, 3).Range.Text = "CUR value";
                doc.Tables[1].Cell(1, 4).Range.Text = "MAX value";
                doc.Tables[1].Cell(1, 5).Range.Text = "VALUE";
                doc.Tables[1].Cell(1, 6).Range.Text = "RATE";
                for (int i = 0; i < dataSetTemp.Tables[0].Rows.Count; i++)
                {
                    dataSetTemp1 = dbw1.ReadInfoMetricByReportMetric(listView2.Items[listView2.SelectedIndices[0]].Text, dataSetTemp.Tables[0].Rows[i].ItemArray[0].ToString());
                    doc.Tables[1].Cell(i + 2, 1).Range.Text = dataSetTemp.Tables[0].Rows[i].ItemArray[0].ToString();
                    doc.Tables[1].Cell(i + 2, 2).Range.Text = dataSetTemp1.Tables[0].Rows[0].ItemArray[2].ToString();
                    doc.Tables[1].Cell(i + 2, 3).Range.Text = dataSetTemp1.Tables[0].Rows[0].ItemArray[0].ToString();
                    doc.Tables[1].Cell(i + 2, 4).Range.Text = dataSetTemp1.Tables[0].Rows[0].ItemArray[3].ToString();
                    doc.Tables[1].Cell(i + 2, 5).Range.Text = Double.Parse(dataSetTemp1.Tables[0].Rows[0].ItemArray[4].ToString()).ToString("F5");
                    doc.Tables[1].Cell(i + 2, 6).Range.Text = dataSetTemp1.Tables[0].Rows[0].ItemArray[5].ToString();
                }
                doc.Tables[1].Columns.AutoFit();
                Word.Border[] borders = new Word.Border[6];
                Word.Table tbl = doc.Tables[doc.Tables.Count];
                borders[0] = tbl.Borders[Word.WdBorderType.wdBorderLeft];
                borders[1] = tbl.Borders[Word.WdBorderType.wdBorderRight];
                borders[2] = tbl.Borders[Word.WdBorderType.wdBorderTop];
                borders[3] = tbl.Borders[Word.WdBorderType.wdBorderBottom];
                borders[4] = tbl.Borders[Word.WdBorderType.wdBorderHorizontal];
                borders[5] = tbl.Borders[Word.WdBorderType.wdBorderVertical];
                foreach (Word.Border border in borders)
                {
                    border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    border.Color = Word.WdColor.wdColorBlack;
                }
                application.Documents[word1].SaveAs(saveFileDialog2.FileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                application.Quit();
                string info = "Doc file saved at\n" + saveFileDialog2.FileName;
                MessageBox.Show(this, info, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            PerformInfoUpdate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PerformInfoUpdate();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            PerformInfoUpdate();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            PerformInfoUpdate();
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int IndexOfReport = listView2.SelectedIndices[0];
            MeasureReport(listView2.Items[listView2.SelectedIndices[0]].Text);
            listView2_ReadReports();
            listView2.Items[IndexOfReport].Selected = true;
        }

        private void MeasureReport(string _name_report)
        {
            DataSet Factor = new DataSet();
            DataSet Criteria = new DataSet();
            DataSet Metric = new DataSet();
            DataSet Infa = new DataSet();
            double reportValue = 0.0;
            Factor = dbw1.ReadFartorsByReport(_name_report);
            for (int i = 0; i < Factor.Tables[0].Rows.Count; i++)
            {
                double factValue = 0.0;
                Criteria = dbw1.ReadCriteriasByReportFactor(_name_report, Factor.Tables[0].Rows[i].ItemArray[0].ToString());
                for (int j = 0; j < Criteria.Tables[0].Rows.Count; j++)
                {
                    double criteriaValue = 0.0;
                    Metric = dbw1.ReadMetricsByReportCriteria(_name_report, Criteria.Tables[0].Rows[j].ItemArray[0].ToString());
                    for (int k = 0; k < Metric.Tables[0].Rows.Count; k++)
                    {
                        Infa = dbw1.ReadInfoMetricByReportMetric(_name_report, Metric.Tables[0].Rows[k].ItemArray[0].ToString());
                        criteriaValue += Double.Parse(Infa.Tables[0].Rows[0].ItemArray[4].ToString()) * Double.Parse(Infa.Tables[0].Rows[0].ItemArray[5].ToString());
                    }
                    Infa = dbw1.ReadInfoCriteriaByReportCriteriaFactor(_name_report, Criteria.Tables[0].Rows[j].ItemArray[0].ToString(), Factor.Tables[0].Rows[i].ItemArray[0].ToString());
                    dbw1.UpdateCriteriaFactorInRep(_name_report, Criteria.Tables[0].Rows[j].ItemArray[0].ToString(), Factor.Tables[0].Rows[i].ItemArray[0].ToString(), Double.Parse(Infa.Tables[0].Rows[0].ItemArray[1].ToString()), criteriaValue);
                    factValue += criteriaValue * Double.Parse(Infa.Tables[0].Rows[0].ItemArray[1].ToString());
                }
                Infa = dbw1.ReadInfoFactorByReportFactor(_name_report, Factor.Tables[0].Rows[i].ItemArray[0].ToString());
                dbw1.UpdateFactorInRep(_name_report, Factor.Tables[0].Rows[i].ItemArray[0].ToString(), Double.Parse(Infa.Tables[0].Rows[0].ItemArray[1].ToString()), factValue);
                reportValue += factValue * Double.Parse(Infa.Tables[0].Rows[0].ItemArray[1].ToString());
            }
            dbw1.UpdateValueInRep(_name_report, reportValue);
            MessageBox.Show(this, "Measure complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            PerformInfoUpdate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            PerformInfoUpdate();
        }

        private void groupBox1_Resize(object sender, EventArgs e)
        {
            splitContainer4.Width = groupBox1.Width - 6;
            splitContainer4.Height = groupBox1.Height - 19;
        }

        private void splitContainer4_Panel1_Resize(object sender, EventArgs e)
        {
            int lenth = splitContainer4.Panel1.Width / 2;
            textBox1.Width = splitContainer4.Panel1.Width - 14;
            richTextBox5.Width = lenth - 20;
            maskedTextBox2.Width = lenth - 20;
            label2.Location = new Point(lenth - 30, label2.Location.Y);
            label6.Location = new Point(lenth - 30, label6.Location.Y);
            richTextBox5.Location = new Point(lenth + 17, richTextBox5.Location.Y);
            maskedTextBox2.Location = new Point(lenth + 17, maskedTextBox2.Location.Y);
            textBox2.Width = lenth - 160;
            textBox4.Width = lenth - 160;
            textBox3.Width = lenth - 160;
            maskedTextBox1.Width = lenth - 160;
        }

        private void splitContainer4_Panel2_Resize(object sender, EventArgs e)
        {
            richTextBox7.Width = splitContainer4.Panel2.Width - 8;
            richTextBox8.Width = splitContainer4.Panel2.Width - 8;
            richTextBox13.Width = splitContainer4.Panel2.Width - 8;
            int lenth = (splitContainer4.Panel2.Width - 10) / 5;
            button1.Location = new Point(5, button1.Location.Y);
            button1.Width = lenth * 2 - 2;
            button2.Location = new Point(lenth * 2 + 6, button2.Location.Y);
            button2.Width = lenth;
            button3.Location = new Point(lenth * 3 + 9, button3.Location.Y);
            button3.Width = (lenth - 1) * 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kiviatDiagramToolStripMenuItem.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkListToolStripMenuItem.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reportToolStripMenuItem1.PerformClick();
        }
    }
}
