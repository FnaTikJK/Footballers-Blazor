Для работы приоложение необходимо создать БД. Для этого нужно либо

1)Сделать миграции через консоль

2)Раскомитить эту строчку в Data/DataContext

![image](https://user-images.githubusercontent.com/70794890/225559074-c7891673-e5da-4c91-9961-833d5a43a421.png)

Далее запустить программу и добавить любого футболиста. Потом закомитить строчку и перезапустить программу, иначе БД будет всё время пересоздаваться.

Я подкрутил SignalR и, вроде как, он работает корректно, но blazor не обновляет строки пока не нажата кнопка "Редактировать" на любой строчке таблицы.
То есть данные обновились, но пользователю не покажутся другому пользователю, пока он не нажмёт "Редактировать". Эту проблему я решить не смог.