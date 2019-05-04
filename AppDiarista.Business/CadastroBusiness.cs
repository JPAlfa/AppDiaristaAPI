using AppDiarista.Business.Interfaces;
using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDiarista.Business
{
    public class CadastroBusiness : BaseBusiness, ICadastroBusiness
    {
        #region Propriedades

        private readonly IDiaristaData diaristaData;
        private readonly IContratanteData contratanteData;

        #endregion

        #region Construtores

        public CadastroBusiness(
            INotificador notificador,
            IDiaristaData diaristaData,
            IContratanteData contratanteData) : base(notificador)
        {
            this.diaristaData = diaristaData;
            this.contratanteData = contratanteData;
        }

        #endregion

        #region Métodos Públicos

        public async Task<bool> VerificaPermiteCadastrarDiaristaBanco(string email)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();

            if (await this.diaristaData.Listar(w => w.Email == email).AnyAsync())
                notificacoes.Add("novoItem", Resource.Mensagens.ErroEmailJaCadastrado);
            
            notificador.AdicionarListaNotificacoes(notificacoes);

            return notificacoes.Count == 0;
        }

        public async Task<bool> VerificaPermiteCadastrarContratanteBanco(string email)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();

            if (await this.contratanteData.Listar(w => w.Email == email).AnyAsync())
                notificacoes.Add("novoItem", Resource.Mensagens.ErroEmailJaCadastrado);

            notificador.AdicionarListaNotificacoes(notificacoes);

            return notificacoes.Count == 0;
        }

        #endregion
    }
}
