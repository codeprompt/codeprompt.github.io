Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim decPrincipal As Decimal
		Dim decInterest As Decimal
		decPrincipal = Convert.ToDecimal(txtPrincipal.Text)
		decInterest = Convert.ToDecimal(txtInterest.Text) / 100
		For value As Integer = 1 to 5 
			decPrincipal *= (1 + decInterest)
			lbxYears.Items.Add(decPrincipal.ToString("C"))
		Next
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class