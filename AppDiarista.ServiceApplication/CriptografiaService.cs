using AppDiarista.Common.Interfaces;
using AppDiarista.ServiceApplication.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.ServiceApplication
{
    public class CriptografiaService : BaseService, ICriptografiaService
    {
        #region Propriedades
        private readonly string chave = "z8VJq)kiKBGllEeb2piZwXcEtrTlQD&9KM$qcXGb";
        private readonly int qtdIteracoes = 10000;
        #endregion

        #region Construtores

        public CriptografiaService(INotificador notificador) : base(notificador) { }
        
        #endregion

        public string HashearSenha(string senha)
        {
            byte[] salt = Encoding.ASCII.GetBytes(chave);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: qtdIteracoes,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
