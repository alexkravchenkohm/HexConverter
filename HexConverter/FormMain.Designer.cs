// Copyright (c) 2022 Alex Kravchenko

namespace HexConverter
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxHex1 = new System.Windows.Forms.TextBox();
            this.textBoxDec1 = new System.Windows.Forms.TextBox();
            this.buttonHex1 = new System.Windows.Forms.Button();
            this.buttonDec1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDec2 = new System.Windows.Forms.Button();
            this.buttonHex2 = new System.Windows.Forms.Button();
            this.textBoxDec2 = new System.Windows.Forms.TextBox();
            this.textBoxHex2 = new System.Windows.Forms.TextBox();
            this.comboBoxFormatDec1 = new System.Windows.Forms.ComboBox();
            this.comboBoxFormatDec2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxHex1
            // 
            this.textBoxHex1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHex1.Location = new System.Drawing.Point(20, 57);
            this.textBoxHex1.Name = "textBoxHex1";
            this.textBoxHex1.Size = new System.Drawing.Size(110, 22);
            this.textBoxHex1.TabIndex = 0;
            this.textBoxHex1.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxHex1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // textBoxDec1
            // 
            this.textBoxDec1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDec1.Location = new System.Drawing.Point(266, 57);
            this.textBoxDec1.Name = "textBoxDec1";
            this.textBoxDec1.Size = new System.Drawing.Size(110, 22);
            this.textBoxDec1.TabIndex = 1;
            this.textBoxDec1.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxDec1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // buttonHex1
            // 
            this.buttonHex1.Location = new System.Drawing.Point(143, 56);
            this.buttonHex1.Name = "buttonHex1";
            this.buttonHex1.Size = new System.Drawing.Size(46, 23);
            this.buttonHex1.TabIndex = 2;
            this.buttonHex1.TabStop = false;
            this.buttonHex1.Text = "->";
            this.buttonHex1.UseVisualStyleBackColor = true;
            this.buttonHex1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // buttonDec1
            // 
            this.buttonDec1.Location = new System.Drawing.Point(208, 57);
            this.buttonDec1.Name = "buttonDec1";
            this.buttonDec1.Size = new System.Drawing.Size(46, 23);
            this.buttonDec1.TabIndex = 3;
            this.buttonDec1.TabStop = false;
            this.buttonDec1.Text = "<-";
            this.buttonDec1.UseVisualStyleBackColor = true;
            this.buttonDec1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hexadecimal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Converted";
            // 
            // buttonDec2
            // 
            this.buttonDec2.Location = new System.Drawing.Point(208, 97);
            this.buttonDec2.Name = "buttonDec2";
            this.buttonDec2.Size = new System.Drawing.Size(46, 23);
            this.buttonDec2.TabIndex = 9;
            this.buttonDec2.TabStop = false;
            this.buttonDec2.Text = "<-";
            this.buttonDec2.UseVisualStyleBackColor = true;
            this.buttonDec2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // buttonHex2
            // 
            this.buttonHex2.Location = new System.Drawing.Point(143, 96);
            this.buttonHex2.Name = "buttonHex2";
            this.buttonHex2.Size = new System.Drawing.Size(46, 23);
            this.buttonHex2.TabIndex = 8;
            this.buttonHex2.TabStop = false;
            this.buttonHex2.Text = "->";
            this.buttonHex2.UseVisualStyleBackColor = true;
            this.buttonHex2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // textBoxDec2
            // 
            this.textBoxDec2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDec2.Location = new System.Drawing.Point(266, 97);
            this.textBoxDec2.Name = "textBoxDec2";
            this.textBoxDec2.Size = new System.Drawing.Size(110, 22);
            this.textBoxDec2.TabIndex = 7;
            this.textBoxDec2.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxDec2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // textBoxHex2
            // 
            this.textBoxHex2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHex2.Location = new System.Drawing.Point(20, 97);
            this.textBoxHex2.Name = "textBoxHex2";
            this.textBoxHex2.Size = new System.Drawing.Size(110, 22);
            this.textBoxHex2.TabIndex = 6;
            this.textBoxHex2.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxHex2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // comboBoxFormatDec1
            // 
            this.comboBoxFormatDec1.FormattingEnabled = true;
            this.comboBoxFormatDec1.Location = new System.Drawing.Point(388, 56);
            this.comboBoxFormatDec1.Name = "comboBoxFormatDec1";
            this.comboBoxFormatDec1.Size = new System.Drawing.Size(75, 23);
            this.comboBoxFormatDec1.TabIndex = 10;
            this.comboBoxFormatDec1.TabStop = false;
            this.comboBoxFormatDec1.SelectedIndexChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // comboBoxFormatDec2
            // 
            this.comboBoxFormatDec2.FormattingEnabled = true;
            this.comboBoxFormatDec2.Location = new System.Drawing.Point(388, 96);
            this.comboBoxFormatDec2.Name = "comboBoxFormatDec2";
            this.comboBoxFormatDec2.Size = new System.Drawing.Size(75, 23);
            this.comboBoxFormatDec2.TabIndex = 11;
            this.comboBoxFormatDec2.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 141);
            this.Controls.Add(this.comboBoxFormatDec2);
            this.Controls.Add(this.comboBoxFormatDec1);
            this.Controls.Add(this.buttonDec2);
            this.Controls.Add(this.buttonHex2);
            this.Controls.Add(this.textBoxDec2);
            this.Controls.Add(this.textBoxHex2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDec1);
            this.Controls.Add(this.buttonHex1);
            this.Controls.Add(this.textBoxDec1);
            this.Controls.Add(this.textBoxHex1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Hex Converter";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHex1;
        private System.Windows.Forms.TextBox textBoxDec1;
        private System.Windows.Forms.Button buttonHex1;
        private System.Windows.Forms.Button buttonDec1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDec2;
        private System.Windows.Forms.Button buttonHex2;
        private System.Windows.Forms.TextBox textBoxDec2;
        private System.Windows.Forms.TextBox textBoxHex2;
        private System.Windows.Forms.ComboBox comboBoxFormatDec1;
        private System.Windows.Forms.ComboBox comboBoxFormatDec2;
    }
}

