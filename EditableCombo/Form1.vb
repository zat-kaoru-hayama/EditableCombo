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
End Class
