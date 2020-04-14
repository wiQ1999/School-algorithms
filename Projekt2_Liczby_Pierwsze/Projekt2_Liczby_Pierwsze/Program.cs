using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Projekt2_Liczby_Pierwsze
{
	class Program
	{
		public static List<ulong> PrimeNumbers = new List<ulong>() { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

		#region PrimeMethods

		static bool IsPrime(ulong a_ulNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_ulNumber < 2) return false;
			else if (a_ulNumber < 4) return true;
			else 
			{
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (a_ulNumber % 2 == 0) return false;
				else
				{
					for (ulong u = 3; u < a_ulNumber / 2; u += 2)
					{
						_ulCriticalPoints++;//Dodanie punktu krytycznego
						if (a_ulNumber % u == 0) return false;
					}
				}
			}

			return true;
		}

		static bool IsPrime(ulong a_ulNumber)
		{
			if (a_ulNumber < 2) return false;
			else if (a_ulNumber < 4) return true;
			else
			{
				if (a_ulNumber % 2 == 0) return false;
				else
				{
					for (ulong u = 3; u < a_ulNumber / 2; u += 2)
					{
						if (a_ulNumber % u == 0) return false;
					}
				}
			}

			return true;
		}

		#endregion

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

		#endregion

		#region MainMethods

		static void PrimeNumbersTime()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersTime");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Lista przechowująca pomiary czasowe
			List<long> _oTimesList = new List<long>();

			//Petla po liście z numerami pierwszymi
			foreach (ulong prime in PrimeNumbers)
			{
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
					_oTimesList.Add(stopwatch.ElapsedMilliseconds);
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

			//Petla po liście z numerami pierwszymi
			foreach (ulong prime in PrimeNumbers)
			{
				//Metoda sprawdzająca liczbę pierwszą
				IsPrime(prime, out ulong _ulCriticalPoints);//Zmienna przechowująca ilość punktów krytycznych

				//Wypisanie wyniku na tablicy
				Console.WriteLine($"{prime}\t{_ulCriticalPoints}");
			}
		}

		#endregion

		static void Main(string[] args)
		{
			Console.WriteLine("Number\tTime/Points\t");

			//Postawowa metoda szukania liczb pierwszych - pomiar czasu
			PrimeNumbersTime();

			//Podstawowa metoda szukanai liczb pierwszych - instrumentacja
			PrimeNumbersInstrumentation();

			//Zmodyfikowana metoda szukanai liczb pierwszych - pomiar czasu


			//Zmodyfikowana metoda szukanai liczb pierwszych - instrumentacja

		}
	}
}
