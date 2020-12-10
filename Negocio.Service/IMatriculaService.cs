using Negocio.Dominio.Models;
using Negocio.Dominio.Criteria;
using Framework;
using System.Collections.Generic;

namespace Negocio.Service
{
    public interface IMatriculaService
    {

        IList<Matricula> GetList(MatriculaCriteria criteria);

        Matricula Get(int id);

        Matricula Guardar(Matricula entidad);

        void Eliminar(int id);

    }
}