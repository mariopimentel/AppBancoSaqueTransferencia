using FluentNHibernate.Mapping;
using Stingy.Dominio.Entidades;

namespace Stingy.Infra.Repositorio.FluentMapping
{
    public class TransacoesMap : ClassMap<Transacoes>
    {
        public TransacoesMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().GeneratedBy.Assigned().GeneratedBy.Increment();

            Map(x => x.DataTransacao).Not.Nullable();
            Map(x => x.TipoTransacao).Not.Nullable();
            References(x => x.ContaOrigem).ForeignKey("FK_Conta_Origem");
            References(x => x.ContaDestino).ForeignKey("FK_Conta_Destino");
            Map(x => x.Valor).Precision(10).Scale(2).Not.Nullable();
        }
    }
}
