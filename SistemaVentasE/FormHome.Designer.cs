
namespace SistemaVentasE
{
    partial class FormHome
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnMarca = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnOrden = new System.Windows.Forms.Button();
            this.panelTopMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelTopMenu.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnUser);
            this.panelMenu.Controls.Add(this.btnMarca);
            this.panelMenu.Controls.Add(this.btnProducto);
            this.panelMenu.Controls.Add(this.btnOrden);
            this.panelMenu.Controls.Add(this.panelTopMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 521);
            this.panelMenu.TabIndex = 0;
            // 
            // btnUser
            // 
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = global::SistemaVentasE.Properties.Resources.group1;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(0, 280);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(220, 60);
            this.btnUser.TabIndex = 5;
            this.btnUser.Text = "Usuario";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMarca.FlatAppearance.BorderSize = 0;
            this.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarca.ForeColor = System.Drawing.Color.White;
            this.btnMarca.Image = global::SistemaVentasE.Properties.Resources.marca;
            this.btnMarca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarca.Location = new System.Drawing.Point(0, 220);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(220, 60);
            this.btnMarca.TabIndex = 4;
            this.btnMarca.Text = "Marca";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducto.FlatAppearance.BorderSize = 0;
            this.btnProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducto.ForeColor = System.Drawing.Color.White;
            this.btnProducto.Image = global::SistemaVentasE.Properties.Resources.producto;
            this.btnProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducto.Location = new System.Drawing.Point(0, 160);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(220, 60);
            this.btnProducto.TabIndex = 3;
            this.btnProducto.Text = "Producto";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnOrden
            // 
            this.btnOrden.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrden.FlatAppearance.BorderSize = 0;
            this.btnOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrden.ForeColor = System.Drawing.Color.White;
            this.btnOrden.Image = global::SistemaVentasE.Properties.Resources.ordenCompra;
            this.btnOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrden.Location = new System.Drawing.Point(0, 100);
            this.btnOrden.Name = "btnOrden";
            this.btnOrden.Size = new System.Drawing.Size(220, 60);
            this.btnOrden.TabIndex = 2;
            this.btnOrden.Text = "   Orden Compra";
            this.btnOrden.UseVisualStyleBackColor = true;
            this.btnOrden.Click += new System.EventHandler(this.btnOrden_Click);
            // 
            // panelTopMenu
            // 
            this.panelTopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(60)))));
            this.panelTopMenu.Controls.Add(this.label1);
            this.panelTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopMenu.Location = new System.Drawing.Point(0, 0);
            this.panelTopMenu.Name = "panelTopMenu";
            this.panelTopMenu.Size = new System.Drawing.Size(220, 100);
            this.panelTopMenu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "S. Ventas";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Orange;
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(220, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(841, 100);
            this.panelTop.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(766, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 100);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(242, 31);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(352, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Bienvenido al Sistema";
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 100);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(841, 421);
            this.panelContent.TabIndex = 2;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 521);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.Name = "FormHome";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panelTopMenu.ResumeLayout(false);
            this.panelTopMenu.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTopMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOrden;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button btnUser;
    }
}

