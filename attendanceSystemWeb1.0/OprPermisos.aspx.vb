Imports capaNegocio
Public Class OprPermisos
    Inherits System.Web.UI.Page
    Dim permission As capaDatos.permission

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("usuario") Is Nothing Then
                Response.Redirect("Login.aspx", False)
            Else
                ListAllPermission(clsPermiso.ListPermissions())
            End If
        End If
    End Sub
    Protected Sub Redirect_ModHorario(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("ModificarHorario.aspx")
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

    Private Sub setNewPermission()
        permission = New capaDatos.permission
        permission.PresentationDate = calPresentacion.SelectedDate
        permission.PermissionDate = calPermiso.SelectedDate
        permission.Reason = txtMotivo.Text
        permission.State = chkEstado.Checked
        permission.dni = txtDni.Text
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        If BtnRegister.Text = "Modificar" Then
            Try
                clsPermiso.Update(HiddenId.Value, calPresentacion.SelectedDate, calPermiso.SelectedDate, txtMotivo.Text, chkEstado.Checked, txtDni.Text)
                BtnRegister.Text = "Guardar"
                ClearControls()
                ListAllPermission(clsPermiso.ListPermissions())

            Catch ex As Exception
                lblAviso.InnerText = "Error: " + ex.Message
            End Try
        ElseIf BtnRegister.Text = "Guardar" Then
            Try
                Dim countE As Integer = clsEmpleado.FindDni(txtDni.Text)
                If (txtDni.Text.Length = 0) Then
                    lblAviso.InnerText = "Es necesario completar todos los campos"
                    ClearControls()
                ElseIf txtDni.Text.Length = 8 And countE = 1 Then
                    setNewPermission()
                    clsPermiso.Register(permission)
                    ClearControls()
                    ListAllPermission(clsPermiso.ListPermissions())
                Else
                    lblAviso.InnerText = "El DNI no ha sido ingresado correctamente"
                End If
            Catch ex As Exception
                lblAviso.InnerText = "Error: " + ex.Message()
            End Try
        End If
    End Sub

    Public Sub SetDataForEditing(i As Int32)
        HiddenId.Value = DgvPermission.Rows(i).Cells(0).Text
        calPresentacion.SelectedDate = Date.Parse(DgvPermission.Rows(i).Cells(1).Text)
        calPermiso.SelectedDate = Date.Parse(DgvPermission.Rows(i).Cells(2).Text)
        txtMotivo.Text = DgvPermission.Rows(i).Cells(3).Text
        txtDni.Text = DgvPermission.Rows(i).Cells(4).Text
        chkEstado.Checked = IIf(DgvPermission.Rows(i).Cells(5).Text = "True", True, False)
        txtDni.Enabled = False
        BtnRegister.Text = "Modificar"
    End Sub

    Private Sub ClearControls()
        txtDni.Text = ""
        txtMotivo.Text = ""
        txtBuscar.Text = ""
        chkEstado.Checked = False
        HiddenId.Value = ""
    End Sub

    Private Sub ListAllPermission(list)
        Try
            DgvPermission.DataSource = list
            DgvPermission.DataBind()
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim dni = txtBuscar.Text
            ListAllPermission(clsPermiso.FindByDNI(dni))
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub

    Protected Sub DgvPermission_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DgvPermission.RowCommand

        Select Case e.CommandName
            Case "Editar"
                Try
                    Dim i = Convert.ToInt32(e.CommandArgument)
                    SetDataForEditing(i)
                Catch ex As Exception
                    lblAviso.InnerText = ex.Message
                End Try
        End Select
        Select Case e.CommandName
            Case "Borrar"
                Try
                    Dim i = Convert.ToInt32(e.CommandArgument)
                    Dim id = DgvPermission.Rows(i).Cells(0).Text
                    clsUsuario.Delete(id)
                    ListAllPermission(clsPermiso.ListPermissions())
                Catch ex As Exception
                    lblAviso.InnerText = ex.Message
                End Try
        End Select
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearControls()
        BtnRegister.Text = "Guardar"
    End Sub

End Class