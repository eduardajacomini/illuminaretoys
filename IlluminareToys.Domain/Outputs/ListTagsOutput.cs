﻿using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Domain.Outputs
{
    public class ListTagsOutput : BaseOutput
    {
        public ListTagsOutput(List<ValidationFailure> errors = null) : base(errors) { }

        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime UpdatedAt { get; set; }
    }
}
