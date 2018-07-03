using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Book.DAL
{
    public class T_Stock_In
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
        public List<Book.Model.T_Stock_In> GetList(int CurrentPage, int PageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + PageSize + " * from  [V_InHead_Provider] where  id not in (select top " + PageSize * (CurrentPage - 1) + " id from [V_InHead_Provider] )";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Stock_In> lst = new List<Model.T_Stock_In>();
            while (dr.Read())
            {
                Book.Model.T_Stock_In inStock = new Model.T_Stock_In();
                Book.Model.T_Stock_InHead head = new Model.T_Stock_InHead();
                inStock.Id = Convert.ToInt32(dr["Id"]);
                inStock.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                inStock.ProviderId = Convert.ToInt32(dr["ProviderId"]);
                inStock.TotalMoney = Convert.ToDecimal(dr["TotalMoney"]);
                inStock.UserName = Convert.ToString(dr["UserName"]);
                head.Id = Convert.ToInt32(dr["Id"]);
                head.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                head.ProviderId = Convert.ToInt32(dr["ProviderId"]);
                head.TotalMoney = Convert.ToDecimal(dr["TotalMoney"]);
                head.UserName = Convert.ToString(dr["UserName"]);
                Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
                provider.Id = Convert.ToInt32(dr["Id"]);
                provider.Name = Convert.ToString(dr["Name"]);
                provider.Tel = Convert.ToString(dr["Tel"]);
                provider.Fax = Convert.ToString(dr["Fax"]);
                provider.Memo = Convert.ToString(dr["Memo"]);
                head.Provider = provider;
                inStock.Head = head;
                inStock.Items = null;
                lst.Add(inStock);
            }
            dr.Close();
            co.Close();
            return lst;
        }
        public Book.Model.T_Stock_In GetModel(int HeadId)
        {
            Book.Model.T_Stock_In model = new Model.T_Stock_In();
            model.Head = null;
            model.Items = new List<Model.T_Stock_InItems>();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from [V_InItem_Book] where headid=@headid";
            cm.Parameters.AddWithValue("@headid",HeadId);
            SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Book.Model.T_Stock_InItems item = new Model.T_Stock_InItems();
                    item.HeadId = HeadId;
                    item.Id = Convert.ToInt32(dr["Id"]);
                    item.Amount = Convert.ToInt32(dr["Amount"]);
                    item.Discount = Convert.ToDecimal(dr["Discount"]);
                    Book.Model.T_Base_Book book = new Model.T_Base_Book();
                    book.Author = Convert.ToString(dr["Author"]);
                    book.BookName = Convert.ToString(dr["BookName"]);
                    book.Id = Convert.ToInt32(dr["Id"]);
                    book.PressName = Convert.ToString(dr["PressName"]);
                    book.Price = Convert.ToDecimal(dr["Price"]);
                    book.SN = Convert.ToString(dr["SN"]);
                    book.Version = Convert.ToInt32(dr["Version"]);
                    item.Book = book;
                    model.Items.Add(item);
                }
                dr.Close();
                co.Close();
            return model;
        }
        public  int Count()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count(*) from T_Stock_InHead";
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;
        }
        public int CountItem(int HeadId)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count(*) from T_Stock_InItems where HeadId=@headId";
            cm.Parameters.AddWithValue("@headid", HeadId);
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;
        }
        public int Delete(string ids)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "delete from t_stock_inItems where headid in (" + ids + ");delete from t_stock_inhead where id in (" + ids + ") ; ";
            cm.Connection = co;
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public bool Add(Book.Model.T_Stock_InHead head, Book.Model.T_Stock_InItems[] items)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlTransaction tran = co.BeginTransaction();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.Transaction = tran;
            try
            {
                cm.Parameters.Clear();
                cm.CommandText = "insert into t_stock_inhead(UserName,CreateTime,ProviderId,TotalMoney) values (@UserName,@CreateTime,@ProviderId,@TotalMoney);select @@identity";
                cm.Parameters.AddWithValue("@UserName", head.UserName);
                cm.Parameters.AddWithValue("@ProviderId", head.ProviderId);
                cm.Parameters.AddWithValue("@CreateTime", head.CreateTime);
                cm.Parameters.AddWithValue("@TotalMoney", head.TotalMoney);
                object result = cm.ExecuteScalar();
                int headId = Convert.ToInt32(result);
                foreach (Book.Model.T_Stock_InItems item in items)
                {
                    cm.Parameters.Clear();
                    cm.CommandText = "insert into t_stock_initems(HeadId,BookId,Amount,Discount) values (@HeadId,@BookId,@Amount,@Discount)";
                    cm.Parameters.AddWithValue("@HeadId", headId);
                    cm.Parameters.AddWithValue("@BookId", item.BookId);
                    cm.Parameters.AddWithValue("@Amount", item.Amount);
                    cm.Parameters.AddWithValue("@Discount", item.Discount);
                    cm.ExecuteNonQuery();
                }
                tran.Commit();//提交   
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
            }
            finally
            {
                co.Close();
            }
            return false;
        }


    }
}
