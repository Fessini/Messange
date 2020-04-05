Imports FalaiDB.DataAccess
Imports MySql.Data.MySqlClient
Imports FalaiDB.MODULO_CONFIGURACOES.Criptografia


Public Class CAD_USUARIO
#Region "Propriedades"
    Public Property ID_USER As Integer
    Public Property NOME_USER As String
    Public Property APELIDO_USER As String
    Public Property SENHA_USER As String
    Public Property FOTO_USER As String
    Public Property ADM_USER As String
    Public Property EMAIL_USER As String
#End Region

#Region "Funções"
    Public Function NovoUsuario() As Boolean
        Dim retorno As Boolean = False
        Dim par As New List(Of MySqlParameter)
        Dim conn As New DataAccess

        Try
            par.Add(New MySqlParameter("@SENHA", ComputeHash(SENHA_USER, "SHA1", Nothing)))
            par.Add(New MySqlParameter("@EMAIL", EMAIL_USER))

            retorno = conn.ExecutaStoredProcedure("NOVO_USUARIO", par)

            'Fechar Conexão
            conn.CloseConn()

            Return retorno

        Catch ex As Exception
            Throw ex
        Finally
            conn = Nothing
        End Try
    End Function
#End Region
End Class
