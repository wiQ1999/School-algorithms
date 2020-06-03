using System.Reflection.Metadata.Ecma335;

namespace Projekt3_Sortowanie.Sorting
{
	class CocktailSort : ASortingAlgorithm
	{
		public CocktailSort(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}

        public override void Sort(int[] a_oTab)
        {
            int _iLeft = 1, _iRight = a_oTab.Length - 1, k = _iRight;

            do
            {
                for (int j = _iRight; j >= _iLeft; j--)
                    if (a_oTab[j - 1] > a_oTab[j])
                    {
                        int temp = a_oTab[j - 1];
                        a_oTab[j - 1] = a_oTab[j];
                        a_oTab[j] = temp;
                        k = j;
                    }

                _iLeft = k + 1;

                for (int j = _iLeft; j <= _iRight; j++)
                    if (a_oTab[j - 1] > a_oTab[j])
                    {
                        int temp = a_oTab[j - 1];
                        a_oTab[j - 1] = a_oTab[j];
                        a_oTab[j] = temp;
                        k = j;
                    }

                _iRight = k - 1;
            } while (_iLeft <= _iRight);
        }
    }
}
