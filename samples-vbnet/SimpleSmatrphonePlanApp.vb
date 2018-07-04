Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim intGBs As Integer = ValidateData(txtGBs.Text)
		If intGBs = 0 Then
			Return
		End If 
		If radBasic.Checked Then
			lblPrice.Text = CalcBasic(intGBs).ToString("C")
		Else
			lblPrice.Text = CalcDeluxe(intGBs).ToString("C")
		End If
	End Sub
	
	Private Function CalcBasic(ByVal intGBs)
		Return 29 + (4 * intGBs)
	End Function
	
	Private Function CalcDeluxe(ByVal intGBs)
		Return 19 + intGBs
	End Function
	
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
	
	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		txtGBs.Text = ""
		radBasic.Checked = True
		lblPrice.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class