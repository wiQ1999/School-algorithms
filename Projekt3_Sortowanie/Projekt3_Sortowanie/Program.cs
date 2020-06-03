using Projekt3_Sortowanie.Sorting;
using Projekt3_Sortowanie.Tables;
using System;

namespace Projekt3_Sortowanie
{
	class Program
	{
		/// <summary>
		/// Constant size of all base tables
		/// </summary>
		const int g_iBaseTabSize = 200_000;

		#region MainMethods

		static void GrowingTableTest()
		{
			//tworzenie tablicy bazowej
			GrowingTable growingTable = new GrowingTable();
			int[] _oBaseTable = growingTable.GenerateTab(g_iBaseTabSize);

			//tworzenie obiektów sortujących
			SelectionSort selectionSort = new SelectionSort(_oBaseTable);
			InsertionSort insertionSort = new InsertionSort(_oBaseTable);
			CocktailSort cocktailSort = new CocktailSort(_oBaseTable);
			HeapSort heapSort = new HeapSort(_oBaseTable);

			//pętla po typach algoryutmów sortujących
			for (int type = 0; type < 4; type++)
			{
				//wypisanie informacji dla każdego typu algorytmu
				switch (type)
				{
					case 0:
						Console.WriteLine("SelectionSort");
						break;
					case 1:
						Console.WriteLine("InsertionSort");
						break;
					case 2:
						Console.WriteLine("CocktailSort");
						break;
					case 3:
						Console.WriteLine("HeapSort");
						break;
				}

				//główna pętla wielkości sortowanych tablic
				for (int i = 50_000; i <= g_iBaseTabSize; i += 5_000)
				{
					//określa który algorytm ma sortować
					switch (type)
					{
						case 0:
							selectionSort.MeasureSortTime(i);
							break;
						case 1:
							insertionSort.MeasureSortTime(i);
							break;
						case 2:
							cocktailSort.MeasureSortTime(i);
							break;
						case 3:
							heapSort.MeasureSortTime(i);
							break;
					}		
				}
			}
		}

		static void DecreasingTableTest()
		{
			//tworzenie tablicy bazowej
			DecreasingTable decreasingTable = new DecreasingTable();
			int[] _oBaseTable = decreasingTable.GenerateTab(g_iBaseTabSize);

			//tworzenie obiektów sortujących
			SelectionSort selectionSort = new SelectionSort(_oBaseTable);
			InsertionSort insertionSort = new InsertionSort(_oBaseTable);
			CocktailSort cocktailSort = new CocktailSort(_oBaseTable);
			HeapSort heapSort = new HeapSort(_oBaseTable);

			//pętla po typach algoryutmów sortujących
			for (int type = 0; type < 4; type++)
			{
				//wypisanie informacji dla każdego typu algorytmu
				switch (type)
				{
					case 0:
						Console.WriteLine("SelectionSort");
						break;
					case 1:
						Console.WriteLine("InsertionSort");
						break;
					case 2:
						Console.WriteLine("CocktailSort");
						break;
					case 3:
						Console.WriteLine("HeapSort");
						break;
				}

				//główna pętla wielkości sortowanych tablic
				for (int i = 50_000; i < g_iBaseTabSize; i += 5_000)
				{
					//określa który algorytm ma sortować
					switch (type)
					{
						case 0:
							selectionSort.MeasureSortTime(i);
							break;
						case 1:
							insertionSort.MeasureSortTime(i);
							break;
						case 2:
							cocktailSort.MeasureSortTime(i);
							break;
						case 3:
							heapSort.MeasureSortTime(i);
							break;
					}
				}
			}
		}

