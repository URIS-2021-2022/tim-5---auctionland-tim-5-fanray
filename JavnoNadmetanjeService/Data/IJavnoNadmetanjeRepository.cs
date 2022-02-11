using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Data
{
    public interface IJavnoNadmetanjeRepository
    {
        List<JavnoNadmetanje> GetJavnoNadmetanjeList();
        JavnoNadmetanje GetJavnoNadmetanjeById(Guid javnoNadmetanjeId);
        JavnoNadmetanjeConfirmationDto CreateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje);
        JavnoNadmetanjeConfirmationDto UpdateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje);
        JavnoNadmetanjeConfirmationDto DeleteJavnoNadmetanje(Guid javnoNadmetanjeId);
    }
}
