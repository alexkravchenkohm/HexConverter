// Copyright (c) 2022 Alex Kravchenko

using System;
using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Windows.Forms;

namespace HexConverter
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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
                "Hex1" => ConvertFromHex(textBoxHex1, textBoxDec1),
                "Dec1" => ConvertFromDec(textBoxHex1, textBoxDec1),
                "Hex2" => ConvertFromHex(textBoxHex2, textBoxDec2),
                "Dec2" => ConvertFromDec(textBoxHex2, textBoxDec2),
                _ => false,
            };

            return converted;
        }

        private static bool ConvertFromHex(TextBox textBoxHex, TextBox textBoxDec)
        {
            var text = textBoxHex.Text;
            
            if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                text = text[2..];
            }
            else if (text.EndsWith("h", StringComparison.OrdinalIgnoreCase))
            {
                text = text[..^1];
            }

            if (ulong.TryParse(text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out ulong hex))
            {
                textBoxDec.Text = hex.ToString(CultureInfo.CurrentCulture);
                return true;
            }

            return false;
        }

        private static bool ConvertFromDec(TextBox textBoxHex, TextBox textBoxDec)
        {
            var text = textBoxDec.Text;
            if (ulong.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out ulong dec))
            {
                textBoxHex.Text = dec.ToString("x");
                return true;
            }

            return false;
        }

    }
}
