using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrumpiesHandsOnLabs.Domain
{
    public class SalesTrnx
    {
        public virtual int Id { get; set; }
        public virtual DateTime TrnxTime { get; set; }
        public virtual int TrnxStatus { get; set; }
        public virtual Amount Amount { get; set; }
    }

    public class Amount
    {
        public virtual double Volume { get; set; }
        public virtual int CurrencyCode { get; set; }
    }
}
