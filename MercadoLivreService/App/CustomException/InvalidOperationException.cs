using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.CustomExceptions
{
    public class InvalidOperationException : CustomException
    {
        private string Reason { get; set; } = "Motivo não especificado.";

        public override string Message
        {
            get
            {
                return $"Operação Inválida: {Reason}";
            }
        }

        public InvalidOperationException(string reason)
        {
            Reason = reason;
        }
    }
}
