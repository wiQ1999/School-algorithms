using System;
using System.Diagnostics;

namespace Projekt1_Wyszukiwanie
{
	class Liniowe
	{
		/// <summary>
		/// Average case of searching an array using critical points
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		/// <param name="_lCriticalPoints">Return value with count of critical points</param>
		public void Average(uint[] a_oMatrix, uint a_uSearchingNumber, out long _lCriticalPoints)
		{
			_lCriticalPoints = 1;
			for (uint i = 0; i < a_oMatrix.Length; i++, _lCriticalPoints++)
			{
				_lCriticalPoints += 2;
				if (a_oMatrix[i] == a_uSearchingNumber)
					return;
			}
		}

		/// <summary>
		/// Average case of searching an array
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		public void Average(uint[] a_oMatrix, uint a_uSearchingNumber)
		{
			for (uint i = 0; i < a_oMatrix.Length; i++)
			{
				if (a_oMatrix[i] == a_uSearchingNumber)
					return;
			}
		}

		/// <summary>
		/// Pessimistic case of searching an array using critical points
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		/// <param name="_lCriticalPoints">Return value with count of critical points</param>
		public void Pessimistic(uint[] a_oMatrix, uint a_uSearchingNumber, out long _lCriticalPoints)
		{
			_lCriticalPoints = 1;
			for (uint i = 0; i < a_oMatrix.Length; i++, _lCriticalPoints++)
			{
				_lCriticalPoints += 2;
				if (a_oMatrix[i] == a_uSearchingNumber)
					return;
			}
		}

		/// <summary>
		/// Pessimistic case of searching an array
		/// </summary>
		/// <param name="a_oMatrix">An array</param>
		/// <param name="a_uSearchingNumber">Number the function is looking for</param>
		public void Pessimistic(uint[] a_oMatrix, uint a_uSearchingNumber)
		{
			for (uint i = 0; i < a_oMatrix.Length; i++)
			{
				if (a_oMatrix[i] == a_uSearchingNumber)
					return;
			}
		}
	}
}
