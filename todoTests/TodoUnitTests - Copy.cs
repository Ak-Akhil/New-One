//using System;
//using System.Configuration;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using todo;
//using todo.Models;

//namespace todo.Tests
//{
//    [TestClass]
//    public class TodoUnitTests
//    {
//        public TestContext TestContext { get; set; }

//        [TestInitialize()]
//        public void Initialize()
//        {
//            string endpoint = TestContext.Properties["endpoint"].ToString();
//            string authKey = TestContext.Properties["authKey"].ToString();
//            Console.WriteLine("Using endpoint: ", endpoint);
//            DocumentDBRepository<Item>.Initialize(endpoint, authKey);
//        }
//        [TestMethod]
//        public async Task TestEditItemsAsync()
//        {
//            var item = new Item
//            {
//                Id = "1",
//                Student_Number = "12345678",
//                First_Name = "testName",
//                Last_Name = "testDescription",
//                Email = "hello@email.com",
//                Home_Address = "testCategory",
//                Mobile = "1234567890",
//                Photo_Path = "http...................",
//                Status = true
//            };



//            // update the item
//            await DocumentDBRepository<Item>.UpdateItemAsync(item.Id, item);
//            // Query for the item
//            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);
//            // Verify the item returned is correct.
//            Assert.AreEqual(item.Id, returnedItem.Id);
//            Assert.AreEqual(item.Student_Number, returnedItem.Student_Number);
//            Assert.AreEqual(item.First_Name, returnedItem.First_Name);
//            Assert.AreEqual(item.Last_Name, returnedItem.Last_Name);
//            Assert.AreEqual(item.Email, returnedItem.Email);
//            Assert.AreEqual(item.Home_Address, returnedItem.Home_Address);
//            Assert.AreEqual(item.Mobile, returnedItem.Mobile);
//            Assert.AreEqual(item.Photo_Path, returnedItem.Photo_Path);
//            Assert.AreEqual(item.Status, returnedItem.Status);


//        }
//    }

//}
