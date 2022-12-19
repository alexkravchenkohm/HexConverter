// Copyright (c) 2022 Alex Kravchenko

using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HexConverter
{
    public partial class FormMain : Form
    {
        private PersistedState? _state;

        public FormMain()
        {
            InitializeComponent();

            PopulateFormats(comboBoxFormatDec1);
            PopulateFormats(comboBoxFormatDec2);
            
            InitializeDirtyFlags();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            buttonHex1.Focus();
        }

        private void InitializeDirtyFlags()
        {
            // Needed for the case of missing persisted state
            textBoxHex1.Tag = false;
            textBoxHex2.Tag = false;
            textBoxDec1.Tag = false;
            textBoxDec2.Tag = false;
        }

        private static void PopulateFormats(ComboBox comboBox)
        {
            foreach (var item in HexConverter.FormatStrings)
            {
                comboBox.Items.Add(item);
            }

            comboBox.SelectedIndex = 0;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            RestoreState();

            RefreshDirtyStates();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }

        private void RefreshDirtyStates()
        {
            RefreshDirtyState(textBoxHex1);
            RefreshDirtyState(textBoxHex2);
            RefreshDirtyState(textBoxDec1);
            RefreshDirtyState(textBoxDec2);
        }

        private static void RefreshDirtyState(TextBox textBox)
        {
            bool dirty = (bool)(textBox.Tag);
            textBox.Font = dirty ? 
                new Font(textBox.Font, FontStyle.Italic) :
                new Font(textBox.Font, FontStyle.Bold);
            textBox.ForeColor = dirty ?
                SystemColors.GrayText :
                SystemColors.WindowText;
        }

        private static void SetDirty(TextBox textBox, bool dirty)
        {
            textBox.Tag = dirty;
            RefreshDirtyState(textBox);
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb && tb.Modified)
            {
                SetDirty(tb, false);
                if      (tb == textBoxHex1) { SetDirty(textBoxDec1, true); }
                else if (tb == textBoxHex2) { SetDirty(textBoxDec2, true); }
                else if (tb == textBoxDec1) { SetDirty(textBoxHex1, true); }
                else if (tb == textBoxDec2) { SetDirty(textBoxHex2, true); }
            }
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && sender is Control control)
            {
                var converted = Convert(control.Name);
                e.Handled = true;
                if (converted)
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                if (!Convert(control.Name))
                {
                    SystemSounds.Beep.Play();
                }
            }
        }

        private bool Convert(string controlName)
        {
            Debug.Assert(controlName.Length >= 4);

            string suffix = controlName.Substring(controlName.Length - 4, 4);
            var converted = suffix switch
            {
                "Hex1" => ConvertFromHex(textBoxHex1, textBoxDec1, comboBoxFormatDec1),
                "Dec1" => ConvertFromDec(textBoxHex1, textBoxDec1, comboBoxFormatDec1),
                "Hex2" => ConvertFromHex(textBoxHex2, textBoxDec2, comboBoxFormatDec2),
                "Dec2" => ConvertFromDec(textBoxHex2, textBoxDec2, comboBoxFormatDec2),
                _ => false,
            };

            return converted;
        }

        private static bool ConvertFromHex(TextBox textBoxHex, TextBox textBoxDec, ComboBox comboBoxFormat)
        {
            var text = textBoxHex.Text;

            var dec = HexConverter.ConvertFromHex(text, comboBoxFormat.Text);
            if (dec == null)
                return false;

            SetDirty(textBoxHex, false);
            SetDirty(textBoxDec, false);

            textBoxDec.Text = dec;
            return true;
        }

        private static bool ConvertFromDec(TextBox textBoxHex, TextBox textBoxDec, ComboBox comboBoxFormat)
        {
            var text = textBoxDec.Text;

            var hex = HexConverter.ConvertFromDec(text, comboBoxFormat.Text);
            if (hex == null)
                return false;

            SetDirty(textBoxHex, false);
            SetDirty(textBoxDec, false);

            textBoxHex.Text = hex;
            return true;
        }

        private void RestoreState()
        {
            _state = PersistedState.Restore();
            if (_state == null)
            {
                _state = new PersistedState();
                return;
            }

            if (_state.Maximised)
            {
                Location = _state.Location;
                WindowState = FormWindowState.Maximized;
                Size = _state.Size;
            }
            else if (_state.Minimised)
            {
                Location = _state.Location;
                WindowState = FormWindowState.Minimized;
                Size = _state.Size;
            }
            else
            {
                Location = _state.Location;
                Size = _state.Size;
            }

            textBoxHex1.Text = _state.Hex1;
            textBoxHex2.Text = _state.Hex2;
            textBoxDec1.Text = _state.Dec1;
            textBoxDec2.Text = _state.Dec2;

            comboBoxFormatDec1.SelectedItem = _state.FormatDec1;
            comboBoxFormatDec2.SelectedItem = _state.FormatDec2;

            textBoxHex1.Tag = _state.IsDirtyHex1;
            textBoxHex2.Tag = _state.IsDirtyHex2;
            textBoxDec1.Tag = _state.IsDirtyDec1;
            textBoxDec2.Tag = _state.IsDirtyDec2;
        }

        private void SaveState()
        {
            if (_state == null)
            {
                _state = new PersistedState();
            }

            if (WindowState == FormWindowState.Maximized)
            {
                _state.Location = RestoreBounds.Location;
                _state.Size = RestoreBounds.Size;
                _state.Maximised = true;
                _state.Minimised = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                _state.Location = Location;
                _state.Size = Size;
                _state.Maximised = false;
                _state.Minimised = false;
            }
            else
            {
                _state.Location = RestoreBounds.Location;
                _state.Size = RestoreBounds.Size;
                _state.Maximised = false;
                _state.Minimised = true;
            }

            _state.Hex1 = textBoxHex1.Text;
            _state.Hex2 = textBoxHex2.Text;
            _state.Dec1 = textBoxDec1.Text;
            _state.Dec2 = textBoxDec2.Text;

            _state.FormatDec1 = (string)comboBoxFormatDec1.SelectedItem;
            _state.FormatDec2 = (string)comboBoxFormatDec2.SelectedItem;

            _state.IsDirtyHex1 = (bool)textBoxHex1.Tag;
            _state.IsDirtyHex2 = (bool)textBoxHex2.Tag;
            _state.IsDirtyDec1 = (bool)textBoxDec1.Tag;
            _state.IsDirtyDec2 = (bool)textBoxDec2.Tag;

            _state.Save();
        }
    }
}
