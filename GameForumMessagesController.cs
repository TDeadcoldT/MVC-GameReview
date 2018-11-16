using mvcGameReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcGameReview.Controllers
{
    public class GameForumMessagesController : Controller
    {
        //
        // GET: /GameForumMessages/

        public ActionResult Index()
        {
            var db = new GameForumMessagesDataContext();
            var f_messages = db.GameForumMessages.ToArray();

            return View(f_messages);
        }

        public ActionResult GameForumMessage(long id)
        {
            var db = new GameForumMessagesDataContext();
            var f_message = db.GameForumMessages.Find(id);

            return View(f_message);
        }
    [HttpGet]
        [Authorize(Users = "Admin")]
        public ActionResult Edit(long id)
        {
            var db = new GameForumMessagesDataContext();
            var f_message = db.GameForumMessages.Find(id);

            return View(f_message);
        }

        [HttpPost]
        [Authorize(Users = "Admin")]
        public ActionResult Edit([Bind]Models.GameForumMessage FMsg)
    {
            if (ModelState.IsValid)
            {
                var db = new GameForumMessagesDataContext();
                db.Entry(FMsg).State = System.Data.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return Edit(FMsg.Id);
    }
        [HttpGet]
    [Authorize(Users = "Admin")]
        public ActionResult Delete(long id)
        {
            var db = new GameForumMessagesDataContext();
            var f_message = db.GameForumMessages.Find(id);

            return View(f_message);
        }
        [HttpPost]
        [Authorize(Users = "Admin")]
        public ActionResult Delete([Bind]Models.GameForumMessage FMsg)
        {
            var db = new GameForumMessagesDataContext();
            db.Entry(FMsg).State = System.Data.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind]Models.GameForumMessage FMsg)
        {
            if (ModelState.IsValid)
            {
                //Save to the database
                FMsg.MessageDate = DateTime.Now;
                FMsg.Approved = false;
                var db = new GameForumMessagesDataContext();
                db.GameForumMessages.Add(FMsg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Create();

        }
        [Authorize(Users = "Admin")]
        public ActionResult Admin()
        {
            var db = new GameForumMessagesDataContext();
            var f_messages = db.GameForumMessages.ToArray();

            return View();
        }
    }
}
