using System;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class Tile
    {
        private States state = States.unsearched;
        private enum States
        {
            unsearched,
            searched
        }

        private static Random random = new Random();
        private int minValue = 0;
        private int maxValue = 5;

        private int circuits = 0;
        private int metal = 0;

        public Tile(int pMinValue, int pMaxValue)
        {
            minValue = pMinValue;
            maxValue = pMaxValue;

            /*for (int i = 0; i < 500; i++)
            {
                Resource.Loot loot;
                if (Search(out loot))
                {
                    if (loot.Resource == Resource.Resources.metal) metal++;
                    else circuits++;
                }
            }

            Console.WriteLine(metal);
            Console.WriteLine(circuits);*/
        }

        /// <summary>
        /// Returns a certain amount of loot found on this tile.
        /// </summary>
        /// <param name="loot"></param>
        /// <returns></returns>
        public bool Search(out Resource.Loot loot)
        {
            state = States.searched;
            loot = new Resource.Loot(0, 0);
            int amount = random.Next(minValue, maxValue + 1);
            if (amount == 0) return false;
            loot.Amount = amount;

            Array enumValues = Enum.GetValues(typeof(Resource.Resources));
            Resource.Resources resource = (Resource.Resources) enumValues.GetValue(random.Next(0, enumValues.Length * 10)/10);
            loot.Resource = resource;
            return true;
        }

        /// <summary>
        /// Returns wether this tile has been searched
        /// </summary>
        /// <returns></returns>
        public bool IsSearched()
        {
            return state == States.searched;
        }
    }
}
