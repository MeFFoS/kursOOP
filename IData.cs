using System;
using System.Collections.Generic;
using System.Text;

namespace kursOOP
{
    interface IData
    {
        void Save();
        void Add();
        static void Print() => throw new NotImplementedException();
    }
}
