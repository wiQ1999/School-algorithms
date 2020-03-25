namespace Projekt1_Wyszukiwanie
{
	class Liniowe
	{
		/// <summary>
		/// Linear searching of array using instrumentation / critical points
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		/// <param name="_lCriticalPoints">Return value with count of critical points</param>
		public long LinSearchInst(int[] a_oMatrix, int a_uSearchingNumber, out long _lCriticalPoints)
		{
			_lCriticalPoints = 0;
			for (int i = 0; i < a_oMatrix.Length; i++)
			{
				_lCriticalPoints++;
				if (a_oMatrix[i] == a_uSearchingNumber)
					return a_uSearchingNumber;
			}

			return 0;
		}

		/// <summary>
		/// Linear searching of array using time measuring
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		public int LinSearchTime(int[] a_oMatrix, int a_uSearchingNumber)
		{
			for (int i = 0; i < a_oMatrix.Length; i++)
			{
				if (a_oMatrix[i] == a_uSearchingNumber)
					return a_uSearchingNumber;
					
			}

			return 0;
		}
	}
}
