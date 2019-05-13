using AppDiarista.Common.Interfaces;
using AppDiarista.Data.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AppDiarista.ServiceApplication
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        #region Propriedades
        private readonly IDiaristaData diaristaData;
        private readonly IContratanteData contratanteData;
        private readonly ICriptografiaService criptografiaService;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        #endregion

        #region Construtores
        public AuthenticationService(INotificador notificador,
            IDiaristaData diaristaData,
            IContratanteData contratanteData,
            ICriptografiaService criptografiaService,
            IConfiguration configuration,
            IMapper mapper) : base(notificador)
        {
            this.diaristaData = diaristaData;
            this.contratanteData = contratanteData;
            this.criptografiaService = criptografiaService;
            this.configuration = configuration;
            this.mapper = mapper;
        }
        #endregion

        #region Métodos Públicos

        public async Task<UsuarioLogadoDTO> Autenticar(LoginDTO model)
        {
            var diarista = await this.diaristaData.Listar(w => w.Email == model.Email).FirstOrDefaultAsync();
            if (diarista != null && diarista.Senha == criptografiaService.HashearSenha(model.Senha))
                return LogarDiarista(model, mapper.Map<DiaristaDTO>(diarista));

            var contratante = await this.contratanteData.Listar(w => w.Email == model.Email).FirstOrDefaultAsync();
            if (contratante != null && contratante.Senha.Trim() == criptografiaService.HashearSenha(model.Senha))
                return LogarContratante(model, mapper.Map<ContratanteDTO>(contratante));

            return AnalisarErroNoLogin(diarista, contratante);
        }

        #endregion

        #region Métodos Privados

        private UsuarioLogadoDTO LogarContratante(LoginDTO model, ContratanteDTO contratante)
        {
            return new UsuarioLogadoDTO()
            {
                Token = GerarTokenString(model),
                Contratante = contratante
            };
        }

        private UsuarioLogadoDTO LogarDiarista(LoginDTO model, DiaristaDTO diarista)
        {
            return new UsuarioLogadoDTO()
            {
                Token = GerarTokenString(model),
                Diarista = diarista
            };
        }

        private UsuarioLogadoDTO AnalisarErroNoLogin(Data.Models.Diarista diarista, Data.Models.Contratante contratante)
        {
            if (contratante == null && diarista == null)
                notificador.AdicionarNotificacao(new Common.Notification.Notificacao("novoItem", Resource.Mensagens.ErroEmailNaoCadastrado));
            else
                notificador.AdicionarNotificacao(new Common.Notification.Notificacao("novoItem", Resource.Mensagens.ErroSenhaIncorreta));
            return null;
        }

        private string GerarTokenString(LoginDTO model)
        {
            Claim[] direitos = CriarClaims(model);
            SigningCredentials credenciais = GerarCredenciais();
            JwtSecurityToken token = GerarJwtToken(direitos, credenciais);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        private JwtSecurityToken GerarJwtToken(Claim[] direitos, SigningCredentials credenciais)
        {
            var issuer = configuration.GetSection("JwtConfiguration:Issuer").Value;
            var audience = configuration.GetSection("JwtConfiguration:Audience").Value;
            return new JwtSecurityToken(
                            issuer: issuer,
                            audience: audience,
                            claims: direitos,
                            signingCredentials: credenciais,
                            expires: DateTime.Now.AddMinutes(30)
                        );
        }

        private SigningCredentials GerarCredenciais()
        {
            var secret = configuration.GetSection("JwtConfiguration:Secret").Value;
            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            return credenciais;
        }

        private Claim[] CriarClaims(LoginDTO model)
        {
            return new[]
                                            {
                        new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
        }

        #endregion

    }
}
