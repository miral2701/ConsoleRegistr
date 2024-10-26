using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class UserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool RegisterUser(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username)) {
                Helper.WriteErrorMessage("User with this username already exists");
                return false;
            }
            string password = ComputeHash(user.Password);
            user.Password = password;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;    
        }

        public bool AuthenticateUser(User user)
        {
            string password=ComputeHash(user.Password);
            return _context.Users.Any(u=>u.Username==user.Username && u.Password==password);
        }

        private string ComputeHash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[]inputBytes=Encoding.ASCII.GetBytes(input);
                byte[] hashBytes=md5.ComputeHash(inputBytes);

                StringBuilder sb=new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) {
                
                sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
           
        }
    }
}
