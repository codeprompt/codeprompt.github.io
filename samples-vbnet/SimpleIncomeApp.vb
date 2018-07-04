Public Class Form1
	Const cdecFICATax As Decimal = 7.65
	Const cdecFedTax As Decimal = 22.0
	Const cdecStateTax As Decimal = 3.0
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim decAnualIncome As Decimal = Convert.ToDecimal(tbxAnualIncome.Text)
		Dim decFICATax As Decimal = (decAnualIncome * cdecFICATax) / 100
		Dim decFedTax As Decimal = (decAnualIncome * cdecFedTax) / 100
		Dim decStateTax As Decimal = (decAnualIncome * cdecStateTax) / 100
		Dim decNet As Decimal = decAnualIncome - decFICATax - decFedTax - decStateTax
		lblFICATax.Text = "FICA Tax: " + decFICATax.ToString("C")
		lblFedTax.Text = "Fed Tax: " + decFedTax.ToString("C")
		lblStateTax.Text = "FICA Tax: " + decStateTax.ToString("C")
		lblNetPay.Text = "Net: " + decNet.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxAnualIncome.Text = ""
		lblNetPay.Text = ""
		lblFICATax.Text = ""
		lblFedTax.Text = ""
		lblStateTax.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class