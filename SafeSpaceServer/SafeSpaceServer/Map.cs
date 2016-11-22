using System;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class Map
    {
        // The amount of tiles per chunk
        private const int tileWidth = 11; 
        private const int tileHeight = 11;
        private int generateRadius;
        private Dictionary<IVector2, Chunk> chunks = new Dictionary<IVector2,Chunk>();

        private IVector2 baseChunk = new IVector2(0, 0);
        private IVector2 baseTile = new IVector2(0, 0);

        public Map(IVector2 pPosition, int pGenerateRadius = 2)
        {
            generateRadius = pGenerateRadius;
            GenerateChunks(pPosition ?? IVector2.zero);
        }

        /// <summary>
        /// Generate all the chunks in a radius around the given position.
        /// </summary>
        /// <param name="pPosition"></param>
        private void GenerateChunks(IVector2 pPosition)
        {
            for (int x = -generateRadius; x <= generateRadius; x++)
            {
                for (int y = -generateRadius; y <= generateRadius; y++)
                {
                    if (!IsGenerated(pPosition.Clone().Add(new IVector2(x, y))))
                    {
                        chunks.Add(new IVector2(x, y), new Chunk(tileWidth, tileHeight));
                    }
                }
            }
        }

        /// <summary>
        /// return true if the given chunk is generated.
        /// </summary>
        /// <param name="pPosition"></param>
        /// <returns></returns>
        public bool IsGenerated(IVector2 pPosition)
        {
            return chunks.ContainsKey(pPosition);
        }

        /// <summary>
        /// Get the chunk at the given position.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <returns></returns>
        public Chunk GetChunkAt(int pX, int pY)
        {
            return chunks[new IVector2(pX, pY)];
        }
        /// <summary>
        /// Get the chunk at the given position.
        /// </summary>
        /// <param name="pPosition"></param>
        /// <returns></returns>
        public Chunk GetChunkAt(IVector2 pPosition)
        {
            return chunks[pPosition];
        }
    }
}
