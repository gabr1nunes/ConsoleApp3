namespace Contas.LibClasses
{
    public class DadosCarteiras
    {
        public List<Carteira> ListaDados = new List<Carteira>();
        public DateTime DataDoSistema { get; set; } = DateTime.Now;

        public void CobrarContas()
        {
            foreach (var conta in ListaDados)
            {
                conta.CobrarTarifa();
            }
        }
    }
}












































//    {
//        public class DadosCarteiras
//        {
//            public List<Carteira> ListaDados = new List<Carteira>();
//            public DateTime DataDoSistema { get; set; } = DateTime.Now;

//            public void CobrarContas()
//            {
//                foreach (var conta in ListaDados)
//                {
//                    conta.CobrarTarifa();
//                }
//            }
//        }
//    }
//}



