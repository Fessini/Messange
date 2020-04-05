Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions

Namespace MODULO_CONFIGURACOES

    Public Class Utils

#Region "Funções e Subrotinas"
        Public Shared Function IsValidaEmail(ByVal email As String) As Boolean
            Dim padraoRegex As String = "^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\." &
        "(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
            Dim verifica As New RegularExpressions.Regex(padraoRegex, RegexOptions.IgnorePatternWhitespace)
            Dim valida As Boolean = False
            'verifica se foi informado um email
            If String.IsNullOrEmpty(email) Then
                valida = False
            Else
                'usar IsMatch para validar o email
                valida = verifica.IsMatch(email)
            End If
            'retorna o valor
            Return valida
        End Function

        ''' <summary>
        ''' Função para fazer Pad Centralizado de texto
        ''' </summary>
        ''' <param name="text"></param>
        ''' <param name="newWidth"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function PadCenter(text As String, newWidth As Integer) As String
            Const filler As Char = " "c
            Dim length As Integer = text.Length
            Dim charactersToPad As Integer = newWidth - length
            If charactersToPad < 0 Then
                text = text.Remove(length - Math.Abs(charactersToPad))
                Return text
            End If

            Dim padLeft As Integer = charactersToPad / 2 + charactersToPad Mod 2
            'add a space to the left if the string is an odd number
            Dim padRight As Integer = charactersToPad / 2

            Dim resultBuilder As New StringBuilder(newWidth)
            For i As Integer = 0 To padLeft - 1
                resultBuilder.Insert(i, filler)
            Next
            For i As Integer = 0 To length - 1
                resultBuilder.Insert(i + padLeft, text(i))
            Next
            For i As Integer = newWidth - padRight To newWidth - 1
                resultBuilder.Insert(i + 1, filler)
                If resultBuilder.Length = newWidth Then Exit For
            Next
            Return resultBuilder.ToString()
        End Function



        Public Shared Function RedimensionarImagem(ByVal OriImg As Image, Optional ByVal MaxLargura As Integer = 0, Optional ByVal MaxAltura As Integer = 0) As Image

            Dim img As Image
            Dim obj As Utils
            obj = New Utils()

            img = obj.Redimensionar(OriImg, MaxLargura, MaxAltura)

            Return img

        End Function


        Public Function Redimensionar(ByVal OriImg As Image, Optional ByVal MaxLargura As Integer = 0, Optional ByVal MaxAltura As Integer = 0) As Image

            Dim MaxH As Integer = MaxAltura
            Dim MaxW As Integer = MaxLargura


            If OriImg.Width > OriImg.Height Then
                'Padrão Paisagem
                If OriImg.Width > MaxW Then
                    MaxH = Convert.ToInt32(OriImg.Height * MaxW / OriImg.Width)
                Else
                    MaxW = OriImg.Width
                    MaxH = OriImg.Height
                End If
            Else
                'Padrão Retrato  
                If OriImg.Height > MaxH Then
                    'MaxH = OriImg.Height
                    MaxW = Convert.ToInt32(OriImg.Width * MaxW / OriImg.Height)
                Else
                    MaxW = OriImg.Width
                    MaxH = OriImg.Height
                End If
            End If

            OriImg = OriImg.GetThumbnailImage(MaxW, MaxH, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf MyCallbackDelegate), System.IntPtr.Zero)
            Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
            OriImg.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim MsAr As Byte() = MS.ToArray()



            OriImg = ByteArrayToImagem(MsAr)

            Return OriImg

        End Function

        Private Function MyCallbackDelegate() As Boolean
            Return False
        End Function




        Public Shared Function ConverterTextoEntityNumber(Texto As String) As String
            Return System.Net.WebUtility.HtmlEncode(Texto)
        End Function


        ''' <summary>
        ''' Função para transformar aquivo físico em String Base64
        ''' </summary>
        ''' <param name="strCaminhoArquivo">String: Caminho físico do arquivo (Ex: 'c:\temp\arquivo.pdf')</param>
        ''' <returns>String: String Base 64 do arquivo físico</returns>
        ''' <remarks></remarks>
        Public Shared Function ArquivoParaBase64(ByVal strCaminhoArquivo As String) As String

            'Le o arquivo e tranforma ele em Bytes
            Dim arquivoBytes As Byte() = File.ReadAllBytes(strCaminhoArquivo)

            'Transforma os bytes em string base 64
            Dim arquivoBase64 As String = Convert.ToBase64String(arquivoBytes)

            Return arquivoBase64

        End Function

        ''' <summary>
        ''' Abrir um arquivo em Base 64
        ''' </summary>
        ''' <param name="strStringBase64">Srting: String Base 64 do arquivo a ser aberto</param>
        ''' <param name="strExt">String: Extensção do arquivo a ser aberto (Ex:  "pdf")</param>
        Public Shared Function AbrirArquivoBase64(ByVal strStringBase64 As String,
                                                  ByVal strExt As String) As Boolean

            'Pega a String Base 64 e tranforma em Binário
            Dim arquivoBinario() As Byte = Convert.FromBase64String(strStringBase64)

            'Cria o arquivo temporário com o tipo de extenção fornecida
            Dim file As String = Path.GetTempFileName().Replace(".tmp", "." & strExt)

            'Carrega os dados no arquivo e fecha
            Using fileStream As IO.FileStream = IO.File.OpenWrite(file)
                fileStream.Write(arquivoBinario, 0, CInt(arquivoBinario.Length))
                fileStream.Close()
            End Using

            'Abre o arquivo
            Try
                System.Diagnostics.Process.Start(file)
            Catch ex As Exception
                Return False
            End Try

            Return True
        End Function


        Public Shared Function LimparArquivosTemporarios() As Boolean

            Dim filePath As String

            Try
                For Each filePath In Directory.GetFiles(Path.GetTempPath, "*.pdf", SearchOption.AllDirectories).Union(Directory.GetFiles(Path.GetTempPath, "*.xml", SearchOption.AllDirectories))
                    Try
                        Dim currentFile As FileInfo = New FileInfo(filePath)
                        currentFile.Delete()
                    Catch ex As Exception
                        Debug.WriteLine("Error on file: {0}\r\n   {1}", filePath, ex.Message)
                    End Try
                Next
            Catch ex As Exception
                Debug.WriteLine("Error on file: {0}\r\n   {1}", "LimparArquivosTemporarios", ex.Message)
            End Try



            Return True
        End Function



        Public Shared Function Decode_FromBase64(ByVal base64BinaryStr As String) As Byte()
            Dim bytes As Byte() = Nothing

            Try
                bytes = System.Convert.FromBase64String(base64BinaryStr)

            Catch ex As Exception
                Throw New Exception("Não Foi Possivel Decodificar arquivo Base64")
            End Try

            Return bytes
        End Function


        Public Shared Function OpenPDFStream(ByVal buffer() As Byte) As IO.Stream

            Dim file As String = Path.GetTempFileName().Replace(".tmp", ".pdf")


            Dim fileStream As IO.FileStream = IO.File.OpenWrite(file)
            fileStream.Write(buffer, 0, CInt(buffer.Length))
            fileStream.Close()




            Return fileStream
        End Function

        Public Shared Function OpenPDF(ByVal buffer() As Byte) As Boolean

            Dim file As String = Path.GetTempFileName().Replace(".tmp", ".pdf")


            Using fileStream As IO.FileStream = IO.File.OpenWrite(file)
                fileStream.Write(buffer, 0, CInt(buffer.Length))
                fileStream.Close()
            End Using

            System.Diagnostics.Process.Start(file)

            Return True
        End Function

        Public Shared Function OpenXML(ByVal buffer() As Byte) As Boolean

            Dim file As String = Path.GetTempFileName().Replace(".tmp", ".xml")


            Using fileStream As IO.FileStream = IO.File.OpenWrite(file)
                fileStream.Write(buffer, 0, CInt(buffer.Length))
                fileStream.Close()
            End Using

            System.Diagnostics.Process.Start(file)


            Return True
        End Function


        Public Shared Function SeNaoForDBNull(ByVal Objeto As Object) As Boolean


            Dim blnRetorno As Boolean = False

            Try

                If Not IsNothing(Objeto) Then
                    If Not IsDBNull(Objeto) Then
                        blnRetorno = True
                    Else
                        blnRetorno = False
                    End If
                Else
                    blnRetorno = False
                End If

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

            Return blnRetorno

        End Function

        Public Shared Function SeNaoForVazio(ByVal Objeto As Object) As Boolean

            Dim blnRetorno As Boolean = False
            Dim Tipo As System.Type

            Try


                If Not IsNothing(Objeto) Then

                    Tipo = Objeto.GetType

                    If Tipo = GetType(Decimal) Then

                        If Objeto <> Decimal.MinValue Then
                            blnRetorno = True
                        End If

                    ElseIf Tipo = GetType(String) Then

                        If Objeto <> String.Empty Then
                            blnRetorno = True
                        End If

                    ElseIf Tipo = GetType(Integer) Then

                        If Objeto <> Integer.MinValue Then
                            blnRetorno = True
                        End If

                    ElseIf Tipo = GetType(Double) Then

                        If Objeto <> Double.MinValue Then
                            blnRetorno = True
                        End If

                    ElseIf Tipo = GetType(Date) Then

                        If Objeto <> Date.MinValue Then
                            blnRetorno = True
                        End If
                    ElseIf Tipo = GetType(SByte) Then
                        If Objeto <> SByte.MinValue Then
                            blnRetorno = True
                        End If
                    Else
                        MsgBox("O Tipo de dados - " & Tipo.Name & " não foi tratado na função 'SeNaoForVazio'. Por favor, verificar")
                        blnRetorno = False
                    End If
                Else
                    blnRetorno = False
                End If

            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                Tipo = Nothing
            End Try

            Return blnRetorno

        End Function


        ''' <summary>
        ''' Função que substitui o valor char para Boolean
        ''' ( S = True , N = False )
        ''' </summary>
        ''' <param name="strValor">Char</param>
        ''' <returns>Boolean</returns>
        ''' <remarks>Anereu Bighetti</remarks>
        Shared Function GetBooleanFromChar(ByVal strValor As Char) As Boolean
            Dim blnRetorno As Boolean = False

            If strValor = "S" Then
                blnRetorno = True
            ElseIf strValor = "N" Then
                blnRetorno = False
            End If

            Return blnRetorno
        End Function

        ''' <summary>
        ''' Função que substitui o valor Boolean para Char
        ''' ( True = S, False = N )
        ''' </summary>
        ''' <param name="blnValor">Boolean</param>
        ''' <returns>Char</returns>
        ''' <remarks>Anereu Bighetti</remarks>
        Shared Function GetCharFromBoolean(ByVal blnValor As Boolean) As Char
            Dim blnRetorno As Char = ""

            If blnValor = True Then
                blnRetorno = "S"
            ElseIf blnValor = False Then
                blnRetorno = "N"
            End If

            Return blnRetorno
        End Function

        Shared Function ByteArrayToImagem(ByVal byteArrayIn As Byte()) As Image
            Dim returnImage As Image = Nothing
            Dim ms As IO.MemoryStream

            Try
                ms = New IO.MemoryStream(byteArrayIn)
                returnImage = Image.FromStream(ms)
            Catch ex As Exception
                Throw ex
            End Try

            Return returnImage

        End Function

        Shared Function ImagemToByteArray(ByVal picFoto As Image) As Byte()

            Dim ms As New IO.MemoryStream
            Dim photo As Byte()

            Try
                picFoto.Save(ms, Drawing.Imaging.ImageFormat.Bmp)

                photo = ms.GetBuffer()
                ms.Close()

                ms.Close()
            Catch ex As Exception
                Throw ex
            End Try

            Return photo

        End Function

