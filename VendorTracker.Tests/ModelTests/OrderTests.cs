using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

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

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> { };
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      DateOnly orderDate1 = new DateOnly(2023, 5, 12);
      DateOnly orderDate2 = new DateOnly(2023, 5, 3);
      Order newOrder1 = new Order("Bread", "7 loaves of sourdough", 15.50F, orderDate1);
      Order newOrder2 = new Order("Pastries", "4 muffins, 2 croissants", 22.40F, orderDate2);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      DateOnly orderDate1 = new DateOnly(2023, 5, 12);
      DateOnly orderDate2 = new DateOnly(2023, 5, 3);
      Order newOrder1 = new Order("Bread", "7 loaves of sourdough", 15.50F, orderDate1);
      Order newOrder2 = new Order("Pastries", "4 muffins, 2 croissants", 22.40F, orderDate2);
      Order result = Order.Find(2);
      Assert.AreEqual(newOrder2, result);
    }
  }
}