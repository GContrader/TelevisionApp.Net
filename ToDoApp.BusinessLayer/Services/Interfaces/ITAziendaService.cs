using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;

namespace ToDoApp.BusinessLayer.Services.Interfaces
{
    public interface ITAziendaService
    {
        Task<IEnumerable<AziendaDTO>> getAll();
        Task<AziendaDTO> PostAzienda(AziendaDTO aziendaDTO);
    }
}
