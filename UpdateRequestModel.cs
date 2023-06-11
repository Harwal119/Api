using System;
namespace batch15webAPI
{
    public class UpdateRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
    public class LoginRequestModel
    {
        public string Email {get;set;}
        public string PassWord {get;set;}
    }
    public class User
    {
        public static List<User> Users = new List<User>{
            new User(){Email = "ade@gmail.com" , PassWord = "ade" , Role = "Admin"},
            new User(){Email = "bola@gmail.com" , PassWord = "bola" , Role = "Customer"},
            new User(){Email = "ayo@gmail.com" , PassWord = "ayo" , Role = "Customer" },
        };
         public string Email {get;set;}
        public string PassWord {get;set;}
        public string Role {get;set;}
        public static void name()
        {

        }
    }
}
