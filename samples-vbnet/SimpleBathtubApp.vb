Public Class Form1
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim decInches As Decimal = Convert.ToDecimal(tbxFeet.Text) * 12
		decInches = decInches + Convert.ToDecimal(tbxInches.Text)
		Dim decCircumference As Decimal = decInches * Math.PI
		Dim decArea As Decimal = Math.Pow((decInches / 2), 2) * Math.PI
		lblArea.Text = decArea.ToString("F2")
		lblCircumference.Text = decCircumference.ToString("F2")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxFeet.Text = ""
		tbxInches.Text = ""
		lblArea.Text = ""
		lblCircumference.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class