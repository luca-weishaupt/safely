﻿using Firebase.Database;
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
                    Email = item.Object.Email,
                    Password = item.Object.Password,
                    Latitude = item.Object.Latitude,
                    Longitude = item.Object.Longitude,
                    Status = item.Object.Status
                }).ToList();

        }

        public async Task AddUser(string email, string password)
        { 
            await firebase
                .Child("Users")
                .PostAsync(new User() 
                { 
                    Email = email,
                    Password = password
                });
        }

        public async Task<User> GetUser(string email)
        {
            var allUsers = await GetAllUsers();
            return allUsers.Where(a => a.Email == email).FirstOrDefault();
        }

        public async Task UpdateLocation(string email, float latitude, float longitude)
        {
            var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.Email == email).FirstOrDefault();

            User updatedUser = (User) toUpdateUser.Object;
            updatedUser.UpdateLocation(longitude, latitude);

            await DeleteUser(updatedUser.Email);
            await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(updatedUser);
        }

        public async Task DeleteUser(string email)
        {
            var toDeleteUser = (await firebase
                .Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.Email == email).FirstOrDefault();
            await firebase.Child("Users").Child(toDeleteUser.Key).DeleteAsync();
        }
    }
}
