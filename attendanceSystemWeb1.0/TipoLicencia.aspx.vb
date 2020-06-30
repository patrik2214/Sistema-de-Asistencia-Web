Imports capaNegocio

Public Class TipoLicencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ListAllLicencesType(clsTipoLicencia.ListLicenseType())
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
    Private Sub ListAllLicencesType(list As List(Of capaDatos.licenseType))
        Try
            DgvTypeLicense.DataSource = list
            DgvTypeLicense.DataBind()
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub
    Private Sub SetNewLicenseType(l As capaDatos.licenseType)
        l.description = TxtDescription.Text
        l.maxDias = NudMaxDays.Text
    End Sub
    Private Sub ClearControls()
        TxtDescription.Text = ""
        NudMaxDays.Text = ""
        HiddenId.Value = ""
        BtnRegister.Text = "Registrar"
    End Sub
    Public Sub SetDataForEditing(i As Int32)
        HiddenId.Value = Convert.ToInt32(DgvTypeLicense.Rows(i).Cells(0).Text)
        TxtDescription.Text = DgvTypeLicense.Rows(i).Cells(1).Text
        NudMaxDays.Text = DgvTypeLicense.Rows(i).Cells(2).Text
        BtnRegister.Text = "Modificar"
    End Sub
    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        If BtnRegister.Text = "Registrar" Then
            Try
                Dim new_type As New capaDatos.licenseType
                SetNewLicenseType(new_type)
                clsTipoLicencia.Register(new_type)
                ListAllLicencesType(clsTipoLicencia.ListLicenseType)
                ClearControls()
            Catch ex As Exception
                Throw New Exception("Error" + ex.Message)
            End Try
        ElseIf BtnRegister.Text = "Modificar" Then
            Try
                Dim new_type As New capaDatos.licenseType
                SetDataForModify(new_type)
                clsTipoLicencia.ModifyLicenseType(new_type)
                ListAllLicencesType(clsTipoLicencia.ListLicenseType)
                ClearControls()
            Catch ex As Exception
                Throw New Exception("Error" + ex.Message)
            End Try
        End If
    End Sub
    Private Sub SetDataForModify(l As capaDatos.licenseType)
        l.description = TxtDescription.Text
        l.maxDias = Convert.ToInt32(NudMaxDays.Text)
        l.licenseTypeId = HiddenId.Value
    End Sub
    Protected Sub DgvTypeLicense_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DgvTypeLicense.RowCommand
        Select Case e.CommandName
            Case "Editar"
                Try
                    Dim i = Convert.ToInt32(e.CommandArgument)
                    SetDataForEditing(i)
                Catch ex As Exception
                    lblAviso.InnerText = ex.Message
                End Try
        End Select

    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearControls()
    End Sub
End Class