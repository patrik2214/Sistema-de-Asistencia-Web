Imports capaNegocio
Public Class OprJustificacion
    Inherits System.Web.UI.Page
    Dim jus As New capaDatos.justification

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("usuario") Is Nothing Then
                Response.Redirect("Login.aspx", False)
            End If
        End If
    End Sub

    Protected Sub Redirect_Usuario(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("MantenimientoUsuario.aspx")
    End Sub
    Protected Sub Redirect_ModHorario(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("ModificarHorario.aspx")
    End Sub
    Protected Sub Redirect_Empleado(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("MantenimientoEmpleado.aspx")
    End Sub
    Protected Sub Redirect_Login(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("usuario") = Nothing
            Response.Redirect("Login.aspx", False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub Redirect_Horario(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("Horario.aspx")
    End Sub

    Protected Sub Redirect_OprAsistencia(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("OprAsistencia.aspx")
    End Sub

    Protected Sub Redirect_OprJustificacion(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("OprJustificacion.aspx")
    End Sub

    Protected Sub Redirect_OprPermisos(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("OprPermisos.aspx")
    End Sub

    Protected Sub Redirect_OprLicencias(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("OprLicencias.aspx")
    End Sub

    Protected Sub Redirect_ConAsistencia(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("ConAsistencia.aspx")
    End Sub

    Protected Sub Redirect_Asistencia(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("RepAsistencia.aspx")
    End Sub

    Protected Sub Redirect_Faltas(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("RepFaltas.aspx")
    End Sub

    Protected Sub Redirect_Licencias(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("RepLicencia.aspx")
    End Sub

    Protected Sub Redirect_Tardanzas(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("RepTardanzas.aspx")
    End Sub

    Protected Sub Redirect_Contrato(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("Contrato.aspx")
    End Sub

    Protected Sub Redirect_TipoLicencia(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("TipoLicencia.aspx")
    End Sub

    Private Sub BuscarDni(sender As Object, e As EventArgs) Handles BuscarDni.Click
        Try
            If TxtDniForSearch.Text.Length = 8 Then
                DgvJustify.DataSource = clsAsistencia.List(TxtDni.Text)
                DgvJustify.DataBind()
            Else
                lblAviso.InnerText = "Ingrese un DNI de 8 digitos"
            End If
        Catch ex As Exception
           Throw New Exception("Error" + ex.Message)
        End Try

    End Sub

    Private Sub Guardar(sender As Object, e As EventArgs) Handles Guardar.Click
        Try
            SetNewJustification(jus)
            clsJustificacion.Register(jus)
            lblAviso.InnerText = "Justificación registrada correctamente"
        Catch ex As Exception
           Throw New Exception("Error" + ex.Message)
        End Try

    End Sub

    Private Sub SetNewJustification(j As capaDatos.justification)
        j.fecha = DateTime.Now()
        j.reason = txtMotivo.Text
        j.state = True
        j.AssistanceId = HiddenId.Value
    End Sub

    Protected Sub DgvJustify_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DgvJustify.RowCommand
        Try
            Dim i = Convert.ToInt32(e.CommandArgument)
            HiddenId.Value = Integer.Parse(DgvJustify.Rows(i).Cells(0).Text)
        Catch ex As Exception
            lblAviso.InnerText = ex.Message
        End Try
    End Sub
End Class