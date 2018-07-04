Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim intFactorial As Integer
		For value As Integer = 1 To 12 
			intFactorial = intNum
			For intNum As Integer = value - 1 To 1 Step -1 
				intFactorial *= intNum
			Next 
			lbxFactorials.Items.Add(value.ToString() + "! " + intFactorialvalue.ToString())
		Next 
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class