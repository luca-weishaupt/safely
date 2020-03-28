using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using Safely.Model;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Safely.Data
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://safely-8a5fe.firebaseio.com/");

        public async Task<List<User>> GetAllUsers()
        {

            return (await firebase
                .Child("Users")
                .OnceAsync<User>())
                .Select(item => new User
            {
                Name = item.Object.Name,
                UserId = item.Object.UserId
            }).ToList();

        }

        public async Task AddUser(int userId, string name)
        {

            await firebase
                .Child("Users")
                .PostAsync(new User() { UserId = userId, Name = name });
        }

        public async Task<User> GetUser(int userId)
        {
            var allUsers = await GetAllUsers();
            return allUsers.Where(a => a.UserId == userId).FirstOrDefault();
        }

        public async Task UpdateUser(int userId, string name)
        {
            var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.UserId == userId).FirstOrDefault();

            await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new User() { UserId = userId, Name = name });
        }

        public async Task DeleteUser(int userId)
        {
            var toDeleteUser = (await firebase
                .Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.UserId == userId).FirstOrDefault();
            await firebase.Child("Users").Child(toDeleteUser.Key).DeleteAsync();
        }
    }
}
