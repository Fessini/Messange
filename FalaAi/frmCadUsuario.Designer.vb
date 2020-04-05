<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadUsuario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GunaShadowPanel1 = New Guna.UI.WinForms.GunaShadowPanel()
        Me.btnCancelar = New Guna.UI.WinForms.GunaButton()
        Me.btnCriar = New Guna.UI.WinForms.GunaButton()
        Me.txtConfirmarSenha = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.txtSenha = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.txtEmail = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.epValida = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GunaShadowPanel1.SuspendLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaShadowPanel1
        '
        Me.GunaShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaShadowPanel1.BaseColor = System.Drawing.Color.White
        Me.GunaShadowPanel1.Controls.Add(Me.btnCancelar)
        Me.GunaShadowPanel1.Controls.Add(Me.btnCriar)
        Me.GunaShadowPanel1.Controls.Add(Me.txtConfirmarSenha)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel3)
        Me.GunaShadowPanel1.Controls.Add(Me.txtSenha)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel2)
        Me.GunaShadowPanel1.Controls.Add(Me.txtEmail)
        Me.GunaShadowPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaShadowPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaShadowPanel1.Name = "GunaShadowPanel1"
        Me.GunaShadowPanel1.ShadowColor = System.Drawing.Color.Black
        Me.GunaShadowPanel1.Size = New System.Drawing.Size(354, 256)
        Me.GunaShadowPanel1.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.AnimationHoverSpeed = 0.07!
        Me.btnCancelar.AnimationSpeed = 0.03!
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BaseColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCancelar.BorderColor = System.Drawing.Color.Black
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnCancelar.FocusedColor = System.Drawing.Color.Empty
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Image = Nothing
        Me.btnCancelar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnCancelar.Location = New System.Drawing.Point(199, 200)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.OnHoverBaseColor = System.Drawing.Color.Aqua
        Me.btnCancelar.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnCancelar.OnHoverForeColor = System.Drawing.Color.White
        Me.btnCancelar.OnHoverImage = Nothing
        Me.btnCancelar.OnPressedColor = System.Drawing.Color.Black
        Me.btnCancelar.Radius = 10
        Me.btnCancelar.Size = New System.Drawing.Size(126, 33)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCriar
        '
        Me.btnCriar.AnimationHoverSpeed = 0.07!
        Me.btnCriar.AnimationSpeed = 0.03!
        Me.btnCriar.BackColor = System.Drawing.Color.Transparent
        Me.btnCriar.BaseColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCriar.BorderColor = System.Drawing.Color.Black
        Me.btnCriar.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnCriar.FocusedColor = System.Drawing.Color.Empty
        Me.btnCriar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCriar.ForeColor = System.Drawing.Color.White
        Me.btnCriar.Image = Nothing
        Me.btnCriar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnCriar.Location = New System.Drawing.Point(29, 200)
        Me.btnCriar.Name = "btnCriar"
        Me.btnCriar.OnHoverBaseColor = System.Drawing.Color.Aqua
        Me.btnCriar.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnCriar.OnHoverForeColor = System.Drawing.Color.White
        Me.btnCriar.OnHoverImage = Nothing
        Me.btnCriar.OnPressedColor = System.Drawing.Color.Black
        Me.btnCriar.Radius = 10
        Me.btnCriar.Size = New System.Drawing.Size(126, 33)
        Me.btnCriar.TabIndex = 7
        Me.btnCriar.Text = "Criar"
        Me.btnCriar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtConfirmarSenha
        '
        Me.txtConfirmarSenha.BackColor = System.Drawing.Color.Transparent
        Me.txtConfirmarSenha.BaseColor = System.Drawing.Color.White
        Me.txtConfirmarSenha.BorderColor = System.Drawing.Color.Silver
        Me.txtConfirmarSenha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConfirmarSenha.FocusedBaseColor = System.Drawing.Color.White
        Me.txtConfirmarSenha.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtConfirmarSenha.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.txtConfirmarSenha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConfirmarSenha.Location = New System.Drawing.Point(29, 164)
        Me.txtConfirmarSenha.MaxLength = 8
        Me.txtConfirmarSenha.Name = "txtConfirmarSenha"
        Me.txtConfirmarSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmarSenha.Radius = 10
        Me.txtConfirmarSenha.SelectedText = ""
        Me.txtConfirmarSenha.Size = New System.Drawing.Size(296, 30)
        Me.txtConfirmarSenha.TabIndex = 6
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel3.Location = New System.Drawing.Point(35, 146)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(96, 15)
        Me.GunaLabel3.TabIndex = 5
        Me.GunaLabel3.Text = "Confirmar Senha"
        '
        'txtSenha
        '
        Me.txtSenha.BackColor = System.Drawing.Color.Transparent
        Me.txtSenha.BaseColor = System.Drawing.Color.White
        Me.txtSenha.BorderColor = System.Drawing.Color.Silver
        Me.txtSenha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSenha.FocusedBaseColor = System.Drawing.Color.White
        Me.txtSenha.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSenha.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSenha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSenha.Location = New System.Drawing.Point(29, 101)
        Me.txtSenha.MaxLength = 8
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Radius = 10
        Me.txtSenha.SelectedText = ""
        Me.txtSenha.Size = New System.Drawing.Size(296, 30)
        Me.txtSenha.TabIndex = 4
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(35, 83)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(39, 15)
        Me.GunaLabel2.TabIndex = 3
        Me.GunaLabel2.Text = "Senha"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.Transparent
        Me.txtEmail.BaseColor = System.Drawing.Color.White
        Me.txtEmail.BorderColor = System.Drawing.Color.Silver
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.FocusedBaseColor = System.Drawing.Color.White
        Me.txtEmail.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmail.Location = New System.Drawing.Point(29, 41)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmail.Radius = 10
        Me.txtEmail.SelectedText = ""
        Me.txtEmail.Size = New System.Drawing.Size(296, 30)
        Me.txtEmail.TabIndex = 2
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(35, 23)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(41, 15)
        Me.GunaLabel1.TabIndex = 1
        Me.GunaLabel1.Text = "E-mail"
        '
        'epValida
        '
        Me.epValida.ContainerControl = Me
        '
        'frmCadUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(354, 256)
        Me.ControlBox = False
        Me.Controls.Add(Me.GunaShadowPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCadUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCadUsuario"
        Me.GunaShadowPanel1.ResumeLayout(False)
        Me.GunaShadowPanel1.PerformLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaShadowPanel1 As Guna.UI.WinForms.GunaShadowPanel
    Friend WithEvents txtConfirmarSenha As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents txtSenha As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents txtEmail As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents btnCancelar As Guna.UI.WinForms.GunaButton
    Friend WithEvents btnCriar As Guna.UI.WinForms.GunaButton
    Friend WithEvents epValida As ErrorProvider
End Class
