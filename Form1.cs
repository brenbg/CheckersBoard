using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckersBoard
{
    public partial class Form1 : Form
    {
        List<CellDetails> cells = new List<CellDetails>();
        const int cCellSize = 70;
        int boardLeft = 0;
        int boardTop = 0;
        int clickCount = 0;
        CellDetails inicio, fin;
        CellDetails cNull;
        int filaInicio, columnaInicio, filaFin, columnaFin;
        int auxtipo = 0, tipoInicio = 0, tipoFin = 0;

        TextureBrush cOscuro = new TextureBrush(Image.FromFile(@".\Imagenes\cC270.jpg"));
        TextureBrush cClaro = new TextureBrush(Image.FromFile(@".\Imagenes\cB70.jpg"));
        TextureBrush cFB = new TextureBrush(Image.FromFile(@".\Imagenes\cOFB70.png"));
        TextureBrush cFN = new TextureBrush(Image.FromFile(@".\Imagenes\cOFN70.png"));
        TextureBrush cRB = new TextureBrush(Image.FromFile(@".\Imagenes\cORB70.png"));
        TextureBrush cRN = new TextureBrush(Image.FromFile(@".\Imagenes\cORN70.png"));
        

        //int [,] tablero = new int[8,8];
        public Form1()
        {
            InitializeComponent();

            picTile.Size = new Size(cCellSize, cCellSize);

            //picBoard.MouseMove += PicBoard_MouseMove;
            picBoard.MouseClick += PicBoard_MouseClick;
            picBoard.Paint += PicBoard_Paint;
            CreateCells();

            boardLeft = picBoard.Location.X;
            boardTop = picBoard.Location.Y;
            cNull = new CellDetails();
            cNull.tipo = -3; //-3 indica que es null
            cNull.Dimension = new Rectangle();
            cNull.Location = new Point(-1,-1);
            cNull.ubicacion = -1;
        }
        private void PicBoard_Paint(object sender, PaintEventArgs e)
        {
            if (cells.Count > 0)
            {
                
                


                int fila = 0, columna = 0;

                for (int i = 0; i <= 63; i++)
                {
                    cells[i].Dimension.Height = 70;
                    cells[i].Dimension.Width = 70;
                    cells[i].ubicacion = i;
                    fila = i / 8;
                    columna = i % 8;

                    switch (tablero[columna, fila])
                    {
                        case -2:
                            e.Graphics.FillRectangle(cRN, cells[i].Dimension);
                            cells[i].tipo = -2;
                            cells[i].ubicacion = i;
                            break;
                        case -1:
                            e.Graphics.FillRectangle(cFN, cells[i].Dimension);
                            cells[i].tipo = -1;
                            break;
                        case 0:
                            e.Graphics.FillRectangle(cOscuro, cells[i].Dimension);
                            cells[i].tipo = 0;
                            break;
                        case 1:
                            e.Graphics.FillRectangle(cFB, cells[i].Dimension);
                            cells[i].tipo = 1;
                            break;
                        case 2:
                            e.Graphics.FillRectangle(cRB, cells[i].Dimension);
                            cells[i].tipo = 2;
                            break;
                        case 3:
                            e.Graphics.FillRectangle(cClaro, cells[i].Dimension);
                            cells[i].tipo = 3;
                            break;
                    }
                }
                /*cOscuro.Dispose();
                cClaro.Dispose();
                cFB.Dispose();
                cFN.Dispose();
                cRB.Dispose();
                cRN.Dispose();*/
            }
        }
        private void PicBoard_MouseClick(object sender, MouseEventArgs e)
        {
            clickCount++;
            CellDetails cell = FindCell(e);
            if (cell != null && cell.Location.X > -1 && cell.Location.Y > -1)
            {
                if (((((cell.ubicacion / 8) % 2) != 0) && ((cell.ubicacion % 8) % 2 == 0)) || (((cell.ubicacion / 8) % 2 == 0) && ((cell.ubicacion % 8) % 2 != 0)))
                {
                    if (clickCount % 2 != 0) //Primer clic del movimiento (elección de ficha a mover)
                    {
                        //picTile.Location = new Point(cell.Dimension.X + boardLeft, cell.Dimension.Y + boardTop);
                        //picTile.Visible = true;
                        inicio = cell;
                        //Console.WriteLine("Inicio " + inicio.Location.X + " " + inicio.Location.Y);
                    }
                    else //Segundo clic de movimiento (elección de a dónde se va a mover la ficha)
                    {
                        fin = cell;
                        //Console.Write("Fin " + fin.Location.X + " " + fin.Location.Y);

                        //encontrar posición en tablero
                        /*filaInicio = inicio.ubicacion / 8;
                        columnaInicio = inicio.ubicacion % 8;
                        filaFin = fin.ubicacion / 8;
                        columnaFin = fin.ubicacion % 28;*/
                        if (tablero[inicio.ubicacion % 8, inicio.ubicacion / 8] != 0 && tablero[fin.ubicacion % 8, fin.ubicacion / 8] == 0 && Math.Abs(distanciaX(inicio.ubicacion % 8, fin.ubicacion % 8)) == 1 && Math.Abs(distanciaY(inicio.ubicacion / 8, fin.ubicacion / 8)) == 1)
                        //if (tablero[columnaInicio, filaInicio] != 0 && tablero[columnaFin, filaFin] == 0 /*&& distancia(columnaInicio,filaInicio,columnaFin,filaFin) == 1*/)
                            {
                            //intercambia imgs
                            auxtipo = inicio.tipo;
                            inicio.tipo = fin.tipo;
                            fin.tipo = auxtipo;
                            tablero[inicio.ubicacion % 8, inicio.ubicacion / 8] = inicio.tipo;
                            tablero[fin.ubicacion % 8, fin.ubicacion / 8] = fin.tipo;
                            /*tablero[columnaInicio, filaInicio] = inicio.tipo;
                            tablero[columnaFin, filaFin] = fin.tipo;*/
                            Console.WriteLine("Tipo Inicio: " + inicio.tipo + "\nTipo fin: " + fin.tipo);

                            this.Refresh();
                        }
                        else
                        {
                            Console.WriteLine("Movimiento no válido");
                            MessageBox.Show("Movimiento no válido", "Error", MessageBoxButtons.OK);
                        }

                        /*Console.WriteLine("Nuevo tablero");
                        for (int m = 0; m < 8; m++)
                        {
                            for (int n = 0; n < 8; n++)
                            {
                                Console.Write(tablero[n, m]);
                            }
                            Console.WriteLine(" ");
                        }*/
                    }
                }

            }
            //else Console.WriteLine("Movimiento no válido");

        }
        /*    private void PicBoard_MouseMove(object sender, MouseEventArgs e)
            {
                CellDetails cell = FindCell(e);
                string details;

                if (cell == null || cell.Location.X < 0 || cell.Location.Y < 0)
                {
                    details = "Could not find cell";
                }
                else
                {
                    details = string.Format("Row: {0}, Col: {1}", cell.Location.Y, cell.Location.X);
                }
                lblDetails.Text = String.Format("{0}, {1} = {2}", e.X, e.Y, details);
            } */


        public void imprimeTablero()
        {
            Console.WriteLine("Nuevo tablero");
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    Console.Write(tablero[n, m]);
                }
                Console.WriteLine(" ");
            }
        }

        public int distanciaX(int xi, int xf)
        {
            return xf - xi;
        }

        public int distanciaY(int yi, int yf)
        {
            return yf - yi;
        }

        public int ocupado(int xi, int yi)
        {
            return tablero[xi, yi];
        }

        public Boolean desocupado(int xf, int yf)
        {
            return tablero[xf, yf] == 0;
        }
      
        private CellDetails FindCell(MouseEventArgs e)
        {
            CellDetails ret = null;
            foreach (CellDetails cell in cells)
            {
                if (cell.Dimension.Contains(e.Location))
                {
                    ret = cell;
                    break;
                }
            }
            return ret;
        }
        private void CreateCells()
        {
            CellDetails cell;
            Point cellLoc;
            //int rows = (picBoard.ClientSize.Height / cCellSize);
            //int cols = (picBoard.ClientSize.Width / cCellSize);
            int rows = 8, cols = 8, y = 0, x = 0;

            // Loop through the rows
            for (int row = 0; row < rows; row++)
            {
                // Loop through the columns
                for (int col = 0; col < cols; col++)
                {
                    cell = new CellDetails();
                    cellLoc = new Point();
                    x = col * cCellSize;
                    y = row * cCellSize;
                    //cellLoc.Y = row + 1;
                    //cellLoc.X = col + 1;
                    cellLoc.X = x;
                    cellLoc.Y = y;
                    cell.Location = cellLoc;
                    //cell.Dimension = new Rectangle(col * cCellSize, row * cCellSize, cCellSize, cCellSize);
                    cell.Dimension = new Rectangle(x, y, cCellSize, cCellSize);
                    cells.Add(cell);
                }
            }
            lblDetails.Text = String.Format("Generated {0} cells.", cells.Count);
        }
    }

    public class CellDetails
    {
        public CellDetails() { }
        public void imprimir()
        {
            Console.WriteLine( "--Información de celda\nTipo: " + this.tipo + "\nUbicación: " + this.ubicacion + "\nLocation: " + this.Location.ToString() + "\n--fin Información celda");
        }
        //public Rectangle Dimension { get; set; }        
        public Point Location { get; set; }
        public Rectangle Dimension = new Rectangle(0, 0, 70, 70);
        public int tipo, ubicacion;
        

        
    }

    
}
