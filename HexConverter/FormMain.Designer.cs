// Copyright (c) 2022 - 2023 Alex Kravchenko

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
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelFormatsDec.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxHex1
            // 
            this.textBoxHex1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHex1.Location = new System.Drawing.Point(37, 158);
            this.textBoxHex1.Margin = new System.Windows.Forms.Padding(7, 6, 4, 6);
            this.textBoxHex1.Name = "textBoxHex1";
            this.textBoxHex1.Size = new System.Drawing.Size(214, 36);
            this.textBoxHex1.TabIndex = 0;
            this.textBoxHex1.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxHex1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            this.textBoxHex1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressed);
            // 
            // textBoxDec1
            // 
            this.textBoxDec1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDec1.Location = new System.Drawing.Point(475, 158);
            this.textBoxDec1.Margin = new System.Windows.Forms.Padding(6, 6, 35, 6);
            this.textBoxDec1.Name = "textBoxDec1";
            this.textBoxDec1.Size = new System.Drawing.Size(195, 36);
            this.textBoxDec1.TabIndex = 1;
            this.textBoxDec1.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxDec1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            this.textBoxDec1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressed);
            // 
            // buttonHex1
            // 
            this.buttonHex1.Location = new System.Drawing.Point(273, 156);
            this.buttonHex1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHex1.Name = "buttonHex1";
            this.buttonHex1.Size = new System.Drawing.Size(78, 53);
            this.buttonHex1.TabIndex = 2;
            this.buttonHex1.TabStop = false;
            this.buttonHex1.Text = "->";
            this.buttonHex1.UseVisualStyleBackColor = true;
            this.buttonHex1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // buttonDec1
            // 
            this.buttonDec1.Location = new System.Drawing.Point(379, 156);
            this.buttonDec1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonDec1.Name = "buttonDec1";
            this.buttonDec1.Size = new System.Drawing.Size(78, 53);
            this.buttonDec1.TabIndex = 3;
            this.buttonDec1.TabStop = false;
            this.buttonDec1.Text = "<-";
            this.buttonDec1.UseVisualStyleBackColor = true;
            this.buttonDec1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hexadecimal";
            // 
            // labelDec
            // 
            this.labelDec.AutoSize = true;
            this.labelDec.Location = new System.Drawing.Point(468, 90);
            this.labelDec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDec.Name = "labelDec";
            this.labelDec.Size = new System.Drawing.Size(125, 32);
            this.labelDec.TabIndex = 5;
            this.labelDec.Text = "Converted";
            // 
            // buttonDec2
            // 
            this.buttonDec2.Location = new System.Drawing.Point(379, 245);
            this.buttonDec2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonDec2.Name = "buttonDec2";
            this.buttonDec2.Size = new System.Drawing.Size(78, 53);
            this.buttonDec2.TabIndex = 9;
            this.buttonDec2.TabStop = false;
            this.buttonDec2.Text = "<-";
            this.buttonDec2.UseVisualStyleBackColor = true;
            this.buttonDec2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // buttonHex2
            // 
            this.buttonHex2.Location = new System.Drawing.Point(273, 245);
            this.buttonHex2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHex2.Name = "buttonHex2";
            this.buttonHex2.Size = new System.Drawing.Size(78, 53);
            this.buttonHex2.TabIndex = 8;
            this.buttonHex2.TabStop = false;
            this.buttonHex2.Text = "->";
            this.buttonHex2.UseVisualStyleBackColor = true;
            this.buttonHex2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // textBoxDec2
            // 
            this.textBoxDec2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDec2.Location = new System.Drawing.Point(475, 247);
            this.textBoxDec2.Margin = new System.Windows.Forms.Padding(6, 6, 35, 6);
            this.textBoxDec2.Name = "textBoxDec2";
            this.textBoxDec2.Size = new System.Drawing.Size(195, 36);
            this.textBoxDec2.TabIndex = 7;
            this.textBoxDec2.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxDec2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            this.textBoxDec2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressed);
            // 
            // textBoxHex2
            // 
            this.textBoxHex2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHex2.Location = new System.Drawing.Point(37, 247);
            this.textBoxHex2.Margin = new System.Windows.Forms.Padding(7, 6, 4, 6);
            this.textBoxHex2.Name = "textBoxHex2";
            this.textBoxHex2.Size = new System.Drawing.Size(214, 36);
            this.textBoxHex2.TabIndex = 6;
            this.textBoxHex2.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.textBoxHex2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            this.textBoxHex2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPressed);
            // 
            // comboBoxFormatDec1
            // 
            this.comboBoxFormatDec1.FormattingEnabled = true;
            this.comboBoxFormatDec1.Location = new System.Drawing.Point(24, 158);
            this.comboBoxFormatDec1.Margin = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.comboBoxFormatDec1.Name = "comboBoxFormatDec1";
            this.comboBoxFormatDec1.Size = new System.Drawing.Size(130, 40);
            this.comboBoxFormatDec1.TabIndex = 10;
            this.comboBoxFormatDec1.TabStop = false;
            this.comboBoxFormatDec1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFormatDecChanged);
            // 
            // comboBoxFormatDec2
            // 
            this.comboBoxFormatDec2.FormattingEnabled = true;
            this.comboBoxFormatDec2.Location = new System.Drawing.Point(24, 247);
            this.comboBoxFormatDec2.Margin = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.comboBoxFormatDec2.Name = "comboBoxFormatDec2";
            this.comboBoxFormatDec2.Size = new System.Drawing.Size(130, 40);
            this.comboBoxFormatDec2.TabIndex = 11;
            this.comboBoxFormatDec2.TabStop = false;
            this.comboBoxFormatDec2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFormatDecChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatDecToolStripButton,
            this.toolStripSeparator,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStrip1.Size = new System.Drawing.Size(891, 42);
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
            this.formatDecToolStripButton.Size = new System.Drawing.Size(93, 36);
            this.formatDecToolStripButton.Text = "&Format";
            this.formatDecToolStripButton.Click += new System.EventHandler(this.FormatDecToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 42);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.CopyToolStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.PasteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.HelpToolStripButton_Click);
            // 
            // panelFormatsDec
            // 
            this.panelFormatsDec.Controls.Add(this.label2);
            this.panelFormatsDec.Controls.Add(this.comboBoxFormatDec1);
            this.panelFormatsDec.Controls.Add(this.comboBoxFormatDec2);
            this.panelFormatsDec.Location = new System.Drawing.Point(689, 0);
            this.panelFormatsDec.Margin = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.panelFormatsDec.Name = "panelFormatsDec";
            this.panelFormatsDec.Size = new System.Drawing.Size(202, 354);
            this.panelFormatsDec.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "Format";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(891, 354);
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
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.panelFormatsDec.PerformLayout();
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
        private System.Windows.Forms.Label label2;
    }
}

