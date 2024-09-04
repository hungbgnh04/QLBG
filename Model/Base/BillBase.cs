using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class BillBase
    {
        private uint id;
        private uint employeeId;
        private DateTime date;
        private double totalMoney;

        public uint Id { get => id; set => id=value; }
        public uint EmployeeId { get => employeeId; set => employeeId=value; }
        public DateTime Date { get => date; set => date=value; }
        public double TotalMoney { get => totalMoney; set => totalMoney=value; }

        public BillBase()
        {
            this.id = 0;
            this.employeeId = 0;
            this.date = DateTime.Now;
            this.totalMoney = 0;
        }

        public BillBase(uint id, uint employeeId, DateTime date, double totalMoney)
        {
            this.id = id;
            this.employeeId = employeeId;
            this.date = date;
            this.totalMoney = totalMoney;
        }
    }
}
