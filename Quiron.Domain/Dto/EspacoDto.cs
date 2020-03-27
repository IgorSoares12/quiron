using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiron.Domain.Dto
{
    [DisplayName("Espaco")]
    public class EspacoDto
    {
        public EspacoDto()
        {
            Id = Guid.NewGuid();
        }

        public EspacoDto(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Descricao' obrigatório.")]
        public string Descricao { get; set; }
    }
}