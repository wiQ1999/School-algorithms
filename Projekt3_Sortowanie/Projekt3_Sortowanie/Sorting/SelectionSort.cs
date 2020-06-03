namespace Projekt3_Sortowanie
{
	class SelectionSort : ASortingAlgorithm
	{
		public SelectionSort(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}
		
		/// <summary>
		/// Selection Sort
		/// </summary>
		/// <param name="a_oTab">Array to sort</param>
		/// <returns>Sorted array</returns>
		public override void Sort(int[] a_oTab)
		{
			//zmienna przechowująca indeks tablicy
			uint _iMinIndex;

			//główna pętla bez uwzględniania ostatniej liczby w tablicy
			for (uint i = 0; i < (a_oTab.Length - 1); i++)
			{
				//przepisanie wartości do zmiennej
				int _iSwapValue = a_oTab[i];
				//przepisanie indeksu
				_iMinIndex = i;

				//pętla po reszcie liczb
				for (uint j = i + 1; j < a_oTab.Length; j++)
				{
					//Sprawdzanie czy wartość z tablicy jest mniejsza niż wartość minimalnego indkesu
					if (a_oTab[j] < _iSwapValue)
					{
						//zmiana wartości minimalnej w przeszukiwanej tablicy
						_iMinIndex = j;
						_iSwapValue = a_oTab[j];
					}
				}

				//zamiana wartości w tablicy
				a_oTab[_iMinIndex] = a_oTab[i];
				a_oTab[i] = _iSwapValue;
			}
		}
	}
}
