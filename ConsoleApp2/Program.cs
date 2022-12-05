internal class Program
{
    private static void Main(string[] args)
    {
        List<People> collection= new List<People>();
        
        People x = new People("Ложкин Вася Петрович", new DateOnly(2004,08,26));
        People y = new People("Пупкин Саня Кропич", new DateOnly(2004, 12, 26));
        People z = new People("Поварешкин Темик Валькович", new DateOnly(2004, 07, 10));

        collection.Add(x);
        collection.Add(y);
        collection.Add(z);

        foreach (var item in collection)
        {
            Console.WriteLine(item.GetPasport());
        }



    }
}

class People
{
    private string _name;
    private string _family;
    private string _patronomic;
    
    private DateOnly _birthday;
    private int _age;

    public People(string fio, DateOnly date)
    {
        var fio_arr = fio.Split(' ');

        if (fio_arr.Length <= 2)
            return;

        _name = fio_arr[1];
        _family = fio_arr[0];
        _patronomic= fio_arr[2];

        _age = DateTime.Now.Year - date.Year;
        if (DateTime.Now.DayOfYear < date.DayOfYear) //на случай, если день рождения ещё не наступил
            _age--;
    }
    public string GetPasport()
    {
        string info = $"Имя {_name}\nФамилия {_family}\n{_patronomic}\n{_age} лет";
        return info;
    }
}