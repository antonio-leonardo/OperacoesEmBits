using System.Text.RegularExpressions;

namespace OperacoesEmBits.Application.DTO
{
    public class NumeroBinarioDto
    {
        const string PATTERN = @"^[01]{5}$";
        public NumeroBinarioDto(string numeroBinario)
        {
            if (string.IsNullOrWhiteSpace(numeroBinario))
            {
                throw new ArgumentNullException("numeroBinario");
            }
            else if (!Regex.IsMatch(numeroBinario, PATTERN))
            {
                throw new ArgumentException("As informações emitidas no parâmetro não seguem os padrão de 5 digitos e/ou apenas '0' e '1' no corpo do texto");
            }
            else
            {
                this.PrimeiroBit = numeroBinario[0].ToString();
                this.SegundoBit  = numeroBinario[1].ToString();
                this.TerceiroBit = numeroBinario[2].ToString();
                this.QuartoBit   = numeroBinario[3].ToString();
                this.QuintoBit   = numeroBinario[4].ToString();
            }
        }

        public string PrimeiroBit { get; private set; }

        public string SegundoBit { get; private set; }

        public string TerceiroBit { get; private set; }

        public string QuartoBit { get; private set; }

        public string QuintoBit { get; private set; }
    }
}