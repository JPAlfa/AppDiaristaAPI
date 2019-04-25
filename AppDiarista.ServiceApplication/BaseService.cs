using AppDiarista.Common.Interfaces;
using AppDiarista.Common.Notification;
using AppDiarista.ServiceApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.ServiceApplication
{
    public class BaseService : IBaseService
    {
        #region Propriedades

        public readonly INotificador notificador;

        #endregion

        #region Construtores

        public BaseService(INotificador notificador)
        {
            this.notificador = notificador;
        }

        #endregion
    }
}
