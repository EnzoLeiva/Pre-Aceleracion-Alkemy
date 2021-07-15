using Pre_Aceleracion_Alkemy.Models.Autentication;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.SendGrid
{
    public interface ISendGridService
    {
        Task SendEmail(RegisterModel user);
    }
}
