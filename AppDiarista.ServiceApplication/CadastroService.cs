using AppDiarista.Business.Interfaces;
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
    public class CadastroService : BaseService, ICadastroService
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;
        private readonly IMapper mapper;
        private readonly IContratanteData contratanteData;
        private readonly ICriptografiaService criptografiaService;
        private readonly ICadastroBusiness cadastroBusiness;

        #endregion

        #region Construtores

        public CadastroService(
            INotificador notificador,
            IUOWAppDiarista uowAppDiarista,
            IContratanteData contratanteData,
            ICriptografiaService criptografiaService,
            ICadastroBusiness cadastroBusiness,
            IMapper mapper) : base(notificador)
        {
            this.criptografiaService = criptografiaService;
            this.contratanteData = contratanteData;
            this.uowAppDiarista = uowAppDiarista;
            this.cadastroBusiness = cadastroBusiness;
            this.mapper = mapper;
        }

        #endregion

        #region Métodos Públicos

        public async Task<int> InserirContratante(CadastroContratanteDTO item)
        {
            if (!(await cadastroBusiness.VerificaPermiteCadastrarContratanteBanco(item.Email)))
                return 0; 

            Data.Models.Endereco enderecoCriar = await InserirEnderecoBanco(item);
            return await InserirContratanteBanco(item, enderecoCriar); ;
        }

        public async Task<int> InserirDiarista(CadastroDiaristaDTO item)
        {
            if (!(await cadastroBusiness.VerificaPermiteCadastrarDiaristaBanco(item.Email)))
                return 0;

            Data.Models.Endereco enderecoCriar = await InserirEnderecoBanco(item);
            return await InserirDiaristaBanco(item, enderecoCriar);
        }

        #endregion

        #region Métodos Privados

        private async Task<int> InserirContratanteBanco(CadastroContratanteDTO item, Data.Models.Endereco enderecoCriar)
        {
            var contratanteCriar = mapper.Map<Data.Models.Contratante>(item);
            contratanteCriar.IdEndereco = enderecoCriar.Id;
            contratanteCriar.Senha = criptografiaService.HashearSenha(item.Senha);
            this.uowAppDiarista.Contratante.Add(contratanteCriar);
            await this.uowAppDiarista.SaveChangesAsync();
            return contratanteCriar.Id;
        }

        private async Task<int> InserirDiaristaBanco(CadastroDiaristaDTO item, Data.Models.Endereco enderecoCriar)
        {
            var diaristaCriar = mapper.Map<Data.Models.Diarista>(item);
            diaristaCriar.IdEndereco = enderecoCriar.Id;
            diaristaCriar.Senha = criptografiaService.HashearSenha(item.Senha);
            diaristaCriar.Nota = 0;
            this.uowAppDiarista.Diarista.Add(diaristaCriar);
            await this.uowAppDiarista.SaveChangesAsync();
            return diaristaCriar.Id;
        }

        private async Task<Data.Models.Endereco> InserirEnderecoBanco(CadastroContratanteDTO item)
        {
            var enderecoCriar = mapper.Map<Data.Models.Endereco>(item);
            this.uowAppDiarista.Endereco.Add(enderecoCriar);
            await this.uowAppDiarista.SaveChangesAsync();
            return enderecoCriar;
        }

        private async Task<Data.Models.Endereco> InserirEnderecoBanco(CadastroDiaristaDTO item)
        {
            var enderecoCriar = mapper.Map<Data.Models.Endereco>(item);
            this.uowAppDiarista.Endereco.Add(enderecoCriar);
            await this.uowAppDiarista.SaveChangesAsync();
            return enderecoCriar;
        }

        #endregion
    }
}
