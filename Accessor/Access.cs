using System.Data.SqlClient;

namespace Accessor
{

    public class Person
    {
       
        public string surname ;
        public string name;
        public string fullname;
        public int idnumber;
        public int parkingNo;
        public int depart;
        public string position;
        public string birthdate;
        public string day1;
        public string endday;
        
        
        /*public void Info()
        {
            Console.WriteLine($"Hi, my surname and name is {surname} {name}" +
                $" my position is {position} in {depart} department");
        }*/
    }
   public class Access
    {

        
        public static void Program()
        {

            Person person = new Person();
            person.surname = "";
            person.name = "";
            person.fullname = "";
            person.position = "";
            person.birthdate = "";
            person.day1 = "";
            person.endday = "";



            var cnn = new SqlConnection("Server= LAPTOP-ICUOINHF; Database = AFCentral;Trusted_Connection=true;");
            cnn.Open();

            string sql = "INSERT INTO Member(FirstName,SurName,FullName,SAIdentityNo,ParkingSpotNo,DepartmentId,PositionId,CelebratesBirthday,Birthday,StartDate,EndDate)" +
                " values(@fname,@lname,@fullname,@saIdno,@parkingSpot,@departId,@pos,@bday,@startdate,@enddate)";

            SqlCommand cmd1 = new SqlCommand(sql, cnn);
           
            cmd1.Parameters.Add(new SqlParameter("@lname", person.surname));
            cmd1.Parameters.Add(new SqlParameter("@fname", person.name));
            cmd1.Parameters.Add(new SqlParameter("@saIdno", person.idnumber));
            cmd1.Parameters.Add(new SqlParameter("@parkingSpot", person.parkingNo));
            cmd1.Parameters.Add(new SqlParameter("@departId", person.depart));
            cmd1.Parameters.Add(new SqlParameter("@pos", person.position));
            cmd1.Parameters.Add(new SqlParameter("@bday", person.birthdate));
            cmd1.Parameters.Add(new SqlParameter("@startdate", person.day1));
            cmd1.Parameters.Add(new SqlParameter("@enddate", person.endday));
            cmd1.ExecuteNonQuery();

            /* var cmd = new SqlCommand("INSERT INTO Member(@Id,@FirstName,@Surname,@FullName," +
                " @SAIdentityNo,@ParkingSpotNo,@PositionId,@CelebratesBirthday,@Birthday" +
                ",@StartDate,@EndDate)", cnn);
            cmd.Parameters.Add("@ID");
            cmd.Parameters.Add("@FirstName");
            cmd.Parameters.Add("@Surname");
            cmd.Parameters.Add("@FullName");
            cmd.Parameters.Add("@SAIdentity");
            cmd.Parameters.Add("@ParkingSpotNo");
            cmd.Parameters.Add("@DepartmentId");
            cmd.Parameters.Add("@PositionId");
            cmd.Parameters.Add("@CelebratesBirthday");
            cmd.Parameters.Add("@StartDate");
            cmd.Parameters.Add("@EndDate");*/
            cnn.Close();


        }
    }
}