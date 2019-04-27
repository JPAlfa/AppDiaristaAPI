using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using AppDiarista.Data.UnitOfWork.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication
{
    public class ContratanteService : BaseService, IContratanteService
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;
        private readonly IMapper mapper;
        private readonly IContratanteData contratanteData;

        #endregion

        #region Construtores

        public ContratanteService(
            INotificador notificador,
            IUOWAppDiarista uowAppDiarista,
            IContratanteData contratanteData,
            IMapper mapper) : base(notificador)
        {
            this.contratanteData = contratanteData;
            this.uowAppDiarista = uowAppDiarista;
            this.mapper = mapper;
        }

        #endregion

        #region Métodos Públicos

        public async Task<bool> Inserir(CadastroContratanteDTO item)
        {
            //if (await this.intencaoBusiness.VerificaPermiteInserirBanco(itemCriar))
            //{

            //}

            //return null;
            Data.Models.Endereco enderecoCriar = await InserirEnderecoBanco(item);
            await InserirContratanteBanco(item, enderecoCriar);

            return true;
        }

        #endregion

        #region Métodos Privados

        private async Task InserirContratanteBanco(CadastroContratanteDTO item, Data.Models.Endereco enderecoCriar)
        {
            var contratanteCriar = mapper.Map<Data.Models.Contratante>(item);
            contratanteCriar.IdEndereco = enderecoCriar.Id;
            this.uowAppDiarista.Contratante.Add(contratanteCriar);
            await this.uowAppDiarista.SaveChangesAsync();
        }

        private async Task<Data.Models.Endereco> InserirEnderecoBanco(CadastroContratanteDTO item)
        {
            var enderecoCriar = mapper.Map<Data.Models.Endereco>(item);
            this.uowAppDiarista.Endereco.Add(enderecoCriar);
            await this.uowAppDiarista.SaveChangesAsync();
            return enderecoCriar;
        }

        #endregion
    }
}
