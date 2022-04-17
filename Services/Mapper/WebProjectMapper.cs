using AutoMapper;
using Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mapper
{
    public class WebProjectMapper : IWebProjectMapper
    {
        /// <summary>
        /// Set config
        /// </summary>
        public WebProjectMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDto, TaskModel>();
                cfg.CreateMap<TaskModel, TaskDto>();
                cfg.CreateMap<TaskCreateDto, TaskModel>();

                cfg.CreateMap<ProjectDto, ProjectModel>();
                cfg.CreateMap<ProjectModel, ProjectDto>();
                cfg.CreateMap<ProjectCreateDto, ProjectModel>();           

            });

            Mapper = config.CreateMapper(); 
        }

        protected IMapper Mapper { get; set; }

        public IConfigurationProvider ConfigurationProvider => Mapper.ConfigurationProvider;

        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }

    }
}
