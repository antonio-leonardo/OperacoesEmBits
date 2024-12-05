using OperacoesEmBits.Domain.Model;
using System.Text;

namespace OperacoesEmBits.Domain.Service
{
    public enum TaxaType
    {
        Gama,
        Epsilon
    }

    public class CalculoTaxaFactory
    {
        private readonly TaxaType _taxaType;

        private readonly IEnumerable<NumeroBinarioModel> _binarios;

        public CalculoTaxaFactory(IEnumerable<NumeroBinarioModel> binarios, TaxaType taxaType)
        {
            if (binarios == null || binarios.Count() == 0)
            {
                throw new ArgumentNullException("sequenciaDeBinarios");
            }
            else
            {
                this._binarios = binarios;
            }
            this._taxaType = taxaType;
        }

        public string GerarBinario()
        {
            string primeiroFator = "", segundoFator = "";
            switch (this._taxaType)
            {
                case TaxaType.Gama:
                    primeiroFator = "0";
                    segundoFator  = "1";
                    break;
                case TaxaType.Epsilon:
                    primeiroFator = "1";
                    segundoFator = "0";
                    break;
            }
            StringBuilder sb = new();

            var primeiroBitGroup = this._binarios.GroupBy(x => x.PrimeiroBit);
            var segundoBitGroup = this._binarios.GroupBy(x => x.SegundoBit);
            var terceiroBitGroup = this._binarios.GroupBy(x => x.TerceiroBit);
            var quartoBitGroup = this._binarios.GroupBy(x => x.QuartoBit);
            var quintoBitGroup = this._binarios.GroupBy(x => x.QuintoBit);

            if (primeiroBitGroup.Where(x => x.Key == 0).Count() > primeiroBitGroup.Where(x => x.Key == 1).Count())
            {
                sb.Append(primeiroFator);
            }
            else
            {
                sb.Append(segundoFator);
            }
            if (segundoBitGroup.Where(x => x.Key == 0).Count() > segundoBitGroup.Where(x => x.Key == 1).Count())
            {
                sb.Append(primeiroFator);
            }
            else
            {
                sb.Append(segundoFator);
            }
            if (terceiroBitGroup.Where(x => x.Key == 0).Count() > terceiroBitGroup.Where(x => x.Key == 1).Count())
            {
                sb.Append(primeiroFator);
            }
            else
            {
                sb.Append(segundoFator);
            }
            if (quartoBitGroup.Where(x => x.Key == 0).Count() > quartoBitGroup.Where(x => x.Key == 1).Count())
            {
                sb.Append(primeiroFator);
            }
            else
            {
                sb.Append(segundoFator);
            }
            if (quintoBitGroup.Where(x => x.Key == 0).Count() > quintoBitGroup.Where(x => x.Key == 1).Count())
            {
                sb.Append(primeiroFator);
            }
            else
            {
                sb.Append(segundoFator);
            }

            return sb.ToString();
        }
    }
}