		static void ConstantTableTest()
		{
			//tworzenie tablicy bazowej - wypełninonej zerami
			int[] _oBaseTable = new int[g_iBaseTabSize];

			//tworzenie obiektów sortujących
			SelectionSort selectionSort = new SelectionSort(_oBaseTable);
			InsertionSort insertionSort = new InsertionSort(_oBaseTable);
			CocktailSort cocktailSort = new CocktailSort(_oBaseTable);
			HeapSort heapSort = new HeapSort(_oBaseTable);

			//pętla po typach algoryutmów sortujących
			for (int type = 0; type < 4; type++)
			{
				//wypisanie informacji dla każdego typu algorytmu
				switch (type)
				{
					case 0:
						Console.WriteLine("SelectionSort");
						break;
					case 1:
						Console.WriteLine("InsertionSort");
						break;
					case 2:
						Console.WriteLine("CocktailSort");
						break;
					case 3:
						Console.WriteLine("HeapSort");
						break;
				}

				//główna pętla wielkości sortowanych tablic
				for (int i = 50_000; i < g_iBaseTabSize; i += 5_000)
				{
					//określa który algorytm ma sortować
					switch (type)
					{
						case 0:
							selectionSort.MeasureSortTime(i);
							break;
						case 1:
							insertionSort.MeasureSortTime(i);
							break;
						case 2:
							cocktailSort.MeasureSortTime(i);
							break;
						case 3:
							heapSort.MeasureSortTime(i);
							break;
					}
				}
			}
		}

		static void RandomTableTest()
		{
			//tworzenie tablicy bazowej
			RandomTable randomTable = new RandomTable();
			int[] _oBaseTable = randomTable.GenerateTab(g_iBaseTabSize);

			//tworzenie obiektów sortujących
			SelectionSort selectionSort = new SelectionSort(_oBaseTable);
			InsertionSort insertionSort = new InsertionSort(_oBaseTable);
			CocktailSort cocktailSort = new CocktailSort(_oBaseTable);
			HeapSort heapSort = new HeapSort(_oBaseTable);

			//pętla po typach algoryutmów sortujących
			for (int type = 0; type < 4; type++)
			{
				//wypisanie informacji dla każdego typu algorytmu
				switch (type)
				{
					case 0:
						Console.WriteLine("SelectionSort");
						break;
					case 1:
						Console.WriteLine("InsertionSort");
						break;
					case 2:
						Console.WriteLine("CocktailSort");
						break;
					case 3:
						Console.WriteLine("HeapSort");
						break;
				}

				//główna pętla wielkości sortowanych tablic
				for (int i = 50_000; i < g_iBaseTabSize; i += 5_000)
				{
					//określa który algorytm ma sortować
					switch (type)
					{
						case 0:
							selectionSort.MeasureSortTime(i);
							break;
						case 1:
							insertionSort.MeasureSortTime(i);
							break;
						case 2:
							cocktailSort.MeasureSortTime(i);
							break;
						case 3:
							heapSort.MeasureSortTime(i);
							break;
					}
				}
			}
		}

		static void VTableTest()
		{
			//tworzenie tablicy bazowej
			VTable vTable = new VTable();
			int[] _oBaseTable = vTable.GenerateTab(g_iBaseTabSize);

			//tworzenie obiektów sortujących
			SelectionSort selectionSort = new SelectionSort(_oBaseTable);
			InsertionSort insertionSort = new InsertionSort(_oBaseTable);
			CocktailSort cocktailSort = new CocktailSort(_oBaseTable);
			HeapSort heapSort = new HeapSort(_oBaseTable);

			//pętla po typach algoryutmów sortujących
			for (int type = 0; type < 4; type++)
			{
				//wypisanie informacji dla każdego typu algorytmu
				switch (type)
				{
					case 0:
						Console.WriteLine("SelectionSort");
						break;
					case 1:
						Console.WriteLine("InsertionSort");
						break;
					case 2:
						Console.WriteLine("CocktailSort");
						break;
					case 3:
						Console.WriteLine("HeapSort");
						break;
				}

				//główna pętla wielkości sortowanych tablic
				for (int i = 50_000; i < g_iBaseTabSize; i += 5_000)
				{
					//określa który algorytm ma sortować
					switch (type)
					{
						case 0:
							selectionSort.MeasureSortTime(i);
							break;
						case 1:
							insertionSort.MeasureSortTime(i);
							break;
						case 2:
							cocktailSort.MeasureSortTime(i);
							break;
						case 3:
							heapSort.MeasureSortTime(i);
							break;
					}
				}
			}
		}

		#endregion

		static void Main(string[] args)
		{
			GrowingTableTest();
			
			DecreasingTableTest();

			ConstantTableTest();

			RandomTableTest();

			VTableTest();
		}
	}
}
