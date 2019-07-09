# IPInformer v 0.2.0

Программа предназначена для отображения внешнего IP-адреса компьютера, определения географической принадлежности IP-адреса, а также того, не попадает ли IP-адрес в список "запрещенных" стран.

Программа получает IP-адрес, из поставляемого с ней PHP-скрипта, размещенного на Web-сервере в Интернете, и/или (в текущей версии) с сайтов, которые информируют пользователя о его внешнем IP. В текущей версии не все такие сайты подходят (сайт не должен быть заскриптован, не требовать обязательного использования cookie и не выдавать капчу), а оригинальный скрипт PHP предоставляет некоторые дополнительные возможности.

Далее, программа получает из базы данных SxGeo сведения о геопозиции, и, если настроено и IP-адрес попал в стоп-лист стран, выводит предупреждение о попадании в данный список.

Свежую версию БД SxGeo можно бесплатно скачать с сайта разработчиков базы данных: <https://sypexgeo.net/ru/download/>

Программа при запуске находится в системном трее, управление производится через контекстное меню.

Изначально писалась по заказу одного активиста, у которого была проблема с периодическим отключением от VPN, в связи с чем, случайно мог "засветиться" его IP, или VPN мог переключить его на нежелательную страну.

По умолчанию программа запускается в "портативном" режиме (все данные хранятся в подкаталоге data каталога с исполняемым файлом)

## Системные требования

Microsoft Windows XP и выше (Vista/7/8/8.1/10), .NET Framework 2.0 и выше, 512 Мб оперативной памяти, 15 Мб на жестком диске.

##Дополнительные компоненты

В качестве контрола для ввода IP-адреса мы использовали

C# IP Address Control вот этого автора:

<https://www.codeproject.com/Articles/9352/A-C-IP-Address-Control>

База данных SypexGeo (SxGeo):

© 2006-2018 zapimir

© 2006-2018 BINOVATOR

<https://sypexgeo.net>

## Скриншоты

### Новый IP

![Новый IP](/help-src/IMAGES/09.png)

### Список "нежелательных" стран

![Список "нежелательных" стран](/help-src/IMAGES/12.png)

### Обнаружен IP "нежелательной" страны

![Обнаружен IP "нежелательной" страны](/help-src/IMAGES/13.png)

![Обнаружен IP "нежелательной" страны](/help-src/IMAGES/14.png)

### Информация о своем IP

![Информация о своем IP](/help-src/IMAGES/15.png)

### Ошибка сети

![Ошибка сети](/help-src/IMAGES/04.png)

![Ошибка сети](/help-src/IMAGES/05.png)