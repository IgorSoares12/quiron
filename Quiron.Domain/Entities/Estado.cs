using System;

namespace Quiron.Domain.Entities
{
    public class Estado : Entity
    {
        public Estado(string uf, string descricao)
        {
            Id = Guid.NewGuid();
            Uf = uf;
            Descricao = descricao;
        }

        public string Uf { get; set; }

        public string Descricao { get; set; }
    }
}