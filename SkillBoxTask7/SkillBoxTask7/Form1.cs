﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 7.8 Практическая работа

namespace SkillBoxTask7
{
    public partial class Form1 : Form
    {
        const char sep = '|';
        private bool up_to_down = true;

        public Form1()
        {
            InitializeComponent();
        }


        #region Внесение/изменение/удаление записей


        /// <summary>
        /// Обработка кнопки добавления сотрудника
        /// </summary>
        private void AddWorker_Click(object sender, EventArgs e)
        {
            // Проверка на возможные ошибки
            bool FileExist = File.Exists(FileName.Text);
            if (FileExist)
            {
                string[] strs = File.ReadAllLines(FileName.Text);
                try
                {
                    int last_idx = strs.Length - 1;
                    int first_sep_idx = strs[last_idx].IndexOf(sep);
                    uint last_id = Convert.ToUInt16(strs[last_idx].Remove(first_sep_idx));

                    Worker worker = new Worker(
                        last_id + 1,
                        DateTime.Now,
                        $"{Surname.Text} {NameTB.Text} {Patronymic.Text}",
                        Convert.ToUInt16(Age.Text),
                        Convert.ToUInt16(HeightTB.Text),
                        Convert.ToDateTime(DateOfBorn.Text),
                        PlaceOfBorn.Text);

                    File.AppendAllText(FileName.Text, $"{worker.info_to_write}\n");
                    FileOutput.Text = $"Следующая запись успешно создана и записана в файл:\n{worker.info_to_read}";
                }
                catch (System.IndexOutOfRangeException)
                {
                    FileOutput.Text =
                        $"Ошибка: System.IndexOutOfRangeException\n" +
                        $"Файл будет пересоздан.\n";
                    Worker worker = new Worker(
                                        1,
                                        DateTime.Now,
                                        $"{Surname.Text} {NameTB.Text} {Patronymic.Text}",
                                        Convert.ToUInt16(Age.Text),
                                        Convert.ToUInt16(HeightTB.Text),
                                        Convert.ToDateTime(DateOfBorn.Text),
                                        PlaceOfBorn.Text);
                    File.WriteAllText(FileName.Text, $"{worker.info_to_write}\n");
                    FileOutput.Text += $"\nСледующая запись успешно создана и записана в файл:\n{worker.info_to_read}";
                }
                catch (System.FormatException)
                {
                    FileOutput.Text =
                        $"Ошибка: System.FormatException.\n" +
                        $"Проверьте корректность введенных данных.";
                }
                catch (Exception ex)
                {
                    FileOutput.Text =
                        $"Ошибка: {ex.Message}.\n";
                }
            }
            else
            {
                Worker worker = new Worker(
                    1,
                    DateTime.Now,
                    $"{Surname.Text} {NameTB.Text} {Patronymic.Text}",
                    Convert.ToUInt16(Age.Text),
                    Convert.ToUInt16(HeightTB.Text),
                    Convert.ToDateTime(DateOfBorn.Text),
                    PlaceOfBorn.Text);
                File.WriteAllText(FileName.Text, $"{worker.info_to_write}\n");
                FileOutput.Text = $"Следующая запись успешно создана и записана в файл:\n{worker.info_to_read}";
            }
        }


        /// <summary>
        /// Обновление информации о работнике в файле по id, указанному в поле UpdateByID_TB 
        /// </summary>
        private void UpdateByID_BT_Click(object sender, EventArgs e)
        {
            int id = int.Parse(UpdateByID_TB.Text);
            if (!File.Exists(FileName.Text))
            {
                FileOutput.Text = "Файла не существует.";
            }
            else
            {
                var text = (File.ReadAllLines(FileName.Text)).ToList<string>();
                for (int i = 0; i < text.Count; i++)
                {
                    if (id == Convert.ToInt16((text[i].Split(sep))[0]))
                    {
                        Worker worker = new Worker(
                            Convert.ToUInt16(UpdateByID_TB.Text),
                            DateTime.Now,
                            $"{Surname.Text} {NameTB.Text} {Patronymic.Text}",
                            Convert.ToUInt16(Age.Text),
                            Convert.ToUInt16(HeightTB.Text),
                            Convert.ToDateTime(DateOfBorn.Text),
                            PlaceOfBorn.Text);
                        string old_info = text[i].Replace(sep, ' ');
                        text[i] = worker.info_to_write;
                        File.WriteAllLines(FileName.Text, text.ToArray<string>());
                        FileOutput.Text =
                            $"Замена записи:\n" +
                            $"{old_info}\n" +
                            $"на запись:\n" +
                            $"{worker.info_to_read}\n" +
                            $"произведена успешно";
                        break;
                    }
                    if (i == text.Count - 1)
                    {
                        FileOutput.Text = "Записи с таким id не существует.";
                    }
                }
            }
        }


