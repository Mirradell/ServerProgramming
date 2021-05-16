Перед запуском сделать следующее:

	1. Создать файл 'common.db' по указанному в файле 'CommonContext.cs'(функция 'OnConfiguration') пути.

	2. Выполнить первоначальную миграцию базы данных Для этого в консл=оли диспетчера пакетов ввести
		2.1. EntityFrameworkCore\Add-Migration InitialCreate
		2.2. EntityFrameworkCore\Update-Database

	3. Готово! Готово к запуску.