using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatServiceLibrary.Models;

namespace ChatServiceLibrary
{
    [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        User Login(String username, String password);

        [OperationContract]
        String DoWork();

        [OperationContract]
        User GetUserByUserName(String username);

    }
}
