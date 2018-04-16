namespace CheckersBoard
{
    partial class Form1
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

        //#region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>

        private void InitializeComponent()
        {
            this.tablero = new int[8, 8];
            for (int m = 0; m < 8; m++)
                for (int n = 0; n < 8; n++)
                {
                    if (m % 2 == 0)  //fila par empieza con claro
                    {
                        if (n % 2 == 1) //en fila par las columnas impares tiene fichas
                        {
                            if (m < 3)
                                tablero[n, m] = -1;
                            else if (m > 4)
                                tablero[n, m] = 1;
                        }
                        else
                        {
                            tablero[n,m] = 3;
                        }
                    }
                    else //fila impar
                    {
                        if (n % 2 == 0) //en fila impar las columnas pares tienen fichas
                        {
                            if (m < 3)
                                tablero[n, m] = -1;
                            else if (m > 4)
                                tablero[n, m] = 1;
                        }
                        else
                        {
                            tablero[n,m]= 3;
                        }
                    }
                }

            //tablero[0,0] = 0;
            //tablero[0, 1] = -2;

            System.Console.WriteLine("Tablero inicial");
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    System.Console.Write(tablero[n, m]);
                }
                System.Console.WriteLine(" ");
            }
        
                    

            this.picBoard = new System.Windows.Forms.PictureBox();
            this.picTile = new System.Windows.Forms.PictureBox();
            this.lblDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoard
            // 
            this.picBoard.Location = new System.Drawing.Point(16, 26);
            this.picBoard.Margin = new System.Windows.Forms.Padding(4);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(560, 560);
            this.picBoard.TabIndex = 0;
            this.picBoard.TabStop = false;
            // 
            // picTile
            // 
            this.picTile.BackColor = System.Drawing.Color.Blue;
            this.picTile.Location = new System.Drawing.Point(191, 82);
            this.picTile.Margin = new System.Windows.Forms.Padding(4);
            this.picTile.Name = "picTile";
            this.picTile.Size = new System.Drawing.Size(68, 63);
            this.picTile.TabIndex = 1;
            this.picTile.TabStop = false;
            this.picTile.Visible = false;
            // 
            // lblDetails
            // 
            this.lblDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDetails.Location = new System.Drawing.Point(0, 608);
            this.lblDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(725, 28);
            this.lblDetails.TabIndex = 2;
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 636);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.picTile);
            this.Controls.Add(this.picBoard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid Test";
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).EndInit();
            this.ResumeLayout(false);

        }
        //#endregion
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.PictureBox picTile;
        private int[,] tablero;
    }
}

