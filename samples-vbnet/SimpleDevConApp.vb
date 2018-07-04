Public Class Form1
	Const intMaxAttendees As Integer = 16
	Const cdecRecurringDiscountPercents As Decimal = 15
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim intNumberOfAttrndees As Integer
		Dim decPrice As Decimal
		If Not IsNumeric(tbxNumberOfAttendees.Text) 
			OrElse Convert.ToInt32(tbxNumberOfAttendees.Text) < 1
			Or Convert.ToInt32(tbxNumberOfAttendees.Text) > intMaxAttendees Then
				MessageBox.Show("Please, enter a valid number of attendees (between 1 and " + intMaxAttendees + ")", "Error")
				tbxNumberOfAttendees.Text = ""
				Return
		End If
		intNumberOfAttrndees = Convert.ToInt32(tbxNumberOfAttendees.Text)
		Select Case intNumberOfAttrndees
			Case Is < 2
				decPrice = 795
			Case Is < 5
				decPrice = 645
			Case Is < 8
				decPrice = 475
			Case Else
				decPrice = 385
		End Select  
		If chkFirstTime.Checked = false Then
			decPrice += (decPrice * cdecRecurringDiscountPercents) / 100
		End If
		lblPrice.Text = decPrice.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxNumberOfAttendees.Text = ""
		chkFirstTime.Checked = true
		lblPrice.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class