        /// <summary>
        /// Удаление информации о сотруднике с конкретным id
        /// </summary>
        private void RemoveByID_BT_Click(object sender, EventArgs e)
        {
            int id = int.Parse(RemoveByID_TB.Text);
            if (!File.Exists(FileName.Text))
            {
                FileOutput.Text = "Файла не существует.";
            }
            else
            {
                var text = (File.ReadAllLines(FileName.Text)).ToList<string>();
                for (int i = 0; i < text.Count; i++)
                {
                    if (id == Convert.ToInt16((text[i].Split(sep))[0]))
                    {
                        FileOutput.Text = $"Удалена следующая запись:\n{text[i].Replace(sep, ' ')}\n\nОставшиеся записи:\n";
                        text.RemoveAt(i);
                        for (int j = 0; j < text.Count; j++)
                        {
                            FileOutput.Text += $"{text[j].Replace(sep, ' ')}\n";
                        }
                        File.WriteAllLines(FileName.Text, text.ToArray<string>());
                        break;
                    }
                    if (i == text.Count - 1)
                    {
                        FileOutput.Text = "Записи с таким id не существует.";
                    }
                }
            }
        }

        #endregion


        #region Чтение записей


        /// <summary>
        /// Чтение информации о сотруднике с конкретным id
        /// </summary>
        private void ReadByID_BT_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ReadByID_TB.Text);
            if (!File.Exists(FileName.Text))
            {
                FileOutput.Text = "Файла не существует.";
            }
            else
            {
                var text = (File.ReadAllLines(FileName.Text)).ToList<string>();
                for (int i = 0; i < text.Count; i++)
                {
                    if (id == Convert.ToInt16((text[i].Split(sep))[0]))
                    {
                        FileOutput.Text = $"Запись с id = {ReadByID_TB.Text}:\n{text[i].Replace(sep, ' ')}";
                        break;
                    }
                    if (i == text.Count - 1)
                    {
                        FileOutput.Text = "Записи с таким id не существует.";
                    }
                }
            }
        }


        /// <summary>
        /// Обработка кнопки чтения указанного файла
        /// </summary>
        private void ReadFile_Click(object sender, EventArgs e)
        {
            bool FileExist = File.Exists(FileName.Text);
            if (FileExist)
            {
                FileOutput.Text = "Начало чтения файла:\n";
                string[] text = File.ReadAllLines(FileName.Text);
                for (int i = 0; i < text.Length; i++)
                {
                    FileOutput.Text += $"{text[i].Replace(sep, ' ')}\n";
                }
                FileOutput.Text += "Конец чтения файла.";
            }
            else
            {
                FileOutput.Text = "Файла не существует.";
            }
        }


        /// <summary>
        /// Чтение по указанному диапазону дат
        /// </summary>
        private void ReadByDate_BT_Click(object sender, EventArgs e)
        {
            bool FileExist = File.Exists(FileName.Text);
            if (FileExist)
            {
                FileOutput.Text = "Начало чтения файла:\n";
                try
                {
                    string[] text = File.ReadAllLines(FileName.Text);
                    List<Worker> workers = new List<Worker>();
                    List<DateTime> dates = new List<DateTime>();
                    DateTime min = Convert.ToDateTime(StartDate_TB.Text);
                    DateTime max = Convert.ToDateTime(EndDate_TB.Text);

                    // Отсекаем ненужные даты
                    for (int i = 0; i < text.Length; i++)
                    {
                        Worker worker = new Worker(text[i]);
                        if (worker.Date > min && worker.Date < max)
                        {
                            workers.Add(new Worker(text[i]));
                            dates.Add(workers[i].Date);
                        }
                    }


                    // Сортировка полученного по выбранному принципу
                    for (int i = 0; i < dates.Count - 1; i++)
                    {
                        for (int j = i + 1; j < dates.Count; j++)
                        {
                            // Сортировка сверху-вниз
                            if (up_to_down)
                            {
                                if (dates[j] < dates[i])
                                {
                                    var date_buf = dates[j];
                                    dates[j] = dates[i];
                                    dates[i] = date_buf;

                                    var worker_buf = workers[j];
                                    workers[j] = workers[i];
                                    workers[i] = worker_buf;
                                }
                            }
                            // Сортировка снизу-вверх
                            else
                            {
                                if (dates[j] > dates[i])
                                {
                                    var date_buf = dates[j];
                                    dates[j] = dates[i];
                                    dates[i] = date_buf;

                                    var worker_buf = workers[j];
                                    workers[j] = workers[i];
                                    workers[i] = worker_buf;
                                }
                            }
                        }
                    }
                    foreach (var w in workers)
                    {
                        FileOutput.Text += $"{w.info_to_read}\n";
                    }
                    FileOutput.Text += "Конец чтения файла.";
                }
                catch (Exception ex)
                {
                    FileOutput.Text =
                        $"Ошибка:\n" +
                        $"{ex.Message}\n" +
                        $"Чтение файла невозможно.";
                }
            }
            else
            {
                if (!FileExist)
                    FileOutput.Text = "Файл не существует.\n";
            }
        }


        /// <summary>
        /// Указание сортировки: по возрастанию дат/по уменьшению дат + ее применение
        /// </summary>
        private void UpDownSort_BT_Click(object sender, EventArgs e)
        {
            if (up_to_down)
            {
                up_to_down = !up_to_down;
                UpDownSort_BT.Text = "Снизу-вверх";
            }
            else
            {
                up_to_down = !up_to_down;
                UpDownSort_BT.Text = "Сверху-вниз";
            }
            ReadByDate_BT_Click(sender, e);
        }

        #endregion
    }
}
