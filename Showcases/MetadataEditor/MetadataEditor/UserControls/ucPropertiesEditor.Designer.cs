namespace MetadataEditor.UserControls
{
    partial class ucPropertiesEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridDocumentProperties = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBuiltInProperty = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDocumentProperties
            // 
            this.gridDocumentProperties.AllowUserToAddRows = false;
            this.gridDocumentProperties.AllowUserToDeleteRows = false;
            this.gridDocumentProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDocumentProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDocumentProperties.BackgroundColor = System.Drawing.Color.White;
            this.gridDocumentProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDocumentProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value,
            this.IsBuiltInProperty});
            this.gridDocumentProperties.Location = new System.Drawing.Point(0, 0);
            this.gridDocumentProperties.MultiSelect = false;
            this.gridDocumentProperties.Name = "gridDocumentProperties";
            this.gridDocumentProperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridDocumentProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDocumentProperties.Size = new System.Drawing.Size(415, 355);
            this.gridDocumentProperties.TabIndex = 1;
            // 
            // Property
            // 
            this.Property.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Property.DataPropertyName = "Name";
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // IsBuiltInProperty
            // 
            this.IsBuiltInProperty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IsBuiltInProperty.DataPropertyName = "IsBuiltIn";
            this.IsBuiltInProperty.HeaderText = "Built-in";
            this.IsBuiltInProperty.Name = "IsBuiltInProperty";
            this.IsBuiltInProperty.ReadOnly = true;
            this.IsBuiltInProperty.Width = 44;
            // 
            // ucPropertiesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gridDocumentProperties);
            this.Name = "ucPropertiesEditor";
            this.Size = new System.Drawing.Size(415, 355);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDocumentProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsBuiltInProperty;
    }
}
