Imports capaNegocio
Public Class OprLicencias
    Inherits System.Web.UI.Page
    Dim span As New TimeSpan
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Session("usuario") Is Nothing Then
                Response.Redirect("Login.aspx", False)
            Else
                SetLicensesTypeCombo()
                ListAllLicencesType(clsLicencia.ListLicenses())
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
    Private Sub SetLicensesTypeCombo()
        Try
            CbxTypeLicense.DataSource = clsTipoLicencia.ListLicenseType()
            CbxTypeLicense.DataTextField = "Description"
            CbxTypeLicense.DataValueField = "LicenseTypeId"
            CbxTypeLicense.DataBind()
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub
    Private Sub SetNewLicense(l As capaDatos.license)
        l.dni = TxtDni.Text
        l.document = TxtDocument.Text
        l.endDate = Date.Parse(DtpEndDate.Text)
        l.startDate = Date.Parse(DtpStartDate.Text)
        l.state = IIf(DateTime.Now > Date.Parse(DtpStartDate.Text) And DateTime.Now < Date.Parse(DtpEndDate.Text), True, False)
        l.typeId = Convert.ToInt32(CbxTypeLicense.SelectedValue.ToString())
        l.PresentationDate = Date.Parse(DtpPresentation.Text)
    End Sub
    Private Sub CbxTypeLicense_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTypeLicense.SelectedIndexChanged
        Try
            'Dim type = CbxTypeLicense.SelectedItem.ToString()
            Dim value = Convert.ToInt32(CbxTypeLicense.SelectedValue.ToString())
            span = clsTipoLicencia.GetMaxTimeSpan(value)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetControls()
        DtpEndDate.Text = DateTime.Now
        DtpStartDate.Text = DateTime.Now
        DtpPresentation.Text = DateTime.Now
        TxtDocument.Text = ""
        TxtDni.Text = ""
    End Sub
    Private Sub BtnRegisterLicense_Click(sender As Object, e As EventArgs) Handles BtnRegisterLicense.Click
        If clsEmpleado.FindDni(TxtDni.Text) = 1 Then
            If Date.Parse(DtpEndDate.Text) - Date.Parse(DtpStartDate.Text) > span Then
                lblAviso.InnerText = "El rango de la licencia excede a los dias permitidos, asegúrese de haber elegido un tipo correcto"
            ElseIf (Date.Parse(DtpEndDate.Text) - Date.Parse(DtpStartDate.Text)) < TimeSpan.FromDays(2) Then
                lblAviso.InnerText = "El rango de fechas ingresado no debe ser menor a 2 dias"
            Else
                Dim new_license As New capaDatos.license
                SetNewLicense(new_license)
                clsLicencia.Register(new_license)
                ListAllLicencesType(clsLicencia.ListLicenses())
                SetControls()
            End If
        Else
            lblAviso.InnerText = "El dni no coincide con ningun empleado"
        End If

    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        SetControls()
    End Sub
    Private Sub ListAllLicencesType(list As List(Of capaDatos.license))
        Try
            DgvLicense.DataSource = list
            DgvLicense.DataBind()
        Catch ex As Exception
            Throw New Exception("Error" + ex.Message)
        End Try
    End Sub
End Class