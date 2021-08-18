using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Loja_de_Instrumentos.Models
{
    public class Instrumento
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Tipo")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Marca")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Preço")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Link da imagem")]
        public string Link { get; set; }
        public List<Categoria> Categoria { get; set; }
    }
}
