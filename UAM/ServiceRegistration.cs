using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UAM.Handlers.Query_Handlers;
using UAM.Mapping_Profiles;
using UAM.Services;

namespace UAM
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterUamService(this IServiceCollection services)
        {
            #region Mapping Profiles

            services.AddAutoMapper(typeof(UamAutoMapperProfile).Assembly);

            #endregion

            #region Services

            services.AddScoped<IUamService, UamService>();


            #endregion

            #region Validators



            #endregion

            #region Handlers

            services.AddMediatR(Assembly.GetExecutingAssembly());
           
            #endregion



            return services;
        }
    }
}
