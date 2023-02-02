using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Grid
    {
        private readonly int[,] grid;

        public int row { get; }

        public int col { get; }

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public Grid(int row, int col)
        {
            this.row = row;
            this.col = col;
            grid = new int[row, col];
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < this.row && c >= 0 && c < this.col;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsFull(int r)
        {
            for (int c = 0; c < this.col; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsEmpty(int r)
        {
            for (int c = 0; c < this.col; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < this.col; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRow(int r, int numRow)
        {
            for (int c = 0; c < this.col; c++)
            {
                grid[r + numRow, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = this.row-1; r >= 0; r--)
            {
                if (IsFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRow(r, cleared);
                }
            }
            return cleared;
        }
    }
}
