using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface ICriptografiaService 
    {
        string HashearSenha(string senha);
    }
}
