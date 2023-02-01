using Domain.DTOs.GlobalDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IGlobalApiClient
    {
        Task<GlobalDTO> GetGlobal();

        Task<GlobalDeFiDTO> GetGlobalDeFi();
    }
}
