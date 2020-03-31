namespace Projekt1_Wyszukiwanie
{
	class Binarne
	{
		/// <summary>
		/// Binary searching of array using instrumentation / critical points
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		/// <param name="_lCriticalPoints">Return value with count of critical points</param>
		/// <returns></returns>
		public long BinSearchInst(int[] a_oMatrix, int a_uSearchingNumber, out long _lCriticalPoints)
		{
			int _uLeft = 0;
			int _uRight = a_oMatrix.Length - 1;

			_lCriticalPoints = 0;

			while (_uLeft <= _uRight)
			{
				int _uCenter = (_uLeft + _uRight) / 2;

				
				if (a_oMatrix[_uCenter] == a_uSearchingNumber)
				{
					_lCriticalPoints++;
					return a_uSearchingNumber;
				}
				else if (a_oMatrix[_uCenter] > a_uSearchingNumber)
				{
					_lCriticalPoints += 2;
					_uRight = _uCenter - 1;
				}
				else
				{
					_lCriticalPoints += 2;
					_uLeft = _uCenter + 1;
				}
			}

			return -1;
		}

		/// <summary>
		/// Binary searching of array using time measuring
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		/// <returns></returns>
		public int BinSearchTime(int[] a_oMatrix, int a_uSearchingNumber)
		{
			int _uLeft = 0;
			int _uRight = a_oMatrix.Length - 1;

			while (_uLeft <= _uRight)
			{
				int _uCenter = (_uLeft + _uRight) / 2;

				if (a_oMatrix[_uCenter] == a_uSearchingNumber)
					return a_uSearchingNumber;
				else if (a_oMatrix[_uCenter] > a_uSearchingNumber)
					_uRight = _uCenter - 1;
				else
					_uLeft = _uCenter + 1;
			}

			return -1;
		}
	}
}
