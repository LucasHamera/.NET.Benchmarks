using BenchmarkDotNet.Attributes;

namespace Benchmarks.NET.Interfaces.Console;

public class InterfacesBenchmark
{
    private IInterface _interface;
    private Implementation _implementation;

    [GlobalSetup]
    public void SetUp()
    {
        _implementation = new Implementation();
        _interface = _implementation;
    }

    [Benchmark]
    public void InterfaceCall()
    {
        _interface.Method();
    }

    [Benchmark]
    public void ImplementationCall()
    {
        _implementation.Method();
    }
}

internal interface IInterface
{
    void Method();
}

internal class Implementation: IInterface
{
    public void Method()
    {
    }
}