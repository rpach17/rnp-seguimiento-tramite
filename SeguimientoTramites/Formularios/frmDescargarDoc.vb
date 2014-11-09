Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Word
Imports System.IO

Public Class frmDescargarDoc
    Private idf As Integer
    Public Property Idf1 As Integer
        Get
            Return idf
        End Get
        Set(ByVal value As Integer)
            idf = value
        End Set
    End Property

    Private iddseguimiento As Integer
    Public Property Iddseguimiento1 As Integer
        Get
            Return iddseguimiento
        End Get
        Set(ByVal value As Integer)
            iddseguimiento = value
        End Set
    End Property

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

    Private IdGS As Integer
    Public Property IdGS1 As Integer
        Get
            Return IdGS
        End Get
        Set(ByVal value As Integer)
            IdGS = value
        End Set
    End Property

    Private numSalto As Integer
    Public Property NumSalto1 As Integer
        Get
            Return numSalto
        End Get
        Set(ByVal value As Integer)
            numSalto = value
        End Set
    End Property


    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim filename As String = ""

        Try
            ' Intentar crear una aplicación de Word (generará una excepción si WOrd no está instalado
            Dim MSWord As New Word.Application
            Dim MSDocumento As New Document

            ' Se obtiene la ruta donde se almacenará el documento junto con su nombre
            FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments
            If FolderBrowserDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                filename = String.Format("{0}\{1}.docx", FolderBrowserDialog1.SelectedPath, NombreDoc1)
            End If

            ' Se obtienen los marcadores del archivo de word con el cual se enlazará
            Dim a As ARCHIVOS = EntityTablas.DescargarArchivo(ids)
            Dim marcadores_datos = EntityTablas.Marcadores(idTramite, a.IDFORMULARIO)

            Dim K As Long = UBound(a.ARCHIVO)

            Try
                ' Intentar eliminar un archivo que ya existe para crearlo de nuevo
                My.Computer.FileSystem.DeleteFile(filename)

                ' Si el archivo no existe se levanta una excepción, por esa razón se ejecuta la eliminación en un bloque seguro
            Catch ex As Exception
            End Try

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
                EntityTablas.ActualizarDetalleTramiteDoc(iddseguimiento, cboUserDestino.SelectedValue)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                MSDocumento.Close()
            End Try
        Catch ex As Exception
            ' Excepción si Word no está instalado
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmDescargarDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim idss As Integer = EntityTablas.ObtenerSiguienteSalto(IdGS, numSalto)
        EntityTablas.CargarUsuariosDestinoSalto(cboUserDestino, idss)
    End Sub
End Class