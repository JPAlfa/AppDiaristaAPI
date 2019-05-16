using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using AppDiarista.Data.Models;
using AppDiarista.Data.UnitOfWork.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication
{
    public class PerfilService : BaseService, IPerfilService
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;
        private readonly IMapper mapper;
        private readonly IContratanteData contratanteData;
        private readonly ICriptografiaService criptografiaService;
        private readonly IDiaristaData diaristaData;
        private readonly IEnderecoData enderecoData;

        #endregion

        #region Construtores

        public PerfilService(
            INotificador notificador,
            IUOWAppDiarista uowAppDiarista,
            IContratanteData contratanteData,
            IDiaristaData diaristaData,
            IEnderecoData enderecoData,
            ICriptografiaService criptografiaService,
            IMapper mapper) : base(notificador)
        {
            this.criptografiaService = criptografiaService;
            this.enderecoData = enderecoData;
            this.contratanteData = contratanteData;
            this.diaristaData = diaristaData;
            this.uowAppDiarista = uowAppDiarista;
            this.mapper = mapper;
        }

        #endregion

        #region Métodos Públicos

        public async Task AlterarContratante(ContratanteEEnderecoDTO item)
        {
            await AlterarEnderecoBanco(mapper.Map<Endereco>(item));
            await AlterarContratanteBanco(mapper.Map<Contratante>(item)); 
        }

        public async Task AlterarDiarista(DiaristaEEnderecoDTO item)
        {
            await AlterarEnderecoBanco(mapper.Map<Endereco>(item));
            await AlterarDiaristaBanco(mapper.Map<Diarista>(item));
        }

        public async Task AlterarSenhaDiarista(DiaristaDTO item)
        {
            await AlterarSenhaDiaristaBanco(mapper.Map<Diarista>(item));
        }

        public async Task AlterarSenhaContratante(ContratanteDTO item)
        {
            await AlterarSenhaContratanteBanco(mapper.Map<Contratante>(item));
        }



        #endregion

        #region Métodos Privados

        private async Task AlterarDiaristaBanco(Diarista itemAlterar)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();
            Diarista itemLocalizado = await this.diaristaData.RetornarPorID(itemAlterar.Id);

            if (itemLocalizado == null)
                notificacoes.Add("itemLocalizado", Resource.Mensagens.ErroItemRecebidoInvalido);

            itemAlterar.Senha = itemLocalizado.Senha;
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
        }

        private async Task AlterarSenhaDiaristaBanco(Diarista itemAlterar)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();
            Diarista itemLocalizado = await this.diaristaData.RetornarPorID(itemAlterar.Id);

            if (itemLocalizado == null)
                notificacoes.Add("itemLocalizado", Resource.Mensagens.ErroItemRecebidoInvalido);

            itemAlterar.Senha = criptografiaService.HashearSenha(itemAlterar.Senha);
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
        }

        private async Task AlterarContratanteBanco(Contratante itemAlterar)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();
            Contratante itemLocalizado = await this.contratanteData.RetornarPorID(itemAlterar.Id);

            if (itemLocalizado == null)
                notificacoes.Add("itemLocalizado", Resource.Mensagens.ErroItemRecebidoInvalido);

            itemAlterar.Senha = itemLocalizado.Senha;
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
        }

        private async Task AlterarSenhaContratanteBanco(Contratante itemAlterar)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();
            Contratante itemLocalizado = await this.contratanteData.RetornarPorID(itemAlterar.Id);

            if (itemLocalizado == null)
                notificacoes.Add("itemLocalizado", Resource.Mensagens.ErroItemRecebidoInvalido);

            itemAlterar.Senha = criptografiaService.HashearSenha(itemAlterar.Senha);
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
        }

        private async Task AlterarEnderecoBanco(Endereco itemAlterar)
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();
            Endereco itemLocalizado = await this.enderecoData.RetornarPorID(itemAlterar.Id);
            if (itemLocalizado == null)
                notificacoes.Add("itemLocalizado", Resource.Mensagens.ErroItemRecebidoInvalido);

            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
        }

        #endregion
    }
}
