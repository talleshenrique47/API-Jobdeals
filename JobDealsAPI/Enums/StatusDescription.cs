using System.ComponentModel;

namespace JobDealsAPI.Enums
{
    public enum StatusDescription
    {
        [Description("Vazio")]
        SemStatus = 1,
        [Description("Dev Sênior")]
        DevSenior = 2,
        [Description("Dev Pleno")]
        DevPleno = 3,
        [Description("Dev Junior")]
        DevJunior = 4,
        [Description("Estagiário")]
        Estagiario = 5
    }
}
