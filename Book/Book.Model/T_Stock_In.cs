﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Book.Model
{
    public class   T_Stock_In : T_Stock_InHead
    {
        public T_Stock_InHead Head { get; set; }
        public List<T_Stock_InItems> Items { get; set; }
    }
    public class T_Stock_InHead
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
        public decimal TotalMoney { get; set; }
        public int ProviderId { get; set; }
        public T_Base_Provider Provider { get; set; }
    }
    public class T_Stock_InItems
    {
        public int Id { get; set; }
        public int HeadId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal Discount { get; set; }
        public T_Base_Book Book { get; set; }
        public T_Stock_InHead Head { get; set; }
    }
}
