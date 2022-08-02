Backend:

Проект на ASP.NET MVC (.net 6)
DB in-memory реализовано при помощи EF.inmemory. Данные берем из Models / SeedData.cs. Загрузка происходит через статический метод этого класса: EnsurePopulated(), вызываем его в middleware  перед app.run() в Program.cs;
	Для создания слабых ссылок, в контроллер передаем интерфейс контекста данных. Конкретную реализацию этого интерфейса инкапуслируем в Data/ DataCircle.cs. Создаем DI- контейнер в сервисах через метод AddTransient<IDataCircle, DataCircle>() в Program.cs; 
	Запросы к DB работают асинхронно через async/await.
Get запрос GetAllCirclesAndComments() возвращает  массив Json.  Через  include() join-им таблицы Circle и CommentsInCircle: context.Circles.Include(p => p.CommentsInCircle.OrderBy( c= > c.CommentId ) ).ToArrayAsync();
На выходе получаем массив Circle с внутренним массивом CommentInCircle.
Формат:
[{"CircleId":1,"PointX":100,"PointY":100,"Radius":10,"Color":"yellow","CommentsInCircle":[{"CommentId":1,"Text":"Comment1","Color":"white","CircleId":1},{"CommentId":2,"Text":"Comment2","Color":"yellow","CircleId":1}]


Frontend:

Использую Jquery,konvajs
	Классы фигур (круг, комментарии к кругу) распложены в wwwroot/konva/shapes.В этих классах инкапсулируем конструкторы фигур и методы для получения нужного объекта KONVA.
	Отправка запросов (get,post,put,delete) в классе Data расположенного в wwwroot/data. В конструктор класса передаем строку запроса. В методы - параметры к запросу (допустим Id). 
	--- В методе GetAllCircle(): Используя for, получаем все объекты Circle. Для каждого Circle, используя for по внутреннему массиву, получаем объекты комментариев. Объединяем все в Konva.Group(); 
	--- В методе  deleteCircle(id): используюя id объекта отправляем запрос 'delete' по адресу:/Circle/DeleteCirclesAndComments/Id.
	
	



