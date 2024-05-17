using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventoryManagementSystem.Context;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class InventoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = db.Items.Find(id);
            ItemDetails itemToPass = new ItemDetails();
            itemToPass.Item_ID = item.Item_ID;
            itemToPass.Item_Name = item.Item_Name;
            itemToPass.Item_Description = item.Item_Description;
            itemToPass.Item_Amount = item.Item_Amount;
            itemToPass.Item_InputDate = item.Item_InputDate;
            itemToPass.Purchases = db.Purchases.Where(a => a.item.Item_ID == id).OrderByDescending(a => a.Purchase_Date).ToList();
            itemToPass.Sales = db.Sales.Where(a => a.item.Item_ID == id).OrderByDescending(a => a.Sale_Date).ToList();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(itemToPass);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item_ID,Item_Name,Item_Description,Item_Amount,Item_InputDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.Item_InputDate = DateTime.Now;
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item_ID,Item_Name,Item_Description,Item_Amount,Item_InputDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RemoveAddAmount(int? id, bool isAdd = true)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = db.Items.Find(id);
            RemoveAddItemAmount itemToPass = new RemoveAddItemAmount();
            itemToPass.Item_ID = item.Item_ID;
            itemToPass.Item_Name = item.Item_Name;
            itemToPass.Item_Description = item.Item_Description;
            itemToPass.Item_Amount = item.Item_Amount;
            itemToPass.Item_InputDate = item.Item_InputDate;
            itemToPass.RemoveAddAmount = 0;
            itemToPass.isAdd = isAdd ? true : false;

            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.isAdd = isAdd;

            return View(itemToPass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveAddAmount([Bind(Include = "Item_ID,Item_Name,Item_Description,Item_Amount,Item_InputDate,RemoveAddAmount,isAdd")] RemoveAddItemAmount item)
        {
            if (ModelState.IsValid)
            {
                if (item.isAdd)
                {
                    Purchase add = new Purchase();
                    add.Purchase_Amount = item.RemoveAddAmount;
                    add.Purchase_Date = DateTime.Now;
                    add.item = db.Items.Find(item.Item_ID);
                    db.Purchases.Add(add);
                    db.SaveChanges();

                    Item itemToModify = db.Items.Find(item.Item_ID);
                    itemToModify.Item_Amount = item.Item_Amount + item.RemoveAddAmount;
                    db.Entry(itemToModify).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Sale remove = new Sale();
                    remove.Sale_Amount = item.RemoveAddAmount;
                    remove.Sale_Date = DateTime.Now;
                    remove.item = db.Items.Find(item.Item_ID);
                    db.Sales.Add(remove);
                    db.SaveChanges();

                    Item itemToModify = db.Items.Find(item.Item_ID);
                    itemToModify.Item_Amount = item.Item_Amount - item.RemoveAddAmount;
                    db.Entry(itemToModify).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
