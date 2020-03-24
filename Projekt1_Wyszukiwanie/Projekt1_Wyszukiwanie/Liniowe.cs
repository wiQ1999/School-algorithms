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
		public void LinSearchInst(uint[] a_oMatrix, uint a_uSearchingNumber, out long _lCriticalPoints)
		{
			_lCriticalPoints = 1;
			for (uint i = 0; i < a_oMatrix.Length; i++, _lCriticalPoints++)
			{
				_lCriticalPoints += 2;
				if (a_oMatrix[i] == a_uSearchingNumber)
					return;
			}
		}

		/// <summary>
		/// Linear searching of array using time measuring
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		public void LinSearchTime(uint[] a_oMatrix, uint a_uSearchingNumber)
		{
			for (uint i = 0; i < a_oMatrix.Length; i++)
			{
				if (a_oMatrix[i] == a_uSearchingNumber)
					return;
			}
		}
	}
}
