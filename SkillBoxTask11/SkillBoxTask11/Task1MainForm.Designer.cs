﻿namespace SkillBoxTask11
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
            this.AddClientBT = new System.Windows.Forms.Button();
            this.ClientsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CreateClientGroup = new System.Windows.Forms.GroupBox();
            this.PassNTB1 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.NameTB1 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.PatrTB1 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.PassSTB1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.PhoneTB1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SurTB1 = new System.Windows.Forms.TextBox();
            this.EditGroup = new System.Windows.Forms.GroupBox();
            this.PassNTB2 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.NameTB2 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.PatrTB2 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.PassSTB2 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.PhoneTB2 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.SurTB2 = new System.Windows.Forms.TextBox();
            this.ConsRB = new System.Windows.Forms.RadioButton();
            this.ManagerRB = new System.Windows.Forms.RadioButton();
            this.EditBT = new System.Windows.Forms.Button();
            this.UserChoosing = new System.Windows.Forms.GroupBox();
            this.SaveBT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.CreateClientGroup.SuspendLayout();
            this.EditGroup.SuspendLayout();
            this.UserChoosing.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddClientBT
            // 
            this.AddClientBT.Location = new System.Drawing.Point(476, 384);
            this.AddClientBT.Name = "AddClientBT";
            this.AddClientBT.Size = new System.Drawing.Size(125, 30);
            this.AddClientBT.TabIndex = 0;
            this.AddClientBT.Text = "Добавить клиента";
            this.AddClientBT.UseVisualStyleBackColor = true;
            this.AddClientBT.Click += new System.EventHandler(this.AddClientBT_Click);
            // 
            // ClientsListBox
            // 
            this.ClientsListBox.FormattingEnabled = true;
            this.ClientsListBox.ItemHeight = 15;
            this.ClientsListBox.Location = new System.Drawing.Point(6, 22);
            this.ClientsListBox.Name = "ClientsListBox";
            this.ClientsListBox.Size = new System.Drawing.Size(294, 319);
            this.ClientsListBox.TabIndex = 1;
            this.ClientsListBox.SelectedIndexChanged += new System.EventHandler(this.ClientsListBox_SelectedIndexChanged);
            this.ClientsListBox.DoubleClick += new System.EventHandler(this.ClientsListBox_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClientsListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 354);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список клиентов";
            // 
            // CreateClientGroup
            // 
            this.CreateClientGroup.Controls.Add(this.PassNTB1);
            this.CreateClientGroup.Controls.Add(this.textBox10);
            this.CreateClientGroup.Controls.Add(this.NameTB1);
            this.CreateClientGroup.Controls.Add(this.textBox8);
            this.CreateClientGroup.Controls.Add(this.PatrTB1);
            this.CreateClientGroup.Controls.Add(this.textBox6);
            this.CreateClientGroup.Controls.Add(this.PassSTB1);
            this.CreateClientGroup.Controls.Add(this.textBox4);
            this.CreateClientGroup.Controls.Add(this.PhoneTB1);
            this.CreateClientGroup.Controls.Add(this.textBox1);
            this.CreateClientGroup.Controls.Add(this.SurTB1);
            this.CreateClientGroup.Location = new System.Drawing.Point(326, 12);
            this.CreateClientGroup.Name = "CreateClientGroup";
            this.CreateClientGroup.Size = new System.Drawing.Size(275, 174);
            this.CreateClientGroup.TabIndex = 3;
            this.CreateClientGroup.TabStop = false;
            this.CreateClientGroup.Text = "Создание клиента";
            // 
            // PassNTB1
            // 
            this.PassNTB1.Location = new System.Drawing.Point(162, 138);
            this.PassNTB1.Name = "PassNTB1";
            this.PassNTB1.Size = new System.Drawing.Size(102, 23);
            this.PassNTB1.TabIndex = 17;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(6, 51);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(72, 23);
            this.textBox10.TabIndex = 8;
            this.textBox10.Text = "Имя";
            // 
            // NameTB1
            // 
            this.NameTB1.Location = new System.Drawing.Point(84, 51);
            this.NameTB1.Name = "NameTB1";
            this.NameTB1.Size = new System.Drawing.Size(180, 23);
            this.NameTB1.TabIndex = 16;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(6, 80);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(72, 23);
            this.textBox8.TabIndex = 6;
            this.textBox8.Text = "Отчество";
            // 
            // PatrTB1
            // 
            this.PatrTB1.Location = new System.Drawing.Point(84, 80);
            this.PatrTB1.Name = "PatrTB1";
            this.PatrTB1.Size = new System.Drawing.Size(180, 23);
            this.PatrTB1.TabIndex = 15;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 138);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(72, 23);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "Паспорт";
            // 
            // PassSTB1
            // 
            this.PassSTB1.Location = new System.Drawing.Point(84, 138);
            this.PassSTB1.Name = "PassSTB1";
            this.PassSTB1.Size = new System.Drawing.Size(72, 23);
            this.PassSTB1.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 109);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(72, 23);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "Телефон";
            // 
            // PhoneTB1
            // 
            this.PhoneTB1.Location = new System.Drawing.Point(84, 109);
            this.PhoneTB1.Name = "PhoneTB1";
            this.PhoneTB1.Size = new System.Drawing.Size(180, 23);
            this.PhoneTB1.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(72, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Фамилия";
            // 
            // SurTB1
            // 
            this.SurTB1.Location = new System.Drawing.Point(84, 22);
            this.SurTB1.Name = "SurTB1";
            this.SurTB1.Size = new System.Drawing.Size(180, 23);
            this.SurTB1.TabIndex = 12;
            // 
            // EditGroup
            // 
            this.EditGroup.Controls.Add(this.PassNTB2);
            this.EditGroup.Controls.Add(this.textBox14);
            this.EditGroup.Controls.Add(this.NameTB2);
            this.EditGroup.Controls.Add(this.textBox16);
            this.EditGroup.Controls.Add(this.PatrTB2);
            this.EditGroup.Controls.Add(this.textBox18);
            this.EditGroup.Controls.Add(this.PassSTB2);
            this.EditGroup.Controls.Add(this.textBox20);
            this.EditGroup.Controls.Add(this.PhoneTB2);
            this.EditGroup.Controls.Add(this.textBox22);
            this.EditGroup.Controls.Add(this.SurTB2);
            this.EditGroup.Location = new System.Drawing.Point(326, 192);
            this.EditGroup.Name = "EditGroup";
            this.EditGroup.Size = new System.Drawing.Size(275, 174);
            this.EditGroup.TabIndex = 11;
            this.EditGroup.TabStop = false;
            this.EditGroup.Text = "Просмотр/редактирование клиента";
            // 
            // PassNTB2
            // 
            this.PassNTB2.Location = new System.Drawing.Point(163, 138);
            this.PassNTB2.Name = "PassNTB2";
            this.PassNTB2.Size = new System.Drawing.Size(102, 23);
            this.PassNTB2.TabIndex = 23;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(6, 51);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(72, 23);
            this.textBox14.TabIndex = 8;
            this.textBox14.Text = "Имя";
            // 
            // NameTB2
            // 
            this.NameTB2.Location = new System.Drawing.Point(85, 51);
            this.NameTB2.Name = "NameTB2";
            this.NameTB2.Size = new System.Drawing.Size(180, 23);
            this.NameTB2.TabIndex = 22;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(6, 80);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(72, 23);
            this.textBox16.TabIndex = 6;
            this.textBox16.Text = "Отчество";
            // 
            // PatrTB2
            // 
            this.PatrTB2.Location = new System.Drawing.Point(85, 80);
            this.PatrTB2.Name = "PatrTB2";
            this.PatrTB2.Size = new System.Drawing.Size(180, 23);
            this.PatrTB2.TabIndex = 21;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(6, 138);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(72, 23);
            this.textBox18.TabIndex = 4;
            this.textBox18.Text = "Паспорт";
            // 
            // PassSTB2
            // 
            this.PassSTB2.Location = new System.Drawing.Point(85, 138);
            this.PassSTB2.Name = "PassSTB2";
            this.PassSTB2.Size = new System.Drawing.Size(72, 23);
            this.PassSTB2.TabIndex = 20;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(6, 109);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(72, 23);
            this.textBox20.TabIndex = 2;
            this.textBox20.Text = "Телефон";
            // 
            // PhoneTB2
            // 
            this.PhoneTB2.Location = new System.Drawing.Point(85, 109);
            this.PhoneTB2.Name = "PhoneTB2";
            this.PhoneTB2.Size = new System.Drawing.Size(180, 23);
            this.PhoneTB2.TabIndex = 19;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(6, 22);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(72, 23);
            this.textBox22.TabIndex = 0;
            this.textBox22.Text = "Фамилия";
            // 
            // SurTB2
            // 
            this.SurTB2.Location = new System.Drawing.Point(85, 22);
            this.SurTB2.Name = "SurTB2";
            this.SurTB2.Size = new System.Drawing.Size(180, 23);
            this.SurTB2.TabIndex = 18;
            // 
            // ConsRB
            // 
            this.ConsRB.AutoSize = true;
            this.ConsRB.Location = new System.Drawing.Point(6, 22);
            this.ConsRB.Name = "ConsRB";
            this.ConsRB.Size = new System.Drawing.Size(94, 19);
            this.ConsRB.TabIndex = 12;
            this.ConsRB.Text = "Консультант";
            this.ConsRB.UseVisualStyleBackColor = true;
            this.ConsRB.CheckedChanged += new System.EventHandler(this.ConsRB_CheckedChanged);
            // 
            // ManagerRB
            // 
            this.ManagerRB.AutoSize = true;
            this.ManagerRB.Checked = true;
            this.ManagerRB.Location = new System.Drawing.Point(106, 22);
            this.ManagerRB.Name = "ManagerRB";
            this.ManagerRB.Size = new System.Drawing.Size(83, 19);
            this.ManagerRB.TabIndex = 13;
            this.ManagerRB.TabStop = true;
            this.ManagerRB.Text = "Менеджер";
            this.ManagerRB.UseVisualStyleBackColor = true;
            this.ManagerRB.CheckedChanged += new System.EventHandler(this.ConsRB_CheckedChanged);
            // 
            // EditBT
            // 
            this.EditBT.Enabled = false;
            this.EditBT.Location = new System.Drawing.Point(345, 384);
            this.EditBT.Name = "EditBT";
            this.EditBT.Size = new System.Drawing.Size(125, 30);
            this.EditBT.TabIndex = 14;
            this.EditBT.Text = "Редактировать";
            this.EditBT.UseVisualStyleBackColor = true;
            this.EditBT.Click += new System.EventHandler(this.EditBT_Click);
            // 
            // UserChoosing
            // 
            this.UserChoosing.Controls.Add(this.ConsRB);
            this.UserChoosing.Controls.Add(this.ManagerRB);
            this.UserChoosing.Location = new System.Drawing.Point(12, 368);
            this.UserChoosing.Name = "UserChoosing";
            this.UserChoosing.Size = new System.Drawing.Size(196, 50);
            this.UserChoosing.TabIndex = 15;
            this.UserChoosing.TabStop = false;
            this.UserChoosing.Text = "Выбор пользователя";
            // 
            // SaveBT
            // 
            this.SaveBT.Location = new System.Drawing.Point(214, 384);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(125, 30);
            this.SaveBT.TabIndex = 16;
            this.SaveBT.Text = "Сохранить";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 428);
            this.Controls.Add(this.SaveBT);
            this.Controls.Add(this.UserChoosing);
            this.Controls.Add(this.EditBT);
            this.Controls.Add(this.EditGroup);
            this.Controls.Add(this.CreateClientGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AddClientBT);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.CreateClientGroup.ResumeLayout(false);
            this.CreateClientGroup.PerformLayout();
            this.EditGroup.ResumeLayout(false);
            this.EditGroup.PerformLayout();
            this.UserChoosing.ResumeLayout(false);
            this.UserChoosing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddClientBT;
        private System.Windows.Forms.ListBox ClientsListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox CreateClientGroup;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox PassNTB1;
        private System.Windows.Forms.TextBox NameTB1;
        private System.Windows.Forms.TextBox PatrTB1;
        private System.Windows.Forms.TextBox PassSTB1;
        private System.Windows.Forms.TextBox PhoneTB1;
        private System.Windows.Forms.TextBox SurTB1;
        private System.Windows.Forms.GroupBox EditGroup;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.RadioButton ConsRB;
        private System.Windows.Forms.RadioButton ManagerRB;
        private System.Windows.Forms.Button EditBT;
        private System.Windows.Forms.TextBox PassNTB2;
        private System.Windows.Forms.TextBox NameTB2;
        private System.Windows.Forms.TextBox PatrTB2;
        private System.Windows.Forms.TextBox PassSTB2;
        private System.Windows.Forms.TextBox PhoneTB2;
        private System.Windows.Forms.TextBox SurTB2;
        private System.Windows.Forms.GroupBox UserChoosing;
        private System.Windows.Forms.Button SaveBT;
    }
}
