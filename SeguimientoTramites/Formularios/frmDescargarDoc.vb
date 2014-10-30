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


    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim a As ARCHIVOS = EntityTablas.DescargarArchivo(ids)

        Dim K As Long = UBound(a.ARCHIVO)
        Dim generador As Random = New Random()
        Dim code As Integer = generador.Next(1, 1000)

        ' Se renombra el archivo, lo que causa que al abrir otro, no estoy invocando su nombre
        Dim filename As String = String.Format("C:\Users\Josué\Documents\Plantilla_{0}.docx", code)

        Using fs As New FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write)
            fs.Write(a.ARCHIVO, 0, K)
            fs.Close()
        End Using

        Dim MSWord As New Word.Application
        'Dim MSDocumento As New Document

        Try
            'MSDocumento = MSWord.Documents.Open(filename)
            'MSDocumento.Bookmarks.Item("nombre").Range.Text = campos.Nombre
            'MSDocumento.Bookmarks.Item("apellido").Range.Text = campos.Apellido
            'MSDocumento.Bookmarks.Item("direccion").Range.Text = campos.Direccion
            'MSDocumento.Bookmarks.Item("correo").Range.Text = campos.Correo
            'MSDocumento.Bookmarks.Item("telefono").Range.Text = campos.Telefono
            'MSDocumento.Save()

            Dim msg As String = String.Format("Documento guardado en: {0} {1} {0}{0}¿Desea abrirlo?", vbCrLf, filename)
            If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
                Process.Start(filename)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            'MSDocumento.Close()
        End Try


    End Sub
End Class