<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.customer_CB = New System.Windows.Forms.ComboBox()
        Me.Salco_partsDataSet1 = New testing_combobox.salco_partsDataSet()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Quot_Det_DG = New System.Windows.Forms.DataGridView()
        Me.subTotal_TB = New System.Windows.Forms.TextBox()
        Me.TaxesTotal_TB = New System.Windows.Forms.TextBox()
        Me.GrandTotal_TB = New System.Windows.Forms.TextBox()
        Me.Quot_desc_TB = New System.Windows.Forms.TextBox()
        Me.Quotenumber_CB = New System.Windows.Forms.ComboBox()
        Me.Create_quote_BTN = New System.Windows.Forms.Button()
        Me.CreatequoteBTN = New System.Windows.Forms.Button()
        Me.Up_Existing_quote_BTN = New System.Windows.Forms.Button()
        Me.Del_Records = New System.Windows.Forms.Button()
        Me.create_invoice_BTN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.Salco_partsDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Quot_Det_DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'customer_CB
        '
        Me.customer_CB.FormattingEnabled = True
        Me.customer_CB.Location = New System.Drawing.Point(149, 150)
        Me.customer_CB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.customer_CB.Name = "customer_CB"
        Me.customer_CB.Size = New System.Drawing.Size(160, 24)
        Me.customer_CB.TabIndex = 0
        '
        'Salco_partsDataSet1
        '
        Me.Salco_partsDataSet1.DataSetName = "salco_partsDataSet"
        Me.Salco_partsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = Me.Salco_partsDataSet1
        Me.BindingSource1.Position = 0
        '
        'Quot_Det_DG
        '
        Me.Quot_Det_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Quot_Det_DG.Location = New System.Drawing.Point(149, 207)
        Me.Quot_Det_DG.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Quot_Det_DG.Name = "Quot_Det_DG"
        Me.Quot_Det_DG.RowHeadersWidth = 51
        Me.Quot_Det_DG.Size = New System.Drawing.Size(1709, 449)
        Me.Quot_Det_DG.TabIndex = 1
        '
        'subTotal_TB
        '
        Me.subTotal_TB.Location = New System.Drawing.Point(1668, 82)
        Me.subTotal_TB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.subTotal_TB.Name = "subTotal_TB"
        Me.subTotal_TB.Size = New System.Drawing.Size(132, 22)
        Me.subTotal_TB.TabIndex = 2
        '
        'TaxesTotal_TB
        '
        Me.TaxesTotal_TB.Location = New System.Drawing.Point(1668, 114)
        Me.TaxesTotal_TB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TaxesTotal_TB.Name = "TaxesTotal_TB"
        Me.TaxesTotal_TB.Size = New System.Drawing.Size(132, 22)
        Me.TaxesTotal_TB.TabIndex = 3
        '
        'GrandTotal_TB
        '
        Me.GrandTotal_TB.Location = New System.Drawing.Point(1668, 146)
        Me.GrandTotal_TB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrandTotal_TB.Name = "GrandTotal_TB"
        Me.GrandTotal_TB.Size = New System.Drawing.Size(132, 22)
        Me.GrandTotal_TB.TabIndex = 4
        '
        'Quot_desc_TB
        '
        Me.Quot_desc_TB.Location = New System.Drawing.Point(756, 152)
        Me.Quot_desc_TB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Quot_desc_TB.Name = "Quot_desc_TB"
        Me.Quot_desc_TB.Size = New System.Drawing.Size(493, 22)
        Me.Quot_desc_TB.TabIndex = 5
        '
        'Quotenumber_CB
        '
        Me.Quotenumber_CB.FormattingEnabled = True
        Me.Quotenumber_CB.Location = New System.Drawing.Point(431, 150)
        Me.Quotenumber_CB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Quotenumber_CB.Name = "Quotenumber_CB"
        Me.Quotenumber_CB.Size = New System.Drawing.Size(160, 24)
        Me.Quotenumber_CB.TabIndex = 6
        '
        'Create_quote_BTN
        '
        Me.Create_quote_BTN.Location = New System.Drawing.Point(479, 700)
        Me.Create_quote_BTN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Create_quote_BTN.Name = "Create_quote_BTN"
        Me.Create_quote_BTN.Size = New System.Drawing.Size(112, 60)
        Me.Create_quote_BTN.TabIndex = 7
        Me.Create_quote_BTN.Text = "&Duplicate Quote"
        Me.Create_quote_BTN.UseVisualStyleBackColor = True
        '
        'CreatequoteBTN
        '
        Me.CreatequoteBTN.Location = New System.Drawing.Point(663, 700)
        Me.CreatequoteBTN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CreatequoteBTN.Name = "CreatequoteBTN"
        Me.CreatequoteBTN.Size = New System.Drawing.Size(100, 60)
        Me.CreatequoteBTN.TabIndex = 8
        Me.CreatequoteBTN.Text = "Create Quote"
        Me.CreatequoteBTN.UseVisualStyleBackColor = True
        '
        'Up_Existing_quote_BTN
        '
        Me.Up_Existing_quote_BTN.Location = New System.Drawing.Point(840, 700)
        Me.Up_Existing_quote_BTN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Up_Existing_quote_BTN.Name = "Up_Existing_quote_BTN"
        Me.Up_Existing_quote_BTN.Size = New System.Drawing.Size(120, 60)
        Me.Up_Existing_quote_BTN.TabIndex = 9
        Me.Up_Existing_quote_BTN.Text = "Update Existing Quote"
        Me.Up_Existing_quote_BTN.UseVisualStyleBackColor = True
        '
        'Del_Records
        '
        Me.Del_Records.Location = New System.Drawing.Point(1044, 700)
        Me.Del_Records.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Del_Records.Name = "Del_Records"
        Me.Del_Records.Size = New System.Drawing.Size(117, 60)
        Me.Del_Records.TabIndex = 10
        Me.Del_Records.Text = "Delete Line Items"
        Me.Del_Records.UseVisualStyleBackColor = True
        '
        'create_invoice_BTN
        '
        Me.create_invoice_BTN.Location = New System.Drawing.Point(1243, 700)
        Me.create_invoice_BTN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.create_invoice_BTN.Name = "create_invoice_BTN"
        Me.create_invoice_BTN.Size = New System.Drawing.Size(113, 60)
        Me.create_invoice_BTN.TabIndex = 11
        Me.create_invoice_BTN.Text = "Generate Invoice"
        Me.create_invoice_BTN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(146, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Customer Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(428, 130)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Quote Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(753, 130)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Quotation Descrition"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1589, 86)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Sub Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1576, 118)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Taxes Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1576, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Grand Totat"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1893, 1001)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.create_invoice_BTN)
        Me.Controls.Add(Me.Del_Records)
        Me.Controls.Add(Me.Up_Existing_quote_BTN)
        Me.Controls.Add(Me.CreatequoteBTN)
        Me.Controls.Add(Me.Create_quote_BTN)
        Me.Controls.Add(Me.Quotenumber_CB)
        Me.Controls.Add(Me.Quot_desc_TB)
        Me.Controls.Add(Me.GrandTotal_TB)
        Me.Controls.Add(Me.TaxesTotal_TB)
        Me.Controls.Add(Me.subTotal_TB)
        Me.Controls.Add(Me.Quot_Det_DG)
        Me.Controls.Add(Me.customer_CB)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Salco_partsDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Quot_Det_DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents customer_CB As ComboBox
    Friend WithEvents Salco_partsDataSet1 As salco_partsDataSet
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Quot_Det_DG As DataGridView
    Friend WithEvents subTotal_TB As TextBox
    Friend WithEvents TaxesTotal_TB As TextBox
    Friend WithEvents GrandTotal_TB As TextBox
    Friend WithEvents Quot_desc_TB As TextBox
    Friend WithEvents Quotenumber_CB As ComboBox
    Friend WithEvents Create_quote_BTN As Button
    Friend WithEvents CreatequoteBTN As Button
    Friend WithEvents Up_Existing_quote_BTN As Button
    Friend WithEvents Del_Records As Button
    Friend WithEvents create_invoice_BTN As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
