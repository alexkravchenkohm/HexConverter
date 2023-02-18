// Copyright (c) 2022 - 2023 Alex Kravchenko

using System;
using System.Diagnostics;
using System.Drawing;
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

            PopulateFormats(comboBoxFormatDec1);
            PopulateFormats(comboBoxFormatDec2);

            InitializeDirtyFlags();
        }

        private void RestoreState()
        {
            _state = PersistedState.Restore();
            if (_state == null)
            {
                _state = new PersistedState();
                HideFormatsDec();
                return;
            }

            if (_state.Maximized)
            {
                Location = _state.Location;
                WindowState = FormWindowState.Maximized;
                Size = _state.Size;
            }
            else if (_state.Minimized)
            {
                Location = _state.Location;
                WindowState = FormWindowState.Minimized;
                Size = _state.Size;
            }
            else
            {
                Location = _state.Location;
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

            formatDecToolStripButton.Checked = _state.ShowFormatDecChecked;
            if (formatDecToolStripButton.Checked)
            {
                ShowFormatsDec();
            }
            else
            {
                HideFormatsDec();
            }
        }

        private void SaveState()
        {
            _state ??= new PersistedState();

            if (WindowState == FormWindowState.Maximized)
            {
                _state.Location = RestoreBounds.Location;
                _state.Size = RestoreBounds.Size;
                _state.Maximized = true;
                _state.Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                _state.Location = Location;
                _state.Size = Size;
                _state.Maximized = false;
                _state.Minimized = false;
            }
            else
            {
                _state.Location = RestoreBounds.Location;
                _state.Size = RestoreBounds.Size;
                _state.Maximized = false;
                _state.Minimized = true;
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

            _state.ShowFormatDecChecked = formatDecToolStripButton.Checked;

            _state.Save();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            textBoxHex1.Focus();
            textBoxHex1.Select(textBoxHex1.Text.Length, 0);
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

            RefreshFormatControls();
        }

        private void RefreshFormatControls()
        {
            if (formatDecToolStripButton.Checked)
            {
                panelFormatsDec.Show();
            }
            else
            {
                panelFormatsDec.Hide();
            }
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
            if (e.KeyCode == Keys.Enter && sender is TextBox textBox)
            {
                var converted = Convert(textBox.Name);
                e.Handled = true;
                if (converted)
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void TextBoxKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (sender is not TextBox textBox)
            {
                return;
            }

            if (!IsValidCharacter(e.KeyChar, textBox.Name))
            {
                e.Handled = true;
            }
        }

        private bool IsValidCharacter(char ch, string textBoxName)
        {
            if (char.IsControl(ch))
            {
                return true;
            }

            var suffix = GetControlNameSuffix(textBoxName);
            var valid = suffix switch
            {
                "Hex1" => HexConverter.IsValidHexCharacter(ch, comboBoxFormatDec1.Text),
                "Dec1" => HexConverter.IsValidDecCharacter(ch, comboBoxFormatDec1.Text),
                "Hex2" => HexConverter.IsValidHexCharacter(ch, comboBoxFormatDec2.Text),
                "Dec2" => HexConverter.IsValidDecCharacter(ch, comboBoxFormatDec2.Text),
                _ => false,
            };

            return valid;
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

        private static string GetControlNameSuffix(string name)
        {
            Debug.Assert(name.Length >= 4);
            return name.Substring(name.Length - 4, 4);
        }

        private bool Convert(string controlName)
        {
            var suffix = GetControlNameSuffix(controlName);
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

        private void FormatDecToolStripButton_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn)
            {
                if (btn.Checked)
                {
                    ShowFormatsDec();
                }
                else
                {
                    HideFormatsDec();
                }
            }
            SetAllTextBoxesDirty();
        }

        private void SetAllTextBoxesDirty()
        {
            SetDirty(textBoxHex1, true);
            SetDirty(textBoxHex2, true);
            SetDirty(textBoxDec1, true);
            SetDirty(textBoxDec2, true);
        }

        private void HideFormatsDec()
        {
            panelFormatsDec.Hide();
            labelDec.Text = "UINT64";
            comboBoxFormatDec1.SelectedItem = "UINT64";
            comboBoxFormatDec2.SelectedItem = "UINT64";
            // TODO: consider the right-pane icon instead of the text
            formatDecToolStripButton.Text = "&Format Options";
            // This allows the FormMain with AutoSize=true to deal with custom DPI display settings.
            // It relies on the Margin constraints of the controls.
            Width = 0;
        }

        private void ShowFormatsDec()
        {
            panelFormatsDec.Show();
            labelDec.Text = "Converted";
            formatDecToolStripButton.Text = "&Format Options";
        }

        private void ComboBoxFormatDecChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox cb)
            {
                if (cb.Name == "comboBoxFormatDec1")
                {
                    SetDirty(textBoxHex1, true);
                    SetDirty(textBoxDec1, true);
                }
                else if (cb.Name == "comboBoxFormatDec2")
                {
                    SetDirty(textBoxHex2, true);
                    SetDirty(textBoxDec2, true);
                }
            }
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveControl is not TextBox tb)
                return;

            // If nothing selected, then copy all the text from the textBox.
            // Remark: this is intentionally inconsistent with Control-C and Control-Ins behavior.
            string? ct = !string.IsNullOrEmpty(tb.SelectedText) ?
                tb.SelectedText :
                tb.Text;
            if (!string.IsNullOrEmpty(ct))
            {
                Clipboard.SetText(ct);
            }
        }

        private void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveControl is not TextBox tb)
                return;

            var ct = Clipboard.GetText();
            if (string.IsNullOrEmpty(ct))
                return;

            tb.Paste(ct);
        }

        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            _ = new AboutBoxMain(Text).ShowDialog();
        }
    }
}
