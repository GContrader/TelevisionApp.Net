using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.BusinessLayer.Models;

namespace ToDoApp.BusinessLayer.Services.Interfaces
{
    public interface IProgrammaService
    {
        Task<IEnumerable<ProgrammaDTO>> GetProgrammaDTOAsync();
        Task<ProgrammaDTO> GetProgrammaDTOAsync(int id);
        Task<ProgrammaDTO> PostProgrammaDTOAsync(CreaProgrammaDTO programmaDTO);
        Task<bool> PutProgrammaDTOAsync(int id, CreaProgrammaDTO programmaDTO);
        Task<bool> DeleteProgrammaDTOAsync(int id);
    }
}
