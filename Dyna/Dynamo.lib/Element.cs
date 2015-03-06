using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamo.lib
{
    public class Element
    {
        ElementType elType;

        private static readonly object syncLock = new object();

        public Element()
        {
            lock (syncLock)
            {
                Random rnd = new Random();
                elType = (ElementType)rnd.Next(3);
            }
        }

        public ElementType PickElement()
        {
            return elType;
        }
    }

    public enum ElementType
    {
        Fire = 0,
        Water,
        Wind
    }
}
