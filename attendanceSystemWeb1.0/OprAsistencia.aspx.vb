Imports capaNegocio
Public Class OprAsistencia
    Inherits System.Web.UI.Page
    Dim assistance As clsAsistencia
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

    Private Sub BtnAsis_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try

            Dim sh As Boolean = clsAsistencia.ValidationShedule(txtDni.Text)
            If sh Then
                Dim c = clsContrato.ExtraTime(txtDni.Text)

                If c Then
                    If clsAsistencia.CountInNull(txtDni.Text) = 1 Then
                        clsAsistencia.UpdateIn(txtDni.Text, DateTime.Now.TimeOfDay, DateTime.Now.Date)
                        lblAviso.InnerText = "Bienvenido"
                        Guardar.Text = "Salida"

                    ElseIf (clsAsistencia.CountOutNull(txtDni.Text) = 1) Then

                        clsAsistencia.UpdateOut(txtDni.Text, DateTime.Now.TimeOfDay, DateTime.Now.Date)
                        lblAviso.InnerText = "Hasta Luego"
                        Guardar.Text = "Entrada"
                        Dispose()

                    ElseIf (clsAsistencia.CountAsis(txtDni.Text) = 1) Then
                        lblAviso.InnerText = "Solo puede Guardar una entrada y una salida por dia"
                    Else
                        Dim new_asistance As New capaDatos.assistance()
                        new_asistance.dni = txtDni.Text
                        new_asistance.fecha = Today
                        new_asistance.inHour = DateTime.Now.TimeOfDay
                        new_asistance.outHour = Nothing
                        clsAsistencia.RegisterAssistance(new_asistance)
                        lblAviso.InnerText = "Bienvenido"
                    End If
                Else
                    Dim time As Integer = DateTime.Today.DayOfWeek()
                    Dim contador As Integer = clsHorario.ValidateDays(time)
                    If (contador = 1) Then
                        If (clsAsistencia.CountInNull(txtDni.Text) = 1) Then
                            clsAsistencia.UpdateIn(txtDni.Text, DateTime.Now.TimeOfDay, DateTime.Now.Date)
                            lblAviso.InnerText = "Bienvenido"
                            Guardar.Text = "Salida"

                        ElseIf (clsAsistencia.CountOutNull(txtDni.Text) = 1) Then
                            clsAsistencia.UpdateOut(txtDni.Text, DateTime.Now.TimeOfDay, DateTime.Now.Date)
                            lblAviso.InnerText = "Hasta Luego"
                            Guardar.Text = "Entrada"

                        ElseIf (clsAsistencia.CountAsis(txtDni.Text) = 1) Then
                            lblAviso.InnerText = "Solo puede Guardar una entrada y una salida por dia"
                        End If
                    Else
                        lblAviso.InnerText = "El día de hoy no tiene que asistir"
                    End If
                End If
            Else
                lblAviso.InnerText = "Usted no tiene horarios de trabajo vigentes, contrato o el dni ingresado es incorrecto"
            End If
        Catch ex As Exception
            lblAviso.InnerText = "Error al Guardar: " + ex.Message
        End Try


    End Sub


End Class