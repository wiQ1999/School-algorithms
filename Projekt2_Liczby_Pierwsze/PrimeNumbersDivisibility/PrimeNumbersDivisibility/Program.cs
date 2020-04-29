using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace PrimeNumbersDivisibility
{
	class Program
	{
		#region PrimeMemory

		public static BigInteger[] PrimesArray = new BigInteger[] { 2, 3, 5, 7 };

		public static List<BigInteger> PrimesList = new List<BigInteger>() { 2, 3, 5, 7 };

		public static Dictionary<BigInteger, BigInteger> PrimesDictionaty = new Dictionary<BigInteger, BigInteger>() { { 0, 2 }, { 1, 3 }, { 2, 5 }, { 3, 7 } };

		static void ResizeMemory(ref BigInteger[] a_oArray, BigInteger _iLastPrime)
		{
			if (_iLastPrime < 7) _iLastPrime = 7;

			int i = a_oArray.Length - 1;

			if (a_oArray[i] > _iLastPrime)//Odjęcie liczb pierwszych z pamięci
			{
				while (a_oArray[i] > _iLastPrime)
				{
					i--;
				}
				Array.Resize(ref a_oArray, i + 1);
			}
			else//Dodanie liczb pierwszych do pamięci
			{
				for (BigInteger u = a_oArray[i] + 2; u < _iLastPrime; u += 2)
				{
					bool _bIsPrime = true;
					foreach (BigInteger prime in PrimesArray)
					{
						if (u % prime == 0)
						{
							_bIsPrime = false;
							break;
						}
					}

					if (_bIsPrime)
					{
						i = a_oArray.Length;
						Array.Resize(ref a_oArray, i + 1);
						a_oArray[i] = u;
					}
				}
			}
		}

		static void ResizeMemory(ref List<BigInteger> a_oList, BigInteger _iLastPrime)
		{
			if (_iLastPrime < 7) _iLastPrime = 7;

			int i = a_oList.Count - 1;

			if (a_oList[i] > _iLastPrime)//Odjęcie liczb pierwszych z pamięci
			{
				while (a_oList[i] > _iLastPrime)
				{
					a_oList.RemoveAt(i--);
				}
			}
			else//Dodanie liczb pierwszych do pamięci
			{
				for (BigInteger u = a_oList[i] + 2; u < _iLastPrime; u += 2)
				{
					bool _bIsPrime = true;
					foreach (BigInteger prime in PrimesList)
					{
						if (u % prime == 0)
						{
							_bIsPrime = false;
							break;
						}
					}

					if (_bIsPrime)
						a_oList.Add(u);
				}
			}
		}

		static void ResizeMemory(ref Dictionary<BigInteger, BigInteger> a_oDictionary, BigInteger _iLastPrime)
		{
			if (_iLastPrime < 7) _iLastPrime = 7;

			int i = a_oDictionary.Count - 1;

			if (a_oDictionary[i] > _iLastPrime)//Odjęcie liczb pierwszych z pamięci
			{
				while (a_oDictionary[i] > _iLastPrime)
				{
					a_oDictionary.Remove(i--);
				}
			}
			else//Dodanie liczb pierwszych do pamięci
			{
				for (BigInteger u = a_oDictionary[i] + 2; u < _iLastPrime; u += 2)
				{
					bool _bIsPrime = true;
					foreach (BigInteger prime in PrimesDictionaty.Values)
					{
						if (u % prime == 0)
						{
							_bIsPrime = false;
							break;
						}
					}

					if(_bIsPrime)
						a_oDictionary.Add(++i, u);
				}
			}
		}

		static void CleanMemory(ref BigInteger[] a_oArray)
		{
			a_oArray = new BigInteger[] { 2, 3, 5, 7 };
		}

		static void CleanMemory(ref List<BigInteger> a_oList)
		{
			a_oList = new List<BigInteger>() { 2, 3, 5, 7 };
		}

		static void CleanMemory(ref Dictionary<BigInteger,BigInteger> a_oDictionary)
		{
			a_oDictionary = new Dictionary<BigInteger, BigInteger>() { { 0, 2 }, { 1, 3 }, { 2, 5 }, { 3, 7 } };
		}

		#endregion

		#region PrimeMethods

		static bool Positive(BigInteger a_iNumber)
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

		static bool Div(BigInteger a_iNumber)
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

		static bool Div1(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4) return true;
			else if (a_iNumber == 5 || a_iNumber == 7) return true;
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

		static bool Div2(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4 || a_iNumber == 5 || a_iNumber == 7) return true;
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

		static bool Div3(BigInteger a_iNumber)
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

		static bool Divisibility2(BigInteger a_iNumber)
		{
			if (a_iNumber % 2 == 0) return false;

			return true;
		}

		static bool Divisibility21(BigInteger a_iNumber)
		{
			uint _iMod = 0;

			_iMod = (uint)a_iNumber % 10;

			if (_iMod % 2 == 0) return false;

			return true;
		}

		static bool Divisibility22(BigInteger a_iNumber)
		{
			uint _iMod = 0;

			_iMod = (uint)a_iNumber % 10;

			if (_iMod == 0 || _iMod == 2 || _iMod == 4 || _iMod == 6 || _iMod == 8) return false;

			return true;
		}

		static bool Divi30(BigInteger a_iNumber)
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

				if (_iMod == 0 || _iMod == 2 || _iMod == 4 || _iMod == 5 || _iMod == 6 || _iMod == 8) return false;

				if (a_iNumber % 3 == 0) return false;

				BigInteger p = 0, k = 1;

				while (p * p <= a_iNumber)
				{
					p = 6 * k - 1;

					if (a_iNumber % p == 0) return false;

					p = 6 * k + 1;

					if (a_iNumber % p == 0) return false;

					k++;
				}
			}

			return true;
		}

		static bool Divi303(BigInteger a_iNumber)
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

				if (_iMod == 0 || _iMod == 2 || _iMod == 4 || _iMod == 5 || _iMod == 6 || _iMod == 8) return false;

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

				BigInteger p = 0, k = 1;

				while (p * p <= a_iNumber)
				{
					p = 6 * k - 1;

					if (a_iNumber % p == 0) return false;

					p = 6 * k + 1;

					if (a_iNumber % p == 0) return false;

					k++;
				}
			}

			return true;
		}

		static bool Divi32(BigInteger a_iNumber)
		{
			if(a_iNumber < 10)
			{
				if (a_iNumber < 2) return false;
				if (a_iNumber < 4 || a_iNumber == 5 || a_iNumber == 7) return true;

				return false;
			}
			else
			{
				BigInteger _iMod = a_iNumber % 10;

				if (_iMod % 2 == 0) return false;

				if (a_iNumber % 3 == 0) return false;

				BigInteger p = 0, k = 1;

				while(p * p <= a_iNumber)
				{
					p = 6 * k - 1;

					if (a_iNumber % p == 0) return false;

					p = 6 * k + 1;

					if (a_iNumber % p == 0) return false;

					k++;
				}
			}

			return true;
		}

		static bool Divi3235(BigInteger a_iNumber)
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

		static BigInteger Divi3235Return(BigInteger a_iNumber)
		{

			BigInteger _iMod = a_iNumber % 10;

			if (_iMod % 2 == 0) return 2;
			if (_iMod % 5 == 0) return 5;

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

			if (_iModSum % 3 == 0) return 3;

			BigInteger p = 0, k = 1;

			while (p * p <= a_iNumber)
			{
				p = 6 * k - 1;

				if (a_iNumber % p == 0) return p;

				p = 6 * k + 1;

				if (a_iNumber % p == 0) return p;

				k++;
			}

			return a_iNumber;
		}

		static bool Divi325(BigInteger a_iNumber)
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

				if (a_iNumber % 3 == 0) return false;

				BigInteger p = 0, k = 1;

				while (p * p <= a_iNumber)
				{
					p = 6 * k - 1;

					if (a_iNumber % p == 0) return false;

					p = 6 * k + 1;

					if (a_iNumber % p == 0) return false;

					k++;
				}
			}

			return true;
		}

		static bool Divi325v2(BigInteger a_iNumber)
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

				if (a_iNumber % 3 == 0) return false;

				if (_iMod == 5) return false;

				BigInteger p = 0, k = 1;

				while (p * p <= a_iNumber)
				{
					p = 6 * k - 1;

					if (a_iNumber % p == 0) return false;

					p = 6 * k + 1;

					if (a_iNumber % p == 0) return false;

					k++;
				}
			}

			return true;
		}

		static bool Array1(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;

			foreach (BigInteger prime in PrimesArray)
			{
				if (a_iNumber == prime) return true;
				if (a_iNumber % prime == 0) return false;
			}

			BigInteger p = PrimesArray[PrimesArray.Length - 1], k = (p + 1) / 6;
			sbyte d = -1;

			if (p < 6 * k)
			{
				p = 6 * k - d;
				ArrayPrimeLoop(p);
				if (a_iNumber == p)
				{
					ArrayAddPrime(p);
					return true;
				}
				if (a_iNumber % p == 0) return false;
			}

			p = 6 * ++k + d;

			while (p < a_iNumber)
			{
				ArrayPrimeLoop(p);
				if (a_iNumber % p == 0) return false;
				if (d == 1)
				{
					d = -1;
					k++;
				}
				else d = 1;
				p = 6 * k + d;
			}

			ArrayAddPrime(a_iNumber);
			return true;
		}

		static void ArrayPrimeLoop(BigInteger p)
		{
			foreach (BigInteger prime in PrimesArray)
			{
				if (prime * prime > p)
				{
					ArrayAddPrime(p);
					return;
				}
				if (p % prime == 0) return;
			}
		}

		static void ArrayAddPrime(BigInteger p)
		{
			Array.Resize(ref PrimesArray, PrimesArray.Length + 1);
			PrimesArray[PrimesArray.Length - 1] = p;
		}

		static bool List1(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;

			foreach (BigInteger prime in PrimesList)
			{
				if (a_iNumber == prime) return true;
				if (a_iNumber % prime == 0) return false;
			}

			BigInteger p = PrimesList[PrimesList.Count - 1], k = (p + 1) / 6;
			sbyte d = -1;

			if (p < 6 * k)
			{
				p = 6 * k - d;
				ListPrimeLoop(p);
				if (a_iNumber == p)
				{
					PrimesList.Add(p);
					return true;
				}
				if (a_iNumber % p == 0) return false;
			}

			p = 6 * ++k + d;

			while (p < a_iNumber)
			{
				ListPrimeLoop(p);
				if (a_iNumber % p == 0) return false;
				if (d == 1)
				{
					d = -1;
					k++;
				}
				else d = 1;
				p = 6 * k + d;
			}

			PrimesList.Add(a_iNumber);
			return true;
		}

		static void ListPrimeLoop(BigInteger p)
		{
			foreach (BigInteger prime in PrimesList)
			{
				if (prime * prime > p)
				{
					PrimesList.Add(p);
					return;
				}
				if (p % prime == 0) return;
			}
		}

		static bool Dictionary1(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;

			foreach (BigInteger prime in PrimesDictionaty.Values)
			{
				if (a_iNumber == prime) return true;
				if (a_iNumber % prime == 0) return false;
			}

			BigInteger p = PrimesDictionaty[PrimesDictionaty.Count - 1], k = (p + 1) / 6;
			sbyte d = -1;

			if (p < 6 * k)
			{
				p = 6 * k - d;
				DictionaryPrimeLoop(p);
				if (a_iNumber == p)
				{
					PrimesDictionaty.Add(PrimesDictionaty.Count, p);
					return true;
				}
				if (a_iNumber % p == 0) return false;
			}

			p = 6 * ++k + d;

			while (p < a_iNumber)
			{
				DictionaryPrimeLoop(p);
				if (a_iNumber % p == 0) return false;
				if (d == 1)
				{
					d = -1;
					k++;
				}
				else d = 1;
				p = 6 * k + d;
			}

			PrimesDictionaty.Add(PrimesDictionaty.Count, a_iNumber);
			return true;
		}

		static void DictionaryPrimeLoop(BigInteger p)
		{
			foreach (BigInteger prime in PrimesDictionaty.Values)
			{
				if (prime * prime > p)
				{
					PrimesDictionaty.Add(PrimesDictionaty.Count, p);
					return;
				}
				if (p % prime == 0) return;
			}
		}

		static bool Divi3235Only(BigInteger a_iNumber)
		{
			if (a_iNumber < 2) return false;
			else if (a_iNumber < 4 || a_iNumber == 5) return true;
			else
			{
				BigInteger _iMod = a_iNumber % 10;

				if (_iMod % 2 == 0 || _iMod % 5 == 0) return false;

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

		static bool Erastotenes(BigInteger a_iNumber)
		{
			//natychmiastowe zwrócenie fałszu jeżeli szukana jest mniejsza od liczby 2
			if (a_iNumber < 2) return false;

			//deklaracja zmiennych
			int _iRangeSqrt = (int)(Math.Sqrt((double)a_iNumber));
			int[] _oTab = new int[_iRangeSqrt - 1];

			//inicjuj tablice
			for (int i = 2; i <= _iRangeSqrt; i++) _oTab[i - 2] = i;

			//algorytm - sito eratostenesa
			for (int i = 2; i < _iRangeSqrt; i++)//pętla po liczbach a nie indeksach
			{
				if (_oTab[i - 2] != 0)//jeżeli wartość w tablicy nie jest zerem
				{
					int j = i + i;//zmienna pomocnicza wielokrotności liczbowej
					while (j <= _iRangeSqrt)//dopóki wielokrotnośc jest mniejsza lub równa pierwiastka z szukanej lcizby
					{
						_oTab[j - 2] = 0;//wyzerowanie liczby, która jest wielokrotnością
						j += i;//dodanie wielkrotności
					}
				}
			}

			//wynik
			for (int i = 0; i < _iRangeSqrt - 1; i++)
			{
				if (_oTab[i] != 0)//jeżeli liczba nie jest zerem
				{
					if (a_iNumber % _oTab[i] == 0) return false;//podzielność
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

		static void ShowPrimes()
		{
			BigInteger _iStart = 0, _iLicznik = 0, _iZakres = 100;

			while(_iLicznik < _iZakres)
			{
				if (Erastotenes(_iStart))
				{
					Console.Write($"{_iStart}, ");

					_iLicznik++;
				}

				_iStart++;
			}
		}

		static void AlgorithmsTest()
		{
			Stopwatch stopwatch = new Stopwatch();

			for (BigInteger i = 1; i < 100000000000000000; i *= 10)
			{
				BigInteger j = i;
				bool _bIsNotPrime = true;

				while (_bIsNotPrime)
				{
					if (Positive(j))
					{
						_bIsNotPrime = false;

						List<long> _oTimes = new List<long>();

						for (int x = 0; x < 10; x++)
						{
							stopwatch.Restart();

							Divi325(j);

							stopwatch.Stop();

							_oTimes.Add(stopwatch.ElapsedMilliseconds);
						}

						Console.WriteLine($"{CountAverage(_oTimes)}");
					}

					j++;
				}
			}
		}

		static void AlgorithmsMaxTime()
		{
			Stopwatch stopwatch = new Stopwatch();

			List<long> _oTimes = new List<long>();

			BigInteger _iOd = 1;
			BigInteger _iDo = 1000000000000000000;
			int _iIle = 100;

			for (BigInteger x = _iOd; x <= _iDo; x *= 100)//Następne wielkości liczb
			{

				//Sito6Divi0
				_oTimes.Clear();
				for (int j = 0; j < 10; j++)//10 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi30(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.Write(CountAverage(_oTimes) + "\t");

				//Sito6Divi03
				_oTimes.Clear();
				for (int j = 0; j < 10; j++)//10 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi303(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.Write(CountAverage(_oTimes) + "\t");

				//Sito6Divi2
				_oTimes.Clear();
				for (int j = 0; j < 10; j++)//10 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi32(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.Write(CountAverage(_oTimes) + "\t");

				//Sito6Divi235
				_oTimes.Clear();
				for (int j = 0; j < 10; j++)//10 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi3235(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.Write(CountAverage(_oTimes) + "\t");

				//Sito6Divi25
				_oTimes.Clear();
				for (int j = 0; j < 10; j++)//10 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi325(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.Write(CountAverage(_oTimes) + "\t");

				Console.WriteLine();
			}
		}

		static void AlgorithmsMaxTime2()
		{
			Stopwatch stopwatch = new Stopwatch();

			BigInteger _iOd = 1;
			BigInteger _iDo = 1000000000000000000;
			int _iIle = 100;

			//Divi3235Only
			Console.WriteLine("Divi3235Only");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi3235Only(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			/*
			//Dictionary1
			Console.WriteLine("Dictionary1");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Dictionary1(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
			//List1
			Console.WriteLine("List1");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						List1(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
			//Array1
			Console.WriteLine("Array1");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Array1(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
			//Divi325v2
			Console.WriteLine("Divi325v2");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi325v2(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
			//Divi325
			Console.WriteLine("Divi325");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi325(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
			//Divi3235
			Console.WriteLine("Divi3235");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi3235(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}

			//Divi32
			Console.WriteLine("Divi32");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi32(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}

			//Divi303
			Console.WriteLine("Divi303");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi303(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}

			//Divi30
			Console.WriteLine("Divi30");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Divi30(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			*/
		}

		static void AlgorithmSpeedTest()
		{
			Stopwatch stopwatch = new Stopwatch();

			List<long> _oTimes = new List<long>();

			BigInteger _iOd = 20, _iDo = 25;

			Console.WriteLine("List1");
			for (int j = 0; j < 5; j++)//5 prób
			{
				//ResizeMemory(ref PrimesDictionaty, _iOd);
				stopwatch.Restart();
				for (BigInteger i = _iOd; i < _iDo; i++)
				{
					List1(i);
				}
				stopwatch.Stop();
				_oTimes.Add(stopwatch.ElapsedMilliseconds);
			}
			Console.WriteLine(CountAverage(_oTimes));
		}

		static void AlgorithmSpeedTest2()
		{
			Stopwatch stopwatch = new Stopwatch();

			BigInteger _iIle = 100, _iZakres = 0; ;

			Console.WriteLine("Array1");
			for (BigInteger x = 1; x < 1000000000000000000; x *= 10)
			{ 
				List<long> _oTimes = new List<long>();
				_iZakres = x + _iIle;
				for (int j = 0; j < 5; j++)//5 prób
				{
					CleanMemory(ref PrimesArray);
					stopwatch.Restart();
					for (BigInteger i = x; i <= _iZakres; i++)
					{
						Array1(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
		}

		static void NumberDivisibility()
		{
			for (BigInteger i = 10000000; i <= 11000000; i++)
			{
				Console.WriteLine($"{i}\t{Divi3235Return(i)}");
			}
		}

		#endregion

		static void Main(string[] args)
		{
			//ShowPrimes();

			//AlgorithmsTest();

			//AlgorithmsMaxTime();

			//AlgorithmsMaxTime2();

			//AlgorithmSpeedTest();

			//AlgorithmSpeedTest2();

			//NumberDivisibility();
		}
	}
}
