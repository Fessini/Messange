Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Namespace MODULO_CONFIGURACOES

    Public Class Configuracao

        Public Shared m_NomeFilialRodando As String = "SisFac"
        Public Shared m_strEmpresa As String = "SisFac"
        Public Shared m_strFilial As String = "SisFac"
        Public Shared m_BancoDados As String = "BODY_TMP"
        Public Shared m_UsuarioBancoDados As String = "sa"
        Public Shared m_SenhaBancoDados As String = "@mf563"
        Public Shared m_ServidorBancoDados As String = "nj2-fessini\sqlexpress"
        Public Shared m_pathRelatorio As String = "C:\NJ2\Akutipuru PME\relatorios"
        Public Shared m_pathRelatorio2 As String = "C:\NJ2\Akutipuru PME\relatorios"
        Public Shared m_DebugMode As Boolean = False
        Public Shared m_Impressora As String = ""
        Public Shared m_Smtp As String = ""
        Public Shared m_EmailEnvio As String = ""
        Public Shared m_EmailEnvioSenha As String = ""
        Public Shared m_Apelido As String = "SisFac"
        Public Shared m_blnVisualizarSemImprimir As Boolean = True
        Public Shared m_blnSystemCompleto As Boolean = True
        Public Shared m_blnMultiplosConfigs As Boolean = False
        Private Shared m_strChave As String = "anereu"


        Public m_configFile As String = "akutipuru.akcfg"
        Private m_configPath As String = ""

        'cria um array de 8-byte para a chave privada
        Private aChave(7) As Byte

        'preenche o vetor de inicialização com alguns valores aleatórios
        Private Vector() As Byte = {&H12, &H44, &H16, &HEE, &H88, &H15, &HDD, &H41}


#Region "Propriedades"
        Private m_intCodigoConfiguracao As Integer
        Public Property CODIGO_CONFIGURACAO() As Integer
            Get
                Return m_intCodigoConfiguracao
            End Get
            Set(ByVal value As Integer)
                m_intCodigoConfiguracao = value
            End Set
        End Property

        Private m_strIDUsuario As String
        Public Property ID_USUARIO() As String
            Get
                Return m_strIDUsuario
            End Get
            Set(ByVal value As String)
                m_strIDUsuario = value
            End Set
        End Property

        Private m_strAlertaContaPagar As Boolean
        Public Property ALERTA_CONTA_PAGAR() As Boolean
            Get
                Return m_strAlertaContaPagar
            End Get
            Set(ByVal value As Boolean)
                m_strAlertaContaPagar = value
            End Set
        End Property


        Private m_strAlertaContaReceber As Boolean
        Public Property ALERTA_CONTA_RECEBER() As Boolean
            Get
                Return m_strAlertaContaReceber
            End Get
            Set(ByVal value As Boolean)
                m_strAlertaContaReceber = value
            End Set
        End Property


        Private m_blnAlertaMovConta As Boolean
        Public Property ALERTA_MOV_CONTA() As Boolean
            Get
                Return m_blnAlertaMovConta
            End Get
            Set(ByVal value As Boolean)
                m_blnAlertaMovConta = value
            End Set
        End Property

        Private m_blnAlertaFerias As Boolean
        Public Property ALERTA_FERIAS As Boolean
            Get
                Return m_blnAlertaFerias
            End Get
            Set(value As Boolean)
                m_blnAlertaFerias = value
            End Set
        End Property

        Private m_strHabilitarAlertas As Boolean
        Public Property HABILITAR_ALERTAS() As Boolean
            Get
                Return m_strHabilitarAlertas
            End Get
            Set(ByVal value As Boolean)
                m_strHabilitarAlertas = value
            End Set
        End Property

        Private m_intTempoVerificarAlertas As Integer
        Public Property TEMPO_VERIFICAR_ALERTA() As Integer
            Get
                Return m_intTempoVerificarAlertas
            End Get
            Set(ByVal value As Integer)
                m_intTempoVerificarAlertas = value
            End Set
        End Property

        Private m_intTempoAlertaVisivel As Integer
        Public Property TEMPO_ALERTA_VISIVEL() As Integer
            Get
                Return m_intTempoAlertaVisivel
            End Get
            Set(ByVal value As Integer)
                m_intTempoAlertaVisivel = value
            End Set
        End Property

        Private m_intDiaReceber As Integer
        Public Property ALERTA_DIA_RECEBER As Integer
            Get
                Return m_intDiaReceber
            End Get
            Set(ByVal value As Integer)
                m_intDiaReceber = value
            End Set
        End Property


        Private m_intDiaPagar As Integer
        Public Property ALERTA_DIA_PAGAR As Integer
            Get
                Return m_intDiaPagar
            End Get
            Set(ByVal value As Integer)
                m_intDiaPagar = value
            End Set
        End Property

        Private m_blnUsarAuditoria As Boolean = True
        ''' <summary>
        ''' HABILITA OU DESABILITA A AUDITORIA DO SISTEMA
        ''' </summary>
        ''' <remarks>Anereu Bighetti (AJB) - 15/10/2008</remarks>
        Public Property USAR_AUDITORIA() As Boolean
            Get
                Return m_blnUsarAuditoria
            End Get
            Set(ByVal value As Boolean)
                m_blnUsarAuditoria = value
            End Set
        End Property


