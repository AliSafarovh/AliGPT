using AutoMapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.DTOs.Groups;
using UniversityApi.Data.DTOs.Student;
using UniversityApi.Data.Entities;

namespace UniversityApi.Data.Mappers
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Group, GroupGetDTO>().ReverseMap();
            CreateMap<GroupPostDTO, Group>();

            CreateMap<Student, StudentGetDTO>()
                .ForMember(src => src.Image, dest => dest.MapFrom(x => "https://localhost:7102/students/" + x.Image))
                .ReverseMap();
            CreateMap<StudentPostDTO, Student>();
        }
    }
}

