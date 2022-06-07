using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Formats;

namespace interns
{
    public class interner
    {
        public static void Insert(string name, string surname, string fullname, string idNo,string depart, string Bday, string startday, string endday)
        {
            string connString = "Server=LAPTOP-9U27768K; Database = AFCentral;Trusted_Connection=true;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            string sql = "INSERT into Member(FirstName, SurName, FullName,SAIdentityNo,DepartmentId, Birthday, StartDate, EndDate) values(@fname,@lname,@FullName,@saIdno,@departId,@bday,@startdate,@enddate)";

            var Bdate = DateOnly.ParseExact(Bday,"yyyyMMdd", provider: System.Globalization.CultureInfo.InvariantCulture);
            var startdate = DateOnly.ParseExact(startday, "yyyyMMdd", provider: System.Globalization.CultureInfo.InvariantCulture);
            var enddate = DateOnly.ParseExact(endday,"yyyyMMdd", provider: System.Globalization.CultureInfo.InvariantCulture);

            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.Parameters.Add(new SqlParameter("@fname",name));
            cmd.Parameters.Add(new SqlParameter("@lname", surname));
            cmd.Parameters.Add(new SqlParameter("@fullname", fullname));
            cmd.Parameters.Add(new SqlParameter("@saIdno", idNo));
            cmd.Parameters.Add(new SqlParameter("@departId", depart));
            cmd.Parameters.Add(new SqlParameter("@bday", Bdate));
            cmd.Parameters.Add(new SqlParameter("@startdate", startdate));
            cmd.Parameters.Add(new SqlParameter("@enddate", enddate));


            cmd.ExecuteNonQuery();
            Console.WriteLine("successfully inserted");

            conn.Close();
            conn.Dispose();
        }
    }
}