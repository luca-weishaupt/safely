using Safely.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using static Safely.Model.User;

namespace Safely.Model
{
    class CreateSamplePoints
    {

        public CreateSamplePoints()
        {
            GenerateFakeUsers();
        }
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        double latitude = 43.666667;
        double longitude = -79.416667;

        public async Task GenerateFakeUsers()
        {
            Random rnd = new Random();

            Debug.WriteLine("Start Generating Fake Users");
            
            for (int i = 0; i < 100; i += 1)
            {
                float lat = (float) (latitude + rnd.NextDouble() - 0.5);
                float lon = (float) (longitude + rnd.NextDouble() - 0.5);

                string email = "fake" + i.ToString() + "@fake.com";
                string password = "fakepassword";

                Debug.WriteLine("Create " + email + " at " + lat.ToString() + ", " + lon.ToString());
                // await firebaseHelper.DeleteUser(email);
                await firebaseHelper.AddUser(email, password);
                await firebaseHelper.UpdateLocation(email, lat, lon);
                await firebaseHelper.UpdateStatus(email, (StatusEnum) (i % 4));
            }
        }

    }
}
