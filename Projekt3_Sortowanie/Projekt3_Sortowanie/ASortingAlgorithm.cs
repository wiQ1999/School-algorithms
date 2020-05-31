using System;
using System.Diagnostics;

namespace Projekt3_Sortowanie
{
	abstract class ASortingAlgorithm : Table
	{
		public ASortingAlgorithm(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}
		
		public abstract void Sort(int[] a_oTab);

		public void MeasureSortTime(int a_iTabSize)
		{
			//obiekt stopera
			Stopwatch stopwatch = new Stopwatch();

			//Tworzenie nowej tablicy na podststawie tablicy bazowej
			int[] _oMeasureTab = Resize(a_iTabSize);

			//wyświetlenie tablicy zmienionej rozmiarem
			Console.WriteLine();
			Console.WriteLine($"Tablica {a_iTabSize}K");
			DisplayTab(_oMeasureTab);

			//pomiar czasu
			stopwatch.Start();

			//wywołanie funkncji
			Sort(_oMeasureTab);

			//pomiar czasu
			stopwatch.Stop();

			//wyświetlenie tablicy posortowanej
			Console.WriteLine();
			Console.WriteLine("Tablica posortowana");
			DisplayTab(_oMeasureTab);

			//wyświetlanie czasu
			Console.WriteLine();
			Console.WriteLine($"Czas sortowania: {stopwatch.ElapsedMilliseconds}.");
		}
	}
}
