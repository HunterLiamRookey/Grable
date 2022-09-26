using SharpDX.Windows;
using SharpDX.D3DCompiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Memory;

namespace Grable
{
    public partial class SharpDXGrable : RenderForm
    {
        public SharpDXGrable()
        {
            Mem rust = new Mem();
            InitializeComponent();
            button1.Visible = false;
            Thread.Sleep(5000);
            label1.Text = "Opening RustClient.exe via Memory Lib...";
            if (rust.OpenProcess("RustClient"))
            {
                label1.Text = "Opening is Complete!!! Injecting DLL File via Memory...";
                Thread.Sleep(3500);
                OpenFileDialog filedialog = new OpenFileDialog();
                filedialog.Filter = "DLL File | *.dll";
                filedialog.Title = "Please Select DLL File to Inject Process";
                filedialog.InitialDirectory = Environment.CurrentDirectory;
                if(filedialog.ShowDialog() == DialogResult.OK)
                {
                    rust.InjectDll(filedialog.FileName);
                    Thread.Sleep(5000);
                    button1.Visible = true;
                    label1.Text = "Injecting is Complete Success... Now You Can Exit this Program!!!" + Environment.NewLine + $"FileName of this DLL: {filedialog.FileName}";
                }
                else
                {
                    MessageBox.Show("Injecting Is Not Complete!!!" + Environment.NewLine + "Try Run RustClient.exe Without EAC(EasyAntiCheat) and Try Again", "Grable Injector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(54);
                }
            }
            else
            {
                Thread.Sleep(7500);
                label1.Text = "RustClient is Not Founded... Pls Try Open RustClient.exe as Admin or Just Launch RustClient.exe";
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(521);
        }
    }
}
