using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class Player
    {
        //Networking variables
        private bool connected = false;
        private TcpClient client;

        //Non-networking variables
        private int inventorySpace;
        private Dictionary<Resource.Resources, int> inventory;

        private float maxFood;
        private float food;

        private float maxEnergy;
        private float energy;

        private MapPlayer mapPlayer;

        public int InventorySpace { get { return inventorySpace; } }
        public float Food { get { return food; } }
        public float Energy { get { return energy; } }
        public float MaxEnergy { get { return maxEnergy; } }
        public MapPlayer MapPlayer { get { return mapPlayer; } }

        /// <summary>
        /// returns the amount that the player has of a certain resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int GetInventoryAmount(Resource.Resources resource)
        {
            if (inventory.ContainsKey(resource)) return inventory[resource];
            return 0;
        }

        /// <summary>
        /// Returns the amount of unused inventory space.
        /// </summary>
        /// <returns></returns>
        public int GetInventorySpaceLeft()
        {
            int inventoryUsed = 0;
            foreach (Resource.Resources resource in inventory.Keys)
            {
                inventoryUsed += inventory[resource];
            }
            return inventorySpace - inventoryUsed;
        }

        /// <summary>
        /// Add resources to the player inventory.
        /// </summary>
        /// <param name="pResource"></param>
        /// <param name="pAmount"></param>
        public void AddItem(Resource.Resources pResource, int pAmount)
        {
            if (inventory.ContainsKey(pResource)) inventory[pResource] += pAmount;
            else inventory.Add(pResource, pAmount);
        }
        /// <summary>
        /// Add resources the the player inventory.
        /// </summary>
        /// <param name="pLoot"></param>
        public void AddItem(Resource.Loot pLoot)
        {
            AddItem(pLoot.Resource, pLoot.Amount);
        }

        /// <summary>
        /// Remove a given amount of a resource from the inventory.
        /// </summary>
        /// <param name="pResource"></param>
        /// <param name="pAmount"></param>
        public void RemoveItem(Resource.Resources pResource, int pAmount)
        {
            if (inventory.ContainsKey(pResource))
            {
                if (inventory[pResource] <= pAmount) inventory.Remove(pResource);
                else inventory[pResource] -= pAmount;
            }
        }
        /// <summary>
        /// Remove a given amount of a resource from the inventory.
        /// </summary>
        /// <param name="?"></param>
        public void RemoveItem(Resource.Loot pLoot)
        {
            RemoveItem(pLoot.Resource, pLoot.Amount);
        }

        /// <summary>
        /// Add food to the players food stat.
        /// </summary>
        /// <param name="pAmount"></param>
        public void AddFood(float pAmount)
        {
            food += pAmount;
            if (food > maxFood) food = maxFood;
        }

        /// <summary>
        /// Add energy to the players energy stat.
        /// </summary>
        /// <param name="pAmount"></param>
        public void AddEnergy(float pAmount)
        {
            energy += pAmount;
            if (energy > maxEnergy) energy = maxEnergy;
        }

        public Player(float pMaxEnergy, float pMaxFood, int pInventorySpace, TcpClient pClient)
        {
            maxEnergy = pMaxEnergy;
            maxFood = pMaxFood;
            inventorySpace = pInventorySpace;

            energy = maxEnergy;
            food = maxFood;

            mapPlayer = new MapPlayer(this);

            client = pClient;
        }

        public void Communicate()
        {
            connected = true;
            NetworkStream stream = client.GetStream();
            Console.WriteLine("A new client has connected!");

            while (connected)
            {

            }
        }
    }
}
