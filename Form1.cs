using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuHotkeys
{
    public partial class Form1 : Form
    {
        private int clickCount;
        private readonly KeyboardHook hook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            hook.RegisterHotKey(Keys.MediaPlayPause);
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            clickCount++;
            // show the keys pressed in a label.
            label1.Text = e.Modifier.ToString() + " + " + e.Key.ToString() + " click " + clickCount;
            SendKeys.Send("^+{M}");
        }
    }
}
