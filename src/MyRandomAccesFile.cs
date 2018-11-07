using System;
using System.IO;
using System.Text;

namespace HashingLab.src
{
    public class MyRandomAccesFile
    {
        #region Fields
        // File to read and write from
        private FileStream _RandFile;
        private int _DataOffset;
        #endregion Fields

        #region Constructors
        private MyRandomAccesFile() { }
        public MyRandomAccesFile(string filepath) : this()
        {
            _RandFile = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
        }
        public MyRandomAccesFile(String filepath, int DataOffset, int Length) : this(filepath)
        {
            _DataOffset = DataOffset;
            byte[] blanks = new byte[DataOffset * Length];
            _RandFile.Write(blanks, 0, DataOffset * Length);
        }
        #endregion Constructors

        #region Methods
        // Write read method
        public string RandomRead(int Record)
        {
            string retrieved;

            // Position stream pointer
            int _Record = Record * _DataOffset;
            int NumBytes = ((Record + 1) * _DataOffset) - _Record;
            SeekOrigin Begin = default(SeekOrigin);
            _RandFile.Seek(_Record, Begin);

            // Prepare buffer
            byte[] buffer = new byte[NumBytes];

            // Read and return string
            int bytes = _RandFile.Read(buffer, 0, buffer.Length);
            retrieved = Encoding.ASCII.GetString(buffer, 0, bytes);
            return retrieved.Split('#')[0];
        }

        // Write write method
        public bool RandomWrite(int Record, string obj)
        {
            // Prepare buffer
            byte[] buffer = Encoding.ASCII.GetBytes(obj += "#");

            // Position stream pointer
            int _Record = Record * _DataOffset;
            SeekOrigin Begin = default(SeekOrigin);
            _RandFile.Seek(_Record, Begin);

            // Write to file and flush
            _RandFile.Write(buffer, 0, buffer.Length);
            _RandFile.Flush();
            return false;
        }

        // write method close
        public void Close()
        {
            _RandFile.Flush();
            _RandFile.Close();
        }
    }
    #endregion Methods
}
