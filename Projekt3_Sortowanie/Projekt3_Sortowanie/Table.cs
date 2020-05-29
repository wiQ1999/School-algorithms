using System;

namespace Projekt3_Sortowanie
{
	abstract class Table
	{
		public int[] Tab { get; set; }

		public Table(int[] a_oBaseTab)
		{
			Tab = a_oBaseTab;
		}

		/// <summary>
		/// Print base table on the console
		/// </summary>
		public void DisplayTab()
		{
			//ptla po liczbach w bazowej tablicy
			foreach (int number in Tab)
			{
				//wyświetlanie liczby
				Console.Write(number + ", ");
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Print table on the console
		/// </summary>
		/// <param name="a_oTab">Table to be printed</param>
		public void DisplayTab(int[] a_oTab)
		{
			//ptla po liczbach w podanej tablicy
			foreach (int number in a_oTab)
			{
				//wyświetlanie liczby
				Console.Write(number + ", ");
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Create a new resize table
		/// </summary>
		/// <param name="a_iNewSize">Smaller size than size of base table</param>
		/// <returns>Returns table with new size with the same number as base table</returns>
		public int[] Resize(int a_iNewSize)
		{
			//inicjalizacja nowej tablicy o mniejszym rozmiarze
			int[] _oReturn = new int[a_iNewSize];

			//wskazanie indeksu początkowego dla wycinania środkowej częsci bazowej tablicy 
			int _iIndexPlace = (Tab.Length / 2) - (a_iNewSize / 2);

			//przepisanie wartości ze starej tablicy do nowej
			for (int i = 0; i < a_iNewSize; i++)
			{
				_oReturn[i] = Tab[i + _iIndexPlace];
			}

			//zwracanie nowej tablicy
			return _oReturn;
		}
	}
}
