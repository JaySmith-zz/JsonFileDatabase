using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magrathea.Data;

namespace JsonFileDatabase.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }



        public void ReadFormatedFile()
        {
            var dataStore = new Magrathea.Data.FileDataRepository(@"C:\Temp\testdata.json");
            var data = dataStore.Read<UserDatabase>();
        }

        [Test]
        public void WritesFormatedFile()
        {
            var data = new UserDatabase();

            data.Users.Add(new User
            {
                UserName = "user1",
                Password = "pass1"
            });

            data.Users.Add(new User
            {
                UserName = "user2",
                Password = "pass2"
            });

            var dataStore = new FileDataRepository(@"C:\Temp\testdata.json");
            dataStore.Save(data);

            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }

    class UserDatabase
    {
        public UserDatabase()
        {
            Users = new List<User>();
        }

        public List<User> Users { get; set; }
    }

    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
