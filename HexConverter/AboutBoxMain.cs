using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexConverter
{
    partial class AboutBoxMain : Form
    {
        public AboutBoxMain()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        private void AboutBoxMain_Load(object sender, EventArgs e)
        {
            linkLabelLicense.Links.Add(new LinkLabel.Link() { LinkData = "LICENSE"});
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
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

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
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

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void LinkLabelLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var fileName = e.Link.LinkData as string;
            if (fileName == null)
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

        private void linkLabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var p = new Process
            {
                //StartInfo = new ProcessStartInfo(@"https://github.com/alexkravchenkohm/HexConverter/tree/v1.0.1-alpha")
                StartInfo = new ProcessStartInfo(@"https://github.com/alexkravchenkohm/HexConverter")
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }

        private void linkLabelBinaries_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(@"https://github.com/alexkravchenkohm/HexConverter/releases")
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }
    }
}
