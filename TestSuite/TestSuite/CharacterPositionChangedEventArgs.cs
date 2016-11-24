using System;
namespace TestSuite
{
	public class CharacterPositionChangedEventArgs : EventArgs
	{
		public bool IsXChanged
		{
			get;
			private set;
		}

		public int OffsetValue
		{
			get;
			private set;
		}
		
		public CharacterPositionChangedEventArgs(bool isXChanged, int offsetValue)
		{
			this.IsXChanged = isXChanged;
			this.OffsetValue = offsetValue;
		}
	}
}
