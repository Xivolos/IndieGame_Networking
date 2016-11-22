using System;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class Resource
    {
        public struct Loot
        {
            private Resources resource;
            private int amount;

            public Resources Resource {
                get { return resource; }
                set { resource = value; }
            }
            public int Amount {
                get { return amount; }
                set { amount = value; }
            }

            public Loot(Resources pResource, int pAmount)
            {
                resource = pResource;
                amount = pAmount;
            }

            public override string ToString()
            {
                return "You found " + amount + " " + resource + "!";
            }
        }

        public enum Resources
        {
            metal,
            circuits
        }
    }
}
