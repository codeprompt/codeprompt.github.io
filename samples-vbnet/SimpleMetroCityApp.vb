Public Class Form1
	Const cdecPricePerRite As Decimal = 2.75
	Const cdecPricePerWeek As Decimal = 30
	Const cdecPricePerMonth As Decimal = 112
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim intNoTickets = Convert.ToInt32(txtNoTickets.Text)
		Dim decPrice
		If radSingleRite.Checked = true Then
			decPrice = intNoTickets * cdecPricePerRite
		Else If radWeek.Checked = true Then
			decPrice = intNoTickets * cdecPricePerWeek
		Else If radMonth.Checked = true Then
			decPrice = intNoTickets * cdecPricePerMonth
		End If
		lblPrice.Text = decPrice.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		radSingleRite.Checked = true
		txtNoTickets.Text = ""
		lblPrice.Text = ""	
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class