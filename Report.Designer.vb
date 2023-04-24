<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Rep_sel_CKB = New System.Windows.Forms.CheckedListBox()
        Me.Cust_sel_Rep_CB = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.report_QN_CB = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreSelRep_BTN = New System.Windows.Forms.Button()
        Me.ListofReport_TB = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ListofReport_TB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Rep_sel_CKB
        '
        Me.Rep_sel_CKB.FormattingEnabled = True
        Me.Rep_sel_CKB.Items.AddRange(New Object() {"Quotation Report", "Invoice Report", "Inventory Report"})
        Me.Rep_sel_CKB.Location = New System.Drawing.Point(29, 169)
        Me.Rep_sel_CKB.Name = "Rep_sel_CKB"
        Me.Rep_sel_CKB.Size = New System.Drawing.Size(215, 49)
        Me.Rep_sel_CKB.TabIndex = 2
        '
        'Cust_sel_Rep_CB
        '
        Me.Cust_sel_Rep_CB.FormattingEnabled = True
        Me.Cust_sel_Rep_CB.Location = New System.Drawing.Point(123, 266)
        Me.Cust_sel_Rep_CB.Name = "Cust_sel_Rep_CB"
        Me.Cust_sel_Rep_CB.Size = New System.Drawing.Size(121, 21)
        Me.Cust_sel_Rep_CB.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 274)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Customer"
        '
        'report_QN_CB
        '
        Me.report_QN_CB.FormattingEnabled = True
        Me.report_QN_CB.Location = New System.Drawing.Point(123, 299)
        Me.report_QN_CB.Name = "report_QN_CB"
        Me.report_QN_CB.Size = New System.Drawing.Size(121, 21)
        Me.report_QN_CB.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 299)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Quote Number"
        '
        'CreSelRep_BTN
        '
        Me.CreSelRep_BTN.Location = New System.Drawing.Point(54, 421)
        Me.CreSelRep_BTN.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CreSelRep_BTN.Name = "CreSelRep_BTN"
        Me.CreSelRep_BTN.Size = New System.Drawing.Size(132, 23)
        Me.CreSelRep_BTN.TabIndex = 7
        Me.CreSelRep_BTN.Text = "Create Selected Reports"
        Me.CreSelRep_BTN.UseVisualStyleBackColor = True
        '
        'ListofReport_TB
        '
        Me.ListofReport_TB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListofReport_TB.Location = New System.Drawing.Point(273, 169)
        Me.ListofReport_TB.Name = "ListofReport_TB"
        Me.ListofReport_TB.Size = New System.Drawing.Size(377, 170)
        Me.ListofReport_TB.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(269, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Reports Found"
        '
        'Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 709)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListofReport_TB)
        Me.Controls.Add(Me.CreSelRep_BTN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.report_QN_CB)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cust_sel_Rep_CB)
        Me.Controls.Add(Me.Rep_sel_CKB)
        Me.Name = "Report"
        Me.Text = "Report"
        CType(Me.ListofReport_TB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Rep_sel_CKB As CheckedListBox
    Friend WithEvents Cust_sel_Rep_CB As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents report_QN_CB As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CreSelRep_BTN As Button
    Friend WithEvents ListofReport_TB As DataGridView
    Friend WithEvents Label3 As Label
End Class
