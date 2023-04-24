<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.idescription = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.itemsview_DG = New System.Windows.Forms.DataGridView()
        Me.inserbutton = New System.Windows.Forms.Button()
        Me.custname = New System.Windows.Forms.Label()
        Me.custlastname = New System.Windows.Forms.Label()
        Me.custphonen = New System.Windows.Forms.Label()
        Me.custadress = New System.Windows.Forms.Label()
        Me.custemail = New System.Windows.Forms.Label()
        Me.cphonen_search_tb = New System.Windows.Forms.TextBox()
        Me.caddress_tb = New System.Windows.Forms.TextBox()
        Me.clnam_tb = New System.Windows.Forms.TextBox()
        Me.cname_tb = New System.Windows.Forms.TextBox()
        Me.cemail_tb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cquotenam_tb = New System.Windows.Forms.TextBox()
        Me.ccreated_tb = New System.Windows.Forms.TextBox()
        Me.Save_Button = New System.Windows.Forms.Button()
        Me.upquote = New System.Windows.Forms.Button()
        Me.Clearquote_BT = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cquotenum_tb = New System.Windows.Forms.TextBox()
        Me.RemoveRow_BT = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Prtype_CB = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.quote_invoice_BTN = New System.Windows.Forms.Button()
        Me.Create_quote_btn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cust_ID_TB = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Qdate_TB = New System.Windows.Forms.TextBox()
        Me.Find_cust_BT = New System.Windows.Forms.Button()
        Me.Salco_partsDataSet2 = New testing_combobox.salco_partsDataSet()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Iunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iquant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalmatcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laborcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalaborcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qdiscaunt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.itemsview_DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Salco_partsDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'idescription
        '
        resources.ApplyResources(Me.idescription, "idescription")
        Me.idescription.FormattingEnabled = True
        Me.idescription.Name = "idescription"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'itemsview_DG
        '
        resources.ApplyResources(Me.itemsview_DG, "itemsview_DG")
        Me.itemsview_DG.AllowUserToOrderColumns = True
        Me.itemsview_DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.itemsview_DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.itemsview_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.itemsview_DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemN, Me.itemcode, Me.idesc, Me.Iunit, Me.iquant, Me.mcost, Me.totalmatcost, Me.laborcost, Me.totalaborcost, Me.tcost, Me.qdiscaunt})
        Me.itemsview_DG.Name = "itemsview_DG"
        Me.itemsview_DG.RowTemplate.Height = 28
        '
        'inserbutton
        '
        resources.ApplyResources(Me.inserbutton, "inserbutton")
        Me.inserbutton.BackColor = System.Drawing.Color.Green
        Me.inserbutton.Name = "inserbutton"
        Me.inserbutton.UseVisualStyleBackColor = False
        '
        'custname
        '
        resources.ApplyResources(Me.custname, "custname")
        Me.custname.Name = "custname"
        '
        'custlastname
        '
        resources.ApplyResources(Me.custlastname, "custlastname")
        Me.custlastname.Name = "custlastname"
        '
        'custphonen
        '
        resources.ApplyResources(Me.custphonen, "custphonen")
        Me.custphonen.Name = "custphonen"
        '
        'custadress
        '
        resources.ApplyResources(Me.custadress, "custadress")
        Me.custadress.Name = "custadress"
        '
        'custemail
        '
        resources.ApplyResources(Me.custemail, "custemail")
        Me.custemail.Name = "custemail"
        '
        'cphonen_search_tb
        '
        resources.ApplyResources(Me.cphonen_search_tb, "cphonen_search_tb")
        Me.cphonen_search_tb.Name = "cphonen_search_tb"
        '
        'caddress_tb
        '
        resources.ApplyResources(Me.caddress_tb, "caddress_tb")
        Me.caddress_tb.Name = "caddress_tb"
        '
        'clnam_tb
        '
        resources.ApplyResources(Me.clnam_tb, "clnam_tb")
        Me.clnam_tb.Name = "clnam_tb"
        '
        'cname_tb
        '
        resources.ApplyResources(Me.cname_tb, "cname_tb")
        Me.cname_tb.Name = "cname_tb"
        '
        'cemail_tb
        '
        resources.ApplyResources(Me.cemail_tb, "cemail_tb")
        Me.cemail_tb.Name = "cemail_tb"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cquotenam_tb
        '
        resources.ApplyResources(Me.cquotenam_tb, "cquotenam_tb")
        Me.cquotenam_tb.Name = "cquotenam_tb"
        '
        'ccreated_tb
        '
        resources.ApplyResources(Me.ccreated_tb, "ccreated_tb")
        Me.ccreated_tb.Name = "ccreated_tb"
        '
        'Save_Button
        '
        resources.ApplyResources(Me.Save_Button, "Save_Button")
        Me.Save_Button.Name = "Save_Button"
        Me.Save_Button.UseVisualStyleBackColor = True
        '
        'upquote
        '
        resources.ApplyResources(Me.upquote, "upquote")
        Me.upquote.Name = "upquote"
        Me.upquote.UseVisualStyleBackColor = True
        '
        'Clearquote_BT
        '
        resources.ApplyResources(Me.Clearquote_BT, "Clearquote_BT")
        Me.Clearquote_BT.Name = "Clearquote_BT"
        Me.Clearquote_BT.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'cquotenum_tb
        '
        resources.ApplyResources(Me.cquotenum_tb, "cquotenum_tb")
        Me.cquotenum_tb.BackColor = System.Drawing.Color.PaleTurquoise
        Me.cquotenum_tb.Name = "cquotenum_tb"
        Me.cquotenum_tb.ReadOnly = True
        '
        'RemoveRow_BT
        '
        resources.ApplyResources(Me.RemoveRow_BT, "RemoveRow_BT")
        Me.RemoveRow_BT.Name = "RemoveRow_BT"
        Me.RemoveRow_BT.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Prtype_CB)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.idescription)
        Me.GroupBox1.Controls.Add(Me.inserbutton)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Prtype_CB
        '
        resources.ApplyResources(Me.Prtype_CB, "Prtype_CB")
        Me.Prtype_CB.FormattingEnabled = True
        Me.Prtype_CB.Name = "Prtype_CB"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.quote_invoice_BTN)
        Me.GroupBox2.Controls.Add(Me.Create_quote_btn)
        Me.GroupBox2.Controls.Add(Me.Save_Button)
        Me.GroupBox2.Controls.Add(Me.upquote)
        Me.GroupBox2.Controls.Add(Me.Clearquote_BT)
        Me.GroupBox2.Controls.Add(Me.RemoveRow_BT)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'quote_invoice_BTN
        '
        resources.ApplyResources(Me.quote_invoice_BTN, "quote_invoice_BTN")
        Me.quote_invoice_BTN.Name = "quote_invoice_BTN"
        Me.quote_invoice_BTN.UseVisualStyleBackColor = True
        '
        'Create_quote_btn
        '
        resources.ApplyResources(Me.Create_quote_btn, "Create_quote_btn")
        Me.Create_quote_btn.Name = "Create_quote_btn"
        Me.Create_quote_btn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cust_ID_TB
        '
        resources.ApplyResources(Me.cust_ID_TB, "cust_ID_TB")
        Me.cust_ID_TB.Name = "cust_ID_TB"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Qdate_TB
        '
        resources.ApplyResources(Me.Qdate_TB, "Qdate_TB")
        Me.Qdate_TB.Name = "Qdate_TB"
        '
        'Find_cust_BT
        '
        resources.ApplyResources(Me.Find_cust_BT, "Find_cust_BT")
        Me.Find_cust_BT.Name = "Find_cust_BT"
        Me.Find_cust_BT.UseVisualStyleBackColor = True
        '
        'Salco_partsDataSet2
        '
        Me.Salco_partsDataSet2.DataSetName = "salco_partsDataSet"
        Me.Salco_partsDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingSource1
        '
        '
        'ItemN
        '
        Me.ItemN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ItemN.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.ItemN, "ItemN")
        Me.ItemN.Name = "ItemN"
        '
        'itemcode
        '
        resources.ApplyResources(Me.itemcode, "itemcode")
        Me.itemcode.Name = "itemcode"
        '
        'idesc
        '
        Me.idesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        resources.ApplyResources(Me.idesc, "idesc")
        Me.idesc.Name = "idesc"
        '
        'Iunit
        '
        resources.ApplyResources(Me.Iunit, "Iunit")
        Me.Iunit.Name = "Iunit"
        '
        'iquant
        '
        resources.ApplyResources(Me.iquant, "iquant")
        Me.iquant.Name = "iquant"
        '
        'mcost
        '
        resources.ApplyResources(Me.mcost, "mcost")
        Me.mcost.Name = "mcost"
        '
        'totalmatcost
        '
        resources.ApplyResources(Me.totalmatcost, "totalmatcost")
        Me.totalmatcost.Name = "totalmatcost"
        '
        'laborcost
        '
        resources.ApplyResources(Me.laborcost, "laborcost")
        Me.laborcost.Name = "laborcost"
        '
        'totalaborcost
        '
        resources.ApplyResources(Me.totalaborcost, "totalaborcost")
        Me.totalaborcost.Name = "totalaborcost"
        '
        'tcost
        '
        resources.ApplyResources(Me.tcost, "tcost")
        Me.tcost.Name = "tcost"
        '
        'qdiscaunt
        '
        resources.ApplyResources(Me.qdiscaunt, "qdiscaunt")
        Me.qdiscaunt.Name = "qdiscaunt"
        '
        'Form2
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Find_cust_BT)
        Me.Controls.Add(Me.Qdate_TB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cust_ID_TB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cquotenum_tb)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ccreated_tb)
        Me.Controls.Add(Me.cquotenam_tb)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cemail_tb)
        Me.Controls.Add(Me.cname_tb)
        Me.Controls.Add(Me.clnam_tb)
        Me.Controls.Add(Me.caddress_tb)
        Me.Controls.Add(Me.cphonen_search_tb)
        Me.Controls.Add(Me.custemail)
        Me.Controls.Add(Me.custadress)
        Me.Controls.Add(Me.custphonen)
        Me.Controls.Add(Me.custlastname)
        Me.Controls.Add(Me.custname)
        Me.Controls.Add(Me.itemsview_DG)
        Me.KeyPreview = True
        Me.Name = "Form2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.itemsview_DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Salco_partsDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents idescription As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents itemsview_DG As DataGridView
    Friend WithEvents inserbutton As Button
    Friend WithEvents custname As Label
    Friend WithEvents custlastname As Label
    Friend WithEvents custphonen As Label
    Friend WithEvents custadress As Label
    Friend WithEvents custemail As Label
    Friend WithEvents cphonen_search_tb As TextBox
    Friend WithEvents caddress_tb As TextBox
    Friend WithEvents clnam_tb As TextBox
    Friend WithEvents cname_tb As TextBox
    Friend WithEvents cemail_tb As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cquotenam_tb As TextBox
    Friend WithEvents ccreated_tb As TextBox
    Friend WithEvents Save_Button As Button
    Friend WithEvents upquote As Button
    Friend WithEvents Clearquote_BT As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cquotenum_tb As TextBox
    Friend WithEvents RemoveRow_BT As Button
    Friend WithEvents Salco_partsDataSet1 As salco_partsDataSet
    Friend WithEvents QuotationTableAdapter1 As salco_partsDataSetTableAdapters.quotationTableAdapter
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Create_quote_btn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cust_ID_TB As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Qdate_TB As TextBox
    Friend WithEvents Salco_partsDataSet As salco_partsDataSet
    Friend WithEvents ItemsTableAdapter As salco_partsDataSetTableAdapters.itemsTableAdapter
    Friend WithEvents Find_cust_BT As Button
    Friend WithEvents quote_invoice_BTN As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Prtype_CB As ComboBox
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Salco_partsDataSet2 As testing_combobox.salco_partsDataSet
    Friend WithEvents ItemN As DataGridViewTextBoxColumn
    Friend WithEvents itemcode As DataGridViewTextBoxColumn
    Friend WithEvents idesc As DataGridViewTextBoxColumn
    Friend WithEvents Iunit As DataGridViewTextBoxColumn
    Friend WithEvents iquant As DataGridViewTextBoxColumn
    Friend WithEvents mcost As DataGridViewTextBoxColumn
    Friend WithEvents totalmatcost As DataGridViewTextBoxColumn
    Friend WithEvents laborcost As DataGridViewTextBoxColumn
    Friend WithEvents totalaborcost As DataGridViewTextBoxColumn
    Friend WithEvents tcost As DataGridViewTextBoxColumn
    Friend WithEvents qdiscaunt As DataGridViewTextBoxColumn
End Class
