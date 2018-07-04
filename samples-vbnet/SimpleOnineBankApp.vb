Public Class Form1
	Dim decBalance As Decimal

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim decAmmount As Decimal 
		decAmmount = ValidateData(tbxInput.Text)
		If decTrainCost = vbNull Then
			Return
		End If
		decBalance += decTrainCost
	End Sub
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim decInterestPercent As Decimal 
		decInterestPercent = ValidateData(InterestPercent.Text)
		If decInterestPercent <> vbNull And decInterestPercent <> 0 Then
			decBalance *= 1 + (decInterestPercent / 100)
		End If
		lblResult.Text = decBalance.ToString("C")
	End Sub

	
	Private Function ValidateData(ByVal strInput As String)
		If Not IsNumeric(strInput) 
			Return vbNull
		End If 
		Try
			intX = Convert.ToInt32(strInput)
			Return intX
		Catch ex As InvalidCastException
			MessageBox.Show("Please, enter valid value")
			Return vbNull
		End Try
	End Function
	

	Private Function CalcCar()

	End Function

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class