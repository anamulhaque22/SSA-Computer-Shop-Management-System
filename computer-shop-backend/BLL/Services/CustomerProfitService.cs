using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerProfitService
    {
        public static bool Create(CustomerProfitDTO data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerProfitDTO, CustomerProfit>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<CustomerProfit>(data);
            return DataAccessFactory.CustomerProfitData().Create(cData);
        }
        public static bool Delete(int Id)
        {
            return DataAccessFactory.CustomerProfitData().Delete(Id);
        }
        public static List<CustomerProfitDTO> Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerProfit, CustomerProfitDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.CustomerProfitData().Get();
            var cData = mapper.Map<List<CustomerProfitDTO>>(data);
            return cData;
        }
        public static CustomerProfitDTO Get(int CusId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerProfit, CustomerProfitDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CustomerProfitDTO>(DataAccessFactory.CustomerProfitData().Get(CusId));
        }
        public static List<CustomerProfitDTO> GetTop3Customers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerProfit, CustomerProfitDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CustomerProfitDTO>>(DataAccessFactory.TopCustomersData().GetTop3Customers());
        }
        public static bool SaveCustomerProfit(int OrderId)
        {
            List<OrderDetail> orderDetails = DataAccessFactory.OrderDetailData().Get(OrderId);
            int cusId = DataAccessFactory.OrderData().Read(OrderId).CustomerId;
            int profit = 0; 
            foreach (var orderDetail in orderDetails)
            {
                profit += (orderDetail.UnitPrice - orderDetail.UnitCostPrice);
            }
            var currData = DataAccessFactory.CustomerProfitData().Get(cusId);
            if (currData == null)
            {
                CustomerProfit customerProfit = new CustomerProfit();
                customerProfit.CusId = cusId;
                customerProfit.TotalProfit = profit;
                return DataAccessFactory.CustomerProfitData().Create(customerProfit);
            }
            currData.TotalProfit += profit;
            return DataAccessFactory.TopCustomersData().Update(currData);
        }
        public static int GetActiveCustomerCount()
        {
            return DataAccessFactory.CustomerProfitData().Get().Count();
        }
    }
}
