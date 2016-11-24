using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSuite
{
    public class KeyInterceptor
    {
        private const int cache_size = 10;

        public Queue<ConsoleKeyInfo> Keys
        {
            get;
            set;
        }

        public event EventHandler<KeyPressedEventArgs> ArrowPressed;

        public virtual void OnArrowPressed(KeyPressedEventArgs e)
        {
            var temp = this.ArrowPressed;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        public KeyInterceptor()
        {
            this.Keys = new Queue<ConsoleKeyInfo>(cache_size);
        }

        public void InterceptKeys()
        {
            ConsoleKeyInfo key;
            var arr = new ConsoleKey[] { ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow };
            do
            {
                key = Console.ReadKey();
				if (arr.Contains(key.Key))
                {
                    OnArrowPressed(new KeyPressedEventArgs(key));
                }
            }
			while (key.Key != ConsoleKey.Escape);
			Console.Clear();
        }


    }
}

