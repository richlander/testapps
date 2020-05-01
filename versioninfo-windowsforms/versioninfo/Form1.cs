using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Information");
            listView1.Columns[0].Width = 1000;
            listView1.View = View.List;

            var collection = new ListViewItem[]
                {
                    
                    new ListViewItem("**Runtime Information**"),
                    new ListViewItem($"{nameof(RuntimeInformation.FrameworkDescription)}: {RuntimeInformation.FrameworkDescription}"),
                    new ListViewItem($"CoreCLR Build: {((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[0]}"),
                    new ListViewItem($"CoreCLR Hash: {((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[1]}"),
                    new ListViewItem($"CoreFX Build: {((AssemblyInformationalVersionAttribute[])typeof(Uri).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[0]}"),
                    new ListViewItem($"CoreFX Hash: {((AssemblyInformationalVersionAttribute[])typeof(Uri).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[1]}"),
                    new ListViewItem(""),
                    new ListViewItem("**Environment info**"),
                    new ListViewItem($"{nameof(Environment.OSVersion)}: {Environment.OSVersion}"),
                    new ListViewItem($"{nameof(RuntimeInformation.OSDescription)}: {RuntimeInformation.OSDescription}"),
                    new ListViewItem($"{nameof(RuntimeInformation.OSArchitecture)}: {RuntimeInformation.OSArchitecture}"),
                    new ListViewItem($"{nameof(Environment.ProcessorCount)}: {Environment.ProcessorCount}")
            };
            
            foreach(var item in collection)
            {
                listView1.Items.Add(item);
            }
        }
    }
}
