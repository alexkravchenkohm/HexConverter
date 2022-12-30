// Copyright (c) 2022 Alex Kravchenko

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace HexConverter
{
    partial class AboutBoxMain : Form
    {
        private const string LinkDataLicense = "LICENSE.txt";
        private const string LinkDataSource = @"https://github.com/alexkravchenkohm/HexConverter";
        private const string LinkDataBinaries = @"https://github.com/alexkravchenkohm/HexConverter/releases";

        public AboutBoxMain()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
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

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static string? AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version?.ToString();
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

        private void LinkLabelLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.LinkData is not string fileName)
                return;
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (directory == null)
                return;

            var p = new Process
            {
                StartInfo = new ProcessStartInfo(Path.Combine(directory, fileName))
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }

        private void LinkLabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(LinkDataSource)
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }

        private void LinkLabelBinaries_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(LinkDataBinaries)
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }
    }
}
