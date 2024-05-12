namespace Projeto.Compras
{
    internal class ItemCompra
    {
        int Id;
        DateOnly DataCompra;
        string MateriaPrima;
        int Quantidade;
        int ValorUnitario;
        int TotalItem;

        public ItemCompra()
        {
        }
        public ItemCompra(int id, DateOnly dataCompra, string materiaPrima, int quantidade, int valorUnitario, int totalItem)
        {
            Id = id;
            DataCompra = dataCompra;
            MateriaPrima = materiaPrima;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalItem;
        }
        public int PegarId()
        {
            return Id;
        }
        public int PegarTotalItem()
        {
            return TotalItem;
        }
        public override string ToString()
        {
            return "Materia Prima - " + MateriaPrima + "\nQuantidade - " + Quantidade + "\nValor Unitário - " + ValorUnitario + "\nValor total do Item - " + TotalItem;
        }
        public string Formatar()
        {
            return Id.ToString("D5") + DataCompra.ToString("ddMMyyyy") + MateriaPrima + Quantidade.ToString("D5") + ValorUnitario.ToString("D5") + TotalItem.ToString("D6");
        }
    }
}
