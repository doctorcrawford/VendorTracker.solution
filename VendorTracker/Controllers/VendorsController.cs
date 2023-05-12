using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDescription)
    {
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorItems = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorItems);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderTitle, string orderDescription, float orderPrice, DateTime orderDate)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      DateOnly orderDateOnly = DateOnly.FromDateTime(orderDate);
      Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDateOnly);
      foundVendor.AddOrder(newOrder);
      List<Order> categoryOrders = foundVendor.Orders;
      model.Add("vendor", foundVendor);
      model.Add("orders", categoryOrders);
      return View("Show", model);
    }

  }
}