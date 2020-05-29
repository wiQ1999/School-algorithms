using System;

namespace Projekt3_Sortowanie
{
	class RandomTable
	{
		/// <summary>
		/// Generate random numbers array
		/// </summary>
		/// <param name="a_iSize">Size of array</param>
		/// <returns>Random array</returns>
		public int[] GenerateTab(int a_iSize)
		{
			//Obiekt losowy
			Random rnd = new Random();

			//inicjalizacja tablicy
			int[] _oReturn = new int[a_iSize];

			//pętla po tablicy
			for (int i = 0; i < a_iSize; i++)
			{
				//przypisuje wartość randomową nie ujemną do int.MaxValue
				_oReturn[i] = rnd.Next();
			}

			//zwrócenie tablicy
			return _oReturn;
		}
	}
}
