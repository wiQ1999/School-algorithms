using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt1_Wyszukiwanie
{
	class Binarne
	{
		public uint Pessimistic(uint[] a_oMatrix, uint a_uSearchingNumber, out long _lCriticalPoints)
		{
			uint _uLeft = 0;
			uint _uRight = (uint)(a_oMatrix.Length - 1);

			_lCriticalPoints = 2;

			while (_uLeft <= _uRight)
			{
				_lCriticalPoints++;

				uint _uCenter = (_uLeft + _uRight) / 2;
				_lCriticalPoints += 3;

				if (a_oMatrix[_uCenter] == a_uSearchingNumber)
				{
					_lCriticalPoints++;
					return a_uSearchingNumber;
				}
				else if (a_oMatrix[_uCenter] > a_uSearchingNumber)
				{
					_lCriticalPoints += 2;
					_uRight = _uCenter - 1;
					_lCriticalPoints += 2;
				}
				else
				{
					_lCriticalPoints += 3;
					_uLeft = _uCenter + 1;
					_lCriticalPoints += 2;
				}
			}

			return 0;
		}

		public uint Pessimistic(uint[] a_oMatrix, uint a_uSearchingNumber)
		{
			uint _uLeft = 0;
			uint _uRight = (uint)(a_oMatrix.Length - 1);

			while (_uLeft <= _uRight)
			{
				uint _uCenter = (_uLeft + _uRight) / 2;

				if (a_oMatrix[_uCenter] == a_uSearchingNumber)
					return a_uSearchingNumber;
				else if (a_oMatrix[_uCenter] > a_uSearchingNumber)
					_uRight = _uCenter - 1;
				else
					_uLeft = _uCenter + 1;
			}

			return 0;
		}
	}
}
