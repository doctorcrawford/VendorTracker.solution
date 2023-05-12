using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorTracker.Tests
{
  [TestClass]
  public class OrderTests
  {
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      DateOnly orderDate = new DateOnly(2023, 5, 12);
      Order newOrder = new Order("Bread", "7 loaves of sourdough", 15.50F, orderDate);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
  }
}