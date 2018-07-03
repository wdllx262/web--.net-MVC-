using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Book.Web.Controllers
{
    public class InController : Controller
    {
        // GET: In
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetALL()
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            List<Book.Model.T_Stock_In> lst = new List<Model.T_Stock_In>();
            lst = bll.GetList(1, 10);
            return Json(lst);
        }
        public JsonResult GetList(int pageSize, int pageIndex)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            List<Book.Model.T_Stock_In> lst = new List<Model.T_Stock_In>();
            lst = bll.GetList(pageIndex, pageSize);
            int count = bll.Count();
            return Json(new { total = count, rows = lst });
        }
        public JsonResult GetModel(int HeadId)
        {  
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            //List<Book.Model.T_Stock_InItems> lst = new List<Book.Model.T_Stock_InItems>();
            Book.Model.T_Stock_In stockIn = bll.GetModel(HeadId);
           // lst = stockIn.Items;
           // int count = bll.CountItem(HeadId);
            //return Json(new { total = count, rows = lst });
            return Json(stockIn);
        }
        public JsonResult Delete(string[] ids)
        {
            //删除

            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            bll.Delete(ids);
            return Json(new Book.Model.Message() { Code = 1, Content = "删除成功" });
        }
        public ActionResult Add()
        {
            return View();
        }
        public JsonResult AddSave(Book.Model.T_Stock_InHead head,Book.Model.T_Stock_InItems[] items)
        {
            //保存
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            bool result = bll.Add(head, items);
            if (result)
            return Json(new Book.Model.Message() { Code = 1, Content = "保存成功" });
            else return Json(new Book.Model.Message() { Code = 0, Content = "保存失败" });
        }
    }
}
