Public Class Form1
	Const cdecPrice As Decimal = 18.0

	Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
		Dim decCost As Decimal = cdecPrice * Convert.ToDecimal(TextBoxNights.Text)
		lblCost.Text = decCost.ToString("C")
	End Sub

	Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
		lblCost.Text = ""
		TextBoxNights.Text = ""
	End Sub

	Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
		Application.Exit()
	End Sub
End Class