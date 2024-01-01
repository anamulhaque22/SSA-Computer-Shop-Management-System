using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Criteria;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        public static bool CreateOrder(OrderDTO obj)
        {
            
            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderAddress = obj.OrderAddress,
                CustomerId = obj.CustomerId,
                OrderNote = obj.OrderNote,
                OrderDetails = new List<OrderDetail>()
            };
            foreach (var od in obj.OrderDetails)
            {
                var product = DataAccessFactory.ProductData().Read(od.ProductId);
                if (product != null)
                {
                    var orderDetail = new OrderDetail
                    {
                        ProductId = od.ProductId,
                        Quantity = od.Quantity,
                        UnitPrice = product.ProductPrice,
                        UnitCostPrice = product.CostPrice
                    };
                    order.OrderDetails.Add(orderDetail);
                }
            }
            var totalAmount = order.OrderDetails.Sum(od => od.UnitPrice * od.Quantity);
            order.TotalAmount = totalAmount;
            order.SetStatusPending();
            order.SetPaymentStatusPending();
            DataAccessFactory.OrderData().Create(order);
            return true;
        }

        public static bool ChangeOrderStatus(OrderStatusDTO os)
        {

            return DataAccessFactory.OrderStatusData().ChangeOrderStatus(new OrderStatus
            {
                OrderId = os.OrderId,
                Status = os.Status,
            });
        }

        public static List<OrderGetDTO> GetAllOrder()
        {
            var data = DataAccessFactory.OrderData().Read();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderGetDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<OrderGetDTO>>(data);
            return cnvrt;
        }
        
        public static SingleOrderDetailsDTO GetSingleOrder(int orderId)
        {
            var data = DataAccessFactory.OrderData().Read(orderId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, SingleOrderDetailsDTO>();
                cfg.CreateMap<OrderDetail, OrderDetailsGetDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<SingleOrderDetailsDTO>(data);
            /*if( data != null)
            {
                var orderDetails = new SingleOrderDetailsDTO
                {
                    Id = data.Id,
                    CustomerId = data.CustomerId,
                    OrderAddress = data.OrderAddress,
                    OrderStatus = data.OrderStatus,
                    OrderNote = data.OrderNote,
                    OrderDate = data.OrderDate,
                    OrderDetails = (List<OrderDetailsGetDTO>)data.OrderDetails
                };
                return orderDetails;
            }*/
            return cnvrt;
        }
        
        public static List<OrderGetDTO> CustomerOrderList(int customerId)
        {
            var data = DataAccessFactory.CustomerOrderData().CustomerOrders(customerId);
            if(data != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Order, OrderGetDTO>();
                });
                var mapper = new Mapper(config);
                var cnvrt = mapper.Map<List<OrderGetDTO>>(data);
                return cnvrt;
            }
            return null;
        }
    }
}
