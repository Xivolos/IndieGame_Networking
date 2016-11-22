using System;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class Chunk
    {
        private int tileWidth;
        private int tileHeight;
        private Dictionary<IVector2, Tile> tiles = new Dictionary<IVector2,Tile>();

        public Chunk(int pTileWidth = 11, int pTileHeight = 11)
        {
            tileWidth = pTileWidth;
            tileHeight = pTileHeight;

            GenerateTiles();
        }

        /// <summary>
        /// Get the tile at the given location.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <returns></returns>
        public Tile GetTileAt(int pX, int pY)
        {
            return tiles[new IVector2(pX, pY)];
        }
        /// <summary>
        /// Get the tile at the given location.
        /// </summary>
        /// <param name="pPosition"></param>
        /// <returns></returns>
        public Tile GetTileAt(IVector2 pPosition)
        {
            return tiles[pPosition];
        }

        /// <summary>
        /// Generate all the tiles in this chunk.
        /// </summary>
        private void GenerateTiles()
        {
            for (int y = 0; y < tileHeight; y++)
            {
                for (int x = 0; x < tileWidth; x++)
                {
                    tiles.Add(new IVector2(x - tileWidth / 2, y - tileHeight / 2 ), new Tile(0, 5));
                }
            }
        }
    }
}