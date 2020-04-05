Imports System.Net
Imports System.Net.Mail
Imports AkutipuruPMEBO.MODULO_CONFIGURACOES
Imports System.Drawing
Imports System.IO

Public Class Email

#Region "Construtores e Destrutores"


    'Variavel da imagem
    Private imgLogotipo As Image = Nothing


#End Region

    Property EMAIL_DESTINO As String
    Property EMAIL_DESTINO_NOME As String
    Property EMAIL_COPIA As String
    Property EMAIL_COPIA_NOME As String
    Property CORPO_HTML As String
    Property CORPO_TEXTO As String
    Property ASSUNTO As String
    Property PDF_ANEXO As IO.Stream = Nothing
    Property PDF_ANEXO_NOME As String
    Property ANEXO As Attachment





    Sub a()

        Dim strHTML As String = ""

        strHTML += "<p>Caro Fornecedor,</p>"
        strHTML += "<p>A XXXXXXXXXXXXXX encaminha para vossa empresa solicitação de cotação em anexo.</p> "
        strHTML += "<p>XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX</p>"
        strHTML += "<p>Atenciosamente,</p>"
        strHTML += "<p>XXXXXXXXXXX - Dept. de Compras</p>"
        


        Dim strTexto As String = ""

        strTexto += "Caro Fornecedor, " & vbCrLf
        strTexto += "A XXXXXXXXXXXXXXXXXXXXX encaminha para vossa empresa solicitação de cotação em anexo." & vbCrLf
        strTexto += "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" & vbCrLf
        strTexto += "Atenciosamente," & vbCrLf
        strTexto += "XXXXXXXXXXXXXX - Dept. de Compras" & vbCrLf


    End Sub


    Public Function EnviarEmailAnexo() As Boolean

        Dim objEnvio As Net.Mail.SmtpClient = Nothing 'Variavel com objeto de envio de email
        Dim objEmail As Net.Mail.MailMessage = Nothing 'Variavel com objeto do EMAIL

        'Variável de Retorno
        Dim blnRetorno As Boolean = False


        'Try

        '    objEnvio = New Net.Mail.SmtpClient(Definicoes.Configuracao.m_Smtp, 25) 'Instancia objeto de envio de email
        '    objEmail = New Net.Mail.MailMessage() 'Instancia Mensagem

        '    '### Criar Mensagem de Email
        '    objEmail.To.Add(New Mail.MailAddress(EMAIL_DESTINO, EMAIL_DESTINO_NOME)) 'Adicionar o Email Principal

        '    If EMAIL_COPIA <> "" Then objEmail.To.Add(New Mail.MailAddress(EMAIL_COPIA, EMAIL_COPIA_NOME)) 'Adicionar o Email Secundário se for Necessário

        '    objEmail.From = New Mail.MailAddress(Definicoes.Configuracao.m_EmailEnvio) 'Seta de qual email é enviado
        '    objEmail.Priority = Mail.MailPriority.High 'Seta Alta Prioridade para O Email
        '    objEmail.DeliveryNotificationOptions = Mail.DeliveryNotificationOptions.OnSuccess 'Marca Confirmação de Recebimento
        '    objEmail.Headers.Add("Disposition-Notification-To", Definicoes.Configuracao.m_EmailEnvio) 'Marca para Receber Confirmação de Leitura

        '    'Passa o Corpo do Email Por AlternateView (HTML e Plain Text)

        '    'Criar Corpo do Email em HTML
        '    Dim strBodyHTML As String = CORPO_HTML


        '    'Se existir logotipo na filial, carrega ao final do e-mail
        '    If Not IsNothing(imgLogotipo) Then

        '        strBodyHTML += "<Br><br> <img src=""cid:Logotipo"" /><br>"

        '        Dim myImage As New Bitmap(imgLogotipo)
        '        Dim ic As New ImageConverter()
        '        Dim ba As [Byte]() = DirectCast(ic.ConvertTo(myImage, GetType([Byte]())), [Byte]())
        '        Dim imgLogotipoStream As New MemoryStream(ba)


        '        Dim view As AlternateView = AlternateView.CreateAlternateViewFromString(strBodyHTML, Nothing, Mime.MediaTypeNames.Text.Html)
        '        Dim resource As New LinkedResource(imgLogotipoStream)
        '        resource.ContentId = "Logotipo"
        '        view.LinkedResources.Add(resource)
        '        objEmail.AlternateViews.Add(view)

        '    End If

        '    'Criar Corpo do Email em Texto Purto
        '    Dim strBodyPlainText = CORPO_TEXTO


        '    Dim view2 As AlternateView = AlternateView.CreateAlternateViewFromString(strBodyPlainText, Nothing, Mime.MediaTypeNames.Text.Plain)
        '    objEmail.AlternateViews.Add(view2)

        '    objEmail.IsBodyHtml = True 'Marca que o corpo do email é HTML
        '    objEmail.Subject = ASSUNTO



        '    ''Criar Anexo Anexo do PDF caso ele seja fornecido
        '    'If Not IsNothing(PDF_ANEXO) Then
        '    '    'Criar Anexo Anexo da Proposta
        '    '    Dim objConentType As New Net.Mime.ContentType("application/pdf")
        '    '    Dim objAnexo As New Net.Mail.Attachment(PDF_ANEXO, PDF_ANEXO_NOME & ".pdf", "application/pdf")

        '    '    objEmail.Attachments.Add(objAnexo) 'Colocar o Anexo no Email
        '    'End If

        '    objEmail.Attachments.Add(ANEXO) 'Colocar o Anexo no Email

        '    'Passar credenciais de email, para envio
        '    Dim Credenciais As New NetworkCredential(Definicoes.Configuracao.m_EmailEnvio, Definicoes.Configuracao.m_EmailEnvioSenha)
        '    objEnvio.Credentials = Credenciais

        '    'Enviar Email
        '    objEnvio.Send(objEmail)


        '    'Retorna True
        '    blnRetorno = True

        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'Finally
        '    objEnvio = Nothing 'Mata Variavel com objeto de envio de email
        '    objEmail = Nothing 'Mata Variavel com objeto do EMAIL
        'End Try

        'Return blnRetorno 'Retorna
    End Function


End Class
