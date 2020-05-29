namespace Projekt3_Sortowanie
{
	class DecreasingTable : ITableGenerator
	{
		/// <summary>
		/// Generate decreasing numbers array
		/// </summary>
		/// <param name="a_iSize">Size of array</param>
		/// <returns>Decreasing array</returns>
		public int[] GenerateTab(int a_iSize)
		{
			//inicjalizacja tablicy
			int[] _oReturn = new int[a_iSize];

			//pętla po tablicy
			for (int i = 0; i < a_iSize; i++)
			{
				//przypisuje wartość ujmneą indeksu
				_oReturn[i] = -i;
			}

			//zwrócenie tablicy
			return _oReturn;
		}
	}
}
