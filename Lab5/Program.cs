namespace Lab5;
 
// Создаем собственный класс исключения ServerConnectionException, наследующий от базового класса Exception
public class ServerConnectionException : Exception
{
    // Объяемляем конструктор класса исключения, который принимает сообщение об ошибке и передает его в конструктор базового класса Exception
    public ServerConnectionException(string message) : base(message)
    {

    }
}

// Объявляем публичный класс AutoUpdate
public class AutoUpdate
{
    // Объявляем метод GetNewData, который принимает логический параметр isConnected, чтобы определить, доступен ли сервер.
    public void GetNewData(bool isConnected)
    {
        // Проверяем, доступен ли сервер. Если да, выводим сообщение об успешном получении данных
        if (isConnected)
        {
            Console.WriteLine("Данные получены");
        }
        // Если сервер недоступен, выбрасываем исключение ServerConnectionException с сообщением "Обрыв связи с сервером".
        else
        {
            throw new ServerConnectionException("Обрыв связи с сервером");
        }
    }
}

// Объявляем класс Program
class Program
{
    // Объявляем точку входа в программу с помощью статистического метода Main
    static void Main(string[] args)
    { 
        // Выводим текст в командную строку
        Console.Write("Введите 1, если сервер доступен, или 0, если сервер недоступен: ");

        // Присваиваем значение целого числа переменной isConnected типа int. Объявляем метод Convert.ToInt32, преобразуем строку в целое число
        int isConnected = Convert.ToInt32(Console.ReadLine());

        // Присваиваем значение логическое переменной с именем boolIsConnected типа bool, в зависимости от сравнения переменной isConnected с 1
        bool boolIsConnected = isConnected == 1;

        // Создаем экземпляр класса AutoUpdate
        AutoUpdate autoUpdate = new AutoUpdate();

        // Блок try выполняет код, который может вызвать исключение
        try
        {
            // Вызываем метод GetNewData с параметром true, имитируя успешное подключение к серверу
            autoUpdate.GetNewData(boolIsConnected);
        }

        // Перехватываем исключение ServerConnectionException
        catch (ServerConnectionException ex)
        {
            // Выводим сообщение об ошибке, полученное из свойства Message исключения
            Console.WriteLine(ex.Message);
        }

        // Перехватываем любые другие исключения
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}