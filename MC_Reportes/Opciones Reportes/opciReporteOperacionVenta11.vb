Imports DevExpress.XtraEditors
Imports MC_Data
Imports MC_Framework
Public Class opciReporteOperacionVenta11
    Dim bsclientes As New BindingSource
    Dim bsdocumentos As New BindingSource
    Dim bsestadodocumentos As New BindingSource
    Dim bstipopago As New BindingSource
    Dim bscaja As New BindingSource

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "REGISTRO DE VENTAS - " '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False
        ControlesDevExpress.InitGridLookUpEditSearch(cbolocal, LocalDAO.GetByAllLocalXMLGrid(UsuarioBE.IDUsuario), "IdLocal", "RazonComercial", 700)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "RAZON COMERCIAL", "RazonComercial", 80, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "ID LOCAL", "IdLocal", 80, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "IPSERVER", "IpServer", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDINFOREST", "BDInforest", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDALMACEN", "BDAlmacen", 50, False)
        DateIni.DateTime = DateTime.Today.AddDays(-7)
        DateFin.DateTime = DateTime.Today
    End Sub
    Private Sub CorrelativoDocumentoSunat()
        Dim RPT As New rptReporteOperacionVenta11
        'Controla los datos ingresados
        If Not Tools.CampoObligatorio(cbolocal, Tools.eValidaControl.SearchLookUpEdit) Then
            Return
        End If

        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        SplashScreenManager.ShowForm(GetType(WaitForm))
        RPT.DataSource = ReportesDao.ReporteOperacionVenta11(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"), (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), chkopcioncliente.EditValue, chkopciondocumentos.EditValue,
                                                             chkopcionestado.EditValue, chkopcionpago.EditValue, chkopcioncaja.EditValue, If(cbocliente.EditValue = "", "", cbocliente.EditValue), If(cbodocumentos.EditValue = "", "", cbodocumentos.EditValue),
                                                             If(cboestados.EditValue = "", "", cboestados.EditValue), If(cbopagos.EditValue = "", "", cbopagos.EditValue), If(cbocajas.EditValue = "", "", cbocajas.EditValue), cbotiporeporte.EditValue)
        RPT.DataMember = "Reporte"
        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel2.Text = cbolocal.Properties.View.FocusedValue
        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        SplashScreenManager.CloseForm()
        ReporteView.Show()
    End Sub
    Private Sub CorrelativoDocumento()
        Dim RPT As New rptReporteOperacionVenta11_Opc1
        'Controla los datos ingresados
        If Not Tools.CampoObligatorio(cbolocal, Tools.eValidaControl.SearchLookUpEdit) Then
            Return
        End If

        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        SplashScreenManager.ShowForm(GetType(WaitForm))
        RPT.DataSource = ReportesDAO.ReporteOperacionVenta11_Opc1(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"), (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), chkopcioncliente.EditValue, chkopciondocumentos.EditValue,
                                                             chkopcionestado.EditValue, chkopcionpago.EditValue, chkopcioncaja.EditValue, If(cbocliente.EditValue = "", "", cbocliente.EditValue), If(cbodocumentos.EditValue = "", "", cbodocumentos.EditValue),
                                                             If(cboestados.EditValue = "", "", cboestados.EditValue), If(cbopagos.EditValue = "", "", cbopagos.EditValue), If(cbocajas.EditValue = "", "", cbocajas.EditValue), cbotiporeporte.EditValue, If(chkopcionpago.Checked = True, False, True))
        RPT.DataMember = "Reporte"
        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel2.Text = cbolocal.Properties.View.FocusedValue
        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        SplashScreenManager.CloseForm()
        ReporteView.Show()
    End Sub
    Private Sub EstadoDocumentos()
        Dim RPT As New rptReporteOperacionVenta11_Opc2
        'Controla los datos ingresados
        If Not Tools.CampoObligatorio(cbolocal, Tools.eValidaControl.SearchLookUpEdit) Then
            Return
        End If

        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        SplashScreenManager.ShowForm(GetType(WaitForm))
        RPT.DataSource = ReportesDAO.ReporteOperacionVenta11_Opc2(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"), (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), chkopcioncliente.EditValue, chkopciondocumentos.EditValue,
                                                             chkopcionestado.EditValue, chkopcionpago.EditValue, chkopcioncaja.EditValue, If(cbocliente.EditValue = "", "", cbocliente.EditValue), If(cbodocumentos.EditValue = "", "", cbodocumentos.EditValue),
                                                             If(cboestados.EditValue = "", "", cboestados.EditValue), If(cbopagos.EditValue = "", "", cbopagos.EditValue), If(cbocajas.EditValue = "", "", cbocajas.EditValue), cbotiporeporte.EditValue)
        RPT.DataMember = "Reporte"
        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel2.Text = cbolocal.Properties.View.FocusedValue
        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        SplashScreenManager.CloseForm()
        ReporteView.Show()
    End Sub
    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnemitir.Click
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If cbotiporeporte.EditValue = 0 Then
            CorrelativoDocumentoSunat()
        End If
        If cbotiporeporte.EditValue = 1 Then
            CorrelativoDocumento()
        End If
        If cbotiporeporte.EditValue = 2 Then
            EstadoDocumentos()
        End If
    End Sub
    Private Sub cbolocal_EditValueChanged(sender As Object, e As EventArgs) Handles cbolocal.EditValueChanged
        SplashScreenManager.ShowForm(GetType(WaitForm))
        SplashScreenManager.Default.SetWaitFormCaption("Cargando Datos ...")
        SplashScreenManager.Default.SetWaitFormDescription(cbolocal.GetSelectedDataRow("RazonComercial"))
        bsclientes.DataSource = LocalDAO.GetClientes(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"))
        bsdocumentos.DataSource = LocalDAO.GetTipoDocumento(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"))
        bsestadodocumentos.DataSource = LocalDAO.GetEstadoDocumento(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"))
        bstipopago.DataSource = LocalDAO.GetTipoPago(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"))
        bscaja.DataSource = LocalDAO.GetCaja(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"))
        SplashScreenManager.CloseForm()
    End Sub
    Private Sub chkopcioncliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkopcioncliente.CheckedChanged
        If chkopcioncliente.Checked = True Then
            cbocliente.Enabled = False
        Else
            cbocliente.Enabled = True
            cbocliente.Properties.DataSource = bsclientes
        End If
    End Sub
    Private Sub chkopciondocumentos_CheckedChanged(sender As Object, e As EventArgs) Handles chkopciondocumentos.CheckedChanged
        If chkopciondocumentos.Checked = True Then
            cbodocumentos.Enabled = False
        Else
            cbodocumentos.Enabled = True
            cbodocumentos.Properties.DataSource = bsdocumentos
        End If
    End Sub
    Private Sub chkopcionestado_CheckedChanged(sender As Object, e As EventArgs) Handles chkopcionestado.CheckedChanged
        If chkopcionestado.Checked = True Then
            cboestados.Enabled = False
        Else
            cboestados.Enabled = True
            cboestados.Properties.DataSource = bsestadodocumentos
        End If
    End Sub
    Private Sub chkopcionpago_CheckedChanged(sender As Object, e As EventArgs) Handles chkopcionpago.CheckedChanged
        If chkopcionpago.Checked = True Then
            cbopagos.Enabled = False
        Else
            cbopagos.Enabled = True
            cbopagos.Properties.DataSource = bstipopago
        End If
    End Sub

    Private Sub chkopcioncaja_CheckedChanged(sender As Object, e As EventArgs) Handles chkopcioncaja.CheckedChanged
        If chkopcioncaja.Checked = True Then
            cbocajas.Enabled = False
        Else
            cbocajas.Enabled = True
            cbocajas.Properties.DataSource = bscaja
        End If
    End Sub

    Private Sub cbotiporeporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotiporeporte.SelectedIndexChanged
        If cbotiporeporte.EditValue = 0 Or cbotiporeporte.EditValue = 4 Then
            cbopagos.Enabled = False
            chkopcionpago.Enabled = False
        Else
            'cbopagos.Enabled = True
            chkopcionpago.Enabled = True
        End If
    End Sub
End Class