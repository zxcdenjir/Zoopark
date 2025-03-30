class Program
{
    static void Main()
    {
        Zoo zoo = new();

        Animal animal1 = new Animal { Id = 0, Name = "Лев", Species = "Panthera leo", Age = 5, IsFed = false };
        zoo.Animals.Add(animal1);
        Animal animal2 = new Animal { Id = 1, Name = "Тигр", Species = "Panthera tigris", Age = 3, IsFed = false };
        zoo.Animals.Add(animal2);
        Animal animal3 = new Animal { Id = 2, Name = "Слон", Species = "Loxodonta africana", Age = 10, IsFed = false };
        zoo.Animals.Add(animal3);

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Вывести список животных");
            Console.WriteLine("2. Добавить животного");
            Console.WriteLine("3. Изменить данные животного");
            Console.WriteLine("4. Накормить животное");
            Console.WriteLine("5. Вывод информации о конкретном животном по id");
            Console.WriteLine("6. Выход");

            int choose;
            do
            {
                choose = IntInput("Выберите действие: ");
                if (choose < 1 || choose > 6)
                    Console.WriteLine("Ошибка");
            }
            while (choose < 1 || choose > 6);
            if (choose == 6)
                break;

            switch (choose)
            {
                case 1: // Вывести список животных
                    {
                        Console.WriteLine();
                        zoo.ListAllAnimals();
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 2: // Добавить животного
                    {
                        Console.WriteLine();
                        Animal animal = new();

                        animal.Id = zoo.Animals.Count;
                        animal.Name = StrInput("Введите имя животного: ");
                        animal.Species = StrInput("Введите вид животного: ");
                        animal.Age = IntInput("Введите возраст животного: ");
                        animal.IsFed = false;

                        zoo.Animals.Add(animal);
                        Console.WriteLine("Добавлено новое животное");

                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 3: // Изменить данные животного
                    {
                        Console.WriteLine();
                        int current_id = IntInput("Введите id животного, которого вы хотите изменить: ");
                        Animal animal = zoo.GetAnimalById(current_id);
                        if (animal == null)
                        {
                            Console.WriteLine("Ошибка");
                            break;
                        }

                        Console.WriteLine($"ID: {animal.Id}, Имя: {animal.Name}, Вид: {animal.Species}, Возраст: {animal.Age}, Накормлен: {(animal.IsFed ? "Да" : "Нет")}");

                        while (true)
                        {
                            Console.WriteLine("1. Изменить имя");
                            Console.WriteLine("2. Изменить вид");
                            Console.WriteLine("3. Изменить возраст");
                            Console.WriteLine("4. Выйти");
                            int choose2;
                            do
                            {
                                choose2 = IntInput("Выберите действие: ");
                                if (choose2 < 1 || choose2 > 4)
                                    Console.WriteLine("Ошибка");
                            }
                            while (choose2 < 1 || choose2 > 4);
                            if (choose2 == 4)
                                break;
                            switch (choose2)
                            {
                                case 1:
                                    {
                                        Console.WriteLine();
                                        animal.Name = StrInput("Введите новое имя животного: ");
                                        Console.WriteLine();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine();
                                        animal.Species = StrInput("Введите новый вид животного: ");
                                        Console.WriteLine();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine();
                                        animal.Age = IntInput("Введите новый возраст животного: ");
                                        Console.WriteLine();
                                        break;
                                    }
                            }
                        }
                        Console.WriteLine("Введите, что вы хотите изменить:");

                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear(); Console.WriteLine();
                        break;
                    }
                case 4: // Вывести всех животных
                    {
                        Console.WriteLine();
                        zoo.ListAllAnimals();
                        if (zoo.Animals.Count == 0)
                            break;
                        int animalId = IntInput("Введите id животного, которое хотите покормить: ");
                        zoo.FeedAnimal(animalId);
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                case 5: // Вывод информации о конкретном животном
                    {
                        Console.WriteLine();
                        int animalId = IntInput("Введите id животного: ");
                        Animal animal = zoo.GetAnimalById(animalId);
                        Console.WriteLine($"ID: {animal.Id}, Имя: {animal.Name}, Вид: {animal.Species}, Возраст: {animal.Age}, Накормлен: {(animal.IsFed ? "Да" : "Нет")}");
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
            }
        }
    }

    static int IntInput(string text)
    {
        int value;
        bool isCorrectnumber;

        do
        {
            Console.Write(text);
            isCorrectnumber = int.TryParse(Console.ReadLine(), out value);

            if (!isCorrectnumber)
                Console.WriteLine("Неверный формат ввода!");

        } while (!isCorrectnumber);

        return value;
    }
    static string StrInput(string text)
    {
        string value;
        bool isCorrectString;
        do
        {
            Console.Write(text);
            value = Console.ReadLine()!;
            isCorrectString = !string.IsNullOrWhiteSpace(value);
            if (!isCorrectString)
                Console.WriteLine("Название не может быть пустым!");
        } while (!isCorrectString);
        return value;
    }
}
