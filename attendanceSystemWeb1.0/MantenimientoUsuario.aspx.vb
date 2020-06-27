Imports capaNegocio
Public Class MantenimientoUsuario
    Inherits System.Web.UI.Page
    Private user As capaDatos.users
    Dim countE As Integer
    Dim Id_Usuario As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ListAllUser(clsUsuario.ListUser())
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


    Private Sub SetNewUsers()
        user = New capaDatos.users
        user.uSerName = txtNombre.Text
        user.userPassword = txtContraseña.Text
        user.userState = chkEstado.Checked
        user.dni = txtDni.Text
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        If BtnRegister.Text = "Modificar" Then
            Try
                clsUsuario.Update(Id_Usuario, txtNombre.Text, txtContraseña.Text, txtDni.Text, chkEstado.Checked)
                BtnRegister.Text = "Registrar"
                ClearControls()
                ListAllUser(clsUsuario.ListUser())

            Catch ex As Exception
                Throw New Exception("Error" + ex.Message)
            End Try
        ElseIf BtnRegister.Text = "Registrar" Then
            Try
                countE = clsEmpleado.FindDni(txtDni.Text)
                If txtNombre.Text.Length = 0 Or txtContraseña.Text.Length = 0 Or txtDni.Text.Length = 0 Then
                    lblAviso.InnerText = "Es necesario completar todos los campos para registrar"
                    ClearControls()
                ElseIf txtDni.Text.Length = 8 And countE = 1 Then
                    SetNewUsers()
                    clsUsuario.RegisterUser(user)
                    ClearControls()
                    ListAllUser(clsUsuario.ListUser())
                Else
                    lblAviso.InnerText = "Es necesario completar todos los campos"
                End If
            Catch ex As Exception
                Throw New Exception("Error" + ex.Message)
            End Try
        End If

    End Sub

    Private Sub ListAllUser(list)
        Try
            DgvUser.DataSource = list
            DgvUser.DataBind()
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub
    Private Sub ClearControls()
        txtBuscar.Text = ""
        txtContraseña.Text = ""
        txtDni.Text = ""
        txtNombre.Text = ""
        chkEstado.Checked = False
    End Sub
    Public Sub SetDataForEditing(i As Int32)
        Id_Usuario = Integer.Parse(DgvUser.Rows(i).Cells(0).Text)
        txtNombre.Text = DgvUser.Rows(i).Cells(1).Text
        txtDni.Text = DgvUser.Rows(i).Cells(2).Text
        txtContraseña.Text = DgvUser.Rows(i).Cells(3).Text
        chkEstado.Checked = IIf(DgvUser.Rows(i).Cells(4).Text = "True", True, False)
        txtDni.Enabled = False
        BtnRegister.Text = "Modificar"
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim dni = txtBuscar.Text
            ListAllUser(clsUsuario.ListUserByDni(dni))
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub

    Protected Sub DgvUser_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DgvUser.RowCommand

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
            Case "Desactivar"
                Try
                    Dim i = Convert.ToInt32(e.CommandArgument)
                    Dim id = DgvUser.Rows(i).Cells(0).Text
                    clsUsuario.Down(id)
                    ListAllUser(clsUsuario.ListUser())
                Catch ex As Exception
                    lblAviso.InnerText = ex.Message
                End Try
        End Select
        Select Case e.CommandName
            Case "Borrar"
                Try
                    Dim i = Convert.ToInt32(e.CommandArgument)
                    Dim id = DgvUser.Rows(i).Cells(0).Text
                    clsUsuario.Delete(id)
                    ListAllUser(clsUsuario.ListUser())
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