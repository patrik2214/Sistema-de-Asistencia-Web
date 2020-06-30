Imports System.Web.Services
Imports capaDatos
Imports capaNegocio
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.UI
Public Class Horario
    Inherits System.Web.UI.Page
    Dim day As IEnumerable(Of Object)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Redirect_Usuario(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("MantenimientoUsuario.aspx")
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
    Private Sub SetNewSchedule(schedu)
        schedu.Dni = TxtDni.Text
        schedu.FinishDate = Date.Parse(DtpEndDate.Text)
        schedu.StartDate = Date.Parse(DtpStartDate.Text)
        schedu.State = True
    End Sub
    Private Sub SetNewDetailSchedule(sche As capaDatos.scheduleDetail, de As Object, id As Integer)
        sche.day = de(0)
        sche.inHour = de(1)
        sche.outHour = de(2)
        sche.scheduleId = id
    End Sub
    Private Sub ClearControls()
        TxtDni.Text = ""
        DtpStartDate.Text = Date.Now()
        DtpEndDate.Text = Date.Now()
    End Sub
    Private Sub RegisterAsistances(DB As BDAsistenciaEntities)
        Dim cantidad_dias_totales = Date.Parse(DtpEndDate.Text) - Date.Parse(DtpStartDate.Text)
        Dim i As Integer
        Dim dia_control = Date.Parse(DtpStartDate.Text)
        Dim dia_entero As Integer = Integer.Parse(Date.Parse(DtpStartDate.Text).DayOfWeek())
        For i = 0 To cantidad_dias_totales.Days
            For Each s In day

                If dia_entero = s(0) Then
                    Dim assis As New capaDatos.assistance
                    assis.dni = Convert.ToString(TxtDni.Text)
                    assis.fecha = dia_control
                    clsAsistencia.RegisterAssistanceNulls(assis, DB)
                End If
            Next
            dia_control = dia_control.AddDays(1)
            dia_entero += 1
            If dia_entero = 8 Then
                dia_entero = 1
            End If
        Next
    End Sub
    Private Sub BtnRegisterSchedule_Click(sender As Object, e As EventArgs) Handles BtnRegisterSchedule.Click
        Dim funcion = "setDias();"
        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "setea", funcion, True)
        Try
            Dim span As TimeSpan = TimeSpan.FromDays(1)
            If Date.Parse(DtpEndDate.Text) - Date.Parse(DtpStartDate.Text) < span Then
                Console.Write("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH me quiero morirrrrrrrrrrrrrrrrrr")
            Else

                Using DB = New BDAsistenciaEntities()
                    Using dbContextTransaction = DB.Database.BeginTransaction()
                        Try
                            Dim schedu As New capaDatos.schedule
                            SetNewSchedule(schedu)
                            Dim id_hor = clsHorario.Register(schedu, DB)
                            Dim sche_details As New capaDatos.scheduleDetail

                            Dim aver = HiddenDias.Value
                            day = JsonConvert.DeserializeObject(Of IEnumerable(Of Object))(HiddenDias.Value)
                            For i = 0 To day.Count - 1
                                SetNewDetailSchedule(sche_details, day(i), id_hor)
                                clsDetalleHorario.Register(sche_details, DB)
                            Next
                            RegisterAsistances(DB)
                            dbContextTransaction.Commit()
                            ClearControls()
                        Catch ex As Exception
                            dbContextTransaction.Rollback()
                            Throw ex
                        End Try

                    End Using

                End Using

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    <WebMethod>
    Public Sub registrarHorario(ddias As JObject)

    End Sub
End Class