using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Projekt3_Sortowanie
{
	abstract class ASortingAlgorithm : Table
	{
		public ASortingAlgorithm(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}
		
		public abstract void Sort(int[] a_oTab);

		private long CountAverage(List<long> a_oTimesList)
		{
			//usunięcie pierwszego wyniku
			a_oTimesList.RemoveAt(0);

			//zmienna przechowująca sumę czasów
			long _lTimesSum = 0;

			//pętla sumująca
			foreach (long time in a_oTimesList)
			{
				_lTimesSum += time;
			}

			//zwrócenie wartości sumy pozostałych czasów przez ich ilośc - średnia
			return _lTimesSum / a_oTimesList.Count;
		}

		public void MeasureSortTime(int a_iTabSize, int a_iMeasurementNumber = 10, bool a_bDisplayInformation = false)
		{
			//obiekt stopera
			Stopwatch stopwatch = new Stopwatch();

			//lista przechowująca pomiary czasów
			List<long> _oTimesList = new List<long>();

			//pętla 10 pomiarów czasowych dla jednego sortowania
			for (int i = 0; i < a_iMeasurementNumber; i++)
			{
				//Tworzenie nowej tablicy na podststawie tablicy bazowej
				int[] _oMeasureTab = Resize(a_iTabSize);

				//wyświetlenie tablicy zmienionej rozmiarem
				if (a_bDisplayInformation)
				{
					Console.WriteLine();
					Console.WriteLine($"Tablica {a_iTabSize}K");
					DisplayTab(_oMeasureTab);
				}

				//pomiar czasu
				stopwatch.Restart();

				//wywołanie funkncji
				Sort(_oMeasureTab);

				//pomiar czasu
				stopwatch.Stop();

				//dodanie wyniku do listy
				_oTimesList.Add(stopwatch.ElapsedMilliseconds);

				//wyświetlenie tablicy posortowanej oraz informacji
				if (a_bDisplayInformation)
				{
					Console.WriteLine();
					Console.WriteLine("Tablica posortowana");
					DisplayTab(_oMeasureTab);
				}
			}

			//obliczenie średniego czasu sortowania
			long _iAverageTime;
			if (a_iMeasurementNumber > 2)
				_iAverageTime = CountAverage(_oTimesList);
			else
				_iAverageTime = _oTimesList[0];

			//wyświetlanie krótkiej informacji
			if (a_bDisplayInformation)
			{
				Console.WriteLine();
				Console.Write("Czas sortowania: ");
			}

			//wyświetlenie wyniku
			Console.WriteLine(_iAverageTime);
		}
	}
}
