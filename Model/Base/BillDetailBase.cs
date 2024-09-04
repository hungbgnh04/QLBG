using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class BillDetailBase
    {
        private uint billID;
        private uint itemID;
        private uint quantity;
        private double discount;
        private double lastPrice;

        public uint BillID { get => billID; set => billID=value; }
        public uint ItemID { get => itemID; set => itemID=value; }
        public uint Quantity { get => quantity; set => quantity=value; }
        public double Discount { get => discount; set => discount=value; }
        public double LastPrice { get => lastPrice; set => lastPrice=value; }

        public BillDetailBase()
        {
            billID = 0;
            itemID = 0;
            quantity = 0;
            discount = 0;
            lastPrice = 0;
        }

        public BillDetailBase(uint billID, uint itemID, uint quantity, double discount, double lastPrice)
        {
            this.BillID = billID;
            this.ItemID = itemID;
            this.Quantity = quantity;
            this.Discount = discount;
            this.LastPrice = lastPrice;
        }
    }
}
