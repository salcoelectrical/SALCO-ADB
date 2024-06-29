Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles
Imports ADOX
'Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Access.Dao
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class Form1
    Private Const V As String = "Provider = Microsoft.ACE.OLEDB.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb"")
        Dim cmq As New OleDb.OleDbCommand
        Dim tax_total, sub_total, grand_total As Double
        Dim l_item As Integer = 0
        ' Start Excel and get Application object.
        oXL = CreateObject("
    Dim cn As New OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
    Dim da As New OleDbDataAdapter
    Dim cm As New OleDb.OleDbCommand
    Dim ds As New DataSet
    Dim dr As OleDb.OleDbDataReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Salco_partsDataSet.customer' table. You can move, or remove it, as needed.
        'Me.CustomerTableAdapter.Fill(Me.Salco_partsDataSet.customer)
        'TODO: This line of code loads data into the 'Salco_partsDataSet.quotation' table. You can move, or remove it, as needed.
        'Me.QuotationTableAdapter.Fill(Me.Salco_partsDataSet.quotation)
        Dim Sel_cust As String = ""
        Call Customer_selection()
        Call populate_quotenumber_CB(Sel_cust)
    End Sub
    'Populate <"Quote_view_DG"> with quotation items details for a specific customer and quotation number selected customer_CB
    Public Sub dis_quote(quotenumber, custname)
        Dim cm As New OleDb.OleDbCommand
        Dim subtotal, taxestotal As Double
        ds.Clear()
        Quot_Det_DG.DataSource = ds
        Quot_Det_DG.DataSource = Nothing

        Try
            With cm
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "SELECT ID,Itemnumber,itemcode,itemdescription,unit,matquantity,matcost,laborcost,totalmatcost,totalaborcost,discount,itemtotcost FROM quotation INNER JOIN customer ON quotation.custID = customer.cusID WHERE quotation.quotenumber = '" & quotenumber & "'"
                da.SelectCommand = cm
                da.Fill(ds)
                Quot_Det_DG.DataSource = ds.Tables(0) 'Produce a quotation view details'
            End With
            cn.Close()
        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical)
            cn.Close()
        End Try
        For Each rowitem As DataGridViewRow In Quot_Det_DG.Rows
            If rowitem.Cells(5).Value <> Nothing And rowitem.Cells(6).Value <> Nothing Then rowitem.Cells(8).Value = rowitem.Cells(5).Value * rowitem.Cells(6).Value
            If rowitem.Cells(5).Value <> Nothing And rowitem.Cells(7).Value <> Nothing Then rowitem.Cells(9).Value = rowitem.Cells(5).Value * rowitem.Cells(7).Value
            If rowitem.Cells(9).Value <> Nothing And rowitem.Cells(8).Value <> Nothing Then rowitem.Cells(11).Value = rowitem.Cells(9).Value + rowitem.Cells(8).Value
            subtotal = rowitem.Cells(11).Value + subtotal
            taxestotal = rowitem.Cells(8).Value * 0.0825 + taxestotal
        Next
        Quot_Det_DG.Columns(6).DefaultCellStyle.Format = "$ 0.00"
        Quot_Det_DG.Columns(7).DefaultCellStyle.Format = "$ 0.00"
        Quot_Det_DG.Columns(8).DefaultCellStyle.Format = "$ 0.00"
        Quot_Det_DG.Columns(9).DefaultCellStyle.Format = "$ 0.00"
        Quot_Det_DG.Columns(10).DefaultCellStyle.Format = "$ 0.00"
        Quot_Det_DG.Columns(11).DefaultCellStyle.Format = "$ 0.00"
        subTotal_TB.Text = FormatCurrency(subtotal, 2)
        TaxesTotal_TB.Text = FormatCurrency(taxestotal, 2)
        GrandTotal_TB.Text = FormatCurrency((subtotal + taxestotal), 2)
        Quot_desc_TB.Text() = ds.Tables(0).Columns(3).ToString
    End Sub

    Private Sub customer_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles customer_CB.SelectedIndexChanged
        'Dim selitem As Object
        Call populate_quotenumber_CB(customer_CB.SelectedItem.ToString)
    End Sub

    Private Sub Quotenumber_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Quotenumber_CB.SelectedIndexChanged
        Call dis_quote(quotenumber:=Quotenumber_CB.SelectedItem(), custname:=customer_CB.SelectedItem())
        Call pr_description(quotenumber:=Quotenumber_CB.SelectedItem())
    End Sub
    Private Sub pr_description(quotenumber)
        Dim Prjdes_cm As New OleDbCommand
        Dim dr As OleDbDataReader
        With Prjdes_cm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT quoationame FROM quotation WHERE quotenumber = '" & quotenumber & "'"
            cn.Open()
            dr = .ExecuteReader

        End With
        dr.Read()
        Quot_desc_TB.Text() = dr("quoationame").ToString
        cn.Close()
    End Sub

    ' Populate Quotenumber_CB based on the item selected in Customer_CB
    Public Sub populate_quotenumber_CB(Sel_cust)
        Dim cm As New OleDb.OleDbCommand
        Quotenumber_CB.Items.Clear()
        With cm
            cn.Open()
            .Connection = cn
            .CommandType = CommandType.Text
            If Sel_cust <> "" Then
                .CommandText = "SELECT DISTINCT quotenumber, quoationame FROM quotation INNER JOIN customer ON quotation.custID = customer.cusID  WHERE customer.custname =  '" & Sel_cust & "' "
            Else
                .CommandText = "SELECT DISTINCT quotenumber, quoationame FROM quotation INNER JOIN customer ON quotation.custID = customer.cusID  WHERE customer.custname =  '" & Sel_cust & "' "
            End If
            ' da.SelectCommand = cm
            dr = .ExecuteReader
        End With
        While dr.Read()
            Quotenumber_CB.Items.Add(dr("quotenumber").ToString) 'papulate quotation number

        End While

        cn.Close()
    End Sub

    Private Sub Customer_selection()
        Dim cm As New OleDb.OleDbCommand

        customer_CB.Items.Clear()
        With cm
            cn.Open()
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT custname FROM customer"
            dr = .ExecuteReader
        End With
        While dr.Read()
            customer_CB.Items.Add(dr("Custname").ToString)
        End While
        cn.Close()
    End Sub
    ' Update Quotation table records
    Private Sub Quot_Det_DG_cellvaluechanged(sender As Object, e As DataGridViewCellEventArgs) Handles Quot_Det_DG.CellContentClick
        Dim q_subtotal, q_taxtotal As Double
        Dim index As Integer
        Dim dgrow As DataGridViewRow
        Try
            index = e.RowIndex
            If index < 0 Then index = 0
            dgrow = Quot_Det_DG.Rows(index)
            dgrow.Cells(8).Value = dgrow.Cells(5).Value * dgrow.Cells(6).Value
            dgrow.Cells(9).Value = dgrow.Cells(5).Value * dgrow.Cells(7).Value
            dgrow.Cells(11).Value = dgrow.Cells(8).Value + dgrow.Cells(9).Value


            For Each dgridrow As DataGridViewRow In Quot_Det_DG.Rows
                If dgridrow.Cells(8).Value = Nothing Or dgridrow.Cells(9).Value = Nothing Then Exit For
                q_subtotal = dgridrow.Cells(8).Value + dgridrow.Cells(9).Value + q_subtotal
                q_taxtotal = dgridrow.Cells(8).Value * 0.0825 + q_taxtotal
            Next
            subTotal_TB.Text = FormatCurrency(q_subtotal, 2)
            TaxesTotal_TB.Text = FormatCurrency(q_taxtotal, 2)
            GrandTotal_TB.Text = FormatCurrency((q_subtotal + q_taxtotal), 2)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.ApplicationModal)
        End Try
    End Sub
    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Dim oXL As Excel.Application
    Dim oWB As Excel.Workbook
    Dim oSheet As Excel.Worksheet
    Dim oRng As Excel.Range
    Dim xlVAlignCenter As IntegerProperty
    Dim validate As New DateTimeOffset
    Private CustomerTableAdapter As Object

    Private Sub CreatequoteBTN_Click(sender As Object, e As EventArgs) Handles CreatequoteBTN.Click
        Dim cmq As New OleDb.OleDbCommand
        Dim tax_total, sub_total, grand_total As Double
        Dim l_item As Integer = 0
        ' Start Excel and get Application object.
        oXL = CreateObject("Excel.Application")
        oXL.Visible = True
        ' Get a new workbook.
        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet

        With cmq
            cn.Open()
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT quotenumber,customer.custname, customer.custlastname, 
                            customer.custaddress, customer.custphone, customer.custemail, itemnumber, 
                            quotedate, itemcode, itemdescription, unit, matquantity, matcost, laborcost, 
                            totalmatcost, totalaborcost, itemtotcost, ctq.ID, ctq.name 
                            FROM (quotation INNER JOIN customer ON quotation.custID = customer.cusID) 
                            INNER JOIN ctq ON quotation.quotenumber = ctq.quotenum  
                            WHERE quotation.quotenumber =  '" & Quotenumber_CB.SelectedItem & "' "

            If Quotenumber_CB.SelectedItem = Nothing Then Call errmsg() : cn.Close() : Exit Sub

            dr = .ExecuteReader
        End With


        ' formatting report
        oSheet.Cells(1, 1).value = "SALCO Electrical Quote"
        oSheet.Range(oSheet.Cells(1, 1), oSheet.Cells(1, 3)).Merge()
        oSheet.Range(oSheet.Cells(9, 2), oSheet.Cells(9, 3)).Merge()
        '  oSheet.Range(oSheet.Cells(10, 2), oSheet.Cells(10, 3)).Merge()
        oSheet.Range(oSheet.Cells(2, 1), oSheet.Cells(2, 3)).Merge()
        oSheet.Range(oSheet.Cells(6, 2), oSheet.Cells(6, 3)).Merge()
        oSheet.Range("A10:A25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("A10:A25").HorizontalAlignment = XlHAlign.xlHAlignCenter
        'oSheet.Range("A10").EntireColumn.AutoFit()
        oSheet.Range("D10:D25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("D10:D25").HorizontalAlignment = XlHAlign.xlHAlignCenter
        oSheet.Range("E10:E25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("E10:E25").HorizontalAlignment = XlHAlign.xlHAlignCenter
        oSheet.Range("E1:E9").HorizontalAlignment = XlHAlign.xlHAlignLeft
        oSheet.Range("F10:F25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("F11:F25").HorizontalAlignment = XlHAlign.xlHAlignRight
        oSheet.Range("G10:G25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("G11:G25").HorizontalAlignment = XlHAlign.xlHAlignRight
        oSheet.Range("C11:C25").HorizontalAlignment = XlHAlign.xlHAlignLeft
        oSheet.Range("B10").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("B11:B28").VerticalAlignment = XlHAlign.xlHAlignCenter
        oSheet.Range("B11:B25").HorizontalAlignment = XlHAlign.xlHAlignLeft
        oSheet.Range("F11:F28").NumberFormat = "$#,##0.00"
        oSheet.Cells(1, 2).style.font.name = "Arial Sans MS"
        ' oSheet.Columns("F").numberformat = "$#,##0.00_);[Red]($#,##0.00)"
        oSheet.Cells(2, 4).value = "Date "
        oSheet.Cells(2, 5).value = Today()
        oSheet.Range("F1").Font.Size = 12
        oSheet.Cells(2, 1).value = "Adress: 5310 Lotus Canyon CT Richmond TX 77407"
        oSheet.Cells(3, 1).value = "Phone: 832-341-6395"
        oSheet.Cells(4, 1).value = "Bill To: "
        oSheet.Cells(5, 1).value = "Full Name: "
        oSheet.Cells(6, 1).value = "Address: "
        oSheet.Cells(7, 1).value = "Email: "
        oSheet.Cells(8, 1).value = "Phone N.: "
        oSheet.Cells(1, 4).value = "Quote N.: "
        oSheet.Cells(5, 4).value = "Quote Date: "
        oSheet.Cells(7, 4).value = "Quote Valid until: "
        oSheet.Cells(6, 4).value = "Prepared by:"
        oSheet.Range("A1").Font.Bold = True
        oSheet.Range("A1").Font.Size = 20
        oSheet.Cells(10, 1).Value = "Item Number"
        oSheet.Cells(10, 2).Value = "Item Code"
        oSheet.Cells(10, 3).Value = "Description"
        oSheet.Cells(10, 4).Value = "Unit"
        oSheet.Cells(10, 5).value = "Quantity"
        '  oSheet.Cells(10, 6).value = "Material Cost"
        oSheet.Cells(10, 6).value = "Item Total Cost"
        ' oSheet.Cells(13, 7).value = "Labor Cost"
        With oSheet.Range("A10:G10")
            .EntireColumn.AutoFit()
            .Font.Bold = True
            .HorizontalAlignment = XlHAlign.xlHAlignCenter
            .VerticalAlignment = XlVAlign.xlVAlignCenter
        End With
        oSheet.Range("C11:C25").ColumnWidth = 70
        dr.Read()
        oSheet.Cells(1, 5).value = dr("quotenumber")
        oSheet.Cells(5, 2).value = dr("custname").ToString & " " & dr("custlastname").ToString
        oSheet.Cells(6, 5).value = dr("name").ToString
        oSheet.Cells(6, 2).value = dr("custaddress").ToString
        oSheet.Cells(7, 2).value = dr("custemail").ToString
        oSheet.Cells(8, 2).value = dr("custphone").ToString
        oSheet.Cells(5, 5).value = dr("quotedate").ToString
        oSheet.Cells(11 + l_item, 1).value = dr("itemnumber").ToString
        oSheet.Cells(11 + l_item, 2).value = dr("itemcode").ToString
        oSheet.Cells(11 + l_item, 3).value = dr("itemdescription").ToString
        oSheet.Cells(11 + l_item, 4).value = dr("unit").ToString
        oSheet.Cells(11 + l_item, 5).value = dr("matquantity")
        '  oSheet.Cells(11 + l_item, 6).value = dr("matcost")
        'oSheet.Cells(14 + l_item, 7).value = dr("laborcost")
        oSheet.Cells(11 + l_item, 6).value = dr("itemtotcost")
        tax_total = Val(dr("matquantity").ToString) * Val(dr("matcost").ToString) * 0.0825 + tax_total
        sub_total = (Val(dr("matcost").ToString) + Val(dr("laborcost").ToString)) * Val(dr("matquantity").ToString) + sub_total

        l_item = 1 + l_item
        While dr.Read()
            oSheet.Cells(11 + l_item, 1).value = dr("itemnumber").ToString
            oSheet.Cells(11 + l_item, 2).value = dr("itemcode").ToString
            oSheet.Cells(11 + l_item, 3).value = dr("itemdescription").ToString
            oSheet.Cells(11 + l_item, 4).value = dr("unit").ToString
            oSheet.Cells(11 + l_item, 5).value = dr("matquantity")
            oSheet.Cells(11 + l_item, 6).value = dr("matcost")
            'oSheet.Cells(14 + l_item, 7).value = dr("laborcost")
            oSheet.Cells(11 + l_item, 6).value = dr("itemtotcost")
            tax_total = Val(dr("totalmatcost").ToString) * 0.0825 + tax_total
            sub_total = dr("itemtotcost").ToString + sub_total
            l_item = 1 + l_item
        End While
        grand_total = tax_total + sub_total + grand_total
        'other formatting needed
        oSheet.Range("C11:C28").EntireColumn.WrapText = True
        oSheet.Range("B8").HorizontalAlignment = XlHAlign.xlHAlignLeft
        ' oSheet.Range("A4").EntireColumn.Font.Bold = True
        'oSheet.Range("A1:A10").EntireColumn.AutoFit()
        oSheet.Range("D3:D11").EntireColumn.AutoFit()
        '   oSheet.Range("A13:A23").EntireColumn.AutoFit()
        oSheet.Range("B11:B23").EntireColumn.AutoFit()
        oSheet.Range("E3:E9").EntireColumn.AutoFit()
        oSheet.Range("F11:G25").EntireColumn.AutoFit()
        cn.Close()


        Call borderformat()
        oSheet.Cells(26, 5).value = "Sub Total: " : oSheet.Cells(26, 6).value = sub_total
        oSheet.Cells(27, 5).value = "Taxes Total: " : oSheet.Cells(27, 6).value = tax_total
        oSheet.Cells(28, 5).value = "Total:" : oSheet.Cells(28, 6).value = grand_total
    End Sub
    ' Private Sub DisplayQuarterlySales(oWS As Excel.Worksheet)
    ' Dim oResizeRange As Excel.Range
    ' Dim oChart As Excel.Chart
    ' Dim iNumQtrs As Integer = 10
    ' Dim sMsg As String
    ' Dim iRet As Integer
    ' Dim xlThin As Integer = 12
    ' Dim xlDouble As Integer = 12
    ' Dim xlThick As Integer = 12
    ' Dim xlEdgeBottom As Integer = 12
    ' Dim xl3DColumn As Integer
    ' Dim oSeries As Excel.Series

    ' Determine how many quarters to display data for.
    ' For iNumQtrs = 4 To 2 Step -1
    '        sMsg = "Enter sales data for" & Str(iNumQtrs) & " quarter(s)?"
    '       iRet = MsgBox(sMsg, vbYesNo Or vbQuestion _
    '         Or vbMsgBoxSetForeground, "Quarterly Sales")
    ' If iRet = vbYes Then Exit For
    ' Next iNumQtrs

    '    sMsg = "Displaying data for" & Str(iNumQtrs) & " quarter(s)."
    '  MsgBox sMsg, vbMsgBoxSetForeground, "Quarterly Sales"

    ' Starting at E1, fill headers for the number of columns selected.
    '   oResizeRange = oWS.Range("E1", "E1").Resize(ColumnSize:=iNumQtrs)

    '  oResizeRange.Formula = "=""Q"" & COLUMN()-4 & CHAR(10) & ""Sales"""

    ' Change the Orientation and WrapText properties for the headers.
    '  oResizeRange.Orientation = 38
    '  oResizeRange.WrapText = True

    ' Fill the interior color of the headers.
    '  oResizeRange.Interior.ColorIndex = 36

    ' Fill the columns with a formula and apply a number format.
    '  oResizeRange = oWS.Range("E2", "E6").Resize(ColumnSize:=iNumQtrs)
    '  oResizeRange.Formula = "=RAND()*100"
    '  oResizeRange.NumberFormat = "$0.00"

    ' Apply borders to the Sales data and headers.
    '  oResizeRange = oWS.Range("E1", "E6").Resize(ColumnSize:=iNumQtrs)
    '  oResizeRange.Borders.Weight = Excel.XlBorderWeight.xlThin

    ' Add a Totals formula for the sales data and apply a border.
    '  oResizeRange = oWS.Range("E8", "E8").Resize(ColumnSize:=iNumQtrs)
    '  oResizeRange.Formula = "=SUM(E2:E6)"
    ' With oResizeRange.Borders(xlEdgeBottom)
    ' .LineStyle = xlDouble
    ' .Weight = Excel.XlBorderWeight.xlThick
    ' End With

    ' Add a Chart for the selected data
    '    oResizeRange = oWS.Range("E2:E6").Resize(ColumnSize:=iNumQtrs)
    '    oChart = oWS.Parent.Charts.Add
    ' With oChart
    ' .ChartWizard(oResizeRange, Excel.XlChartType.xl3DColumn, , Excel.XlRowCol.xlColumns)
    '         oSeries = .SeriesCollection(1)
    '         oSeries.XValues = oWS.Range("A2", "A6")
    ' For iRet = 1 To iNumQtrs
    ' .SeriesCollection(iRet).Name = "=""Q" & Str(iRet) & """"
    ' Next iRet
    ' .Location(Excel.XlChartLocation.xlLocationAsObject, oWS.Name)
    ' End With

    ' Move the chart so as not to cover your data.
    ' With oWS.Shapes("Chart 1")
    ' .Top = oWS.Rows(10).Top
    ' .Left = oWS.Columns(2).Left

    ' End With

    ' Free any references.
    '    oChart = Nothing
    '   oResizeRange = Nothing

    '   End Sub

    Private Sub Up_Existing_quote_BTN_Click(sender As Object, e As EventArgs) Handles Up_Existing_quote_BTN.Click
        Dim cm As New OleDb.OleDbCommand
        For Each rowitem As DataGridViewRow In Quot_Det_DG.Rows
            If rowitem.IsNewRow() = True Then Exit For
            If rowitem.Cells(0).Value Is Nothing Or rowitem.Cells(0).Value.ToString = "" Then Call insertRecord() : Exit For

            Try
                cm = New OleDb.OleDbCommand("UPDATE quotation SET Itemnumber = @Itemnumber, itemcode = @itemcode, itemdescription = @itemdescription, unit = @unit, matquantity = @matquantity, matcost = @matcost, laborcost = @laborcost, totalmatcost= @totalmatcost, totalaborcost = @totalaborcost, discount = @discount, itemtotcost = @itemtotcost WHERE ID = @ID", cn) 'Itemnumber = @Itemnumber, itemcode = @itemcode, itemdescription = @itemdescription, unit = @unit, matquantity = @matquantity, matcost = @matcost, laborcost = @laborcost, totalmatcost= @totalmatcost, totalaborcost = @totalaborcost, discount = @discount, itemtotcost = @itemtotcost WHERE ID = @ID WHERE ID = @ID", cn)
                If rowitem.Cells(1).Value = Nothing Then Exit For
                With cm
                    .Parameters.AddWithValue("Itemnumber", rowitem.Cells(1).Value)
                    .Parameters.AddWithValue("itemcode", rowitem.Cells(2).Value)
                    .Parameters.AddWithValue("itemdescription", rowitem.Cells(3).Value)
                    .Parameters.AddWithValue("unit", rowitem.Cells(4).Value)
                    .Parameters.AddWithValue("matquantity", rowitem.Cells(5).Value)
                    .Parameters.AddWithValue("matcost", rowitem.Cells(6).Value)
                    .Parameters.AddWithValue("laborcost", rowitem.Cells(7).Value)
                    .Parameters.AddWithValue("totalmatcost", rowitem.Cells(6).Value * rowitem.Cells(5).Value)
                    .Parameters.AddWithValue("totalaborcost", rowitem.Cells(7).Value * rowitem.Cells(5).Value)
                    .Parameters.AddWithValue("discount", rowitem.Cells(10).Value)
                    .Parameters.AddWithValue("itemtotcost", rowitem.Cells(5).Value * (rowitem.Cells(6).Value + rowitem.Cells(7).Value))
                    .Parameters.AddWithValue("ID", rowitem.Cells(0).Value)
                    .Parameters.AddWithValue("ID", rowitem.Cells(0).Value)
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                End With
            Catch ex As System.Exception
                MsgBox(ex.Message & "Quotation has not been UPDATED!", MsgBoxResult.Ok)
                cn.Close()
                Exit Sub
            End Try
        Next
        MsgBox("Quotation UPDATED!", vbOK)
    End Sub
    Private Sub insertRecord()
        Dim cn As New OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim cm, scm As New OleDbCommand
        Dim srd As OleDbDataReader
        scm.CommandText = CommandType.Text
        scm.Connection = cn
        scm.CommandText = "SELECT quotenumber,custID,quoationame, quocreaname,quotedate from quotation WHERE quotenumber = '" & Quotenumber_CB.SelectedItem & "'"
        cn.Open()
        srd = scm.ExecuteReader
        srd.Read()
        cm.Connection = cn
        cm.CommandText = CommandType.Text
        '      cm.CommandText = "INSERT INTO quotation(Itemnumber,itemcode,itemdescription,unit,matquantity,matcost,laborcost,totalmatcost,totalaborcost,discount,itemtotcost)
        '      VALUES(@Itemnumber,@itemcode,@itemdescription,@unit,@matquantity,@matcost,@laborcost,@totalmatcost,@totalaborcost,@discount,@itemtotcost)"
        cm.CommandText = "INSERT INTO quotation(quotenumber, custID, Itemnumber,quotedate, itemcode,itemdescription,unit,matquantity,matcost,laborcost,discount, totalmatcost,totalaborcost, quoationame,quocreaname, itemtotcost )
                          VALUES(@quotenumber, @custID,@Itemnumber, @quotedate, @itemcode,@itemdescription,@unit,@matquantity,@matcost,@laborcost,@discount, @totalmatcost,@totalaborcost, @quoationame,@quocreaname, @itemtotcost)"

        '  cm.Parameters.AddWithValue("@quotenumber", Quotenumber_CB.SelectedItem)
        cm.Parameters.AddWithValue("@quotenumber", srd("quotenumber").ToString)
        cm.Parameters.AddWithValue("@custID", srd("custID").ToString)
        cm.Parameters.AddWithValue("@Itemnumber", Quot_Det_DG.Item(1, 3).Value)
        cm.Parameters.AddWithValue("@quotedate", srd("quotedate").ToString)
        cm.Parameters.AddWithValue("@itemcode", Quot_Det_DG.Item(2, 3).Value)
        cm.Parameters.AddWithValue("@itemdescription", Quot_Det_DG.Item(3, 3).Value)
        cm.Parameters.AddWithValue("@unit", Quot_Det_DG.Item(4, 3).Value)
        cm.Parameters.AddWithValue("@matquantity", Quot_Det_DG.Item(5, 3).Value)
        cm.Parameters.AddWithValue("@matcost", Quot_Det_DG.Item(6, 3).Value)
        cm.Parameters.AddWithValue("@laborcost", Quot_Det_DG.Item(7, 3).Value)
        cm.Parameters.AddWithValue("@discount", Quot_Det_DG.Item(10, 3).Value)
        cm.Parameters.AddWithValue("@totalmatcost", Quot_Det_DG.Item(6, 3).Value * Quot_Det_DG.Item(7, 3).Value)
        cm.Parameters.AddWithValue("@totalaborcost", Quot_Det_DG.Item(6, 3).Value * Quot_Det_DG.Item(9, 3).Value)
        cm.Parameters.AddWithValue("@quoationame", srd("quoationame").ToString)
        cm.Parameters.AddWithValue("@quocreaname", srd("quocreaname").ToString)
        cm.Parameters.AddWithValue("@itemtotcost", Quot_Det_DG.Item(11, 3).Value * (Quot_Det_DG.Item(10, 1).Value + Quot_Det_DG.Item(8, 1).Value))
        ' cm.Parameters.AddWithValue("ID", Quot_Det_DG.Item(11, 3).Value)
        cm.Parameters("@quotenumber").Value = srd("quotenumber").ToString
        cm.Parameters("@custID").Value = srd("custID").ToString
        cm.Parameters("@Itemnumber").Value = Quot_Det_DG.Item(1, 3).Value
        cm.Parameters("@quotedate").Value = srd("quotedate").ToString
        cm.Parameters("@itemcode").Value = Quot_Det_DG.Item(2, 3).Value
        cm.Parameters("@itemdescription").Value = Quot_Det_DG.Item(3, 3).Value
        cm.Parameters("@unit").Value = Quot_Det_DG.Item(4, 3).Value
        cm.Parameters("@matquantity").Value = Quot_Det_DG.Item(5, 3).Value
        cm.Parameters("@matcost").Value = Quot_Det_DG.Item(6, 3).Value
        cm.Parameters("@laborcost").Value = Quot_Det_DG.Item(7, 3).Value
        cm.Parameters("@discount").Value = Quot_Det_DG.Item(10, 3).Value
        cm.Parameters("@totalmatcost").Value = Quot_Det_DG.Item(6, 3).Value * Quot_Det_DG.Item(7, 3).Value
        cm.Parameters("@totalaborcost").Value = Quot_Det_DG.Item(6, 3).Value * Quot_Det_DG.Item(9, 3).Value
        cm.Parameters("@quoationame").Value = srd("quoationame").ToString
        cm.Parameters("@quocreaname").Value = srd("quocreaname").ToString
        cm.Parameters("@itemtotcost").Value = Quot_Det_DG.Item(11, 3).Value * (Quot_Det_DG.Item(10, 1).Value + Quot_Det_DG.Item(8, 1).Value)
        cm.ExecuteNonQuery()
        cn.Close()
    End Sub
    Private Sub create_invoice_BTN_Click(sender As Object, e As EventArgs) Handles create_invoice_BTN.Click
        Dim l_item As Integer
        Dim tax_total As Double, sub_total, grand_total
        'Dim cn As new OleDb.OleDbConnection(VExcel.Application")
        oXL = CreateObject("Excel.Application")
        oXL.Visible = True
        ' Get a new workbook.
        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet
        Dim cmq As New OleDbCommand
        With cmq
            cn.Open()
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "Select DISTINCT quotenumber, customer.custname, customer.custlastname, customer.custaddress, customer.custphone, customer.custemail, itemnumber, quotedate, itemcode, itemdescription, unit, matquantity, matcost, laborcost, totalmatcost, totalaborcost, itemtotcost FROM quotation  INNER JOIN customer On quotation.custID = customer.cusID   WHERE quotation.quotenumber =  '" & Quotenumber_CB.SelectedItem & "' "
        If Quotenumber_CB.SelectedItem = Nothing Then Call errmsg() : cn.Close() : Exit Sub
        End With
        ' formatting report
        oSheet.Cells(1, 1).value = "SALCO Electrical Invoice"
        oSheet.Range(oSheet.Cells(1, 1), oSheet.Cells(1, 3)).Merge()
        oSheet.Range(oSheet.Cells(9, 2), oSheet.Cells(9, 3)).Merge()
        oSheet.Range(oSheet.Cells(4, 1), oSheet.Cells(4, 3)).Merge()
        '  oSheet.Range(oSheet.Cells(10, 2), oSheet.Cells(10, 3)).Merge()
        oSheet.Range(oSheet.Cells(2, 1), oSheet.Cells(2, 3)).Merge()
        oSheet.Range(oSheet.Cells(6, 2), oSheet.Cells(6, 3)).Merge()
        oSheet.Range(oSheet.Cells(30, 2), oSheet.Cells(30, 3)).Merge()
        oSheet.Range(oSheet.Cells(31, 2), oSheet.Cells(31, 3)).Merge()
        oSheet.Range(oSheet.Cells(32, 2), oSheet.Cells(32, 3)).Merge()
        oSheet.Range(oSheet.Cells(33, 2), oSheet.Cells(33, 3)).Merge()
        oSheet.Range(oSheet.Cells(34, 2), oSheet.Cells(34, 3)).Merge()
        oSheet.Range(oSheet.Cells(35, 2), oSheet.Cells(35, 3)).Merge()
        oSheet.Range("A10:A25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("A10:A25").HorizontalAlignment = XlHAlign.xlHAlignCenter
        'oSheet.Range("A10").EntireColumn.AutoFit()
        oSheet.Range("A4:F4").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("A4:C4").HorizontalAlignment = XlHAlign.xlHAlignCenter
        oSheet.Range("D10:D25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("D10:D25").HorizontalAlignment = XlHAlign.xlHAlignCenter
        oSheet.Range("E10:E25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("E10:E25").HorizontalAlignment = XlHAlign.xlHAlignCenter
        oSheet.Range("E1:E9").HorizontalAlignment = XlHAlign.xlHAlignLeft
        oSheet.Range("F10:F25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("F11:F25").HorizontalAlignment = XlHAlign.xlHAlignRight
        oSheet.Range("G10:G25").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("G11:G25").HorizontalAlignment = XlHAlign.xlHAlignRight
        oSheet.Range("C11:C25").HorizontalAlignment = XlHAlign.xlHAlignLeft
        oSheet.Range("B10").VerticalAlignment = XlVAlign.xlVAlignCenter
        oSheet.Range("B11:B28").VerticalAlignment = XlHAlign.xlHAlignCenter
        oSheet.Range("B11:B25").HorizontalAlignment = XlHAlign.xlHAlignLeft
        oSheet.Range("F11:F28").NumberFormat = "$#,##0.00"
        oSheet.Cells(1, 2).style.font.name = "Arial Sans MS"
        oSheet.Cells(2, 4).value = "Date "
        oSheet.Cells(2, 5).value = Today()
        oSheet.Range("F1").Font.Size = 12
        oSheet.Cells(2, 1).value = "Adress: 5310 Lotus Canyon Court Richmond TX 77407"
        oSheet.Cells(3, 1).value = "Phone: 832-341-6395"
        oSheet.Cells(4, 1).value = "Billing To: "
        oSheet.Cells(5, 1).value = "Full Name: "
        oSheet.Cells(6, 1).value = "Address: "
        oSheet.Cells(7, 1).value = "Email: "
        oSheet.Cells(8, 1).value = "Phone N.: "
        oSheet.Cells(1, 4).value = "Invoice N.: "
        oSheet.Cells(8, 4).value = "Quote Date: "
        'oSheet.Cells(3, 4).value = "Quotation Valid until: "
        oSheet.Cells(7, 4).value = "Prepared by: Salvatore Colaiuda"
        oSheet.Range("A1").Font.Bold = True
        oSheet.Range("A1").Font.Size = 20
        oSheet.Cells(10, 1).Value = "Item Number"
        oSheet.Cells(10, 2).Value = "Item Code"
        oSheet.Cells(10, 3).Value = "Description"
        oSheet.Cells(10, 4).Value = "Unit"
        oSheet.Cells(10, 5).value = "Quantity"
        '  oSheet.Cells(10, 6).value = "Material Cost"
        oSheet.Cells(10, 6).value = "Item Total Cost"
        ' oSheet.Cells(13, 7).value = "Labor Cost"
        oSheet.Cells(30, 2).value = "Thank you for your business !"
        oSheet.Cells(31, 2).value = "Your Payment transaction can be done as follow:"
        oSheet.Cells(32, 2).value = "Zelle using Phone Number: 832-341-6395"
        oSheet.Cells(33, 2).value = "Apple Pay using the phone number: 832-341-6395"
        oSheet.Cells(34, 2).value = "By Check attention to: SALCO Electrical"
        oSheet.Cells(35, 2).value = "Or Cash."
        With oSheet.Range("A10:G10")
            .EntireColumn.AutoFit()
            .Font.Bold = True
            .HorizontalAlignment = XlHAlign.xlHAlignCenter
            .VerticalAlignment = XlVAlign.xlVAlignCenter
        End With
        oSheet.Range("C11:C25").ColumnWidth = 70
        dr = cmq.ExecuteReader()
        dr.Read()
        oSheet.Cells(1, 5).value = dr("quotenumber").ToString
        oSheet.Cells(5, 2).value = dr("custname").ToString & "" & dr("custlastname").ToString
        oSheet.Cells(6, 2).value = dr("custaddress").ToString
        oSheet.Cells(7, 2).value = dr("custemail").ToString
        oSheet.Cells(8, 2).value = dr("custphone").ToString
        oSheet.Cells(8, 5).value = dr("quotedate").ToString
        oSheet.Cells(11 + l_item, 1).value = dr("itemnumber").ToString
        oSheet.Cells(11 + l_item, 2).value = dr("itemcode").ToString
        oSheet.Cells(11 + l_item, 3).value = dr("itemdescription").ToString
        oSheet.Cells(11 + l_item, 4).value = dr("unit").ToString
        oSheet.Cells(11 + l_item, 5).value = dr("matquantity")
        '  oSheet.Cells(11 + l_item, 6).value = dr("matcost")
        'oSheet.Cells(14 + l_item, 7).value = dr("laborcost")
        oSheet.Cells(11 + l_item, 6).value = dr("itemtotcost")
        tax_total = Val(dr("matquantity").ToString) * Val(dr("matcost").ToString) * 0.0825 + tax_total
        sub_total = (Val(dr("matcost").ToString) + Val(dr("laborcost").ToString)) * Val(dr("matquantity").ToString) + sub_total

        l_item = 1 + l_item
        While dr.Read()
            oSheet.Cells(11 + l_item, 1).value = dr("itemnumber").ToString
            oSheet.Cells(11 + l_item, 2).value = dr("itemcode").ToString
            oSheet.Cells(11 + l_item, 3).value = dr("itemdescription").ToString
            oSheet.Cells(11 + l_item, 4).value = dr("unit").ToString
            oSheet.Cells(11 + l_item, 5).value = dr("matquantity")
            oSheet.Cells(11 + l_item, 6).value = dr("matcost")
            'oSheet.Cells(14 + l_item, 7).value = dr("laborcost")
            oSheet.Cells(11 + l_item, 6).value = dr("itemtotcost")
            tax_total = Val(dr("totalmatcost").ToString) * 0.0825 + tax_total
            sub_total = dr("itemtotcost").ToString + sub_total
            l_item = 1 + l_item
        End While
        grand_total = tax_total + sub_total + grand_total
        'other formatting needed
        oSheet.Range("C11:C28").EntireColumn.WrapText = True
        oSheet.Range("B8").HorizontalAlignment = XlHAlign.xlHAlignLeft
        '  oSheet.Range("A10:G10").EntireColumn.Font.Bold = True
        'oSheet.Range("A1:A10").EntireColumn.AutoFit()
        oSheet.Range("D3:D11").EntireColumn.AutoFit()
        '   oSheet.Range("A13:A23").EntireColumn.AutoFit()
        oSheet.Range("B11:B23").EntireColumn.AutoFit()
        oSheet.Range("E3:E9").EntireColumn.AutoFit()
        oSheet.Range("F11:G25").EntireColumn.AutoFit()
        cn.Close()

        Call borderformat()
        oSheet.Cells(26, 5).value = "Sub Total: " : oSheet.Cells(26, 6).value = sub_total
        oSheet.Cells(27, 5).value = "Taxes Total: " : oSheet.Cells(27, 6).value = tax_total
        oSheet.Cells(28, 5).value = "Total:" : oSheet.Cells(28, 6).value = grand_total

        DisposeComObj(oSheet)
        DisposeComObj(oXL)
        'DisposeComObj(CustomerTableAdapter)
        DisposeComObj(oWB)
        ' objBook.Close(False)
    End Sub
    Sub borderformat()
        With oSheet.Range("A10:F10").Borders(XlBordersIndex.xlEdgeBottom)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThick
        End With
        With oSheet.Range("A10:F10").Borders(XlBordersIndex.xlEdgeTop)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThick
        End With
        With oSheet.Range("A10:A25").Borders(XlBordersIndex.xlEdgeLeft)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThick
        End With
        With oSheet.Range("F10:f25").Borders(XlBordersIndex.xlEdgeRight)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThick
        End With
        With oSheet.Range("A25: f25").Borders(XlBordersIndex.xlEdgeBottom)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThick
        End With

        With oSheet.Range("A10:f25").Borders(XlBordersIndex.xlInsideVertical)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThin
        End With
        With oSheet.Range("A4:F4").Borders(XlBordersIndex.xlEdgeTop)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThin
        End With
        With oSheet.Range("F4:F9").Borders(XlBordersIndex.xlEdgeRight)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThin
        End With
        oSheet.Application.ActiveWindow.DisplayGridlines = False
    End Sub
    Private Sub errmsg()
        MsgBox("A quote number has to be sellected!", vbOK)
    End Sub
    ' Remove seected row or multiple rows from the datagrid and from the databse
    Private Sub Del_Records_Click(sender As Object, e As EventArgs) Handles Del_Records.Click
        Dim rowtodelete, rowindex As Integer
        Dim msgresp, row_todelete As String
        rowtodelete = Me.Quot_Det_DG.Rows.GetFirstRow(DataGridViewElementStates.Selected)
        If rowtodelete > -1 Then Me.Quot_Det_DG.Rows.RemoveAt(rowtodelete)
        msgresp = MsgBox("Do you want to remove this record from the DataBASE table?", vbYesNo)
        If msgresp = vbYes Then
            Try
                Dim cm As New OleDbCommand
                Dim dr As OleDbDataReader
                rowindex = Quot_Det_DG.CurrentRow.Index
                row_todelete = Quot_Det_DG.Item(0, rowindex).Value
                cn.Open()
                With cm
                    .Connection = cn
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE ID from quotation where ID =  " & row_todelete & " "
                    .Parameters.AddWithValue("@row", 0)
                    cm.ExecuteNonQuery()
                    cn.Close()
                End With
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.OkOnly)
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub DisposeComObj(ByRef Reference As Object)
        Try
            Do Until _
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Reference) <= 0
            Loop
        Catch
        Finally
            Reference = Nothing
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub Create_quote_BTN_Click(sender As Object, e As EventArgs) Handles Create_quote_BTN.Click
        Form3.Show()
    End Sub

    'Delete selected records in a Quote_Det_DG
End Class