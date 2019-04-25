using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Common.Interfaces
{
    public interface ICriptografia
    {
        /// <summary>
        /// Chave interna para o algoritmo de geração de keys. Olha para uma chave no webconfig. Alterações na chave invalidarão todas as keys já geradas
        /// e não poderão ser decriptadas. Como as keys geradas geralmente devem ter validade, não será um problema
        /// </summary>
        string ChavePrivada { get; }
        string EncriptarString(string valorParaEncriptar);
        string DecriptarString(string valorEncriptado);
    }
}
