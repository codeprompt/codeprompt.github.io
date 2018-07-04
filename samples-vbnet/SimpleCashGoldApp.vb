Public Class Form1
	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim decInput As Decimal = ValidateData(tbxInput.Text)
		If decInput = 0 Then 
			Return
		End If
		If radGoldNeeded.Checked Then 
			lblResult.Text = GoldNeeded(decInput).ToString() + " Ounces needed"
		Else 
			lblResult.Text = GoldWorth(decInput).ToString("C")
		End If
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
	
	Const cdecPricePerOunce = 1168.67
	Private Function GoldNeeded(ByVal decPrice As Decimal)
		Return decPrice / cdecPricePerOunce
	End Function
	Private Function GoldWorth(ByVal decAmmount As Decimal)
		Return decAmmount * cdecPricePerOunce
	End Function
	
	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxInput.Text = ""
		radGoldNeeded.Checked = True
		lblResult.Text = ""
	End Sub
	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class