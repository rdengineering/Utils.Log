namespace Utils.Log
{
    partial class LogTable
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data_grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // data_grid
            // 
            this.data_grid.AllowUserToAddRows = false;
            this.data_grid.AllowUserToDeleteRows = false;
            this.data_grid.AllowUserToResizeColumns = false;
            this.data_grid.AllowUserToResizeRows = false;
            this.data_grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_grid.Location = new System.Drawing.Point(0, 0);
            this.data_grid.MultiSelect = false;
            this.data_grid.Name = "data_grid";
            this.data_grid.ReadOnly = true;
            this.data_grid.RowHeadersVisible = false;
            this.data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_grid.Size = new System.Drawing.Size(494, 376);
            this.data_grid.TabIndex = 0;
            // 
            // AlarmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.data_grid);
            this.Name = "AlarmTable";
            this.Size = new System.Drawing.Size(494, 376);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data_grid;
    }
}
