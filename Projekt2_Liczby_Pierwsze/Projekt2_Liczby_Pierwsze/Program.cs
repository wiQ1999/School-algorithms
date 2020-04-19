using System;
using System.Collections.Generic;
using System.Data;
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
			else if (a_iNumber < 4) return true;
			else
			{
				if (a_iNumber % 2 == 0) return false;
				else
				{
					for (BigInteger u = 3; u * u <= a_iNumber; u += 2)
					{
						if (a_iNumber % u == 0) return false;
					}
				}
			}

			return true;
		}

		static bool IsPrimePositive(BigInteger a_iNumber, out ulong _ulCriticalPoints)
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
					for (BigInteger u = 3; u <= (BigInteger)Math.Sqrt((double)a_iNumber); u += 2)
					{
						_ulCriticalPoints++;//Dodanie punktu krytycznego
						if (a_iNumber % u == 0) return false;
					}
				}
			}

			return true;
		}

		static bool IsPrimeSito6(BigInteger a_iNumber)
		{
			if (a_iNumber < 11)
			{
				if (a_iNumber != 2 && a_iNumber != 3 && a_iNumber != 5 && a_iNumber != 7) return false;
			}
			else
			{
				if (a_iNumber % 2 == 0) return false;
				if (a_iNumber % 3 == 0) return false;

				BigInteger prime = 0, k = 1;

				while (prime * prime <= a_iNumber)
				{
					prime = 6 * k - 1;
					if (a_iNumber % prime == 0) return false;

					prime = 6 * k + 1;
					if (a_iNumber % prime == 0) return false;

					k++;
				}
			}

			return true;
		}

		static bool IsPrimeSito6(BigInteger a_iNumber, out ulong _ulCriticalPoints)
		{
			_ulCriticalPoints = 0;//Zmienna puktów krytycznych

			if (a_iNumber < 11)
			{
				if (a_iNumber != 2 && a_iNumber != 3 && a_iNumber != 5 && a_iNumber != 7) return false;
			}
			else
			{
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (a_iNumber % 2 == 0) return false;
				_ulCriticalPoints++;//Dodanie punktu krytycznego
				if (a_iNumber % 3 == 0) return false;

				BigInteger prime = 0, k = 1;

				while (prime * prime <= a_iNumber)
				{
					prime = 6 * k - 1;
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					if (a_iNumber % prime == 0) return false;

					prime = 6 * k + 1;
					_ulCriticalPoints++;//Dodanie punktu krytycznego
					if (a_iNumber % prime == 0) return false;

					k++;
				}
			}

			return true;
		}

		static bool IsPrimeDivisibility(BigInteger a_iNumber)
		{
			//Deklaracja zmiennych
			BigInteger _iMod = -1, _iLength = 10, _iSum = 0, _iBy7 = 0;
			uint _uPow = 0;

			//Petla zczytujące koljne cyfry w liczbie
			while (_iMod != a_iNumber)//Dopóki modulo z liczby mnożonej o 10 nie jest równy badanej liczbie
			{
				//Zczytanie cyfry z danego miejsca w liczbie
				_iMod = a_iNumber % _iLength;

				//Dodanie cyfry do sumy cyft badanej liczby
				_iSum += _iMod / (_iLength / 10);
				
				//Badania podzielności 
				if(_iLength == 10)//Pierwsza cyfra w badanej liczbie
				{
					if (_iMod % 2 == 0) return false;//Podzielne przez 2
					if (_iMod % 5 == 0) return false;//Podzielne przez 5
				}

				//Sumowanie podzielności przez 7
				_iBy7 += (BigInteger)Math.Pow((double)_iMod, _uPow++);//Zwiekszenie mocy potęgi o jeden

				//przesunięcie na nastepną cyfrę
				_iLength *= 10;
			}

			if (_iSum % 3 == 0) return false;//Podzielne przez 3
			if (_iBy7 % 7 == 0) return false;//Podzielne przez 7

			return true;
		}

		#endregion

		#region MainMethods

		static void PrimeNumbersTime()
		{
			//Opis metody w konsoli
			Console.WriteLine("PrimeNumbersTime");

			//Opis kolumn
			Console.WriteLine("Number\tTime/Points\t");

			//Deklaracja stopera
			Stopwatch stopwatch = new Stopwatch();

			//Lista przechowująca pomiary czasowe
			List<long> _oTimesList = new List<long>();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
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

			//Lista przechowująca pomiary czasowe
			List<long> _oTimesList = new List<long>();

			//Petla po liście z numerami pierwszymi
			foreach (BigInteger prime in PrimeNumbers)
			{
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
					_oTimesList.Add(stopwatch.ElapsedMilliseconds);
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

		//TESTY
		static void PrimeNumbersTEST()
		{
			BigInteger Length = 1000;

			for (BigInteger i = 0; i < Length; i++)
			{
				if (IsPrimePositive(i))
				{
					Console.WriteLine($"{i}\t{IsPrimeSito6(i)}");
				}
			}
		}

		static void PrimeNumbersTEST2()
		{
			BigInteger counter = 0;
			BigInteger zakres = 0;

			while(zakres < 100)
			{
				if (IsPrimeDivisibility(counter))
				{
					Console.Write(counter + ", ");
					zakres++;
				}

				counter++;
			}
		}


		#endregion

		static void Main(string[] args)
		{
			//Postawowa metoda szukania liczb pierwszych - pomiar czasu
			//PrimeNumbersTime();

			//Podstawowa metoda szukanai liczb pierwszych - instrumentacja
			//PrimeNumbersInstrumentation();

			//Pozytywna metoda szukanai liczb pierwszych - pomiar czasu
			//PrimeNumbersPositiveTime();

			//Pozytywna metoda szukanai liczb pierwszych - instrumentacja
			//PrimeNumbersPositiveInstrumentation();


			

			//TESTY
			PrimeNumbersTEST2();
		}
	}
}
