using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    class Member
    {
        MY_DB myDB = new MY_DB();
        public bool InsertMember(string id,string fname,string lname,string gender,DateTime bdate,string adrs,string phone,MemoryStream pic,string username)
        {
                SqlCommand command = new SqlCommand("insert into Member (Id,FirstName,LastName, Gender, BirthDate,Address,Phone ,Picture,username)" +
                 " values (@id,@fn,@ln,@gdr,@bdt,@adrs,@phn,@pic,@user)", myDB.getConnection);
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
                command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
                command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
                command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
                command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = adrs;
                command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
                command.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
                command.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;

                myDB.openConnection();
                if ((command.ExecuteNonQuery() == 1))
                {
                    myDB.closeConnection();
                    return true;
                }
                else
                {
                    myDB.closeConnection();
                    return false;
                }
        }
        public bool DeleteMember(string id)
        {
            SqlCommand command = new SqlCommand("delete FROM Member WHERE Id=@id", myDB.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            myDB.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                myDB.closeConnection();
                return true;
            }
            else
            {
                myDB.closeConnection();
                return false;
            }


        }
        public bool UpdateMember(string id, string fname, string lname, string gender, DateTime bdate, string adrs, string phone, MemoryStream pic)
        {
            //string query = string.Format("UPDATE dbo.Member SET FirstName=N'{1}', LastName=N'{2}' , Gender=N'{3}', BirthDate={4}, Address=N'{5}',Phone=N'{6}', Picture={7} WHERE Id=N'{0}'", id, fname, lname, gender, bdate, adrs, phone, pic);

            //int result = DataProvider.Instance.ExecuteNonQuery(query);
            //return result > 0;
            SqlCommand command = new SqlCommand("Update Member Set FirstName=@fn,LastName=@ln,BirthDate=@bdt,Gender=@gdr,Phone=@phn,Address=@adrs,Picture=@pic Where Id=@id ", myDB.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = adrs;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();

            myDB.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                myDB.closeConnection();
                return true;
            }
            else
            {
                myDB.closeConnection();
                return false;
            }


        }
        public DataTable getMemberForUsername(string username)
        {
            SqlCommand command = new SqlCommand("select * from Member where username= @us", myDB.getConnection);
            command.Parameters.Add("@us", SqlDbType.NVarChar).Value = username;
            SqlDataAdapter adap = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adap.Fill(table);
            return table;
        } 

    }
}
