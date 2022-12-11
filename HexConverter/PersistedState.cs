﻿// Copyright (c) 2022 Alex Kravchenko

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace HexConverter
{
    internal class PersistedState
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool Maximised { get; set; }
        public bool Minimised { get; set; }

        public string Hex1 { get; set; } = string.Empty;
        public string Hex2 { get; set; } = string.Empty;
        public string Dec1 { get; set; } = string.Empty;
        public string Dec2 { get; set; } = string.Empty;

        public string Format1 { get; set; } = string.Empty;
        public string Format2 { get; set; } = string.Empty;

        private static string GetFileName()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filename = "state.json";
            return directory == null ? filename : Path.Combine(directory, filename);
        }

        internal void Save()
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);

            File.WriteAllText(GetFileName(), jsonString);
        }

        internal static PersistedState? Restore()
        {
            var filename = GetFileName();
            if (!File.Exists(filename))
                return null;

            try
            {
                var text = File.ReadAllText(filename);
                var state = JsonSerializer.Deserialize<PersistedState>(text);
                return state;
            }
            catch
            {
                return null;
            }
        }
    }
}
