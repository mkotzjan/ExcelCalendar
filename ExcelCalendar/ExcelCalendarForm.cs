using ExcelCalendar.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelCalendar
{
    public partial class ExcelCalendarForm : Form
    {
        private List<IPerson> persons;

        public ExcelCalendarForm()
        {
            InitializeComponent();
            persons = new List<IPerson>();
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
            else if (Options.showWeek == true && Options.week == -1)
            {
                MessageBox.Show("Bitte Schicht wählen.");
            }
            else
            {
                SaveFileDialog saveExcel = new SaveFileDialog();
                saveExcel.Filter = "Excel Worksheet|*.xls|Open Office Calc|*.ods";
                saveExcel.FilterIndex = 1;
                saveExcel.OverwritePrompt = false;

                if (saveExcel.ShowDialog() == DialogResult.OK)
                {
                    GenerateExcel.generate(saveExcel.FileName, persons);
                }
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
            Options.showWeek = weekCheckBox.Checked;
        }

        private void weekComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options.week = weekComboBox.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Geburtstagsliste.csv";
            openFileDialog1.Filter = "CSV (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                persons.Clear();

                try
                {
                    var lines = File.ReadAllLines(openFileDialog1.FileName);
                    foreach (var line in lines)
                    {
                        var tokens = line.Split(',');
                        persons.Add(new Person(tokens[0], tokens[1], DateTime.Parse(tokens[2])));
                    }
                 }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ein Fehler ist aufgetreten");
                    return;
                }

                var fileNameWithoutPath = Path.GetFileName(openFileDialog1.FileName);
                selectBirthdayFile.Text = fileNameWithoutPath + " ausgewählt";
            }

        }
    }
}
