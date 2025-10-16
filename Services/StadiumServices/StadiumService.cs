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
                if (stadium.Name.Equals(null) || stadium.Address.Equals(null))
                {
                    throw new Exception("Error valores no validos");
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
                List<Stadium> list = await _contextDB.Stadiums.ToListAsync();

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

        public async Task<DtoStadium> GetStadiumById(int id)
        {
            try
            {
                var list = from shift in _contextDB.Shifts where shift.StadiumId.Equals(id) select shift;
                DtoStadium dtoStadium = new DtoStadium();
                foreach (var shift in list)
                {
                    DtoShift dtoShift = new DtoShift();
                    dtoShift.Id = shift.Id;
                    dtoShift.Day = shift.Day;
                    dtoShift.Time = shift.Time;
                    dtoShift.Price = shift.Price;
                    dtoStadium.shifts.Add(dtoShift);
                }
                return dtoStadium;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
