using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace renameDoc
{
    public partial class Form1 : Form
    {
        Timer pTimer = new Timer();
        List<string> pList = new List<string>();
        private static string configpath = Application.StartupPath + "\\config.ini";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        public static void WriteContentValue(string section, string key, string iValue)
        {
            WritePrivateProfileString(section, key, iValue, configpath);
        }

        public static string ReadContentValue(string Section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, configpath);
            return temp.ToString();
        }
     public static T ReadConfig<T>(string section, string key)
         {
             if (File.Exists(configpath))
             {
                string value = ReadContentValue(section, key);

                if (String.IsNullOrWhiteSpace(value))
                     return default(T);
 
                if (typeof(T).IsEnum)
                     return (T) Enum.Parse(typeof(T), value, true);
 
                 return (T) Convert.ChangeType(value, typeof(T));
             }
             else
             {
                 return default(T);
            }
        }

       public static void WriteConfig(string section, string key, string value)
        {
             //如果文件不存在，则创建
             if (!File.Exists(configpath))
             {
                 using (FileStream myFs = new FileStream(configpath, FileMode.Create)) { }
             }
             WriteContentValue(section, key, value);
         }

public static bool connectState(string path)
        {
            return connectState(path, "", "");
        }
        /// <summary>
        /// 连接远程共享文件夹
        /// </summary>
        /// <param name="path">远程共享文件夹的路径</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static bool connectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                //throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }

        public Form1()
        {
            InitializeComponent();

            this.button_end.Enabled = false;
            pTimer.Tick += new EventHandler(callback);
            pTimer.Enabled = false;

            this.textBox_docDir.Text = ReadConfig<string>("doc", "path");
            this.textBox_fresh.Text = ReadConfig<string>("doc", "time");
            this.textBox_rename.Text = ReadConfig<string>("doc", "name");
        }

        private void callback(object sender, EventArgs e)
        {
            this.richTextBox_docList.Clear();
            string strPath = this.textBox_docDir.Text;
            DirectoryInfo root = new DirectoryInfo(strPath);
            FileInfo[] files = root.GetFiles();
            this.richTextBox_docList.AppendText(Convert.ToString(files.Length));
            this.richTextBox_docList.AppendText("\n");
            for (int i = 0; i < files.Length; i++)
            {
                this.richTextBox_docList.AppendText(files.GetValue(i).ToString());
                this.richTextBox_docList.AppendText("\n");
            }

            for (int i = 0; i < files.Length; i++)
            {
                string tmpFileName = files.GetValue(i).ToString();
                bool isHave = false;
                for(int j = 0; j < pList.Count; j++)
                {
                    if(pList[j].Contains(tmpFileName))
                    {
                        isHave = true;
                        break;
                    }
                }
                if(isHave)
                {
                    continue;
                }
                string tmpNewFileName = files.GetValue(i).ToString();
                string tmpStrSelect = this.textBox_select.Text;
                if(tmpStrSelect != "")
                {
                    if (tmpNewFileName.Contains(tmpStrSelect) && !tmpNewFileName.Contains("【") && !tmpNewFileName.Contains("】"))
                    {
                        pList.Add(tmpNewFileName);
                        string oldpath = this.textBox_docDir.Text + @"\" + tmpNewFileName;
                        string newpath = this.textBox_docDir.Text + @"\" + tmpNewFileName.Insert(2, this.textBox_rename.Text);
                        Console.WriteLine(oldpath);
                        Console.WriteLine(newpath);
                        FileInfo fileInfo = new FileInfo(oldpath);
                        fileInfo.MoveTo(newpath);
                        this.richTextBox_rename.AppendText(tmpNewFileName.Insert(2, this.textBox_rename.Text));
                        pList.Add(tmpNewFileName.Insert(2, this.textBox_rename.Text));
                        this.richTextBox_rename.AppendText("\n");
                        break;
                    }
                }else
                {
                    if (!tmpNewFileName.Contains("【") && !tmpNewFileName.Contains("】"))
                    {
                        pList.Add(tmpNewFileName);
                        string oldpath = this.textBox_docDir.Text + @"\" + tmpNewFileName;
                        string newpath = this.textBox_docDir.Text + @"\" + tmpNewFileName.Insert(2, this.textBox_rename.Text);
                        Console.WriteLine(oldpath);
                        Console.WriteLine(newpath);
                        FileInfo fileInfo = new FileInfo(oldpath);
                        fileInfo.MoveTo(newpath);
                        this.richTextBox_rename.AppendText(tmpNewFileName.Insert(2, this.textBox_rename.Text));
                        pList.Add(tmpNewFileName.Insert(2, this.textBox_rename.Text));
                        this.richTextBox_rename.AppendText("\n");
                        break;
                    }
                }
            }

            for(int i = 0; i < files.Length; i++)
            {
                string tmpFileName = files.GetValue(i).ToString();
                bool isHave = false;
                for (int j = 0; j < pList.Count; j++)
                {
                    if (pList[j].Contains(tmpFileName))
                    {
                        isHave = true;
                        break;
                    }
                }
                if (isHave)
                {
                    continue;
                }else
                {
                    pList.Add(tmpFileName);
                }
            }

        }

        private void button_select_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            string strPath = path.SelectedPath;
            this.textBox_docDir.Text = strPath;
            if(strPath == "")
            {
                return;
            }

            bool bresult = connectState(strPath);

            DirectoryInfo root = new DirectoryInfo(strPath);
            FileInfo[] files = root.GetFiles();
            for(int i = 0; i < files.Length; i++)
            {
                this.richTextBox_docList.AppendText(files.GetValue(i).ToString());
                this.richTextBox_docList.AppendText("\n");
            }
        }

        private void button_begin_Click(object sender, EventArgs e)
        {
            if(this.textBox_fresh.Text == "")
            {
                MessageBox.Show("刷新频率不能为空", "警告");
                return;
            }
            if(this.textBox_rename.Text == "")
            {
                MessageBox.Show("重命名字符不能为空", "警告");
                return;
            }

            WriteConfig("doc", "path", this.textBox_docDir.Text);
            WriteConfig("doc", "time", this.textBox_fresh.Text);
            WriteConfig("doc", "name", this.textBox_rename.Text);

            pList.Clear();

            string strPath = this.textBox_docDir.Text;
            DirectoryInfo root = new DirectoryInfo(strPath);
            FileInfo[] files = root.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                pList.Add(files.GetValue(i).ToString());
            }

            this.button_begin.Enabled = false;
            this.button_end.Enabled = true;

            pTimer.Enabled = true;
            pTimer.Interval = Convert.ToInt32(this.textBox_fresh.Text) * 1000;
            pTimer.Start();
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            this.button_begin.Enabled = true;
            this.button_end.Enabled = false;
            pTimer.Enabled = false;
            pTimer.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
