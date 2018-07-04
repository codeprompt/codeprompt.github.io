Public Class Form1
	Dim decHeight As Integer = 0 
	Dim decWidth As Integer = 0 
	
	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		If lbxMetricSystems.SelectedIndex = 1 Then
			lblResult.Text = CalcImperial().ToString()
		Else
			lblResult.Text = CalcMetric().ToString()
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
	
	Private Function CalcImperial()
		Return (decWidth / (decHeight * decHeight)) * 703 
	End Function
	Private Function CalcMetric()
		Return decWidth / (decHeight * decHeight)
	End Function
	
	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxWidth.Text = ""
		tbxHeight.Text = ""
		btnAdd.Visible = False
		lblResult.Text = ""
	End Sub
	Private Sub lbxMetricSystems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxMetricSystems.SelectedIndexChanged
		If decHeight > 0 And decWidth > 0 Then And lbxMetricSystems.SelectedIndex > 0
			btnAdd.Visible = True
		End If
	End Sub 
	Private Sub tbxHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxHeight.TextChanged
		decHeight = ValidateData(tbxHeight.Text)
		If decHeight > 0 And decWidth > 0 Then And lbxMetricSystems.SelectedIndex > 0
			btnAdd.Visible = True
		End If
	End Sub 
	Private Sub tbxWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxWidth.TextChanged
		decWidth = ValidateData(tbxWidth.Text)
		If decHeight > 0 And decWidth > 0 Then And lbxMetricSystems.SelectedIndex > 0
			btnAdd.Visible = True
		End If
	End Sub


	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class