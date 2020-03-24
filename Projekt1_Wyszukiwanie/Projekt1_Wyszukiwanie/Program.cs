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
		static void DisplayMatrix(uint[] a_oMatrix)
		{
			for (uint i = 0; i < a_oMatrix.Length; i++)
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
		static uint[] CreateMatrix(uint a_uLength, uint a_uMaxValue, uint a_uLastNumber)
		{
			uint[] _oMatrix = new uint[a_uLength];

			Random rnd = new Random();

			for (uint i = 0; i < a_uLength; i++)
			{
				if(i == a_uLength - 1)
				{
					_oMatrix[i] = a_uLastNumber;
					break;
				}

				_oMatrix[i] = (uint)rnd.Next(0, (int)(a_uMaxValue + 1));
			}

			return _oMatrix;
		}

		/// <summary>
		/// Generates an array with specific length
		/// </summary>
		/// <param name="a_uLength">Length of array</param>
		/// <param name="a_uMaxValue">Maximum value randomly generate in array</param>
		/// <returns>A generated array</returns>
		static uint[] CreateMatrix(uint a_uLength, uint a_uMaxValue)
		{
			uint[] _oMatrix = new uint[a_uLength];

			Random rnd = new Random();

			for (uint i = 0; i < a_uLength; i++)
			{
				_oMatrix[i] = (uint)rnd.Next(0, (int)(a_uMaxValue + 1));
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
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, 99, 100);//Wraz ze sztywno określoną ostatnią wartośćia w tablicy

				//Sprawdzenie wartości peirwszego elementu w tablicy
				uint _uFirstNumber = _oMatrix[0];

				//Zmienna przechowująca ilosć punktów krytycznych
				long _lCriticalPoints = 0;

				//Zmienna przechowująca sumę punktów pomiaroywch między przypadkiem optymistycznym a pesymistycznym
				long _lCriticalPointsSum = 0;

				//szukanie przypadku pesymistycznego oraz optymistycznego
				for (int y = 0; y < 2; y++)
				{
					//Sprawdzenie szukanego elementu
					if (y == 0)
					{
						//Szukanie pierwszego elementu
						binarne.BinSearchInst(_oMatrix, _uFirstNumber, out _lCriticalPoints);
					}
					else
					{
						//Szukanie ostatniego elementu
						binarne.BinSearchInst(_oMatrix, 100, out _lCriticalPoints);
					}

					//Sumowanie punktów krytycznych
					_lCriticalPointsSum += _lCriticalPoints;
				}

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPointsSum / 2}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
			}
		}

		static void Bin_Pes_Instr()
		{
			//Opis
			Console.WriteLine("Wyszukiwanie_Binarne_Pesymistyczne_Instrumentacja");

			//Wyświetlenie kolumn
			Console.WriteLine("Matrix_Size\tSearch_Time\tLoops_Number");

			//Deklaracja wyszukiwania binarnego
			Binarne binarne = new Binarne();

			//Testowo licznik pętli
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, (uint)(int.MaxValue) - 1);

				//Sortowanie tablicy od najmniejszych wartości do najwiekszych
				Array.Sort(_oMatrix);

				//Zmienna przechowująca ilosć punktów krytycznych
				long _lCriticalPoints = 0;

				//Szukanie elementu o wartości uint.max
				uint _uResult = binarne.BinSearchInst(_oMatrix, (uint)(int.MaxValue), out _lCriticalPoints);

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPoints}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
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
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, 99, 100);//Wraz ze sztywno określoną ostatnią wartośćia w tablicy

				//Sprawdzenie wartości peirwszego elementu w tablicy
				uint _uFirstNumber = _oMatrix[0];

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Zmienna przechowująca sumę czasów między przypadkiem optymistycznym a pesymistycznym
				long _lTimeSum = 0;

				//Uśrednienie wyniku
				for (int x = 0; x < 7; x++)//7 prób
				{
					//szukanie przypadku pesymistycznego oraz optymistycznego
					for (int y = 0; y < 2; y++)
					{
						//Rozpoczecie pomiaru czasu
						Time.Start();

						//Sprawdzenie szukanego elementu
						if (y == 0)
						{
							//Szukanie pierwszego elementu
							binarne.BinSearchTime(_oMatrix, _uFirstNumber);
						}
						else
						{
							//Szukanie ostatniego elementu
							binarne.BinSearchTime(_oMatrix, 100);
						}

						//Sumowanie czasów
						_lTimeSum += Time.ElapsedMilliseconds;

						//Resetowanie stopera
						Time.Reset();
					}

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
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
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
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, (uint)(int.MaxValue) - 1);

				//Sortowanie tablicy od najmniejszych wartości do najwiekszych
				Array.Sort(_oMatrix);

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Uśrednienie wyniku
				for (int x = 0; x < 7; x++)//7 prób
				{
					//Rozpoczecie pomiaru czasu
					Time.Start();

					//Szukanie elementu o wartości uint.max
					uint _uResult = binarne.BinSearchTime(_oMatrix, (uint)(int.MaxValue));

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
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
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
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, 99, 100);//Wraz ze sztywno określoną ostatnią wartośćia w tablicy

				//Sprawdzenie wartości peirwszego elementu w tablicy
				uint _uFirstNumber = _oMatrix[0];

				//Zmienna przechowująca ilosć punktów krytycznych
				long _lCriticalPoints = 0;

				//Zmienna przechowująca sumę punktów pomiaroywch między przypadkiem optymistycznym a pesymistycznym
				long _lCriticalPointsSum = 0;

				//szukanie przypadku pesymistycznego oraz optymistycznego
				for (int y = 0; y < 2; y++)
				{
					//Sprawdzenie szukanego elementu
					if (y == 0)
					{
						//Szukanie pierwszego elementu
						liniowe.LinSearchInst(_oMatrix, _uFirstNumber, out _lCriticalPoints);
					}
					else
					{
						//Szukanie ostatniego elementu
						liniowe.LinSearchInst(_oMatrix, 100, out _lCriticalPoints);
					}

					//Sumowanie punktów krytycznych
					_lCriticalPointsSum += _lCriticalPoints;
				}

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPointsSum / 2}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
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
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, 99);

				//Zmienna przechowująca ilosć punktów krytycznych
				long _lCriticalPoints = 0;

				//Szukanie elementu o wartości 100
				liniowe.LinSearchInst(_oMatrix, 100, out _lCriticalPoints);

				//Wyświetlenie statystyk
				Console.WriteLine($"{i * 1000000}\t\t{_lCriticalPoints}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
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
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, 99, 100);//Wraz ze sztywno określoną ostatnią wartośćia w tablicy

				//Sprawdzenie wartości peirwszego elementu w tablicy
				uint _uFirstNumber = _oMatrix[0];

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Zmienna przechowująca sumę czasów między przypadkiem optymistycznym a pesymistycznym
				long _lTimeSum = 0;

				//Uśrednienie wyniku
				for (int x = 0; x < 7; x++)//7 prób
				{
					//szukanie przypadku pesymistycznego oraz optymistycznego
					for (int y = 0; y < 2; y++)
					{
						//Rozpoczecie pomiaru czasu
						Time.Start();

						//Sprawdzenie szukanego elementu
						if (y == 0)
						{
							//Szukanie pierwszego elementu
							liniowe.LinSearchTime(_oMatrix, _uFirstNumber);
						}
						else
						{
							//Szukanie ostatniego elementu
							liniowe.LinSearchTime(_oMatrix, 100);
						}

						//Sumowanie czasów
						_lTimeSum += Time.ElapsedMilliseconds;

						//Resetowanie stopera
						Time.Reset();
					}

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
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
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
			int _iCouter = 1;

			//Pętla po punktach pomiarowych
			for (uint i = 2; i <= 280; i += 4)//70 punktów pomiarowych
			{
				//Tworzenie tablic o podanej wielkości
				uint[] _oMatrix = CreateMatrix(i * 1000000, 99);

				//Tworzenie listy wyników czasowych
				List<long> _oTimesList = new List<long>();

				//Uśrednienie wyniku
				for (int x = 0; x < 7; x++)//7 prób
				{
					//Rozpoczecie pomiaru czasu
					Time.Start();

					//Szukanie elementu o wartości 100
					liniowe.LinSearchTime(_oMatrix, 100);

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
				Console.WriteLine($"{i * 1000000}\t\t{_lAverage}\t\t{_iCouter++}");//Testowo licznik pętli - Couter
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
