namespace OperacoesEmBits.Domain.Model
{
    public class NumeroBinarioModel
    {
        public NumeroBinarioModel(params string[] bits)
        {
            if(bits == null)
            {
                throw new ArgumentNullException("bits");
            }
            else if (bits.Length != 5)
            {
                throw new ArgumentException("O argumento 'numerosBinarios' precisa conter 5 itens.");
            }
            else if(!bits.All(s => (new string[] { "0", "1" }).Contains(s)))
            {
                throw new ArgumentException("Os bits só podem conter '0' ou '1'.");
            }
            else
            {
                this.PrimeiroBit = int.Parse(bits[0].ToString());
                this.SegundoBit  = int.Parse(bits[1].ToString());
                this.TerceiroBit = int.Parse(bits[2].ToString());
                this.QuartoBit   = int.Parse(bits[3].ToString());
                this.QuintoBit   = int.Parse(bits[4].ToString());
            }
        }
        public int PrimeiroBit { get; private set; }

        public int SegundoBit { get; private set; }

        public int TerceiroBit { get; private set; }

        public int QuartoBit { get; private set; }

        public int QuintoBit { get; private set; }
    }
}