namespace SkillBoxTask2
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
            this.Surname = new System.Windows.Forms.TextBox();
            this.Patronymic = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PhysScore = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.ProgrScore = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.MathScore = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.Age = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Surname
            // 
            this.Surname.Location = new System.Drawing.Point(77, 21);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(116, 23);
            this.Surname.TabIndex = 0;
            this.Surname.Text = "Пинчук";
            this.Surname.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // Patronymic
            // 
            this.Patronymic.Location = new System.Drawing.Point(77, 79);
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.Size = new System.Drawing.Size(116, 23);
            this.Patronymic.TabIndex = 1;
            this.Patronymic.Text = "Романович";
            this.Patronymic.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(77, 50);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(116, 23);
            this.NameTB.TabIndex = 2;
            this.NameTB.Text = "Всеволод";
            this.NameTB.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(8, 50);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(63, 23);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "Имя:";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(8, 79);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(63, 23);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "Отчество:";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(8, 21);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(63, 23);
            this.textBox6.TabIndex = 3;
            this.textBox6.Text = "Фамилия:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Patronymic);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.Surname);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.NameTB);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 112);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ФИО";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PhysScore);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.ProgrScore);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.MathScore);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Location = new System.Drawing.Point(217, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 112);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Баллы";
            // 
            // PhysScore
            // 
            this.PhysScore.Location = new System.Drawing.Point(138, 79);
            this.PhysScore.Name = "PhysScore";
            this.PhysScore.Size = new System.Drawing.Size(51, 23);
            this.PhysScore.TabIndex = 1;
            this.PhysScore.Text = "83,0";
            this.PhysScore.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(8, 50);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(124, 23);
            this.textBox8.TabIndex = 5;
            this.textBox8.Text = "Математика:";
            // 
            // ProgrScore
            // 
            this.ProgrScore.Location = new System.Drawing.Point(138, 21);
            this.ProgrScore.Name = "ProgrScore";
            this.ProgrScore.Size = new System.Drawing.Size(51, 23);
            this.ProgrScore.TabIndex = 0;
            this.ProgrScore.Text = "86,0";
            this.ProgrScore.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(8, 79);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(124, 23);
            this.textBox10.TabIndex = 4;
            this.textBox10.Text = "Физика:";
            // 
            // MathScore
            // 
            this.MathScore.Location = new System.Drawing.Point(138, 50);
            this.MathScore.Name = "MathScore";
            this.MathScore.Size = new System.Drawing.Size(51, 23);
            this.MathScore.TabIndex = 2;
            this.MathScore.Text = "88,0";
            this.MathScore.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(8, 21);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(124, 23);
            this.textBox12.TabIndex = 3;
            this.textBox12.Text = "Программирование:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox14);
            this.groupBox3.Controls.Add(this.Age);
            this.groupBox3.Controls.Add(this.Email);
            this.groupBox3.Controls.Add(this.textBox18);
            this.groupBox3.Location = new System.Drawing.Point(12, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 61);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прочее";
            // 
            // textBox14
            // 
            this.textBox14.Enabled = false;
            this.textBox14.Location = new System.Drawing.Point(209, 21);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(56, 23);
            this.textBox14.TabIndex = 5;
            this.textBox14.Text = "Email:";
            // 
            // Age
            // 
            this.Age.Location = new System.Drawing.Point(70, 21);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(123, 23);
            this.Age.TabIndex = 0;
            this.Age.Text = "23";
            this.Age.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(271, 21);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(123, 23);
            this.Email.TabIndex = 2;
            this.Email.Text = "vsevolodpin@y.ru";
            this.Email.TextChanged += new System.EventHandler(this.UpdateValuesEvent);
            // 
            // textBox18
            // 
            this.textBox18.Enabled = false;
            this.textBox18.Location = new System.Drawing.Point(8, 21);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(56, 23);
            this.textBox18.TabIndex = 3;
            this.textBox18.Text = "Возраст:";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(12, 197);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(404, 181);
            this.Result.TabIndex = 10;
            this.Result.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 390);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkillBoxTask2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox Surname;
        private TextBox Patronymic;
        private TextBox NameTB;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox PhysScore;
        private TextBox textBox8;
        private TextBox ProgrScore;
        private TextBox textBox10;
        private TextBox MathScore;
        private TextBox textBox12;
        private GroupBox groupBox3;
        private TextBox textBox14;
        private TextBox Age;
        private TextBox Email;
        private TextBox textBox18;
        private RichTextBox Result;
    }
}