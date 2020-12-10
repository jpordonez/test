using Negocio.Dominio.Models;
using Negocio.Dominio.Criteria;
using Framework;
using System.Collections.Generic;

namespace Negocio.Service
{
    public interface IComponenteEducativoService
    {

        IList<ComponenteEducativo> GetList();

        ComponenteEducativo Get(int id);

        ComponenteEducativo Guardar(ComponenteEducativo entidad);

        void Eliminar(int id);

    }
}