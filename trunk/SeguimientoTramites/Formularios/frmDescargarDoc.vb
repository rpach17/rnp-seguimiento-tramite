Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Word
Imports System.IO

Public Class frmDescargarDoc
    Private ids As Integer
    Public Property Ids1 As Integer
        Get
            Return ids
        End Get
        Set(ByVal value As Integer)
            ids = value
        End Set
    End Property

    Private idTramite As Integer
    Public Property IdTramite1 As Integer
        Get
            Return idTramite
        End Get
        Set(ByVal value As Integer)
            idTramite = value
        End Set
    End Property

    Private nombreDoc As String
    Public Property NombreDoc1 As String
        Get
            Return nombreDoc
        End Get
        Set(ByVal value As String)
            nombreDoc = value
        End Set
    End Property

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox1.Text = SaveFileDialog1.FileName
        End If






        Dim a As ARCHIVOS = EntityTablas.DescargarArchivo(ids)
        Dim marcadores_datos = EntityTablas.Marcadores(idTramite, a.IDFORMULARIO)

        Dim K As Long = UBound(a.ARCHIVO)

        ' Se renombra el archivo, lo que causa que al abrir otro, no estoy invocando su nombre
        Dim filename As String = String.Format("E:\{0}.docx", NombreDoc1)

        Dim MSWord As New Word.Application
        Dim MSDocumento As New Document

        Try
            Using fs As New FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write)
                fs.Write(a.ARCHIVO, 0, K)
                fs.Close()
            End Using

            MSDocumento = MSWord.Documents.Open(filename)
            For Each elemento In marcadores_datos
                MSDocumento.Bookmarks.Item(elemento.MARCADOR).Range.Text = elemento.VALOR
            Next
            MSDocumento.Save()

            Dim msg As String = String.Format("Documento guardado en: {0} {1} {0}{0}¿Desea abrirlo?", vbCrLf, filename)
            If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
                Process.Start(filename)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            MSDocumento.Close()
        End Try
    End Sub

End Class