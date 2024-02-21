Public Class Form1
    Dim db As New dreamHomeDataContext
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Panel1.Visible = True
        btnSave.Enabled = True
        btnAdd.Enabled = False

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Panel1.Visible = False
        btnSave.Enabled = False
        btnAdd.Enabled = True
        txtSearch.Clear()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgBranch.DataSource = db.loadBranch


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        db.insertBranch(txtBranchNo.Text.Trim, txtStreet.Text.Trim, txtCity.Text.Trim, txtPostalCode.Text.Trim)
        dgBranch.DataSource = db.loadBranch

        Panel1.Visible = False
        btnSave.Enabled = False
        btnAdd.Enabled = True
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Length = 0 Then
            dgBranch.DataSource = db.loadBranch
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        Else
            btnEdit.Enabled = True
            btnDelete.Enabled = True

            dgBranch.DataSource = db.filterBranch(txtSearch.Text.Trim)


            If dgBranch.Rows.Count > 0 Then

                If dgBranch.CurrentRow IsNot Nothing Then
                    Try
                        txtBranchNo.Text = dgBranch.Item(0, 0).Value.ToString
                        txtStreet.Text = dgBranch.Item(1, 0).Value.ToString
                        txtCity.Text = dgBranch.Item(2, 0).Value.ToString
                        txtPostalCode.Text = dgBranch.Item(3, 0).Value.ToString

                    Catch ex As Exception

                    End Try
                Else

                End If
            Else

            End If
        End If
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Panel1.Visible = True
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        db.deleteBranch(txtBranchNo.Text)
        dgBranch.DataSource = db.loadBranch

        Panel1.Visible = False
        btnSave.Enabled = False
        btnAdd.Enabled = True
        txtSearch.Clear()


    End Sub

    Private Sub dgBranch_SelectionChanged(sender As Object, e As EventArgs) Handles dgBranch.SelectionChanged
        If dgBranch.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgBranch.SelectedRows(0)

            Try
                txtBranchNo.Text = selectedRow.Cells(0).Value.ToString
                txtStreet.Text = selectedRow.Cells(1).Value.ToString
                txtCity.Text = selectedRow.Cells(2).Value.ToString
                txtPostalCode.Text = selectedRow.Cells(3).Value.ToString
            Catch ex As Exception
                ' Handle the exception if necessary
            End Try
        End If
    End Sub
End Class
