Перед запуском сделать следующее:

	1. Если путь к файлу "common.db" в прошлой лабораторной был изменен, то аналогично изменить и здесь(файл "CommonContext.cs")

	2. Выполнить миграцию базы данных Для этого в консоли диспетчера пакетов ввести
		2.1. EntityFrameworkCore\Add-Migration AddAccountMigration
		2.2. EntityFrameworkCore\Update-Database

	3. Готово! Можно запускать.