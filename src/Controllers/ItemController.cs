﻿namespace todo.Controllers
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Models;
    using OfficeOpenXml;
    using todo.Models;

    [System.Web.Mvc.Authorize]

    public class ItemController : Controller
    {
        //[ActionName("Index")]
        //public async Task<ActionResult> IndexAsync()
        //{
        //    var items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Status);
        //    return View(items);
        //}
        ImageService imageService = new ImageService();

        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync(string option, string search, string Status)
        {
            var items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Status);

            if (option == "StudentNum" && Status == "InActive")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => !d.Status && d.Student_Number.ToLower().StartsWith(search.ToLower())));
            }
            else if (option == "FirstName" && Status == "InActive")
            {
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => !d.Status && d.First_Name.ToLower().StartsWith(search.ToLower())));
            }
            else if (option == "LastName" && Status == "InActive")
            {
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => !d.Status && d.Last_Name.ToLower().StartsWith(search.ToLower())));
            }

            else if (option == "StudentNum" && Status == "Active")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Status && d.Student_Number.ToLower().StartsWith(search.ToLower())));
            }
            else if (option == "FirstName" && Status == "Active")
            {
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Status && d.First_Name.ToLower().StartsWith(search.ToLower())));
            }
            else if(option == "LastName" && Status == "Active")
            {
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Status && d.Last_Name.ToLower().StartsWith(search.ToLower())));
            }

            else if (option == "StudentNum" && Status == "All")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Student_Number.ToLower().StartsWith(search.ToLower())));
            }
            else if (option == "FirstName" && Status == "All")
            {
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.First_Name.ToLower().StartsWith(search.ToLower())));
            }
            else if (option == "LastName" && Status == "All")
            {
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Last_Name.ToLower().StartsWith(search.ToLower())));
            }

            else
            {
                return View(items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Status || !d.Status));
            }

        }













#pragma warning disable 1998
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }
#pragma warning restore 1998

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync( Item item,HttpPostedFileBase photo)
        {
            var user = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Student_Number == item.Student_Number);

            if (user.FirstOrDefault() != null)
            {

                ModelState.AddModelError("Student_Number", "Student Number Already Exists");
                return View(item);


            }



                if (ModelState.IsValid)
            {
                var imageUrl = await imageService.UploadImageAsync(photo);
                if (photo != null)
                {
                    item.Photo_Path = imageUrl.ToString();
                }
                await DocumentDBRepository<Item>.CreateItemAsync(item);
                
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(Item item, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {

                if (photo == null || photo.ContentLength == 0)
                {

                }
                else
                {
                    var imageUrl = await imageService.UploadImageAsync(photo);

                    item.Photo_Path = imageUrl.ToString();
                }
                await DocumentDBRepository<Item>.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }



        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id, string student_no)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = await DocumentDBRepository<Item>.GetItemAsync(id, student_no);
            if (item == null)
            {
                return HttpNotFound();
            }

                        if(item.Photo_Path != null)
            {

                ViewBag.Image = "True";

            }
            else
            {

                ViewBag.Image = "False";

            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string student_no)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = await DocumentDBRepository<Item>.GetItemAsync(id, student_no);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmedAsync(string id, string student_no)
        {
            await DocumentDBRepository<Item>.DeleteItemAsync(id, student_no);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id, string student_no)
        {
            Item item = await DocumentDBRepository<Item>.GetItemAsync(id, student_no);
            if(item.Photo_Path != null)
            {

                ViewBag.Image = "True";

            }
            else
            {

                ViewBag.Image = "False";

            }
            return View(item);
        }





        [ActionName("EmailTheStudent")]
        public async Task<ActionResult> EmailTheStudent(string id, string student_no)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = await DocumentDBRepository<Item>.GetItemAsync(id, student_no);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        [HttpPost]
        [ActionName("EmailTheStudent")]
        public async Task<ActionResult> EmailConfirmTheStudent(string id, string student_no)
        {

            ExcelEmail excelemail = new ExcelEmail();


            Task.Run(async () => { await excelemail.EmailExcel(id, student_no); }).Wait();



            Item item = await DocumentDBRepository<Item>.GetItemAsync(id, student_no);
            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.Email = "Email Sent Successfully";

            return View(item);





        }











    }













}