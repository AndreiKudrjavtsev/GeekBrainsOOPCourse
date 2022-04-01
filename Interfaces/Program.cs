IBar test1 = new TestClass();
test1.Test();

IFoo test2 = new TestClass();
test2.Test();

public interface IFoo
{
    public void Test();
    public int GetValue();
}

public interface IBar
{
    public void Test();
}

public abstract class Foo
{
    protected int _value;

    public int GetValue()
    {
        return _value;
    }
}

public abstract class Bar
{
    public abstract void Test();
}

public class TestClass : IFoo, IBar
{
    public int Value { get; set; } = 10;

    public int GetValue()
    {
        return Value;
    }

    void IBar.Test()
    {
        Console.WriteLine("Test IBar from class");
    }

    void IFoo.Test()
    {
        Console.WriteLine("Test IFoo from class");
    }
}