using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhgDataProcessor
{
    public partial class frmSpikeDetector : Form
    {
        public frmSpikeDetector()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            string fileName="";
            
            if ( openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
            }
            
            if (fileName.Equals(string.Empty))
            {
                StreamReader file =
               new StreamReader(fileName);

                string line = "";

                while ((line = file.ReadLine()) != null)
                {


                }
            }
            
        } // end of function

        private void frmSpikeDetector_Load(object sender, EventArgs e)
        {
            cmbMeasure.SelectedIndex = 0;
        }
    }
}
