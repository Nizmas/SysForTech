using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysTech
{
    public class UserService : IUserService
    {
        private OfficeContext officeContext;
        //тут я бы предпочёл конструктор
        public OfficeContext OfficeContext
        {
            set
            {
                officeContext = value;
            }
        }
        public bool IsValidUser(string username, string password)
        {
            /*var clService = new ClientService();
            if (!CheckClient(clService, username))
            {
                var selectedClient = clService.ReturnClient(new ClientModel { ClientName = username }, "SELECT * FROM clients WHERE clientname = @clientname;");
                return Password.CheckPassword(password, selectedClient.PasswordSalt, selectedClient.PasswordHash);
            }*/
            return false;
        }

        public bool UserCreate(string username, string password)
        {
            if (!CheckClient(username))
            {
                Guid userGuid = Guid.NewGuid();
                var newPassword = new Password(password);
                CreateClient(username, newPassword.PasswordHash, newPassword.Salt, userGuid);
                return true;
            }
            return false;
        }

        private bool CheckClient(string username)
        {
            var workers = officeContext.Workers.ToList();
            return workers.Exists(worker => worker.FullName == username);
        }
        private void CreateClient(string username, string passwordHash, string clientsalt, Guid id)
        {
            var projObj = new Worker()
            {
                Id = id.ToString(),
                FullName = username,
                Employment = DateTime.Now,
                Position = "a2d2d9b0-618c-428c-b0b2-8b27ddc66640",
                PasswordHash = passwordHash,
                PasswordSalt = clientsalt
            };

            try
            {
                officeContext.Workers.AddAsync(projObj);
                officeContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
