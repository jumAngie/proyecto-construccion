using Construccion.BusinessLogic.Services;
using Construccion.DataAccess;
using Construccion.DataAccess.Repositories.Acce;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connection)
        {
            services.AddScoped<RolesRepository>();
            services.AddScoped<UsuariosRepository>();
            ConstruccionCon.BuildConnectionString(connection);
        }


        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<AccessService>();
            
        }
    }
}
