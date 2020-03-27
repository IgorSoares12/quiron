using System;

namespace Quiron.Domain.Entities
{
    public class Espaco : Entity
    {
        public Espaco(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public string Descricao { get; set; }
    }
}