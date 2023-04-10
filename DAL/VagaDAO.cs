using CoderCarrer.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CoderCarrer.DAL
{
    public class VagaDAO
    {
        private MySqlConnection _conexao;
        MySqlCommand cmd = new MySqlCommand();
        public VagaDAO()
        {
            _conexao = ConexaoBD.getConexao();
        }
        public List<Vaga> getTodosVagas()
        {
            string sql = "select * from vagas_ti";
            var dados = (List<Vaga>)_conexao.Query<Vaga>(sql);
            return dados;

        }

        string mensagem = "";
        public string Inserirvagas(string data_vaga, string descricao_vaga, string empresa, string salario)
        {
            //this empresa = empresa_;
            cmd.CommandText = "insert into Entrada (data_vaga, descricao,empresa, salario) values (@data_vaga,@descricao @empresa,salario);";
            cmd.Parameters.AddWithValue("@data_vaga", data_vaga);
            cmd.Parameters.AddWithValue("@descricao", descricao_vaga);
            cmd.Parameters.AddWithValue("@empresa", empresa);
            cmd.Parameters.AddWithValue("@salario", salario);
            {
                
                return mensagem;
            }
        }
    }
}