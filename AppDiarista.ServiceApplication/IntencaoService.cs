using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AppDiarista.Business.Interfaces;
using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using AppDiarista.Data.UnitOfWork.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiarista.ServiceApplication
{
    public class IntencaoService : BaseService, IIntencaoService
    {
        #region Propriedades

        private readonly IIntencaoBusiness intencaoBusiness;
        private readonly IUOWAppDiarista uowAppDiarista;
        private readonly IMapper mapper;
        private readonly IIntencaoData intencaoData;

        #endregion

        #region Construtores

        public IntencaoService(
            INotificador notificador,
            IIntencaoBusiness intencaoBusiness,
            IUOWAppDiarista uowAppDiarista,
            IIntencaoData intencaoData,
            IMapper mapper) : base(notificador)
        {
            this.intencaoBusiness = intencaoBusiness;
            this.intencaoData = intencaoData;
            this.uowAppDiarista = uowAppDiarista;
            this.mapper = mapper;
        }

        #endregion

        #region Métodos Públicos

        public async Task<IntencaoDTO> Inserir(IntencaoDTO item)
        {
            return await InserirBanco(item);
        }
        
        public async Task<IntencaoDTO> Alterar(int id, IntencaoDTO item)
        {

            item = await this.AlterarBanco(id, item);

            return item;
        }

        public async Task<List<IntencaoDTO>> Listar()
        {
            var result = await this.intencaoData.ListarTodos().ToListAsync();
            return mapper.Map<List<IntencaoDTO>>(result);
        }

        public async Task<List<IntencaoDTO>> ListarPorBot(string botId)
        {
            var result = await this.intencaoData.Listar(x => x.BotId.ToString() == botId).ToListAsync();
            return mapper.Map<List<IntencaoDTO>>(result);
        }

        public async Task<IntencaoDTO> RetornarPorId(int id)
        {
            var result = await this.intencaoData.RetornarPorID(id);
            return mapper.Map<IntencaoDTO>(result);
        }


        #endregion

        #region Métodos Privados

        private async Task<IntencaoDTO> InserirBanco(IntencaoDTO item)
        {
            var itemCriar = mapper.Map<Data.Models.Intent>(item);
            if (await this.intencaoBusiness.VerificaPermiteInserirBanco(itemCriar))
            {
                this.uowAppDiarista.Intent.Add(itemCriar);
                await this.uowAppDiarista.SaveChangesAsync();
                item.IntentId = itemCriar.IntentId;
                return item;
            }

            return null;
        }

        private async Task<IntencaoDTO> AlterarBanco(int id, IntencaoDTO item)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();

            Data.Models.Intent itemLocalizado = await this.intencaoData.RetornarPorID(id);
            if (itemLocalizado == null)
            {
                notificacoes.Add("itemLocalizado", Resource.Mensagens.ErroItemRecebidoInvalido);
            }

            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;

            var itemAlterar = mapper.Map<Data.Models.Intent>(item);
            if (this.intencaoBusiness.VerificaPermiteAlterarBanco(id, itemAlterar))
            {
                uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
                await uowAppDiarista.SaveChangesAsync();
                return await RetornarPorId(id);
            }

            return null;
        }

        #endregion
    }
}
