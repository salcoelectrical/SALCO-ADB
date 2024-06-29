<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.D_cusname_TX = New System.Windows.Forms.TextBox()
        Me.D_Q_Creator_TX = New System.Windows.Forms.TextBox()
        Me.D_Cus_Email_T = New System.Windows.Forms.TextBox()
        Me.D_Cus_Adress_TX = New System.Windows.Forms.TextBox()
        Me.D_Cus_Phone_TX = New System.Windows.Forms.TextBox()
        Me.D_Cus_Lasname_TX = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.D_Q_Number_TX = New System.Windows.Forms.TextBox()
        Me.D_Q_Date_TX = New System.Windows.Forms.TextBox()
        Me.D_Q_DG = New System.Windows.Forms.DataGridView()
        Me.Save_dup_quote_BT = New System.Windows.Forms.Button()
        Me.D_Q_Name = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.D_Q_Exit_BTN = New System.Windows.Forms.Button()
        CType(Me.D_Q_DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(251, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(279, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Information"
        '
        'D_cusname_TX
        '
        Me.D_cusname_TX.Location = New System.Drawing.Point(40, 120)
        Me.D_cusname_TX.Name = "D_cusname_TX"
        Me.D_cusname_TX.Size = New System.Drawing.Size(289, 22)
        Me.D_cusname_TX.TabIndex = 1
        '
        'D_Q_Creator_TX
        '
        Me.D_Q_Creator_TX.Location = New System.Drawing.Point(618, 193)
        Me.D_Q_Creator_TX.Name = "D_Q_Creator_TX"
        Me.D_Q_Creator_TX.Size = New System.Drawing.Size(295, 22)
        Me.D_Q_Creator_TX.TabIndex = 2
        '
        'D_Cus_Email_T
        '
        Me.D_Cus_Email_T.Location = New System.Drawing.Point(355, 193)
        Me.D_Cus_Email_T.Name = "D_Cus_Email_T"
        Me.D_Cus_Email_T.Size = New System.Drawing.Size(235, 22)
        Me.D_Cus_Email_T.TabIndex = 3
        '
        'D_Cus_Adress_TX
        '
        Me.D_Cus_Adress_TX.Location = New System.Drawing.Point(40, 193)
        Me.D_Cus_Adress_TX.Name = "D_Cus_Adress_TX"
        Me.D_Cus_Adress_TX.Size = New System.Drawing.Size(289, 22)
        Me.D_Cus_Adress_TX.TabIndex = 4
        '
        'D_Cus_Phone_TX
        '
        Me.D_Cus_Phone_TX.Location = New System.Drawing.Point(618, 120)
        Me.D_Cus_Phone_TX.Name = "D_Cus_Phone_TX"
        Me.D_Cus_Phone_TX.Size = New System.Drawing.Size(295, 22)
        Me.D_Cus_Phone_TX.TabIndex = 5
        '
        'D_Cus_Lasname_TX
        '
        Me.D_Cus_Lasname_TX.Location = New System.Drawing.Point(355, 120)
        Me.D_Cus_Lasname_TX.Name = "D_Cus_Lasname_TX"
        Me.D_Cus_Lasname_TX.Size = New System.Drawing.Size(235, 22)
        Me.D_Cus_Lasname_TX.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(615, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Quote Creator"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(352, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "E-Mail Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Full Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(615, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Phone Number"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(347, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Last Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1013, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Quote Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1013, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 17)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Quote Date"
        '
        'D_Q_Number_TX
        '
        Me.D_Q_Number_TX.Location = New System.Drawing.Point(1016, 164)
        Me.D_Q_Number_TX.Name = "D_Q_Number_TX"
        Me.D_Q_Number_TX.Size = New System.Drawing.Size(289, 22)
        Me.D_Q_Number_TX.TabIndex = 15
        '
        'D_Q_Date_TX
        '
        Me.D_Q_Date_TX.Location = New System.Drawing.Point(1016, 120)
        Me.D_Q_Date_TX.Name = "D_Q_Date_TX"
        Me.D_Q_Date_TX.Size = New System.Drawing.Size(295, 22)
        Me.D_Q_Date_TX.TabIndex = 16
        '
        'D_Q_DG
        '
        Me.D_Q_DG.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab
        Me.D_Q_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_Q_DG.Location = New System.Drawing.Point(31, 255)
        Me.D_Q_DG.Name = "D_Q_DG"
        Me.D_Q_DG.RowHeadersWidth = 51
        Me.D_Q_DG.RowTemplate.Height = 24
        Me.D_Q_DG.Size = New System.Drawing.Size(1388, 419)
        Me.D_Q_DG.TabIndex = 17
        '
        'Save_dup_quote_BT
        '
        Me.Save_dup_quote_BT.Location = New System.Drawing.Point(1016, 35)
        Me.Save_dup_quote_BT.Name = "Save_dup_quote_BT"
        Me.Save_dup_quote_BT.Size = New System.Drawing.Size(152, 42)
        Me.Save_dup_quote_BT.TabIndex = 18
        Me.Save_dup_quote_BT.Text = "Save Current Quote Details"
        Me.Save_dup_quote_BT.UseVisualStyleBackColor = True
        '
        'D_Q_Name
        '
        Me.D_Q_Name.Location = New System.Drawing.Point(1016, 212)
        Me.D_Q_Name.Name = "D_Q_Name"
        Me.D_Q_Name.Size = New System.Drawing.Size(289, 22)
        Me.D_Q_Name.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1013, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 17)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Quote Name"
        '
        'D_Q_Exit_BTN
        '
        Me.D_Q_Exit_BTN.Location = New System.Drawing.Point(1237, 35)
        Me.D_Q_Exit_BTN.Name = "D_Q_Exit_BTN"
        Me.D_Q_Exit_BTN.Size = New System.Drawing.Size(138, 42)
        Me.D_Q_Exit_BTN.TabIndex = 21
        Me.D_Q_Exit_BTN.Text = "&Exit"
        Me.D_Q_Exit_BTN.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1440, 674)
        Me.Controls.Add(Me.D_Q_Exit_BTN)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.D_Q_Name)
        Me.Controls.Add(Me.Save_dup_quote_BT)
        Me.Controls.Add(Me.D_Q_DG)
        Me.Controls.Add(Me.D_Q_Date_TX)
        Me.Controls.Add(Me.D_Q_Number_TX)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.D_Cus_Lasname_TX)
        Me.Controls.Add(Me.D_Cus_Phone_TX)
        Me.Controls.Add(Me.D_Cus_Adress_TX)
        Me.Controls.Add(Me.D_Cus_Email_T)
        Me.Controls.Add(Me.D_Q_Creator_TX)
        Me.Controls.Add(Me.D_cusname_TX)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.D_Q_DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents D_cusname_TX As TextBox
    Friend WithEvents D_Q_Creator_TX As TextBox
    Friend WithEvents D_Cus_Email_T As TextBox
    Friend WithEvents D_Cus_Adress_TX As TextBox
    Friend WithEvents D_Cus_Phone_TX As TextBox
    Friend WithEvents D_Cus_Lasname_TX As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents D_Q_Number_TX As TextBox
    Friend WithEvents D_Q_Date_TX As TextBox
    Friend WithEvents D_Q_DG As DataGridView
    Friend WithEvents Save_dup_quote_BT As Button
    Friend WithEvents D_Q_Name As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents D_Q_Exit_BTN As Button
End Class
