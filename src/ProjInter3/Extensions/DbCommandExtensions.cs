using System.Data;

namespace ProjInter3.Extensions
{
    public static class DbCommandExtensions
    {
        public static void AddParameter(this IDbCommand cmd, string nome, object? valor)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = nome;
            parameter.Value = valor;

            cmd.Parameters.Add(parameter);
        }

    }
}
