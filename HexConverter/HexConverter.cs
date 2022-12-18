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
                    return GetAscii(hex);
                default:
                    break;
            }

            return null;
        }

        private static string? GetAscii(string hex)
        {
            var tokens = hex.Split(new char[] {'-', ' ', ','}, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var ret = string.Empty;
            foreach (var token in tokens)
            {
                if (!ulong.TryParse(token, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var val))
                {
                    return null;
                }
                var bytes = BitConverter.GetBytes(BinaryPrimitives.ReverseEndianness(val));
                var text = Encoding.ASCII.GetString(bytes);
                text = text.TrimStart('\0');
                ret += text;
            }

            return ret;
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
                    var bytes = Encoding.ASCII.GetBytes(text);
                    if (bytes.Length > 0)
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