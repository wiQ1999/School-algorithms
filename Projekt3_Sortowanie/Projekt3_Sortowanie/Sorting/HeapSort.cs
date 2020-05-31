using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt3_Sortowanie.Sorting
{
	class HeapSort : ASortingAlgorithm
	{
		public HeapSort(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}

        private void heapify(int[] t, uint left, uint right)
        {
            uint i = left, j = 2 * i + 1;
            int buf = t[i];

            while (j <= right)
            {
                if (j < right)
                    if (t[j] < t[j + 1])
                        j++;
                if (buf >= t[j]) break;

                t[i] = t[j];
                i = j;
                j = 2 * i + 1;
            }

            t[i] = buf;
        }

        public override void Sort(int[] tab)
        {
            uint left = (uint)tab.Length / 2;
            uint right = (uint)tab.Length - 1;
            while (left > 0)
            {
                left--;
                heapify(tab, left, right);
            }

            while (right > 0)
            {
                int buf = tab[left];
                tab[left] = tab[right];
                tab[right] = buf;
                right--;
                heapify(tab, left, right);
            }
        }
    }
}
