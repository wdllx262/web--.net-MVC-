using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string PressName { get; set; }
        public string SN { get; set; }
        public string Author { get; set; }
        private int version=0;

        public int Version
        {
            get { return version; }
            set { version= value; }
        }
        public decimal Price   { get; set; }

    }
    public class T_Base_Provider
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 供应商电话
        /// </summary>
        public string Tel{ get; set; }
        /// <summary>
        /// 供应商传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

    }
    public class Message
    {
        public int Code { get; set; }
        public string Content { get; set; }
    }
    public class T_Base_Book_Page
    {
        public List<T_Base_Book> list { get; set; }
        public int count { get; set; }
    }
    public class T_Base_Provider_Page
    {
        public List<T_Base_Provider> list { get; set; }
        public int count { get; set; }
    }

}
