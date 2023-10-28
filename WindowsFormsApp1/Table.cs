using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Table
    {
        private Dictionary<int, int[]> _tableCoordinates;
        private int _boardCellsCount = 64;
        private int _startCoordinateX = 5;
        private int _startCoordinateY = 5;
        private int _cellSize = 44;
        private int _boardCellsSideCount = 8;

        public Table()
        {
            _tableCoordinates = new Dictionary<int, int[]>();
            int[] coordinates;
            int indexCount = 0;

            for (int i = 0; i < _boardCellsSideCount; i++)
            {
                for (int j = 0; j < _boardCellsSideCount; j++)
                {
                    coordinates = new int[] { (_startCoordinateX + _cellSize * i), (_startCoordinateY + _cellSize * j) };
                    Console.WriteLine(i + " " + coordinates[0] + " " + coordinates[1]);
                    AddCoordinates(indexCount, coordinates);
                    indexCount++;
                }
            }
        }

        public void AddCoordinates(int index, int[] coordinates)
        {
            _tableCoordinates.Add(index, coordinates);
        }

        public void RemoveAllObjects()
        {
            
        }

        public int[] GetCoordinates(int index)
        {
            foreach (var item in _tableCoordinates)
            {
                if(item.Key == index)
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}
