using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BelSoft;

namespace ExBinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private InvokeDLL dll;
        private void btnBindAndRun_Click(object sender, EventArgs e)
        {
            dll = new InvokeDLL();
            try
            {
                dll.Run(@"DynBindingDLL.dll", "PrintHello", "Today is: ", 2);
            }
            catch (TargetParameterCountException tpce)
            {
                MessageBox.Show(tpce.Message);
            }
            catch (MissingMethodException mme)
            {
                MessageBox.Show(mme.Message);
            }
            catch (FileNotFoundException fne)
            {
                MessageBox.Show(fne.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            dll?.UnloadDomain();
        }
    }
}