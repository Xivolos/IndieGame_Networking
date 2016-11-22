using System;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class MapPlayer
    {
        private Player player;

        private IVector2 tilePosition = IVector2.zero;
        private IVector2 mapPosition = IVector2.zero;
        private int tileWidth;
        private int tileHeight;

        public IVector2 TilePotition { get { return tilePosition; } }
        public IVector2 MapPosition { get { return mapPosition; } }

        public MapPlayer(Player pPlayer)
        {
            player = pPlayer;
        }

        /// <summary>
        /// Move the player to the given chunk and position.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pChunkX"></param>
        /// <param name="pChunkY"></param>
        public void MoveTo(IVector2 pTargetTile, IVector2 pTargetChunk)
        {
            tilePosition = pTargetTile;
            mapPosition = pTargetChunk;
        }
        /// <summary>
        /// Move the player to the given tile.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public void MoveTo(IVector2 pTargetTile)
        {
            tilePosition = pTargetTile;
        }
        /// <summary>
        /// Move the player to the given chunk and position.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pChunkX"></param>
        /// <param name="pChunkY"></param>
        public void MoveTo(int pX, int pY, IVector2 pTargetChunk)
        {
            tilePosition = new IVector2(pX, pY);
            mapPosition = pTargetChunk;
        }
        /// <summary>
        /// Move the player to the given tile.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public void MoveTo(int pX, int pY)
        {
            tilePosition = new IVector2(pX, pY);
        }
    }
}