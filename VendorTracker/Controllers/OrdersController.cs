using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VendorTracker.Models;

namespace VendorTracker.Controllers;

[Route("vendors/{vendorId}/orders")]
public class OrdersController : Controller
{

  [HttpGet("new")]
  public ActionResult New(int vendorId)
  {
    Vendor vendor = Vendor.Find(vendorId);
    return View(vendor);
  }

  [HttpGet("{orderId}")]
  public ActionResult Show(int vendorId, int orderId)
  {
    Order order = Order.Find(orderId);
    Vendor vendor = Vendor.Find(vendorId);
    Dictionary<string, object> model = new Dictionary<string, object>();
    model.Add("order", order);
    model.Add("vendor", vendor);
    return View(model);
  }
}