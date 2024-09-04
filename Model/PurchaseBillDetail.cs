using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class PurchaseBillDetail : BillDetailBase
    {
        private double billPrice;

        public double BillPrice { get => billPrice; set => billPrice=value; }

        public PurchaseBillDetail() : base()
        {
            BillPrice = 0;
        }

        public PurchaseBillDetail(uint billID, uint itemID, uint quantity, double discount, 
            double lastPrice, double billPrice) : base(billID, itemID, quantity, discount, lastPrice)
        {
            BillPrice = billPrice;
        }
    }
}
