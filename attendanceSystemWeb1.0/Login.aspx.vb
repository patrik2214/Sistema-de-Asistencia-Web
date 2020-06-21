Imports capaNegocio
Imports capaDatos


Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim usuario As New clsUsuario
    Private users As capaDatos.Users
    Protected Sub Btn_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            User = New clsUsuario().Login(txtNombreUsuario.Text, txtContraseña.Text)
            Dim username = User.Employee.Name + " " + User.Employee.Lastname
            Response.Redirect("Index.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Public Property User() As capaDatos.Users
        Get
            Return users
        End Get
        Set(value As capaDatos.Users)
            users = value
        End Set
    End Property

End Class