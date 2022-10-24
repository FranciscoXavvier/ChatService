using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ChatServiceLibrary.Models
{
    [DataContract]
    public class User
    {
        public User()
        {

        }
        public User(int userId,string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
       

    }
}
