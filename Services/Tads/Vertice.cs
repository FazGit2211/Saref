using Saref.Models.Stadium;

namespace Saref.Services.Tads
{
    public class Vertice
    {
        public Stadium Stadium { get; set; }
        public int NumVertice { get; set; }
        public Vertice(Stadium stadium)
        {
            this.Stadium = stadium;
            this.NumVertice = -1;
        }
    }
}
