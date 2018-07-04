Public Class Form1
	Const cdecPricePerDay As Decimal = 29.99
	Const cdecPricePerMile As Decimal = 0.39

	Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
		Dim intDays As Integer = TextBoxDays.Text
		Dim intMiles As Integer = TextBoxMiles.Text
		Dim decCost As Decimal = (intDays * cdecPricePerDay) + (intMiles * cdecPricePerMile)
		lblCost.Text = decCost.ToString("C")
	End Sub

	Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
		lblCost.Text = ""
		TextBoxDays.Text = ""
		TextBoxMiles.Text = ""
	End Sub

	Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
		Application.Exit()
	End Sub
End Class 