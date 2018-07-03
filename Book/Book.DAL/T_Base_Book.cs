using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Book.DAL
{
    public class T_Base_Book
    {
        public List<Book.Model.T_Base_Book> GetAll()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_book";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst;
        }
        public List<Book.Model.T_Base_Book> GetList(int CurrentPage, int PageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + PageSize + " * from t_base_book where id not in (select top " + PageSize*(CurrentPage-1)+ " id from  t_base_book)";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst; ;
        }
        public int GetCount()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) from t_base_book";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        public int Add(Book.Model.T_Base_Book book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into t_base_book (BookName,Author,PressName,Version,Price,SN) values (@BookName,@Author,@PressName,@Version,@Price,@SN)";
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@PressName", book.PressName);
            cmd.Parameters.AddWithValue("@Version", book.Version);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@SN", book.SN);
            int result = 0;
            result = cmd.ExecuteNonQuery();
            co.Close();
            return result;

        }
        public int Delete(int id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "delete from t_base_book where id=@Id";
            cmd.Parameters.AddWithValue("@Id",id);
            int result = 0;
            result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public Book.Model.T_Base_Book GetModel(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from t_base_book where id=@Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            Book.Model.T_Base_Book book = null;
            while (dr.Read())
            {
                book = new Book.Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
            }
            dr.Close();
            co.Close();
            return book;
        }
        public int upDate(Book.Model.T_Base_Book book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "update t_base_book set BookName=@BookName, Author=@Author, PressName=@PressName,[Version]=@Version,Price=@Price,SN=@SN where Id=@Id";
            cm.Parameters.AddWithValue("@BookName", book.BookName);
            cm.Parameters.AddWithValue("@Author", book.Author);
            cm.Parameters.AddWithValue("@PressName", book.PressName);
            cm.Parameters.AddWithValue("@Version", book.Version);
            cm.Parameters.AddWithValue("@Price", book.Price);
            cm.Parameters.AddWithValue("@SN", book.SN);
            cm.Parameters.AddWithValue("@Id", book.Id);
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public List<Book.Model.T_Base_Book> GetSearch(string SN)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_book WHERE sn like '%" + SN + "%'";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst;
        }

    }
    public class T_Base_Provider
    {
        public List<Book.Model.T_Base_Provider> GetAll()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_provider";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Provider> lst = new List<Model.T_Base_Provider>();
            while (dr.Read())
            {
                Book.Model.T_Base_Provider item= new Model.T_Base_Provider();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Name= Convert.ToString(dr["Name"]);
                item.Tel = Convert.ToString(dr["Tel"]);
                item.Fax = Convert.ToString(dr["Fax"]);
                item.Memo = Convert.ToString(dr["Memo"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }
        public List<Book.Model.T_Base_Provider> GetList(int CurrentPage, int PageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + PageSize + " * from t_base_provider where id not in (select top " + PageSize * (CurrentPage - 1) + " id from  t_base_provider)";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Provider > lst = new List<Model.T_Base_Provider> ();
            while (dr.Read())
            {
                Book.Model.T_Base_Provider item = new Model.T_Base_Provider();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Name = Convert.ToString(dr["Name"]);
                item.Tel = Convert.ToString(dr["Tel"]);
                item.Fax = Convert.ToString(dr["Fax"]);
                item.Memo = Convert.ToString(dr["Memo"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst; ;
        }
        public int GetCount()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) from t_base_provider";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        public int Add(Book.Model.T_Base_Provider item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "insert into t_base_provider (Name,Tel,Fax,Memo) values (@Name,@Tel,@Fax,@Memo)";
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@Tel", item.Tel);
            cmd.Parameters.AddWithValue("@Fax", item.Fax);
            cmd.Parameters.AddWithValue("@Memo", item.Memo);
            int result = 0;
            result = cmd.ExecuteNonQuery();
            co.Close();
            return result;

        }
        public int Delete(int id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "delete from t_base_provider where id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            int result = 0;
            result = cmd.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public Book.Model.T_Base_Provider GetModel(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = co;
            cmd.CommandText = "select * from  t_base_provider where id=@Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            Book.Model.T_Base_Provider item = null;
            while (dr.Read())
            {
               item = new Book.Model.T_Base_Provider();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Name = Convert.ToString(dr["Name"]);
                item.Tel = Convert.ToString(dr["Tel"]);
                item.Fax = Convert.ToString(dr["Fax"]);
                item.Memo = Convert.ToString(dr["Memo"]);
            }
            dr.Close();
            co.Close();
            return item;
        }
        public int upDate(Book.Model.T_Base_Provider book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "update t_base_provider set Name=@Name, Tel=@Tel, Fax=@Fax,Memo=@Memo where Id=@Id";
            cm.Parameters.AddWithValue("@Id", book.Id);
            cm.Parameters.AddWithValue("@Name", book.Name);
            cm.Parameters.AddWithValue("@Tel", book.Tel);
            cm.Parameters.AddWithValue("@Fax", book.Fax);
            cm.Parameters.AddWithValue("@Memo", book.Memo);
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public List<Book.Model.T_Base_Provider> GetSearch(string Name, int matchCount)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=152111160209";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + matchCount + " * from t_base_provider where Name like '%" + Name + "%'";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Provider> lst = new List<Model.T_Base_Provider>();
            while (dr.Read())
            {
                Book.Model.T_Base_Provider item = new Model.T_Base_Provider();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Name = Convert.ToString(dr["Name"]);
                item.Tel = Convert.ToString(dr["Tel"]);
                item.Fax = Convert.ToString(dr["Fax"]);
                item.Memo = Convert.ToString(dr["Memo"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }


    }
}
