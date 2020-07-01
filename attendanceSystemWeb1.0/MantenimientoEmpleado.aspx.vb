Imports capaNegocio
Public Class MantenimientoEmpleado
    Inherits System.Web.UI.Page
    Private employ As New capaDatos.employee
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("usuario") Is Nothing Then
                Response.Redirect("Login.aspx", False)
            Else
                ListAllEmployees(clsEmpleado.ListEmployee())
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

    Private Sub ListAllEmployees(list)
        Try
            DgvEmpl.DataSource = list
            DgvEmpl.DataBind()
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub
    Private Sub ClearControls()
        txtApellido.Text = ""
        txtCorreo.Text = ""
        txtDireccion.Text = ""
        txtDni.Text = ""
        txtNombre.Text = ""
        txtTelefono.Text = ""
        chkEstado.Checked = False
        CbxSex.ClearSelection()
    End Sub
    Public Sub SetDataForEditing(i As Int32)
        txtDni.Text = DgvEmpl.Rows(i).Cells(0).Text
        txtNombre.Text = DgvEmpl.Rows(i).Cells(1).Text
        txtApellido.Text = DgvEmpl.Rows(i).Cells(2).Text
        CbxSex.SelectedIndex = IIf(DgvEmpl.Rows(i).Cells(3).Text = "M", 2, 1)
        txtDireccion.Text = DgvEmpl.Rows(i).Cells(4).Text
        txtTelefono.Text = DgvEmpl.Rows(i).Cells(5).Text
        txtCorreo.Text = DgvEmpl.Rows(i).Cells(6).Text
        chkEstado.Checked = IIf(DgvEmpl.Rows(i).Cells(7).Text = "True", True, False)
        txtDni.Enabled = False
        BtnRegister.Text = "Modificar"
    End Sub
    Private Sub SetNewEmployeer(employee As capaDatos.employee)
        Try
            employee.dni = txtDni.Text
            employee.name = txtNombre.Text
            employee.lastname = txtApellido.Text
            employee.address = txtDireccion.Text
            employee.genre = CbxSex.SelectedValue
            employee.phone = txtTelefono.Text
            employee.email = txtCorreo.Text
            employee.state = chkEstado.Checked
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try

    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim dni = txtBuscar.Text
            ListAllEmployees(clsEmpleado.SearchEmployee(dni))
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        If CbxSex.SelectedValue IsNot "Seleccionar" Then
            Try
                If (BtnRegister.Text = "Registrar") Then
                    SetNewEmployeer(employ)
                    clsEmpleado.Register(employ)
                    ListAllEmployees(clsEmpleado.ListEmployee())
                    ClearControls()
                ElseIf (BtnRegister.Text = "Modificar") Then
                    Dim new_employ As New capaDatos.employee
                    SetNewEmployeer(new_employ)
                    clsEmpleado.ModifyEmployee(new_employ)
                    ListAllEmployees(clsEmpleado.ListEmployee())
                    ClearControls()
                    BtnRegister.Text = "Register"
                    txtDni.Enabled = True
                End If
            Catch ex As Exception
                Throw New Exception("Error" + ex.Message)
            End Try
        Else
            lblAviso.InnerText = "Seleccione un valor para el sexo"
        End If
    End Sub

    Protected Sub DgvEmpl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DgvEmpl.SelectedIndexChanged

    End Sub
    Protected Sub DgvEmpl_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DgvEmpl.RowCommand

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
                    Dim dni = DgvEmpl.Rows(i).Cells(0).Text
                    Dim em As Boolean = clsEmpleado.Validation(dni)
                    If (em = False) Then
                        clsEmpleado.DeleteEmployee(dni)
                        ListAllEmployees(clsEmpleado.ListEmployee())
                    Else
                        clsEmpleado.DownEmployee(dni)
                        ListAllEmployees(clsEmpleado.ListEmployee())
                    End If

                Catch ex As Exception
                    lblAviso.InnerText = ex.Message
                End Try
        End Select
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearControls()
        BtnRegister.Text = "Registrar"
    End Sub

End Class