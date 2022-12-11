// Copyright (c) 2022 Alex Kravchenko

using System;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms;

namespace HexConverter
{
    public partial class FormMain : Form
    {
        private PersistedState? _state;

        public FormMain()
        {
            InitializeComponent();

            PopulateFormats(comboBoxFormat1);
            PopulateFormats(comboBoxFormat2);
        }

        private void PopulateFormats(ComboBox comboBox)
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
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
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
                "Hex1" => ConvertFromHex(textBoxHex1, textBoxDec1, comboBoxFormat1),
                "Dec1" => ConvertFromDec(textBoxHex1, textBoxDec1, comboBoxFormat1),
                "Hex2" => ConvertFromHex(textBoxHex2, textBoxDec2, comboBoxFormat2),
                "Dec2" => ConvertFromDec(textBoxHex2, textBoxDec2, comboBoxFormat2),
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

            textBoxDec.Text = dec;
            return true;
        }

        private static bool ConvertFromDec(TextBox textBoxHex, TextBox textBoxDec, ComboBox comboBoxFormat)
        {
            var text = textBoxDec.Text;

            var hex = HexConverter.ConvertFromDec(text, comboBoxFormat.Text);
            if (hex == null)
                return false;

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

            comboBoxFormat1.SelectedItem = _state.Format1;
            comboBoxFormat2.SelectedItem = _state.Format2;
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

            _state.Format1 = (string)comboBoxFormat1.SelectedItem;
            _state.Format2 = (string)comboBoxFormat2.SelectedItem;

            _state.Save();
        }
    }
}
