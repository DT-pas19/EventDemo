using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace TestSuite
{
    class MainClass
    {
		static readonly Tuple<int, int> window_size = new Tuple<int, int>(80, 40);

		[DllImport("libc")]
		private static extern int system(string exec);

        public static void Main(string[] args)
        {
			Console.Clear();
			Console.SetWindowSize(window_size.Item1, window_size.Item2);
			system("resize -s 50 100 > /dev/null");
			KeyInterceptor k = new KeyInterceptor();
			Thread t = new Thread(() =>
			{
				Console.Title = "Перехват клавиш стартовал";
				k.InterceptKeys();
			});

			Character c = new Character(x: 5, y: 10, horizontal_limit: window_size.Item1, vertical_limit: window_size.Item2);
            k.ArrowPressed += c.ChangePosition;
			c.PositionChanged += (sender, e) =>
			{
				Console.Title = string.Format("Изменено положение ГГ: по оси {0} на {1} клетки", e.IsXChanged ? "X" : "Y", e.OffsetValue);
				int dx = e.IsXChanged ? e.OffsetValue : 0;
				int dy = e.IsXChanged ? 0 : e.OffsetValue;
				Console.SetCursorPosition(c.X - dx, c.Y - dy); // Очистка предыдущей позиции
				Console.Write("_");
				Console.SetCursorPosition(c.X, c.Y);			// Отрисовка ГГ
				Console.Write("Ж");
			};
			Console.WriteLine("Начали!");
			t.Start();
        }
    }
}