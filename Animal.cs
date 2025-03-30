public class Animal
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public int Age { get; set; }
    public bool IsFed { get; set; }

    //public override string ToString()
    //{
    //    return $"ID: {Id}, Имя: {Name}, Вид: {Species}, Возраст: {Age}, Накормлен: {(IsFed ? "Сыто" : "Голодное")}";
    //}
}
