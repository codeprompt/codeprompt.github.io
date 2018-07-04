Public Class Form1
	Const cdecTax As Decimal = 8.75

	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim decPrice As Decimal = Convert.ToDecimal(tbxItemPrice.Text)
		Dim decFinal As Decimal = decPrice + (decPrice * cdecTax) / 100
		lblPrice.Text = tbxItemName.Text + " " + decPrice.ToString("C") +
			", tax: " + cdecTax.ToString("F2") +
			"%, total: " + decFinal.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxItemName.Text = ""
		tbxItemPrice.Text = ""
		lblPrice.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
			End Sub					'intentianally misindented
End Class