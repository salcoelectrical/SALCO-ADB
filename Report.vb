Imports System.ComponentModel.Design
Imports System.Data.OleDb
Imports System.Diagnostics.Eventing.Reader
Imports System.Net.Sockets
Imports System.Windows.Forms.VisualStyles
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports testing_combobox.salco_partsDataSetTableAdapters

Public Class Report
    Dim cn As New OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
    Dim da As New OleDbDataAdapter
    Dim cm As New OleDb.OleDbCommand
    Dim ds As New DataSet
    Dim dr As OleDb.OleDbDataReader
    Dim cmq As New OleDbCommand
    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Dim oXL As Excel.Application
    Dim oWB As Excel.Workbook
    Dim oSheet As Excel.Worksheet
    Dim oRng As Excel.Range
    Dim xlVAlignCenter As IntegerProperty
    Dim validate As New DateTimeOffset


    Private Sub reportformat(ByVal tittle As String, ByVal reptype As String)
        oXL = CreateObject("Excel.Application")
        oXL.Visible = True
        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet

        ' formatting report
        oSheet.Cells(1, 1).value = tittle
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
        oSheet.Cells(2, 1).value = "Adress: 5310 Lotus Canyon Court Richmond TX 77407 "
        oSheet.Cells(3, 1).value = "Phone: 832-341-6395"
        oSheet.Cells(4, 1).value = "Bill To: "
        oSheet.Cells(5, 1).value = "Full Name: "
        oSheet.Cells(6, 1).value = "Address: "
        oSheet.Cells(7, 1).value = "Email: "
        oSheet.Cells(8, 1).value = "Phone N.: "
        oSheet.Cells(1, 4).value = reptype
        oSheet.Cells(6, 4).value = "Quote Date: "
        oSheet.Cells(3, 4).value = "Quotation Valid until: "
        oSheet.Cells(5, 4).value = "Prepared by: "
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
        ' Payment notes
        oSheet.Range("C11:C25").ColumnWidth = 70
        oSheet.Cells(30, 2).value = "Thank you for your business !"
        oSheet.Cells(31, 2).value = "Your Payment transaction can be done as follow:"
        oSheet.Cells(32, 2).value = "Zelle using Phone Number: 832-341-6395"
        oSheet.Cells(33, 2).value = "Apple Pay using the phone number: 832-341-6395"
        oSheet.Cells(34, 2).value = "By Check attention to: SALCO Electrical"
        oSheet.Cells(35, 2).value = "Or Cash."

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
        With oSheet.Range("F10:F25").Borders(XlBordersIndex.xlEdgeRight)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThick
        End With
        With oSheet.Range("A25: F25").Borders(XlBordersIndex.xlEdgeBottom)
            .LineStyle = XlLineStyle.xlContinuous
            .Weight = XlBorderWeight.xlThick
        End With

        With oSheet.Range("A10:F25").Borders(XlBordersIndex.xlInsideVertical)
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
        Call reportdata()
    End Sub

    Sub invoicereport()
    End Sub
    Sub reportdata()
        Dim tax_total, sub_total, grand_total As Double
        Dim l_item As Integer = 0
        Try
            With cmq
                cn.Open()
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "SELECT DISTINCT quotenumber,customer.custname, customer.custlastname, 
                customer.custaddress, customer.custphone, customer.custemail,
                itemnumber, quotedate, itemcode, itemdescription, unit, 
                matquantity, matcost, laborcost, totalmatcost,totalaborcost,
                itemtotcost, ctq.name, ctq.ID FROM 
                (quotation INNER JOIN customer ON quotation.custID = customer.cusID) 
                INNER JOIN ctq ON quotation.quotenumber = ctq.quotenum
                WHERE quotation.quotenumber =  '" & report_QN_CB.SelectedItem & "' "
                ' .CommandText = "SELECT DISTINCT * From ctq WHERE ctq.quotenum = '" & report_QN_CB.SelectedItem & "'"
                If report_QN_CB.SelectedItem = Nothing Then Call errmsg() : cn.Close() : Exit Sub

                dr = .ExecuteReader
                ' cn.Close()
            End With
            oSheet.Range("C11:C25").ColumnWidth = 70
            dr.Read()
            oSheet.Cells(1, 5).value = dr("quotenumber").ToString
            oSheet.Cells(5, 2).value = dr("custname").ToString & dr("custlastname").ToString
            oSheet.Cells(6, 2).value = dr("custaddress").ToString
            oSheet.Cells(7, 2).value = dr("custemail").ToString
            oSheet.Cells(8, 2).value = dr("custphone").ToString
            oSheet.Cells(6, 5).value = dr("quotedate").ToString
            oSheet.Cells(11 + l_item, 1).value = dr("itemnumber").ToString
            oSheet.Cells(11 + l_item, 2).value = dr("itemcode").ToString
            oSheet.Cells(11 + l_item, 3).value = dr("itemdescription").ToString
            oSheet.Cells(11 + l_item, 4).value = dr("unit").ToString
            oSheet.Cells(11 + l_item, 5).value = dr("matquantity")
            oSheet.Cells(5, 5).value = dr("name").ToString
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

            cn.Close()
            oSheet.Cells(26, 5).value = "Sub Total: " : oSheet.Cells(26, 6).value = sub_total
            oSheet.Cells(27, 5).value = "Taxes Total: " : oSheet.Cells(27, 6).value = tax_total
            oSheet.Cells(28, 5).value = "Total:" : oSheet.Cells(28, 6).value = grand_total
        Catch ex As Exception
            MsgBox(ex.Message, vbOK)
            cn.Close()
        End Try

    End Sub

    Private Sub inventory()
        MsgBox("Under Construction", Rep_sel_CKB.CheckedItems(0))
    End Sub
    Private Sub errmsg()
        MsgBox("A quote number has to be sellected!", vbOK)
    End Sub

    Sub RepCustSelection()
        Dim cm As New OleDb.OleDbCommand
        Dim da As New OleDbDataAdapter
        Dim dr As OleDbDataReader
        Cust_sel_Rep_CB.Items.Clear()
        With cm
            cn.Open()
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT custname FROM customer"
            da.SelectCommand = cm
            dr = .ExecuteReader
        End With
        While dr.Read()
            Cust_sel_Rep_CB.Items.Add(dr("Custname").ToString)
        End While
        cn.Close()
    End Sub
    Sub Repquoteselection(rep_cust)
        Dim cm As New OleDb.OleDbCommand
        report_QN_CB.Items.Clear()
        With cm
            cn.Open()
            .Connection = cn
            .CommandType = CommandType.Text
            If rep_cust <> "" Then
                .CommandText = "SELECT DISTINCT quotenumber FROM quotation INNER JOIN customer ON quotation.custID = customer.cusID  WHERE customer.custname =  '" & rep_cust & "' "
            Else
                .CommandText = "SELECT DISTINCT quotenumber FROM quotation INNER JOIN customer ON quotation.custID = customer.cusID  WHERE customer.custname =  '" & rep_cust & "' "
            End If
            ' da.SelectCommand = cm
            dr = .ExecuteReader
        End With
        While dr.Read()
            report_QN_CB.Items.Add(dr("quotenumber").ToString) 'papulate quotation number
        End While
        cn.Close()
    End Sub

    Private Sub CreSelRep_BTN_click(sender As Object, e As EventArgs) Handles CreSelRep_BTN.Click
        Try
            If Rep_sel_CKB.CheckedItems(0) = "Quotation Report" Then
                Call reportformat("SALCO Electrical Quote", "Quote No:")
            ElseIf Rep_sel_CKB.CheckedItems(0) = "Invoice Report" Then
                Call reportformat("SALCO Electrical Invoice", "Invoice No:")
            Else
                ' Call quotereport()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbOK)
            ' MsgBox("Report type has to be selected!", vbOK)
        End Try
    End Sub

    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call RepCustSelection()
    End Sub

    Private Sub Cust_sel_Rep_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cust_sel_Rep_CB.SelectedIndexChanged
        Call Repquoteselection(Cust_sel_Rep_CB.SelectedItem())
    End Sub

End Class