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

        public async Task<bool> AlterarContratante(ContratanteDTO item)
        {
            return await AlterarContratanteBanco(mapper.Map<Contratante>(item)); 
        }

        public async Task<bool> AlterarDiarista(DiaristaDTO item)
        {
            return await AlterarDiaristaBanco(mapper.Map<Diarista>(item));
        }

        public async Task<bool> AlterarEndereco(EnderecoDTO item)
        {
            return await AlterarEnderecoBanco(mapper.Map<Endereco>(item));
        }

        public async Task<bool> AlterarSenhaDiarista(int idDiarista, string senha)
        {
            return await AlterarSenhaDiaristaBanco(idDiarista, senha);
        }

        public async Task<bool> AlterarSenhaContratante(int idContratante, string senha)
        {
            return await AlterarSenhaContratanteBanco(idContratante, senha);
        }

        public async Task<bool> AlterarPrecoDiariaDiarista(int idDiarista, double precoDiaria)
        {
            return await AlterarPrecoDiariaDiaristaBanco(idDiarista, precoDiaria);
        }

        #endregion

        #region Métodos Privados

        private async Task<bool> AlterarDiaristaBanco(Diarista itemAlterar)
        {
            Diarista itemLocalizado = await this.diaristaData.RetornarPorID(itemAlterar.Id);

            if (itemLocalizado == null)
                return EnviarErro();

            itemAlterar.Senha = itemLocalizado.Senha;
            itemAlterar.IdEndereco = itemLocalizado.IdEndereco;
            itemAlterar.Nota = itemLocalizado.Nota;
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
            return true;
        }

        private async Task<bool> AlterarContratanteBanco(Contratante itemAlterar)
        {
            Contratante itemLocalizado = await this.contratanteData.RetornarPorID(itemAlterar.Id);

            if (itemLocalizado == null)
                return EnviarErro();

            itemAlterar.Senha = itemLocalizado.Senha;
            itemAlterar.IdEndereco = itemLocalizado.IdEndereco;
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
            return true;
        }

        private async Task<bool> AlterarSenhaDiaristaBanco(int idDiarista, string senha)
        {
            Diarista itemLocalizado = await this.diaristaData.RetornarPorID(idDiarista);

            if (itemLocalizado == null)
                return EnviarErro();

            itemLocalizado.Senha = criptografiaService.HashearSenha(senha);
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
            return true;
        }

        private async Task<bool> AlterarSenhaContratanteBanco(int idContratante, string senha)
        {
            Contratante itemLocalizado = await this.contratanteData.RetornarPorID(idContratante);

            if (itemLocalizado == null)
                return EnviarErro();

            itemLocalizado.Senha = criptografiaService.HashearSenha(senha);
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
            return true;
        }

        private async Task<bool> AlterarEnderecoBanco(Endereco itemAlterar)
        {
            Endereco itemLocalizado = await this.enderecoData.RetornarPorID(itemAlterar.Id);
            if (itemLocalizado == null)
                return EnviarErro();

            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Detached;
            uowAppDiarista.Entry(itemAlterar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
            return true;
        }

        private async Task<bool> AlterarPrecoDiariaDiaristaBanco(int idDiarista, double precoDiaria)
        {
            Diarista itemLocalizado = await this.diaristaData.RetornarPorID(idDiarista);

            if (itemLocalizado == null)
                return EnviarErro();
                
            itemLocalizado.PrecoDiaria = precoDiaria;
            uowAppDiarista.Entry(itemLocalizado).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
            return true;
        }

        private bool EnviarErro()
        {
            Dictionary<string, string> notificacoes = new Dictionary<string, string>();
            notificacoes.Add("itemLocalizado", Resource.Mensagens.ErroItemRecebidoInvalido);
            notificador.AdicionarListaNotificacoes(notificacoes);
            return false;
        }

        #endregion
    }
}
