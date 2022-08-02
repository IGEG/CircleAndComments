Backend:

Проект на ASP.NET MVC (.net 6)
DB in-memory реализовано при помощи EF.inmemory. Данные берем из Models / SeedData.cs. Загрузка в context происходит через статический метод этого класса: EnsurePopulated(), вызываем его в middleware  перед app.run() в Program.cs;
	Для создания слабых ссылок, в контроллер передаем интерфейс контекста данных. Конкретную реализацию этого интерфейса инкапуслируем в Data/ DataCircle.cs. Создаем DI- контейнер в сервисах через метод AddTransient<IDataCircle, DataCircle>() в Program.cs; 
	Запросы к DB работают асинхронно через async/await.
Get запрос GetAllCirclesAndComments() возвращает  массив Json.  Через  include() join-им таблицы Circle и CommentsInCircle: context.Circles.Include(p => p.CommentsInCircle.OrderBy( c= > c.CommentId ) ).ToArrayAsync();
На выходе получаем массив Circle с внутренним массивом CommentInCircle.

Frontend:

Использую Jquery,konvajs
	Классы фигур (круг, комментарии к кругу) распложены в wwwroot/konva/shapes.
В этих классах инкапсулируем конструкторы фигур и методы для получения нужного объекта KONVA.
В _Layout.cshtml  подключаю скрипты.
В Views/Circle/Index.cshtml через $.ajax() get получаю массив Circle. Используя for, получаем все объекты Circle. Для каждого Circle, используя for по внутреннему массиву, получаем объекты комментариев. Объединяем все в Konva.Group();


