using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Projekt3_Sortowanie
{
	class SelectionSort : ASortingAlgorithm
	{
		public SelectionSort(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}
		
		public override int[] Sort(int[] a_oTab)
		{
			uint k;
			for (uint i = 0; i < (a_oTab.Length - 1); i++)
			{
				int temp = a_oTab[i];
				k = i;
				for (uint j = i + 1; j < a_oTab.Length; j++)
					if (a_oTab[j] < temp)
					{
						k = j;
						temp = a_oTab[j];
					}

				a_oTab[k] = a_oTab[i];
				a_oTab[i] = temp;
			}

			return a_oTab;
		}
	}
}
