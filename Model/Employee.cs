using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    internal class Employee : HumanBase
    {
        private bool gender;
        private DateTime birthDate;
        private uint jobTitleId;

        public bool Gender { get => gender; set => gender=value; }
        public DateTime BirthDate { get => birthDate; set => birthDate=value; }
        public uint JobTitleId { get => jobTitleId; set => jobTitleId=value; }

        public Employee() : base()
        {
            Gender = true;
            BirthDate = DateTime.Now;
            JobTitleId = 0;
        }

        public Employee(uint id, string name, string address, string phoneNumber, bool gender,
            DateTime birthDate, uint jobTitleId) : base(id, name, address, phoneNumber)
        {
            Gender = gender;
            BirthDate = birthDate;
            JobTitleId = jobTitleId;
        }
    }
}
