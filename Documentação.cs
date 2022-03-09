#region assembly BodeOfWarServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\nikol\source\repos\Bode of War\BodeOfWarServer.dll
// Decompiled with ICSharpCode.Decompiler 6.1.0.5902
#endregion

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace BodeOfWarServer
{
    //
    // Resumo:
    //     Interface do jogo Bode of War do Projeto Integrador do BCC
    public class Jogo
    {
        private static DateTime ultimaChamada = DateTime.Now;

        //
        // Resumo:
        //     Exibe a versão do jogo
        public const string Versao = "1.1";

        private const int delay = 200;

        private const double tempoEspera = 0.3;

        //
        // Resumo:
        //     Retorna a lista de partidas do tipo solicitado
        //
        // Parâmetros:
        //   status:
        //     Envie um caracter: (T)odas, (A)bertas, (J)ogando, (E)ncerradas
        public static string ListarPartidas(string status)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_ListarPartidas";
            if (!status.Equals("T"))
            {
                sqlCommand.Parameters.Add("@status", SqlDbType.Char, 1).Value = status;
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Cria uma nova partida
        //
        // Parâmetros:
        //   nome:
        //     Nome da partida (deve ser único)
        //
        //   senha:
        //     Senha da partida (até 10 caracteres)
        public static string CriarPartida(string nome, string senha)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (nome == "")
            {
                return "ERRO:Nome da partida está vazio";
            }

            if (nome.Length > 20)
            {
                return "ERRO:Nome da partida com mais que 20 caracteres";
            }

            if (senha.Length > 10)
            {
                return "ERRO:Senha com mais de 10 caracteres";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_CriarPartida";
            sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar, 20).Value = nome;
            sqlCommand.Parameters.Add("@senha", SqlDbType.VarChar, 10).Value = senha;
            sqlCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = Environment.UserName;
            string result = sqlCommand.ExecuteScalar().ToString();
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return result;
        }

        //
        // Resumo:
        //     Lista de jogadores de uma determinada partida
        //
        // Parâmetros:
        //   idPartida:
        //     Id da partida
        public static string ListarJogadores(int idPartida)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idPartida == 0)
            {
                return "ERRO:Id  da partida está vazio";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_ListarJogadores";
            sqlCommand.Parameters.Add("@idPartida", SqlDbType.Int).Value = idPartida;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Cria um jogador e entra em uma partida
        //
        // Parâmetros:
        //   idPartida:
        //     Id da partida
        //
        //   nome:
        //     Nome do Jogador
        //
        //   senha:
        //     Senha da Partida
        public static string EntrarPartida(int idPartida, string nome, string senha)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idPartida == 0 || senha == "")
            {
                return "ERRO:Id ou Senha da partida está vazio";
            }

            if (nome == "")
            {
                return "ERRO:Nome do jogador está vazio";
            }

            if (senha.Length > 10)
            {
                return "ERRO:Senha com mais de 10 caracteres";
            }

            if (nome.Length > 50)
            {
                return "ERRO:Nome com mais de 50 caracteres";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_EntrarPartida";
            sqlCommand.Parameters.Add("@idPartida", SqlDbType.Int).Value = idPartida;
            sqlCommand.Parameters.Add("@NomeJogador", SqlDbType.VarChar, 50).Value = nome;
            sqlCommand.Parameters.Add("@senhaPartida", SqlDbType.Char, 10).Value = senha;
            sqlCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = Environment.UserName;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text += sqlDataReader[0].ToString();
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Inicia uma partida, mudando seu status para J
        //
        // Parâmetros:
        //   idJogador:
        //
        //   senha:
        public static string IniciarPartida(int idJogador, string senha)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idJogador == 0 || senha == "")
            {
                return "ERRO:Id do jogador ou Senha da partida está vazio";
            }

            if (senha.Length > 10)
            {
                return "ERRO:Senha com mais de 10 caracteres";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_IniciarPartida";
            sqlCommand.Parameters.Add("@idJogador", SqlDbType.Int).Value = idJogador;
            sqlCommand.Parameters.Add("@senhaJogador", SqlDbType.Char, 10).Value = senha;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text += sqlDataReader[0].ToString();
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Retorna o status da partida e o código do jogador que é a vez.
        //
        // Parâmetros:
        //   idPartida:
        //     Id da Partida
        public static string VerificarVez(int idPartida)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idPartida == 0)
            {
                return "ERRO:Id da partida está vazio";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_VerificarVez";
            sqlCommand.Parameters.Add("@idPartida", SqlDbType.Int).Value = idPartida;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            sqlDataReader.NextResult();
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Retorna o que já aconteceu na partida
        //
        // Parâmetros:
        //   idPartida:
        //     Id da Partida
        public static string ExibirNarracao(int idPartida)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idPartida == 0)
            {
                return "ERRO:Id da partida está vazio";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_LerNarracao";
            sqlCommand.Parameters.Add("@idPartida", SqlDbType.Int).Value = idPartida;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Exibe o ID das cartas que o jogador tem na mão
        //
        // Parâmetros:
        //   idJogador:
        //
        //   senha:
        public static string VerificarMao(int idJogador, string senha)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idJogador == 0 || senha == "")
            {
                return "ERRO:Id do jogador ou Senha da partida está vazio";
            }

            if (senha.Length > 10)
            {
                return "ERRO:Senha com mais de 10 caracteres";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_VerificarMao";
            sqlCommand.Parameters.Add("@idJogador", SqlDbType.Int).Value = idJogador;
            sqlCommand.Parameters.Add("@senhaJogador", SqlDbType.Char, 10).Value = senha;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Retorna as cartas existentes no jogo, a quantidade de bodes e o código da figura
        public static string ListarCartas()
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_ListarCartas";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Faz a jogada de uma carta na mesa
        //
        // Parâmetros:
        //   idJogador:
        //     id do Jogador
        //
        //   senha:
        //     Senha do Jogador
        //
        //   idCarta:
        //     id da carta jogada
        public static string Jogar(int idJogador, string senha, int idCarta)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idJogador == 0 || senha == "")
            {
                return "ERRO:Id do jogador ou Senha da partida está vazio";
            }

            if (senha.Length > 10)
            {
                return "ERRO:Senha com mais de 10 caracteres";
            }

            if (idCarta < 1 || idCarta > 50)
            {
                return "ERRO:Id da Carta fora do intervalo existente";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_Jogar";
            sqlCommand.Parameters.Add("@idJogador", SqlDbType.Int).Value = idJogador;
            sqlCommand.Parameters.Add("@senhaJogador", SqlDbType.Char, 10).Value = senha;
            sqlCommand.Parameters.Add("@idCarta", SqlDbType.TinyInt).Value = idCarta;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Exibe os valores da carta de ilha sorteada, para que o jogador escolha um
        //
        // Parâmetros:
        //   idJogador:
        //     id do Jogador
        //
        //   senha:
        //     senha do Jogador
        //
        // Devoluções:
        //     Valor A , Valor B
        public static string VerificarIlha(int idJogador, string senha)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idJogador == 0 || senha == "")
            {
                return "ERRO:Id do jogador ou Senha da partida está vazio";
            }

            if (senha.Length > 10)
            {
                return "ERRO:Senha com mais de 10 caracteres";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_VerificarIlha";
            sqlCommand.Parameters.Add("@idJogador", SqlDbType.Int).Value = idJogador;
            sqlCommand.Parameters.Add("@senhaJogador", SqlDbType.Char, 10).Value = senha;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text += sqlDataReader[0].ToString();
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Define o valor da carta de ilha
        //
        // Parâmetros:
        //   idJogador:
        //     id do Jogador
        //
        //   senha:
        //     senha do Jogador
        //
        //   valor:
        //     Valor escolhido para a ilha
        public static string DefinirIlha(int idJogador, string senha, int valor)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idJogador == 0 || senha == "")
            {
                return "ERRO:Id do jogador ou Senha da partida está vazio";
            }

            if (senha.Length > 10)
            {
                return "ERRO:Senha com mais de 10 caracteres";
            }

            if (valor < 1 || valor > 8)
            {
                return "ERRO:Valor fora do intervalo permitido";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_DefinirIlha";
            sqlCommand.Parameters.Add("@idJogador", SqlDbType.Int).Value = idJogador;
            sqlCommand.Parameters.Add("@senhaJogador", SqlDbType.Char, 10).Value = senha;
            sqlCommand.Parameters.Add("@valor", SqlDbType.TinyInt).Value = valor;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text += sqlDataReader[0].ToString();
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }

        //
        // Resumo:
        //     Exibe a situação da mesa na rodada atual A primeira linha exibe o total permitido
        //     na ilha até então. As linhas seguintes exibem a carta jogada por cada jogador
        //     no formato: jogador,carta
        //
        // Parâmetros:
        //   idPartida:
        //     Id da Partida
        public static string VerificarMesa(int idPartida)
        {
            return VerificarMesa(idPartida, 0);
        }

        //
        // Resumo:
        //     Exibe a situação da mesa em uma determinada rodada A primeira linha exibe o total
        //     permitido na ilha até então. As linhas seguintes exibem a carta jogada por cada
        //     jogador no formato: jogador,carta
        //
        // Parâmetros:
        //   idPartida:
        //     id da Partida
        //
        //   idRodada:
        //     id da Rodada
        public static string VerificarMesa(int idPartida, int idRodada)
        {
            while (ultimaChamada.AddSeconds(0.3) > DateTime.Now)
            {
                Thread.Sleep(200);
            }

            if (idPartida == 0)
            {
                return "ERRO:Id da partida está vazio";
            }

            SqlConnection sqlConnection = Conexao.Conectar();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "pr_VerificarMesa";
            sqlCommand.Parameters.Add("@idPartida", SqlDbType.Int).Value = idPartida;
            if (idRodada != 0)
            {
                sqlCommand.Parameters.Add("@idRodada", SqlDbType.Int).Value = idRodada;
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string text = "";
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            sqlDataReader.NextResult();
            while (sqlDataReader.Read())
            {
                text = text + sqlDataReader[0].ToString() + "\r\n";
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            ultimaChamada = DateTime.Now;
            return text;
        }
    }
}
#if false // Log de descompilação
'13' itens no cache
------------------
Resolver: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Foi encontrado um assembly: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Carregar de: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll'
------------------
Resolver: 'System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Foi encontrado um assembly: 'System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Carregar de: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Data.dll'
#endif
