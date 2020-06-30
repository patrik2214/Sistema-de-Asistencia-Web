Imports capaNegocio
Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim objUsuario As New clsUsuario
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim user = objUsuario.Login(txtNombreUsuario.Text, txtContraseña.Text)
            Dim nombre = user.employee.name + " " + user.employee.lastname
            Session("usuario") = nombre
            If user IsNot Nothing Then
                lblMensaje.Text = "Bienvenido al Sistema " & nombre
                Response.Redirect("Index.aspx", False)
            Else
                lblMensaje.Text = "Error de acceso!!"
            End If
        Catch ex As Exception
            Throw New Exception("Error al ingresar: " + ex.Message)
        End Try
    End Sub
End Class