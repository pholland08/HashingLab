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

        // TODO Write method CalculateHash
        private int _CalculateHash(string key)
        {
            int _address = -1;
            // TODO Add hash algorithm
            return _address;

        }

        // Linear collision handling
        private bool _HandleCollision(MyHashNode CollidedNode)
        {
            CollidedNode.ProbeCount++;
            int _CollisionAddress = CollidedNode.InitialAddress + CollidedNode.ProbeCount;

            // Wrap around to front of table if needed
            if (_CollisionAddress >= _HashTable.Length) { _CollisionAddress -= _HashTable.Length; }

            // Check if arrived at original location
            if (_CollisionAddress == CollidedNode.InitialAddress) { return false; }

            if (_HashTable[_CollisionAddress].HashKey == null)
            {
                // Space is available
                _HashTable[CollidedNode.InitialAddress] = CollidedNode;
                _CurrentCapacity++;
                return true;
            }
            else
            {
                // Another collision has occured
                return _HandleCollision(CollidedNode);
            }
        }

        // TODO Write method Add
        public bool Add(string key)
        {
            MyHashNode NewNode = new MyHashNode(key);
            NewNode.InitialAddress = _CalculateHash(key);
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
                return _HandleCollision(NewNode);
            }

        }
        
        // TODO Write method Delete
        public bool Delete(string key)
        {
            // TODO Write method body
            return false;
        }

        // TODO Write method Find

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
        }

    }
}
