using Domain.Constants;
using Domain.DTOs.GlobalDTOs;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class GlobalApiClient : AsyncApiRepository, IGlobalApiClient
    {
        public GlobalApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<GlobalDTO> GetGlobal()
        {
            return await GetAsync<GlobalDTO>(QueryStringHelper.AppendQueryString(GlobalApiEndPoints.Global)).ConfigureAwait(false);
        }

        public async Task<GlobalDeFiDTO> GetGlobalDeFi()
        {
            return await GetAsync<GlobalDeFiDTO>(QueryStringHelper.AppendQueryString(GlobalApiEndPoints.DecentralizedFinanceDeFi)).ConfigureAwait(false);
        }
    }
}
