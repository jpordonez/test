using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Framework.Repository;
using Nucleo.Dominio.Entidades;

namespace Negocio.Proceso
{
    public static class InstallProces
    {
        public static void Procesar() {
            var random = new Random();


            var repository = ServiceLocator.Current.GetInstance<IRepository<Sistema>>();

            //1. Sistema
            var sis = GetSistema();

            if (repository.Exists(c => c.Codigo == sis.Codigo))
            {
                
                sis = repository.GetList(c => c.Codigo == sis.Codigo).SingleOrDefault();
                sis.Nombre = "Sistema Cambio " + random.Next();
            }

            //2. Catalogos
            var listaCatalogos = GetCatalogos(sis);
            var repositoryCatalogo = ServiceLocator.Current.GetInstance<IRepository<Catalogo>>();
            foreach (var cat in listaCatalogos)
            {

                if (repositoryCatalogo.Exists(c => c.Codigo == cat.Codigo))
                {
                    var catExistente = repositoryCatalogo.GetList(c => c.Codigo == cat.Codigo).SingleOrDefault();

                    catExistente.Nombre = "Catelogo Cambio " + random.Next();
                    catExistente.Descripcion = cat.Descripcion + random.Next();
                    //catExistente.Items = cat.Items;

                    //Detele
                    //var diff = cat.Items.

                    //New/Update
                    foreach (var item in cat.Items) {

                        var itemExiste = catExistente.Items.Where(i => i.Codigo == item.Codigo).SingleOrDefault();
                        if (itemExiste != null)
                        {
                            itemExiste.Nombre = item.Nombre + random.Next();
                            itemExiste.Descripcion = item.Descripcion;
                            itemExiste.CodigoCatalogo = item.CodigoCatalogo;
                            //itemExiste.Catalogo = catExistente;
                        }
                        else {
                            item.Catalogo = catExistente;
                            catExistente.Items.Add(item);
                        }

                    }


                    repositoryCatalogo.SaveOrUpdate(catExistente);
                }
                else
                {

                    repositoryCatalogo.SaveOrUpdate(cat);

                }

            }

            

            repository.SaveOrUpdate(sis);
             


        }

        public static Sistema GetSistema()
        {
            Sistema sistema = new Sistema();
            sistema.Codigo = "CAR_LINEA";
            sistema.Nombre = "Carpeta en Linea";
            sistema.Descripcion = "Carpeta en linea - UDLA";

            return sistema;
        }

        public static List<Catalogo> GetCatalogos(Sistema sistema) {

            Catalogo catalogo = new Catalogo();
            catalogo.Codigo = "TIP_MNU_ITEM";
            catalogo.Nombre = "Tipo de Menu Item";
            catalogo.Sistema = sistema;

            ItemCatalogo item = new ItemCatalogo();
            item.CodigoCatalogo = "TIP_MNU_ITEM";
            item.Catalogo = catalogo;
            item.Codigo = "MNU_CONTENEDOR";
            item.Nombre = "Tipo de item de menu contenedor";
            item.Descripcion = "Tipo de item de menu contenedor";

            catalogo.Items.Add(item);


            item = new ItemCatalogo();
            item.CodigoCatalogo = "TIP_MNU_ITEM";
            item.Catalogo = catalogo;
            item.Codigo = "MNU_MENU";
            item.Nombre = "Tipo de item de menu normal";
            item.Descripcion = "Tipo de item de menu normal";

            catalogo.Items.Add(item);


            item = new ItemCatalogo();
            item.CodigoCatalogo = "TIP_MNU_ITEM";
            item.Catalogo = catalogo;
            item.Codigo = "MNU_MENU_2";
            item.Nombre = "Tipo de item de menu normal";
            item.Descripcion = "Tipo de item de menu normal";

            catalogo.Items.Add(item);

            var lista = new List<Catalogo>();
            lista.Add(catalogo);


            return lista; 
        }
    }
}
