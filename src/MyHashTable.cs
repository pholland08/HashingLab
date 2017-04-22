using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingLab.src
{
    class MyHashTable
    {
        // TODO Create HashTable structure
        private MyHashNode[] _HashTable;
        private int _CurrentCapacity;
        public int CurrentCapacity
        {
            get { return _CurrentCapacity; }

        }

        // HashTable constructors
        private MyHashTable() { _CurrentCapacity = 0; }
        public MyHashTable(int Length) : this()
        {
            _HashTable = new MyHashNode[Length];
        }

        // Linear collision handling
        private bool _HandleCollision(ref MyHashNode CollidedNode)
        {
            CollidedNode.ProbeCount += 1;
            int _CollisionAddress = CollidedNode.InitialAddress + CollidedNode.ProbeCount;

            // Wrap around to front of table if needed
            if (_CollisionAddress >= _HashTable.Length) { _CollisionAddress -= _HashTable.Length; }

            // If wrapped around to original location
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
                // Another collision has occured
                return _HandleCollision(ref CollidedNode);
            }
        }

        // TODO Write method Add
        public bool Add(string key)
        {
            MyHashNode NewNode = new MyHashNode(key);
            NewNode.ProbeCount++;

            if (_HashTable[NewNode.InitialAddress].HashKey == null)
            {
                _HashTable[NewNode.InitialAddress] = NewNode;
                _CurrentCapacity++;
                return true;
            }
            else
            {
                // Collision has occured
                bool Result = _HandleCollision(ref NewNode);
                if (Result)
                {
                    // Empty space was found
                    _HashTable[NewNode.InitialAddress] = NewNode;
                    _CurrentCapacity++;
                    return true;
                }
                else
                {
                    // Table was full
                    return false;
                }
            }

        }

        // TODO Write method Delete
        public bool Delete(string key)
        {
            // TODO Write method body
            return false;
        }

        // TODO Write method Find
        public int Find(string Key)
        {
            MyHashNode NewNode = new MyHashNode(Key);
            NewNode.ProbeCount++;

            if (_HashTable[NewNode.InitialAddress].HashKey == Key)
            {
                return NewNode.InitialAddress;
            }
            else
            {
                // Begin search
                int _SearchAddress = NewNode.InitialAddress + NewNode.ProbeCount;
                int _FoundAt = -1;

                // While current comparison is initialized but isn't the InitialAddress
                while (_HashTable[_SearchAddress] != null || _SearchAddress != NewNode.InitialAddress)
                {
                    if (_SearchAddress >= _HashTable.Length) { _SearchAddress -= _HashTable.Length; }

                    if (_HashTable[_SearchAddress].HashKey == Key)
                    {
                        // Key found at different address
                        _FoundAt = _SearchAddress;
                        return _FoundAt;
                    }
                    else
                    {
                        // Compare next key
                        NewNode.ProbeCount++;
                    }
                }
                // Key not found in table
                return _FoundAt;

            }
        }

    }

    // TODO Create HashNode class
    class MyHashNode
    {
        // TODO Declare field: HashKey
        private string _HashKey;
        public string HashKey
        {
            get { return _HashKey; }
            set { _HashKey = value; }
        }

        // TODO Declare field: InitialAddress
        private int _InitialAddress;
        public int InitialAddress
        {
            get { return _InitialAddress; }
            set { _InitialAddress = value; }
        }

        // TODO Declare field: CurrentLocation
        private int _CurrentLocation;
        public int CurrentLocation
        {
            get { return _CurrentLocation; }
            set { _CurrentLocation = value; }
        }

        // TODO Declare field: ProbeCount
        private int _ProbeCount;
        public int ProbeCount
        {
            get { return _ProbeCount; }
            set { _ProbeCount = value; }
        }

        // TODO Write HashNode constructor
        // No argument constructor
        private MyHashNode()
        {
            this.InitialAddress = -1;
            this.ProbeCount = 0;
            this.HashKey = null;
        }
        // Default constructor
        public MyHashNode(string key) : this()
        {
            this.HashKey = key;
            this.InitialAddress = HashFunctions.CalculateHash(key);
        }

    }

    class HashFunctions
    {
        // TODO Write method CalculateHash
        public static int CalculateHash(string key)
        {
            int _address = -1;
            // TODO Add body of algorithm
            return _address;

        }
    }
}
