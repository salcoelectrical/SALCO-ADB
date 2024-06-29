Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Markup
Imports System.Xml
Imports ADOX

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim resp As MsgBoxResult = MsgBox("Is The owner information the same?", vbYesNo,)
        dc.Close()
        If resp = MsgBoxResult.Yes Then
            Call Full_duplication()

        Else
            Call new_cust_quote(con)
        End If
    End Sub


    Dim indx As Integer = 0
    Public Sub Full_duplication()
        Dim con As New OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim found As Boolean = True
        Dim da As New OleDb.OleDbDataAdapter
        Dim comcheck As New OleDbCommand
        Dim ds As New DataSet
        Dim x As Integer = 0
        Dim DQDG As New DataGridViewRow
        '  D_Q_DG.DataSource = ds
        ' D_Q_DG.DataSource = Nothing
        Dim rd As OleDbDataReader
        Dim TODAYquote As String = Date.Today().Date.ToString("d").Replace("/", "") & "_"

        Do While found = vbTrue
            With comcheck
                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "SELECT DISTINCT quotenumber FROM quotation WHERE (quotenumber ='" & TODAYquote & indx & "')"
                con.Open()
                rd = .ExecuteReader
                found = False
            End With
            While rd.Read()
                indx += 1
                found = True
            End While
            con.Close()
        Loop
        con.Open()
        Dim c_com As New OleDbCommand("SELECT quotenumber, ctq.name,customer.custname,
              customer.custlastname, quotedate,
              customer.custaddress, customer.custphone, customer.custemail 
              FROM (quotation INNER JOIN customer ON quotation.custID = customer.cusID) 
              INNER JOIN ctq ON quotation.quotenumber = ctq.quotenum  
              WHERE quotation.quotenumber =  '" & Form1.Quotenumber_CB.SelectedItem & "'", con)
        c_com.CommandType = CommandType.Text
        rd = c_com.ExecuteReader()
        If indx < 0 Then indx = 0
        rd.Read()
        D_cusname_TX.Text() = rd("custname").ToString()
        D_Cus_Lasname_TX.Text() = rd("custlastname").ToString()
        D_Cus_Adress_TX.Text() = rd("custaddress").ToString()
        D_Cus_Email_T.Text() = rd("custemail").ToString()
        D_Cus_Phone_TX.Text() = rd("custphone").ToString()
        D_Q_Number_TX.Text() = Date.Today().Date.ToString("d").Replace("/", "") & "_" & indx
        ' D_Q_Number_TX.Text() = rd("quotenumber").ToString()
        D_Q_Date_TX.Text() = Today()
        If indx < 0 Then indx = 0
        Dim qcom As New OleDbCommand("SELECT itemnumber, itemcode, itemdescription , 
              unit, matquantity, matcost, laborcost, 
              totalmatcost, totalaborcost, itemtotcost
              FROM (quotation INNER JOIN customer ON quotation.custID = customer.cusID) 
              INNER JOIN ctq ON quotation.quotenumber = ctq.quotenum  
         WHERE quotation.quotenumber =  '" & Form1.Quotenumber_CB.SelectedItem & "'", con)
        da.SelectCommand = qcom
        da.Fill(ds)
        D_Q_DG.DataSource = ds.Tables(0)
        With D_Q_DG
            .Columns("itemnumber").HeaderText = "Item Number"
            .Columns("itemcode").HeaderText = "Material Code"
            .Columns("itemdescription").HeaderText = " Material Description"
            .Columns("unit").HeaderText = "Unit"
            .Columns("matquantity").HeaderText = "Material Quantity"
            .Columns("matcost").HeaderText = "Material Cost"
            .Columns("laborcost").HeaderText = "Labor Cost"
            .Columns("totalmatcost").HeaderText = " Total Mat Cost"
            .Columns("totalaborcost").HeaderText = "Total Labor Cost"
            .Columns("itemtotcost").HeaderText = "Item Total Cost"
        End With
        con.Close()
    End Sub

    Dim TODAYquote As String = Date.Today().Date.ToString("d").Replace("/", "") & "_"
    Public Sub new_cust_quote(con)
        Dim found As Boolean
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim x As Integer = 0
        Dim DQDG As New DataGridViewRow
        D_Q_DG.DataSource = ds
        D_Q_DG.DataSource = Nothing
        Dim DQ_RGRow As DataGridViewRow

        Dim rd As OleDbDataReader

        Dim comcheck As New OleDbCommand("SELECT DISTINCT quotenumber FROM quotation", con)
        comcheck.CommandType = CommandType.Text
        con.Open()
        rd = comcheck.ExecuteReader()
        Do While found = vbTrue
            With comcheck
                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "SELECT DISTINCT quotenumber FROM quotation WHERE (quotenumber ='" & TODAYquote & indx & "')"
                con.Open()
                rd = .ExecuteReader
                found = False
            End With
            While rd.Read()
                indx += 1
                found = True
            End While
            con.Close()
        Loop
        D_Q_Number_TX.Text() = TODAYquote & "_" & indx
        Dim c_com As New OleDbCommand("SELECT itemnumber, itemcode, itemdescription , 
              unit, matquantity, matcost, laborcost, 
              totalmatcost, totalaborcost, itemtotcost
              FROM (quotation INNER JOIN customer ON quotation.custID = customer.cusID) 
              INNER JOIN ctq ON quotation.quotenumber = ctq.quotenum  
              WHERE quotation.quotenumber =  '" & Form1.Quotenumber_CB.SelectedItem & "'", con)

        D_Q_Date_TX.Text() = Today()
        If indx < 0 Then indx = 0
        da.SelectCommand = c_com
        da.Fill(ds)
        D_Q_DG.DataSource = ds.Tables(0)
        With D_Q_DG
            .Columns("itemnumber").HeaderText = "Item Number"
            .Columns("itemcode").HeaderText = "Material Code"
            .Columns("itemdescription").HeaderText = " Material Description"
            .Columns("unit").HeaderText = "Unit"
            .Columns("matquantity").HeaderText = "Material Quantity"
            .Columns("matcost").HeaderText = "Material Cost"
            .Columns("laborcost").HeaderText = "Labor Cost"
            .Columns("totalmatcost").HeaderText = " Total Mat Cost"
            .Columns("totalaborcost").HeaderText = "Total Labor Cost"
            .Columns("itemtotcost").HeaderText = "Item Total Cost"
        End With
        con.Close()
    End Sub

    Public Sub insert_customer(u_con)
        Dim up_com As New OleDbCommand
        Dim rd As OleDbDataReader
        Dim check_cust As New OleDbCommand()
        u_con.Open()
        Try
            With up_com
                .Connection = u_con
                .CommandType = CommandType.Text
                .CommandText = "SELECT cusID from customer WHERE ucsID = '" & D_cusname_TX.Text & D_Cus_Phone_TX.Text & "'"
                rd = .ExecuteReader()
            End With
            If rd.Read() = True Then MsgBox("Cusomer Already Registered", vbOKOnly) : Exit Sub

            With up_com
                .Connection = u_con
                .CommandType = CommandType.Text
                .CommandText = ("INSERT INTO customer(custname, custlastname, custaddress, custphone, custemail, custnote, cusID)
                                                   VALUES (@custname, @custlastname, @custaddress, @custphone, @custemail, @custnote, @cusID)")
                .Parameters.AddWithValue("@custname", D_cusname_TX.Text())
                .Parameters.AddWithValue("@custlastname", D_Cus_Lasname_TX.Text())
                .Parameters.AddWithValue("@custaddress", D_Cus_Adress_TX.Text())
                .Parameters.AddWithValue("@custphone", D_Cus_Phone_TX.Text().ToString)
                .Parameters.AddWithValue("@custemail", D_Cus_Email_T.Text())
                .Parameters.AddWithValue("@custnote", "")
                .Parameters.AddWithValue("@cusID", D_cusname_TX.Text() & D_Cus_Phone_TX.Text().Replace("-", ""))
                .Parameters("@custname").Value = D_cusname_TX.Text()
                .Parameters("@custlastname").Value = D_Cus_Lasname_TX.Text()
                .Parameters("@custaddress").Value = D_Cus_Adress_TX.Text()
                .Parameters("@custphone").Value = D_Cus_Phone_TX.Text().ToString
                .Parameters("@custemail").Value = D_Cus_Email_T.Text()
                .Parameters("@custnote").Value = ""
                .Parameters("@cusID").Value = D_cusname_TX.Text() & D_Cus_Phone_TX.Text().Replace("-", "")
                .ExecuteNonQuery()
            End With
            u_con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, "Execution Error Detected", vbOK)
        End Try
    End Sub
    Public Sub quote_table_update(u_con)
        Dim cmup As New OleDbCommand
        Dim up_com As New OleDbCommand
        Try
            up_com.Connection = u_con
            up_com.CommandText = ("INSERT INTO quotation(itemnumber,quotedate,quotenumber,itemcode,itemdescription,
                                                    unit,matquantity,matcost,laborcost,discount, totalmatcost,
                                                    totalaborcost,quoationame,custID, itemtotcost)
                                 VALUES(@itemnumber,@quotdate,@quotnumber,@itemcode,@itemdesc,@unit,
                                        @matquantity,@itemcost,@laborcost,@discount,@totalmatcost,@totalaborcost,
                                        @quoationame,@custID,@itemtotcost)")


            For Each rowitem As DataGridViewRow In D_Q_DG.Rows

                If rowitem.IsNewRow = True Then Exit For
                '  If rowitem.Cells(0).Value Is Nothing Or rowitem.Cells(0).Value.ToString = "" Then Call insertRecord() : Exit For
                If rowitem.Cells(1).Value = Nothing Then u_con.close() : Exit For
                With up_com
                    .Parameters.AddWithValue("@itemnumber", rowitem.Cells(0).Value)
                    .Parameters.AddWithValue("@quotdate", Convert.ToDateTime(D_Q_Date_TX.Text()))
                    .Parameters.AddWithValue("@quotnumber", D_Q_Number_TX.Text).ToString()
                    .Parameters.AddWithValue("@itemcode", rowitem.Cells(1).Value).ToString()
                    .Parameters.AddWithValue("@itemdescription", rowitem.Cells(2).Value).ToString()
                    .Parameters.AddWithValue("@unit", rowitem.Cells(3).Value).ToString()
                    .Parameters.AddWithValue("@matquantity", rowitem.Cells(4).Value)
                    .Parameters.AddWithValue("@matcost", rowitem.Cells(6).Value)
                    .Parameters.AddWithValue("@laborcost", rowitem.Cells(7).Value)
                    .Parameters.AddWithValue("@discount", 0)
                    .Parameters.AddWithValue("@totalmatcot", rowitem.Cells(8).Value)
                    .Parameters.AddWithValue("@totalaborcost", rowitem.Cells(9).Value)
                    .Parameters.AddWithValue("@quoationame", D_Q_Name.Text).ToString()
                    .Parameters.AddWithValue("@custID", D_cusname_TX.Text() & D_Cus_Phone_TX.Text()).ToString()
                    .Parameters.AddWithValue("@itemtotcost", rowitem.Cells(9).Value + rowitem.Cells(8).Value)

                    .Parameters("@itemnumber").Value = rowitem.Cells(0).Value
                    .Parameters("@quotdate").Value = Convert.ToDateTime(D_Q_Date_TX.Text())
                    .Parameters("@quotnumber").Value = D_Q_Number_TX.Text.ToString()
                    .Parameters("@itemcode").Value = rowitem.Cells(1).Value.ToString
                    .Parameters("@itemdescription").Value = rowitem.Cells(2).Value.ToString
                    .Parameters("@unit").Value = rowitem.Cells(3).Value.ToString
                    .Parameters("@matquantity").Value = rowitem.Cells(4).Value
                    .Parameters("@matcost").Value = rowitem.Cells(6).Value
                    .Parameters("@laborcost").Value = rowitem.Cells(7).Value
                    .Parameters("@discount").Value = 0
                    .Parameters("@totalmatcot").Value = rowitem.Cells(8).Value
                    .Parameters("@totalaborcost").Value = rowitem.Cells(9).Value
                    .Parameters("@quoationame").Value = D_Q_Name.Text.ToString()
                    .Parameters("@custID").Value = D_cusname_TX.Text() & D_Cus_Phone_TX.Text().ToString
                    .Parameters("@itemtotcost").Value = rowitem.Cells(9).Value + rowitem.Cells(8).Value

                    ' .Parameters.AddWithValue("ID", rowitem.Cells(0).Value)
                    u_con.Open()
                    up_com.ExecuteNonQuery()
                    u_con.Close()
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message, vbOK)
        End Try
        u_con.Close()
    End Sub
    Public Sub ctq_insert(con)
        Dim ctq_up_com As New OleDbCommand()

        'ctq_up_com.CommandType = CommandType.Text = "INSERT INTO ctq(ID,name,QuoteNum,quotename) VALUES(@ID,@name,@QuoteNum,@quotename)"


        With ctq_up_com
            .Connection = con
            .CommandText = CommandType.Text
            .CommandText = "INSERT INTO ctq(ID,name,QuoteNum,quotename) VALUES(@ID,@name,@QuoteNum,@quotename)"
            .Parameters.AddWithValue("@ID", D_cusname_TX.Text() & D_Cus_Phone_TX.Text())
            .Parameters.AddWithValue("@name", D_cusname_TX.Text() & " " & D_Cus_Lasname_TX.Text())
            .Parameters.AddWithValue("@QuoteNum", D_Q_Number_TX.Text())
            .Parameters.AddWithValue("@quotename", D_Q_Name.Text())
            .Parameters("@ID").Value = D_cusname_TX.Text() + D_Cus_Phone_TX.Text()
            .Parameters("@name").Value = D_cusname_TX.Text() & " " & D_Cus_Lasname_TX.Text()
            .Parameters("@QuoteNum").Value = D_Q_Number_TX.Text()
            .Parameters("@quotename").Value = D_Q_Name.Text()
        End With
        con.open()
        ctq_up_com.ExecuteNonQuery()
        con.close()
    End Sub

    Private Sub Save_dup_quote_BT_Click(sender As Object, e As EventArgs) Handles Save_dup_quote_BT.Click
        Dim u_con As New OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim checkcust As New OleDbCommand
        Dim rd As OleDbDataReader
        checkcust.CommandType = CommandType.Text
        Call quote_table_update(u_con)
        u_con.Close()
        Call insert_customer(u_con)
        With checkcust
            .Connection = u_con
            .CommandText = "SELECT cusID from customer WHERE (cusID = '" & D_cusname_TX.Text & D_Cus_Phone_TX.Text.Replace("-", "") & "')"
            u_con.Open()
            rd = .ExecuteReader()
        End With
        If rd.Read() = True Then Exit Sub
        u_con.Close()
        Call ctq_insert(u_con)

        u_con.Close()
    End Sub

    Private Sub D_Q_Exit_BTN_Click(sender As Object, e As EventArgs) Handles D_Q_Exit_BTN.Click
        Close()
        Form1.Show()
    End Sub
End Class