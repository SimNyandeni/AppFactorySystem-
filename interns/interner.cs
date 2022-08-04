﻿using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Formats;
using System.Data;

namespace interns
{
    public class interner
    {
        public static void Insert(string name, string surname,/*int parkingNumber,*/ string fullname, string idNo, DateTime Bday, DateTime startday, DateTime endday)
        {
            string connString = "Server=LAPTOP-9U27768K; Database = AFCentral;Trusted_Connection=true;";
            SqlConnection conn = new SqlConnection(connString);
            

           using(SqlCommand cmd = new SqlCommand("MemberInsert", conn))
            {
                try
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@IdNumber", idNo);
                    cmd.Parameters.AddWithValue("@birthday", Bday);
                    cmd.Parameters.AddWithValue("@startdate", startday);
                    cmd.Parameters.AddWithValue("@endate", endday);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("successfully inserted");
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);  
                }


            }








            

            conn.Close();
            conn.Dispose();
        }
    }
}