using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ImageWithText> images = new DB().GetImages();
            return View(images);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase image, string text)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            image.SaveAs(Server.MapPath("~/Images") + "/" + fileName);
            DB db = new DB();
            db.Add(text, fileName);
            return Redirect("/home/index");
        }
    }


    //Title
    //Description
    //Name optional/nullable
    //Phone Number
    //ImageFileName
    //Date Listed

    //On the home page, show all the listings, but show only the title, image and date listed.
    //Next to each listing, there should be a show details button

    //When the show details button is clicked, the user should be taken to a page that shows
    //all the information of that listing. If the person viewing the listing is also the one that
    //listed it, there should be a delete button underneath to delete that listing.

    //There should also be a page to add a listing (you can add a link for this in the top navbar
    //of the site). On this page, there should be a form where users can submit new listings,
    //inluding uploading of the image
}