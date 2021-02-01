using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PrjAdoFirstApplication
{

    class Student1
    {
        public string Sid { get; set; }
        public int SAge { get; set; }
    }
    class DataAccessLayer
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd = null;
        static string connection = ConfigurationManager.ConnectionStrings["dbStudyconnection"].ConnectionString;
        #region Connection
        public static SqlConnection GetConnection()
        {
            con = new SqlConnection(connection);
            con.Open();
            return con;
        }
        #endregion
        Student1 studentobj = new Student1();
        public int GetAge(string id)
        {
           
            con = GetConnection();
            cmd = new SqlCommand("GetStudentAge", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Stuid", id));

          studentobj.SAge =Convert.ToInt32(cmd.ExecuteScalar());


            return studentobj.SAge;
        }


    }

    class BusinessAccessLayer
    {
        DataAccessLayer Dalobj = new DataAccessLayer();
        Student1 studal=new Student1();
      public void CheckAge(string sid)
        {

            //  studal = Dalobj.GetAge( s);
            studal.SAge = Dalobj.GetAge(sid);
            if (studal.SAge!=null && studal.SAge > 0)
            {
                Console.WriteLine("Valid Student");
            }

            else
            {
                Console.WriteLine("InValid Student");
            }

        }

    }

    //Presentation Layer
    class ThreetireArchitectureEg
    {
        public static void Main()
        {
            
            BusinessAccessLayer balobj = new BusinessAccessLayer();
            Student1 student = new Student1();
            Console.WriteLine("Enter the student Id");
            student.Sid = Console.ReadLine();
            balobj.CheckAge(student.Sid);
            Console.Read();
        }
    }
}
