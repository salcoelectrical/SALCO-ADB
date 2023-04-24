Imports System.CodeDom
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Text
Imports System.Resources
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Office.Interop.Access
Imports Microsoft.Office.Interop.Access.Dao
Imports testing_combobox.salco_partsDataSetTableAdapters

Module modconnection
    Public dc As New OleDb.OleDbConnection
    Public cm As New OleDb.OleDbCommand
    Public dr As OleDbDataReader

End Module
Public Class Form2
    Dim selecteditem As Integer
    Dim selectedtext As String
    Dim quoindex As Integer = 0
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Salco_partsDataSet.items' table. You can move, or remove it, as needed.
        'Me.ItemsTableAdapter.Fill(Me.Salco_partsDataSet.items)
        Call Itemtype()

    End Sub

    Dim inum As Integer
    Private Sub Inserbutton_Click(sender As Object, e As EventArgs) Handles inserbutton.Click
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim da As New OleDbDataAdapter()
        Dim dt As New DataTable
        Dim slcom As New OleDbCommand("select * from salco_parts.items where itemdesc = '" & idescription.SelectedItem & "'", dc)
        da.SelectCommand = slcom
        da.Fill(dt)
        dc.Open()
        slcom.Prepare()
        Try
            'Me.cquotenum_tb.Text() = Today().ToShortDateString.Replace("/", "")
            itemsview_DG.Rows.Add(New String() {inum,
                              dt.Rows(0).Item(2).ToString,
                              dt.Rows(0).Item(3).ToString,
                              dt.Rows(0).Item(4).ToString,
                              "",
                              dt.Rows(0).Item(5).ToString,
                              "",
                              dt.Rows(0).Item(6).ToString,
                              "",
                              ""
                              })
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        inum = inum + 1
    End Sub

    Private Sub Prtype_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Prtype_CB.SelectedIndexChanged
        Call Prtype_CB_item()
    End Sub

    Private Sub idescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles idescription.SelectedIndexChanged
        selecteditem = idescription.SelectedIndex
        selectedtext = idescription.SelectedValue
    End Sub

    Private Sub Save_Button_Click(sender As Object, e As EventArgs) Handles Save_Button.Click
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim da As New OleDbDataAdapter()
        Dim rd As OleDbDataReader
        Dim row_count As Integer = itemsview_DG.Rows.Count
        Dim cm As New OleDb.OleDbCommand
        ' Dim quote_num_search As New OleDbCommand("SELECT quotenumber FROM quotation WHERE quotenumber =  '532023_2", dc)
        Dim meserr As String
        If cname_tb.Enabled = False Then meserr = "Customer Name cannot be blank" : Call suberror(meserr) : Exit Sub

        '  If quote_num_search.ToString() Is Nothing Then Call quote_update() : Exit Sub
        Try
            dc.Open()
            With cm
                .Connection = dc
                .CommandType = CommandType.Text
                .CommandText = "SELECT itemcode, quotenumber FROM quotation WHERE quotenumber = '" & cquotenum_tb.Text() & "'"
                rd = .ExecuteReader
            End With

            For Each rowitem As DataGridViewRow In itemsview_DG.Rows
                While rd.Read()
                    If rowitem.IsNewRow() = True Then Exit Sub
                    If rd("itemcode").ToString = rowitem.Cells(1).Value Then
                        Call quote_update()
                    Else
                        Call InsertData()
                    End If
                End While

                Call InsertData()
            Next
            rd.Close()
        Catch ex As Exception
            MsgBox(ex.Message & " Quotation has not been SAVED", MsgBoxStyle.Critical)

        End Try
    End Sub
    Private Sub InsertData()
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim da As New OleDbDataAdapter()
        Dim srd As OleDbDataReader
        Dim cm, scm As New OleDb.OleDbCommand
        Call Customer()
        Call Quotecreator(ccreated_tb.Text())
        Try
            dc.Open()
            With scm
                .Connection = dc
                .CommandType = CommandType.Text
                .CommandText = "SELECT quotenumber from quotation WHERE quotenumber = '" & cquotenum_tb.Text() & "'"
                srd = .ExecuteReader()
            End With

            If srd.Read() = True Then Exit Sub
            With cm
                .Connection = dc
                .CommandType = CommandType.Text

                For Each rowitem As DataGridViewRow In itemsview_DG.Rows
                    If rowitem.Cells(0).Value = Nothing Then Exit Try
                    .CommandText = "INSERT INTO quotation(itemnumber, quotedate, quotenumber, itemcode, itemdescription,
                                                          unit, matquantity, matcost, laborcost, discount, totalmatcost,
                                                          totalaborcost,quoationame, quocreaname, CustID,itemtotcost) 
                                    VALUES(@itemnumber, @quotedate, @quotenumber, @itemcode, @itemdescription, @unit, 
                                           @matquantity, @matcost, @laborcost, @discount, @totalmatcost,totalaborcost, 
                                           @quoationame, @quocreaname,@custID,@itemtotcost)"

                    ' .Parameters.Add(New System.Data.OleDb.OleDbParameter("@ID", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(0).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemnumber", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(0).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@quotedate", System.Data.OleDb.OleDbType.VarChar, 255, Qdate_TB.Text()))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@quotenumber", System.Data.OleDb.OleDbType.VarChar, 255, cquotenum_tb.Text()))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemcode", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(1).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemdescription", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(2).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(3).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@matquantity", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(4).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@matcost", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(5).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@laborcost", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(7).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@discount", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(10).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@totalmatcost", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(6).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@totalaborcost", System.Data.OleDb.OleDbType.VarChar, 255, rowitem.Cells(8).Value))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@quoationame", System.Data.OleDb.OleDbType.VarChar, 255, cquotenam_tb.Text()))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@quocreaname", System.Data.OleDb.OleDbType.VarChar, 255, ccreated_tb.Text()))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custID", System.Data.OleDb.OleDbType.VarChar, 255, cust_ID_TB.Text()))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemtotcost", System.Data.OleDb.OleDbType.VarChar, 255, (rowitem.Cells(9).Value)))
                    'cm.Parameters("@ID").Value = rowitem.Cells(0).Value
                    cm.Parameters("@itemnumber").Value = rowitem.Cells(0).Value
                    cm.Parameters("@quotedate").Value = Qdate_TB.Text()
                    cm.Parameters("@quotenumber").Value = cquotenum_tb.Text()
                    cm.Parameters("@itemcode").Value = rowitem.Cells(1).Value
                    cm.Parameters("@itemdescription").Value = rowitem.Cells(2).Value
                    cm.Parameters("@unit").Value = rowitem.Cells(3).Value
                    If rowitem.Cells(4).Value = "" Then
                        cm.Parameters("@matquantity").Value = 0
                    Else
                        cm.Parameters("@matquantity").Value = Val(rowitem.Cells(4).Value)
                    End If
                    cm.Parameters("@matcost").Value = Val(rowitem.Cells(5).Value)
                    cm.Parameters("@laborcost").Value = Val(rowitem.Cells(7).Value)
                    If rowitem.Cells(6).Value = Nothing Then
                        cm.Parameters("@totalmatcost").Value = 0
                    Else
                        cm.Parameters("@totalmatcost").Value = Val(rowitem.Cells(6).Value)
                    End If
                    cm.Parameters("@quoationame").Value = cquotenam_tb.Text()
                    If rowitem.Cells(10).Value = Nothing Then
                        cm.Parameters("@discount").Value = 0
                    Else
                        cm.Parameters("@discount").Value = rowitem.Cells(10).Value
                    End If
                    cm.Parameters("@quocreaname").Value = ccreated_tb.Text()
                    cm.Parameters("@custID").Value = cust_ID_TB.Text()

                    If rowitem.Cells(9).Value = Nothing Then
                        cm.Parameters("@itemtotcost").Value = 0
                    Else
                        cm.Parameters("@itemtotcost").Value = rowitem.Cells(9).Value
                    End If

                    cm.Parameters("@totalaborcost").Value = rowitem.Cells(8).Value
                    cm.ExecuteNonQuery()
                Next
            End With
            dc.Close()
            MsgBox("Quotation Saved", vbOK)


        Catch ex As Exception
            MsgBox(ex.Message & " Quotation has not been SAVED", MsgBoxStyle.Critical)

        End Try
        ' Call Customer()
        ' Call Quotecreator(ccreated_tb.Text())

    End Sub
    Sub Customer()
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim ccm As New OleDbCommand
        Dim cm As New OleDbCommand
        dc.Open()
        Try
            With cm
                .Connection = dc
                .CommandType = CommandType.Text
                .CommandText = "select * from customer where (cusID = '" & cust_ID_TB.Text() & "')"
                dr = .ExecuteReader
                While dr.Read()
                    Exit Sub
                End While
            End With
            With ccm
                .Connection = dc
                .CommandText = CommandType.Text
                .CommandText = "INSERT INTO customer(custname,custlastname,custaddress,custphone,custemail,custnote,cusID) 
                                VALUES(@custname,@custlastname,@custaddress,@custphone,@custemail,@custnote,@cusID)"
                '.Parameters.Add(New System.Data.OleDb.OleDbParameter("@index", System.Data.OleDb.OleDbType.VarChar, 255, cname_tb.Text + cphonen_search_tb.Text))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custname", System.Data.OleDb.OleDbType.VarChar, 255, cname_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custlastname", System.Data.OleDb.OleDbType.VarChar, 255, clnam_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custaddress", System.Data.OleDb.OleDbType.VarChar, 255, caddress_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custphone", System.Data.OleDb.OleDbType.VarChar, 255, cphonen_search_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custemail", System.Data.OleDb.OleDbType.VarChar, 255, cemail_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custnote", System.Data.OleDb.OleDbType.VarChar, 255, cquotenam_tb.Text()))
                '.Parameters.Add(New System.Data.OleDb.OleDbParameter("@custquotenumber", System.Data.OleDb.OleDbType.VarChar, 255, cquotenum_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@cusID", System.Data.OleDb.OleDbType.VarChar, 255, cust_ID_TB.Text()))

                'ccm.Parameters("@index").Value = cname_tb.Text + cphonen_search_tb.Text
                ccm.Parameters("@custname").Value = cname_tb.Text()
                ccm.Parameters("@custlastname").Value = clnam_tb.Text()
                ccm.Parameters("@custaddress").Value = caddress_tb.Text()
                ccm.Parameters("@custphone").Value = cphonen_search_tb.Text()
                ccm.Parameters("@custemail").Value = cemail_tb.Text()
                ccm.Parameters("@custnote").Value = cname_tb.Text()
                ccm.Parameters("@cusID").Value = cust_ID_TB.Text()

                ccm.ExecuteNonQuery()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            dc.Close()
            Exit Sub
        End Try
        dc.Close()
        dr.Close()
    End Sub

    Private Sub Quotecreator(ByVal creatorname)
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim cmc, ctc As New OleDbCommand

        dc.Open()
        With ctc
            .Connection = dc
            .CommandType = CommandType.Text
            .CommandText = "select * from ctq where (ID = '" & cquotenum_tb.Text() & ccreated_tb.Text() & "')"
            dr = .ExecuteReader
        End With
        While dr.Read()
            Exit Sub
        End While
        Try
            With cmc
                .Connection = dc
                .CommandText = CommandType.Text
                .CommandText = "INSERT INTO ctq(ID, name, quoteNum ) VALUES(@ID,@name,@quoteNum)"
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@ID", System.Data.OleDb.OleDbType.VarChar, 255, cquotenum_tb.Text() & ccreated_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@name", System.Data.OleDb.OleDbType.VarChar, 255, ccreated_tb.Text()))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@quoteNum", System.Data.OleDb.OleDbType.VarChar, 255, cquotenum_tb.Text()))
                .Parameters("@ID").Value = cquotenum_tb.Text() & ccreated_tb.Text()
                .Parameters("@name").Value = ccreated_tb.Text()
                .Parameters("@quoteNum").Value = cquotenum_tb.Text()
                .ExecuteNonQuery()
                dc.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            dc.Close()
            Exit Sub
        End Try
    End Sub
    Private Sub suberror(meserr)
        MsgBox(meserr, MsgBoxStyle.Critical)
    End Sub

    Sub Find_Cust_phone()
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        dc.Open()
        Dim found As Boolean
        Dim dr As OleDbDataReader
        Dim msganswer As String
        Try
            Dim cm = New OleDb.OleDbCommand
            With cm
                .Connection = dc
                .CommandType = CommandType.Text
                .CommandText = "select * from customer where (custphone = '" & cphonen_search_tb.Text() & "')"
                dr = .ExecuteReader()
            End With

            While dr.Read()
                cname_tb.Enabled = True
                clnam_tb.Enabled = True
                cphonen_search_tb.Enabled = True
                cquotenam_tb.Enabled = True
                cquotenum_tb.Enabled = True
                caddress_tb.Enabled = True
                cemail_tb.Enabled = True
                ccreated_tb.Enabled = True
                cname_tb.Text = dr("custname").ToString
                clnam_tb.Text = dr("custlastname").ToString
                caddress_tb.Text = dr("custaddress").ToString
                cemail_tb.Text = dr("custemail").ToString
                found = True

            End While
            dc.Close()
            If found = False Then msganswer = MsgBox("Customer not registered." & "Would you like to create a new Quote for This Customer? ", vbYesNo)
            dr.Close()
            If msganswer = vbYes Then
                Call Insert_customer()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Sub Insert_customer()
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        'dc.Open()
        Dim Quote_number As String

        Dim found As Boolean
        Dim da As New OleDbDataAdapter()
        Dim drcus As OleDbDataReader
        Dim cm = New OleDb.OleDbCommand
        Try
            dc.Open()
            Quote_number = Today().ToShortDateString.Replace("/", "").Replace(":", "") & "_" & quoindex
            With cm
                .Connection = dc
                .CommandType = CommandType.Text
                .CommandText = "select quotenumber from quotation where (quotenumber = '" & Quote_number & "')"
                drcus = .ExecuteReader
            End With
            While drcus.Read()
                quoindex += quoindex
                found = True
            End While
            cname_tb.Enabled = True
            clnam_tb.Enabled = True
            cphonen_search_tb.Enabled = True
            cquotenam_tb.Enabled = True
            cquotenum_tb.Enabled = True
            caddress_tb.Enabled = True
            cemail_tb.Enabled = True
            ccreated_tb.Enabled = True
            cquotenum_tb.Text() = Quote_number
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Sub quote_update()
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim da As New OleDbDataAdapter()
        Dim cm As New OleDb.OleDbCommand
        Dim meserr As String
        If cname_tb.Enabled = False Then meserr = "Customer Name cannot be blank" : Call suberror(meserr) : Exit Sub

        dc.Open()

        Try
            With cm
                .Connection = dc
                .CommandType = CommandType.Text
                For Each rowitem As DataGridViewRow In itemsview_DG.Rows
                    If rowitem.Cells(0).Value = Nothing Then Exit For
                    .CommandText = "UPDATE quotation SET itemnumber = @itemnumber, itemcode = @itemcode,
                                                        itemdescription = @itemdescription, unit = @unit,
                                                        matquantity = @matquantity, matcost = @matcost,
                                                        laborcost = @laborcost, discount = @discount,
                                                        quocreaname = @quocreaname 
                                    WHERE quotenumber = '" & cquotenum_tb.Text().ToString & "'" 'itemnumber = @itemnumber, itemcode = @itemcode, itemdescription = @itemdescription, unit = @unit, matquantity  = @matquantity, matcost = @matcost, laborcost = @laborcost, discount = @discount, quocreaname = @quocreaname WHERE quotenumber = '" & cquotenum_tb.Text().ToString & "'"
                    .Parameters.AddWithValue("itemnumber", rowitem.Cells(0).Value)
                    .Parameters.AddWithValue("itemcode", rowitem.Cells(1).Value)
                    .Parameters.AddWithValue("itemdescription", rowitem.Cells(2).Value)
                    .Parameters.AddWithValue("unit", rowitem.Cells(3).Value)
                    .Parameters.AddWithValue("matquantity", rowitem.Cells(4).Value)
                    .Parameters.AddWithValue("matcost", rowitem.Cells(5).Value)
                    .Parameters.AddWithValue("laborcost", rowitem.Cells(6).Value)
                    If rowitem.Cells(6).Value = Nothing Then
                        .Parameters.AddWithValue("discount", 0)
                    Else
                        .Parameters.AddWithValue("discount", rowitem.Cells(10).Value)
                    End If
                    .Parameters.AddWithValue("quocreaname", ccreated_tb.Text())

                    .Parameters.AddWithValue("ID", rowitem.Cells(0).Value)
                    cm.ExecuteNonQuery()
                Next
                dc.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            dc.Close()
        End Try
    End Sub

    Private Sub Itemsview_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles itemsview_DG.CellValueChanged
        Dim index As Integer
        Dim DataRow As New DataGridViewRow
        If DataRow.IsNewRow = True Then MsgBox("New Row detected", vbOK)
        Try
            index = e.RowIndex
            If index < 0 Then index = 0
            DataRow = itemsview_DG.Rows(index)
            DataRow.Cells(6).Value = DataRow.Cells(4).Value * DataRow.Cells(5).Value
            DataRow.Cells(8).Value = DataRow.Cells(4).Value * DataRow.Cells(7).Value
            DataRow.Cells(9).Value = DataRow.Cells(6).Value + DataRow.Cells(8).Value
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.ApplicationModal)

        End Try
    End Sub

    Private Sub Create_quote_btn_Click(sender As Object, e As EventArgs) Handles Create_quote_btn.Click
        Dim dc As New OleDbConnection("provider = microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim drcus As OleDbDataReader
        Dim cm = New OleDb.OleDbCommand
        Dim found As Boolean = True
        Dim quoindex As Integer = 0
        Dim quote_number As String = Today().ToShortDateString.Replace("/", "").Replace(":", "") & "_" & quoindex

        If cust_ID_TB.Text() = "" Then Me.cust_ID_TB.Text() = cname_tb.Text() + cphonen_search_tb.Text().Replace("-", "")
        If Qdate_TB.Text() = "" Then Qdate_TB.Text() = Today()

        Do While found = True
            With cm
                dc.Open()
                .Connection = dc
                .CommandType = CommandType.Text
                .CommandText = "SELECT quotenumber FROM quotation WHERE (quotenumber = '" & quote_number & "')"
                drcus = .ExecuteReader
                found = False
            End With
            If drcus.Read() = True Then

                quoindex = quoindex + 1
                quote_number = Today().ToShortDateString.Replace("/", "").Replace(":", "") & "_" & quoindex
                found = True

            End If

            cquotenum_tb.Text() = Today().ToShortDateString.Replace("/", "").Replace(":", "") & "_" & quoindex
            dc.Close()
        Loop
    End Sub

    Private Sub Find_cust_BT_Click(sender As Object, e As EventArgs) Handles Find_cust_BT.Click
        Call Find_Cust_phone()
    End Sub

    Private Sub RemoveRow_BT_Click(sender As Object, e As EventArgs) Handles RemoveRow_BT.Click
        Dim rowtodelete As Integer
        Dim rowNumb As Integer = 0
        rowtodelete = itemsview_DG.Rows.GetFirstRow(DataGridViewElementStates.Selected)
        If rowtodelete > -1 Then itemsview_DG.Rows.RemoveAt(rowtodelete)
        For Each rowitem As DataGridViewRow In itemsview_DG.Rows
            If rowitem.Cells(3).Value <> Nothing Then
                rowitem.Cells(0).Value = rowNumb
                rowNumb = rowNumb + 1
                inum = rowNumb
            End If
        Next
    End Sub

    Function DeleteRow(sel_row)
        Dim cn As New OleDbConnection("provider = microsoft.ace.oledb.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Try
            Dim cm As New OleDbCommand

            cn.Open()
            With cm
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "DELETE quotenumber from quotation where (quotenumber = '" & cquotenum_tb.Text() & "')"
                .Parameters.AddWithValue("@row", 0)
                cm.ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.OkOnly)
        End Try
    End Function

    Private Sub Upquote_Click(sender As Object, e As EventArgs) Handles upquote.Click
        Form1.Show()
    End Sub

    Private Sub quote_invoice_BTN_Click(sender As Object, e As EventArgs) Handles quote_invoice_BTN.Click
        Report.Show()
    End Sub

    Private Sub Prtype_CB_item()
        idescription.Items.Clear()
        Dim cn As New OleDbConnection("provider = microsoft.ace.oledb.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim itemreader As OleDbDataReader
        Dim itemdesc_da As New OleDbDataAdapter

        Dim itemdes_cm As New OleDbCommand
        With itemdes_cm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT itemdesc FROM salco_parts.items WHERE type = '" & Prtype_CB.SelectedItem.ToString & "' "
            cn.Open()
            itemreader = .ExecuteReader()
        End With

        While itemreader.Read()
            idescription.Items.Add(itemreader("itemdesc").ToString)
        End While
    End Sub

    Private Sub FillBy_distinct_typeToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.ItemsTableAdapter.FillBy_distinct_type(Me.Salco_partsDataSet1.items)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.ItemsTableAdapter.FillBy(Me.Salco_partsDataSet.items)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Itemtype()
        Dim cn As New OleDbConnection("provider = microsoft.ace.oledb.12.0;data source = C:\Users\Salvatore Colaiuda\OneDrive\Documents\SALCO\Visual Studio\testing combobox\salco_parts.mdb")
        Dim itemreader As OleDbDataReader
        Dim itemdesc_da As New OleDbDataAdapter
        Dim itemdesc_ds As New DataTable
        Dim itemcm As New OleDbCommand
        With itemcm
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT type FROM salco_parts.items"
            cn.Open()
            itemreader = .ExecuteReader()

        End With
        While itemreader.Read()
            Prtype_CB.Items.Add(itemreader("type").ToString)
        End While
        cn.Close()
    End Sub

    Private Sub Clearquote_BT_Click(sender As Object, e As EventArgs) Handles Clearquote_BT.Click
        caddress_tb.Clear()
        ccreated_tb.Clear()
        cemail_tb.Clear()
        clnam_tb.Clear()
        cname_tb.Clear()
        cphonen_search_tb.Clear()
        cquotenam_tb.Clear()
        cquotenum_tb.Clear()
        cphonen_search_tb.Clear()
        cquotenam_tb.Clear()
        cquotenum_tb.Clear()
    End Sub

    Private Sub BindingSource1_CurrentChanged(sender As Object, e As EventArgs) Handles BindingSource1.CurrentChanged

    End Sub
End Class