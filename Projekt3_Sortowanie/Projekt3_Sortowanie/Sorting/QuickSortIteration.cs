using System;

namespace Projekt3_Sortowanie.Sorting
{
	class QuickSortIteration : ASortingAlgorithm
	{
		public int Pivot { get; set; } = 0;
		public QuickSortIteration(int[] a_oBaseTab) : base(a_oBaseTab)
		{
		}

		Random rnd = new Random();

		public override void Sort(int[] a_oTab)
		{
			//inicjalizacja zmiennych
			int i, j, _iLeft, _iRight, sp = 0;
			int[] _oLeftStack = new int[a_oTab.Length], _oRightStack = new int[a_oTab.Length];
			_oRightStack[sp] = a_oTab.Length - 1;

			do
			{
				//pobieranie żądań podziału
				_iLeft = _oLeftStack[sp];
				_iRight = _oRightStack[sp];
				sp--;

				do
				{
					//pivot
					int _iPivot = 0;
					switch (Pivot)
					{
						case 0:
							_iPivot = a_oTab[(_iLeft + _iRight) / 2];//środkowy
							break;
						case 1:
							_iPivot = a_oTab[_iRight];//skrajnie prawy
							break;
						case 2:
							_iPivot = a_oTab[rnd.Next(_iLeft, _iRight + 1)];//losowy
							break;
					}

					i = _iLeft;
					j = _iRight;

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

					if (i < _iRight)
					{
						sp++;
						_oLeftStack[sp] = i;
						_oRightStack[sp] = _iRight;
					} // ewentualnie dodajemy żądanie podziału

					_iRight = j;
				} while (_iLeft < _iRight);

			} while (sp >= 0); // dopóki stos żądań nie będzie pusty
		}
	}
}
