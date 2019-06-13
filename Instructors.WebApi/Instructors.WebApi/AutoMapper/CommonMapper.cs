using System;
using System.Text;
using AutoMapper;
using Instructors.WebApi.Data.Models;
using Instructors.WebApi.Models;

namespace Instructors.WebApi.AutoMapper
{
    public class CommonMapper : ICommonMapper
    {
        public IMapper Mapper { get; set; }

        public CommonMapper()
        {
            MapperConfiguration config = GetConfiguration();
            Mapper = config.CreateMapper();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public T Map<T>(object source) where T : class
        {
            return (T)Mapper.Map(source, source.GetType(), typeof(T));
        }


        private MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Instructor, InstructorDto>();
                cfg.CreateMap<InstructorDto, Instructor>();
            });
        }
    }
}
