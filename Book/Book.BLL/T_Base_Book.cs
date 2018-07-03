using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Book.BLL
{
    public class T_Base_Book
    {
        public List<Book.Model.T_Base_Book> GetAll()
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            return dal.GetAll();
        }
        public Book.Model.T_Base_Book_Page GetListPage(int CurrentPage, int PageSize)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            List<Book.Model.T_Base_Book> list = dal.GetList(CurrentPage, PageSize);
            int count = dal.GetCount();
            Book.Model.T_Base_Book_Page page = new Model.T_Base_Book_Page();
            page.list = list;
            page.count = count;
            return page;
        }
        public List<Book.Model.T_Base_Book> GetList(int CurrentPage,int PageSize)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            return dal.GetList(CurrentPage, PageSize);
        }
        public int Add(Book.Model.T_Base_Book book)
        {
            int result = 0;
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            result=dal.Add(book);
            return result;
        }
        public int Delete(int Id)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            int result = dal.Delete(Id);
            return result;
        }
        public Book.Model.T_Base_Book GetModel(int Id)
        {
            return (new DAL.T_Base_Book()).GetModel(Id);
        }
        public int upDate(Book.Model.T_Base_Book book)
        { 
             int result = 0;
             Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
             result = dal.upDate(book);
             return result;
        }
        public List<Book.Model.T_Base_Book> GetSearch(string SN)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book ();
            List<Book.Model.T_Base_Book> lst = dal.GetSearch(SN);
            return lst;
        }
    }
    public class T_Base_Provider
    {
        public List<Book.Model.T_Base_Provider> GetAll()
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            return dal.GetAll();
        }
        public Book.Model.T_Base_Provider_Page GetListPage(int CurrentPage, int PageSize)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> list = dal.GetList(CurrentPage, PageSize);
            int count = dal.GetCount();
            Book.Model.T_Base_Provider_Page page = new Model.T_Base_Provider_Page();
            page.list = list;
            page.count = count;
            return page;
        }
        public List<Book.Model.T_Base_Provider> GetList(int CurrentPage, int PageSize)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            return dal.GetList(CurrentPage, PageSize);
        }
        public int Add(Book.Model.T_Base_Provider book)
        {
            int result = 0;
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            result = dal.Add(book);
            return result;
        }
        public int Delete(int Id)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            int result = dal.Delete(Id);
            return result;
        }
        public Book.Model.T_Base_Provider GetModel(int Id)
        {
            return (new DAL.T_Base_Provider()).GetModel(Id);
        }
        public int upDate(Book.Model.T_Base_Provider book)
        {
            int result = 0;
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            result = dal.upDate(book);
            return result;
        }
        public List<Book.Model.T_Base_Provider> GetSearch(string Name, int matchCount)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> lst = dal.GetSearch(Name, matchCount);
            return lst;
        }
    }
}
