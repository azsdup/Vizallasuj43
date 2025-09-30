namespace Vizallasuj2.Models
{
    public class Víz
    {
        public int id { get; set; }
        public DateTime Datum { get; set; }
        public int Vizallas { get; set; }
        public string Varos { get; set; } = string.Empty;
        public string Folyo { get; set; } = string.Empty;
    }
}
