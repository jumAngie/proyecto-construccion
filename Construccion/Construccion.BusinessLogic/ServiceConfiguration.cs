using Construccion.BusinessLogic.Services;
using Construccion.DataAccess;
using Construccion.DataAccess.Repositories.Acce;
using Construccion.DataAccess.Repositories.Cons;
using Construccion.DataAccess.Repositories.Gral;
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
            // ACCE
            services.AddScoped<RolesRepository>();
            services.AddScoped<UsuariosRepository>();
            services.AddScoped<PantallasRepository>();
            services.AddScoped<RolesPorPantallaRepository>();

            // CONS
            services.AddScoped<ClientesRepository>();
            services.AddScoped<ConstruccionesRepository>();
            services.AddScoped<EmpleadosPorConstruccionRepository>();
            services.AddScoped<IncidenciasRepository>();
            services.AddScoped<InsumosRepository>();
            services.AddScoped<UnidadesMedidaRepository>();
            services.AddScoped<InsumosConstruccionRepository>();
            services.AddScoped<CargosRepository>();

            // GRAL
            services.AddScoped<DepartamentosRepository>();
            services.AddScoped<EmpleadosRepository>();
            services.AddScoped<EstadosCivilesRepository>();
            services.AddScoped<MunicipiosRepository>();



            ConstruccionCon.BuildConnectionString(connection);

        }


        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<AccessService>();
            services.AddScoped<ConstruccionServices>();
            services.AddScoped<GeneralesService>();
            
        }
    }
}
