using Infra.DataAccess.Contracts;
using Infra.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infra.DataAccess.Repositories
{
    public class MinisterioRepository : MasterRepository, IMinisterioRepository
    {
        /// <summary>
        /// Esta clase hereda de clase MasterRepository e implementa la interfaz IUserRepository.
        /// Aquí se realiza las diferentes transacciones y consultas a la base de datos de la entidad
        /// usuario.
        /// </summary>
        /// 

        //public User Login(string username, string password)
        //{//Ejemplo de una consulta con varios parámetros mediante un procedimiento almacenado:
        // //Validar el usuario y contraseña del usuario para el inicio de sesion.

        //    string commandText = "loginUser";//Establecer el comando de texto (Transact-SQL o procedimiento almacenado).
        //    CommandType commandType = CommandType.StoredProcedure;//Establecer el tipo de comando.
        //    var parameters = new List<SqlParameter>();//Crear una lista genérica de para los parámetros de la consulta.
        //    parameters.Add(new SqlParameter("@user", username));//Crear y agregar el parámetro usuario (Nombre de parámetro y valor).
        //    parameters.Add(new SqlParameter("@password", password));//Crear y agregar el parámetro contraseña (Nombre de parámetro y valor).

        //    var table = ExecuteReader(commandText, parameters, commandType);//Ejecutar el método lector de la clase base MasterRepository y enviar los parámetros necesarios.

        //    if (table.Rows.Count > 0)//Si la consulta fue exitosa (usuario y contraseña válidos).
        //    {
        //        var user = new User();//Crear objeto-entidad usuario.
        //        foreach (DataRow row in table.Rows)//Recorrer las filas de la tabla y asignar los valores respectivos del objeto usuario.
        //        {
        //            user.Id = (int)(row[0]);//Celda posición [0].
        //            user.Username = row[1].ToString();
        //            user.Password = row[2].ToString();
        //            user.FirstName = row[3].ToString();
        //            user.LastName = row[4].ToString();
        //            user.Position = row[5].ToString();
        //            user.Email = row[6].ToString();
        //            if (row[7] != DBNull.Value) user.Photo = (byte[])row[7];//Establecer el valor si el valor de celda es diferente a nulo.
        //        }
        //        return user;//Retornar objeto usuario.
        //    }
        //    else //Si la consulta no fue exitosa - retornar un objeto nulo.
        //        return null;
        //}

        public int Add(Ministerio entity)
        {//Ejemplo de una transacción con varios parámetros usando un procedimiento almacenado:
         //Agregar un nuevo usuario.

            var parameters = new List<SqlParameter>();//Crear una lista para los parámetros de la transacción.
            parameters.Add(new SqlParameter("@nombreMinisterio", entity.NombreMinisterio));
            parameters.Add(new SqlParameter("@telefono", entity.Telefono));
            parameters.Add(new SqlParameter("@direccion", entity.Direccion));
            parameters.Add(new SqlParameter("@photo", entity.Photo));
            parameters.Add(new SqlParameter("@email", entity.Email));
            if (entity.Photo != null)//Si la propiedad Foto es diferente a nulo, asignar el valor de la propiedad.
                parameters.Add(new SqlParameter("@photo", entity.Photo) { SqlDbType = SqlDbType.VarBinary });//En este caso del campo Foto, es importante especificar explícitamente el tipo de dato de SQL.
            else //Caso contrario asignar un valor nulo de SQL.                                              //Puedes hacer lo mismo con los otros parámetros, sin embargo es opcional,  
                parameters.Add(new SqlParameter("@photo", DBNull.Value) { SqlDbType = SqlDbType.VarBinary });//El tipo de datos será derivará del tipo de dato de su valor.

            //Ejecutar el método ExecuteNonQuery de la clase MasterRepository para realizar una transacción de insertar,
            //y enviar los parámetros necesarios (Comando de texto, parámetros y tipo de comando).
            return ExecuteNonQuery("AddMinisterio", parameters, CommandType.StoredProcedure);
        }
        public int Edit(Ministerio entity)
        {//Ejemplo de una transacción con varios parámetros usando un procedimiento almacenado:
         //Editar usuario.

            var parameters = new List<SqlParameter>();//Crear una lista para los parámetros de la transacción.
            parameters.Add(new SqlParameter("@idMinisterio", entity.IdMinisterio));
            parameters.Add(new SqlParameter("@nombreMinisterio", entity.NombreMinisterio));
            parameters.Add(new SqlParameter("@telefono", entity.Telefono));
            parameters.Add(new SqlParameter("@direccion", entity.Direccion));
            parameters.Add(new SqlParameter("@photo", entity.Photo));
            parameters.Add(new SqlParameter("@email", entity.Email));
            if (entity.Photo != null)
                parameters.Add(new SqlParameter("@photo", entity.Photo) { SqlDbType = SqlDbType.VarBinary });
            else parameters.Add(new SqlParameter("@photo", DBNull.Value) { SqlDbType = SqlDbType.VarBinary });

            //Ejecutar el método ExecuteNonQuery de la clase MasterRepository para realizar una transacción de actualizar,
            //y enviar los parámetros necesarios (Comando de texto, parámetros y tipo de comando).
            return ExecuteNonQuery("EditMinisterio", parameters, CommandType.StoredProcedure);
        }
        public int Remove(Ministerio entity)
        {//Ejemplo de una transacción con un solo parámetro usando un comando Transact-SQL:
         //Eliminar usuario.

            string sqlCommand = "delete from Ministerio where idMinisterio=@idMinisterio";//Comando de tipo texto (Transact-SQL)
            return ExecuteNonQuery(sqlCommand, new SqlParameter("@Ministerio", entity.IdMinisterio), CommandType.Text);
        }


        public Ministerio GetSingle(string value)
        {//Ejemplo de una consulta usando un comando Transact-SQL con un parámetro:
         //Obtener un usuario según el valor espeficicado (Buscar).

            string sqlCommand;
            DataTable table;
            int idMinisterio;

            bool isNumeric = int.TryParse(value, out idMinisterio);//Determinar si el parámetro valor es un numero entero.
            if (isNumeric)//Si el valor es un número, realizar la consulta usando el id del usuario.
            {
                sqlCommand = "select *from Ministerio where idMinisterio= @idMinisterio";
                table = ExecuteReader(sqlCommand, new SqlParameter("@idMinisterio", idMinisterio), CommandType.Text);
            }
            else //Caso contrario, realizar la consulta usando el nombre de usuario o correo electrónico.
            {
                sqlCommand = "select *from Ministerio where ministerioName= @findValue or email=@findValue";
                table = ExecuteReader(sqlCommand, new SqlParameter("@findValue", value), CommandType.Text);
            }

            if (table.Rows.Count > 0)//Si la consulta tiene resultado
            {
                var ministerio = new Ministerio();//Crear un objeto usuario y asignar los valores.
                foreach (DataRow row in table.Rows)
                {
                    ministerio.IdMinisterio = Convert.ToInt32(row[0]);
                    ministerio.NombreMinisterio = row[1].ToString();
                    ministerio.Direccion = row[2].ToString();
                    ministerio.Telefono = row[3].ToString();
                    ministerio.Email = row[4].ToString();
                    if (row[5] != DBNull.Value) ministerio.Photo = (byte[])row[5];
                }
                //Opcionalmente desechar la tabla para liberar memoria.
                table.Clear();
                table = null;

                return ministerio;//Retornar usuario encontrado.
            }
            else//Si la consulta no fué exitosa, retornar nulo.
                return null;
        }
        public IEnumerable<Ministerio> GetAll()
        {
            var ministerioList = new List<Ministerio>();
            var table = ExecuteReader("SelectAllMinisterios", CommandType.StoredProcedure);

            foreach (DataRow row in table.Rows)
            {
                var ministerio = new Ministerio();
                ministerio.IdMinisterio = Convert.ToInt32(row[0]);
                ministerio.NombreMinisterio = row[1].ToString();
                ministerio.Direccion = row[2].ToString();
                ministerio.Telefono = row[3].ToString();
                ministerio.Email = row[4].ToString();
                if (row[5] != DBNull.Value) ministerio.Photo = (byte[])row[5];

                ministerioList.Add(ministerio);
            }
            table.Clear();
            table = null;

            return ministerioList;
        }
        public IEnumerable<Ministerio> GetByValue(string value)
        {
            var ministerioList = new List<Ministerio>();
            var table = ExecuteReader("SelectMinisterio", new SqlParameter("@findValue", value), CommandType.StoredProcedure);

            foreach (DataRow row in table.Rows)
            {
                var ministerio = new Ministerio();
                ministerio.IdMinisterio = Convert.ToInt32(row[0]);
                ministerio.NombreMinisterio = row[1].ToString();
                ministerio.Direccion = row[2].ToString();
                ministerio.Telefono = row[3].ToString();
                ministerio.Email = row[4].ToString();
                if (row[5] != DBNull.Value) ministerio.Photo = (byte[])row[5];

                ministerioList.Add(ministerio);
            }
            table.Clear();
            table = null;

            return ministerioList;
        }

        public int AddRange(List<Ministerio> ministerio)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(List<Ministerio> ministerio)
        {
            throw new NotImplementedException();
        }

        public Ministerio Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
