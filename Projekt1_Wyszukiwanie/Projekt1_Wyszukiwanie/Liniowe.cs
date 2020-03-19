using System;
using System.Diagnostics;

namespace Projekt1_Wyszukiwanie
{
	class Liniowe
	{
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

		public void Average(uint[] a_oMatrix, uint a_uSearchingNumber)
		{
			for (uint i = 0; i < a_oMatrix.Length; i++)
			{
				if (a_oMatrix[i] == a_uSearchingNumber)
					return;
			}
		}

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
