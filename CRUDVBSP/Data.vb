Imports System.Data.SqlClient

Public Class Data
    Dim sqlConnection As SqlConnection = New SqlConnection()
    Dim connectionString As String = "Data Source=DESKTOP-NLEBNTP;Initial Catalog=Agenda;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    Public Function ObtenerContactos() As DataTable
        Dim sConsulta As String
        sConsulta = String.Format("EXEC SP_CONTACTOS 1")

        Dim adtAdaptador As SqlDataAdapter = New SqlDataAdapter(sConsulta, sqlConnection)
        Dim tblResultado As DataTable = New DataTable()


        sqlConnection.ConnectionString = connectionString

        sqlConnection.Open()


        adtAdaptador.Fill(tblResultado)

        sqlConnection.Close()

        Return (tblResultado)
    End Function

    Public Sub InsertarContacto(nombre As String, telefono As String, tipo As String, sexo As String, activo As Boolean)
        Dim sConsulta As String
        sConsulta = String.Format("EXEC SP_CONTACTOS 2,0,'{0}','{1}',{2},{3},{4}", nombre, telefono, tipo, sexo, activo)
        Dim cmdComando As SqlCommand = New SqlCommand(sConsulta, sqlConnection)
        Try
            'Da cadena de conexión
            sqlConnection.ConnectionString = connectionString

            'Abre la base de datos
            sqlConnection.Open()

            'Ejecuta comando
            cmdComando.ExecuteNonQuery()
            MsgBox("Datos insertados correctamente")
            sqlConnection.Close()
        Catch ex As SqlException
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ModificarContacto(nombre As String, telefono As String, tipo As String, sexo As String, activo As Boolean, id As String)
        Dim sConsulta As String
        sConsulta = String.Format("EXEC SP_CONTACTOS 3,{5},'{0}','{1}',{2},{3},{4}", nombre, telefono, tipo, sexo, activo, id)
        Dim cmdComando As SqlCommand = New SqlCommand(sConsulta, sqlConnection)
        Try
            'Da cadena de conexión
            sqlConnection.ConnectionString = connectionString

            'Abre la base de datos
            sqlConnection.Open()

            'Ejecuta comando
            cmdComando.ExecuteNonQuery()
            MsgBox("Datos modificados correctamente")
            sqlConnection.Close()
        Catch ex As SqlException
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub EliminarEmpleado(id As String)
        Dim sConsulta As String
        sConsulta = String.Format("EXEC SP_CONTACTOS 4,{0}", id)
        Dim cmdComando As SqlCommand = New SqlCommand(sConsulta, sqlConnection)
        Try
            'Da cadena de conexión
            sqlConnection.ConnectionString = connectionString

            'Abre la base de datos
            sqlConnection.Open()

            'Ejecuta comando
            cmdComando.ExecuteNonQuery()
            MsgBox("Eliminación con éxito")
            sqlConnection.Close()
        Catch ex As SqlException
            MsgBox(ex.Message)
        End Try
    End Sub
End Class



