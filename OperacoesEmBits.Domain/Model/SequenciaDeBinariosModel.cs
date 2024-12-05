using OperacoesEmBits.Domain.Service;

namespace OperacoesEmBits.Domain.Model
{
    public class SequenciaDeBinariosModel
    {
        private readonly IEnumerable<NumeroBinarioModel> _binarios;

        public SequenciaDeBinariosModel(IEnumerable<NumeroBinarioModel> binarios)
        {
            if(binarios == null || binarios.Count() == 0)
            {
                throw new ArgumentNullException("sequenciaDeBinarios");
            }
            else
            {
                this._binarios = binarios;
            }
        }

        public int ConsumoDeEnergia { get { return this.TaxaGama * this.TaxaEpsilon; } }

        public int TaxaGama { get { return Convert.ToInt32(this.TaxaGamaBinario, 2); } }

        public int TaxaEpsilon { get { return Convert.ToInt32(this.TaxaEpsilonBinario, 2); } }

        private string TaxaGamaBinario
        {
            get
            {
                return new CalculoTaxaFactory(this._binarios, TaxaType.Gama).GerarBinario();
            }
        }

        private string TaxaEpsilonBinario
        {
            get
            {
                return new CalculoTaxaFactory(this._binarios, TaxaType.Epsilon).GerarBinario();
            }
        }
    }
}