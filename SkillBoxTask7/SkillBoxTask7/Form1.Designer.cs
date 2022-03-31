namespace SkillBoxTask7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WorkerInfo = new System.Windows.Forms.GroupBox();
            this.UpdateByID_BT = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.TextBox();
            this.UpdateByID_TB = new System.Windows.Forms.TextBox();
            this.AddWorker = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.Patronymic = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.Age = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.HeightTB = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.DateOfBorn = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.PlaceOfBorn = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Surname = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FileOutput = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UpDownSort_BT = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.EndDate_TB = new System.Windows.Forms.TextBox();
            this.ReadFile = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.ReadByDate_BT = new System.Windows.Forms.Button();
            this.StartDate_TB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReadByID_BT = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.RemoveByID_TB = new System.Windows.Forms.TextBox();
            this.RemoveByID_BT = new System.Windows.Forms.Button();
            this.ReadByID_TB = new System.Windows.Forms.TextBox();
            this.WorkerInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkerInfo
            // 
            this.WorkerInfo.Controls.Add(this.UpdateByID_BT);
            this.WorkerInfo.Controls.Add(this.FileName);
            this.WorkerInfo.Controls.Add(this.UpdateByID_TB);
            this.WorkerInfo.Controls.Add(this.AddWorker);
            this.WorkerInfo.Controls.Add(this.textBox3);
            this.WorkerInfo.Controls.Add(this.NameTB);
            this.WorkerInfo.Controls.Add(this.textBox14);
            this.WorkerInfo.Controls.Add(this.Patronymic);
            this.WorkerInfo.Controls.Add(this.textBox12);
            this.WorkerInfo.Controls.Add(this.Age);
            this.WorkerInfo.Controls.Add(this.textBox10);
            this.WorkerInfo.Controls.Add(this.HeightTB);
            this.WorkerInfo.Controls.Add(this.textBox8);
            this.WorkerInfo.Controls.Add(this.DateOfBorn);
            this.WorkerInfo.Controls.Add(this.textBox6);
            this.WorkerInfo.Controls.Add(this.PlaceOfBorn);
            this.WorkerInfo.Controls.Add(this.textBox4);
            this.WorkerInfo.Controls.Add(this.Surname);
            this.WorkerInfo.Controls.Add(this.textBox1);
            this.WorkerInfo.Location = new System.Drawing.Point(12, 12);
            this.WorkerInfo.Name = "WorkerInfo";
            this.WorkerInfo.Size = new System.Drawing.Size(278, 285);
            this.WorkerInfo.TabIndex = 0;
            this.WorkerInfo.TabStop = false;
            this.WorkerInfo.Text = "Добавление сотрудника";
            // 
            // UpdateByID_BT
            // 
            this.UpdateByID_BT.Location = new System.Drawing.Point(6, 256);
            this.UpdateByID_BT.Name = "UpdateByID_BT";
            this.UpdateByID_BT.Size = new System.Drawing.Size(86, 23);
            this.UpdateByID_BT.TabIndex = 17;
            this.UpdateByID_BT.Text = "Обновить ID:";
            this.UpdateByID_BT.UseVisualStyleBackColor = true;
            this.UpdateByID_BT.Click += new System.EventHandler(this.UpdateByID_BT_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(140, 225);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(128, 23);
            this.FileName.TabIndex = 16;
            this.FileName.Text = "Отдел продаж.txt";
            // 
            // UpdateByID_TB
            // 
            this.UpdateByID_TB.Location = new System.Drawing.Point(98, 256);
            this.UpdateByID_TB.Name = "UpdateByID_TB";
            this.UpdateByID_TB.Size = new System.Drawing.Size(36, 23);
            this.UpdateByID_TB.TabIndex = 22;
            this.UpdateByID_TB.Text = "1";
            // 
            // AddWorker
            // 
            this.AddWorker.Location = new System.Drawing.Point(140, 256);
            this.AddWorker.Name = "AddWorker";
            this.AddWorker.Size = new System.Drawing.Size(128, 23);
            this.AddWorker.TabIndex = 16;
            this.AddWorker.Text = "Создание записи";
            this.AddWorker.UseVisualStyleBackColor = true;
            this.AddWorker.Click += new System.EventHandler(this.AddWorker_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 225);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(128, 23);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Имя файла:";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(140, 51);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(128, 23);
            this.NameTB.TabIndex = 14;
            this.NameTB.Text = "Всеволод";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(6, 51);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(128, 23);
            this.textBox14.TabIndex = 13;
            this.textBox14.Text = "Имя:";
            // 
            // Patronymic
            // 
            this.Patronymic.Location = new System.Drawing.Point(140, 80);
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.Size = new System.Drawing.Size(128, 23);
            this.Patronymic.TabIndex = 12;
            this.Patronymic.Text = "Романович";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(6, 80);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(128, 23);
            this.textBox12.TabIndex = 11;
            this.textBox12.Text = "Отчество:";
            // 
            // Age
            // 
            this.Age.Location = new System.Drawing.Point(140, 109);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(128, 23);
            this.Age.TabIndex = 10;
            this.Age.Text = "23";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(6, 109);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(128, 23);
            this.textBox10.TabIndex = 9;
            this.textBox10.Text = "Возраст:";
            // 
            // HeightTB
            // 
            this.HeightTB.Location = new System.Drawing.Point(140, 138);
            this.HeightTB.Name = "HeightTB";
            this.HeightTB.Size = new System.Drawing.Size(128, 23);
            this.HeightTB.TabIndex = 8;
            this.HeightTB.Text = "182";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(6, 138);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(128, 23);
            this.textBox8.TabIndex = 7;
            this.textBox8.Text = "Рост (см):";
            // 
            // DateOfBorn
            // 
            this.DateOfBorn.Location = new System.Drawing.Point(140, 167);
            this.DateOfBorn.Name = "DateOfBorn";
            this.DateOfBorn.Size = new System.Drawing.Size(128, 23);
            this.DateOfBorn.TabIndex = 6;
            this.DateOfBorn.Text = "08.01.1999";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 167);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(128, 23);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = "Дата рождения:";
            // 
            // PlaceOfBorn
            // 
            this.PlaceOfBorn.Location = new System.Drawing.Point(140, 196);
            this.PlaceOfBorn.Name = "PlaceOfBorn";
            this.PlaceOfBorn.Size = new System.Drawing.Size(128, 23);
            this.PlaceOfBorn.TabIndex = 4;
            this.PlaceOfBorn.Text = "г. Нижний Новгород";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 196);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(128, 23);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "Место рождения:";
            // 
            // Surname
            // 
            this.Surname.Location = new System.Drawing.Point(140, 22);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(128, 23);
            this.Surname.TabIndex = 2;
            this.Surname.Text = "Пинчук";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(128, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Фамилия:";
            // 
            // FileOutput
            // 
            this.FileOutput.Location = new System.Drawing.Point(6, 20);
            this.FileOutput.Name = "FileOutput";
            this.FileOutput.ReadOnly = true;
            this.FileOutput.Size = new System.Drawing.Size(620, 314);
            this.FileOutput.TabIndex = 1;
            this.FileOutput.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UpDownSort_BT);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Controls.Add(this.FileOutput);
            this.groupBox2.Controls.Add(this.EndDate_TB);
            this.groupBox2.Controls.Add(this.ReadFile);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.ReadByDate_BT);
            this.groupBox2.Controls.Add(this.StartDate_TB);
            this.groupBox2.Location = new System.Drawing.Point(296, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 374);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Чтение файла";
            // 
            // UpDownSort_BT
            // 
            this.UpDownSort_BT.Location = new System.Drawing.Point(531, 341);
            this.UpDownSort_BT.Name = "UpDownSort_BT";
            this.UpDownSort_BT.Size = new System.Drawing.Size(95, 23);
            this.UpDownSort_BT.TabIndex = 26;
            this.UpDownSort_BT.Text = "Сверху-вниз";
            this.UpDownSort_BT.UseVisualStyleBackColor = true;
            this.UpDownSort_BT.Click += new System.EventHandler(this.UpDownSort_BT_Click);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(420, 341);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(25, 23);
            this.textBox15.TabIndex = 24;
            this.textBox15.Text = "до:";
            // 
            // EndDate_TB
            // 
            this.EndDate_TB.Location = new System.Drawing.Point(451, 341);
            this.EndDate_TB.Name = "EndDate_TB";
            this.EndDate_TB.Size = new System.Drawing.Size(74, 23);
            this.EndDate_TB.TabIndex = 25;
            this.EndDate_TB.Text = "30.04.2022";
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(6, 341);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(133, 23);
            this.ReadFile.TabIndex = 17;
            this.ReadFile.Text = "Прочитать весь файл";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(309, 341);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(25, 23);
            this.textBox11.TabIndex = 22;
            this.textBox11.Text = "от:";
            // 
            // ReadByDate_BT
            // 
            this.ReadByDate_BT.Location = new System.Drawing.Point(145, 341);
            this.ReadByDate_BT.Name = "ReadByDate_BT";
            this.ReadByDate_BT.Size = new System.Drawing.Size(159, 23);
            this.ReadByDate_BT.TabIndex = 19;
            this.ReadByDate_BT.Text = "Прочитать файл по датам";
            this.ReadByDate_BT.UseVisualStyleBackColor = true;
            this.ReadByDate_BT.Click += new System.EventHandler(this.ReadByDate_BT_Click);
            // 
            // StartDate_TB
            // 
            this.StartDate_TB.Location = new System.Drawing.Point(340, 341);
            this.StartDate_TB.Name = "StartDate_TB";
            this.StartDate_TB.Size = new System.Drawing.Size(74, 23);
            this.StartDate_TB.TabIndex = 23;
            this.StartDate_TB.Text = "08.01.1999";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReadByID_BT);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.RemoveByID_TB);
            this.groupBox3.Controls.Add(this.RemoveByID_BT);
            this.groupBox3.Controls.Add(this.ReadByID_TB);
            this.groupBox3.Location = new System.Drawing.Point(12, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 83);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Работа с записями";
            // 
            // ReadByID_BT
            // 
            this.ReadByID_BT.Location = new System.Drawing.Point(140, 20);
            this.ReadByID_BT.Name = "ReadByID_BT";
            this.ReadByID_BT.Size = new System.Drawing.Size(128, 23);
            this.ReadByID_BT.TabIndex = 21;
            this.ReadByID_BT.Text = "Прочитать по ID:";
            this.ReadByID_BT.UseVisualStyleBackColor = true;
            this.ReadByID_BT.Click += new System.EventHandler(this.ReadByID_BT_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(6, 51);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(25, 23);
            this.textBox9.TabIndex = 21;
            this.textBox9.Text = "ID:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(6, 22);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(25, 23);
            this.textBox7.TabIndex = 17;
            this.textBox7.Text = "ID:";
            // 
            // RemoveByID_TB
            // 
            this.RemoveByID_TB.Location = new System.Drawing.Point(37, 51);
            this.RemoveByID_TB.Name = "RemoveByID_TB";
            this.RemoveByID_TB.Size = new System.Drawing.Size(97, 23);
            this.RemoveByID_TB.TabIndex = 20;
            this.RemoveByID_TB.Text = "1";
            // 
            // RemoveByID_BT
            // 
            this.RemoveByID_BT.Location = new System.Drawing.Point(140, 50);
            this.RemoveByID_BT.Name = "RemoveByID_BT";
            this.RemoveByID_BT.Size = new System.Drawing.Size(128, 23);
            this.RemoveByID_BT.TabIndex = 19;
            this.RemoveByID_BT.Text = "Удалить по ID:";
            this.RemoveByID_BT.UseVisualStyleBackColor = true;
            this.RemoveByID_BT.Click += new System.EventHandler(this.RemoveByID_BT_Click);
            // 
            // ReadByID_TB
            // 
            this.ReadByID_TB.Location = new System.Drawing.Point(37, 22);
            this.ReadByID_TB.Name = "ReadByID_TB";
            this.ReadByID_TB.Size = new System.Drawing.Size(97, 23);
            this.ReadByID_TB.TabIndex = 18;
            this.ReadByID_TB.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 392);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.WorkerInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер сотрудников";
            this.WorkerInfo.ResumeLayout(false);
            this.WorkerInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox WorkerInfo;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox Patronymic;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox Age;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox HeightTB;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox DateOfBorn;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox PlaceOfBorn;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox Surname;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox FileOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddWorker;
        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox RemoveByID_TB;
        private System.Windows.Forms.Button RemoveByID_BT;
        private System.Windows.Forms.TextBox ReadByID_TB;
        private System.Windows.Forms.Button ReadByID_BT;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox EndDate_TB;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button ReadByDate_BT;
        private System.Windows.Forms.TextBox StartDate_TB;
        private System.Windows.Forms.TextBox UpdateByID_TB;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button UpDownSort_BT;
        private System.Windows.Forms.Button UpdateByID_BT;
    }
}
