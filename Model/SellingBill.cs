using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class SellingBill : BillBase
    {
        private uint providerID;

        public uint ProviderID { get => providerID; set => providerID=value; }

        public SellingBill() : base()
        {
            providerID = 0;
        }

        public SellingBill(uint id, uint employeeID, DateTime date, double totalMoney, uint providerID) 
            : base(id, employeeID, date, totalMoney)
        {
            this.providerID = providerID;
        }
    }
}
