﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Projekt2_Liczby_Pierwsze
{
	class Program
	{
		/// <summary>
		/// List of prime numbers selected for this project
		/// </summary>
		public static List<BigInteger> PrimeNumbers = new List<BigInteger>() { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

		#region Methods

		static long CountAverage(List<long> a_oTimeList)
		{
			//Sortowanie listy
			a_oTimeList.Sort();

			//Usuwanie skrajnych wyników
			a_oTimeList.RemoveAt(0);
			a_oTimeList.RemoveAt(a_oTimeList.Count - 1);

			//Zmienna przechowująca sumę czasów
			long _lTimeSum = 0;

			//Pętla po wszystkich wynikach czasowych
			foreach (long time in a_oTimeList)
			{
				_lTimeSum += time;
			}

			return _lTimeSum / a_oTimeList.Count;
		}

		static void ShowPrimes(BigInteger a_iQuantity)
		{
			//Liczby naturalne
			BigInteger i = 2;

			//Pętla odpowiedizalna a wyświetlanie liczb pierwszych
			while (a_iQuantity >= 1)//Dopóki licznik liczb pierwszych nie zejdzie do 0
			{
				//Sprawdzenie pierwszości liczby
				if (IsPrimeEratostenes(i, out ulong cp))
				{
					//Wypisanie na konsoli
					Console.WriteLine($"{i}, {cp}");
					//Odjęcie od lciznika liczby pierwszej
					a_iQuantity--;
				}
				//Przejście do następnej liczby naturalnej
				i++;
			}
		}

		#endregion

		#region PrimeMethods

		static bool IsPrime(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4) return true;
			else
			{
				if (a_iNumber % 2 == 0) return false;
				else
				{
					for (BigInteger u = 3; u < a_iNumber / 2; u += 2)
					{
						if (a_iNumber % u == 0) return false;
					}
				}
			}

			return true;
		}

		static bool IsPrime(BigInteger a_iNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4) return true;
			else
			{
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (a_iNumber % 2 == 0) return false;
				else
				{
					for (BigInteger u = 3; u < a_iNumber / 2; u += 2)
					{
						_ulCriticalPoints++;//Dodanie punktu krytycznego
						if (a_iNumber % u == 0) return false;
					}
				}
			}

			return true;
		}

		static bool IsPrimePositive(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;
			else
			{
				if (a_iNumber < 4) return true;
				else
				{
					if (a_iNumber % 2 == 0) return false;
					else
					{
						for (BigInteger u = 3; u <= (BigInteger)Math.Sqrt((double)a_iNumber); u += 2)
						{
							if (a_iNumber % u == 0) return false;
						}
					}
				}
			}

			return true;
		}

		static bool IsPrimePositive(BigInteger a_iNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_iNumber < 2) return false;
			else
			{
				if (a_iNumber < 4) return true;
				else
				{
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					if (a_iNumber % 2 == 0) return false;
					else
					{
						for (BigInteger u = 3; u <= (BigInteger)Math.Sqrt((double)a_iNumber); u += 2)
						{
							_ulCriticalPoints++;//Dodanie punktu krytycznego
							if (a_iNumber % u == 0) return false;
						}
					}
				}
			}

			return true;
		}

		static bool IsPrimeDivisibilityForm(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4 || a_iNumber == 5 || a_iNumber == 7) return true;
			else
			{
				if (a_iNumber % 2 == 0) return false;
				if (a_iNumber % 3 == 0) return false;

				BigInteger prime = 0, k = 1;
				sbyte d = -1;

				while (prime * prime <= a_iNumber)
				{
					prime = 6 * k + d;
					if (a_iNumber % prime == 0) return false;

					if (d == 1)
					{
						d = -1;
						k++;
					}
					else d = 1;
				}
			}

			return true;
		}

		static bool IsPrimeDivisibilityForm(BigInteger a_iNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4 || a_iNumber == 5 || a_iNumber == 7) return true;
			else
			{
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (a_iNumber % 2 == 0) return false;
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (a_iNumber % 3 == 0) return false;

				BigInteger prime = 0, k = 1;
				sbyte d = -1;

				while (prime * prime <= a_iNumber)
				{
					prime = 6 * k + d;
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					if (a_iNumber % prime == 0) return false;

					if (d == 1)
					{
						d = -1;
						k++;
					}
					else d = 1;
				}
			}

			return true;
		}

		static bool IsPrimeDivisibility235(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4 || a_iNumber == 5) return true;
			else
			{
				BigInteger _iMod = a_iNumber % 10;

				if (_iMod % 2 == 0) return false;
				if (_iMod % 5 == 0) return false;

				BigInteger _iModSum = _iMod;
				BigInteger _iNuller = 100;
				int _iModOne;

				while (_iMod != a_iNumber)
				{
					_iMod = a_iNumber % _iNuller;
					_iModOne = (int)(_iMod / (_iNuller / 10));
					_iNuller *= 10;
					_iModSum += _iModOne;
				}

				if (_iModSum % 3 == 0) return false;

				for (BigInteger u = 3; u * u <= a_iNumber; u += 2)
				{
					if (a_iNumber % u == 0) return false;
				}

				return true;
			}
		}

		static bool IsPrimeDivisibility235(BigInteger a_iNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4 || a_iNumber == 5) return true;
			else
			{
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				BigInteger _iMod = a_iNumber % 10;

				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (_iMod % 2 == 0) return false;
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (_iMod % 5 == 0) return false;

				BigInteger _iModSum = _iMod;
				BigInteger _iNuller = 100;
				int _iModOne;

				while (_iMod != a_iNumber)
				{
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					_iMod = a_iNumber % _iNuller;
					_iModOne = (int)(_iMod / (_iNuller / 10));
					_iNuller *= 10;
					_iModSum += _iModOne;
				}

				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (_iModSum % 3 == 0) return false;

				for (BigInteger u = 3; u * u <= a_iNumber; u += 2)
				{
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					if (a_iNumber % u == 0) return false;
				}

				return true;
			}
		}

		static bool IsPrimeDivisibilityForm235(BigInteger a_iNumber)
		{
			if (a_iNumber < 10)
			{
				if (a_iNumber < 2) return false;
				if (a_iNumber < 4 || a_iNumber == 5 || a_iNumber == 7) return true;

				return false;
			}
			else
			{
				BigInteger _iMod = a_iNumber % 10;

				if (_iMod % 2 == 0) return false;
				if (_iMod % 5 == 0) return false;

				BigInteger _iModSum = _iMod;
				BigInteger _iNuller = 100;
				int _iModOne;

				while (_iMod != a_iNumber)
				{
					_iMod = a_iNumber % _iNuller;
					_iModOne = (int)(_iMod / (_iNuller / 10));
					_iNuller *= 10;
					_iModSum += _iModOne;
				}

				if (_iModSum % 3 == 0) return false;

				BigInteger prime = 0, k = 1;
				sbyte d = -1;

				while (prime * prime <= a_iNumber)
				{
					prime = 6 * k + d;
					if (a_iNumber % prime == 0) return false;

					if (d == 1)
					{
						d = -1;
						k++;
					}
					else d = 1;
				}
			}

			return true;
		}

		static bool IsPrimeDivisibilityForm235(BigInteger a_iNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_iNumber < 10)
			{
				if (a_iNumber < 2) return false;
				if (a_iNumber < 4 || a_iNumber == 5 || a_iNumber == 7) return true;

				return false;
			}
			else
			{
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				BigInteger _iMod = a_iNumber % 10;

				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (_iMod % 2 == 0) return false;
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (_iMod % 5 == 0) return false;

				BigInteger _iModSum = _iMod;
				BigInteger _iNuller = 100;
				int _iModOne;

				while (_iMod != a_iNumber)
				{
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					_iMod = a_iNumber % _iNuller;
					_iModOne = (int)(_iMod / (_iNuller / 10));
					_iNuller *= 10;
					_iModSum += _iModOne;
				}

				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (_iModSum % 3 == 0) return false;

				BigInteger prime = 0, k = 1;
				sbyte d = -1;

				while (prime * prime <= a_iNumber)
				{
					prime = 6 * k + d;
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					if (a_iNumber % prime == 0) return false;

					if (d == 1)
					{
						d = -1;
						k++;
					}
					else d = 1;
				}
			}

			return true;
		}

		static bool IsPrimeEratostenes(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;

			//deklaracja zmiennych
			int _iRangeSqrt = (int)(Math.Sqrt((double)a_iNumber));//pierwiastek z n
			int[] _oTab = new int[_iRangeSqrt - 1];//nowa tablica

			//inicjuj tablice
			for (int i = 2; i <= _iRangeSqrt; i++) _oTab[i - 2] = i;

			//algorytm - sito eratostenesa
			for (int i = 2; i <= _iRangeSqrt; i++)//pętla po liczbach a nie indeksach
			{
				if (_oTab[i - 2] != 0)//jeżeli wartość w tablicy nie jest zerem
				{
					if (a_iNumber % i == 0) return false;//podzielność
					int j = i + i;//zmienna pomocnicza wielokrotności liczbowej
					while (j <= _iRangeSqrt)//dopóki wielokrotnośc jest mniejsza lub równa pierwiastka z szukanej liczby
					{
						_oTab[j - 2] = 0;//wyzerowanie liczby, która jest wielokrotnością
						j += i;//dodanie wielkrotności
					}
				}
			}

			return true;//liczba jest pierwsza
		}

		static bool IsPrimeEratostenes(BigInteger a_iNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_iNumber < 2) return false;

			//deklaracja zmiennych
			int _iRangeSqrt = (int)(Math.Sqrt((double)a_iNumber));//pierwiastek z n
			int[] _oTab = new int[_iRangeSqrt - 1];//nowa tablica

			//inicjuj tablice
			for (int i = 2; i <= _iRangeSqrt; i++) _oTab[i - 2] = i;

			//algorytm - sito eratostenesa
			for (int i = 2; i <= _iRangeSqrt; i++)//pętla po liczbach a nie indeksach
			{
				if (_oTab[i - 2] != 0)//jeżeli wartość w tablicy nie jest zerem
				{
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					if (a_iNumber % i == 0) return false;//podzielność
					int j = i + i;//zmienna pomocnicza wielokrotności liczbowej
					while (j <= _iRangeSqrt)//dopóki wielokrotnośc jest mniejsza lub równa pierwiastka z szukanej liczby
					{
						_oTab[j - 2] = 0;//wyzerowanie liczby, która jest wielokrotnością
						j += i;//dodanie wielkrotności
					}
				}
			}

			return true;//liczba jest pierwsza
		}

		#endregion

		#region MainPrimeMethods

		static void PrimeNumbersTime()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersTime");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Lista przechowująca pomiary czasowe
				List<long> _oTimesList = new List<long>();

				//Petla uśredniająca wynik czasowy
				for (int x = 0; x < 10; x++)//10 pomiarów jednej liczby
				{
					//Zresetowanie stopera i rozpoczącie pomiaru
					stopwatch.Restart();

					//Metoda sprawdzająca liczbę pierwszą
					IsPrime(prime);

					//Pomiar czasu
					stopwatch.Stop();

					//Dodanie wyniku do listy czasów
					_oTimesList.Add(stopwatch.ElapsedTicks);
				}

				//Zmienna przechowująca średnią czasową dla jednej liczy pierwszej
				long _lTimeAverage = CountAverage(_oTimesList);//Funkcja oblcizająca średnią czasową

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_lTimeAverage}");
			}
		}

		static void PrimeNumbersInstrumentation()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersInstrumentation");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Metoda sprawdzająca liczbę pierwszą
				IsPrime(prime, out ulong _ulCriticalPoints);//Zmienna przechowująca ilość punktów krytycznych

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_ulCriticalPoints}");
			}
		}

		static void PrimeNumbersPositiveTime()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersPositiveTime");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Lista przechowująca pomiary czasowe
				List<long> _oTimesList = new List<long>();

				//Petla uśredniająca wynik czasowy
				for (int x = 0; x < 10; x++)//10 pomiarów jednej liczby
				{
					//Zresetowanie stopera i rozpoczącie pomiaru
					stopwatch.Restart();

					//Metoda sprawdzająca liczbę pierwszą
					IsPrimePositive(prime);

					//Pomiar czasu
					stopwatch.Stop();

					//Dodanie wyniku do listy czasów
					_oTimesList.Add(stopwatch.ElapsedTicks);
				}

				//Zmienna przechowująca średnią czasową dla jednej liczy pierwszej
				long _lTimeAverage = CountAverage(_oTimesList);//Funkcja oblcizająca średnią czasową

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_lTimeAverage}");
			}
		}

		static void PrimeNumbersPositiveInstrumentation()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersPositiveInstrumentation");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Metoda sprawdzająca liczbę pierwszą
				IsPrimePositive(prime, out ulong _ulCriticalPoints);//Zmienna przechowująca ilość punktów krytycznych

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_ulCriticalPoints}");
			}
		}

		static void PrimeNumbersDivisibilityFormTime()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersDivisibilityFormTime");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Lista przechowująca pomiary czasowe
				List<long> _oTimesList = new List<long>();

				//Petla uśredniająca wynik czasowy
				for (int x = 0; x < 10; x++)//10 pomiarów jednej liczby
				{
					//Zresetowanie stopera i rozpoczącie pomiaru
					stopwatch.Restart();

					//Metoda sprawdzająca liczbę pierwszą
					IsPrimeDivisibilityForm(prime);

					//Pomiar czasu
					stopwatch.Stop();

					//Dodanie wyniku do listy czasów
					_oTimesList.Add(stopwatch.ElapsedTicks);
				}

				//Zmienna przechowująca średnią czasową dla jednej liczy pierwszej
				long _lTimeAverage = CountAverage(_oTimesList);//Funkcja oblcizająca średnią czasową

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_lTimeAverage}");
			}
		}

		static void PrimeNumbersDivisibilityFormInstrumentation()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersDivisibilityFormInstrumentation");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Metoda sprawdzająca liczbę pierwszą
				IsPrimeDivisibilityForm(prime, out ulong _ulCriticalPoints);//Zmienna przechowująca ilość punktów krytycznych

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_ulCriticalPoints}");
			}
		}

		static void PrimeNumbersDivisibility235Time()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersDivisibility235Time");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Lista przechowująca pomiary czasowe
				List<long> _oTimesList = new List<long>();

				//Petla uśredniająca wynik czasowy
				for (int x = 0; x < 10; x++)//10 pomiarów jednej liczby
				{
					//Zresetowanie stopera i rozpoczącie pomiaru
					stopwatch.Restart();

					//Metoda sprawdzająca liczbę pierwszą
					IsPrimeDivisibility235(prime);

					//Pomiar czasu
					stopwatch.Stop();

					//Dodanie wyniku do listy czasów
					_oTimesList.Add(stopwatch.ElapsedTicks);
				}

				//Zmienna przechowująca średnią czasową dla jednej liczy pierwszej
				long _lTimeAverage = CountAverage(_oTimesList);//Funkcja oblcizająca średnią czasową

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_lTimeAverage}");
			}
		}

		static void PrimeNumbersDivisibility235Instrumentation()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersDivisibility235Instrumentation");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Metoda sprawdzająca liczbę pierwszą
				IsPrimeDivisibility235(prime, out ulong _ulCriticalPoints);//Zmienna przechowująca ilość punktów krytycznych

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_ulCriticalPoints}");
			}
		}

		static void PrimeNumbersDivisibilityForm235Time()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersDivisibilityForm235Time");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Lista przechowująca pomiary czasowe
				List<long> _oTimesList = new List<long>();

				//Petla uśredniająca wynik czasowy
				for (int x = 0; x < 10; x++)//10 pomiarów jednej liczby
				{
					//Zresetowanie stopera i rozpoczącie pomiaru
					stopwatch.Restart();

					//Metoda sprawdzająca liczbę pierwszą
					IsPrimeDivisibilityForm235(prime);

					//Pomiar czasu
					stopwatch.Stop();

					//Dodanie wyniku do listy czasów
					_oTimesList.Add(stopwatch.ElapsedTicks);
				}

				//Zmienna przechowująca średnią czasową dla jednej liczy pierwszej
				long _lTimeAverage = CountAverage(_oTimesList);//Funkcja oblcizająca średnią czasową

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_lTimeAverage}");
			}
		}

		static void PrimeNumbersDivisibilityForm235Instrumentation()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersDivisibilityForm235Instrumentation");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Metoda sprawdzająca liczbę pierwszą
				IsPrimeDivisibilityForm235(prime, out ulong _ulCriticalPoints);//Zmienna przechowująca ilość punktów krytycznych

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_ulCriticalPoints}");
			}
		}

		static void PrimeNumbersEratostenesTime()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersEratostenesTime");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Lista przechowująca pomiary czasowe
				List<long> _oTimesList = new List<long>();

				//Petla uśredniająca wynik czasowy
				for (int x = 0; x < 10; x++)//10 pomiarów jednej liczby
				{
					//Zresetowanie stopera i rozpoczącie pomiaru
					stopwatch.Restart();

					//Metoda sprawdzająca liczbę pierwszą
					IsPrimeEratostenes(prime);

					//Pomiar czasu
					stopwatch.Stop();

					//Dodanie wyniku do listy czasów
					_oTimesList.Add(stopwatch.ElapsedTicks);
				}

				//Zmienna przechowująca średnią czasową dla jednej liczy pierwszej
				long _lTimeAverage = CountAverage(_oTimesList);//Funkcja oblcizająca średnią czasową

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_lTimeAverage}");
			}
		}

		static void PrimeNumbersEratostenesInstrumentation()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersEratostenesInstrumentation");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
				//Metoda sprawdzająca liczbę pierwszą
				IsPrimeEratostenes(prime, out ulong _ulCriticalPoints);//Zmienna przechowująca ilość punktów krytycznych

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_ulCriticalPoints}");
			}
		}

		#endregion

		#region NumericalSetTest

		static void NumericalSetTestTime()
		{
			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Deklaracja zmiennych
			List<long> _oTimes = new List<long>();
			BigInteger _iMax = 1000000000000000000;
			int i = 1, _iQuantity = 100, _iBy = 10, _iTry = 10;

			//Opis kolumn
			//Console.WriteLine("Number\tIsPrimeDivisibilityForm\tIsPrimeDivisibility235\tIsPrimeDivisibilityForm235\tIsPrimeEratotenes");

			//Główna pętla
			for (BigInteger x = 1; x <= _iMax; x *= _iBy)
			{
				//Wielkość przeszukiwanych liczb
				//Console.Write(x + "\t");

				//IsPrimeDivisibilityForm
				_oTimes.Clear();//Wyczyszczenie listy czasów
				for (int j = 0; j < _iTry; j++)//Ilość prób
				{
					i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
					stopwatch.Restart();//Restart stopera
					while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
					{
						IsPrimeDivisibilityForm(x + i++);//Funkcja liczb pierwszych
					}
					stopwatch.Stop();//Zatrzymanie stopera
					_oTimes.Add(stopwatch.ElapsedMilliseconds);//Dodanie czasu do lsity czasów
				}
				Console.Write(CountAverage(_oTimes) + "\t");//Obliczenie średniej czasowej i jej wyświetlenie

				//IsPrimeDivisibility235
				_oTimes.Clear();//Wyczyszczenie listy czasów
				for (int j = 0; j < _iTry; j++)//Ilość prób
				{
					i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
					stopwatch.Restart();//Restart stopera
					while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
					{
						IsPrimeDivisibility235(x + i++);//Funkcja liczb pierwszych
					}
					stopwatch.Stop();//Zatrzymanie stopera
					_oTimes.Add(stopwatch.ElapsedMilliseconds);//Dodanie czasu do lsity czasów
				}
				Console.Write(CountAverage(_oTimes) + "\t");//Obliczenie średniej czasowej i jej wyświetlenie

				//IsPrimeDivisibilityForm235
				_oTimes.Clear();//Wyczyszczenie listy czasów
				for (int j = 0; j < _iTry; j++)//Ilość prób
				{
					i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
					stopwatch.Restart();//Restart stopera
					while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
					{
						IsPrimeDivisibilityForm235(x + i++);//Funkcja liczb pierwszych
					}
					stopwatch.Stop();//Zatrzymanie stopera
					_oTimes.Add(stopwatch.ElapsedMilliseconds);//Dodanie czasu do lsity czasów
				}
				Console.Write(CountAverage(_oTimes) + "\t");//Obliczenie średniej czasowej i jej wyświetlenie

				//IsPrimeEratotenes
				_oTimes.Clear();//Wyczyszczenie listy czasów
				for (int j = 0; j < _iTry; j++)//Ilość prób
				{
					i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
					stopwatch.Restart();//Restart stopera
					while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
					{
						IsPrimeEratostenes(x + i++);//Funkcja liczb pierwszych
					}
					stopwatch.Stop();//Zatrzymanie stopera
					_oTimes.Add(stopwatch.ElapsedMilliseconds);//Dodanie czasu do lsity czasów
				}
				Console.Write(CountAverage(_oTimes) + "\t");//Obliczenie średniej czasowej i jej wyświetlenie

				//Przejście do nastepnej lini
				Console.WriteLine();
			}
		}

		static void NumericalSetTestInstrumentation()
		{
			//Deklaracja zmiennych
			BigInteger _iMax = 1000000000000000000;
			int i = 1, _iQuantity = 100, _iBy = 10;
			ulong _ulCriticalPointsSum = 0;

			//Opis kolumn
			//Console.WriteLine("Number\tIsPrimeDivisibilityForm\tIsPrimeDivisibility235\tIsPrimeDivisibilityForm235\tIsPrimeEratostenes");

			//Główna pętla
			for (BigInteger x = 1; x <= _iMax; x *= _iBy)
			{
				//Wielkość przeszukiwanych liczb
				//Console.Write(x + "\t");

				//IsPrimeDivisibilityForm
				i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
				_ulCriticalPointsSum = 0;//Zmienna przechowująca sumę punktów krytycznych
				while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
				{
					IsPrimeDivisibilityForm(x + i++, out ulong _ulCriticalPoints);//Funkcja liczb pierwszych
					_ulCriticalPointsSum += _ulCriticalPoints;//Sumowanie punktów krytycznych
				}
				Console.Write(_ulCriticalPointsSum + "\t");//Wyświetlenei punktów krytycznych

				//IsPrimeDivisibilityForm
				i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
				_ulCriticalPointsSum = 0;//Zmienna przechowująca sumę punktów krytycznych
				while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
				{
					IsPrimeDivisibility235(x + i++, out ulong _ulCriticalPoints);//Funkcja liczb pierwszych
					_ulCriticalPointsSum += _ulCriticalPoints;//Sumowanie punktów krytycznych
				}
				Console.Write(_ulCriticalPointsSum + "\t");//Wyświetlenei punktów krytycznych

				//IsPrimeDivisibilityForm
				i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
				_ulCriticalPointsSum = 0;//Zmienna przechowująca sumę punktów krytycznych
				while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
				{
					IsPrimeDivisibilityForm235(x + i++, out ulong _ulCriticalPoints);//Funkcja liczb pierwszych
					_ulCriticalPointsSum += _ulCriticalPoints;//Sumowanie punktów krytycznych
				}
				Console.Write(_ulCriticalPointsSum + "\t");//Wyświetlenei punktów krytycznych

				//IsPrimeDivisibilityForm
				i = 0;//Zresetowanie licznika kolejnych liczb naturalnych
				_ulCriticalPointsSum = 0;//Zmienna przechowująca sumę punktów krytycznych
				while (i <= _iQuantity)//Pętla dopóki licznik nie jest podaną wielkością liczbową
				{
					IsPrimeEratostenes(x + i++, out ulong _ulCriticalPoints);//Funkcja liczb pierwszych
					_ulCriticalPointsSum += _ulCriticalPoints;//Sumowanie punktów krytycznych
				}
				Console.Write(_ulCriticalPointsSum + "\t");//Wyświetlenei punktów krytycznych

				//Przejście do nastepnej lini
				Console.WriteLine();
			}
		}

		#endregion

		static void Main(string[] args)
		{
			//Postawowa metoda szukania liczb pierwszych - pomiar czasu
			//PrimeNumbersTime();

			//Podstawowa metoda szukania liczb pierwszych - instrumentacja
			//PrimeNumbersInstrumentation();

			//Pozytywna metoda szukania liczb pierwszych - pomiar czasu
			//PrimeNumbersPositiveTime();

			//Pozytywna metoda szukania liczb pierwszych - instrumentacja
			//PrimeNumbersPositiveInstrumentation();

			//Metoda podzielności za pomocą wzoru p = 6 * k + d szukania liczb pierwszych - pomiar czasu
			//PrimeNumbersDivisibilityFormTime();

			//Metoda podzielności za pomocą wzoru p = 6 * k + d szukania liczb pierwszych - instrumentacja
			//PrimeNumbersDivisibilityFormInstrumentation();

			//Metoda podzielności przez 2,3 i 5 szukania liczb pierwszych - pomiar czasu
			//PrimeNumbersDivisibility235Time();

			//Metoda podzielności przez 2,3 i 5 szukania liczb pierwszych - instrumentacja
			//PrimeNumbersDivisibility235Instrumentation();

			//Hybryda metod podzielności za pomocą wzoru p = 6 * k + d oraz podzielności przez 2,3 i 5 szukania liczb pierwszych - pomiar czasu
			//PrimeNumbersDivisibilityForm235Time();

			//Hybryda metod podzielności za pomocą wzoru p = 6 * k + d oraz podzielności przez 2,3 i 5 szukania liczb pierwszych - instrumentacja
			//PrimeNumbersDivisibilityForm235Instrumentation();

			//Metoda sita Eratostenesa szukania liczb pierwszych - pomiar czasu
			//PrimeNumbersEratostenesTime();

			//Metoda sita Eratostenesa szukania liczb pierwszych - instrumentacja
			//PrimeNumbersEratostenesInstrumentation();





			//Test wszystkich algorytmów na zbiorze liczbowym - pomiar czasu
			//NumericalSetTestTime();

			//Test wszystkich algorytmów na zbiorze liczbowym - instrumentacja
			//NumericalSetTestInstrumentation();





			//TESTS
			//ShowPrimes(100);
		}
	}
}