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

    [TestMethod]
    public void GetTitle_ReturnsName_String()
    {
      DateOnly orderDate = new DateOnly(2023, 5, 12);
      Order newOrder = new Order("Bread", "7 loaves of sourdough", 15.50F, orderDate);
      string expected = "Bread";
      Assert.AreEqual(expected, newOrder.Title);
    }

    [TestMethod]
    public void GetDate_ReturnsDate_DateOnly()
    {
      DateOnly orderDate = new DateOnly(2023, 5, 12);
      Order newOrder = new Order("Bread", "7 loaves of sourdough", 15.50F, orderDate);
      DateOnly expected = new DateOnly(2023, 5, 12);
      Assert.AreEqual(expected, newOrder.Date);
    }
  }
}