using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Book.BLL
{
    public class T_Stock_In
    {
        public Book.DAL.T_Stock_In dal = new DAL.T_Stock_In();

        public List<Book.Model.T_Stock_In> GetList(int CurrentPage, int PageSize)
        {
            return dal.GetList(CurrentPage, PageSize);
        }
        public Book.Model.T_Stock_In GetModel(int HeadId)
        {
            return dal.GetModel(HeadId);
        }
        public int Count()
        {
            return dal.Count();
        }
        public int CountItem(int HeadId)
        {
            return dal.CountItem(HeadId);
        }
        public int Delete(string[] ids)
        {
            string idstring = string.Join(", ", ids);
            return dal.Delete(idstring);
        }
        public bool Add(Book.Model.T_Stock_InHead head, Book.Model.T_Stock_InItems[] items)
        {
            decimal totalMoney = 0;
            foreach (Book.Model.T_Stock_InItems item in items)
            {
                totalMoney += item.Amount * item.Discount * 10;
            }
            head.TotalMoney = totalMoney;
            return dal.Add(head,items);
        }

    }
}
