// Copyright (c) 2022 - 2023 Alex Kravchenko

using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace HexConverter
{
    partial class AboutBoxMain : Form
    {
        private const string LinkDataLicense = "LICENSE.txt";
        private const string LinkDataSource = @"https://github.com/alexkravchenkohm/HexConverter";
        private const string LinkDataBinaries = @"https://github.com/alexkravchenkohm/HexConverter/releases";

        public AboutBoxMain(string productName)
        {
            InitializeComponent();
            Text = $"About {productName}";
            labelVersion.Text = AssemblyVersionMajorMinor;
            labelCopyright.Text = AssemblyCopyright;
        }

        private void AboutBoxMain_Load(object sender, EventArgs e)
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(linkLabelLicense, LinkDataLicense);
            toolTip.SetToolTip(linkLabelSource, LinkDataSource);
            toolTip.SetToolTip(linkLabelBinaries, LinkDataBinaries);

            linkLabelLicense.Links.Add(new LinkLabel.Link() { LinkData = LinkDataLicense });
        }

        #region Assembly Attribute Accessors

        public static string? AssemblyVersionMajorMinor
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
                if (string.IsNullOrEmpty(version))
                    return null;
                // Remove two last components from the version string
                var tokens = version.Split(new char[] { '.' });
                if (tokens.Length < 2)
                    return version;

                return $"{tokens[0]}.{tokens[1]}";
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        #endregion

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string? processStartTarget = null;

            if (sender == linkLabelLicense)
            {
                if (e.Link.LinkData is string fileName)
                {
                    var directory = AppContext.BaseDirectory;
                    if (directory is not null)
                    {
                        processStartTarget = Path.Combine(directory, fileName);
                    }
                    else
                    {
                        SystemSounds.Beep.Play();
                    }
                }
            }
            else if (sender == linkLabelSource)
            {
                processStartTarget = LinkDataSource;
            }
            else if (sender == linkLabelBinaries)
            {
                processStartTarget = LinkDataBinaries;
            }

            OpenLink(processStartTarget);
        }

        private static void OpenLink(string? target)
        {
            if (target is not null)
            {
                try
                {
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo(Path.Combine(target))
                        {
                            UseShellExecute = true
                        }
                    };
                    process.Start();
                }
                catch
                {
                    SystemSounds.Beep.Play();
                }
            }
        }
    }
}
