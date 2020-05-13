using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace pulsacionesdotnet.Models
{
     public class PersonaInputModel
        {
            [Required(ErrorMessage = "La identificacion es requerida")]
            public string Identificacion { get; set; }
            [Required (ErrorMessage= "El nombre es requerido")]
            public string Nombre { get; set; }
            [Range (1, 99, ErrorMessage ="La edad debe estar en un rango entre 1 y 99")]
            public int Edad { get; set; }
            [SexoValidacion(ErrorMessage ="El sexo debe ser F o M")]
            public string Sexo { get; set; }
        }

        public class SexoValidacion : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if  ((value.ToString().ToUpper() == "M") || (value.ToString().ToUpper() =="F"))
                {
                    return ValidationResult.Success;
                }else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

        }

        public class PersonaViewModel : PersonaInputModel
        {
            public PersonaViewModel()
            {

            }
            public PersonaViewModel(Persona persona)
            {
                Identificacion = persona.Identificacion;
                Nombre = persona.Nombre;
                Edad = persona.Edad;
                Sexo = persona.Sexo;
                Pulsacion = persona.Pulsacion;
            }
            public decimal Pulsacion { get; set; }

        }
}