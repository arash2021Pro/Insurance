namespace HappyInsurance.BlazorCoreModules.RandomeGenerator;

public class CodeGenerator:ICodeGeneratorService
{
    public string Generate(int length)
    {
        var randome = new Random();
        var code = "";
        for (int i = 1; i <= length; i++)
        {
            code += randome.Next(1, 10);
        }
        return code;
    }
}