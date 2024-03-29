﻿using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Display (Name ="Id do TipoProduto")]
        [Required(ErrorMessage ="O Id é obrigatório")]
        public int IdTipoProduto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength (50,MinimumLength = 3, ErrorMessage ="O nome precisa estar entre 3 e 50 caracteres")]
        public string Nome { get; set; } = null!;
        public byte[]? Imagem { get; set; } = null!;
    }
}
