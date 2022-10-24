using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using ChatServiceLibrary.Models;

namespace ChatServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
       
        public UserService()
        {
            dbInit();
        }

        public string DoWork()
        {
            return "Inside dowork of User service";
        }

        SqlConnection conn;
        SqlCommand cmd;

        void dbInit()
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["chatappdbconnectionstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            Console.WriteLine("DB Connection Success !");
        }

      

        public User Login(String username, String password)
        {
            dbInit();
            Console.WriteLine(username);
            Console.WriteLine(password);
            cmd.CommandText = "SELECT * FROM [Users] WHERE Username=@Username and Password=@Password";
            SqlParameter param1 = new SqlParameter("@Username", username);
            SqlParameter param2 = new SqlParameter("@Password", password);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            User fetchedUser = new User();
            while (sqlDataReader.Read())
            {
                fetchedUser.UserId = sqlDataReader.GetInt32(0);
                fetchedUser.Password = sqlDataReader.GetString(1);
                fetchedUser.Username = sqlDataReader.GetString(2);

                Console.WriteLine(sqlDataReader.GetString(2));
            }
            sqlDataReader.Close();
            conn.Close();
            return fetchedUser;
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }


        public User GetUserByUserName(string username)
        {
            dbInit();
            Console.WriteLine(username);
            cmd.CommandText = "SELECT * FROM [Users] WHERE Username=@Username";
            SqlParameter param1 = new SqlParameter("@Username", username);
            cmd.Parameters.Add(param1);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            User fetchedUser = new User();
            while (sqlDataReader.Read())
            {
                fetchedUser.UserId = sqlDataReader.GetInt32(0);
                fetchedUser.Password = sqlDataReader.GetString(1);
                fetchedUser.Username = sqlDataReader.GetString(2);
            }
            sqlDataReader.Close();
            conn.Close();
            return fetchedUser;
        }


    }
}
