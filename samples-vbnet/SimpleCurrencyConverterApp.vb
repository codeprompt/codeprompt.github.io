Public Class Form1
	Const cdecToEUR As Decimal = 0.848648
	Const cdecToCAD As Decimal = 1.27687
	Const cdecToJPY As Decimal = 112.914
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim decAmmountUSD As Decimal = Convert.ToDecimal(tbxAmmountUSD.Text)
		Dim decEur As Decimal = (decAmmountUSD * cdecToEUR) / 100
		Dim decCad As Decimal = (decAmmountUSD * cdecToCAD) / 100
		Dim decJpy As Decimal = (decAmmountUSD * cdecToJPY) / 100
		Dim dt As Date = Convert.ToDateTime(tbxDate.Text)
		lblDate.Text = dt.ToString("U", Globalization.CultureInfo.CreateSpecificCulture("en-US"))
		lblUsd.Text = decAmmountUSD + " USD"
		lblEur.Text = decEur.ToString("C") + " EUR"
		lblCad.Text = decCad.ToString("C") + " CAD"
		lblJpy.Text = decJpy.ToString("C") + " JPY"
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxAmmountUSD.Text = ""
		tbxDate.Text = ""
		lblDate.Text = ""
		lblUsd.Text = ""
		lblEur.Text = ""
		lblCad.Text = ""
		lblJpy.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class