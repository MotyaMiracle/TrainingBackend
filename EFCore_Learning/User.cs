using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore_Learning
{
    public class User
    {
        
        //public User(string login, string password, UserProfile profile)
        //{
        //    Login = login;
        //    Password = password;
        //    Profile = profile;
        //}
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        [Required]
        public UserProfile? Profile { get; set; }
        //private UserProfile? Profile { get; set; }
        //public override string ToString()
        //{
        //    return $"Name: {Profile?.Name} Age: {Profile?.Age} Login: {Login} Password: {Password}";
        //}
    }
}
