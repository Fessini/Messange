<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GunaShadowPanel1 = New Guna.UI.WinForms.GunaShadowPanel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.txtEmail = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.txtSenha = New Guna.UI.WinForms.GunaTextBox()
        Me.btnEntrar = New Guna.UI.WinForms.GunaButton()
        Me.GunaGoogleSwitch1 = New Guna.UI.WinForms.GunaGoogleSwitch()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.lblCriarConta = New Guna.UI.WinForms.GunaLinkLabel()
        Me.GunaShadowPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaShadowPanel1
        '
        Me.GunaShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaShadowPanel1.BaseColor = System.Drawing.Color.White
        Me.GunaShadowPanel1.Controls.Add(Me.lblCriarConta)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel3)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaGoogleSwitch1)
        Me.GunaShadowPanel1.Controls.Add(Me.btnEntrar)
        Me.GunaShadowPanel1.Controls.Add(Me.txtSenha)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel2)
        Me.GunaShadowPanel1.Controls.Add(Me.txtEmail)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaShadowPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaShadowPanel1.Name = "GunaShadowPanel1"
        Me.GunaShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.GunaShadowPanel1.Size = New System.Drawing.Size(347, 515)
        Me.GunaShadowPanel1.TabIndex = 3
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(74, 149)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(41, 15)
        Me.GunaLabel1.TabIndex = 0
        Me.GunaLabel1.Text = "E-mail"
        '
        'txtEmail
        '
        Me.txtEmail.BaseColor = System.Drawing.Color.White
        Me.txtEmail.BorderColor = System.Drawing.Color.Silver
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.FocusedBaseColor = System.Drawing.Color.White
        Me.txtEmail.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmail.Location = New System.Drawing.Point(68, 167)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmail.Radius = 10
        Me.txtEmail.SelectedText = ""
        Me.txtEmail.Size = New System.Drawing.Size(211, 30)
        Me.txtEmail.TabIndex = 1
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(74, 211)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(39, 15)
        Me.GunaLabel2.TabIndex = 2
        Me.GunaLabel2.Text = "Senha"
        '
        'txtSenha
        '
        Me.txtSenha.BaseColor = System.Drawing.Color.White
        Me.txtSenha.BorderColor = System.Drawing.Color.Silver
        Me.txtSenha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSenha.FocusedBaseColor = System.Drawing.Color.White
        Me.txtSenha.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSenha.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSenha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSenha.Location = New System.Drawing.Point(68, 229)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Radius = 10
        Me.txtSenha.SelectedText = ""
        Me.txtSenha.Size = New System.Drawing.Size(211, 30)
        Me.txtSenha.TabIndex = 3
        '
        'btnEntrar
        '
        Me.btnEntrar.AnimationHoverSpeed = 0.07!
        Me.btnEntrar.AnimationSpeed = 0.03!
        Me.btnEntrar.BaseColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnEntrar.BorderColor = System.Drawing.Color.Black
        Me.btnEntrar.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEntrar.FocusedColor = System.Drawing.Color.Empty
        Me.btnEntrar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEntrar.ForeColor = System.Drawing.Color.White
        Me.btnEntrar.Image = Nothing
        Me.btnEntrar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnEntrar.Location = New System.Drawing.Point(68, 265)
        Me.btnEntrar.Name = "btnEntrar"
        Me.btnEntrar.OnHoverBaseColor = System.Drawing.Color.Aqua
        Me.btnEntrar.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnEntrar.OnHoverForeColor = System.Drawing.Color.White
        Me.btnEntrar.OnHoverImage = Nothing
        Me.btnEntrar.OnPressedColor = System.Drawing.Color.Black
        Me.btnEntrar.Radius = 10
        Me.btnEntrar.Size = New System.Drawing.Size(109, 33)
        Me.btnEntrar.TabIndex = 4
        Me.btnEntrar.Text = "Entrar"
        Me.btnEntrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaGoogleSwitch1
        '
        Me.GunaGoogleSwitch1.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaGoogleSwitch1.CheckedOffColor = System.Drawing.Color.DarkGray
        Me.GunaGoogleSwitch1.CheckedOnColor = System.Drawing.Color.Aqua
        Me.GunaGoogleSwitch1.FillColor = System.Drawing.Color.White
        Me.GunaGoogleSwitch1.Location = New System.Drawing.Point(183, 270)
        Me.GunaGoogleSwitch1.Name = "GunaGoogleSwitch1"
        Me.GunaGoogleSwitch1.Size = New System.Drawing.Size(38, 20)
        Me.GunaGoogleSwitch1.TabIndex = 5
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel3.Location = New System.Drawing.Point(227, 271)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(51, 15)
        Me.GunaLabel3.TabIndex = 6
        Me.GunaLabel3.Text = "Lembrar"
        '
        'lblCriarConta
        '
        Me.lblCriarConta.AutoSize = True
        Me.lblCriarConta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCriarConta.Location = New System.Drawing.Point(74, 313)
        Me.lblCriarConta.Name = "lblCriarConta"
        Me.lblCriarConta.Size = New System.Drawing.Size(94, 15)
        Me.lblCriarConta.TabIndex = 7
        Me.lblCriarConta.TabStop = True
        Me.lblCriarConta.Text = "Criar nova conta"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 515)
        Me.Controls.Add(Me.GunaShadowPanel1)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Falaí"
        Me.GunaShadowPanel1.ResumeLayout(False)
        Me.GunaShadowPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaShadowPanel1 As Guna.UI.WinForms.GunaShadowPanel
    Friend WithEvents btnEntrar As Guna.UI.WinForms.GunaButton
    Friend WithEvents txtSenha As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents txtEmail As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaGoogleSwitch1 As Guna.UI.WinForms.GunaGoogleSwitch
    Friend WithEvents lblCriarConta As Guna.UI.WinForms.GunaLinkLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
End Class
