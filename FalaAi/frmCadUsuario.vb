Imports FalaiDB
Imports FalaiDB.MODULO_CONFIGURACOES.Utils

Public Class frmCadUsuario

    Private Sub btnCriar_Click(sender As Object, e As EventArgs) Handles btnCriar.Click
        Dim use As CAD_USUARIO
        Dim blnValida As Boolean = True

        Try
            'FAZ VALIDAÇÃO DOS CAMPOS
            If txtEmail.TextLength > 0 Then
                If IsValidaEmail(txtEmail.Text) = False Then
                    epValida.SetError(txtEmail, "Formato incorreto de e-mail.")
                    blnValida = False
                End If
            Else
                epValida.SetError(txtEmail, "Favor informar se e-mail para o cadastro.")
                blnValida = False
            End If
            If txtSenha.TextLength = 0 Then
                epValida.SetError(txtSenha, "Favor informar a senha para o cadastro.")
                blnValida = False
            End If
            If txtConfirmarSenha.TextLength = 0 Then
                epValida.SetError(txtConfirmarSenha, "Favor redigitar a senha para o cadastro.")
                blnValida = False
            End If
            If txtConfirmarSenha.Text <> txtSenha.Text Then
                epValida.SetError(txtConfirmarSenha, "A senha não confere.")
                blnValida = False
            End If
            If blnValida = False Then Exit Sub

            'INSTANCIA CLASSE E PREPARA DADOS PARA INCLUSÃO
            use = New CAD_USUARIO
            use.EMAIL_USER = txtEmail.Text
            use.SENHA_USER = txtSenha.Text
            '
            'CHAMA FUNÇÃO DE INCLUSÃO
            If use.NovoUsuario = True Then
                MessageBox.Show("Conta criada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Problema ao tentar criar conta, favor tente mais tarde.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocorreu o seguinte erro:" & vbNewLine & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            use = Nothing
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class