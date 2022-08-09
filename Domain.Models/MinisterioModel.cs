using Domain.Models.Contracts;
using Infra.DataAccess.Contracts;
using Infra.DataAccess.Entities;
using Infra.DataAccess.Repositories;
using Infra.EmailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MinisterioModel : IMinisterioModel
    {
        /// <summary>
        /// Esta clase implementa la interfaz IUserModel junto a sus métodos definidos.
        /// </summary>

        #region -> Atributos

        
        private int _idMinisterio;
        private string _nombreMinisterio;
        private string _direccion;
        private string _telefono;
        private string _email;
        private byte[] _photo;

        private MinisterioRepository _ministerioRepository;

        #endregion

        #region -> Constructores

        public MinisterioModel()
        {
            _ministerioRepository = new MinisterioRepository();
        }


        public MinisterioModel(int idMinisterio, string nombreMinisterio, string email, string direccion, string telefono, byte[] photo)

        {

            IdMinisterio = idMinisterio;
            NombreMinisterio = nombreMinisterio;
            Email = email;
            Photo = photo;
            Direccion = direccion;
            Telefono = telefono;


            _ministerioRepository = new MinisterioRepository();
        }
        #endregion

        #region -> Propiedades
        public int IdMinisterio
        {
            get { return _idMinisterio; }
            set { _idMinisterio = value; }
        }
        public string NombreMinisterio
        {
            get { return _nombreMinisterio; }
            set { _nombreMinisterio = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }


        #endregion

        #region -> Métodos Públicos        
        public int Add(MinisterioModel ministerioModel)
        {
            var ministerioEntity = MapMinisterioEntity(ministerioModel);
            return _ministerioRepository.Add(ministerioEntity);
        }
        public int Edit(MinisterioModel ministerioModel)
        {
            var ministerioEntity = MapMinisterioEntity(ministerioModel);
            return _ministerioRepository.Edit(ministerioEntity);
        }
        public int Remove(MinisterioModel ministerioModel)
        {
            var ministerioEntity = MapMinisterioEntity(ministerioModel);
            return _ministerioRepository.Remove(ministerioEntity);
        }
        //public int AddRange(List<MinisterioModel> ministerioModels)
        //{
        //    var ministerioEntityList = MapMinisterioEntity(ministerioModels);
        //    return _ministerioRepository.AddRange(ministerioEntityList);
        //}
        //public int RemoveRange(List<MinisterioModel> ministerioModels)
        //{
        //    var ministerioEntityList = MapMinisterioEntity(ministerioModels);
        //    return _ministerioRepository.RemoveRange(ministerioEntityList);
        //}

        public MinisterioModel GetSingle(string value)
        {
            var ministerioEntity = _ministerioRepository.GetSingle(value);
            if (ministerioEntity != null)
                return MapMinisterioModel(ministerioEntity);
            else return null;
        }
        public IEnumerable<MinisterioModel> GetAll()
        {
            var ministerioEntityList = _ministerioRepository.GetAll();
            return MapMinisterioModel(ministerioEntityList);
        }
        public IEnumerable<MinisterioModel> GetByValue(string value)
        {
            var ministerioEntityList = _ministerioRepository.GetByValue(value);
            return MapMinisterioModel(ministerioEntityList);
        }

        //public MinisterioModel Login(string ministerioname, string password)
        //{
        //    var ministerioEntity = _ministerioRepository.Login(ministerioname, password);
        //    if (ministerioEntity != null)
        //        return MapMinisterioModel(ministerioEntity);
        //    else return null;

        //}
        //public MinisterioModel RecoverPassword(string requestingMinisterio)
        //{//Método para recupear la contraseña del usuario y enviarlo a su dirección de correo.
        //    var ministerioModel = GetSingle(requestingMinisterio);
        //    if (ministerioModel != null)
        //    {
        //        var mailService = new EmailService();
        //        mailService.Send(
        //            recipient: ministerioModel.Email,
        //            subject: "Solicitud de recuperación de contraseña",
        //            //body: "Hola " + ministerioModel.FirstName + ",\nSolicitó recuperar su contraseña.\n" +
        //            //"Tu contraseña actual es: " + ministerioModel.Password + "\nSin embargo, le pedimos que cambie" +
        //            //"su contraseña inmediatamente una vez ingrese a la aplicacíon");              
        //    }
        //    return ministerioModel;
        //    /*Nota: Eso es simplemente un ejemplo para enviar correos electrónicos,
        //     * no es buena idea enviar directamente la contraseña del usuario,
        //     * en su lugar, es mejor enviar una contraseña temporal.*/
        //}

        #endregion

        #region -> Métodos Privados (Mapear datos)

        //Mapear modelo entidad a modelo de dominio.
        private MinisterioModel MapMinisterioModel(Ministerio ministerioEntity)
        {//Mapear un solo objeto.
            var ministerioModel = new MinisterioModel
            {
                IdMinisterio = ministerioEntity.IdMinisterio,
                NombreMinisterio = ministerioEntity.NombreMinisterio,
                Email = ministerioEntity.Email,
                Photo = ministerioEntity.Photo,
                Direccion = ministerioEntity.Direccion,
                Telefono = ministerioEntity.Telefono

            };

            return ministerioModel;

        }
        private List<MinisterioModel> MapMinisterioModel(IEnumerable<Ministerio> ministerioEntityList)
        {//Mapear colección de objetos.
            var ministerioModelList = new List<MinisterioModel>();

            foreach (var ministerioEntity in ministerioEntityList)
            {
                ministerioModelList.Add(MapMinisterioModel(ministerioEntity));
            };
            return ministerioModelList;
        }
        //Mapear modelo de dominio a modelo de entidad.
        private Ministerio MapMinisterioEntity(MinisterioModel ministerioModel)
        {//Mapear un solo objeto.
            var ministerioEntity = new Ministerio
            {
                IdMinisterio = ministerioModel.IdMinisterio,
                NombreMinisterio = ministerioModel.NombreMinisterio,
                Direccion = ministerioModel.Direccion,
                Telefono = ministerioModel.Telefono,
                Email = ministerioModel.Email,
                Photo = ministerioModel.Photo
            };
            return ministerioEntity;
        }
        private List<Ministerio> MapMinisterioEntity(List<MinisterioModel> ministerioModelList)
        {//Mapear una colección de usuarios.
            var ministerioEntityList = new List<Ministerio>();

            foreach (var ministerioModel in ministerioModelList)
            {
                ministerioEntityList.Add(MapMinisterioEntity(ministerioModel));
            };
            return ministerioEntityList;
        }

        public int AddRange(List<MinisterioModel> Ministerios)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(List<MinisterioModel> Ministerios)
        {
            throw new NotImplementedException();
        }

        public MinisterioModel Login(string Ministerio, string pass)
        {
            throw new NotImplementedException();
        }

        public MinisterioModel RecoverPassword(string requestingMinisterio)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

    
}
