
В данном проекте не актуально, но:
- в манифесте проекта организованно копирование файла БД в директорию bin
- чтение "строки подключения" из конфига
- добавление настроек БД в конструктор контроллера из сервиса
- авторизация с токенами

Хотелось бы, но не добавлено в БД:
- проверка вводимых в БД значений в Check
- использовать нормальную типизацию
- да и в общем на MSSQL привычнее работать

Для простоты:
- всё в одном пространстве имён
- всё в одном проекте без выделения бизнес логики
- не применяются библиотеки классов
- нет специализированных библиотек для контейнеров (только AddTransient)