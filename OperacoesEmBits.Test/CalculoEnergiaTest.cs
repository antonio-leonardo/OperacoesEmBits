using OperacoesEmBits.Application;
using OperacoesEmBits.Application.DTO;
using OperacoesEmBits.Domain.Model;
using Xunit;

namespace OperacoesEmBits.Test;


public class CalculoEnergiaTest
{
    [Fact]
    public static void SimularTesteDeIntegracao()
    {
        string[] numerosBinariosStr = { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

        List<NumeroBinarioDto> numerosBinariosDto = new();
        foreach (string numeroBinarioStr in numerosBinariosStr)
        {
            try
            {
                numerosBinariosDto.Add(new NumeroBinarioDto(numeroBinarioStr));
            }
            catch
            {
                continue;
            }
        }

        Assert.Equal(numerosBinariosStr.Length, numerosBinariosDto.Count);

        if(numerosBinariosStr.Length == numerosBinariosDto.Count)
        {
            IngestaoDeBinarios ingestaoBinarios = new(numerosBinariosDto);
            int consumoDeEnergia = ingestaoBinarios.ObterEnergiaConsumidaNoSubmarino();

            List<NumeroBinarioModel> numerosBinariosModel = new();
            foreach (string numeroBinarioStr in numerosBinariosStr)
            {
                string[] bits = new string[numeroBinarioStr.Length];
                for (int i = 0; i < numeroBinarioStr.Length; i++)
                {
                    bits[i] = numeroBinarioStr[i].ToString();
                }
                try
                {
                    numerosBinariosModel.Add(new NumeroBinarioModel(bits));
                }
                catch
                {
                    continue;
                }
            }

            Assert.Equal(numerosBinariosStr.Length, numerosBinariosModel.Count);

            if (numerosBinariosStr.Length == numerosBinariosModel.Count)
            {
                SequenciaDeBinariosModel sequenciaDeBinarios = new(numerosBinariosModel);

                Assert.Equal(sequenciaDeBinarios.ConsumoDeEnergia, consumoDeEnergia);
            }
        }
    }

    [Theory]
    [InlineData("10110", "1", "0", "1", "1", "0")]
    [InlineData("11100", "1", "0", "1", "1", "0")]
    [InlineData("11200", "1", "1", "2", "0", "0")]
    [InlineData("A1001", "A", "1", "2", "0", "1")]
    [InlineData("0100B", "0", "1", "0", "0", "B")]
    [InlineData("010000", "0", "1", "0", "0", "0")]
    [InlineData("", "0", "1", "1", "0", "1")]
    [InlineData("", " ", "", " ", "", " ")]
    public static void TestarNumerosBinariosAplicacao(string numeroBinario, string primeiroBit, string segundoBit, string terceiroBit, string quartoBit, string quintoBit)
    {
        string bitsConcatenados = primeiroBit + segundoBit + terceiroBit + quartoBit + quartoBit;
        if (!string.IsNullOrWhiteSpace(numeroBinario) && numeroBinario == bitsConcatenados)
        {
            NumeroBinarioDto dto = null;
            try
            {
                dto = new(numeroBinario);
                Assert.Equal(primeiroBit, dto.PrimeiroBit);
                Assert.Equal(segundoBit, dto.SegundoBit);
                Assert.Equal(terceiroBit, dto.TerceiroBit);
                Assert.Equal(quartoBit, dto.QuartoBit);
                Assert.Equal(quintoBit, dto.QuintoBit);
            }
            catch
            {
                Func<NumeroBinarioDto> dto1 = () => new NumeroBinarioDto(numeroBinario);
                ArgumentException exception = Assert.Throws<ArgumentException>(dto1);
            }
            if (dto != null &&
                primeiroBit == dto.PrimeiroBit &&
                segundoBit == dto.SegundoBit &&
                terceiroBit == dto.TerceiroBit &&
                quartoBit == dto.QuartoBit &&
                quintoBit == dto.QuintoBit)
            {
                NumeroBinarioModel model = null;
                try
                {
                    model = new(new string[] { dto.PrimeiroBit, dto.SegundoBit, dto.TerceiroBit, dto.QuartoBit, dto.QuintoBit });
                    Assert.Equal(dto.PrimeiroBit, model.PrimeiroBit.ToString());
                    Assert.Equal(dto.SegundoBit, model.SegundoBit.ToString());
                    Assert.Equal(dto.TerceiroBit, model.TerceiroBit.ToString());
                    Assert.Equal(dto.QuartoBit, model.QuartoBit.ToString());
                    Assert.Equal(dto.QuintoBit, model.QuintoBit.ToString());
                }
                catch
                {
                    Func<NumeroBinarioModel> model1 = () => new NumeroBinarioModel(new string[] { dto.PrimeiroBit, dto.SegundoBit, dto.TerceiroBit, dto.QuartoBit, dto.QuintoBit });
                    ArgumentException exception = Assert.Throws<ArgumentException>(model1);
                }
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(numeroBinario))
            {
                Func<NumeroBinarioDto> dto1 = () => new NumeroBinarioDto(numeroBinario);
                ArgumentNullException exception = Assert.Throws<ArgumentNullException>(dto1);
            }
            if(numeroBinario != bitsConcatenados)
            {
                Assert.NotEqual(numeroBinario, bitsConcatenados);
            }
        }
    }
}