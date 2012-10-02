using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportSystem
{
    public partial class Form5 : Form
    {
        DBwork dbw1 = new DBwork(SqlConnectionParametrs.DataBaseName, SqlConnectionParametrs.DataBaseServiceName);
        private DataSet dataSet1;
        double[] parametrs = new double[0];
        Point[] pointParametrs;
        Point[] middlePoints;
        Point[] smallPoints;
        Point[] namePoints;
        Point[] percent75;
        Point[] percent25;
        Point[] percent100;
        System.Windows.Forms.Label[] nameLable;

        string g_reportName;

        public Form5(string reportName)
        {
            g_reportName = reportName;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            DataSet dataSet1 = dbw1.ReadDataBaseToDataSet("QUIM", "select progName, CreationD_rep, percofend from Report where progName LIKE '" + g_reportName + "'");
            this.Text = dataSet1.Tables[0].Rows[0].ItemArray[0].ToString() + " " + dataSet1.Tables[0].Rows[0].ItemArray[1].ToString();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            /*
            if (nameLable != null)
            {
                for (int i = 0; i < nameLable.Count(); i++)
                {
                    this.Controls.Remove(nameLable[i]);
                    nameLable[i].Dispose();
                }
            }
            nameLable = null;
            */
            double zoom = 1.0;
            int numberOfLines = parametrs.Length;
            float cornerPerLine = 0;
            pointParametrs = new Point[parametrs.Length];
            middlePoints = new Point[parametrs.Length];
            smallPoints = new Point[parametrs.Length];
            namePoints = new Point[parametrs.Length];
            nameLable = new Label[parametrs.Length];
            percent25 = new Point[parametrs.Length];
            percent75 = new Point[parametrs.Length];
            percent100 = new Point[parametrs.Length];
            if (numberOfLines != 0)
                cornerPerLine = 360 / numberOfLines;
            Graphics G;
            G = e.Graphics;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen P;
            SolidBrush SB;
            P = new Pen(Color.Black, 1);
            SB = new SolidBrush(Color.LightGreen);
            G.DrawArc(P, (int)(382 * zoom), (int)(19 * zoom), (int)(566 * zoom), (int)(566 * zoom), 0, 360);
            G.FillEllipse(SB, (int)(382 * zoom), (int)(19 * zoom), (int)(566 * zoom), (int)(566 * zoom));
            SB.Color = Color.Red;
            G.FillEllipse(SB, (int)(664 * zoom), (int)(301 * zoom), 4, 4);
            for (int i = 0; i < numberOfLines; i++)
            {
                G.ResetTransform();
                G.TranslateTransform((int)(666 * zoom), (int)(303 * zoom));
                G.RotateTransform(cornerPerLine * i);
                P.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                G.DrawLine(P, 0, 0, (int)(290 * zoom), 0);
                P.EndCap = System.Drawing.Drawing2D.LineCap.Flat;
                SB.Color = Color.Black;
                SB.Color = Color.Red;
                P.Color = Color.Red;
                G.DrawEllipse(P, ((int)(283 * zoom) * (float)parametrs[i]) - 1, -1, 2, 2);
                P.Color = Color.Black;
                if ((cornerPerLine * i) == 0)
                {
                    pointParametrs[i].X = Convert.ToInt32(283 * (float)parametrs[i]);
                    pointParametrs[i].Y = 0;
                    middlePoints[i].X = Convert.ToInt32(140);
                    middlePoints[i].Y = 0;
                    smallPoints[i].X = Convert.ToInt32(28);
                    smallPoints[i].Y = 0;
                    namePoints[i].X = Convert.ToInt32(293);
                    namePoints[i].Y = -7;
                    //////
                    percent25[i].X = Convert.ToInt32(71);
                    percent25[i].Y = 0;
                    percent75[i].X = Convert.ToInt32(212);
                    percent75[i].Y = 0;
                    percent100[i].X = Convert.ToInt32(283);
                    percent100[i].Y = 0;
                    //////
                }
                if (((cornerPerLine * i) < 90) && ((cornerPerLine * i) > 0))
                {
                    pointParametrs[i].X = Convert.ToInt32(Math.Cos(Math.PI * (cornerPerLine * i) / 180) * (283 * (float)parametrs[i]));
                    pointParametrs[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (cornerPerLine * i) / 180) * (283 * (float)parametrs[i]));
                    middlePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (cornerPerLine * i) / 180) * (140));
                    middlePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (cornerPerLine * i) / 180) * (140));
                    smallPoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (cornerPerLine * i) / 180) * (28));
                    smallPoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (cornerPerLine * i) / 180) * (28));
                    namePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (cornerPerLine * i) / 180) * (293));
                    namePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (cornerPerLine * i) / 180) * (293));
                    /////////
                    percent25[i].X = Convert.ToInt32(Math.Cos(Math.PI * (cornerPerLine * i) / 180) * (71));
                    percent25[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (cornerPerLine * i) / 180) * (71));
                    percent75[i].X = Convert.ToInt32(Math.Cos(Math.PI * (cornerPerLine * i) / 180) * (212));
                    percent75[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (cornerPerLine * i) / 180) * (212));
                    percent100[i].X = Convert.ToInt32(Math.Cos(Math.PI * (cornerPerLine * i) / 180) * (283));
                    percent100[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (cornerPerLine * i) / 180) * (283));
                    /////////
                }
                if ((cornerPerLine * i) == 90)
                {
                    pointParametrs[i].X = 0;
                    pointParametrs[i].Y = Convert.ToInt32(283 * (float)parametrs[i]);
                    middlePoints[i].X = 0;
                    middlePoints[i].Y = Convert.ToInt32(140);
                    smallPoints[i].X = 0;
                    smallPoints[i].Y = Convert.ToInt32(28);
                    namePoints[i].Y = Convert.ToInt32(293);
                    namePoints[i].X = -7;
                    ///////////
                    percent25[i].X = 0;
                    percent25[i].Y = Convert.ToInt32(71);
                    percent75[i].X = 0;
                    percent75[i].Y = Convert.ToInt32(212);
                    percent100[i].X = 0;
                    percent100[i].Y = Convert.ToInt32(283);
                    ///////////
                }
                if (((cornerPerLine * i) > 90) && ((cornerPerLine * i) < 180))
                {
                    pointParametrs[i].X = Convert.ToInt32(Math.Cos(Math.PI * (180 - cornerPerLine * i) / 180) * (-283 * (float)parametrs[i]));
                    pointParametrs[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (180 - cornerPerLine * i) / 180) * (283 * (float)parametrs[i]));
                    middlePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (180 - cornerPerLine * i) / 180) * (-140));
                    middlePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (180 - cornerPerLine * i) / 180) * (140));
                    smallPoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (180 - cornerPerLine * i) / 180) * (-28));
                    smallPoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (180 - cornerPerLine * i) / 180) * (28));
                    string temp = checkedListBox1.CheckedItems[i].ToString();
                    temp.Count();
                    namePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (180 - cornerPerLine * i) / 180) * (-283)) - 6 * temp.Count();
                    namePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (180 - cornerPerLine * i) / 180) * (293));
                    ////////
                    percent25[i].X = Convert.ToInt32(Math.Cos(Math.PI * (180 - cornerPerLine * i) / 180) * (-71));
                    percent25[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (180 - cornerPerLine * i) / 180) * (71));
                    percent75[i].X = Convert.ToInt32(Math.Cos(Math.PI * (180 - cornerPerLine * i) / 180) * (-212));
                    percent75[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (180 - cornerPerLine * i) / 180) * (212));
                    percent100[i].X = Convert.ToInt32(Math.Cos(Math.PI * (180 - cornerPerLine * i) / 180) * (-283));
                    percent100[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (180 - cornerPerLine * i) / 180) * (283));
                    ////////
                }
                if ((cornerPerLine * i) == 180)
                {
                    pointParametrs[i].X = Convert.ToInt32(-283 * (float)parametrs[i]);
                    pointParametrs[i].Y = 0;
                    middlePoints[i].X = Convert.ToInt32(-140);
                    middlePoints[i].Y = 0;
                    smallPoints[i].X = Convert.ToInt32(-28);
                    smallPoints[i].Y = 0;
                    string temp = checkedListBox1.CheckedItems[i].ToString();
                    temp.Count();
                    namePoints[i].X = Convert.ToInt32(-283 - 7 * temp.Count());
                    namePoints[i].Y = -7;
                    //////////
                    percent25[i].X = Convert.ToInt32(-71);
                    percent25[i].Y = 0;
                    percent75[i].X = Convert.ToInt32(-212);
                    percent75[i].Y = 0;
                    percent100[i].X = Convert.ToInt32(-283);
                    percent100[i].Y = 0;
                    //////////
                }
                if (((cornerPerLine * i) > 180) && ((cornerPerLine * i) < 270))
                {
                    pointParametrs[i].X = Convert.ToInt32(Math.Cos(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-283 * (float)parametrs[i]));
                    pointParametrs[i].Y = Convert.ToInt32(Math.Sin(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-283 * (float)parametrs[i]));
                    middlePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-140));
                    middlePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-140));
                    smallPoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-28));
                    smallPoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-28));
                    string temp = checkedListBox1.CheckedItems[i].ToString();
                    temp.Count();
                    namePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-283)) - 7 * temp.Count();
                    namePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-303));
                    ///////////
                    percent25[i].X = Convert.ToInt32(Math.Cos(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-71));
                    percent25[i].Y = Convert.ToInt32(Math.Sin(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-71));
                    percent75[i].X = Convert.ToInt32(Math.Cos(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-212));
                    percent75[i].Y = Convert.ToInt32(Math.Sin(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-212));
                    percent100[i].X = Convert.ToInt32(Math.Cos(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-283));
                    percent100[i].Y = Convert.ToInt32(Math.Sin(Math.PI * ((cornerPerLine * i) - 180) / 180) * (-283));
                    ///////////
                }
                if ((cornerPerLine * i) == 270)
                {
                    pointParametrs[i].X = 0;
                    pointParametrs[i].Y = Convert.ToInt32(-283 * (float)parametrs[i]);
                    middlePoints[i].X = 0;
                    middlePoints[i].Y = Convert.ToInt32(-140);
                    smallPoints[i].X = 0;
                    smallPoints[i].Y = Convert.ToInt32(-28);
                    namePoints[i].Y = Convert.ToInt32(-303);
                    namePoints[i].X = -7;
                    ////////
                    percent25[i].X = 0;
                    percent25[i].Y = Convert.ToInt32(-71);
                    percent75[i].X = 0;
                    percent75[i].Y = Convert.ToInt32(-212);
                    percent100[i].X = 0;
                    percent100[i].Y = Convert.ToInt32(-283);
                    ////////
                }
                if (((cornerPerLine * i) > 270) && ((cornerPerLine * i) < 360))
                {
                    pointParametrs[i].X = Convert.ToInt32(Math.Cos(Math.PI * (360 - cornerPerLine * i) / 180) * (283 * (float)parametrs[i]));
                    pointParametrs[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (360 - cornerPerLine * i) / 180) * (-283 * (float)parametrs[i]));
                    middlePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (360 - cornerPerLine * i) / 180) * (140));
                    middlePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (360 - cornerPerLine * i) / 180) * (-140));
                    smallPoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (360 - cornerPerLine * i) / 180) * (28));
                    smallPoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (360 - cornerPerLine * i) / 180) * (-28));
                    namePoints[i].X = Convert.ToInt32(Math.Cos(Math.PI * (360 - cornerPerLine * i) / 180) * (293));
                    namePoints[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (360 - cornerPerLine * i) / 180) * (-303));
                    /////////
                    percent25[i].X = Convert.ToInt32(Math.Cos(Math.PI * (360 - cornerPerLine * i) / 180) * (71));
                    percent25[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (360 - cornerPerLine * i) / 180) * (-71));
                    percent75[i].X = Convert.ToInt32(Math.Cos(Math.PI * (360 - cornerPerLine * i) / 180) * (212));
                    percent75[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (360 - cornerPerLine * i) / 180) * (-212));
                    percent100[i].X = Convert.ToInt32(Math.Cos(Math.PI * (360 - cornerPerLine * i) / 180) * (283));
                    percent100[i].Y = Convert.ToInt32(Math.Sin(Math.PI * (360 - cornerPerLine * i) / 180) * (-283));
                    /////////
                }
                if ((cornerPerLine * i) == 360)
                {
                    pointParametrs[i].X = Convert.ToInt32(283 * (float)parametrs[i]);
                    pointParametrs[i].Y = 0;
                    middlePoints[i].X = Convert.ToInt32(140);
                    middlePoints[i].Y = 0;
                    smallPoints[i].X = Convert.ToInt32(28);
                    smallPoints[i].Y = 0;
                    namePoints[i].X = Convert.ToInt32(283);
                    namePoints[i].Y = 0;
                    //////
                    percent25[i].X = Convert.ToInt32(71);
                    percent25[i].Y = 0;
                    percent25[i].X = Convert.ToInt32(212);
                    percent25[i].Y = 0;
                    percent100[i].X = Convert.ToInt32(283);
                    percent100[i].Y = 0;
                    //////
                }
                namePoints[i].X += 666;
                namePoints[i].Y += 303;
            }
            G.ResetTransform();
            G.TranslateTransform(666, 303);
            if (numberOfLines > 1)
            {            
                SB.Color = Color.GreenYellow;
                G.FillPolygon(SB, middlePoints);
                SB.Color = Color.Coral;
                G.FillPolygon(SB, smallPoints);
                P.Color = Color.Red;
                P.Width = 5;
                G.DrawPolygon(P, pointParametrs);
                P.Width = 1;
                P.Color = Color.Black;
            }
            for (int i = 0; i < numberOfLines; i++)
            {
                G.ResetTransform();
                G.TranslateTransform(666, 303);
                G.RotateTransform(cornerPerLine * i);
                G.DrawLine(P, 0, 0, 290, 0);
                P.Color = Color.Red;
                G.DrawEllipse(P, (283 * (float)parametrs[i]) - 1, -1, 2, 2);
                P.Color = Color.Black;
            }
            for (int i = 0; i < numberOfLines; i++)
            {
                G.ResetTransform();
                SB.Color = Color.Black;
                G.DrawString(checkedListBox1.CheckedItems[i].ToString(), new Font("Times", 10), SB, namePoints[i]);
            }
            if (numberOfLines > 1)
            {
                G.ResetTransform();
                G.TranslateTransform(666, 303);
                P.Width = 1;
                P.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                G.DrawPolygon(P, percent25);
                G.DrawPolygon(P, percent75);
                G.DrawPolygon(P, percent100);
                P.Width = 1;
            }
            G.ResetTransform();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                dataSet1 = dbw1.ReadFartorsByReport(g_reportName);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                dataSet1 = dbw1.ReadCriteriasByReport(g_reportName);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                dataSet1 = dbw1.ReadMetricsByReport(g_reportName);
            }
            parametrs = new double[0];
            this.Invalidate();
            for (int i = 0; i < dataSet1.Tables[0].Rows.Count; i++)
            {
                checkedListBox1.Items.Add(dataSet1.Tables[0].Rows[i].ItemArray[0].ToString(), false);
            }
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Invalidate();
            parametrs = new double[checkedListBox1.CheckedIndices.Count];
            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
                {
                    dataSet1 = dbw1.ReadInfoFactorByReportFactor(g_reportName, checkedListBox1.CheckedItems[i].ToString());
                    parametrs[i] = Double.Parse(dataSet1.Tables[0].Rows[0].ItemArray[0].ToString());
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
                {
                    dataSet1 = dbw1.ReadInfoCriteriaByReportCriteriaFactor(g_reportName, checkedListBox1.CheckedItems[i].ToString(), "%");
                    parametrs[i] = Double.Parse(dataSet1.Tables[0].Rows[0].ItemArray[0].ToString());
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
                {
                    dataSet1 = dbw1.ReadInfoMetricByReportMetric(g_reportName, checkedListBox1.CheckedItems[i].ToString());
                    parametrs[i] = Double.Parse(dataSet1.Tables[0].Rows[0].ItemArray[4].ToString());
                }
            }
            Invalidate();
        }
    }
}
