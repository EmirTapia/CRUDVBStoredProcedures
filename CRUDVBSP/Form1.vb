Public Class Form1
    Dim _data As Data = New Data()
    Private Sub CargarDatos()
        dgvList.DataSource = _data.ObtenerContactos()
    End Sub
    Public Function ValidarFormulario() As Boolean
        If txtNombre.Text = String.Empty Then
            MessageBox.Show("Ingresa un nombre válido")
            Return False
        ElseIf txtTelefono.Text = String.Empty Then
            MessageBox.Show("Ingresa un telefono válido")
            Return False
        ElseIf cbSexo.SelectedItem = String.Empty Then
            MessageBox.Show("Ingresa un telefono válido")
            Return False
        ElseIf cbTipo.SelectedItem = String.Empty Then
            MessageBox.Show("Ingresa un telefono válido")
            Return False
        End If
        Return True
    End Function
    Private Sub LlenarFormulario()
        Dim i As Integer
        i = dgvList.CurrentCell.RowIndex

        txtID.Text = dgvList.Rows(i).Cells(0).Value.ToString()
        txtNombre.Text = dgvList.Rows(i).Cells(1).Value.ToString()
        txtTelefono.Text = dgvList.Rows(i).Cells(2).Value.ToString()
        cbTipo.SelectedIndex = dgvList.Rows(i).Cells(3).Value.ToString()
        cbSexo.SelectedIndex = dgvList.Rows(i).Cells(4).Value.ToString()
        rbActive.Checked = dgvList.Rows(i).Cells(5).Value.ToString()

        btnInsertar.Enabled = False
        btnLimpiar.Visible = True

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        If ValidarFormulario() Then
            _data.InsertarContacto(txtNombre.Text, txtTelefono.Text, cbTipo.SelectedIndex, cbSexo.SelectedIndex, rbActive.Checked)
            CargarDatos()
            BorrarCampos()
        End If
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        LlenarFormulario()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If ValidarFormulario() Then
            _data.ModificarContacto(txtNombre.Text, txtTelefono.Text, cbTipo.SelectedIndex, cbSexo.SelectedIndex, rbActive.Checked, txtID.Text)
            CargarDatos()
            BorrarCampos()
        End If

    End Sub
    Public Sub BorrarCampos()
        txtID.Text = String.Empty
        txtNombre.Text = String.Empty
        txtTelefono.Text = String.Empty
        cbSexo.SelectedIndex = 0
        cbTipo.SelectedIndex = 0
        rbActive.Checked = False

        btnInsertar.Enabled = True
        btnLimpiar.Visible = False
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        BorrarCampos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If (MsgBox("¿Esta seguro de eliminar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            If txtID.Text <> String.Empty Then
                _data.EliminarEmpleado(txtID.Text)

                CargarDatos()
                BorrarCampos()
            End If
        End If
    End Sub
End Class
