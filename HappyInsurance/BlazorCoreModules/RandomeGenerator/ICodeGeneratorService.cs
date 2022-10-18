namespace HappyInsurance.BlazorCoreModules.RandomeGenerator;

public interface ICodeGeneratorService
{
    public string Generate(int length);
}