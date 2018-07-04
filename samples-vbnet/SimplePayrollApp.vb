Public Class Form1
	Const cdecTaxRateSingle As Decimal = 22
	Const cdecTaxRateFamily As Decimal = 19.8
	Const cdecMinPayPerHour As Decimal = 7.25
	Const cdecMaxPayPerHour As Decimal = 40.00
	Const cintMinWorkHours As Integer = 8
	Const cintMaxWorkHours As Integer = 60
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim strName As String
		Dim intHours As Integer
		Dim decRate As Decimal
		Dim decGrossPay As Decimal
		Dim decTax As Decimal
		Dim decNetPay As Decimal
		If tbxName.Text = "" Or IsNumeric(tbxName.Text) Then
			MessageBox.Show("Please, enter a valid Name", "Error")
			tbxName.Text = ""
			Return
		End If
		strName = tbxName.Text
		If Not IsNumeric(tbxHours.Text) 
			OrElse Convert.ToInt32(tbxHours.Text) < cintMinWorkHours
			Or Convert.ToInt32(tbxHours.Text) > cintMaxWorkHours Then
				MessageBox.Show("Please, enter a valid number of hours worked", "Error")
				tbxNumMonths.Text = ""
				Return
		End If
		intHours = Convert.ToInt32(tbxHours.Text)
		If Not IsNumeric(tbxRate.Text) 
			OrElse Convert.ToDecimal(tbxRate.Text) < cdecMinPayPerHour
			Or Convert.ToDecimal(tbxRate.Text) > cdecMaxPayPerHour Then
				MessageBox.Show("Please, enter a valid hour rate", "Error")
				tbxRate.Text = ""
				Return
		End If
		decRate = Convert.ToInt32(tbxRate.Text)
		decGrossPay = intHours * decRate
		If intHours > 40 Then
			Dim intOverTime As Integer = intHours - 40
			decGrossPay += (intOverTime * decRate) / 2
		End If
		If radSingleTax.Checked = true Then
			decTax = (decGrossPay * cdecTaxRateSingle) / 100
		Else 
			decTax = (decGrossPay * cdecTaxRateFamily) / 100
		End If
		decNetPay = decGrossPay - decTax
		lblName.Text = strName + " : "
		lblGross.Text = decGrossPay.ToString("C")
		lblTax.Text = decTax.ToString("C")
		lblNet.Text = decNetPay.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxName.Text = ""
		tbxHours.Text = ""
		tbxRate.Text = ""
		lblName.Text = ""
		lblGross.Text = ""
		lblTax.Text = ""
		lblNet.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class