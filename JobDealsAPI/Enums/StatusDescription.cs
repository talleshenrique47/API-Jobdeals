using System.ComponentModel;

namespace JobDealsAPI.Enums
{
    public enum StatusDescription
    {
        [Description("A Fazer")]
        AFazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
