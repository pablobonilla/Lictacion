using Infra.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Contracts
{
    public interface IMinisterioRepository : IGenericRepository<Ministerio>
    {//Esta interfaz implementa la interfaz genérica IGenericRepository (No olvides de especificar la entidad).
     //Adicionalmente, define otros comportamientos públicos específicos de la entidad usuario.

        int AddRange(List<Ministerio> ministerio);//Agregar una colección de usuarios (Insercción masiva)
        int RemoveRange(List<Ministerio> ministerio);//Eliminar una colección de usuarios (remoción masiva)
        Ministerio Login(string username, string password);//Validar los datos de inicio de sesión.
    }
}
