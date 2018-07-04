Public Class Form1
	Const cdecCostPerFoot As Decimal = 9.87
	Const cdecCostOneTime As Decimal = 25
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		As Decimal = Convert.ToDecimal(tbxLength.Text)
		Dim decWidth As Decimal = Convert.ToDecimal(tbxWidth.Text)
		Dim decDepth As Decimal = Convert.ToDecimal(tbxDepth.Text)
		Dim decVolume As Decimal = decLength * decWidth * decDepth
		Dim decPrice As Decimal = (decVolume * cdecCostPerFoot) + cdecCostOneTime
		lblCost.Text = decPrice.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxLength.Text = ""
		tbxWidth.Text = ""
		tbxDepth.Text = ""
		lblCost.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class