public class Zoo
{
    public List<Animal> Animals { get; set; } = new List<Animal>();

    public void AddAnimal(Animal animal)
    { 
        Animals.Add(animal);
        Console.WriteLine($"Добавлено новое животное: {animal}.");
    }

    public void FeedAnimal(int animalId)
    {
        try
        {
            Animals[animalId].IsFed = true;
            Console.WriteLine($"Животное с id {animalId} было накормлено: {Animals[animalId].Name}.");
        }
        catch
        {
            Console.WriteLine($"Не удалось накормить животное c id {animalId}. Животное с таким ID не найдено.");
        }
    }

    public void UpdateAnimal(int animalId, Animal updatedAnimal)
    {
        try
        {
            Animals[animalId] = updatedAnimal;
            Console.WriteLine($"Животное с id {animalId} было обновлено на: {updatedAnimal}.");
        }
        catch
        {
            Console.WriteLine($"Не удалось обновить животное c id {animalId}. Животное с таким ID не найдено.");
        }
    }

    public void ListAllAnimals()
    {
        if (Animals.Count == 0)
            Console.WriteLine("Список животных пуст.");
        else
        {
            Console.WriteLine("Список всех животных в зоопарке:");
            foreach (Animal animal in Animals)
            {
                Console.WriteLine($"ID: {animal.Id}, Имя: {animal.Name}, Вид: {animal.Species}, Возраст: {animal.Age}, Накормлен: {(animal.IsFed ? "Да" : "Нет")}");
            }
        }
    }

    public Animal GetAnimalById(int animalId)
    {
        try
        {
            Animal animal = Animals[animalId];
            return animal;
        }
        catch
        {
            Console.WriteLine($"Не удалось получить информацию животное c id {animalId}. Животное с таким ID не найдено.");
            return null;
        }
    }
}
