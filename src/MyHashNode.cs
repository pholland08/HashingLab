using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingLab.src
{
    class MyHashNode
    {
        #region Fields{get; set;}
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
        #endregion Fields

        #region Constructors
        ////////////////////////////////////////////////////////////////////
        /// Constructors
        ////////////////////////////////////////////////////////////////////
        // No argument constructor
        internal MyHashNode()
        {
            this.InitialAddress = -1;
            this.CurrentLocation = -1;
            this.ProbeCount = 0;
            this.HashKey = null;
        }

        // Default constructor
        public MyHashNode(string key) : this()
        {
            this.HashKey = key;
            this.InitialAddress = HashFunctions.CalculateHash(key);
        }
        #endregion Constructors

        #region Methods
        // TODO Write method ToString()
        public override string ToString()
        {
            return $"{HashKey}\t{InitialAddress}\t{CurrentLocation}\t{ProbeCount}";
        }
        #endregion Methods
    }
}
