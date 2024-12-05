using OperacoesEmBits.Application.DTO;
using OperacoesEmBits.Domain.Model;
using System.Text;

namespace OperacoesEmBits.Application
{
    public class IngestaoDeBinarios
    {
        private readonly SequenciaDeBinariosModel _sequenciaBinarios;
        public IngestaoDeBinarios(IEnumerable<NumeroBinarioDto> binarios)
        {
            List<NumeroBinarioModel> numerosBinarios = new();
            StringBuilder sb = new();
            int counter = 0;
            
            foreach (NumeroBinarioDto binario in binarios)
            {
                try
                {
                    numerosBinarios.Add(new(binario.PrimeiroBit, binario.SegundoBit, binario.TerceiroBit, binario.QuartoBit, binario.QuintoBit));
                }
                catch(Exception ex)
                {
                    string msg = $"Erro no item {counter}: {ex.Message};";
                    sb.Append(msg);
                    //log error
                }
                finally
                {
                    counter++;
                }
            }
            if(numerosBinarios.Count != binarios.Count())
            {
                throw new ArgumentException(sb.ToString());
            }
            else
            {
                this._sequenciaBinarios = new(numerosBinarios);
            }
        }

        public int ObterEnergiaConsumidaNoSubmarino()
        {

            return _sequenciaBinarios.ConsumoDeEnergia;
        }
    }
}