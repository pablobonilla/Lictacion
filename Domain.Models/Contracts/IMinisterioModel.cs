using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Contracts
{
    public interface IMinisterioModel : IBaseModel<MinisterioModel>
    {
        int AddRange(List<MinisterioModel> Ministerios);
        int RemoveRange(List<MinisterioModel> Ministerios);
        MinisterioModel Login(string Ministerio, string pass);
        MinisterioModel RecoverPassword(string requestingMinisterio);
    }
}
