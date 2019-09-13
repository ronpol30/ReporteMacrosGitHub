Imports System.Xml
Imports System.Configuration
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
'Imports Microsoft.Office.Interop.Excel
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class Tools
    Public Enum eValidaControl
        TextEdit = 1
        SpinEdit = 2
        GridLoopUpEdit = 3
        SearchLookUpEdit = 4
        DateEdit = 5
        ComboBoxEdit = 6
    End Enum
    Shared Function ValidaVersion(IdPrograma As Int32) As Boolean
        Dim query As String = "SELECT VERSION FROM MC_SISTEMA WHERE IDSISTEMA=" & IdPrograma
        Using cnx As New SqlConnection(ConfigurationManager.ConnectionStrings("MC_CENTRAL_ConnectionString").ConnectionString)
            Dim cmd As New SqlCommand(query, cnx)
            cnx.Open()
            Try
                If My.Application.Info.Version.ToString = cmd.ExecuteScalar() Then
                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
            cnx.Close()
        End Using
        Return False
    End Function
    Shared Function ReadAppSettings(Key As String) As String
        Dim Value As String = String.Empty
        Try
            Value = ConfigurationManager.AppSettings(Key)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Value
    End Function

    Shared Function SaveAppSettings(Key As String, Value As String) As Boolean
        Dim Result As Boolean = False

        Try
            Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim settings = configFile.AppSettings.Settings

            If IsNothing(settings(Key)) Then
                settings.Add(Key, Value)
            Else
                settings(Key).Value = Value
            End If
            configFile.Save(ConfigurationSaveMode.Modified)

            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
        Catch ex As ConfigurationErrorsException
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Result
    End Function

    Shared Function ReadNullAsEmptyString(ByVal reader As IDataReader, ByVal fieldName As String) As String
        If IsDBNull(reader(fieldName)) Then
            Return String.Empty
        Else
            Return reader(fieldName).ToString.Trim
        End If
        'Return False
    End Function

    Public Function ReadNullAsEmptyDate(ByVal reader As IDataReader, ByVal fieldName As String) As Nullable(Of Date)
        If IsDBNull(reader(fieldName)) Then
            Return Nothing
        Else
            Return reader(fieldName).ToString.Trim
        End If
        'Return False
    End Function

    Shared Function Teclado(Optional sender As Object = Nothing, Optional e As KeyEventArgs = Nothing) As KeyEventArgs
        Select Case e.KeyCode
            Case Keys.Escape
                sender.Close()
            Case Keys.F1
                MessageBox.Show("Ayuda no esta disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case Keys.F2
                sender.btnNuevo.PerformClick()
            Case Keys.Enter
                sender.btnEditar.PerformClick()
        End Select
        Return e
    End Function

    Shared Function CampoObligatorio(objControl As Object, Optional ByVal Tipo As eValidaControl = eValidaControl.TextEdit) As Boolean
        Dim Result As Boolean = True

        'Se valida que la propiedad Text no este vacia
        If Tipo = eValidaControl.TextEdit Then
            If objControl.Text = "" Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If
            If objControl.Text = "0.00" Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If
            If objControl.Text = "0" Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If
        End If

        If Tipo = eValidaControl.SpinEdit Then
            Dim Control As New SpinEdit

            Control = CType(objControl, SpinEdit)

            If Control.EditValue = 0 Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If
        End If

        If Tipo = eValidaControl.GridLoopUpEdit Then
            Dim Control As New GridLookUpEdit

            Control = CType(objControl, GridLookUpEdit)

            If Control.EditValue = 0 Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If
        End If

        If Tipo = eValidaControl.SearchLookUpEdit Then
            Dim Control As New SearchLookUpEdit

            Control = CType(objControl, SearchLookUpEdit)

            If Control.EditValue = 0 Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If
        End If

        If Tipo = eValidaControl.DateEdit Then
            Dim Control As New DateEdit
            Control = CType(objControl, DateEdit)

            If Control.EditValue Is Nothing Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If

        End If

        If Tipo = eValidaControl.ComboBoxEdit Then
            Dim Control As New ComboBoxEdit
            Control = CType(objControl, ComboBoxEdit)

            If Control.EditValue Is Nothing Then
                objControl.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                objControl.ErrorText = "El campo es obligatorio"
                Result = False
            End If

        End If

        Return Result
    End Function
    Shared Sub CargarControl(ByVal usrCtrl As Control, panel As DevExpress.XtraEditors.PanelControl)
        Dim con As Control
        For controlIndex As Integer = panel.Controls.Count - 1 To 0 Step -1
            con = panel.Controls(controlIndex)
            panel.Controls.Remove(con)
        Next
        panel.Controls.Add(usrCtrl)
        usrCtrl.Dock = DockStyle.Fill
    End Sub

    Shared Sub MarcaGrilla(ByVal Grilla As DevExpress.XtraGrid.Views.Grid.GridView, ByVal NombreCampoCheck As String, ByVal Estado As Boolean)
        Try
            Dim i As Integer
            For i = 0 To Grilla.RowCount - 1
                Grilla.SetRowCellValue(i, NombreCampoCheck, Estado)
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Shared Function ConvertXMLLocalesBaseDatos(dt As DataTable) As String
        Dim ds As New DataSet
        Dim dtcopy As New DataTable
        dtcopy = dt.Copy()
        ds.Tables.Add(dtcopy)
        Dim simpleresult As String = ds.GetXml
        ''Se declara la variable Result como Object, si es cadena no muestra el XML
        'Dim Result = New XElement("ITEMS",
        '           From item In Lista
        '           Select New XElement("ITEM", New XAttribute("IDUsuario", item.IDUsuario))) ', New XAttribute("IDBaseDatos", item.IDBasedatos)))

        Return simpleresult
    End Function
    Shared Sub createNodeLocal(ByVal idlocal As String, ByVal idtributario As String, ByVal razonsocial As String, ByVal razoncomercial As String, ByVal ipserver As String, ByVal bdinforest As String, ByVal bdalmacen As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("Local")
        writer.WriteStartElement("IdLocal")
        writer.WriteString(idlocal)
        writer.WriteEndElement()
        writer.WriteStartElement("IDTributario")
        writer.WriteString(idtributario)
        writer.WriteEndElement()
        writer.WriteStartElement("RazonSocial")
        writer.WriteString(razonsocial)
        writer.WriteEndElement()
        writer.WriteStartElement("RazonComercial")
        writer.WriteString(razoncomercial)
        writer.WriteEndElement()
        writer.WriteStartElement("IpServer")
        writer.WriteString(ipserver)
        writer.WriteEndElement()
        writer.WriteStartElement("BDINFOREST")
        writer.WriteString(bdinforest)
        writer.WriteEndElement()
        writer.WriteStartElement("bdalmacen")
        writer.WriteString(bdalmacen)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub
    Shared Sub createNodeUsuario(ByVal idusuario As String, ByVal nombres As String, ByVal apellidopaterno As String, ByVal apellidomaterno As String, ByVal nombreusuario As String, ByVal contrasena As String, ByVal idrol As String, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("Usuarios")
#Region "DatosXML"
            .WriteStartElement("idusuario")
            .WriteString(idusuario)
            .WriteEndElement()
            .WriteStartElement("nombres")
            .WriteString(nombres)
            .WriteEndElement()
            .WriteStartElement("apellidopaterno")
            .WriteString(apellidopaterno)
            .WriteEndElement()
            .WriteStartElement("apellidomaterno")
            .WriteString(apellidomaterno)
            .WriteEndElement()
            .WriteStartElement("nombreusuario")
            .WriteString(nombreusuario)
            .WriteEndElement()
            .WriteStartElement("contrasena")
            .WriteString(contrasena)
            .WriteEndElement()
            .WriteStartElement("idrol")
            .WriteString(idrol)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub createNodeUsuariolocal(ByVal idusuario As String, ByVal idlocal As String, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("UsuarioLocal")
#Region "DatosXML"
            .WriteStartElement("idusuario")
            .WriteString(idusuario)
            .WriteEndElement()
            .WriteStartElement("idlocal")
            .WriteString(idlocal)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub createNodeRol(ByVal idrol As Integer, ByVal Descripcion As String, ByVal estado As Integer, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("Rol")
#Region "DatosXML"
            .WriteStartElement("idrol")
            .WriteString(idrol)
            .WriteEndElement()
            .WriteStartElement("Descripcion")
            .WriteString(Descripcion)
            .WriteEndElement()
            .WriteStartElement("estado")
            .WriteString(estado)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub createNodeModulo(ByVal idmodulo As Integer, ByVal Descripcion As String, ByVal estado As Integer, ByVal idsistema As Integer, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("Modulo")
#Region "DatosXML"
            .WriteStartElement("idmodulo")
            .WriteString(idmodulo)
            .WriteEndElement()
            .WriteStartElement("Descripcion")
            .WriteString(Descripcion)
            .WriteEndElement()
            .WriteStartElement("estado")
            .WriteString(estado)
            .WriteEndElement()
            .WriteStartElement("idsistema")
            .WriteString(idsistema)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub createNodeSistema(ByVal idmodulo As Integer, ByVal CodSistema As String, ByVal Descripcion As String, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("Modulo")
#Region "DatosXML"
            .WriteStartElement("idmodulo")
            .WriteString(idmodulo)
            .WriteEndElement()
            .WriteStartElement("CodSistema")
            .WriteString(CodSistema)
            .WriteEndElement()
            .WriteStartElement("Descripcion")
            .WriteString(Descripcion)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub createNodeSubModulo(ByVal idsubmodulo As Integer, ByVal Descripcion As String, ByVal estado As Integer, ByVal idmodulo As Integer, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("Modulo")
#Region "DatosXML"
            .WriteStartElement("idsubmodulo")
            .WriteString(idsubmodulo)
            .WriteEndElement()
            .WriteStartElement("Descripcion")
            .WriteString(Descripcion)
            .WriteEndElement()
            .WriteStartElement("estado")
            .WriteString(estado)
            .WriteEndElement()
            .WriteStartElement("idmodulo")
            .WriteString(idmodulo)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub createNodeAccesos(ByVal idaccesos As Integer, ByVal idrol As Integer, ByVal idsistema As Integer, ByVal idmodulo As Integer, ByVal idsubmodulo As Integer, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("Modulo")
#Region "DatosXML"
            .WriteStartElement("idaccesos")
            .WriteString(idaccesos)
            .WriteEndElement()
            .WriteStartElement("idrol")
            .WriteString(idrol)
            .WriteEndElement()
            .WriteStartElement("idsistema")
            .WriteString(idsistema)
            .WriteEndElement()
            .WriteStartElement("idmodulo")
            .WriteString(idmodulo)
            .WriteEndElement()
            .WriteStartElement("idsubmodulo")
            .WriteString(idsubmodulo)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub createNodeMC_LOCAL_LIST(ByVal IDLOCAL As Integer, ByVal RAZONCOMERCIAL As String, ByVal RUC As String, ByVal RAZONSOCIAL As String, ByVal TIPOLOCAL As String, ByVal UBICACION As String, ByVal ESTADO As String, ByVal CORREO As String, ByVal IPSERVER As String, ByVal BDINFOREST As String, ByVal BDALMACEN As String, ByVal SUPERVISOR As String, ByVal JEFEZONAL As String, ByVal SELECCION As Boolean, ByVal writer As XmlTextWriter)
        With writer
            .WriteStartElement("LocalList")
#Region "DatosXML"
            .WriteStartElement("IDLOCAL")
            .WriteString(IDLOCAL)
            .WriteEndElement()
            .WriteStartElement("RAZONCOMERCIAL")
            .WriteString(RAZONCOMERCIAL)
            .WriteEndElement()
            .WriteStartElement("RUC")
            .WriteString(RUC)
            .WriteEndElement()
            .WriteStartElement("RAZONSOCIAL")
            .WriteString(RAZONSOCIAL)
            .WriteEndElement()
            .WriteStartElement("TIPOLOCAL")
            .WriteString(TIPOLOCAL)
            .WriteEndElement()
            .WriteStartElement("UBICACION")
            .WriteString(UBICACION)
            .WriteEndElement()
            .WriteStartElement("ESTADO")
            .WriteString(ESTADO)
            .WriteEndElement()
            .WriteStartElement("CORREO")
            .WriteString(CORREO)
            .WriteEndElement()
            .WriteStartElement("IPSERVER")
            .WriteString(IPSERVER)
            .WriteEndElement()
            .WriteStartElement("BDINFOREST")
            .WriteString(BDINFOREST)
            .WriteEndElement()
            .WriteStartElement("BDALMACEN")
            .WriteString(BDALMACEN)
            .WriteEndElement()
            .WriteStartElement("SUPERVISOR")
            .WriteString(SUPERVISOR)
            .WriteEndElement()
            .WriteStartElement("JEFEZONAL")
            .WriteString(JEFEZONAL)
            .WriteEndElement()
            .WriteStartElement("SELECCION")
            .WriteString(SELECCION)
            .WriteEndElement()
#End Region
            .WriteEndElement()
        End With
    End Sub
    Shared Sub ExportToExcel(ByVal dt As DataTable, ByVal fileName As String, ByVal sheetName As String)
        If File.Exists(fileName) Then
            File.Delete(fileName)
        End If
        Dim oExcel As Object
        oExcel = CreateObject("Excel.Application")
        Dim oBook As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oBook = oExcel.Workbooks.Add
        oSheet = oExcel.Worksheets(1)

        oSheet.Name = "Hoja"
        'oSheet.Range("A1").Value = "SOME VALUE"
        oBook.SaveAs(fileName)
        oBook.Close()
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing

        ' Verificamos los parámetros pasados
        '
        If ((dt Is Nothing) OrElse
        (String.IsNullOrEmpty(fileName)) OrElse
        (String.IsNullOrEmpty(sheetName))) Then _
        Throw New ArgumentNullException()

        Dim app As Excel.Application = Nothing
        Dim book As Excel.Workbook = Nothing
        Dim sheet As Excel.Worksheet = Nothing

        Try
            ' Referenciamos la aplicación Excel.

            app = New Excel.Application()
            'Crear Libro y Hoja
            'book = app.Workbooks.Add("File")
            'sheet = book.Sheets("Hoja")

            ' Abrimos el libro de trabajo            '
            book = app.Workbooks.Open(fileName)
            ' Referenciamos la hoja de cálculo del libro.            '
            sheet = DirectCast(book.Sheets(sheetName), Excel.Worksheet)
            With sheet
                ' Limpiamos el contenido de toda la hoja.                '
                .Cells.Select()
                .Cells.ClearContents()

                ' Seleccionamos la primera celda de la hoja.                '
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo                '
                Dim fila As Integer = 1
                Dim columna As Integer = 1

                For Each dc As DataColumn In dt.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next

                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                '
                With .Range(.Cells(1, 1), .Cells(1, dt.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With

                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                '
                fila = 2
                For Each row As DataRow In dt.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dt.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)
                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()
            End With
        Catch ex As Exception
            ' Se ha producido una excepción;
            ' indicamos que el libro ha sido guardado.
            '
            If (book IsNot Nothing) Then
                book.Saved = True
            End If
            ' Devolvemos la excepción al procedimiento llamador
            Throw
        Finally
            sheet = Nothing
            If (book IsNot Nothing) Then
                ' Si procede, guardamos el libro de trabajo.
                If (Not (book.Saved)) Then book.Save()
                ' Cerramos el libro de Excel.
                book.Close()
            End If
            book = Nothing

            If (app IsNot Nothing) Then
                ' Si procede, cerramos Excel y disminuimos el recuento
                ' de referencias al objeto Excel.Application.
                app.Quit()
                While (System.Runtime.InteropServices.Marshal.ReleaseComObject(app) > 0)
                    ' Sin implementación.
                End While
            End If
            app = Nothing
        End Try
    End Sub
End Class