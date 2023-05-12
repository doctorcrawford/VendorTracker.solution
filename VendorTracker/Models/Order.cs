using System;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public DateOnly Date { get; set; }

    public Order(string title, string description, float price, DateOnly date)
    {
      Title = title;
      Description = description;
      Price = price;
      Date = date;
    }
  }
}