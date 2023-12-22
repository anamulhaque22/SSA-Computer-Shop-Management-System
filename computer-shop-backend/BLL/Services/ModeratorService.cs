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
    public class ModeratorService
    {
        public static List<ModeratorDTO> Get()
        {
            var data = DataAccessFactory.ModeratorData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Moderator, ModeratorDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ModeratorDTO>>(data);
            return mapped;
        }

        public static ModeratorDTO Get(int id)
        {
            var data = DataAccessFactory.ModeratorData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Moderator, ModeratorDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ModeratorDTO>(data);
            return mapped;

        }

        public static MSalaryDTO Getwithsalary(int id)
        {
            var data = DataAccessFactory.ModeratorData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Moderator, MSalaryDTO>();
                c.CreateMap<Salary, SalaryDTO>();

            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<MSalaryDTO>(data);
            return mapped;

        }

        public static MAttendanceReportDTO GetWithAttenden(int id)
        {

            var data = DataAccessFactory.ModeratorData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Moderator, MAttendanceReportDTO>();
                c.CreateMap<AttendanceReport, AttendanceReportDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<MAttendanceReportDTO>(data);
            return mapped;
        }

        public static bool Create(ModeratorDTO moderator)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ModeratorDTO, Moderator>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Moderator>(moderator);
            var res = DataAccessFactory.ModeratorData().Create(mapped);
            if (res) return true;
            return false;
        }

        public static bool Update(ModeratorDTO moderator)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ModeratorDTO, Moderator>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<Moderator>(moderator);
            var res = DataAccessFactory.ModeratorData().Update(mapped);
            if (res) return true;
            return false;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ModeratorData().Delete(id);
        }


        public static bool ChangePassword(int id, ChangePasswordDTO changePasswordDTO)

        {
            var moderator = DataAccessFactory.ModeratorData().Read(id);
            if (changePasswordDTO.CurrentPassword == moderator.Password)
            {
                return DataAccessFactory.ChangePassData().ChangePassword(moderator.Id, changePasswordDTO.Password);
            }
            return false;
        }
    }
}
