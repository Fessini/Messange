Imports MySql.Data.MySqlClient

Public Class DataAccess
#Region "Variáveis de Acesso a Dados"
    Private conn As MySqlConnection
    Private command As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
#End Region

#Region "Construtor"
    Sub New()
        conn = New MySqlConnection("Server=50.116.87.224;Database=apren208_Falai;Uid=apren208_fessini;Pwd=@mfmf563;")
        conn.Open()
    End Sub
#End Region

#Region "Funções e Subrotinas"
    ''' <summary>
    ''' Sub para fechar a conexão com o banco de dados.
    ''' </summary>
    Public Sub CloseConn()
        Try
            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Função para efetuar consulta.
    ''' </summary>
    ''' <param name="Procedure">Nome da procedure.</param>
    ''' <param name="Parametros">Parametros da procedure.</param>
    ''' <returns></returns>
    Public Function ExecutaStoredProcedureReader(ByVal Procedure As String,
                                          ByVal Parametros As List(Of MySqlParameter)) As Data.IDataReader
        Dim regAffect As Data.IDataReader = Nothing

        Try
            ' Instancia o Command 
            command = New MySqlCommand
            'Cria um Command
            command = conn.CreateCommand()
            'Estipula como Command para Stored Procedure
            command.CommandType = CommandType.StoredProcedure
            ' Passa o nome da procedure para ser executada
            command.CommandText = Procedure
            'Limpar parametros se eles ja existirem no command
            command.Parameters.Clear()

            'Recebe os parametros que vao ser passados para a SP
            For Each Parametro As MySqlParameter In Parametros
                command.Parameters.Add(Parametro)
            Next

            'Executa a Procedure 
            regAffect = command.ExecuteReader()

            Return regAffect

        Catch ex As Exception
            Throw ex
        Finally
            command = Nothing
        End Try

        Return regAffect

    End Function

    ''' <summary>
    ''' Função que executa uma Stored Procedure sem retorno de valores (SP para INSERT, UPDATE, DELETE)
    ''' </summary>
    ''' <param name="Procedure">String: Nome da Procedure a ser executada</param>
    ''' <param name="Parametros">Data.SqlClient.SqlParameterCollection: Coleção de parâmetros a serem passados para a SP</param>
    ''' <returns>Boolean : Retorna a True se deu tudo ok</returns>
    ''' <remarks>Autor: Márcio Fessini</remarks>
    Public Function ExecutaStoredProcedure(ByVal Procedure As String,
                                           ByVal Parametros As List(Of MySqlParameter)) As Boolean


        Try

            ' Instancia o Command 
            command = New MySqlCommand
            'Cria um Command
            command = conn.CreateCommand()
            'Estipula como Command para Stored Procedure
            command.CommandType = CommandType.StoredProcedure
            ' Passa o nome da procedure para ser executada
            command.CommandText = Procedure
            'Limpar parametros se eles ja existirem no command
            command.Parameters.Clear()

            'Recebe os parametros que vao ser passados para a SP
            For Each Parametro As MySqlParameter In Parametros
                command.Parameters.Add(Parametro)
            Next

            'Executa a Procedure 
            command.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw ex
        Finally
            command = Nothing
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Função que executa uma Stored Procedure sem retorno de valores (SP para INSERT, UPDATE, DELETE)
    ''' </summary>
    ''' <param name="Procedure">String: Nome da Procedure a ser executada</param>
    ''' <param name="Parametros">Data.SqlClient.SqlParameterCollection: Coleção de parâmetros a serem passados para a SP</param>
    ''' <returns>Integer: Retorna a quantidade de registros afetados pela SP</returns>
    ''' <remarks>Autor: Márcio Fessini</remarks>
    Public Function ExecutaStoredProcedureDataset(ByVal Procedure As String,
                                           ByVal Parametros As List(Of MySqlParameter)) As Data.DataSet
        Dim regAffect As Data.DataSet

        Try
            ' Instancia o Command 
            command = New MySqlCommand
            'Cria um Command
            command = conn.CreateCommand()
            'Estipula como Command para Stored Procedure
            command.CommandType = CommandType.StoredProcedure
            ' Passa o nome da procedure para ser executada
            command.CommandText = Procedure
            'Limpar parametros se eles ja existirem no command
            command.Parameters.Clear()

            'Recebe os parametros que vao ser passados para a SP
            For Each Parametro As MySqlParameter In Parametros
                command.Parameters.Add(Parametro)
            Next

            da = New MySqlDataAdapter(command)


            'Executa a Procedure e retorna o dataset 
            regAffect = New Data.DataSet
            da.Fill(regAffect)

            Return regAffect

        Catch ex As Exception
            Throw ex
        Finally
            command = Nothing
        End Try

        Return regAffect

    End Function
#End Region
End Class
