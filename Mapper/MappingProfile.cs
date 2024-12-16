using AutoMapper;
using DominModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.DTOS;
using ViewModel.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoggingSystemTask.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map LogEntry to ViewModel
            CreateMap<Log, LogViewModel>();

            // Map DTO to LogEntry (for Create/Update)
            //CreateMap<LogDTO, Log>();

            CreateMap<LogDTO, Log>()
           .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id since it's auto-generated
           .ForMember(dest => dest.CreatedOn, opt => opt.Ignore()); 
        }
    }
}
