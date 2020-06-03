namespace Projekt3_Sortowanie.Sorting
{
	class InsertionSort : ASortingAlgorithm
	{
        public InsertionSort(int[] a_oBaseTab) : base(a_oBaseTab)
        {
        }

        public override void Sort(int[] a_oTab)
        {
            //główna pętla
            for (uint i = 1; i < a_oTab.Length; i++)
            {
                //zmienne koljenych wartości
                uint _iIndex = i;
                int _iValue = a_oTab[_iIndex];

                //dopóki jest mniejszy niż indeks 0 && wartość po lewej jest mniejsza niż wartość ze sprawdzanego indeksu
                while ((_iIndex > 0) && (a_oTab[_iIndex - 1] > _iValue))
                {
                    //przesuwanie wartości
                    a_oTab[_iIndex] = a_oTab[_iIndex - 1];
                    _iIndex--;
                }

                //nadpisanie wartości
                a_oTab[_iIndex] = _iValue;
            }
        }
    }
}
