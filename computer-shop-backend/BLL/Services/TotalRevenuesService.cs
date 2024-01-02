using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TotalRevenuesService
    {
        public static bool Create(TotalRevenueDTO data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalRevenueDTO, TotalRevenue>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<TotalRevenue>(data);
            return DataAccessFactory.TotalRevenueData().Create(cData);
        }
        public static bool Delete(int Year)
        {
            return DataAccessFactory.TotalRevenueData().Delete(Year);
        }
        public static List<TotalRevenueDTO> Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalRevenue, TotalRevenueDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.TotalRevenueData().Get();
            var cData = mapper.Map<List<TotalRevenueDTO>>(data);
            return cData;
        }
        public static TotalRevenueDTO Get(int Year)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalRevenue, TotalRevenueDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<TotalRevenueDTO>(DataAccessFactory.TotalRevenueData().Get(Year));
        }
        public static bool Update(TotalRevenueDTO obj)
        {
            var pData = DataAccessFactory.TotalRevenueData().Get(obj.Year);
            if (pData == null) { return false; }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalRevenueDTO, TotalRevenue>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<TotalRevenue>(obj);

            if (cData.Jan != 0)
            {
                pData.Jan = cData.Jan;
            }
            else if(cData.Feb != 0)
            {
                pData.Feb = cData.Feb;
            }
            else if (cData.Mar != 0)
            {
                pData.Mar = cData.Mar;
            }
            else if (cData.Apr != 0)
            {
                pData.Apr = cData.Apr;
            }
            else if (cData.May != 0)
            {
                pData.May = cData.May;
            }
            else if (cData.Jun!= 0)
            {
                pData.Jun = cData.Jun;
            }
            else if (cData.Jul != 0)
            {
                pData.Jul = cData.Jul;
            }
            else if (cData.Aug != 0)
            {
                pData.Aug = cData.Aug;
            }
            else if (cData.Sep != 0)
            {
                pData.Sep = cData.Sep;
            }
            else if (cData.Nov != 0)
            {
                pData.Nov = cData.Nov;
            }
            else if (cData.Dec!= 0)
            {
                pData.Dec = cData.Dec;
            }
            return DataAccessFactory.UpdateTotalRevenue().Update(pData);
        }
        public static bool CalculateAndSaveRevenue(int OrderId)
        {
            List<OrderDetail> orderDetails = DataAccessFactory.OrderDetailData().Get(OrderId);
            int profit = 0;
            foreach (var orderDetail in orderDetails)
            {
                profit += (orderDetail.UnitPrice - orderDetail.UnitCostPrice)*orderDetail.Quantity;
            }
            int currentYear = DateTime.Now.Year;
            var currRevData = DataAccessFactory.TotalRevenueData().Get(currentYear);
            if (currRevData == null)
            {
                TotalRevenue totalRevenue = new TotalRevenue();
                totalRevenue.Year = currentYear;
                DataAccessFactory.TotalRevenueData().Create(totalRevenue);
                currRevData = totalRevenue;
            }
            int currentMonth = DateTime.Now.Month;
            currRevData.Year = currentYear;

            if (currentMonth == 1)
            {
                currRevData.Jan += profit;
            }
            else if (currentMonth == 2)
            {
                currRevData.Feb += profit;
            }
            else if (currentMonth == 3)
            {
                currRevData.Mar += profit;
            }
            else if (currentMonth == 4)
            {
                currRevData.Apr += profit;
            }
            else if (currentMonth == 5)
            {
                currRevData.May += profit;
            }
            else if (currentMonth == 6)
            {
                currRevData.Jun += profit;
            }
            else if (currentMonth == 7)
            {
                currRevData.Jul += profit;
            }
            else if (currentMonth == 8)
            {
                currRevData.Aug += profit;
            }
            else if (currentMonth == 9)
            {
                currRevData.Sep += profit;
            }
            else if (currentMonth == 10)
            {
                currRevData.Oct += profit;
            }
            else if (currentMonth == 11)
            {
                currRevData.Nov += profit;
            }
            else if (currentMonth == 12)
            {
                currRevData.Dec += profit;
            }
            return DataAccessFactory.UpdateTotalRevenue().Update(currRevData);
        }
    }
}
