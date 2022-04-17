using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mapper
{
    public interface IWebProjectMapper
    {
        /// <summary>
        /// Configuration Provide
        /// </summary>
        IConfigurationProvider ConfigurationProvider { get; }

        /// <summary>
        /// Converts an object to target type object <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the object</typeparam>
        /// <param name="source">Source object</param>
        /// <returns>Result object</returns>
        T Map<T>(object source);

        /// <summary>
        /// Converts an object to target type object<typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Target type</typeparam>
        /// <param name="source">Source object</param>
        /// <param name="destination">Target object</param>
        void Map<TSource, TDestination>(TSource source, TDestination destination);
   
}
}
