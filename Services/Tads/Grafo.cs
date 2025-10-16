using Saref.Models.Stadium;

namespace Saref.Services.Tads
{
    public class Grafo
    {
        public int NumVertices { get; set; }
        public static int MaxVertices = 5;
        public Vertice[] Vertices;
        public int[,] MatrizAdyacencia;
        public Grafo() { }
        public Grafo(int max)
        {
            MatrizAdyacencia = new int[max, max];
            Vertices = new Vertice[max];
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    MatrizAdyacencia[i, j] = 0;
                }
            }
            NumVertices = 0;
        }
        public void NewVertice(Stadium stadium)
        {
            try
            {
                //Verificar existencia en el array de vertices
                int verticeExist = VerticeExist(stadium.Name);
                //Si no existe se crea uno nuevo
                if (verticeExist == -1)
                {
                    Vertice vertice = new Vertice(stadium);
                    //Asignarle el número de vertice
                    vertice.NumVertice = NumVertices;
                    //Agregar al array de vertices
                    Vertices[NumVertices++] = vertice;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Método para verificar si ya existe en el array de vertices
        public int VerticeExist(string name)
        {
            try
            {
                int exist = -1;
                int i = 0;
                foreach (var vertice in Vertices)
                {
                    if (vertice.Stadium.Name.Equals(name))
                    {
                        exist = i;
                    }
                    i++;
                }
                return exist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }

        //Método para crear/verificar los arco y asignar/marcar a la matriz
        public bool NewArch(int numVertice1, int numVertice2)
        {
            try
            {
                bool ok = false;
                if (numVertice1 != -1 && numVertice2 != -1)
                {
                    MatrizAdyacencia[numVertice1, numVertice2] = 1;
                    ok = true;
                }
                return ok;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        //Método para verificar si un V1 con V2 son adyacentes
        public bool VerticeAdyacente(int numVertice1, int numVertice2)
        {
            try
            {
                if (numVertice1 != -1 && numVertice2 != -1)
                {
                    return MatrizAdyacencia[numVertice1, numVertice2] == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
