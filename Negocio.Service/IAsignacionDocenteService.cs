using Negocio.Dominio.Models;
using Negocio.Dominio.Criteria;
using Framework;
using System.Collections.Generic;

namespace Negocio.Service
{
    public interface IAsignacionDocenteService
    {

        IList<AsignacionDocente> GetList(AsignacionDocenteCriteria criteria);

        AsignacionDocente Get(int id);

        AsignacionDocente Guardar(AsignacionDocente entidad);

        void Eliminar(int id);

    }
}