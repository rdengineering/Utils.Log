using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utils.Log
{
    public partial class LogTable : UserControl
    {
        private enum visible_column_index_t
        { 
            TIME = 0,
            MESSAGE,
        }
        
        private System.Windows.Forms.BindingSource table_log_binding;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_date_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_message;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_type;

        private void setup_table()
        {
            if (this.components == null)
                this.components = new Container();
            
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.table_log_binding = new System.Windows.Forms.BindingSource(this.components);
            this.column_date_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_log_binding)).BeginInit();
            this.SuspendLayout();
            // 
            // data_grid
            // 
            this.data_grid.AllowUserToAddRows = false;
            this.data_grid.AllowUserToDeleteRows = false;
            this.data_grid.AllowUserToResizeRows = false;
            this.data_grid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                                                                                this.column_date_time,
                                                                                                this.column_message,
                                                                                                this.column_type});
            this.data_grid.DataSource = this.table_log_binding;
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
            // column_date_time
            // 
            this.column_date_time.DataPropertyName = "date_time";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F/*12F*/, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "HH:MM:ss";
            dataGridViewCellStyle2.NullValue = null;
            this.column_date_time.DefaultCellStyle = dataGridViewCellStyle2;
            this.column_date_time.HeaderText = "Time";
            this.column_date_time.Name = "date_time";
            this.column_date_time.ReadOnly = true;
            this.column_date_time.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // column_message
            // 
            this.column_message.DataPropertyName = "message";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F/*12F*/, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            this.column_message.DefaultCellStyle = dataGridViewCellStyle3;
            this.column_message.HeaderText = "Message";
            this.column_message.Name = "message";
            this.column_message.ReadOnly = true;
            this.column_message.SortMode = DataGridViewColumnSortMode.NotSortable;
            //
            // column_type
            // 
            this.column_type.DataPropertyName = "type";
            this.column_type.HeaderText = "type";
            this.column_type.Name = "type";
            this.column_type.ReadOnly = true;
            this.column_type.Visible = false;
            // 
            // table_log_binding
            // 
            this.table_log_binding.DataMember = "table_log_t";
            this.table_log_binding.DataSource = log_manager.Instance.logDataSet;
            // 
            // LogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)(this.table_log_binding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            this.ResumeLayout(false);

            //this.data_grid.SortedColumn = this.column_date_time;
            //this.data_grid.SortOrder = SortOrder.Descending;
        }

        public LogTable()
        {
            InitializeComponent();

            setup_table();

            this.data_grid.RowPrePaint += data_grid_RowPrePaint;
            this.data_grid.SelectionChanged += data_grid_SelectionChanged;
        }

        public void Filter(Boolean alarm_visible, Boolean warning_visible, Boolean message_visible)
        {
            if (alarm_visible && warning_visible && message_visible)
                this.table_log_binding.Filter = "";
            else if (!alarm_visible && !warning_visible && !message_visible)
                this.table_log_binding.Filter = "type = 3";
            else
            {
                String filter_alarm = String.Empty;
                String filter_warning = String.Empty;
                String filter_message = String.Empty;

                Int32 or_count = Convert.ToInt32(alarm_visible) + Convert.ToInt32(warning_visible) + Convert.ToInt32(message_visible) - 1;

                filter_alarm = (alarm_visible ? "type = 2" : String.Empty);
                filter_warning = (warning_visible ? "type = 1" : String.Empty);
                filter_message = (message_visible ? "type = 0" : String.Empty);

                if ((filter_alarm != String.Empty) && (or_count > 0))
                {
                    --or_count;
                    filter_alarm += " OR ";
                }
                if ((filter_warning != String.Empty) && (or_count > 0))
                {
                    --or_count;
                    filter_warning += " OR ";
                }

                this.table_log_binding.Filter = filter_alarm + filter_warning + filter_message;
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            this.data_grid.RowPrePaint -= data_grid_RowPrePaint;
            this.data_grid.SelectionChanged -= data_grid_SelectionChanged;

            base.Dispose(disposing);
        }

        #region Events ------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void data_grid_SelectionChanged(object sender, EventArgs e)
        {
            this.data_grid.ClearSelection();
        }

        void data_grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color color_row = Color.White;

            switch ((log_manager.log_type_t)(Convert.ToByte(this.data_grid.Rows[e.RowIndex].Cells["type"].Value)))
            { 
                case log_manager.log_type_t.ERROR:
                    color_row = Color.OrangeRed;
                    break;

                case log_manager.log_type_t.WARNING:
                    color_row = Color.Yellow;
                    break;

                case log_manager.log_type_t.MESSAGE:
                    color_row = Color.White;
                    break;

                default:
                    break;
            }

            this.data_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = color_row;
        }

        /// <summary>
        /// Risposta all'evento di Resize del controllo. Viene mantenuta l'altezza per non deformare l'immagine
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            try
            {
                this.data_grid.Columns[Convert.ToInt32(visible_column_index_t.TIME)].Width = 80;
                this.data_grid.Columns[Convert.ToInt32(visible_column_index_t.MESSAGE)].Width = ( this.Size.Width - ( 20 + 80 ) );
            }
            catch (ArgumentOutOfRangeException) { }
        }

        #endregion

    }
}
