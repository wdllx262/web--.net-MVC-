using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Book.Web.Controllers
{
    public class BookController : Controller
    {
        int PageSize = 3;
        int MaxPageIndex = 10;
        // GET: Book
        public ActionResult Index()
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            Book.Model.T_Base_Book_Page page = bll.GetListPage(1, PageSize);
            ViewBag.MaxPageIndex = MaxPageIndex;
            ViewBag.PageSize = PageSize;
            ViewBag.lst = page.list;
            ViewBag.count = page.count;
            return View();

        }
        public JsonResult GetList(int CurrentPage)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            List<Book.Model.T_Base_Book> lst = bll.GetList(CurrentPage, PageSize);
            return Json(lst);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddSave(string BookName, string Author, string PressName, string SN, int Version, decimal Price)
        {
            Book.Model.T_Base_Book book = new Model.T_Base_Book();
            book.Author = Author;
            book.BookName = BookName;
            book.SN = SN;
            book.PressName = PressName;
            book.Version = Version;
            book.Price = Price;
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            int result = bll.Add(book);
            return Redirect("/Book/Index");
        }
        public ActionResult Delete(int Id)
        { Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
           int result = bll.Delete(Id);
           return RedirectToAction("Index");
        }
        public JsonResult DeleteJson(int Id)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            int result = bll.Delete(Id);
            Book.Model.Message message;
            if (result > 0)
            {
                message = new Book.Model.Message() { Code = 200, Content = "删除成功" };
            }
            else
                message = new Model.Message() { Code = 500, Content = "删除失败" };
            return Json(message);
        }
        public ActionResult update(int Id)
        {
            Book.Model.T_Base_Book book = (new Book.BLL.T_Base_Book()).GetModel(Id);
            ViewBag.Book = book;
            return View();
        }
        public ActionResult upDateSave(Book.Model.T_Base_Book book)
        {
            Book.BLL.T_Base_Book updatebook = new Book.BLL.T_Base_Book();
            int result = updatebook.upDate(book);
            return Redirect("/Book/Index");
        }
        public JsonResult GetSearch(string SN)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();

            List<Book.Model.T_Base_Book> lst = bll.GetSearch(SN);
            return Json(lst);
        }

    }


}
