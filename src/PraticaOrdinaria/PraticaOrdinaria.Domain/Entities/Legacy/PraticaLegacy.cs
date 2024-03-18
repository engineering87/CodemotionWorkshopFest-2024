namespace PraticaOrdinaria.Domain.Entities.Legacy
{
    public class PraticaLegacy
    {
        public Guid P_GUID { get; set; }
        public string P_PTC { get; set; }
        public DateTime P_DATAINS { get; set; }
        public int P_TYPE { get; set; }
        public int P_PAG_TYPE { get; set; }
        public Guid BEN_GUID { get; set; }
        public TipoPagamento Pagamento { get; set; }
        
    }
}
