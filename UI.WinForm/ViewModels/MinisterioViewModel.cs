using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Models;

namespace UI.WinForm.ViewModels
{
    public class MinisterioViewModel
    {
        #region -> Atributos

        private int _idMinisterio;
        private string _nombreMinisterio;
        private string _direccion;
        private string _telefono;
        private string _email;
        private byte[] _photo;

        #endregion

        #region -> Constructores

        public MinisterioViewModel()
        {

        }

        public MinisterioViewModel(int idMinisterio, string nombreMinisterio, string email, string direccion, string telefono, byte[] photo)
        {
            IdMinisterio = idMinisterio;
            NombreMinisterio = nombreMinisterio;
            Email = email;
            Photo = photo;
            //Direccion = direccion;
           // Telefono = telefono;




    }
        #endregion

        #region -> Propiedades + Validacíon y Visualización de Datos

        //Posición 0 
        [DisplayName("Num")]//Nombre a visualizar (Por ejemplo en la columna del datagridview se mostrará como Num).
        public int IdMinisterio
        {
            get { return _idMinisterio; }
            set { _idMinisterio = value; }
        }

        //Posición 1 
        [DisplayName("Nombre del Ministerio")]//Nombre a visualizar.
        [Required(ErrorMessage = "El nombre del Ministerio es requerido.")]//Validaciones
        [StringLength(150, MinimumLength = 5, ErrorMessage = "El nombre del ministerio debe contener un mínimo de 5 caracteres.")]
        public string NombreMinisterio
        {
            get { return _nombreMinisterio; }
            set { _nombreMinisterio = value; }
        }

        //Posición 2
        //[DisplayName("Dirección")]//Nombre a visualizar.
        //[Browsable(false)]//Ocultar visualización (Por ejemplo no mostrar en el datagridview).
        //[Required(ErrorMessage = "Por favor ingrese una dirección.")]//Valicaciones
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "La Dirección debe contener un mínimo de 5 caracteres.")]
        //public string Direccion
        //{
        //    get { return _password; }
        //    set { _password = value; }
        //}

        //Posición 3
        [DisplayName("Nombre")]//Nombre a visualizar.
        [Browsable(false)]//Ocultar visualización
        [Required(ErrorMessage = "Por favor ingrese nombre")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El nombre debe ser solo letras")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe contener un mínimo de 3 caracteres.")]
        //public string FirstName
        //{
        //    //get { return _firstName; }
        //    //set { _firstName = value; }
        //}

        //Posición 4
        //[DisplayName("Apellido")]//Nombre a visualizar.
        //[Browsable(false)]//Ocultar visualización
        //[Required(ErrorMessage = "Por favor ingrese apellido.")]//Validaciones
        //[RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El apellido debe ser solo letras")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe contener un mínimo de 3 caracteres.")]
        //public string LastName
        //{
        //    //get { return _lastName; }
        //    //set { _lastName = value; }
        //}

        //Posición 5
        [ReadOnly(true)]//Solo lectura.
        //[DisplayName("Nombre completo")]//Nombre a visualizar.
        //public string FullName
        //{
        //    //get { return _firstName + ", " + _lastName; }
        //}

        //Posición 6
        //[DisplayName("Cargo")]
        //[Required(ErrorMessage = "Por favor ingrese un cargo.")]
        //[StringLength(100, MinimumLength = 8, ErrorMessage = "Last name must contain a minimum of 8 characters.")]
        //public string Position
        //{
        //    get { return _position; }
        //    set { _position = value; }
        //}

        //Posición 7
        //[DisplayName("Email")]//Nombre a visualizar.
        //[Required(ErrorMessage = "Por favor ingrese correo electrónico.")]//Validaciones
        //[EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        //Posición 8
        [DisplayName("Foto")]//Nombre a visualizar.
        [Browsable(false)]//Ocultar visualización
        public byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; }

        }
        #endregion

        #region -> Métodos (Mapear datos)

        //Mapear modelo de dominio a modelo de vista
        //public MinisterioViewModel MapMinisterioViewModel(MinisterioModel MinisterioModel)
        //{
        //    var MinisterioViewModel = new MinisterioViewModel
        //    {
        //        Id = MinisterioModel.Id,
        //        Ministerioname = MinisterioModel.Ministerioname,
        //        Password = MinisterioModel.Password,
        //        FirstName = MinisterioModel.FirstName,
        //        LastName = MinisterioModel.LastName,
        //        Position = MinisterioModel.Position,
        //        Email = MinisterioModel.Email,
        //        Photo = MinisterioModel.Photo
        //    };
        //    return MinisterioViewModel;
        //}
        //public List<MinisterioViewModel> MapMinisterioViewModel(IEnumerable<MinisterioModel> MinisterioModelList)
        //{
        //    var MinisterioViewModelList = new List<MinisterioViewModel>();

        //    foreach (var MinisterioModel in MinisterioModelList)
        //    {
        //        MinisterioViewModelList.Add(MapMinisterioViewModel(MinisterioModel));
        //    };
        //    return MinisterioViewModelList;
        //}

        //Mapear modelo de vista a modelo de dominio
        //public MinisterioModel MapMinisterioModel(MinisterioViewModel MinisterioViewModel)
        //{
        //    var MinisterioModel = new MinisterioModel
        //    {
        //        Id = MinisterioViewModel.Id,
        //        Ministerioname = MinisterioViewModel.Ministerioname,
        //        Password = MinisterioViewModel.Password,
        //        FirstName = MinisterioViewModel.FirstName,
        //        LastName = MinisterioViewModel.LastName,
        //        Position = MinisterioViewModel.Position,
        //        Email = MinisterioViewModel.Email,
        //        Photo = MinisterioViewModel.Photo
        //    };
        //    return MinisterioModel;
        //}        
        //public List<MinisterioModel> MapMinisterioModel(List<MinisterioViewModel> MinisterioViewModelList)
        //{
        //    var MinisterioModelList = new List<MinisterioModel>();

        //    foreach (var MinisterioViewModel in MinisterioViewModelList)
        //    {
        //        MinisterioModelList.Add(MapMinisterioModel(MinisterioViewModel));
        //    };
        //    return MinisterioModelList;
        //}
        #endregion
    }
}
