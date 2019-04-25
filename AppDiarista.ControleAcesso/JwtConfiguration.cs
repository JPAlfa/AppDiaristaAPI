using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.ControleAcesso
{
    public class JwtConfiguration
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string MinutosValidadeToken { get; set; }

        public SymmetricSecurityKey SigningKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
            }
        }

        public SigningCredentials SigningCredentials
        {
            get
            {
                return new SigningCredentials(
                    SigningKey, 
                    SecurityAlgorithms.HmacSha256, 
                    SecurityAlgorithms.Sha512Digest);
            }
        }
    }
}
