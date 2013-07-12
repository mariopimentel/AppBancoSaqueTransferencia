using FluentNHibernate.Mapping;
using Stingy.Dominio.Entidades;

namespace Stingy.Infra.Repositorio.FluentMapping
{
    public class ContaMap : ClassMap<Conta>
    {
        public ContaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().GeneratedBy.Assigned().GeneratedBy.Increment();

            Map(x => x.NumeroConta).Not.Nullable();
            Map(x => x.Agencia).Not.Nullable();
            Map(x => x.Saldo).Precision(10).Scale(2).Not.Nullable();  
        }
    }
}
