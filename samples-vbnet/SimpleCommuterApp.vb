Public Class Form1
	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim decPrce As Decimal = 0
		If cbxChoice.SelectedIndex = 1 Then 
			decPrce = CalcCar()
		Else 
			decPrce = CalcTrain()
		Else 
			decPrce = CalcBus()
		End If
		If decPrce = 0 Then 
			Return 
		End If
		lblResult.Text = decPrce.ToString("C")
	End Sub
	
	Private Function ValidateData(ByVal strInput As String)
		If Not IsNumeric(strInput) 
			Return 0
		End If 
		Try
			intX = Convert.ToInt32(strInput)
			Return intX
		Catch ex As InvalidCastException
			MessageBox.Show("Please, enter valid value")
			Return 0
		End Try
	End Function
	

	Private Function CalcCar()
		Dim decCarDailyDistance As Decimal = ValidateData(tbxCarDailyDistance.Text)
		If decCarDailyDistance = 0 Then
			Return 0
		End If
		Dim decCarWorkdaysPerMonth As Decimal = ValidateData(tbxCarWorkdaysPerMonth.Text)
		If decCarWorkdaysPerMonth = 0 Then
			Return 0
		End If
		Dim decCarMilPerGalon As Decimal = ValidateData(tbxCarMilPerGalon.Text)
		If decCarMilPerGalon = 0 Then
			Return 0
		End If
		Dim decCarCostPerGalon As Decimal = ValidateData(tbxCarCostPerGalon.Text)
		If decCarCostPerGalon = 0 Then
			Return 0
		End If
		Return ((decCarDailyDistance / decCarMilPerGalon) * decCarCostPerGalon) * decCarWorkdaysPerMonth
	End Function
	Private Function CalcTrain()
		Dim decTrainCost As Decimal = ValidateData(tbxTrainCost.Text)
		If decTrainCost = 0 Then
			Return 0
		End If
		Dim decTraindays As Decimal = ValidateData(tbxTraindays.Text)
		If decTraindays = 0 Then
			Return 0
		End If
		Return decTrainCost * decWorkdays
	End Function
	Private Function CalcBus()
		Dim decBusCost As Decimal = ValidateData(tbxBusCost.Text)
		If decBusCost = 0 Then
			Return 0
		End If
		Dim decWorkdays As Decimal = ValidateData(tbxWorkdays.Text)
		If decWorkdays = 0 Then
			Return 0
		End If
		Return decBusCost * decWorkdays
	End Function
		
		
	Private Sub cbxChoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChoice.SelectedIndexChanged
		If cbxChoice.SelectedIndex = 0 Then
				pnlCarQuestions.Visible = False
				pnlTrainQuestions.Visible = False
				pnlBusQuestions.Visible = False
				btnAdd_Click.Visible = True
		Else If cbxChoice.SelectedIndex = 1 Then
				pnlCarQuestions.Visible = True
				pnlTrainQuestions.Visible = False
				pnlBusQuestions.Visible = False
				btnAdd_Click.Visible = True
		Else If cbxChoice.SelectedIndex = 2 Then
				pnlCarQuestions.Visible = False
				pnlTrainQuestions.Visible = True
				pnlBusQuestions.Visible = False
				btnAdd_Click.Visible = True
		Else If cbxChoice.SelectedIndex = 3 Then
				pnlCarQuestions.Visible = False
				pnlTrainQuestions.Visible = False
				pnlBusQuestions.Visible = True
				btnAdd_Click.Visible = True
		End If
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		btnAdd_Click.Visible = False
		pnlCarQuestions.Visible = False
		pnlTrainQuestions.Visible = False
		pnlBusQuestions.Visible = False
		tbxCarDailyDistance.Text = ""
		tbxCarWorkdaysPerMonth.Text = ""
		tbxCarMilPerGalon.Text = ""
		tbxCarCostPerGalon.Text = ""
		tbxTrainCost.Text = ""
		tbxTrainWorkdays.Text = ""
		tbxBusCost.Text = ""
		tbxBusWorkdays.Text = ""
	End Sub
	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class