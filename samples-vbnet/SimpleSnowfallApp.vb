Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim strAmmount As String
		Do
			strAmmount = InputBox("Enter Ammount")
			If strAmmount = "" Then
				If lbxInchesSnow.Items.Count = 0 Then
					MsgBox("Enter some value first!")
				Else
					Dim decAverage As Decimal = 0
					For value = 0 To lbxInchesSnow.Items.Count - 1
						decAverage += lbxInchesSnow.Items(value)
					Next
					decAverage = decAverage / lbxInchesSnow.Items.Count
					lblResult.Text = decAverage.ToString("F1") + " inches"
					Return
				End If
			Else
				lbxInchesSnow.Items.Add(strAmmount)
			End If
		Loop While lbxInchesSnow.Items.Count < 7
		Dim decAverage As Decimal = 0
		For value = 0 To lbxInchesSnow.Items.Count - 1
			decAverage += lbxInchesSnow.Items(value)
		Next
		decAverage = decAverage / lbxInchesSnow.Items.Count
		lblResult.Text = decAverage.ToString("F1") + " inches"
	End Sub

	Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
		lbxInchesSnow.Items.Clear()
		lblResult.Text = ""
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class