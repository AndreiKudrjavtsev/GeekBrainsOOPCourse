static void DoSomeWithRef(MyRefType refType)
{
    refType.A = 100;
}

static void DoSomeWithValue(MyValueType valueType)
{
    valueType.A = 100;
}

var refType = new MyRefType();
var valType = new MyValueType();

DoSomeWithRef(refType);
DoSomeWithValue(valType);
//Console.WriteLine(refType.A);
//Console.WriteLine(valType.A);

// ---------------------------------------


// ---------------------------------------


struct MyValueType
{
    public int A { get; set; }
}

class MyRefType
{
    public int A { get; set; }
}

