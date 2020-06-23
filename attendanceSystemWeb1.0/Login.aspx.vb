Imports capaNegocio
Imports capaDatos

Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim usuario As New clsUsuario
    Private users As capaDatos.users
    Protected Sub Btn_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            User = New clsUsuario().Login(txtNombreUsuario.Text, txtContraseña.Text)
            Response.Redirect("Index.aspx")
        Catch ex As Exception



        End Try
    End Sub

    Public Property User() As capaDatos.users
        Get
            Return users
        End Get
        Set(value As capaDatos.users)
            users = value
        End Set
    End Property

End Class