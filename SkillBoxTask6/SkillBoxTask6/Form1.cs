using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillBoxTask6
{
    public partial class Form1 : Form
    {
        // Для гибкости
        private char sep = '|';

        public Form1()
        {
            InitializeComponent();
        }

        private void AddWorker_Click(object sender, EventArgs e)
        {
            string current_time = DateTime.Now.ToString("dd.MM.yyyy hh:mm");
            string FullName = $"{Surname.Text} {NameTB.Text} {Patronymic.Text}";

            if (File.Exists(FileName.Text))
            {
                string[] strs = File.ReadAllLines(FileName.Text);
                int last_idx = strs.Length - 1;
                int first_sep_idx = strs[last_idx].IndexOf(sep);

                int last_id = Convert.ToInt16(strs[last_idx].Remove(first_sep_idx));
                string to_add = 
                    $"{last_id + 1}{sep}" +
                    $"{current_time}{sep}" +
                    $"{FullName}{sep}{Age.Text}" +
                    $"{sep}{HeightTB.Text}{sep}" +
                    $"{DateOfBorn.Text}{sep}" +
                    $"{PlaceOfBorn.Text}";
                File.AppendAllText(FileName.Text, $"{to_add}\n");
            }
            else
            {
                string to_add = 
                    $"1{sep}" +
                    $"{current_time}{sep}" +
                    $"{FullName}{sep}" +
                    $"{Age.Text}{sep}" +
                    $"{HeightTB.Text}{sep}" +
                    $"{DateOfBorn.Text}{sep}" +
                    $"{PlaceOfBorn.Text}";
                File.WriteAllText(FileName.Text, $"{to_add}\n");
            }
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(FileName.Text))
            {
                FileOutput.Text = "";
                string[] text = File.ReadAllLines(FileName.Text);
                for (int i = 0; i < text.Length; i++)
                {
                    FileOutput.Text += $"{text[i].Replace(sep, ' ')}\n";
                }
            }
            else
            {
                FileOutput.Text = "File isn`t exist.";
            }
        }
    }
}
