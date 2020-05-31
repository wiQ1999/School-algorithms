namespace Projekt3_Sortowanie.Sorting
{
	class InsertionSort : ASortingAlgorithm
	{
        public InsertionSort(int[] a_oBaseTab) : base(a_oBaseTab)
        {
        }

        public override void Sort(int[] a_oTab)
        {
            for (uint i = 1; i < a_oTab.Length; i++)
            {
                uint j = i;
                int temp = a_oTab[j];

                while ((j > 0) && (a_oTab[j - 1] > temp))
                {
                    a_oTab[j] = a_oTab[j - 1];
                    j--;
                }

                a_oTab[j] = temp;
            }
        }
    }
}
