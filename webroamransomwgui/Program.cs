using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webroamransomwgui
{

    public static class AccessControl
    {
        public static void AddFileSecurity(string fileName, string account,
              FileSystemRights rights, AccessControlType controlType)
        {

            // Get a FileSecurity object that represents the
            // current security settings.
            if (Directory.Exists(fileName))
            {
                var files = Directory.EnumerateFiles(fileName);

                foreach (var f in files)
                {
                    FileSecurity fSecurity = File.GetAccessControl(f);

                    // Add the FileSystemAccessRule to the security settings.
                    fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                        rights, controlType));

                    // Set the new access settings.
                    File.SetAccessControl(f, fSecurity);
                }
            }
            else if (File.Exists(fileName))
            {
                FileSecurity fSecurity = File.GetAccessControl(fileName);
                fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                        rights, controlType));
                File.SetAccessControl(fileName, fSecurity);
            }
            /*  var myDirectoryInfo = new DirectoryInfo(fileName);
              var myDirectorySecurity = myDirectoryInfo.GetAccessControl();
              myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(account, rights, InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, controlType));
              myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(account, rights, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, controlType));
              myDirectoryInfo.SetAccessControl(myDirectorySecurity);*/
        }

        public static void RemoveFileSecurityALL(string fileName, bool asAdmin)/*, string account,
            FileSystemRights rights, AccessControlType controlType)*/
        {
            try
            {
                // MessageBox.Show(fileName, asAdmin.ToString());
                // Get a FileSecurity object that represents the
                // current security settings.
                if (Directory.Exists(fileName))
                {


                    // MessageBox.Show(fileName+Environment.NewLine+ Environment.UserDomainName + "\\" + Environment.UserName + Environment.NewLine+asAdmin);
                    Directory.GetAccessControl(fileName).SetAccessRuleProtection(true, false);
                    DirectorySecurity ds = Directory.GetAccessControl(fileName);// new DirectorySecurity();
                    ds.SetAccessRuleProtection(true, false);
                    ds.RemoveAccessRuleAll(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, !asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, AccessControlType.Allow));
              //       ds.RemoveAccessRuleAll(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                //    ds.RemoveAccessRuleAll(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));

                    //ds.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                    //ds.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                      ds.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                      ds.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                      ds.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                      ds.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                      
                   // Directory.SetAccessControl(fileName, ds);
                    //  ds.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, AccessControlType.Allow));
                    ds.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                    ds.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                    Directory.SetAccessControl(fileName, ds);
                   // ds.SetAccessRuleProtection(true, false);
                    //  Directory.GetAccessControl(fileName).SetAccessRuleProtection(true, false);
                    //   var dSecurity = ds;
                    /*    dSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                        dSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                        dSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + "Administrators", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                        dSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + "Administrators", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                        dSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.ReadAndExecute, InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                        dSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.ReadAndExecute, InheritanceFlags.ObjectInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                        */
                    //Directory.SetAccessControl(fileName, new DirectorySecurity());
                    var files = Directory.EnumerateFiles(fileName);
                    foreach (var f in files)
                    {
                        FileSecurity fSecurity = new FileSecurity();/*File.GetAccessControl(f);
                        var collection = fSecurity.GetAccessRules(false, true, typeof(System.Security.Principal.NTAccount));
                        // Remove the FileSystemAccessRule from the security settings.
                        foreach (FileSystemAccessRule cc in collection)
                        {

                            fSecurity.SetAccessRuleProtection(true, false);
                            fSecurity.RemoveAccessRuleAll(cc);

                        }*/
                                                                    //  fSecurity.SetAccessRuleProtection(false, false);
                      //  fSecurity.SetAccessRuleProtection(true, false);
                        fSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                        fSecurity.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                        /*fSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                        fSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                        fSecurity.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                        fSecurity.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                        */
                        fSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, AccessControlType.Allow));
                        fSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, AccessControlType.Allow));

                        /* fSecurity.RemoveAccessRuleAll(new FileSystemAccessRule(account,
                             rights, controlType));      */
                        // Set the new access settings.
                        /*  File.GetAccessControl(f).SetAccessRuleProtection(true, false);
                          File.GetAccessControl(f).RemoveAccessRuleAll(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                          File.GetAccessControl(f).RemoveAccessRuleAll(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                          File.GetAccessControl(f).RemoveAccessRuleAll(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));*/
                        try
                        {
                            File.SetAccessControl(f, fSecurity);
                        }
                        catch
                        {

                        }
                        //   MessageBox.Show(f);
                    }
                    /* var fsecMe = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.ReadAndExecute, AccessControlType.Allow);
                     //MessageBox.Show(fileName);
                     var dsec = new DirectorySecurity(fileName, AccessControlSections.Access);
                     dsec.PurgeAccessRules(fsecMe.IdentityReference);
                     Directory.SetAccessControl(fileName, dsec);*/
                }
                else
                {
                    FileSecurity fSecurity = File.GetAccessControl(fileName);
                    /*  var collection = fSecurity.GetAccessRules(false, false, typeof(System.Security.Principal.NTAccount));
                      // Remove the FileSystemAccessRule from the security settings.
                      foreach (FileSystemAccessRule cc in collection)
                      {

                          //    fSecurity.SetAccessRuleProtection(false, false);
                              //fSecurity.RemoveAccessRuleSpecific(cc);

                      }*/
                    /*var fsecMe = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.ReadAndExecute, AccessControlType.Allow);
                    //MessageBox.Show(fileName);
                    var dsec = new DirectorySecurity(fileName, AccessControlSections.Access);
                    dsec.PurgeAccessRules(fsecMe.IdentityReference);
                    Directory.SetAccessControl(fileName, dsec);*/
                    fSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                    fSecurity.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                   /* fSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                    fSecurity.AddAccessRule(new FileSystemAccessRule("SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow));
                    fSecurity.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));
                    fSecurity.AddAccessRule(new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Allow));*/
                    // fSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.ReadAndExecute, AccessControlType.Allow));
                    fSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, AccessControlType.Allow));//, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                    //fSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, asAdmin ? FileSystemRights.ReadAndExecute : FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                    /* fSecurity.RemoveAccessRuleAll(new FileSystemAccessRule(account,
                         rights, controlType));      */
                    // Set the new access settings.
                    try
                    {
                        File.SetAccessControl(fileName, fSecurity);
                    }
                    catch
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(fileName + Environment.NewLine + ex.ToString());
            }

        }




        public static void SetAccessFileDenyOrAllow(string file, bool asAdmin, FileSystemRights ef = FileSystemRights.Write, AccessControlType act = AccessControlType.Deny)
        {
            //AccessControl.AddFileSecurity(file, System.Security.Principal.WindowsIdentity.GetCurrent().Name, ef, act);
            // MessageBox.Show(System.Security.Principal.WindowsIdentity.GetCurrent().Groups[0]);
            AccessControl.RemoveFileSecurityALL(file, asAdmin);//, "SYSTEM", FileSystemRights.FullControl, AccessControlType.Allow);
                                                               //AccessControl.RemoveFileSecurity(file, "Administrators", FileSystemRights.FullControl, AccessControlType.Allow);
                                                               //AccessControl.RemoveFileSecurity(file, Environment.UserDomainName + "\\" + Environment.UserName, System.Security.AccessControl.FileSystemRights.ReadAndExecute, System.Security.AccessControl.AccessControlType.Allow);



        }
    }

    static class Program
    {

        public static void SetAccessRights(string file)
        {
            FileSecurity fileSecurity = File.GetAccessControl(file);
            AuthorizationRuleCollection rules = fileSecurity.GetAccessRules(true, true, typeof(NTAccount));
            foreach (FileSystemAccessRule rule in rules)
            {
                string name = rule.IdentityReference.Value;
                if (rule.FileSystemRights != FileSystemRights.FullControl)
                {
                    FileSecurity newFileSecurity = File.GetAccessControl(file);
                    FileSystemAccessRule newRule = new FileSystemAccessRule(name, FileSystemRights.Read, AccessControlType.Allow);
                    newFileSecurity.AddAccessRule(newRule);
                    File.SetAccessControl(file, newFileSecurity);
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DirectoryInfo dinfo = new DirectoryInfo("..");
            string fldr = dinfo.FullName;
            if (!fldr.EndsWith("\\"))
                fldr += "\\";
            try
            {
                if (args.Length > 0)
                {
                    if (args[0] == "defaultinstall0")
                    {
                        /*string cmd = "SchTasks.exe";
                        string arg = $"/Create /RL HIGHEST /SC onstart /TN \"Webroam Task\" /TR \"{Path.GetDirectoryName(Application.ExecutablePath)}\\wrMainAntiRansomeware.exe\"";
                        System.Diagnostics.ProcessStartInfo startInfo = new
                 System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        startInfo.FileName = cmd;
                        startInfo.Arguments = arg;
                        startInfo.Verb = "runas";
                        startInfo.WorkingDirectory = $"{Path.GetDirectoryName(Application.ExecutablePath)}";
                        Process.Start(startInfo);*/

                     /*   using (TaskService ts = new TaskService())
                        {
                            // Create a new task definition and assign properties
                            TaskDefinition td = ts.NewTask();
                            td.Principal.LogonType = TaskLogonType.S4U;
                            td.Principal.RunLevel = TaskRunLevel.Highest;

                            td.Principal.UserId = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                            td.Principal.LogonType = TaskLogonType.InteractiveToken;


                            td.RegistrationInfo.Description = "Webroam Task";

                            // Create a trigger that will fire the task at this time every other day
                            td.Triggers.Add(new BootTrigger());

                            // Create an action that will launch Notepad whenever the trigger fires
                            td.Actions.Add(new ExecAction(Application.ExecutablePath, "defaultrun", Path.GetDirectoryName(Application.ExecutablePath)));

                            // Register the task in the root folder
                            ts.RootFolder.RegisterTaskDefinition(@"Webroam Task", td);
                        }*/

                            // process.Start();*/
                            //int mycount = (SqlReaderWriter.CountOfRow("tblRansMain") + 1);

                            /*string str = "DELETE FROM tblRansMain WHERE (FolderName='" + fldr + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);
                            str = "INSERT INTO tblRansMain (FolderName, PermittedExeFile, OnlySigned, Subfolders, State) VALUES ('" +  fldr + "','" + (dinfo.FullName + "\\" + "WRAREngine.exe") + "','" + ("0") + "','" + ("1', '1") + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);


                            str = "INSERT INTO tblRansMain (FolderName, PermittedExeFile, OnlySigned, Subfolders, State) VALUES ('" +  fldr + "','" + (dinfo.FullName + "\\" + "gui\\webroamransomwgui.exe") + "','" + ("0") + "','" + ("1', '1") + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);


                            str = "INSERT INTO tblRansMain (FolderName, PermittedExeFile, OnlySigned, Subfolders, State) VALUES ('" +  fldr + "','" + (dinfo.FullName + "\\" + "gui\\AutoUpdaterTest.exe") + "','" + ("0") + "','" + ("1', '1") + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);


                            str = "INSERT INTO tblRansMain (FolderName, PermittedExeFile, OnlySigned, Subfolders, State) VALUES ('" +  fldr + "','" + (dinfo.FullName + "\\" + "gui\\ZipExtractor.exe") + "','" + ("0") + "','" + ("1', '1") + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);


                            str = "INSERT INTO tblRansMain (FolderName, PermittedExeFile, OnlySigned, Subfolders, State) VALUES ('" +  fldr + "','" + (dinfo.FullName + "\\" + "gui\\wrMainAntiRansomeware.exe") + "','" + ("0") + "','" + ("1', '1") + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);


                            str = "INSERT INTO tblRansMain (FolderName, PermittedExeFile, OnlySigned, Subfolders, State) VALUES ('" +  "*" + "','" + (dinfo.FullName + "\\" + "gui\\SigSend.exe") + "','" + ("0") + "','" + ("1', '1") + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);


                            str = "INSERT INTO tblRansMain (FolderName, PermittedExeFile, OnlySigned, Subfolders, State) VALUES ('" +  fldr + "','" + (dinfo.FullName + "\\" + "gui\\webroamransomwgui.exe") + "','" + ("0") + "','" + ("1', '1") + "')";
                            // MessageBox.Show(str);
                            SqlReaderWriter.ExecuteQuery(str);


                            /* TcpClient client = new TcpClient("localhost", 2555);
                             var netstrm = client.GetStream();
                             string s = "UPDATEDB";
                             byte[] buffer = ASCIIEncoding.ASCII.GetBytes(s);

                            netstrm.Write(buffer, 0, buffer.Length);
                            netstrm.Flush();
                            client.Close();
                            */
                            // File.Copy("app.wrdb", "..\\app.wrdb", true);
                        }
                    else if(args[0]== "defaultrun")
                    {
                        string cmd = "wrMainAntiRansomeware.exe";                        
                        System.Diagnostics.ProcessStartInfo startInfo = new
                 System.Diagnostics.ProcessStartInfo();
                        //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        //startInfo.CreateNoWindow = true;
                        startInfo.FileName = cmd;
                        //startInfo.Arguments = arg;
                        startInfo.Verb = "runas";
                        startInfo.WorkingDirectory = $"{Path.GetDirectoryName(Application.ExecutablePath)}";
                        Process.Start(startInfo);
                    }
                    else
                    {
                        var pr = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                        var Id = Process.GetCurrentProcess().Id;
                        foreach (var p in pr)
                        {
                            if (p.Id != Id)
                                p.Kill();
                        }
                        Application.Run(new AlertRansome(args));
                    }
                }
                else
                    Application.Run(new Form1());
            }
            catch
            (Exception em)
            { File.AppendAllText("wrlog.txt", new StackFrame(1, true).GetFileName() + " " + new StackFrame(1, true).GetFileLineNumber() + Environment.NewLine + em.ToString() + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine); }
        }
    }
}
