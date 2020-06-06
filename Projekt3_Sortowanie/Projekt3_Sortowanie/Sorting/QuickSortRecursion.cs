using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt3_Sortowanie.Sorting
{
	class QuickSortRecursion : ASortingAlgorithm
	{
        public int Pivot { get; set; } = 0;

		public QuickSortRecursion(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}

        public override void Sort(int[] a_oTab)
        {
            Sort(a_oTab, 0, a_oTab.Length - 1);
        }

        Random rnd = new Random();

        private void Sort(int[] a_oTab, int a_iLeft, int a_iRight)
        {
            //inicjalizacja mziennych
            int i = a_iLeft, j = a_iRight;

            //pivot
            int _iPivot = 0;
            switch (Pivot)
			{
                case 0:
                    _iPivot = a_oTab[(a_iLeft + a_iRight) / 2];//środkowy
                    break;
                case 1:
                    _iPivot = a_oTab[a_iRight];//skrajnie prawy
                    break;
                case 2:
                    _iPivot = a_oTab[rnd.Next(a_iLeft, a_iRight + 1)];//losowy
                    break;
			}

            do
            {
                while (a_oTab[i] < _iPivot) i++;
                while (_iPivot < a_oTab[j]) j--;

                if (i <= j)
                {
                    int _iSwap = a_oTab[i];
                    a_oTab[i] = a_oTab[j];
                    a_oTab[j] = _iSwap;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (a_iLeft < j) Sort(a_oTab, a_iLeft, j);
            if (i < a_iRight) Sort(a_oTab, i, a_iRight);
        }
    }
}
