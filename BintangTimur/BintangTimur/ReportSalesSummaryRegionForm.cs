﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Draco
{
    public partial class ReportSalesSummaryRegionForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public ReportSalesSummaryRegionForm()
        {
            InitializeComponent();
        }

        private void ReportSalesSummaryRegionForm_Load(object sender, EventArgs e)
        {
            DataSet dsTempReport = new DataSet();
            try
            {
                string appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.penjualanRegionXML;
                dsTempReport.ReadXml(@appPath);

                //prepare report for preview
                ReportSalesSummaryRegion rptXMLReport = new ReportSalesSummaryRegion();
                CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2;
                txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                String nama, alamat, telepon, email;
                if (!gutil.loadinfotoko(2, out nama, out alamat, out telepon, out email))
                {
                    //reset default optsi = 1
                    if (!gutil.loadinfotoko(1, out nama, out alamat, out telepon, out email))
                    {
                        nama = "TOKO DEFAULT";
                        alamat = "ALAMAT DEFAULT";
                        telepon = "0271-XXXXXXX";
                        email = "A@B.COM";
                    }
                }
                txtReportHeader1.Text = nama;
                txtReportHeader2.Text = alamat + Environment.NewLine + telepon + Environment.NewLine + email;
                rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptXMLReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
