Imports capaNegocio
Public Class MantenimientoUsuario
    Inherits System.Web.UI.Page
    Private user As capaDatos.users
    Dim table As New DataTable
    Dim countE As Integer
    Dim Id_Usuario As Integer
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




    Private Sub SetNewUsers()
        user = New capaDatos.users
        user.uSerName = txtNombre.Text
        user.userPassword = txtContraseña.Text
        user.userState = chkEstado.Checked
        user.dni = txtDni.Text
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        If Guardar.Text = "Modificar" Then
            Try
                clsUsuario.Update(Id_Usuario, txtNombre.Text, txtContraseña.Text, txtDni.Text, chkEstado.Checked)
                Guardar.Text = "Registrar"
                ClearControls()
                ListTable()

            Catch ex As Exception

            End Try
        Else
            Try
                countE = clsEmpleado.FindDni(txtDni.Text)
                If txtNombre.Equals("") Or txtContraseña.Equals("") Or txtDni.Equals("") Then

                    ClearControls()
                ElseIf txtDni.MaxLength = 8 And countE = 1 Then
                    SetNewUsers()
                    clsUsuario.RegisterUser(user)
                    ClearControls()
                    ListTable()

                Else

                End If
            Catch ex As Exception

            End Try
        End If

    End Sub


    Private Sub ClearControls()

    End Sub


    Private Sub ListTable()
        Try
            tblUsuario.Columns.Clear()
            tblUsuario.DataSource = clsUsuario.ListUser()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ListUserByDNI()
        Try
            tblUsuario.Columns.Clear()
            tblUsuario.DataSource = clsUsuario.ListUserByDni(Id_Usuario)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
            If (Id_Usuario > 0) Then

                ListUserByDNI()

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub UpdateUser()
        Try
            If Id_Usuario > 0 Then

                Dim c = clsUsuario.FindUser(Id_Usuario)
                txtNombre.Text = c.uSerName
                txtDni.Text = c.dni
                txtContraseña.Text = c.userPassword
                chkEstado.Checked = c.userState
                Guardar.Text = "Modificar"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Delete()
        Try
            If (Id_Usuario > 0) Then
                clsUsuario.Delete(Id_Usuario)
                ClearControls()
                ListTable()

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Down()
        Try
            If (Id > 0) Then
                clsUsuario.Down(Id)
                ClearControls()
                ListTable()

            End If
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub table_CellClick(sender As Object, e As DataGrid) Handles tblUsuario.
    '      Integer.parse(table.CurrentRow.Cells(0).Value)
    '    Dim senderGrid = DirectCast(sender, DataGrid)

    'End Sub


End Class