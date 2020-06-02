using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.CustomExceptions
{
    public class ValidationException : CustomException
    {
        private string InvalidField { get; set; }
        private string ReasonToBeInvalid { get; set; }
        public override string Message
        {
            get
            {
                if (ReasonToBeInvalid.Length > 0)
                {
                    return $"Erro de validação, o campo '{InvalidField}' está inválido. Motivo:{ReasonToBeInvalid} ";
                }
                else
                {
                    return $"Erro de validação, o campo '{InvalidField}' está inválido.";
                }
            }
        }
        public ValidationException(string invalidField, string reason = "")
        {
            InvalidField = invalidField;
            ReasonToBeInvalid = reason;
        }
    }
}
