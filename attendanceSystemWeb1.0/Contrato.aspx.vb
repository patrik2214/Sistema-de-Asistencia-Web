Imports capaNegocio
Public Class Contrato
    Inherits System.Web.UI.Page
    Private contract As capaDatos.contract
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Session("usuario") Is Nothing Then
                Response.Redirect("Login.aspx", False)
            Else
                ListAllContract(clsContrato.ListContrat())
            End If
        End If
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

    Private Sub SetNewContrat()
        contract = New capaDatos.contract
        contract.dni = txtDni.Text
        contract.mount = Decimal.Parse(txtSalario.Text)
        contract.startDate = calInicio.SelectedDate
        contract.finishDate = calFin.SelectedDate
        contract.extraHours = chkHorasExtra.Checked
        contract.state = chkEstado.Checked
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        If BtnRegister.Text = "Modificar" Then
            clsContrato.Update(HiddenId.Value, calInicio.SelectedDate, calFin.SelectedDate, Decimal.Parse(txtSalario.Text), chkHorasExtra.Checked, chkEstado.Checked)
            ClearControls()
            ListAllContract(clsContrato.ListContrat())
            BtnRegister.Text = "Guardar"

        ElseIf BtnRegister.Text = "Guardar" Then
            If (txtDni.Text.Length <> 8 Or txtSalario.Text.Length = 0) Then
                lblAviso.InnerText = "Hay datos mal Ingresados"
            Else
                If (txtDni.Text.Length = 8) Then
                    Try
                        Dim count As Integer
                        count = clsEmpleado.FindDni(txtDni.Text)
                        If count = 1 Then
                            SetNewContrat()
                            clsContrato.RegisterContrat(contract)
                            ClearControls()
                            ListAllContract(clsContrato.ListContrat())

                        Else
                            lblAviso.InnerText = "Hay datos mal Ingresados"
                        End If
                    Catch ex As Exception
                        Throw New Exception("Error" + ex.Message)
                    End Try
                Else
                    lblAviso.InnerText = "Hay datos mal Ingresados"
                End If
            End If
        End If

    End Sub

    Private Sub ListAllContract(list)
        Try
            DgvContract.DataSource = list
            DgvContract.DataBind()
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub

    Private Sub ClearControls()
        txtBuscar.Text = ""
        txtDni.Text = ""
        txtSalario.Text = ""
        chkHorasExtra.Checked = False
        chkEstado.Checked = False
        HiddenId.Value = ""
    End Sub


    Public Sub SetDataForEditing(i As Int32)
        HiddenId.Value = Integer.Parse(DgvContract.Rows(i).Cells(0).Text)
        txtDni.Text = DgvContract.Rows(i).Cells(1).Text
        calInicio.SelectedDate = Date.Parse(DgvContract.Rows(i).Cells(2).Text)
        calFin.SelectedDate = Date.Parse(DgvContract.Rows(i).Cells(3).Text)
        txtSalario.Text = DgvContract.Rows(i).Cells(4).Text
        chkHorasExtra.Checked = IIf(DgvContract.Rows(i).Cells(5).Text = "True", True, False)
        chkEstado.Checked = IIf(DgvContract.Rows(i).Cells(6).Text = "True", True, False)
        txtDni.Enabled = False
        BtnRegister.Text = "Modificar"
    End Sub


    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            Dim dni = txtBuscar.Text
            ListAllContract(clsContrato.FindContratByDni(dni))
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub

    Protected Sub DgvContract_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DgvContract.RowCommand
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
                    Dim id = DgvContract.Rows(i).Cells(0).Text
                    clsContrato.Down(id)
                    ListAllContract(clsContrato.ListContrat())
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