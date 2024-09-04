using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class SellingBillDetail : BillDetailBase
    {
        public SellingBillDetail() : base() { }

        public SellingBillDetail(uint billID, uint itemID, uint quantity, double discount,
            double lastPrice) : base(billID, itemID, quantity, discount, lastPrice)
        {
        }
    }
}
