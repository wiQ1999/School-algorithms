using Projekt3_Sortowanie.Tables;
using System;
using System.Net.NetworkInformation;

namespace Projekt3_Sortowanie
{
	class Program
	{
		static void Main(string[] args)
		{
			//GrowingTable growingTable = new GrowingTable();

			//int[] _oGrowingBaseTable = growingTable.GenerateTab(200);

			//DecreasingTable decreasingTable = new DecreasingTable();

			//int[] _oDecreasingBaseTable = decreasingTable.GenerateTab(200);

			//int[] _oConstantBaseTable = new int[200];

			//RandomTable randomTable = new RandomTable();

			//int[] _oRandomBaseTable = randomTable.GenerateTab(200);

			VTable vTable = new VTable();

			int[] _oVBaseTable = vTable.GenerateTab(200);

			SelectionSort selectionSort = new SelectionSort(_oVBaseTable);

			Console.WriteLine("SelectionSort - Tablica malejąca - bazowa");
			selectionSort.DisplayTab();

			selectionSort.MeasureSortTime(50);

			selectionSort.MeasureSortTime(100);
		}
	}
}
