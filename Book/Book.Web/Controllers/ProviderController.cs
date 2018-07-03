using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provider
        int PageSize = 3;
        int MaxPageIndex = 10;
        // GET: Book
        public ActionResult Index()
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            Book.Model.T_Base_Provider_Page page = bll.GetListPage(1, PageSize);
            ViewBag.MaxPageIndex = MaxPageIndex;
            ViewBag.PageSize = PageSize;
            ViewBag.lst = page.list;
            ViewBag.count = page.count;
            return View();

        }
        public JsonResult GetList(int CurrentPage)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> lst = bll.GetList(CurrentPage, PageSize);
            return Json(lst);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddSave(string Name, string Tel, string Fax, string Memo)
        {
            Book.Model.T_Base_Provider item = new Model.T_Base_Provider();
            item.Name = Name;
            item.Tel = Tel;
            item.Fax = Fax;
            item.Memo = Memo;
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            int result = bll.Add(item);
            return Redirect("/Provider/Index");
        }
        public ActionResult Delete(int Id)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            int result = bll.Delete(Id);
            return RedirectToAction("/Provider/Index");
        }
        public JsonResult DeleteJson(int Id)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
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
            Book.Model.T_Base_Provider book = (new Book.BLL.T_Base_Provider()).GetModel(Id);
            ViewBag.Book = book;
            return View();
        }
        public ActionResult upDateSave(Book.Model.T_Base_Provider book)
        {
            Book.BLL.T_Base_Provider updatebook = new Book.BLL.T_Base_Provider();
            int result = updatebook.upDate(book);
            return Redirect("/Provider/Index");
        }
        public JsonResult GetSearch(string Name, int matchCount = 10)
        {
            //Name = Name.Trim();
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> lst = bll.GetSearch(Name, matchCount);
            return Json(lst);
        }

    }
}