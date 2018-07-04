Public Class Form1
	Dim offers As New Dictionary(Of Integer, String)
		offers.Add(1, "Hummus")
		offers.Add(2, "Garlic Dip")
		offers.Add(3, "Hummus with Grilled Chicken")
		offers.Add(4, "Roasted Bell Pepper Hummus")
		offers.Add(5, "Cilantro Jalapeno Hummus")
	Dim prices As New Dictionary(Of String, Decimal)
		prices.Add("Hummus", 39.99)
		prices.Add("Garlic Dip", 42.99)
		prices.Add("Hummus with Grilled Chicken", 49.99)
		prices.Add("Roasted Bell Pepper Hummus", 44.99)
		prices.Add("Cilantro Jalapeno Hummus", 45.99)

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		ComboBoxPlatters.Items.Add("Please select one")
		ComboBoxPlatters.Items.Add(offers(1) + " " + prices(offers(1)).ToString("C"))
		ComboBoxPlatters.Items.Add(offers(2) + " " + prices(offers(2)).ToString("C"))
		ComboBoxPlatters.Items.Add(offers(3) + " " + prices(offers(3)).ToString("C"))
		ComboBoxPlatters.Items.Add(offers(4) + " " + prices(offers(4)).ToString("C"))
		ComboBoxPlatters.Items.Add(offers(5) + " " + prices(offers(5)).ToString("C"))
		ComboBoxPlatters.SelectedIndex = 0
		
		ComboBoxPlatters.Items.Add("Please select one")
		ComboBoxBreads.Items.Add("Standart Pita")
		ComboBoxBreads.Items.Add("Chapati")
		ComboBoxBreads.Items.Add("Khubz")
		ComboBoxBreads.SelectedIndex = 0
	End Sub
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim intLoyaltyPoints As Integer
		Dim decPrice As Decimal
		If tbxLoyaltyPoints.Text = "" Then 
			intLoyaltyPoints = 0 
		Else 
			If Not IsNumeric(tbxLoyaltyPoints.Text)
				OrElse Convert.ToInt32(tbxLoyaltyPoints.Text) < 0 Then
					MessageBox.Show("Please, enter a valid number of loyalty points", "Error")
					tbxLoyaltyPoints.Text = ""
					Return
			Else
				intLoyaltyPoints = Convert.ToInt32(tbxLoyaltyPoints.Text)
			End If
		End If
		If ComboBoxPlatters.SelectedIndex = 0 Then
			MessageBox.Show("Please, select an offer first", "Error")
			Return
		End If
		If ComboBoxBreads.SelectedIndex = 0 Then
			MessageBox.Show("Please, select bread first", "Error")
			Return
		End If
		decPrice = prices(offers(ComboBoxPlatters.SelectedIndex))
		Dim intDiscountPercentage As Integer = intLoyaltyPoints / 2
		If intDiscountPercentage > 100 Then
			intDiscountPercentage = 100
		End If
		decPrice -= (decPrice * intDiscountPercentage) / 100
		lblOrder.Text = offers(ComboBoxPlatters.SelectedIndex) + " with " +
						ComboBoxBreads.SelectedItem.ToString()
		If chkLemonAndGarlic.Checked And chkTahiniSause.Checked Then
			lblOrder.Text += " plus Lenmon and Garlic topping and Tahini Sause"
		Else If chkLemonAndGarlic.Checked
			lblOrder.Text += " plus Lenmon and Garlic topping"
		Else If chkTahiniSause.Checked
			lblOrder.Text += " plus Tahini Sause"
		End If
		lblOrder.Text += Environment.NewLine + decPrice.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxLoyaltyPoints.Text = ""
		lblOrder.Text = ""
		chkTahiniSause.Checked = false
		chkLemonAndGarlic.Checked = false
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class