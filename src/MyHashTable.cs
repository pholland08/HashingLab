using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingLab.src
{
    class MyHashTable
    {
        #region Fields
        private MyHashNode[] _HashTable;
        private int _CurrentCapacity;
        public int CurrentCapacity
        {
            get { return _CurrentCapacity; }

        }
        public int Length;
        #endregion Fields

        #region Constructors
        // HashTable constructors
        private MyHashTable() { _CurrentCapacity = 0; }
        public MyHashTable(int Length) : this()
        {
            _HashTable = new MyHashNode[Length];
            this.Length = Length;
            for (int node = 0; node < _HashTable.Length; node++)
            {
                _HashTable[node] = new MyHashNode();
            }
        }
        #endregion Constructors

        #region Methods
        // Linear collision handling
        private bool _HandleCollision(ref MyHashNode CollidedNode)
        {
            int _CollisionAddress = CollidedNode.InitialAddress + CollidedNode.ProbeCount;
            CollidedNode.ProbeCount += 1;

            // Wrap around to front of table if needed
            if (!(_CollisionAddress < _HashTable.Length)) { _CollisionAddress -= _HashTable.Length; }

            // If wrapped around to original location, return false
            if (_CollisionAddress == CollidedNode.InitialAddress)
            {
                CollidedNode.CurrentLocation = -1;
                return false;
            }

            if (_HashTable[_CollisionAddress].HashKey == null)
            {
                // Space is available
                CollidedNode.CurrentLocation = _CollisionAddress;
                return true;
            }
            else
            {
                // Recursion
                // Another collision has occured
                return _HandleCollision(ref CollidedNode);
            }
        }

        // TODO Write method Add
        public bool Add(string key)
        {
            MyHashNode NewNode = new MyHashNode(key);
            NewNode.ProbeCount++;

            if (_HashTable[NewNode.InitialAddress].HashKey == null || _HashTable[NewNode.InitialAddress].HashKey == NewNode.HashKey)
            {
                NewNode.CurrentLocation = NewNode.InitialAddress;
                _HashTable[NewNode.CurrentLocation] = NewNode;
                _CurrentCapacity++;
                return true;
            }
            else
            {
                // Collision has occured
                do
                {
                    bool Result = _HandleCollision(ref NewNode);
                    if (Result)
                    {
                        // Empty space was found
                        _HashTable[NewNode.CurrentLocation] = NewNode;
                        _CurrentCapacity++;
                        return true;
                    }
                } while (NewNode.ProbeCount < _HashTable.Length);

                // Table was full
                return false;

            }

        }

        // TODO Write method Delete
        public bool Delete(string Key)
        {
            // TODO Write method body
            int KeyAddress = Get(Key).InitialAddress;
            if (KeyAddress > -1)
            {
                // Reset Address.HashKey, but keep keep other fields to indicate table location has already been used.
                _HashTable[KeyAddress].HashKey = null;
                return true;
            }
            return false;
        }

        // Search HashTable for location of key, returns -1 if not found.
        public MyHashNode Get(string Key)
        {
            MyHashNode NewNode = new MyHashNode(Key);
            NewNode.ProbeCount++;

            if (_HashTable[NewNode.InitialAddress].HashKey == Key)
            {
                NewNode.CurrentLocation = NewNode.InitialAddress;
                return NewNode;
            }
            else
            {
                // Begin search
                int _SearchAddress;
                // While current comparison is initialized but isn't the InitialAddress
                do
                {
                    _SearchAddress = NewNode.InitialAddress + NewNode.ProbeCount;
                    if (_SearchAddress >= _HashTable.Length) { _SearchAddress -= _HashTable.Length; }

                    if (_HashTable[_SearchAddress].HashKey == Key)
                    {
                        // Key found at different address
                        return _HashTable[_SearchAddress];
                    }
                    else
                    {
                        // Compare next key
                        NewNode.ProbeCount++;
                    }
                } while (_HashTable[_SearchAddress] != null || _SearchAddress != NewNode.InitialAddress);
                // Key not found in table
                return new MyHashNode();

            }
        }

        // TODO Write method ToString
        // TODO Document method
        public override string ToString()
        {
            String contents = "";
            foreach(MyHashNode node in _HashTable)
            {
                contents += $"{node.ToString()}\n";
            }
            return contents;
        }
        #endregion Methods
    }

    class HashFunctions
    {
        // TODO Write method CalculateHash
        public static int CalculateHash(string key)
        {
            int _address = -1;
            char[] _KeyChars = key.ToCharArray();
            int first = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[0], (int)_KeyChars[1]));
            int second = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[5], (int)_KeyChars[6]));
            // TODO Add body of algorithm
            _address = (((first + second) * 256) + (int)_KeyChars[12]) % 128;
            //_address = (((first + second) * 257) + ((int)_KeyChars[0]) - (int)_KeyChars[1]) % 127;

            return _address;

        }
    }
}


// TODO Look into passing functions as parameter