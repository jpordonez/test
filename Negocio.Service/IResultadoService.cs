using Negocio.Dominio.Models;
using Negocio.Dominio.Criteria;
using Framework;
using System.Collections.Generic;
using Negocio.Dominio.DTO;

namespace Negocio.Service
{
    public interface IResultadoService
    {

        IPagedListMetaData<ResultadoDTO> GetList(ResultadoCriteria criteria);

        Resultado Get(int id);

        Resultado Guardar(Resultado entidad);

        void Eliminar(int id);

    }
}