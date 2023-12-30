using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class TaskService
    {
        public static bool Create(TaskDTO data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDTO, Task>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<Task>(data);
            return DataAccessFactory.TaskData().Create(cData);
        }
        public static bool Delete(int Id)
        {
            return DataAccessFactory.TaskData().Delete(Id);
        }
        public static List<TaskDTO> Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.TaskData().Get();
            var cData = mapper.Map<List<TaskDTO>>(data);
            return cData;
        }
        public static TaskDTO Get(int Id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<TaskDTO>(DataAccessFactory.TaskData().Get(Id));
        }
    }
}
