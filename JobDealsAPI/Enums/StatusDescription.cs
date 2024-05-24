using System.ComponentModel;

namespace JobDealsAPI.Enums
{
    public enum StatusDescription
    {
        [Description("Dev Sênior")]
        DevSenior = 1,
        [Description("Dev Pleno")]
        DevPleno = 2,
        [Description("Dev Junior")]
        DevJunior = 3,
        [Description("Estagiário")]
        Estagiario = 4
    }
}