#End Region

#Region "Conversão de Numeros em Reais"



        ''' <summary>
        ''' Função principal que recolhe o valor e chama as duas funções
        ''' auxiliares para a parte inteira e para a parte decimal
        ''' </summary>
        ''' <param name="number">Número a converter para extenso (Reais)</param>
        ''' 
        Public Function NumeroToExtenso(ByVal number As Decimal) As String
            Dim cent As Integer
            Try
                ' se for =0 retorna 0 reais
                If number = 0 Then
                    Return "Zero Reais"
                End If
                ' Verifica a parte decimal, ou seja, os centavos
                cent = Decimal.Round((number - Int(number)) * 100, MidpointRounding.ToEven)
                ' Verifica apenas a parte inteira
                number = Int(number)
                ' Caso existam centavos
                If cent > 0 Then
                    ' Caso seja 1 não coloca "Reais" mas sim "Real"
                    If number = 1 Then
                        Return "Um Real e " + getDecimal(cent) + "centavos "
                        ' Caso o valor seja inferior a 1 Real
                    ElseIf number = 0 Then
                        Return getDecimal(cent) + "centavos "
                    Else
                        Return getInteger(number) + "Reais e " + getDecimal(cent) + "centavos "
                    End If
                Else
                    ' Caso seja 1 não coloca "Reais" mas sim "Real"
                    If number = 1 Then
                        Return "Um Real "
                    Else
                        Return getInteger(number) + "Reais "
                    End If
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' Função auxiliar - Parte decimal a converter
        ''' </summary>
        ''' <param name="number">Parte decimal a converter</param>
        Private Function getDecimal(ByVal number As Byte) As String
            Try
                Select Case number
                    Case 0
                        Return ""
                    Case 1 To 19
                        Dim strArray() As String = _
                           {"Um ", "Dois ", "Três ", "Quatro ", "Cinco ", "Seis ", _
                            "Sete ", "Oito ", "Nove ", "Dez ", "Onze ", _
                            "Doze ", "Treze ", "Quatorze ", "Quinze ", _
                            "Dezesseis ", "Dezessete ", "Dezoito ", "Dezenove "}
                        Return strArray(number - 1) + " "
                    Case 20 To 99
                        Dim strArray() As String = _
                            {"Vinte ", "Trinta ", "Quarenta ", "Cinquenta ", _
                            "Sessenta ", "Setenta ", "Oitenta ", "Noventa "}
                        If (number Mod 10) = 0 Then
                            Return strArray(number \ 10 - 2) + " "
                        Else
                            Return strArray(number \ 10 - 2) + " e " + getDecimal(number Mod 10) + " "
                        End If
                    Case Else
                        Return ""
                End Select
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' Função auxiliar - Parte inteira a converter
        ''' </summary>
        ''' <param name="number">Parte inteira a converter</param>
        Private Function getInteger(ByVal number As Decimal) As String
            Try
                number = Int(number)
                Select Case number
                    Case Is < 0
                        Return "-" & getInteger(-number)
                    Case 0
                        Return ""
                    Case 1 To 19
                        Dim strArray() As String = _
                            {"Um ", "Dois ", "Três ", "Quatro ", "Cinco ", "Seis ", _
                            "Sete ", "Oito ", "Nove ", "Dez ", "Onze ", "Doze ", _
                            "Treze ", "Quatorze ", "Quinze ", "Dezesseis ", _
                            "Dezessete ", "Dezoito ", "Dezenove "}
                        Return strArray(number - 1) + " "
                    Case 20 To 99
                        Dim strArray() As String = _
                            {"Vinte ", "Trinta ", "Quarenta ", "Cinquenta ", _
                            "Sessenta ", "Setenta ", "Oitenta ", "Noventa "}
                        If (number Mod 10) = 0 Then
                            Return strArray(number \ 10 - 2)
                        Else
                            Return strArray(number \ 10 - 2) + " e " + getInteger(number Mod 10)
                        End If
                    Case 100
                        Return "Cem "
                    Case 101 To 999
                        Dim strArray() As String = _
                               {"Cento ", "Duzentos ", "Trezentos ", "Quatrocentos ", "Quinhentos ", _
                               "Seiscentos ", "Setecentos ", "Oitocentos ", "Novecentos "}
                        If (number Mod 100) = 0 Then
                            Return strArray(number \ 100 - 1) + " "
                        Else
                            Return strArray(number \ 100 - 1) + " e " + getInteger(number Mod 100)
                        End If
                    Case 1000 To 1999
                        Select Case (number Mod 1000)
                            Case 0
                                Return "Mil "
                            Case Is <= 100
                                Return "Mil e " + getInteger(number Mod 1000)
                            Case Else
                                Return "Mil , " + getInteger(number Mod 1000)
                        End Select
                    Case 2000 To 999999
                        Select Case (number Mod 1000)
                            Case 0
                                Return getInteger(number \ 1000) & "Mil "
                            Case Is <= 100
                                Return getInteger(number \ 1000) & "Mil e " & getInteger(number Mod 1000)
                            Case Else
                                Return getInteger(number \ 1000) & "Mil , " & getInteger(number Mod 1000)
                        End Select
                    Case 1000000 To 1999999
                        Select Case (number Mod 1000000)
                            Case 0
                                Return "Um Milhão "
                            Case Is <= 100
                                Return getInteger(number \ 1000000) + "Milhão e " & getInteger(number Mod 1000000)
                            Case Else
                                Return getInteger(number \ 1000000) + "Milhão, " & getInteger(number Mod 1000000)
                        End Select
                    Case 2000000 To 999999999
                        Select Case (number Mod 1000000)
                            Case 0
                                Return getInteger(number \ 1000000) + " Milhões "
                            Case Is <= 100
                                Return getInteger(number \ 1000000) + "Milhões e " & getInteger(number Mod 1000000)
                            Case Else
                                Return getInteger(number \ 1000000) + "Milhões, " & getInteger(number Mod 1000000)
                        End Select
                    Case 1000000000 To 1999999999
                        Select Case (number Mod 1000000000)
                            Case 0
                                Return "Um Bilhão "
                            Case Is <= 100
                                Return getInteger(number \ 1000000000) + "Bilhão e " + getInteger(number Mod 1000000000)
                            Case Else
                                Return getInteger(number \ 1000000000) + "Bilhão, " + getInteger(number Mod 1000000000)
                        End Select
                    Case Else
                        Select Case (number Mod 1000000000)
                            Case 0
                                Return getInteger(number \ 1000000000) + " Bilhões "
                            Case Is <= 100
                                Return getInteger(number \ 1000000000) + "Bilhões e " + getInteger(number Mod 1000000000)
                            Case Else
                                Return getInteger(number \ 1000000000) + "Bilhões, " + getInteger(number Mod 1000000000)
                        End Select
                End Select
            Catch ex As Exception
                Return ""
            End Try
        End Function


#End Region

    End Class

End Namespace