#End Region


#Region "Funções e Subrotinas"

        'cria a chave e o hash da senha
        Private Sub criaChave(ByVal strKey As String)

            ' array de Byte para tratar a senha
            Dim arrByte(7) As Byte

            Dim AscEncod As New ASCIIEncoding
            Dim i As Integer = 0
            AscEncod.GetBytes(strKey, i, strKey.Length, arrByte, i)

            'obtem o valor do hash da senha
            Dim hashSha As New SHA1CryptoServiceProvider
            Dim arrHash() As Byte = hashSha.ComputeHash(arrByte)

            'poe o valor do hash na chave
            For i = 0 To 7
                aChave(i) = arrHash(i)
            Next i
        End Sub

        Private Function CreateMemoryStream_1(ByVal filePath As String) As MemoryStream
            'Step1: read whole FileStream into byte array.
            Dim buffer() As Byte = System.IO.File.ReadAllBytes(filePath)

            'Step2:convert byte array into MemoryStream.  
            Dim ms1 As MemoryStream = New MemoryStream(buffer)
            Return ms1

        End Function

        Public Function Descriptografar(Message As String) As String


            Dim Results As Byte()
            Dim UTF8 As New System.Text.UTF8Encoding()
            Dim HashProvider As New MD5CryptoServiceProvider()
            Dim TDESKey As Byte() = HashProvider.ComputeHash(UTF8.GetBytes(m_strChave))
            Dim TDESAlgorithm As New TripleDESCryptoServiceProvider()

            TDESAlgorithm.Key = TDESKey

            TDESAlgorithm.Mode = CipherMode.ECB

            TDESAlgorithm.Padding = PaddingMode.PKCS7

            Dim DataToDecrypt As Byte() = Convert.FromBase64String(Message)

            Try
                Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor()
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)
            Finally
                TDESAlgorithm.Clear()
                HashProvider.Clear()
            End Try

            Return UTF8.GetString(Results)

        End Function


        Public Function Criptografar(Message As String) As String


            Dim Results As Byte()
            Dim UTF8 As New System.Text.UTF8Encoding()
            Dim HashProvider As New MD5CryptoServiceProvider()
            Dim TDESKey As Byte() = HashProvider.ComputeHash(UTF8.GetBytes(m_strChave))
            Dim TDESAlgorithm As New TripleDESCryptoServiceProvider()

            TDESAlgorithm.Key = TDESKey
            TDESAlgorithm.Mode = CipherMode.ECB
            TDESAlgorithm.Padding = PaddingMode.PKCS7

            Dim DataToEncrypt As Byte() = UTF8.GetBytes(Message)

            Try
                Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor()
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)
            Finally
                TDESAlgorithm.Clear()
                HashProvider.Clear()
            End Try

            Return Convert.ToBase64String(Results)

        End Function


        Private Sub Decifrar(ByVal inName As String, ByVal outName As String)

            Try

                Dim storage(4096) As Byte
                Dim totalBytesEscritos As Long = 8
                Dim tamanhoPacote As Integer

                Dim arqEntrada As MemoryStream = Nothing
                arqEntrada = CreateMemoryStream_1(inName)

                'Dim arqEntrada As New FileStream(inName, FileMode.Open, FileAccess.Read)

                Dim arqSaida As New FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write)

                arqSaida.SetLength(0)

                Dim comprimentoTotalArquivo As Long = arqEntrada.Length
                'instancia um objeto para cifrar
                Dim des As New DESCryptoServiceProvider
                Dim crStream As New CryptoStream(arqSaida, des.CreateDecryptor(aChave, Vector), CryptoStreamMode.Write)


                While totalBytesEscritos < comprimentoTotalArquivo
                    tamanhoPacote = arqEntrada.Read(storage, 0, 4096)
                    crStream.Write(storage, 0, tamanhoPacote)
                    totalBytesEscritos = Convert.ToInt32(totalBytesEscritos + tamanhoPacote / des.BlockSize * des.BlockSize)
                    Console.WriteLine("Processed {0} bytes, {1} bytes total", tamanhoPacote, totalBytesEscritos)
                End While

                crStream.Close()

            Catch e As Exception
                MsgBox(e.Message & "  Verifique se esta usando a senha correta.")
            End Try

        End Sub

        Private Sub Cifrar(ByVal inName As String, ByVal outName As String)
            Try
                Dim storage(4096) As Byte          'cria um buffer
                Dim totalBytesEscritos As Long = 8  'bytes escritos

                Dim tamanhoPacote As Integer         'determina o numero de bytes escritos de uma vez

                'Declara os arquivos  streams. 
                ' Dim arqEntrada As New FileStream(inName, FileMode.OpenOrCreate, FileAccess.ReadWrite)

                Dim arqEntrada As MemoryStream = Nothing
                arqEntrada = CreateMemoryStream_1(inName)

                Dim arqSaida As New FileStream(outName, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                arqSaida.SetLength(0)

                Dim comprimentoTotalArquivo As Long = arqEntrada.Length       'Define o tamanho do arquivo fonte

                'cria um objeto cripto
                Dim des As New DESCryptoServiceProvider

                Dim crStream As New CryptoStream(arqSaida, des.CreateEncryptor(aChave, Vector), CryptoStreamMode.Write)

                'fluxo de streamd
                While totalBytesEscritos < comprimentoTotalArquivo
                    tamanhoPacote = arqEntrada.Read(storage, 0, 4096)
                    crStream.Write(storage, 0, tamanhoPacote)
                    totalBytesEscritos = Convert.ToInt32(totalBytesEscritos + tamanhoPacote / des.BlockSize * des.BlockSize)
                End While

                crStream.Close()
            Catch e As Exception
                MsgBox(e.Message)
            End Try

        End Sub



        Public Sub BuscarConfiguracoes(ByVal blnArquivoEspecifico As Boolean, Optional ByVal strCaminhoEspecifico As String = "")
            If blnArquivoEspecifico = True Then
                m_configPath = strCaminhoEspecifico
                m_configFile = FileIO.FileSystem.GetName(strCaminhoEspecifico)
            Else
                m_configPath = Environment.CurrentDirectory
                m_configPath = m_configPath & "\" & m_configFile
            End If

            If System.IO.File.Exists(m_configFile) = True Then

                criaChave(m_strChave)

                Decifrar(m_configFile, m_configFile)

                Dim dsXML As New Data.DataSet
                dsXML.ReadXml(m_configFile)

                m_UsuarioBancoDados = dsXML.Tables(0).Rows(0).Item("user").ToString
                m_SenhaBancoDados = dsXML.Tables(0).Rows(0).Item("senha").ToString
                m_BancoDados = dsXML.Tables(0).Rows(0).Item("banco").ToString
                m_ServidorBancoDados = dsXML.Tables(0).Rows(0).Item("servidor").ToString

                m_pathRelatorio = dsXML.Tables(0).Rows(0).Item("relatorio").ToString
                m_pathRelatorio2 = dsXML.Tables(0).Rows(0).Item("relatorio").ToString

                If dsXML.Tables(0).Rows(0).Item("debugmode").ToString = "TRUE" Then
                    m_DebugMode = True
                End If

                m_Impressora = dsXML.Tables(0).Rows(0).Item("impressora").ToString

                m_Smtp = dsXML.Tables(0).Rows(0).Item("smtp").ToString
                m_EmailEnvio = dsXML.Tables(0).Rows(0).Item("email").ToString
                m_EmailEnvioSenha = dsXML.Tables(0).Rows(0).Item("emailsenha").ToString

                m_Apelido = dsXML.Tables(0).Rows(0).Item("apelido").ToString

                criaChave(m_strChave)  'cria a chave

                Cifrar(m_configFile, m_configFile)

            Else
                Throw New Exception("Não existe arquivo de configuração válido!")
            End If
        End Sub

#End Region


    End Class


End Namespace
