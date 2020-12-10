using Framework;
using Framework.EntityFramewok;
using Nucleo.Dominio.Criteria;
using Nucleo.Dominio.DTO;
using Nucleo.Dominio.Models;

namespace Nucleo.Service
{
    public interface IInstitucionService
    {

        Institucion Get(int id);
        IPagedListMetaData<InstitucionDTO> GetList(InstitucionCriteria criteria);
        Institucion Guardar(Institucion institucion);
        void Eliminar(int id);

    }
}
