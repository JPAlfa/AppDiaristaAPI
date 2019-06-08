using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using AppDiarista.Data.Models;
using AppDiarista.Data.UnitOfWork.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication
{
    public class AgendamentoService : BaseService, IAgendamentoService
    {

        #region Propriedades

        private readonly IServicoData servicoData;
        private readonly IDiaristaData diaristaData;
        private readonly IMapper mapper;
        private readonly IUOWAppDiarista uowAppDiarista;

        #endregion

        #region Construtores

        public AgendamentoService(INotificador notificador, 
            IServicoData servicoData, 
            IDiaristaData diaristaData,
            IMapper mapper,
            IUOWAppDiarista uowAppDiarista) :base(notificador)
        {
            this.servicoData = servicoData;
            this.diaristaData = diaristaData;
            this.mapper = mapper;
            this.uowAppDiarista = uowAppDiarista;
        }

        #endregion

        #region Métodos Públicos

        public async Task<int> AgendarServico(AgendamentoServicoDTO servico)
        {
            return await InserirServicoBanco(servico);
        }

        public async Task ConfirmarServico(int idServico)
        {
             await ConfirmarServicoBanco(idServico);
        }

        public async Task AvaliarServico(int idServico, short nota)
        {
            await AvaliarServicoBanco(idServico, nota);
        }

        public async Task<List<DateTime>> BuscarDiasOcupados(int idDiarista)
        {
            return await BuscarDiasOcupadosBanco(idDiarista);
        }

        #endregion

        #region Métodos Privados

        private async Task<int> InserirServicoBanco(AgendamentoServicoDTO servico)
        {
            var servicoCriar = mapper.Map<Servico>(servico);
            var diarista = await diaristaData.RetornarPorID(servico.IdDiarista);
            servicoCriar.Preco = diarista.PrecoDiaria;  
            servicoCriar.DataServico = servicoCriar.DataServico.Date;
            servicoCriar.Confirmado = false;
            servicoCriar.Realizado = false;
            this.uowAppDiarista.Servico.Add(servicoCriar);
            await this.uowAppDiarista.SaveChangesAsync();
            return servicoCriar.Id;
        }

        private async Task ConfirmarServicoBanco(int idServico)
        {
            var servicoConfirmar = await servicoData.RetornarPorID(idServico);
            uowAppDiarista.Entry(servicoConfirmar).State = EntityState.Detached;
            servicoConfirmar.Confirmado = true;
            uowAppDiarista.Entry(servicoConfirmar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
        }

        private async Task AvaliarServicoBanco(int idServico, short nota)
        {
            var servicoConfirmar = await servicoData.RetornarPorID(idServico);
            uowAppDiarista.Entry(servicoConfirmar).State = EntityState.Detached;
            servicoConfirmar.Realizado = true;
            servicoConfirmar.Nota = nota;
            uowAppDiarista.Entry(servicoConfirmar).State = EntityState.Modified;
            await uowAppDiarista.SaveChangesAsync();
        }

        private async Task<List<DateTime>> BuscarDiasOcupadosBanco(int idDiarista)
        {
            var servicosMarcados = await servicoData.Listar(x => x.IdDiarista == idDiarista && x.DataServico > DateTime.Now).ToListAsync();
            var listaDatas = servicosMarcados.Select(x => x.DataServico).OrderBy(data => data).ToList();
            return listaDatas;
        }

        #endregion
    }
}
