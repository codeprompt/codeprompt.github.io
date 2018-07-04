Public Class Form1
	Const cdecPrice As Decimal = 14.99

	Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
		Dim decCost As Decimal = cdecPrice * Convert.ToDecimal(TextBoxTickets.Text)
		lblCost.Text = decCost.ToString("C")
	End Sub

	Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
		lblCost.Text = ""
		TextBoxTickets.Text = ""
	End Sub

	Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
		Application.Exit()
	End Sub
End Class 