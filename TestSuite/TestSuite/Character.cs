using System;

namespace TestSuite
{
    public class Character
    {
        private int x,y;
		private int horizontal_limit, vertical_limit;
		public event EventHandler<CharacterPositionChangedEventArgs> PositionChanged;

		public void OnPositionChanged(CharacterPositionChangedEventArgs e)
		{
			var temp = this.PositionChanged;
			if (temp != null)
			{
				temp(this, e);
			}
		}

		public int X
        {
            get
            {
                return x;
            }
            set
            {
				int limit = this.horizontal_limit;
                if (value > 0 && value < limit)
                {
					int offset = this.x - value;
                    this.x = value;
					var e = new CharacterPositionChangedEventArgs(true, offset);
					this.OnPositionChanged(e);
                }
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
				if (value > 0 && value < this.vertical_limit)
                {
					int offset = this.y - value;
					this.y = value;
					var e = new CharacterPositionChangedEventArgs(false, offset);
					this.OnPositionChanged(e);
                }
            }
        }

		public void ChangePosition(object sender, EventArgs e)
		{
			var ek = e as KeyPressedEventArgs;
			int dx = 0, dy = 0;
			switch (ek.Key.Key)
			{
				case ConsoleKey.LeftArrow:
					dx = -1;
					break;
				case ConsoleKey.RightArrow:
					dx = 1;
					break;
				case ConsoleKey.UpArrow:
					dy = -1;
					break;
				case ConsoleKey.DownArrow:
					dy = 1;
					break;
			}
			this.X += dx;
			this.Y += dy;
        }

        public Character(int x, int y, int horizontal_limit = 0, int vertical_limit = 0)
        {
            this.X = x;
            this.Y = y;
			this.horizontal_limit = horizontal_limit;
			this.vertical_limit = vertical_limit;
        }
    }
}

