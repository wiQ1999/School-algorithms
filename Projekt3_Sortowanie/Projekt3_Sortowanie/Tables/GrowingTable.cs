namespace Projekt3_Sortowanie
{
	class GrowingTable : ITableGenerator
	{
		/// <summary>
		/// Generate growing numbers array
		/// </summary>
		/// <param name="a_iSize">Size of array</param>
		/// <returns>Growing array</returns>
		public int[] GenerateTab(int a_iSize)
		{
			//inicjalizacja tablicy
			int[] _oReturn = new int[a_iSize];

			//pętla po tablicy
			for (int i = 0; i < a_iSize; i++)
			{
				//przypisuje wartośc równą indeksowi
				_oReturn[i] = i;
			}

			//zwrócenie tablicy
			return _oReturn;
		}
	}
}
