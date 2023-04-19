using Features.Interfaces;
using Features.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Features.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _log;

        public UserService(ILogger<UserService> log)
        {
            _log = log;
        }

        public void GetAllUser()
        {
            var query = GetListUser();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        public List<Users> GetListUser()
        {
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                List<Users> ? listUser = JsonSerializer.Deserialize<List<Users>>
                (
                    File.ReadAllText("MockData/Users.json"), options
                );

                return listUser;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public string GetUserById(Guid Id)
        {
            var data = GetListUser();
            var user = data.FirstOrDefault(x => x.Id == Id)?.username;
            return user;
        }
    }
}
