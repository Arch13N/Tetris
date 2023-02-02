using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position [][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int ID { get; }

        private int rotation;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.row, StartOffset.col);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotation])
            {
                yield return new Position(p.row + offset.row, p.col + offset.col);
            }
        }

        public void RotateCW()
        {
            rotation = (rotation + 1) % Tiles.Length;
        }

        public void RotationCCW()
        {
            if (rotation == 0)
            {
                rotation = Tiles.Length - 1;
            }
            else
            {
                rotation--;
            }
        }

        public void Move(int row, int col)
        {
            offset.row += row;
            offset.col += col;
        }
        
        public void Reset()
        {
            rotation = 0;
            offset.row = StartOffset.row;
            offset.col = StartOffset.col;
        }
    }
}
