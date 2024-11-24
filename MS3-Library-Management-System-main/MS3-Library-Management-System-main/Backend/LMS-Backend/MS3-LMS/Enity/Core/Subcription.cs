﻿using MS3_LMS.Enity.User;
using System.ComponentModel.DataAnnotations;

namespace MS3_LMS.Enity.Core
{
    public class Subscription
    {
        [Key]
        public Guid SubId { get; set; }
        public enum Type
        {
            Month,
            Year
        };
        public Type SubType { get; set; }
        public int Count { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancel { get; set; }
        public  Guid MemebID { get; set; }

        public  Member? Member { get; set; }

        public ICollection<Payment> Payment { get; set; }


    }

}
