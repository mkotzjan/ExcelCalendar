using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelCalendar
{
    public partial class ExcelCalendarForm : Form
    {
        public ExcelCalendarForm()
        {
            InitializeComponent();
        }

        private void ExcelCalendarForm_Load(object sender, EventArgs e)
        {

        }

        private void generateExcel_Click(object sender, EventArgs e)
        {
            if (Options.year < 2000 && Options.showHoliday == true)
            {
                MessageBox.Show("Keine Ferien in Datenbank vorhanden.");
                Options.showHoliday = false;
                holidayCheckBox.Checked = false;
            }
            SaveFileDialog saveExcel = new SaveFileDialog();
            saveExcel.Filter = "Excel Worksheet|*.xls";
            saveExcel.FilterIndex = 1;
            saveExcel.OverwritePrompt = false;

            if(saveExcel.ShowDialog() == DialogResult.OK)
            {
                GenerateExcel.generate(saveExcel.FileName);
            }
        }

        private void yearUpDown_ValueChanged(object sender, EventArgs e)
        {
            Options.year = (int)yearUpDown.Value;
        }

        private void tableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void feastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Options.showFeast = feastCheckBox.Checked;
        }

        private void holidayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Options.showHoliday = holidayCheckBox.Checked;
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void weekCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
