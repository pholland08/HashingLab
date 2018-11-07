using System;

namespace HashingLab.src
{
    class HashFunctions
    {
        // Write method CalculateHash
        public static int CalculateHash(string key, string algorithm, int PrimeTS)
        {
            // Instantiate return value
            int _address = 1;

            // Perform given hash algorithm
            switch (algorithm)
            {
                case "burris":
                    {
                        char[] _KeyChars = key.ToCharArray();
                        int first = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[0], (int)_KeyChars[1]));
                        int second = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[5], (int)_KeyChars[6]));
                        _address = (((first + second) * 256) + (int)_KeyChars[12]) % 128;
                        break;
                    }
                default:
                    {
                        char[] _KeyChars = key.ToCharArray();

                        int first = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[1] + 2, (int)_KeyChars[2] + 3));
                        int second = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[5] + 6, (int)_KeyChars[6] + 7));
                        int third = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[1] + 2, (int)_KeyChars[6] + 7));
                        int fourth = Convert.ToInt32(string.Format("{0}{1}", (int)_KeyChars[5] + 6, (int)_KeyChars[2] + 3));

                        _address = Math.Abs((first ^ second) + (third ^ fourth));

                        foreach (char k in _KeyChars)
                        {
                            _address = ((_address * 2) + (int)k) % PrimeTS;
                        }
                        break;
                    }
            }
            return _address;
        }
    }
}
