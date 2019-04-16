using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhgDataProcessor
{
    public partial class frmMainApp : Form
    {
        public frmMainApp()
        {
            InitializeComponent();
        }

        private void tStrip_Click(object sender, EventArgs e)
        {
            FormCollection openForms = Application.OpenForms;

            if ( sender == tStripDataProcessing)
            {
                foreach(Form frm in openForms)
                {
                    if ( frm is frmDataProcessor)
                    {
                        frm.Focus();
                        return;
                    }
                }

                frmDataProcessor newfrm = new frmDataProcessor();
                newfrm.MdiParent = this;
                newfrm.WindowState = FormWindowState.Maximized;
                newfrm.Show();
            }
            else if ( sender == tStripDatasetParser )
            {
                foreach (Form frm in openForms)
                {
                    if (frm is frmDataSetParsingAndCleaning)
                    {
                        frm.Focus();
                        return;
                    }
                }

                frmDataSetParsingAndCleaning newfrm = new frmDataSetParsingAndCleaning();
                newfrm.MdiParent = this;
                newfrm.WindowState = FormWindowState.Maximized;
                newfrm.Show();
            }

            else if (sender == tStripSpikeDetector)
            {
                foreach (Form frm in openForms)
                {
                    if (frm is frmSpikeDetector)
                    {
                        frm.Focus();
                        return;
                    }
                }

                frmSpikeDetector newfrm = new frmSpikeDetector();
                newfrm.MdiParent = this;
                newfrm.WindowState = FormWindowState.Maximized;
                newfrm.Show();
            }
            else if (sender == tStripTweetFreuencyDistribution)
            {
                foreach (Form frm in openForms)
                {
                    if (frm is frmTweetFrequencyDistributor)
                    {
                        frm.Focus();
                        return;
                    }
                }

                frmTweetFrequencyDistributor newfrm = new frmTweetFrequencyDistributor();
                newfrm.MdiParent = this;
                newfrm.WindowState = FormWindowState.Maximized;
                newfrm.Show();
            }
            else if (sender == tStripDataReduction)
            {
                foreach (Form frm in openForms)
                {
                    if (frm is frmReduceDataSet)
                    {
                        frm.Focus();
                        return;
                    }
                }

                frmReduceDataSet newfrm = new frmReduceDataSet();
                newfrm.MdiParent = this;
                newfrm.WindowState = FormWindowState.Maximized;
                newfrm.Show();
            }
        }
    }
}
