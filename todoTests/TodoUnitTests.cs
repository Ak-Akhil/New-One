
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Tests
{
    [TestClass]
    public class TodoUnitTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void Initialize()
        {

            string endpoint = "https://localhost:8081";
            string authKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
            Console.WriteLine("Using endpoint: ", endpoint);
            DocumentDBRepository<Item>.Initialize(endpoint, authKey);
        }
        [TestMethod]
        public async Task TestCreateItemsAsync()
        {
            var item = new Item
            {
                Id = "942b1512-1d1e-4c8a-8199-878bdc0395d8",
                Student_Number = "12345678",
                First_Name = "testName",
                Last_Name = "testDescription",
                Email = "hello@email.com",
                Home_Address = "testCategory",
                Mobile = "1234567890",
                Photo_Path = "http",
                Status = true
            };



            // update the item
            await DocumentDBRepository<Item>.CreateItemAsync(item);
            // Query for the item
            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);
            // Verify the item returned is correct.
            Assert.AreEqual(item.Id, returnedItem.Id);
            Assert.AreEqual(item.Student_Number, returnedItem.Student_Number);
            Assert.AreEqual(item.First_Name, returnedItem.First_Name);
            Assert.AreEqual(item.Last_Name, returnedItem.Last_Name);
            Assert.AreEqual(item.Email, returnedItem.Email);
            Assert.AreEqual(item.Home_Address, returnedItem.Home_Address);
            Assert.AreEqual(item.Mobile, returnedItem.Mobile);
            Assert.AreEqual(item.Photo_Path, returnedItem.Photo_Path);
            Assert.AreEqual(item.Status, returnedItem.Status);
        }


        [TestMethod]
        public async Task TestCreateItemsAsync2()
        {
            var item = new Item
            {
                Id = "96cd7412-0aef-4631-a85d-17d1f55c630x",
                Student_Number = "87654321",
                First_Name = "testName2",
                Last_Name = "testDescription2",
                Email = "hello@email2.com",
                Home_Address = "testCategory2",
                Mobile = "0395241614",
                Photo_Path = "http...................2",
                Status = true
            };

            // Create the item
            await DocumentDBRepository<Item>.CreateItemAsync(item);
            // Query for the item
            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);
            // Verify the item returned is correct.
            Assert.AreEqual(item.Id, returnedItem.Id);
            Assert.AreEqual(item.Student_Number, returnedItem.Student_Number);
            Assert.AreEqual(item.First_Name, returnedItem.First_Name);
            Assert.AreEqual(item.Last_Name, returnedItem.Last_Name);
            Assert.AreEqual(item.Email, returnedItem.Email);
            Assert.AreEqual(item.Home_Address, returnedItem.Home_Address);
            Assert.AreEqual(item.Mobile, returnedItem.Mobile);
            Assert.AreEqual(item.Photo_Path, returnedItem.Photo_Path);
            Assert.AreEqual(item.Status, returnedItem.Status);
        }

        [TestMethod]
        public async Task TestCreateItemsAsync3()
        {
            var item = new Item
            {
                Id = "96cd7412-0aef-4631-a85d-17d1f55c630o",
                Student_Number = "45896354",
                First_Name = "testName3",
                Last_Name = "testDescription3",
                Email = "hello@email3.com",
                Home_Address = "testCategory3",
                Mobile = "4785362458",
                Photo_Path = "http...................3",
                Status = true
            };

            // Create the item
            await DocumentDBRepository<Item>.CreateItemAsync(item);
            // Query for the item
            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);
            // Verify the item returned is correct.
            Assert.AreEqual(item.Id, returnedItem.Id);
            Assert.AreEqual(item.Student_Number, returnedItem.Student_Number);
            Assert.AreEqual(item.First_Name, returnedItem.First_Name);
            Assert.AreEqual(item.Last_Name, returnedItem.Last_Name);
            Assert.AreEqual(item.Email, returnedItem.Email);
            Assert.AreEqual(item.Home_Address, returnedItem.Home_Address);
            Assert.AreEqual(item.Mobile, returnedItem.Mobile);
            Assert.AreEqual(item.Photo_Path, returnedItem.Photo_Path);
            Assert.AreEqual(item.Status, returnedItem.Status);
        }


        [TestMethod]
        public async Task TestCreateItemsAsync4()
        {
            var item = new Item
            {
                Id = "96cd7412-0aef-4631-a85d-17d1f55c630u",
                Student_Number = "45896354",
                First_Name = "testName3",
                Last_Name = "testDescription3",
                Email = "hello@email3.com",
                Home_Address = "testCategory3",
                Mobile = "4785362458",
                Photo_Path = "http...................3",
                Status = true
            };

            // Create the item
            await DocumentDBRepository<Item>.CreateItemAsync(item);
            // Query for the item
            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);
            // Verify the item returned is correct.
            Assert.AreEqual(item.Id, returnedItem.Id);
            Assert.AreEqual(item.Student_Number, returnedItem.Student_Number);
            Assert.AreEqual(item.First_Name, returnedItem.First_Name);
            Assert.AreEqual(item.Last_Name, returnedItem.Last_Name);
            Assert.AreEqual(item.Email, returnedItem.Email);
            Assert.AreEqual(item.Home_Address, returnedItem.Home_Address);
            Assert.AreEqual(item.Mobile, returnedItem.Mobile);
            Assert.AreEqual(item.Photo_Path, returnedItem.Photo_Path);
            Assert.AreEqual(item.Status, returnedItem.Status);
        }

        [TestMethod]
        public async Task TestCreateItemsAsync5()
        {
            var item = new Item
            {
                Id = "942b1512-1d1e-4c8a-8199-878bdc0395d8",
                Student_Number = "21833736",
                First_Name = "Akhie",
                Last_Name = "Ishwarlaal",
                Email = "s3akhil@gmail.com",
                Home_Address = "Suncoast",
                Mobile = "0767619968",
                Photo_Path = "http...................",
                Status = true
            };

            // Create the item
            await DocumentDBRepository<Item>.CreateItemAsync(item);
            // Query for the item
            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);
            // Verify the item returned is correct.
            Assert.AreEqual(item.Id, returnedItem.Id);
            Assert.AreEqual(item.Student_Number, returnedItem.Student_Number);
            Assert.AreEqual(item.First_Name, returnedItem.First_Name);
            Assert.AreEqual(item.Last_Name, returnedItem.Last_Name);
            Assert.AreEqual(item.Email, returnedItem.Email);
            Assert.AreEqual(item.Home_Address, returnedItem.Home_Address);
            Assert.AreEqual(item.Mobile, returnedItem.Mobile);
            Assert.AreEqual(item.Photo_Path, returnedItem.Photo_Path);
            Assert.AreEqual(item.Status, returnedItem.Status);
        }


        [TestMethod]
        public async Task TestEditItemsAsync()
        {
            var item = new Item
            {
                Id = "942b1512-1d1e-4c8a-8199-878bdc0395d8",
                Student_Number = "21833736",
                First_Name = "Akhie",
                Last_Name = "Ishwarlaal",
                Email = "s3akhil@gmail.com",
                Home_Address = "Suncoast",
                Mobile = "0767619968",
                Photo_Path = "http...................",
                Status = true
            };

            await DocumentDBRepository<Item>.CreateItemAsync(item);

            var edititem = new Item
            {
                Id = "942b1512-1d1e-4c8a-8199-878bdc0395d8",
                Student_Number = "21833736",
                First_Name = "Akhil",
                Last_Name = "Ishwarlaal",
                Email = "s3akhil@gmail.com",
                Home_Address = "Suncoast",
                Mobile = "0767619968",
                Photo_Path = "http...................",
                Status = true
            };
            // Create the item
           
            // update the item
            await DocumentDBRepository<Item>.UpdateItemAsync(item.Id, edititem);
            // Query for the item
            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);
            // Verify the item returned is correct.
            Assert.AreEqual(edititem.Id, returnedItem.Id);
            Assert.AreEqual(edititem.Student_Number, returnedItem.Student_Number);
            Assert.AreEqual(edititem.First_Name, returnedItem.First_Name);
            Assert.AreEqual(edititem.Last_Name, returnedItem.Last_Name);
            Assert.AreEqual(edititem.Email, returnedItem.Email);
            Assert.AreEqual(edititem.Home_Address, returnedItem.Home_Address);
            Assert.AreEqual(edititem.Mobile, returnedItem.Mobile);
            Assert.AreEqual(edititem.Photo_Path, returnedItem.Photo_Path);
            Assert.AreEqual(edititem.Status, returnedItem.Status);
            

        }

        [TestMethod]
        public async Task TestDeleteConfirmedAsync()
        {
            var item = new Item
            {
                Id = "96cd7412-0aef-4631-a85d-17d1f55c630h",
                Student_Number = "45896354",
                First_Name = "testName3",
                Last_Name = "testDescription3",
                Email = "hello@email3.com",
                Home_Address = "testCategory3",
                Mobile = "4785362458",
                Photo_Path = "http...................3",
                Status = true
            };

            // Create the item
            await DocumentDBRepository<Item>.CreateItemAsync(item);

            // Delete the item
            


            
            await DocumentDBRepository<Item>.DeleteItemAsync(item.Id, item.Student_Number);
            var returnedItem = await DocumentDBRepository<Item>.GetItemAsync(item.Id, item.Student_Number);

            // Verify the item returned is correct.
            Assert.IsNull(returnedItem);

        }






        [TestCleanup()]
        public void Cleanup()
        {
            DocumentDBRepository<Item>.Teardown();
        }

    }
}
