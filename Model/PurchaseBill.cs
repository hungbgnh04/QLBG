using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class PurchaseBill : BillBase
    {
        private uint customerID;

        public uint CustomerID { get => customerID; set => customerID=value; }

        public PurchaseBill(uint id, uint employeeID, DateTime date, uint totalMoney, 
            uint customerID) : base(id, employeeID, date, totalMoney)
        {
            this.customerID = customerID;
        }

        public PurchaseBill() : base()
        {
            this.customerID = 0;
        }
    }
}
