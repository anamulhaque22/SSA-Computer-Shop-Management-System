using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
        public static CustomerDTO Registration(CustomerRegistrationDTO obj)
        {
            var data = DataAccessFactory.CustomerData().Create(new DAL.EF.Models.Customer
            {
                Name = obj.Name,
                Email = obj.Email,
                password = obj.password,
                Phone = obj.Phone,
                Address = obj.Address,
            });

            return data != null ? new CustomerDTO
            {
                Id = data.Id,
                Name = data.Name,
                Email = data.Email,
                Address = data.Address,
                Phone = data.Phone,
            }: null;
        }

        public static bool DeleteCustomer(int id)
        {
            return DataAccessFactory.CustomerData().Delete(id);
        }

        public static CustomerDTO GetCustomer(int id)
        {
            var data = DataAccessFactory.CustomerData().Read(id);
            return data != null ? new CustomerDTO
            {
                Id = data.Id,
                Name = data.Name,
                Email = data.Email,
                Address = data.Address,
                Phone = data.Phone,
            }: null;
        }

        public static List<CustomerDTO> GetAllCustomer()
        {
            var data = DataAccessFactory.CustomerData().Read();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<CustomerDTO>>(data);
            return cnvrt;
        }

        public static CustomerDTO UpdateCustomer(CustomerUpdateDTO c)
        {
            var data = DataAccessFactory.CustomerData().Update(new Customer
            {
                Id= c.Id,
                Name= c.Name,
                Address= c.Address,
                Phone = c.Phone,
            });
            return data != null ? new CustomerDTO
            {
                Id = data.Id,
                Name = data.Name,
                Email = data.Email,
                Address = data.Address,
                Phone = data.Phone,
            }: null;
        }
    }
}
