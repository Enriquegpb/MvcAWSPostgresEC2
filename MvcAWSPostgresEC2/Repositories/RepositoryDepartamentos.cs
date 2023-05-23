using Microsoft.EntityFrameworkCore;
using MvcAWSPostgresEC2.Data;
using MvcAWSPostgresEC2.Models;

namespace MvcAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> FindDepartamentoAsync(int iddepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(d => d.IdDepartamento == iddepartamento);
        }

        public async Task NewDepartamentoAsync(int iddepartamento, string nombre, string localidad)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = iddepartamento,
                Localidad = localidad,
                Nombre = nombre,
            };
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
