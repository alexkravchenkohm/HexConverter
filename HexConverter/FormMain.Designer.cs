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
            this.labelDec = new System.Windows.Forms.Label();
            this.buttonDec2 = new System.Windows.Forms.Button();
            this.buttonHex2 = new System.Windows.Forms.Button();
            this.textBoxDec2 = new System.Windows.Forms.TextBox();
            this.textBoxHex2 = new System.Windows.Forms.TextBox();
            this.comboBoxFormatDec1 = new System.Windows.Forms.ComboBox();
            this.comboBoxFormatDec2 = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.formatDecToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panelFormatsDec = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panelFormatsDec.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxHex1
            // 
            this.textBoxHex1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHex1.Location = new System.Drawing.Point(21, 70);
            this.textBoxHex1.Name = "textBoxHex1";
            this.textBoxHex1.Size = new System.Drawing.Size(118, 22);
            this.textBoxHex1.TabIndex = 0;
            this.textBoxHex1.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxHex1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // textBoxDec1
            // 
            this.textBoxDec1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDec1.Location = new System.Drawing.Point(276, 70);
            this.textBoxDec1.Name = "textBoxDec1";
            this.textBoxDec1.Size = new System.Drawing.Size(110, 22);
            this.textBoxDec1.TabIndex = 1;
            this.textBoxDec1.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxDec1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // buttonHex1
            // 
            this.buttonHex1.Location = new System.Drawing.Point(153, 69);
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
            this.buttonDec1.Location = new System.Drawing.Point(218, 70);
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
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hexadecimal";
            // 
            // labelDec
            // 
            this.labelDec.AutoSize = true;
            this.labelDec.Location = new System.Drawing.Point(276, 40);
            this.labelDec.Name = "labelDec";
            this.labelDec.Size = new System.Drawing.Size(62, 15);
            this.labelDec.TabIndex = 5;
            this.labelDec.Text = "Converted";
            // 
            // buttonDec2
            // 
            this.buttonDec2.Location = new System.Drawing.Point(218, 110);
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
            this.buttonHex2.Location = new System.Drawing.Point(153, 109);
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
            this.textBoxDec2.Location = new System.Drawing.Point(276, 110);
            this.textBoxDec2.Name = "textBoxDec2";
            this.textBoxDec2.Size = new System.Drawing.Size(110, 22);
            this.textBoxDec2.TabIndex = 7;
            this.textBoxDec2.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxDec2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // textBoxHex2
            // 
            this.textBoxHex2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHex2.Location = new System.Drawing.Point(21, 110);
            this.textBoxHex2.Name = "textBoxHex2";
            this.textBoxHex2.Size = new System.Drawing.Size(118, 22);
            this.textBoxHex2.TabIndex = 6;
            this.textBoxHex2.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxHex2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // comboBoxFormatDec1
            // 
            this.comboBoxFormatDec1.FormattingEnabled = true;
            this.comboBoxFormatDec1.Location = new System.Drawing.Point(12, 69);
            this.comboBoxFormatDec1.Name = "comboBoxFormatDec1";
            this.comboBoxFormatDec1.Size = new System.Drawing.Size(75, 23);
            this.comboBoxFormatDec1.TabIndex = 10;
            this.comboBoxFormatDec1.TabStop = false;
            this.comboBoxFormatDec1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFormatDecChanged);
            // 
            // comboBoxFormatDec2
            // 
            this.comboBoxFormatDec2.FormattingEnabled = true;
            this.comboBoxFormatDec2.Location = new System.Drawing.Point(12, 110);
            this.comboBoxFormatDec2.Name = "comboBoxFormatDec2";
            this.comboBoxFormatDec2.Size = new System.Drawing.Size(75, 23);
            this.comboBoxFormatDec2.TabIndex = 11;
            this.comboBoxFormatDec2.TabStop = false;
            this.comboBoxFormatDec2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFormatDecChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatDecToolStripButton,
            this.toolStripSeparator,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(504, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // formatDecToolStripButton
            // 
            this.formatDecToolStripButton.CheckOnClick = true;
            this.formatDecToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.formatDecToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("formatDecToolStripButton.Image")));
            this.formatDecToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.formatDecToolStripButton.Name = "formatDecToolStripButton";
            this.formatDecToolStripButton.Size = new System.Drawing.Size(86, 22);
            this.formatDecToolStripButton.Text = "Show &Formats";
            this.formatDecToolStripButton.Click += new System.EventHandler(this.FormatDecToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.CopyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.PasteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.HelpToolStripButton_Click);
            // 
            // panelFormatsDec
            // 
            this.panelFormatsDec.Controls.Add(this.comboBoxFormatDec1);
            this.panelFormatsDec.Controls.Add(this.comboBoxFormatDec2);
            this.panelFormatsDec.Location = new System.Drawing.Point(392, 0);
            this.panelFormatsDec.Name = "panelFormatsDec";
            this.panelFormatsDec.Size = new System.Drawing.Size(113, 155);
            this.panelFormatsDec.TabIndex = 13;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 155);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonDec2);
            this.Controls.Add(this.buttonHex2);
            this.Controls.Add(this.textBoxDec2);
            this.Controls.Add(this.textBoxHex2);
            this.Controls.Add(this.labelDec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDec1);
            this.Controls.Add(this.buttonHex1);
            this.Controls.Add(this.textBoxDec1);
            this.Controls.Add(this.textBoxHex1);
            this.Controls.Add(this.panelFormatsDec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AK Hex Converter";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelFormatsDec.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHex1;
        private System.Windows.Forms.TextBox textBoxDec1;
        private System.Windows.Forms.Button buttonHex1;
        private System.Windows.Forms.Button buttonDec1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDec;
        private System.Windows.Forms.Button buttonDec2;
        private System.Windows.Forms.Button buttonHex2;
        private System.Windows.Forms.TextBox textBoxDec2;
        private System.Windows.Forms.TextBox textBoxHex2;
        private System.Windows.Forms.ComboBox comboBoxFormatDec1;
        private System.Windows.Forms.ComboBox comboBoxFormatDec2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton formatDecToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Panel panelFormatsDec;
    }
}

