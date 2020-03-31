using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Projekt1_Wyszukiwanie
{
	class Program
	{
		#region Methods

		/// <summary>
		/// Display an array on the console
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		static void DisplayMatrix(int[] a_oMatrix)
		{
			for (int i = 0; i < a_oMatrix.Length; i++)
			{
				Console.Write(i.ToString());
			}
		}

		/// <summary>
		/// Generates an array with specific length
		/// </summary>
		/// <param name="a_uLength">Length of array</param>
		/// <param name="a_uMaxValue">Maximum value randomly generate in array</param>
		/// <param name="a_uLastNumber">Value on the last place in array</param>
		/// <returns>A generated array</returns>
		static int[] CreateMatrix(int a_uLength, int a_uMaxValue, int a_uLastNumber)
		{
			int[] _oMatrix = new int[a_uLength];

			Random rnd = new Random();

			for (int i = 0; i < a_uLength; i++)
			{
				if(i == a_uLength - 1)
				{
					_oMatrix[i] = a_uLastNumber;
					break;
				}

				_oMatrix[i] = rnd.Next(0, a_uMaxValue + 1);
			}

			return _oMatrix;
		}

		/// <summary>
		/// Generates an array with specific length
		/// </summary>
		/// <param name="a_uLength">Length of array</param>
		/// <param name="a_uMaxValue">Maximum value randomly generate in array</param>
		/// <returns>A generated array</returns>
		static int[] CreateMatrix(int a_uLength, int a_uMaxValue)
		{
			int[] _oMatrix = new int[a_uLength];

			Random rnd = new Random();

			for (uint i = 0; i < a_uLength; i++)
			{
				_oMatrix[i] = rnd.Next(0, a_uMaxValue + 1);
			}

			return _oMatrix;
		}

		static void Bin_Ave_Instr()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Binarne_Średnie_Instrumentacja");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tCritical_Points\tLoops_Number");

			//Deklaracja wyszukiwania binarnego
			Binarne binarne = new Binarne();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Sortowanie tablicy od najmniejszych wartości do najwiekszych
				Array.Sort(_oMatrix);

				//Zmienna przechowująca sumę punktów pomiaroywch
				long _lCriticalPointsSum = 0;

				//Licznik pętli średniej binarnej
				uint _uAverageLoops = 0;

				//Pętla średniej binarnej
				for (int j = 0; j < _oMatrix.Length / 2; j += 10000)//(długość tablicy / 2) / 10 000 prób
				{
					//Losowa liczba do szukania
					int _iRandomNumber = _oMatrix[j];

					//Szukanie elementu binarnie
					binarne.BinSearchInst(_oMatrix, _iRandomNumber, out long _lCriticalPoints);//Zmienna przechowująca ilosć punktów krytycznych

					//Sumowanie punktów krytycznych
					_lCriticalPointsSum += _lCriticalPoints;

					//Inkrementacja licznika pętli
					_uAverageLoops++;
				}

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPointsSum / _uAverageLoops}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		static void Bin_Pes_Instr()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Binarne_Pesymistyczne_Instrumentacja");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tCritical_Points\tLoops_Number");

			//Deklaracja wyszukiwania binarnego
			Binarne binarne = new Binarne();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Sortowanie tablicy od najmniejszych wartości do najwiekszych
				Array.Sort(_oMatrix);

				//Szukanie elementu binarnie
				binarne.BinSearchInst(_oMatrix, int.MaxValue, out long _lCriticalPoints);//Zmienna przechowująca ilosć punktów krytycznych

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPoints}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		static void Bin_Ave_Time()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Binarne_Średnie_PomiarCzasu");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tSearch_Time\tLoops_Number");

			//Deklaracja stopera
			Stopwatch Time = new Stopwatch();

			//Deklaracja wyszukiwania binarnego
			Binarne binarne = new Binarne();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Sortowanie tablicy od najmniejszych wartości do najwiekszych
				Array.Sort(_oMatrix);

				//Tworzenie listy wyników czasowych średniej
				List<long> _oTimesListAverage = new List<long>();

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Licznik pętli średniej binarnej
				uint _uAverageLoops = 0;

				//Pętla średniej binarnej
				for (int j = 0; j < _oMatrix.Length / 2; j += 10000)//(długość tablicy / 2) / 10 000 prób
				{
					//Losowa liczba do szukania
					int _iRandomNumber = _oMatrix[j];

					//Uśrednienie wyniku czasowego
					for (int x = 0; x < 10; x++)//10 prób
					{
						//Rozpoczecie pomiaru czasu
						Time.Start();

						//Szukanie losowego elementu binarnie
						binarne.BinSearchTime(_oMatrix, _iRandomNumber);

						//Pomiar czasu
						Time.Stop();

						//Dodanie wyniku do listy wyników czasowych
						_oTimesList.Add(Time.ElapsedMilliseconds);

						//Resetowanie stopera
						Time.Reset();
					}

					//Sortowanie listy wyników czasowych
					_oTimesList.Sort();

					//Usunięcie skrajnych wartości
					_oTimesList.RemoveAt(0);
					_oTimesList.RemoveAt(_oTimesList.Count - 1);

					//Dodanie wyników do listy śreniej wyników czasowych
					foreach (long time in _oTimesList)
					{
						_oTimesListAverage.Add(time);
					}

					//Inkrementacja licznika pętli
					_uAverageLoops++;
				}

				//Deklaracja zmiennej uśredniajacej wynik
				long _lAverage = 0;

				//Sumowanie wyników
				foreach (long point in _oTimesListAverage)
				{
					_lAverage += point;
				}

				//Uśrednienie wyniku
				_lAverage /= _oTimesListAverage.Count;

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		static void Bin_Pes_Time()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Binarne_Pesymistyczne_PomiarCzasu");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tSearch_Time\tLoops_Number");

			//Deklaracja stopera
			Stopwatch Time = new Stopwatch();

			//Deklaracja wyszukiwania binarnego
			Binarne binarne = new Binarne();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Sortowanie tablicy od najmniejszych wartości do najwiekszych
				Array.Sort(_oMatrix);

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Uśrednienie wyniku
				for (int x = 0; x < 10; x++)//10 prób
				{
					//Rozpoczecie pomiaru czasu
					Time.Start();

					//Szukanie elementu binarnie
					binarne.BinSearchTime(_oMatrix, int.MaxValue);

					//Pomiar czasu
					Time.Stop();

					//Dodanie wyniku do listy wyników czasowych
					_oTimesList.Add(Time.ElapsedMilliseconds);

					//Resetowanie stopera
					Time.Reset();
				}

				//Sortowanie tablicy wyników czasowych
				_oTimesList.Sort();

				//Usunięcie skrajnych wartości
				_oTimesList.RemoveAt(0);
				_oTimesList.RemoveAt(_oTimesList.Count - 1);

				//Deklaracja zmiennej uśredniajacej wynik
				long _lAverage = 0;

				//Sumowanie wyników
				foreach (long point in _oTimesList)
				{
					_lAverage += point;
				}

				//Uśrednienie wyniku
				_lAverage /= _oTimesList.Count;

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		static void Lin_Ave_Instr()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Liniowe_Średnie_Instrumentacja");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tCritical_Points\tLoops_Number");

			//Deklaracja wyszukiwania liniowego
			Liniowe liniowe = new Liniowe();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Sprawdzenie wartości peirwszego elementu w tablicy
				int _iFirstNumber = _oMatrix[0];

				//Zmienna przechowująca sumę punktów pomiaroywch między przypadkiem optymistycznym a pesymistycznym
				long _lCriticalPointsSum = 0;

				//Szukanie pierwszego elementu liniowo
				liniowe.LinSearchInst(_oMatrix, _iFirstNumber, out long _lCriticalPoints);//Zmienna przechowująca ilosć punktów krytycznych

				//Sumowanie punktów krytycznych
				_lCriticalPointsSum += _lCriticalPoints;

				//Szukanie ostatniego elementu liniowo
				liniowe.LinSearchInst(_oMatrix, int.MaxValue, out _lCriticalPoints);

				//Sumowanie punktów krytycznych
				_lCriticalPointsSum += _lCriticalPoints;

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPointsSum / 2}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		static void Lin_Pes_Instr()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Liniowe_Pesymistyczne_Instrumentacja");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tCritical_Points\tLoops_Number");

			//Deklaracja wyszukiwania liniowego
			Liniowe liniowe = new Liniowe();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Szukanie elementu liniowo
				liniowe.LinSearchInst(_oMatrix, int.MaxValue, out long _lCriticalPoints);//Zmienna przechowująca ilosć punktów krytycznych

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPoints}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		static void Lin_Ave_Time()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Liniowe_Średnie_PomiarCzasu");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tSearch_Time\tLoops_Number");

			//Deklaracja stopera
			Stopwatch Time = new Stopwatch();

			//Deklaracja wyszukiwania liniowego
			Liniowe liniowe = new Liniowe();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Sprawdzenie wartości peirwszego elementu w tablicy
				int _iFirstNumber = _oMatrix[0];

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Uśrednienie wyniku
				for (int x = 0; x < 10; x++)//10 prób
				{
					//Zmienna przechowująca sumę czasów między przypadkiem optymistycznym a pesymistycznym
					long _lTimeSum = 0;

					//Rozpoczecie pomiaru czasu
					Time.Start();

					//Szukanie pierwszego elementu liniowo
					liniowe.LinSearchTime(_oMatrix, _iFirstNumber);

					//Pomiar czasu
					Time.Stop();

					//Sumowanie czasów
					_lTimeSum += Time.ElapsedMilliseconds;

					//Resetowanie stopera
					Time.Restart();

					//Szukanie ostatniego elementu liniowo
					liniowe.LinSearchTime(_oMatrix, int.MaxValue);

					//Pomiar czasu
					Time.Stop();

					//Sumowanie czasów
					_lTimeSum += Time.ElapsedMilliseconds;

					//Resetowanie stopera
					Time.Reset();

					//Dodanie Uśrednionej sumy czasu do listy wyników czasowych
					_oTimesList.Add(_lTimeSum / 2);
				}

				//Sortowanie tablicy wyników czasowych
				_oTimesList.Sort();

				//Usunięcie skrajnych wartości
				_oTimesList.RemoveAt(0);
				_oTimesList.RemoveAt(_oTimesList.Count - 1);

				//Deklaracja zmiennej uśredniajacej wynik
				long _lAverage = 0;

				//Sumowanie wyników
				foreach (long point in _oTimesList)
				{
					_lAverage += point;
				}

				//Uśrednienie wyniku
				_lAverage /= _oTimesList.Count;

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		static void Lin_Pes_Time()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Liniowe_Pesymistyczne_PomiarCzasu");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tSearch_Time\tLoops_Number");

			//Deklaracja stopera
			Stopwatch Time = new Stopwatch();

			//Deklaracja wyszukiwania liniowego
			Liniowe liniowe = new Liniowe();

			//Testowo licznik pętli
			int _iCouter = 0;

			//Pętla po punktach pomiarowych
			for (int i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				int[] _oMatrix = CreateMatrix(i * 1000000, int.MaxValue - 1);

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Uśrednienie wyniku
				for (int x = 0; x < 10; x++)//10 prób
				{
					//Rozpoczecie pomiaru czasu
					Time.Start();

					//Szukanie elementu liniowo
					liniowe.LinSearchTime(_oMatrix, int.MaxValue);

					//Pomiar czasu
					Time.Stop();

					//Dodanie wyniku do listy wyników czasowych
					_oTimesList.Add(Time.ElapsedMilliseconds);

					//Resetowanie stopera
					Time.Reset();
				}

				//Sortowanie tablicy wyników czasowych
				_oTimesList.Sort();

				//Usunięcie skrajnych wartości
				_oTimesList.RemoveAt(0);
				_oTimesList.RemoveAt(_oTimesList.Count - 1);

				//Deklaracja zmiennej uśredniajacej wynik
				long _lAverage = 0;

				//Sumowanie wyników
				foreach (long point in _oTimesList)
				{
					_lAverage += point;
				}

				//Uśrednienie wyniku
				_lAverage /= _oTimesList.Count;

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{++_iCouter}");//Testowo licznik pętli - Couter
			}
		}

		#endregion

		static void Main(string[] args)
		{
			#region Console_Setings

			Console.Title = "Algorytmy przeszukujące";

			#endregion
			
			
			Lin_Pes_Time();
			Lin_Ave_Time();
			Lin_Pes_Instr();
			Lin_Ave_Instr();
			
			Bin_Pes_Time();
			Bin_Ave_Time();
			Bin_Pes_Instr();
			Bin_Ave_Instr();
			

			Console.ReadKey();
		}
	}
}
