Public Class frmPrincipal
    Private Sub GunaTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblCriarConta_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblCriarConta.LinkClicked
        Using frmCadastro As New frmCadUsuario
            frmCadastro.ShowDialog(Me)
        End Using
    End Sub
End Class
