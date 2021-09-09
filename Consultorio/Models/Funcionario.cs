﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Funcionario
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um nome para o paciente!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe uma data de nascimento para o paciente!")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? Nascimento { get; set; }


        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

       
    }
}
