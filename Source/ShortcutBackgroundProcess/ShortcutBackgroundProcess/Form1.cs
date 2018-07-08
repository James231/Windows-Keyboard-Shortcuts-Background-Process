using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ShortcutBackgroundProcess
{
    public partial class Form1 : Form
    {
        // Methods for creating hotkeys
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // The list of application paths in the order the hotkeys are registered
        List<string> appPath;

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        /// <summary>
        /// Constructor to setup the hotkeys
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            RegisterHotKeys();
        }

        /// <summary>
        /// Method to hide the application (and hide it from the taskbar) once it has been loaded. Added as a delegate by the InitializeComponent method in Form1.Designer.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Registers the Hotkeys by looking at the file
        /// </summary>
        public void RegisterHotKeys ()
        {
            appPath = new List<string>();

            // Registe the quit hotkey
            RegisterHotKey(this.Handle, 0, (int)KeyModifier.Alt, Keys.Q.GetHashCode());

            // Read the lines of the shortcuts file
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Shortcuts.txt");
            string[] lines = reader.ReadToEnd().Split(new string[] { "\n" }, StringSplitOptions.None);
            reader.Close();
            
            foreach (string line in lines)
            {
                // Split the line up into words
                string[] words = line.Split(' ');
                if (words != null)
                {
                    // Check line has enough words
                    if (words.Length > 2)
                    {
                        if ((!string.IsNullOrEmpty(words[0])) && (words[1].Length == 1))
                        {
                            // Check Key from the second word in the line is valid
                            if (!"ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".Contains(words[1][0]))
                            {
                                continue;
                            }

                            // Check the modifier is valid
                            bool validModifier = false;
                            KeyModifier modifier = KeyModifier.None;
                            switch (words[0])
                            {
                                case "NONE":
                                    validModifier = true;
                                    break;
                                case "ALT":
                                    validModifier = true;
                                    modifier = KeyModifier.Alt;
                                    break;
                                case "CTRL":
                                    validModifier = true;
                                    modifier = KeyModifier.Control;
                                    break;
                                case "SHIFT":
                                    validModifier = true;
                                    modifier = KeyModifier.Shift;
                                    break;
                                case "WINKEY":
                                    validModifier = true;
                                    modifier = KeyModifier.WinKey;
                                    break;
                            }
                            if (!validModifier)
                            {
                                continue;
                            }

                            // Get the key from second word in line
                            Keys key = keyFromChar(words[1][0]);

                            // Get the path. Use line not words as it may contain spaces
                            int startOfPath = words[0].Length + 3;
                            string path = line.Substring(startOfPath);

                            // We check if the path is valid when the key is pressed as it is unnecessary here

                            //Register the Hotkey as long as it doesn't overwrite the quit hotkey
                            if ((modifier != KeyModifier.Alt) || (key != Keys.Q))
                            {
                                RegisterHotKey(this.Handle, appPath.Count + 1, (int)modifier, key.GetHashCode());
                                appPath.Add(path);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Returns the Key for the provided character
        /// </summary>
        /// <param name="keyChar">The character in the hotkey representing a key</param>
        /// <returns></returns>
        public Keys keyFromChar (char keyChar)
        {
            // There might be a shorter way of getting the key, but this still efficient
            Keys key = Keys.A;
            switch (keyChar) {
                case 'B':
                    key = Keys.B;
                    break;
                case 'C':
                    key = Keys.C;
                    break;
                case 'D':
                    key = Keys.D;
                    break;
                case 'E':
                    key = Keys.E;
                    break;
                case 'F':
                    key = Keys.F;
                    break;
                case 'G':
                    key = Keys.G;
                    break;
                case 'H':
                    key = Keys.H;
                    break;
                case 'I':
                    key = Keys.I;
                    break;
                case 'J':
                    key = Keys.J;
                    break;
                case 'K':
                    key = Keys.K;
                    break;
                case 'L':
                    key = Keys.L;
                    break;
                case 'M':
                    key = Keys.M;
                    break;
                case 'N':
                    key = Keys.N;
                    break;
                case 'O':
                    key = Keys.O;
                    break;
                case 'P':
                    key = Keys.P;
                    break;
                case 'Q':
                    key = Keys.Q;
                    break;
                case 'R':
                    key = Keys.R;
                    break;
                case 'S':
                    key = Keys.S;
                    break;
                case 'T':
                    key = Keys.T;
                    break;
                case 'U':
                    key = Keys.U;
                    break;
                case 'V':
                    key = Keys.V;
                    break;
                case 'W':
                    key = Keys.W;
                    break;
                case 'X':
                    key = Keys.X;
                    break;
                case 'Y':
                    key = Keys.Y;
                    break;
                case 'Z':
                    key = Keys.Z;
                    break;
                case '1':
                    key = Keys.D1;
                    break;
                case '2':
                    key = Keys.D2;
                    break;
                case '3':
                    key = Keys.D3;
                    break;
                case '4':
                    key = Keys.D4;
                    break;
                case '5':
                    key = Keys.D5;
                    break;
                case '6':
                    key = Keys.D6;
                    break;
                case '7':
                    key = Keys.D7;
                    break;
                case '8':
                    key = Keys.D8;
                    break;
                case '9':
                    key = Keys.D9;
                    break;
                case '0':
                    key = Keys.D0;
                    break;
            }
            return key;
        }

        /// <summary>
        /// Called when application is closing. Unregisters all hotkeys.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unregister quit hotkey
            UnregisterHotKey(this.Handle, 0);

            // Unregister user hotkeys
            for (int i = 0; i < appPath.Count; i++)
            {
                UnregisterHotKey(this.Handle, i + 1);
            }
        }

        /// <summary>
        /// Called when a hotkey could have been pressed
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Check if a hotkey is being pressed
            if (m.Msg == 0x0312)
            {
                // m.WParam.ToInt32() returns the hotkey id
                int id = m.WParam.ToInt32();

                // Check if it is the quit hotkey
                if (id == 0)
                {
                    Application.Exit();
                }

                // Check if the id is a valid user hotkey
                if ((id > 0) && (id <= appPath.Count))
                {
                    if (!string.IsNullOrEmpty(appPath[id-1]))
                    {
                        // Check if the application path is valid
                        if (File.Exists(appPath[id-1]))
                        {
                            // Start the application
                            Process proc = new Process();
                            proc.StartInfo.FileName = appPath[id-1];
                            // Use a try catch block to start the process as it can can give errors. This also stops two processes sharing the same hotkey
                            proc.Start();
                        } else
                        {
                            // We know the path isn't valid so make sure we don't check again next time the key is pressed
                            appPath[id-1] = "";
                        }
                    }
                }
            }
        }
    }
}
