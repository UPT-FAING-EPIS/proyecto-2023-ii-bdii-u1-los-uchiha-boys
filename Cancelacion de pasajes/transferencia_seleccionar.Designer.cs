namespace Cancelacion_de_pasajes
{
    partial class transferencia_seleccionar
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvViajes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViajes
            // 
            this.dgvViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViajes.Location = new System.Drawing.Point(23, 26);
            this.dgvViajes.Name = "dgvViajes";
            this.dgvViajes.Size = new System.Drawing.Size(949, 367);
            this.dgvViajes.TabIndex = 3;
            this.dgvViajes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViajes_CellClick);
            // 
            // transferencia_seleccionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 458);
            this.Controls.Add(this.dgvViajes);
            this.Name = "transferencia_seleccionar";
            this.Text = "transferencia_seleccionar";
            this.Load += new System.EventHandler(this.transferencia_seleccionar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvViajes;
    }
}