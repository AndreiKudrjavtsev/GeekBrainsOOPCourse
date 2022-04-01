namespace OOPInCsharp.Lesson1.Introduction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var car = new Car();
            //car._model = "Buggati";
            car.Model = "BuggatiBuggatiBuggatiBuggati";
            car.Model = "VW Polo";
            car.VIN = "1231dslfmkls34";

            car.StartEngine();
        }
    }

    class Car
    {
        // 1. Поля
        private string _model;

        // 2. Свойства
        public string Model 
        {
            get => _model; 
            set
            {
                if (!(value.Length > 0 && value.Length <= 20))
                {
                    throw new ArgumentException("Wrong value!!!");
                }

                _model = value;
            }
        }

        public string VIN { get; set; }

        // 3. Методы
        public void StartEngine()
        {

        }
    }
}