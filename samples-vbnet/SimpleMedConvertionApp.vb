Public Class Form1
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		If Not IsNumeric(tbxWeight.Text) Then
			MessageBox.Show("Invalid weight entered", "Error")
		Else If radToKg.Checked = True Then
			Dim decKG As Decimal = Convert.ToDecimal(tbxWeight.Text) / 2.2046
			lblWeight.Text = decKG.ToString("F3") + " lb"
		Else If radToLB.Checked = True Then
			Dim decLB As Decimal = Convert.ToDecimal(tbxWeight.Text) * 2.2046
			lblWeight.Text = decLB.ToString("F3") + " kg"
		End If
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxWeight.Text = ""
		lblWeight.Text = ""	
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class