using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mar3HW.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCountry { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }


    public class NorthwindManager
    {
        private readonly string _connectionString;

        public NorthwindManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetOrders()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT o.OrderId, o.OrderDate, o.ShipAddress, o.ShipCountry, SUM(od.UnitPrice * od.Quantity) AS 'OrderTotal'
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.OrderId, o.OrderDate, o.ShipAddress, o.ShipCountry";
            connection.Open();
            List<Order> orders = new List<Order>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    Id = (int)reader["OrderId"],
                    Date = (DateTime)reader["OrderDate"],
                    ShipAddress = (string)reader["ShipAddress"],
                    ShipCountry = (string)reader["ShipCountry"],
                    Total = (decimal)reader["OrderTotal"]
                });
            }
            connection.Close();
            return orders;
        }

        public List<OrderDetail> GetOrderDetails1997()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT od.*
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE DATEPART(YEAR, o.OrderDate) = 1997";
            connection.Open();
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orderDetails.Add(new OrderDetail
                {
                    OrderId = (int)reader["OrderId"],
                    ProductId = (int)reader["ProductId"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    Quantity = (short)reader["Quantity"]
                });
            }
            connection.Close();
            return orderDetails;
        }
    }
}