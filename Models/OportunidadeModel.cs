using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class OportunidadeModel
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NivelSurto { get; set; }
        public int QtdHoras { get; set; }
        public long QtdErros { get; set; }
        public long AprendizadoNivel { get; set; }
        public long HorasSono { get; set; }
        public int HorasFolga { get; set; }

        public OportunidadeModel() { }
    }
}
