var animals = new List<Animal>()
{
    new Cat()
    {
        Name = "Barsik"
    },
    new Dog()
    {
        Name = "Sharik"
    }
};

var catFood = new AnimalFood() { Type = FoodType.CatFood, Brand = "Whiskas" };
foreach (var animal in animals)
{
    animal.Feed(catFood);
}

// + - * / | ^ & < > (!= == - также переопределяем Equals() & GetHashCode() )


#region Animal
public enum AnimalType
{
    Cat,
    Dog,
    Unknown,
    SuperAnimal
}

public class Animal
{
    public string Name { get; set; }
    public virtual AnimalType Type => AnimalType.Unknown;

    public virtual void Feed(AnimalFood food)
    {
        Console.WriteLine($"Trying to feed animal {Type} with food: {food.Type}");
    }

    public void Test() { }
    public void Test(int i) { }
}

public enum FoodType
{
    CatFood, 
    DogFood
}

public class AnimalFood
{
    public FoodType Type { get; set; }
    public string Brand { get; set; }
}

public class Cat : Animal
{
    public override AnimalType Type => AnimalType.Cat;

    public override void Feed(AnimalFood food)
    {
        base.Feed(food);

        if (food == null)
            return;

        if (food.Type == FoodType.DogFood)
        {
            Console.WriteLine("Wrong food type!");
        }

        if (food.Type == FoodType.CatFood)
        {
            Console.WriteLine("Your cat is happy!");
        }
    }
}

public class Dog : Animal
{
    public override AnimalType Type => AnimalType.Dog;

    public override void Feed(AnimalFood food)
    {
        base.Feed(food);

        if (food == null)
            return;

        if (food.Type == FoodType.CatFood)
        {
            Console.WriteLine("Wrong food type!");
        }

        if (food.Type == FoodType.DogFood)
        {
            Console.WriteLine("Your dog is happy!");
        }
    }
}
#endregion

class Result<T>
{
    public T Value { get; set; }
    public bool IsSuccessful { get; set; }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T> { Value = value, IsSuccessful = true };
    }

    public static explicit operator T(Result<T> result)
    {
        return result.Value;
    }
}