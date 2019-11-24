using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Utils
{
    public class SafeUpdateDictionary<Tkey, TValue> : Dictionary<Tkey, TValue>
    {
        public new TValue this[Tkey index]
        {
            get
            {
                if (this.TryGetValue(index, out TValue val))
                    return val;
                else
                {
                    base.Add(index, default(TValue));
                    return base[index];
                }
            }
            set
            {
                if (this.ContainsKey(index))
                    base[index] = value;
                else
                    base.Add(index, value);
            }
        }
    }
}
