using System;
using System.Collections.Generic;

namespace SafeSpaceServer
{
    class IVector2
    {
        private int _x;
        private int _z;

        public IVector2(int pX, int pY)
        {
            _x = pX;
            _z = pY;
        }
        
        public static IVector2 zero { get { return new IVector2(0, 0); } }

        public int x {
            get { return _x; }
            set { _x = value; }
        }
        public int z {
            get { return _z; }
            set { _z = value; }
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ _z.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var other = obj as IVector2;
            if (other == null)
                return false;

            return _x == other.x && _z == other.z;
        }

        public IVector2 Clone()
        {
            return new IVector2(_x, _z);
        }

        public IVector2 Add(IVector2 pVec)
        {
            _x += pVec.x;
            _z += pVec.z;
            return this;
        }
        public IVector2 Add(int pX, int pY)
        {
            _x += pX;
            _z += pY;
            return this;
        }

        public IVector2 Subtract(IVector2 pVec)
        {
            _x -= pVec.x;
            _z -= pVec.z;
            return this;
        }
        public IVector2 Subtract(int pX, int pY)
        {
            _x -= pX;
            _z -= pY;
            return this;
        }

        public override string ToString()
        {
            return "(" + _x + " , " + _z + ")";
        }
    }
}
