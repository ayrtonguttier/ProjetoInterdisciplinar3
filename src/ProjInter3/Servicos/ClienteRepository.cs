using ProjInter3.Extensions;
using ProjInter3.Models;
using System.Data;
using System.Data.Common;

namespace ProjInter3.Servicos
{
    public class ClienteRepository
    {
        private readonly IDbConnection connection;

        public ClienteRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Add(ClienteModel cliente)
        {
            connection.Open();
            using var cmd = connection.CreateCommand();
            string cmdTxt = "INSERT INTO TB_CLIENTE (NOME, SOBRENOME, CPF) VALUES (@NOME, @SOBRENOME, @CPF);\nSELECT LAST_INSERT_ID();";
            cmd.CommandText = cmdTxt;

            cmd.AddParameter("@NOME", cliente.Nome);
            cmd.AddParameter("@SOBRENOME", cliente.Sobrenome);
            cmd.AddParameter("@CPF", cliente.Cpf);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        internal ClienteModel? GetById(int idCliente)
        {
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID, NOME, SOBRENOME, CPF FROM TB_CLIENTE WHERE ID = @ID";
            cmd.AddParameter("@ID", idCliente);

            using var reader = cmd.ExecuteReader();

            var cliente = new ClienteModel();

            reader.Read();
            cliente.Id = reader.GetInt32(0);
            cliente.Nome = reader.GetString(1);
            cliente.Sobrenome = reader.GetString(2);
            cliente.Cpf = reader.GetString(3);
            connection.Close();

            return cliente;
        }
    }
}
