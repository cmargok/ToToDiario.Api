using static ToToDiario.API.Domain.Enums.Enums;

namespace ToToDiario.API.Domain.Commons
{
    public class BaseOut
    {
        public ResultStatus Result { get; set; }
        public string ResultMessage { get; set; } = string.Empty;
    }
}
