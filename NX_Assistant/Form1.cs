using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NX_Assistant.Properties;

namespace NX_Assistant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // text field for the project number / custom validation for inputing 6 digits only
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only (6 digits)","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // toggles/ untoggles the app on top of all 
            this.TopMost ^= true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // WIP - expected solution - to open the user's personal project folder in OneDrive
            // string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // System.Diagnostics.Debug.WriteLine(userName);
            var project_id = textBox1.Text;
            var O365user = textBox2.Text;
            if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length < 6)
            {
                MessageBox.Show("Please input the correct project number (6 digits)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                System.Diagnostics.Process.Start("https://stptrans-my.sharepoint.com/personal/"+O365user+"_stptrans_com/_layouts/15/onedrive.aspx?id=%2Fpersonal%2F"+O365user+"_stptrans_com%2FDocuments%2F" + project_id);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // runs the STP obfuscator
            System.Diagnostics.Process.Start("iexplore", "http://nx/Wiki/Page/Apps/XliffMtObfuscator/WindowsApplication.application");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            // takes the project number as argument, stores it into a variable, opens the project folder on the FS, the MQ project in NX and the obfuscator

            var project_id = textBox1.Text;
            if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length < 6)
            {
                MessageBox.Show("Please input the correct project number (6 digits)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                System.Diagnostics.Process.Start("iexplore", "http://nx/Wiki/Page/Apps/XliffMtObfuscator/WindowsApplication.application");
                System.Diagnostics.Process.Start("http://nx/MemoQ/ServerProject/Select.aspx?sll=&tll=&qn=" + project_id + "&qc=&qd=&qp=&qs=&qx=&sd1=&sd2=");
                string string1 = project_id.Substring(0, 2);
                string string2 = project_id.Substring(2, 2);
                string string3 = project_id.Substring(4, 2);
                var output = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\";
                try
                {
                    System.Diagnostics.Process.Start(output);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("The network path was not found, please make sure you've input the correct project number or created the folder structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         }

            private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // opens the project in NX
            var project_id = textBox1.Text;
            if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length < 6)
            {
                MessageBox.Show("Please input the correct project number (6 digits)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                System.Diagnostics.Process.Start("http://nx/Project/Structure/Detail2.aspx?px=1&p="+project_id);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // sets the default username for the OD button to work
           textBox2.Text = Settings.Default.O365;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // opens the project folder on the file server
            var project_id = textBox1.Text;
            if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length < 6)
            {
                MessageBox.Show("Please input the correct project number (6 digits)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string string1 = project_id.Substring(0, 2);
                string string2 = project_id.Substring(2, 2);
                string string3 = project_id.Substring(4, 2);
                var output = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\";
                try
                {
                    System.Diagnostics.Process.Start(output);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("The network path was not found, please make sure you've input the correct project number or created the folder structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // opens the MQ server project in NX
            var project_id = textBox1.Text;
            if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Length < 6)
            {
                MessageBox.Show("Please input the correct project number (6 digits)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                System.Diagnostics.Process.Start("http://nx/MemoQ/ServerProject/Select.aspx?sll=&tll=&qn="+project_id+"&qc=&qd=&qp=&qs=&qx=&sd1=&sd2=");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            // Button to save the defaut username in the app settings - works with OD button
            var O365text = textBox2.Text;
            Settings.Default["O365"] = textBox2.Text;
            Settings.Default.Save();
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
{
            var project_id = textBox1.Text;
            string string1 = project_id.Substring(0, 2);
            string string2 = project_id.Substring(2, 2);
            string string3 = project_id.Substring(4, 2);
            var sourcePath = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\_src";
            // Bilingual files organisation
            var targetPath_mq = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\_mq";
            var extensions_mq = new[] { ".sdlxliff", ".mqxliff" };
            {
                try
                {
                    var files_mq = (from file in System.IO.Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                    where extensions_mq.Contains(System.IO.Path.GetExtension(file), StringComparer.InvariantCultureIgnoreCase)
                                    select new
                                    {
                                        Source = file,
                                        Destination = file.Replace(sourcePath, targetPath_mq)
                                    });

                    foreach (var file in files_mq)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(file.Destination));
                        File.Copy(file.Source, file.Destination);
                    }
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("The network path was not found, please make sure you've input the correct project number or created the folder structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Bilingual files are already organised", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // TMs organisation
            var targetPath_tm = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\_tm"; ;
            var extensions_tm = new[] { ".sdltm", ".tmx" };

            {
                try
                {
                    var files_tm = (from file in System.IO.Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                    where extensions_tm.Contains(System.IO.Path.GetExtension(file), StringComparer.InvariantCultureIgnoreCase)
                                    select new
                                    {
                                        Source = file,
                                        Destination = file.Replace(sourcePath, targetPath_tm)
                                    });
                    foreach (var file in files_tm)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(file.Destination));
                        File.Copy(file.Source, file.Destination);
                    }
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("The network path was not found, please make sure you've input the correct project number or created the folder structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("TMs are already organised", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            // TBs organisation
            var targetPath_tb = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\_term";
            var extensions_tb = new[] { ".sdltb", ".tbx", ".txt" };
           
            {
                try
                {
                    var files_tb = (from file in System.IO.Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                    where extensions_tb.Contains(System.IO.Path.GetExtension(file), StringComparer.InvariantCultureIgnoreCase)
                                    select new
                                    {
                                        Source = file,
                                        Destination = file.Replace(sourcePath, targetPath_tb)
                                    });
                    foreach (var file in files_tb)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(file.Destination));
                        File.Copy(file.Source, file.Destination);
                    }
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("The network path was not found, please make sure you've input the correct project number or created the folder structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("TBs are already organised", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            var targetPath_pm = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\_pm";
            var extensions_pm = new[] { ".msg", ".xls", ".xlsx", ".csv" };
            {
                try
                {
                    var files_pm = (from file in System.IO.Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                    where extensions_pm.Contains(System.IO.Path.GetExtension(file), StringComparer.InvariantCultureIgnoreCase)
                                    select new
                                    {
                                        Source = file,
                                        Destination = System.IO.Path.Combine(targetPath_pm, System.IO.Path.GetFileName(file))
                                    });
                    foreach (var file in files_pm)
                        File.Move(file.Source, file.Destination);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("The network path was not found, please make sure you've input the correct project number or created the folder structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("PM files are already organised", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            var targetPath_ref = @"\\fs\P\STP\00\" + string1 + @"\" + string2 + @"\" + string3 + @"\_ref";
            var extensions_ref = new[] { ".doc", ".docx", ".pdf" };

            {
                try
                {
                    var files_ref = (from file in System.IO.Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                     where extensions_ref.Contains(System.IO.Path.GetExtension(file), StringComparer.InvariantCultureIgnoreCase)
                                     select new
                                     {
                                         Source = file,
                                         Destination = System.IO.Path.Combine(targetPath_ref, System.IO.Path.GetFileName(file))
                                     });
                    foreach (var file in files_ref)
                        File.Move(file.Source, file.Destination);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("The network path was not found, please make sure you've input the correct project number or created the folder structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Refeence files are already organised", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
