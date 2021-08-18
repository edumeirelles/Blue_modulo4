using System.ComponentModel.DataAnnotations;


namespace Loja_de_Instrumentos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Categoria do Instrumento")]
        public string InstrumentoCategoria { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Instrumento")]
        public int InstrumentoId { get; set; }
        public Instrumento Instrumento { get; set; }

    }
}
