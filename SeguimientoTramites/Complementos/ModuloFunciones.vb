Imports Oracle.DataAccess.Client

Module ModuloFunciones
    Structure Sesion
        Public IdUsuario As Integer
        Public Usuario As String
        Public Nombre As String
        Public IdSucursalOficina As Integer
        Public Sucursal As String
        Public Oficina As String
        Public IdPuesto As Integer
        Public NombrePuesto As String
    End Structure

    Public SesionActiva As Sesion

    Public Function SHA1(ByVal strToHash As String) As String
        Using sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider()
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
            bytesToHash = sha1Obj.ComputeHash(bytesToHash)
            Dim strResult As String = ""
            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next
            Return strResult
        End Using
    End Function

    Public Function ValidarCorreo(ByVal correo As String) As Boolean
        If correo.IndexOf("@") > -1 Then
            If correo.IndexOf(".", correo.IndexOf("@")) > correo.IndexOf("@") Then
                Return True
            End If
        End If

        Return False
    End Function
    Public Function DameID(ByVal miGrid As DataGridView, Optional ByVal colID As Integer = 0)
        Try
            Return miGrid.CurrentRow().Cells(colID).Value
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatoGrid(ByVal grid As DataGridView, Optional ByVal columna As Integer = 0)
        Try
            Return grid.CurrentRow().Cells(columna).Value
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ProbarConexion(ByVal cadena As String) As String
        Try
            Using conn As New OracleConnection(cadena)
                conn.Open()
            End Using
            Return "OK"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function MinutosAHoras(ByVal mins As Integer) As String
        Dim minutos As Integer = 0
        Dim horas As Integer = Math.DivRem(mins, 60, minutos)
        Return String.Format("{0:00}:{1:00} {2}", horas, minutos, IIf(horas > 0, "horas", "minutos"))
    End Function
End Module
