namespace dahinh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int animalId = random.Next(0, 4);
            Console.WriteLine("Random ID: " + animalId);
            Animal animal = GetAnimal(animalId);
            animal.Move();
        }
        static Animal GetAnimal(int id)
        {
            switch (id)
            {
                case 0:
                    return new Dog();
                case 1:
                    return new Bird();
                default:
                    return new Fish();
            }
        }
    }
}
