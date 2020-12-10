using Framework;
using Nucleo.Dominio.Criteria;
using Nucleo.Dominio.DTO;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Service
{
    public interface IPersonaService
    {

        Persona Get(int id);
        Persona Get(string identificacion);
        IPagedListMetaData<PersonaDTO> GetList(PersonaCriteria personaCriteria);
        Persona Guardar(Persona catalogo);
        bool ValidarIdentificacion(int? personaId, int tipoIdentificacion, string identificacion, out string mensaje);
        bool ValidarExistenciaCorreo(int? personaId, string correo);
        void Eliminar(int id);

    }
}
