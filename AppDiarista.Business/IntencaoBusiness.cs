using AppDiarista.Business.Interfaces;
using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDiarista.Business
{
    public class IntencaoBusiness : BaseBusiness, IIntencaoBusiness
    {
        #region Propriedades

        private readonly IIntencaoData intencaoData;

        #endregion

        #region Construtores

        public IntencaoBusiness(
            INotificador notificador, 
            IIntencaoData intencaoData) : base(notificador)
        {
            this.intencaoData = intencaoData;
        }

        #endregion

        #region Métodos Públicos

        

        public async Task<bool> VerificaPermiteInserirBanco(Data.Models.Intent novoItem)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();

            if (novoItem == null)
            {
                notificacoes.Add("novoItem", Resource.Mensagens.ErroItemRecebidoInvalido);
            }

            var itemJaExiste = await this.intencaoData.Listar(w => w.Name == novoItem.Name).AnyAsync();
            if (itemJaExiste)
            {
                notificacoes.Add("novoItem", Resource.Mensagens.ErroIntencaoJaCadastrada);
            }

            notificador.AdicionarListaNotificacoes(notificacoes);

            return notificacoes.Count == 0;
        }

        public bool VerificaPermiteAlterarBanco(int id, Data.Models.Intent itemAlterar)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();

            if (id == 0)
            {
                notificacoes.Add("id", Resource.Mensagens.ErroItemRecebidoInvalido);
            }

            if (itemAlterar == null)
            {
                notificacoes.Add("itemAlterar", Resource.Mensagens.ErroItemRecebidoInvalido);
            }

            notificador.AdicionarListaNotificacoes(notificacoes);

            return notificacoes.Count == 0;
        }

        #endregion
    }
}
