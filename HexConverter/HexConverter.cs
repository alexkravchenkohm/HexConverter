// Copyright (c) 2022 - 2023 Alex Kravchenko

using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HexConverter
{
    internal class HexConverter
    {
        private enum Format
        {
            UINT64,
            UINT32,
            UINT16,
            UINT8,
            INT64,
            INT32,
            INT16,
            INT8,
            FLOAT64,
            FLOAT32,
            ASCII,
        }

        private static readonly char[] AciiByteSeparators = new char[] { '-', ' ', ',' };
        internal static string[] FormatStrings => Enum.GetNames(typeof(Format));

        public static string? ConvertFromHex(string hex, string formatName)
        {
            if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                hex = hex[2..];
            }
            else if (hex.EndsWith("h", StringComparison.OrdinalIgnoreCase))
            {
                hex = hex[..^1];
            }

            if (Enum.TryParse(formatName, out Format format))
            {
                return ConvertFromHex(hex, format);
            }

            return null;
        }

        private static string? ConvertFromHex(string hex, Format format)
        {
            switch (format)
            {
                case Format.UINT64:
                    {
                        if (ulong.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.UINT32:
                    {
                        if (uint.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.UINT16:
                    {
                        if (ushort.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.UINT8:
                    {
                        if (byte.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.INT64:
                    {
                        if (long.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.INT32:
                    {
                        if (int.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.INT16:
                    {
                        if (short.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.INT8:
                    {
                        if (sbyte.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.FLOAT64:
                    {
                        if (ulong.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var uintVal))
                        {
                            var bytes = BitConverter.GetBytes(uintVal);
                            var val = BitConverter.ToDouble(bytes.AsSpan());
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.FLOAT32:
                    {
                        if (uint.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var uintVal))
                        {
                            var bytes = BitConverter.GetBytes(uintVal);
                            var val = BitConverter.ToSingle(bytes.AsSpan());
                            return val.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case Format.ASCII:
                    return GetAscii(hex);
                default:
                    break;
            }

            return null;
        }

        private static string? GetAscii(string hex)
        {
            var tokens = hex.Split(
                AciiByteSeparators, 
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var sb = new StringBuilder();
            foreach (var item in tokens)
            {
                // add "0" char to the front of each token if length is odd
                var token = (item.Length % 2 == 0) ? item : "0" + item;
                // link the tokens back
                sb.Append(token);
            }
            var normalized = sb.ToString();

            var bytes = new byte[normalized.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                if (!byte.TryParse(normalized.AsSpan(i * 2, 2), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var bval))
                {
                    return null;
                }
                bytes[i] = bval;
            }

            return Encoding.ASCII.GetString(bytes);
        }

        public static string? ConvertFromDec(string text, string formatName)
        {
            if (Enum.TryParse(formatName, out Format format))
            {
                return ConvertFromDec(text, format);
            }

            return null;
        }

        private static string? ConvertFromDec(string text, Format format)
        {

            switch (format)
            {
                case Format.UINT64:
                    {
                        if (ulong.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.UINT32:
                    {
                        if (uint.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.UINT16:
                    {
                        if (ushort.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.UINT8:
                    {
                        if (byte.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.INT64:
                    {
                        if (long.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.INT32:
                    {
                        if (int.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.INT16:
                    {
                        if (short.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.INT8:
                    {
                        if (sbyte.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var val))
                        {
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.FLOAT64:
                    {
                        if (double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out var floatVal))
                        {
                            var bytes = BitConverter.GetBytes(floatVal);
                            var val = BitConverter.ToUInt64(bytes.AsSpan());
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.FLOAT32:
                    {
                        if (float.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out var floatVal))
                        {
                            var bytes = BitConverter.GetBytes(floatVal);
                            var val = BitConverter.ToUInt32(bytes.AsSpan());
                            return val.ToString("x");
                        }
                    }
                    break;
                case Format.ASCII:
                    {
                        var bytes = Encoding.ASCII.GetBytes(text);
                        return BitConverter.ToString(bytes).Replace("-", string.Empty);
                    }
                default:
                    break;
            }

            return null;
        }

        private static bool IsFormatFloating(string formatName)
        {
            return Enum.TryParse(formatName, out Format format)
                && (format == Format.FLOAT64 || format == Format.FLOAT32);
        }

        private static bool IsFormatAscii(string formatName)
        {
            return Enum.TryParse(formatName, out Format format) && format == Format.ASCII;
        }

        internal static bool IsValidHexCharacter(char ch, string formatName)
        {
            if (IsFormatAscii(formatName) && AciiByteSeparators.Contains(ch))
            {
                // Allowing byte separators when converting to ASCII
                return true;
            }
            if (char.IsDigit(ch))
            {
                return true;
            }
            return char.ToUpperInvariant(ch) switch
            {
                'X' or 'H' or 'A' or 'B' or 'C' or 'D' or 'E' or 'F' => true,
                _ => false,
            };
        }

        internal static bool IsValidDecCharacter(char ch, string formatName)
        {
            if (IsFormatAscii(formatName))
            {
                // Allowing any character to be entered when converting from ASCII
                return true;
            }
            if (IsFormatFloating(formatName) && ch == '.' || ch == 'e' || ch == 'E')
            {
                return true;
            }
            if (char.IsNumber(ch) || ch == '+' || ch == '-')
            {
                return true;
            }
            
            return false;
        }
    }
}