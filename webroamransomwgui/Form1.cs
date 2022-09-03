using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webroamransomwgui
{
    public partial class Form1 : Form
    {
        string[] Args = null;
        public Form1(string[] args)
        {
            Args = args;
            InitializeComponent();
        }
        public Form1()
        {
            InitializeComponent();
            List<string> er = new List<string>();
            int indx = 0;
            string filename2 = $"{ (System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb";
            foreach (DataRow row in Csv.DataSetGet(filename2, "?", out er).Rows)
            {

                //if (indx == rw.Count - 1)
                if (Directory.Exists(row[5].ToString()) || File.Exists(row[5].ToString()))
                {
                    indx++;
                string fldr = "";
                fldr = row[3]?.ToString().ToLower();
                //MessageBox.Show("s: "+fldr);
                if (fldr.Contains("*"))
                    continue;
                watcher = new FileSystemWatcher(fldr);
                
                    watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.Security;
                    watcher.Changed += delegate (object a, FileSystemEventArgs b)
                    {
                       

                //if (indx == rw.Count - 1)
                //  break;MessageBox.Show("s: ");
                indx++;

                        
                            if (!isMyUpPerm)
                            {
                            var mywatcher = (FileSystemWatcher)a;
                            isMyUpPerm = true;
                                mywatcher.EnableRaisingEvents = false;
                            AccessControl.SetAccessFileDenyOrAllow(fldr, row[0].ToString().ToLower() == "true" ? row[5].ToString().ToLower() == "true" : false);
                                isMyUpPerm = false;
                                mywatcher.EnableRaisingEvents = true;
                        // MessageBox.Show("11");
                    
                        
                    }
            };
                
                    watcher.EnableRaisingEvents = true;

                    watchers.Add(watcher);
                }
            }
        }

        private static bool VerifyAuthenticodeSignature(string providedFilePath)
        {
            bool isSigned = true;
            string fileName = Path.GetFileName(providedFilePath);
            string calculatedFullPath = Path.GetFullPath(providedFilePath);

            if (File.Exists(calculatedFullPath))
            {
                //Log.LogMessage(string.Format("Verifying file '{0}'", calculatedFullPath));
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.AddCommand("Get-AuthenticodeSignature", true);
                    ps.AddParameter("FilePath", calculatedFullPath);
                    var cmdLetResults = ps.Invoke();

                    foreach (PSObject result in cmdLetResults)
                    {
                        Signature s = (Signature)result.BaseObject;
                        isSigned = s.Status.Equals(SignatureStatus.Valid);
                        if (isSigned == false)
                        {
                            //ErrorList.Add(string.Format("!!!AuthenticodeSignature status is '{0}' for file '{1}' !!!", s.Status.ToString(), calculatedFullPath));
                        }
                        else
                        {
                            Console.WriteLine(string.Format("!!!AuthenticodeSignature status is '{0}' for file '{1}' !!!", s.Status.ToString(), calculatedFullPath));

                        }
                        break;
                    }
                }
            }
            else
            {
                //ErrorList.Add(string.Format("File '{0}' does not exist. Unable to verify AuthenticodeSignature", calculatedFullPath));
                isSigned = false;
            }

            return isSigned;
        }
        FileSystemWatcher watcher;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 11);
                //  MessageBox.Show(Environment.UserDomainName+"\\"+Environment.UserName);
                DataTable tbl = null;
                var cl = dataGridView1.Columns[0] as DataGridViewComboBoxColumn;
                //cl.Items.Add("Include");
                cl.Items.Add("Exclude Folder");
                cl.Items.Add("Exclude Program");
                if (Args == null || Args.Length == 0)
                {
                    Task.Factory.StartNew(() =>
                    {
                    // Process.Start("netsh advfirewall firewall add rule name=\"mssqlce\" dir=out remoteport=80 protocol=TCP action=block");
                    List<string> lser = new List<string>();
                        string filename = $"{ (System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb";
                    //MessageBox.Show(filename);
                    tbl = Csv.DataSetGet(filename, "?", out lser);
                    // this.BeginInvoke(new MethodInvoker(delegate() { MessageBox.Show(tbl.Rows.Count.ToString()); }));
                    //SqlReaderWriter.ReadQuery("SELECT FolderName, PermittedExeFile, OnlySigned, Subfolders, State FROM tblRansMain");
                }).ContinueWith((t) =>
                {
                    int ir = 0;
                    if (tbl.Rows.Count > 0)
                    {
                        // dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                        foreach (DataRow row in tbl.Rows)
                        {
                            Image imgc;
                            if (File.Exists(row[4].ToString()) && VerifyAuthenticodeSignature(row[4].ToString()))
                                imgc = webroamransomwgui.Properties.Resources.OK;
                            else
                                imgc = webroamransomwgui.Properties.Resources.NOTOK;
                            // MessageBox.Show(row[4].ToString());
                            if (row[4].ToString() != "*" && row[3].ToString() != "*")
                            {

                                int eindex = dataGridView2.Rows.Count - 1;
                                dataGridView2.Invoke(new MethodInvoker(() =>
                                {
                                    bool enbl = row[0].ToString().ToLowerInvariant() == "true";
                                    dataGridView2.Rows.Add(row[3].ToString().Trim(), null, row[1].ToString().Trim().ToLowerInvariant() == "true", row[4].ToString().Trim(), null,
                                        row[2].ToString().Trim().ToLowerInvariant() == "true", imgc, row[5].ToString().Trim().ToLowerInvariant() == "true", enbl, null);
                                    if (!enbl)
                                        dataGridView2.Rows[eindex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                                    //MessageBox.Show(row[0].ToString().ToLowerInvariant());
                                    Bs.Add(row[0].ToString().ToLowerInvariant() == "true");
                                }));
                                continue;
                            }
                            dataGridView1.Invoke(new MethodInvoker(() => { dataGridView1.Rows.Add("Exclude Folder", row[3].ToString().Trim(), null, row[1].ToString().Trim().ToLowerInvariant() == "true", row[4].ToString().Trim(), null, imgc); }));
                            if (row[4].ToString() == "*")
                            {
                                dataGridView1.Invoke(new MethodInvoker(() =>
                                {
                                    dataGridView1.Rows[ir].Cells[4].Value = "*";
                                    ((DataGridViewComboBoxCell)dataGridView1.Rows[ir].Cells[0]).Value = "Exclude Folder";
                                }));
                            }
                            else
                            {

                            }
                            if (row[3].ToString() == "*")
                            {
                                dataGridView1.Invoke(new MethodInvoker(() =>
                                {
                                    dataGridView1.Rows[ir].Cells[1].Value = "*";
                                    ((DataGridViewComboBoxCell)dataGridView1.Rows[ir].Cells[0]).Value = "Exclude Program";
                                }));
                            }
                            ir++;
                        }
                    }

                });
                }
                else
                {
                    tabControl1.TabPages.RemoveAt(1);
                    dataGridView1.Rows.Add("Exclude Program", "*", null, true, Args[0], null);


                }
                /*  */
                //var rw = dataGridView2.Rows;
                List<string> er = new List<string>();
                int indx = 0;
                string filename2 = $"{ (System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb";
                foreach (DataRow row in Csv.DataSetGet(filename2, "?", out er).Rows)
                {

                    //if (indx == rw.Count - 1)
                    //  break;MessageBox.Show("s: ");
                    indx++;

                    string fldr;
                    fldr = row[3]?.ToString().ToLower();
                    if (!fldr.Contains("*"))
                    {
                        if (!(File.Exists(fldr) || Directory.Exists(fldr)))
                            continue;
                        //AccessControl.SetAccessFileDenyOrAllow(fldr, System.Security.AccessControl.FileSystemRights.Read, System.Security.AccessControl.AccessControlType.Allow);                           
                      
                        isMyUpPerm = true;
                        AccessControl.SetAccessFileDenyOrAllow(fldr, row[0].ToString().ToLower() == "true" ? row[5].ToString().ToLower() == "true" : false);
                        isMyUpPerm = false;
                    }

                }
                timer1.Start();
            }
            catch
            {

            }
            }
    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dataGridView1.RowCount != 0)
                {
                    if (e.ColumnIndex == 2)
                    {
                        var fd = new FolderBrowserDialog();
                        if (fd.ShowDialog() != DialogResult.Cancel)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[1].Value = fd.SelectedPath;
                            dataGridView1.Enabled = false;
                            dataGridView1.Enabled = true;
                        }
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        var fd = new OpenFileDialog();
                        fd.Filter = "*.exe|*.exe";
                        if (fd.ShowDialog() != DialogResult.Cancel)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[4].Value = fd.FileName;
                            dataGridView1.Rows[e.RowIndex].Cells[6].Value = (VerifyAuthenticodeSignature(fd.FileName) ? webroamransomwgui.Properties.Resources.OK : webroamransomwgui.Properties.Resources.NOTOK);
                            dataGridView1.Enabled = false;
                            dataGridView1.Enabled = true;
                        }
                    }
                }
            }
            catch
            { }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dataGridView1.RowCount != 0)
            {
                if (e.ColumnIndex == 7)
                {
                    for (int c = 0; c < dataGridView1.RowCount; c++)
                    {
                        if (c != e.RowIndex && e.RowIndex >= 0 && dataGridView1.Rows[c].Cells[1 + 1].Value != null && dataGridView1.Rows[e.RowIndex].Cells[1 + 1].Value.ToString().ToLower().TrimEnd('\\') == dataGridView1.Rows[c].Cells[1 + 1].Value.ToString().ToLower().TrimEnd('\\'))
                        {
                            dataGridView1.Rows[c].Cells[1 + 6].Value = Boolean.Parse(dataGridView1.Rows[e.RowIndex].Cells[1 + 6].Value.ToString());
                        }
                    }
                }
                else if (e.ColumnIndex == 0)
                {
                        if ((dataGridView1.Rows[e.RowIndex].Cells[0]).Value.ToString() == "Exclude Folder")
                        {
                            (dataGridView1.Rows[e.RowIndex].Cells[4]).Value = "*";
                            if ((dataGridView1.Rows[e.RowIndex].Cells[1]).Value.ToString() == "*")
                                (dataGridView1.Rows[e.RowIndex].Cells[1]).Value = "";
                        }
                        else if ((dataGridView1.Rows[e.RowIndex].Cells[0]).Value.ToString() == "Exclude Program")
                        {
                            (dataGridView1.Rows[e.RowIndex].Cells[1]).Value = "*";
                            if ((dataGridView1.Rows[e.RowIndex].Cells[4]).Value.ToString() == "*")
                                (dataGridView1.Rows[e.RowIndex].Cells[4]).Value = "";
                        }
                        else
                        {
                            if((dataGridView1.Rows[e.RowIndex].Cells[4]).Value.ToString() == "*")
                            (dataGridView1.Rows[e.RowIndex].Cells[4]).Value = "";

                            if((dataGridView1.Rows[e.RowIndex].Cells[1]).Value.ToString() == "*")
                            (dataGridView1.Rows[e.RowIndex].Cells[1]).Value = "";
                        }
                }
                else if (e.ColumnIndex == 4)
                {
                        if ((dataGridView1.Rows[e.RowIndex].Cells[4]).Value.ToString() == "*")
                        {
                            (dataGridView1.Rows[e.RowIndex].Cells[0]).Value = "Exclude Folder";
                        }
                      /*  else if ((dataGridView1.Rows[e.RowIndex].Cells[1]).Value.ToString() != "*")
                        {
                            (dataGridView1.Rows[e.RowIndex].Cells[0]).Value = "Include";
                        }*/
                }
                    else if (e.ColumnIndex == 1)
                    {
                        if ((dataGridView1.Rows[e.RowIndex].Cells[1]).Value.ToString() == "*")
                        {
                            (dataGridView1.Rows[e.RowIndex].Cells[0]).Value = "Exclude Program";
                        }
                        /*else if ((dataGridView1.Rows[e.RowIndex].Cells[4]).Value.ToString() != "*")
                        {
                            (dataGridView1.Rows[e.RowIndex].Cells[0]).Value = "Include";
                        }*/
                    }
                }
            }
            catch
            { }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GenerateConsoleCtrlEvent(ConsoleCtrlEvent sigevent, int dwProcessGroupId);

        [DllImport("kernel32.dll")]
        static extern bool ProcessIdToSessionId(uint dwProcessId, out uint pSessionId);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool AttachConsole(uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handler, bool add);
        delegate Boolean ConsoleCtrlDelegate(ConsoleCtrlEvent type);
        [DllImport("kernel32.dll")] [return: MarshalAs(UnmanagedType.Bool)] static extern bool AllocConsole();

        public enum ConsoleCtrlEvent
        {
            CTRL_C = 0,
            CTRL_BREAK = 1,
            CTRL_CLOSE = 2,
            CTRL_LOGOFF = 5,
            CTRL_SHUTDOWN = 6
        }
        bool isMyUpPerm = false;
        List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                 var   c = row.Cells[1];
                    if (c != null && c.Value != null && c.Value.ToString().ToLowerInvariant().Contains(Environment.GetFolderPath(Environment.SpecialFolder.Windows).ToLowerInvariant()))
                    {
                        c.Selected = true;
                        MessageBox.Show("Rules can't be applied to Windows Directory Files!");
                        return;
                    }
                }
                foreach (DataGridViewRow row in dataGridView2.Rows)
                //foreach (DataGridViewCell c in row.Cells)
                {
                    var c = row.Cells[0];
                    if (c != null && c.Value != null && c.Value.ToString().ToLowerInvariant().Contains(Environment.GetFolderPath(Environment.SpecialFolder.Windows).ToLowerInvariant()))
                    {
                        c.Selected = true;
                        MessageBox.Show("Rules can't be applied to Windows Directory Files!");
                        return;
                    }
                }
                this.Text += " - Waiting..";
                button1.Enabled = false;
                dataGridView1.ClearSelection();
       
                bool starred = true;
                bool filled = true;

                int rc = dataGridView1.RowCount;
                bool colf = false;

              
                if (rc > 0)
                {
                    foreach (DataGridViewCell c in dataGridView1.Rows[rc - 1].Cells)
                    {                       
                        if (c.ColumnIndex == dataGridView1.ColumnCount - 2)
                            break;
                        if (c.Value != null && c.Value.ToString() != "")
                        {
                            colf = true;
                        }
                    }
                }
                if (!colf)
                    rc--;
                for (int i = 0; i < rc; i++)
                {                 
                    if ((dataGridView1.Rows[i].Cells[0].Value == null) || (dataGridView1.Rows[i].Cells[1].Value==null||dataGridView1.Rows[i].Cells[1].Value.ToString() != "*") && (dataGridView1.Rows[i].Cells[4].Value==null||dataGridView1.Rows[i].Cells[4].Value.ToString() != "*"))
                    {
                        starred = false;
                        if ((dataGridView1.Rows[i].Cells[1]).Value == null)
                            dataGridView1.Rows[i].Cells[1].Selected = true;
                        if ((dataGridView1.Rows[i].Cells[4]).Value == null)
                            dataGridView1.Rows[i].Cells[4].Selected = true;
                        if (dataGridView1.Rows[i].Cells[0].Value == null)
                            dataGridView1.Rows[i].Cells[0].Selected = true;
                        break;
                    }
                    if ((dataGridView1.Rows[i].Cells[1]).Value == null || (dataGridView1.Rows[i].Cells[4]).Value == null)
                    {
                        filled = false;
                        break;
                    }
                }
                if (!starred)
                {
                    MessageBox.Show("Exclude: One of the paths should be '*' depending on exclude type!");
                    button1.Enabled = true;
                    this.Text = this.Text.Replace(" - Waiting..", "");
                    return;
                }
                rc = dataGridView2.RowCount;
                colf = false;
                if(rc>0)
                {
                    dataGridView2.ClearSelection();
                    foreach (DataGridViewCell c in dataGridView2.Rows[rc-1].Cells)
                    {
                       
                        if (c.ColumnIndex == dataGridView1.ColumnCount - 2)
                            break;
                        if (c.Value != null && c.Value.ToString() != "" && c.Value.ToString() != "False")
                            colf = true;
                    }
                }
                if (!colf)
                    rc--;
                for (int i = 0; i < rc; i++)
                {
                    if ((dataGridView2.Rows[i].Cells[3].Value == null) || ((dataGridView2.Rows[i].Cells[0]).Value == null))
                    {
                        filled = false;
                        if ((dataGridView2.Rows[i].Cells[3]).Value == null)
                            dataGridView2.Rows[i].Cells[3].Selected = true;
                        if ((dataGridView2.Rows[i].Cells[0]).Value == null)
                            dataGridView2.Rows[i].Cells[0].Selected = true;
                    }
                }
                if (!filled)
                {
                    MessageBox.Show("Please fill all required fields!");
                    button1.Enabled = true;
                    this.Text = this.Text.Replace(" - Waiting..", "");
                    return;
                }
                string filename = $"{ (System.IO.Path.GetDirectoryName(Application.ExecutablePath))}\\app.wrdb";
                File.Copy("app.wrdb", "app.wrdb.bak", true);
                if (Args == null || Args.Length == 0)
                {
                    //SqlReaderWriter.DeleteQuery("DELETE FROM tblRansMain");
                    File.Delete(filename);
                    File.AppendAllText(filename, "State?Subfolders?OnlySigned?FolderName?PermittedExeFile?RunAs?"+Environment.NewLine, new UTF8Encoding(false));
                }
               
               // int mycount = (SqlReaderWriter.CountOfRow("tblRansMain") + 1);
                var rw = dataGridView1.Rows;
                int indx = 0;
                
                foreach (DataGridViewRow row in rw)
                {
                    if (indx == rw.Count)
                        break;
                    indx++;
                    if (row.Cells[1].Value != null)
                    {
                        string fldr = row.Cells[1].Value.ToString().Trim().ToLower();
                        if (!fldr.EndsWith("\\")&&!fldr.Contains("*"))
                            fldr += "\\";

                        // MessageBox.Show(row.Cells[7].ToString());
                        string str = /*"INSERT INTO tblRansMain (FolderName, PermittedExeFile, Subfolders, OnlySigned, State) VALUES ('" +*/
                              "TRUE" + "?" + row.Cells[3].Value?.ToString().ToUpper() + "?FALSE?" + fldr + "?" + row.Cells[4].Value.ToString().Trim().ToLower() + "?" + "FALSE" + "?";
                          //MessageBox.Show(str);
                        File.AppendAllText(filename, str + Environment.NewLine, new UTF8Encoding(false));
                        //SqlReaderWriter.ExecuteQuery(str);
                        //mycount++;
                    }
                }
                rw = dataGridView2.Rows;
                indx = 0;
                foreach (DataGridViewRow row in rw)
                {
                  
                    if (indx == rw.Count - 1)
                        break;
                    indx++;
                    if (row.Cells[3].Value != null)
                    {
                        string fldr = row.Cells[0].Value.ToString().Trim().ToUpper();                       
                        string str = row.Cells[8].Value?.ToString().Trim().ToUpper() + "?" + row.Cells[2].Value?.ToString().Trim().ToUpper() + "?" + (row.Cells[5].Value?.ToString().ToUpper()) + "?" + (row.Cells[0].Value?.ToString().ToLower()) + "?" + (row.Cells[3].Value?.ToString().ToLower()) + "?" + (row.Cells[7].Value?.ToString().ToLower() == "true" ? "TRUE" : "FALSE") + "?";
                        //MessageBox.Show("s: "+str);
                        File.AppendAllText(filename, str + Environment.NewLine, new UTF8Encoding(false));
                        fldr = row.Cells[0].Value?.ToString().ToLower();
                        if (!fldr.Contains("*"))
                        {
                            //AccessControl.SetAccessFileDenyOrAllow(fldr, System.Security.AccessControl.FileSystemRights.Read, System.Security.AccessControl.AccessControlType.Allow);                           
                            /*   var watcher = new FileSystemWatcher(fldr);
                               watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.Security;
                               watcher.Changed += delegate (object a, FileSystemEventArgs b) 
                               {
                                   //MessageBox.Show("1");                                
                                   if(!isMyUpPerm)
                                   {
                                       isMyUpPerm = true;
                                       AccessControl.SetAccessFileDenyOrAllow(fldr);
                                      // MessageBox.Show("11");
                                   }
                               };
                               watcher.EnableRaisingEvents = true;
                               watchers.Add(watcher);*/
                            //MessageBox.Show(row.Cells[7].Value?.ToString().ToLower());
                          
                                // AccessControl.SetAccessFileDenyOrAllow(fldr, System.Security.AccessControl.FileSystemRights.Read, System.Security.AccessControl.AccessControlType.Allow);

                                isMyUpPerm = true;
                            if(Directory.Exists(fldr))
                                AccessControl.SetAccessFileDenyOrAllow(fldr, row.Cells[8].Value.ToString().ToLower() == "true"?row.Cells[7].Value.ToString().ToLower() == "true":false);
                                isMyUpPerm = false;

                            
                        }
                        // mycount++;
                    }
                }
                //button1.Enabled = true;
                /* System.Diagnostics.Process process = new System.Diagnostics.Process();
                 System.Diagnostics.ProcessStartInfo startInfo = new
                 System.Diagnostics.ProcessStartInfo();
                 startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 startInfo.CreateNoWindow = true;
                 startInfo.FileName = "cmd.exe";
                 startInfo.Arguments = $"/C copy /y {System.IO.Path.GetDirectoryName(Application.ExecutablePath)}app.wrdb {Directory.GetParent(System.IO.Path.GetDirectoryName(Application.ExecutablePath))}app.wrdb";
                 process.StartInfo = startInfo;
                // process.Start();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(Environment.NewLine+ex.ToString());
                button1.Enabled = true;
                this.Text = this.Text.Replace(" - Waiting..", "");
                return;
            }
              File.Copy(".\\app.wrdb", "..\\app.wrdb", true);
         /*   Task.Factory.StartNew((Action)delegate ()
            {*/
                
                    /*TcpClient client = new TcpClient("localhost", 2555);
                    var netstrm = client.GetStream();
                    string s = "UPDATEDB";
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(s);

                    netstrm.Write(buffer, 0, buffer.Length);
                    netstrm.Flush();
                    client.Close();*/
                    
               /*        try
                        {
                Process[] p1 = Process.GetProcessesByName("WrArServ");
                if (p1.Length > 0)
                {
                    var p = p1[0];
                    FreeConsole();
                    if (AttachConsole((uint)p.Id))
                    {
                        //uint spid= p.SessionId;

                        // MessageBox.Show(Process.GetProcessesByName("WRAREngine").Length.ToString() + Environment.NewLine + spid);
                        SetConsoleCtrlHandler(null, true);

                        //                            GenerateConsoleCtrlEvent(ConsoleCtrlEvent.CTRL_C, p.SessionId);
                        GenerateConsoleCtrlEvent(ConsoleCtrlEvent.CTRL_C, 0);
                        //
                       // Thread.Sleep(2000);
                        FreeConsole();
                        SetConsoleCtrlHandler(null, false);
                    }
                }
                        }
                        catch (Exception em) { File.AppendAllText("wrlog.txt", new StackFrame(1, true).GetFileName() + " " + new StackFrame(1, true).GetFileLineNumber() + Environment.NewLine + em.ToString() + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine); }
               */
                   
                /*
            }).ContinueWith((a) =>
            {
              */  this.Text = this.Text.Replace(" - Waiting..", "");
                
                this.button1.BeginInvoke(new MethodInvoker(delegate {MessageBox.Show("The changes were saved successfully!"); button1.Enabled = true; this.Close(); }));
               
            //});


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dataGridView2.RowCount != 0)
                {
                    if (e.ColumnIndex == 1)
                    {
                        var fd = new FolderBrowserDialog();
                        if (fd.ShowDialog() != DialogResult.Cancel)
                        {
                            dataGridView2.Rows[e.RowIndex].Cells[0].Value = fd.SelectedPath;
                            dataGridView2.Enabled = false;
                            dataGridView2.Enabled = true;
                        }
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        var fd = new OpenFileDialog();
                        fd.Filter = "*.exe|*.exe";
                        if (fd.ShowDialog() != DialogResult.Cancel)
                        {
                            dataGridView2.Rows[e.RowIndex].Cells[3].Value = fd.FileName;
                            dataGridView2.Rows[e.RowIndex].Cells[6].Value = (VerifyAuthenticodeSignature(fd.FileName) ? webroamransomwgui.Properties.Resources.OK : webroamransomwgui.Properties.Resources.NOTOK);
                            dataGridView2.Enabled = false;
                            dataGridView2.Enabled = true;
                        }
                    }
                    else if (e.ColumnIndex == 8 && e.RowIndex >= 0 && (dataGridView2.RowCount > 0))
                    {dataGridView2.CurrentCell.Value = !Bs[e.RowIndex];
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        Bs[e.RowIndex] = !Bs[e.RowIndex];
                        if (dataGridView2.CurrentCell != null && dataGridView2.CurrentCell.Value != null)
                        {//dataGridView2.RefreshEdit();                        
                            if (!String.IsNullOrWhiteSpace(dataGridView2.CurrentCell.Value.ToString()) & dataGridView2.CurrentCell.ValueType == typeof(bool) && Bs[e.RowIndex] == false)
                            {
                                
                                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                            }
                        }
                    }
                    else if (e.ColumnIndex == 9)
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
                //dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch
            { }

        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }
        List<bool> Bs = new List<bool>();
        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            if (e.RowIndex == Bs.Count)
            //dataGridView2.Rows[e.RowIndex ].Cells["Enabled"].Value = true;
            {
                dataGridView2.Rows[e.RowIndex].Cells[8].Value = dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGoldenrodYellow;
                Bs.Add(true);
            }
        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   if (e.ColumnIndex == 9)
                {
                    dataGridView2.Rows.RemoveAt(e.RowIndex);
                    dataGridView2.CommitEdit(DataGridViewDataErrorContexts.RowDeletion);
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

    }
}
