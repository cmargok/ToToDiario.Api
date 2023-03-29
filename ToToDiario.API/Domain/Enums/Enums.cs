using System.ComponentModel;

namespace ToToDiario.API.Domain.Enums
{
    public class Enums
    {       
        public enum ResultStatus
        {
            [field: Description("OutOfUse")]
            OutOfUse,

            [field: Description("Success")]
            Success,

            [field: Description("Error")]
            Error,

            [field: Description("NotFound")]
            NotFound,

            [field: Description("NoRecords")]
            NoRecords,

            [field: Description("ExpiredCode")]
            ExpiredCode,

            [field: Description("NotCreated")]
            NotCreated,

            [field: Description("NotExist")]
            NotExist,
        }

        public enum NotasEstado
        {
            [field: Description("Activo")]
           Activo = 1,

            [field: Description("Leido")]
            Leido = 2,

            [field: Description("Borrado")]
            Borrado = 3, 

        }
    }
}
