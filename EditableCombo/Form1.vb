Option Strict On
Option Infer On

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.DataGridView1.ReadOnly = False
            Me.DataGridView1.Enabled = True
            For i As Integer = 0 To 1
                Dim row1 As New DataGridViewRow
                row1.CreateCells(Me.DataGridView1)
                row1.ReadOnly = False
                row1.Resizable = DataGridViewTriState.False

                row1.Cells(0).Value = i.ToString()
                row1.Cells(0).ReadOnly = False
                row1.Cells(1).Value = "A"
                row1.Cells(1).ReadOnly = False
                Me.DataGridView1.Rows.Add(row1)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Dim cmb = TryCast(Me.DataGridView1.CurrentCell, DataGridViewComboBoxCell)
        If cmb IsNot Nothing Then
            Dim cb = CType(e.Control, DataGridViewComboBoxEditingControl)
            cb.DropDownStyle = ComboBoxStyle.DropDown
        End If
    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Dim cbc = TryCast(Me.DataGridView1.CurrentCell, DataGridViewComboBoxCell)
        If cbc IsNot Nothing Then
            If Not cbc.Items.Contains(e.FormattedValue) Then
                cbc.Items.Add(e.FormattedValue)
            End If
            Me.DataGridView1.EndEdit()
            cbc.Value = e.FormattedValue
        End If
    End Sub
End Class
