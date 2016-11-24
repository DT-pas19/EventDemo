using System;

namespace TestSuite
{
    public class KeyPressedEventArgs : EventArgs
    {
        public ConsoleKeyInfo Key
        {
            get;
            private set;
        }

        public KeyPressedEventArgs(ConsoleKeyInfo key)
        {
            this.Key = key;
        }
    }
}

