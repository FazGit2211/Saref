using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Dtos;
using Saref.Models.Stadium;
using Saref.Services.Tads;

namespace Saref.Services.StadiumServices
{
    public class StadiumService : IStadium
    {
        //Inyectar contexto de la base de datos
        private readonly ContextDB _contextDB;
        public StadiumService(ContextDB context)
        {
            _contextDB = context;
        }
        public async Task<Stadium> CreateNew(Stadium stadium)
        {
            try
            {
                if (stadium.Name.Trim() == "" || stadium.Address.Trim() == "")
                {
                    return null;
                }
                _contextDB.Stadiums.Add(stadium);
                await _contextDB.SaveChangesAsync();
                return stadium;
            }
            catch (System.Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<Stadium>> GetAllStadiums()
        {
            try
            {
                List<Stadium> list = await _contextDB.Stadiums.Include(sh => sh.Shifts).ToListAsync();

                //Declarar e instanciar grafo
                /*
                Grafo grafo = new Grafo(5);
                foreach (Stadium stadium in list)
                {
                    grafo.NewVertice(stadium);
                }
                Console.WriteLine("Numbers Vertices:" + grafo.NumVertices);
                Console.WriteLine("Vertices:" + grafo.Vertices[0].Stadium.ToString());
                Console.WriteLine("Vertices:" + grafo.Vertices[1].Stadium.ToString());
                Console.WriteLine("Vertices:" + grafo.Vertices[2].Stadium.ToString());
                grafo.NewArch(grafo.Vertices[0].NumVertice, grafo.Vertices[2].NumVertice);
                grafo.NewArch(grafo.Vertices[2].NumVertice, grafo.Vertices[2].NumVertice);
                grafo.NewArch(grafo.Vertices[0].NumVertice, grafo.Vertices[1].NumVertice);
                Console.WriteLine("Matriz Adyacencia:");
                for (int i = 0; i < Grafo.MaxVertices; i++)
                {
                    for (int j = 0; j < Grafo.MaxVertices; j++)
                    {
                        Console.WriteLine(grafo.MatrizAdyacencia[i, j]);
                    }
                }*/
                return list;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Stadium> GetStadiumById(int idStadium)
        {
            try
            {
                if (idStadium <= 0) { return null; }
                return await _contextDB.Stadiums.FindAsync(idStadium);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
