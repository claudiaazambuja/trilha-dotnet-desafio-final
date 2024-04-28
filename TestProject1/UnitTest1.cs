using trilha_dotnet_desafiofinal;

namespace TestProject1;

public class UnitTest1
{

    public Calculadora construirClasse()
    {
        string data = "02/02/2020";
        Calculadora calc = new Calculadora(data);

        return calc;
    }

    [Fact]
    public void Test1()
    {
        Calculadora calc = construirClasse();

        int result = calc.teste(1, 2);
        Assert.Equal(0, result);
    }
    
    [Theory]
    [InlineData(1,2,0)]
    [InlineData(1,2,0)]
    public void Test2(int val1, int val2, int resultado)
    {
        
        Calculadora calc = construirClasse();

        int result = calc.teste(val1, val2);
        Assert.Equal(resultado, result);
    }
    
    [Theory]
    [InlineData(1,2,3)]
    [InlineData(1,7,8)]
    public void Test3(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();

        int result = calc.sum(val1, val2);
        Assert.Equal(resultado, result);
    }
    
    [Theory]
    [InlineData(1,2,-1)]
    [InlineData(1,7,-6)]
    public void Test4(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();

        int result = calc.sub(val1, val2);
        Assert.Equal(resultado, result);
    }
    
    [Theory]
    [InlineData(4,2,2)]
    [InlineData(14,7,2)]
    public void Test5(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();

        int result = calc.div(val1, val2);
        Assert.Equal(resultado, result);
    }
    
    
    [Theory]
    [InlineData(1,2,2)]
    [InlineData(1,7,7)]
    public void Test6(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();

        int result = calc.mult(val1, val2);
        Assert.Equal(resultado, result);
    }
    
    [Fact]
    public void DivisaoPorZero()
    {
        Calculadora calc = construirClasse();

        Assert.Throws<DivideByZeroException>(
            () => calc.div(1,0)
        );
    }
    
    [Fact]
    public void TesteHistorico()
    {
        Calculadora calc = construirClasse();
        calc.sum(1, 2);
        calc.teste(3, 5);
        calc.sum(1, 5);

        var lista = calc.historico("02/02/2020");

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count );
    }
   
}