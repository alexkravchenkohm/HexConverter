// Copyright (c) 2022 Alex Kravchenko

using System;
using System.Buffers.Binary;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

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
            ASCII,
        }

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
                case Format.ASCII:
                    {
                        // For now just expecting up to 8-byte strings interpreted as big-endian ASCII characters.
                        // TODO: add support for free-form coma-separated lists.
                        if (ulong.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                        {
                            var bytes = BitConverter.GetBytes(BinaryPrimitives.ReverseEndianness(val));
                            var text = Encoding.UTF8.GetString(bytes); 
                            text = text.TrimStart('\0');
                            return Regex.Replace(text, @"[^\u001F-\u007F]", "\u001a");  // Non printable are substituted with 0x1a "SUB"
                        }
                    }
                    break;
                default:
                    break;
            }

            return null;
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
                case Format.ASCII:
                    var bytes = Encoding.UTF8.GetBytes(text);
                    if (bytes.Length > 0 && Array.IndexOf(bytes, 0x1a) < 0)   // reject values containing the substitute character 
                    {
                        // This code trims the string to 8 bytes. An alternative approach is rejecting it.
                        var eightBytes = new byte[8];
                        for (int i = 0; i < bytes.Length && i < eightBytes.Length; i++)
                        {
                            // Only taking eight bytes from the tail
                            eightBytes[eightBytes.Length - 1 - i] = bytes[bytes.Length - 1 - i];
                        }
                        var ul = BitConverter.ToUInt64(eightBytes, 0);
                        ul = BinaryPrimitives.ReverseEndianness(ul);
                        return ul.ToString("x");
                    }
                    break;
                default:
                    break;
            }

            return null;
        }
    }
}