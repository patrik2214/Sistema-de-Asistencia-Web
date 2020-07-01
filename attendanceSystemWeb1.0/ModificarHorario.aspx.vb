Imports capaNegocio
Imports capaDatos
Public Class ModificarHorario
    Inherits System.Web.UI.Page
    Dim ind As New List(Of Integer)
    Dim idh As Integer
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
    Protected Sub Redirect_ModHorario(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("ModificarHorario.aspx")
    End Sub
    Protected Sub Redirect_TipoLicencia(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("TipoLicencia.aspx")
    End Sub

    Public Sub ListScheduleDetails(d As List(Of scheduleDetail))
        Dim taskTable As New DataTable()

        ' Create the columns.

        taskTable.Columns.Add("Dia", GetType(Integer))
        taskTable.Columns.Add("Hora ingreso", GetType(Integer))
        taskTable.Columns.Add("Hora salida", GetType(Integer))

        'Add data to the new table.
        For Each det In d
            ind.Add(det.id)
            idh = det.scheduleId
            Dim tableRow = taskTable.NewRow()

            tableRow("Dia") = det.day
            tableRow("Hora ingreso") = det.inHour
            tableRow("Hora salida") = det.outHour
            taskTable.Rows.Add(tableRow)
        Next

        'Persist the table in the Session object.
        Session("Details") = taskTable
        Session("indices") = ind
        Session("idhorario") = idh
        'Bind data to the GridView control.
        BindData()
    End Sub
    Private Sub BindData()
        DgvScheduleDetails.DataSource = Session("Details")
        DgvScheduleDetails.DataBind()
    End Sub
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try
            If TxtDni.Text.Length = 8 Then
                Dim schedule_list = clsHorario.SearchScheduleForDNI(TxtDni.Text)
                Dim last_schedule = schedule_list.Last()
                ListScheduleDetails(clsDetalleHorario.SearchDetailForScheduleId(last_schedule.id))
            Else
                lblAviso.InnerText = "Este DNI no tiene horarios asociados"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub DgvScheduleDetails_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        DgvScheduleDetails.PageIndex = e.NewPageIndex
        'Bind data to the GridView control.
        BindData()
    End Sub

    Protected Sub DgvScheduleDetails_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        DgvScheduleDetails.EditIndex = e.NewEditIndex
        'Bind data to the GridView control.
        BindData()
    End Sub

    Protected Sub DgvScheduleDetails_RowCancelingEdit()
        'Reset the edit index.
        DgvScheduleDetails.EditIndex = -1
        'Bind data to the GridView control.
        BindData()
    End Sub

    Protected Sub DgvScheduleDetails_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim dt = CType(Session("Details"), DataTable)


        Dim row = DgvScheduleDetails.Rows(e.RowIndex)
        dt.Rows(row.DataItemIndex)("Dia") = (CType((row.Cells(1).Controls(0)), TextBox)).Text
        dt.Rows(row.DataItemIndex)("Hora ingreso") = (CType((row.Cells(2).Controls(0)), TextBox)).Text
        dt.Rows(row.DataItemIndex)("Hora salida") = (CType((row.Cells(3).Controls(0)), TextBox)).Text


        DgvScheduleDetails.EditIndex = -1


        BindData()
    End Sub
    Private Sub BtnUpdateSchedule_Click(sender As Object, e As EventArgs) Handles BtnUpdateSchedule.Click
        Try
            Dim cou = DgvScheduleDetails.Rows.Count
            For i = 0 To DgvScheduleDetails.Rows.Count - 1
                Dim detail As New capaDatos.scheduleDetail
                SetNewDetailForSchedule(detail, i)
                clsDetalleHorario.ModifyScheduleDetail(detail)
            Next
            ClearModifyControls()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub SetNewDetailForSchedule(sched As capaDatos.scheduleDetail, i As Integer)
        Dim indices = Session("indices")
        sched.id = Convert.ToInt32(indices(i))
        sched.scheduleId = Convert.ToInt32(Session("idhorario"))
        sched.day = Convert.ToInt32(DgvScheduleDetails.Rows(i).Cells(1).Text)
        sched.inHour = Convert.ToInt32(DgvScheduleDetails.Rows(i).Cells(2).Text)
        sched.outHour = Convert.ToInt32(DgvScheduleDetails.Rows(i).Cells(3).Text)
    End Sub
    Private Sub ClearModifyControls()
        TxtDni.Text = ""
        Session("Details") = Nothing
        BindData()
        Session("indices") = Nothing
        Session("idhorario") = Nothing
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearModifyControls()
    End Sub

End Class