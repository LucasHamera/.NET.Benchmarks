using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.NET.Generics.Console;

public class GenericsBenchmark
{
    private IRunner _interface;
    private Runner _implementation;

    [GlobalSetup]
    public void SetUp()
    {
        _implementation = new Runner();
        _interface = _implementation;
    }

    [Benchmark]
    public void InterfaceCall()
    {
        _implementation.Run(_implementation);
    }

    [Benchmark]
    public void ImplementationCall()
    {
        _implementation.Run(_interface);
    }

    [Benchmark]
    public void NonGenericCall()
    {
        _implementation.Run();
    }
}

internal class Runner: IRunner
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Run<T>(T runner) where T : IRunner
    {
        runner.Run();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Run()
    {
    }
}

internal interface IRunner
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    void Run();
}