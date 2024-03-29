﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Descripcion { get; set; }

        [Required]
        public bool EsCorrecta { get; set; }

        //Relacion foranea de preguntas a respuestas
        public int PreguntaId { get; set; }

        //Navegacion
        public Pregunta Pregunta { get; set; }
    }
}
