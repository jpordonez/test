using System;
using System.Collections.Generic;
using System.Reflection;
using Framework.Repository;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Presentacion.Models
{

    public class MappingConfiguration : IMappingConfiguration
    {

        public List<Type> GetMapper()
        {
            return new List<Type>();
        }


        public List<Assembly> GetAssemblyWithMapper()
        {

            //1. Agregar Nucleo.Data 
            Assembly dll = typeof(Sistema).Assembly;

            List<Assembly> list = new List<Assembly>();
            list.Add(dll);

            //2. Agregar Negocio.Data


            return list;
        }
    }
}
