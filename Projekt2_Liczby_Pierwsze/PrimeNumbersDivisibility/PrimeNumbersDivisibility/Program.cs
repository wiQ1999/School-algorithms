using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace PrimeNumbersDivisibility
{
	class Program
	{
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

		static bool Sito6(BigInteger a_iNumber)
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

		static bool Sito61(BigInteger a_iNumber)
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

		static bool Sito62(BigInteger a_iNumber)
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

		static bool Sito63(BigInteger a_iNumber)
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

		static bool Sito6Divi0(BigInteger a_iNumber)
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

		static bool Sito6Divi03(BigInteger a_iNumber)
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

		static bool Sito6Divi2(BigInteger a_iNumber)
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

		static bool Sito6Divi235(BigInteger a_iNumber)
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

		static bool Sito6Divi25(BigInteger a_iNumber)
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

		static bool Sito6Divi25v2(BigInteger a_iNumber)
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
			BigInteger _iNumber = 0, _iLicznik = 0, _iZakres = 100;

			while(_iLicznik < _iZakres)
			{
				if (Sito6Divi25v2(_iNumber))
				{
					Console.Write($"{_iNumber}, ");

					_iLicznik++;
				}

				_iNumber++;
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

							Sito6Divi25(j);

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
						Sito6Divi0(i);
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
						Sito6Divi03(i);
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
						Sito6Divi2(i);
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
						Sito6Divi235(i);
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
						Sito6Divi25(i);
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

			//Sito6Divi25v2
			Console.WriteLine("Sito6Divi25v2");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Sito6Divi25v2(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
			//Sito6Divi25
			Console.WriteLine("Sito6Divi25");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Sito6Divi25(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
			//Sito6Divi235
			Console.WriteLine("Sito6Divi235");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Sito6Divi235(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}

			//Sito6Divi2
			Console.WriteLine("Sito6Divi2");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Sito6Divi2(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}

			//Sito6Divi03
			Console.WriteLine("Sito6Divi03");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Sito6Divi03(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}

			//Sito6Divi0
			Console.WriteLine("Sito6Divi0");
			for (BigInteger x = _iOd; x <= _iDo; x *= 10)//Następne wielkości liczb
			{
				List<long> _oTimes = new List<long>();
				for (int j = 0; j < 5; j++)//5 prób
				{
					stopwatch.Restart();
					for (BigInteger i = x; i <= x + _iIle; i++)////100 liczb
					{
						Sito6Divi0(i);
					}
					stopwatch.Stop();
					_oTimes.Add(stopwatch.ElapsedMilliseconds);
				}
				Console.WriteLine(CountAverage(_oTimes));
			}
			
		}

		#endregion

		static void Main(string[] args)
		{
			//ShowPrimes();

			//AlgorithmsTest();

			//AlgorithmsMaxTime();

			AlgorithmsMaxTime2();
		}
	}
}
