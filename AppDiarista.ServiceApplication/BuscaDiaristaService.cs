using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using AppDiarista.Data.UnitOfWork.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication
{
    public class BuscaDiaristaService : BaseService, IBuscaDiaristaService
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;
        private readonly IMapper mapper;
        private readonly IDiaristaData diaristaData;
        private readonly IEnderecoData enderecoData;

        #endregion

        #region Construtores

        public BuscaDiaristaService(
            INotificador notificador,
            IUOWAppDiarista uowAppDiarista,
            IDiaristaData diaristaData,
            IEnderecoData enderecoData,
            IMapper mapper) : base(notificador)
        {
            this.diaristaData = diaristaData;
            this.enderecoData = enderecoData;
            this.uowAppDiarista = uowAppDiarista;
            this.mapper = mapper;
        }

        #endregion

        #region Métodos Públicos

        public async Task<List<DiaristaDTO>> ListarDiaristasPorCidade(string cidade)
        {
            var enderecos = await this.enderecoData.Listar(x => x.Cidade == cidade).ToListAsync();
            var res = mapper.Map<List<DiaristaDTO>>(await this.diaristaData.Listar(x => enderecos.Any(y => y.Id == x.IdEndereco)).ToListAsync());
            return res;
        }

        #endregion

        #region Métodos Privados

        #endregion
    }
}
