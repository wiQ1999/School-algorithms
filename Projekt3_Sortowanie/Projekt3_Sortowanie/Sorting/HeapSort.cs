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

        public override void Sort(int[] a_oTab)
        {
            uint left = (uint)a_oTab.Length / 2;
            uint right = (uint)a_oTab.Length - 1;
            while (left > 0)
            {
                left--;
                heapify(a_oTab, left, right);
            }

            while (right > 0)
            {
                int buf = a_oTab[left];
                a_oTab[left] = a_oTab[right];
                a_oTab[right] = buf;
                right--;
                heapify(a_oTab, left, right);
            }
        }
    }
}
