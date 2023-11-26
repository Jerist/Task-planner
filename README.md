# Task-planner
Сайт предназначен для планирования задач. После регистрации и авторизации пользователи могут просмотреть список своих задач или проектов, создавать новые, удалять или редактировать уже существующие. Авторизация происходит по номеру телефона

![model](https://github.com/Jerist/Task-planner/blob/main/Планировщик%20задач.png)

## Уровни доступа:
- пользователь;
- администратор.

## Основные сущности:
- пользователь
  - уникальный идентификатор;
  - имя;
  - номер телефона;
  - почта;
  - пароль в зашифрованном виде.

- проект
  - уникальный идентификатор;
  - название;
  - описание;
  - идентификатор пользователя.

- приоритет задачи
  - уникальный идентификатор;
  - название (высокий, средний, низкий).

- статус задачи
  - уникальный идентификатор;
  - название (выполнена, в процессе, отменена).

- задача
  - уникальный идентификатор;
  - описание;
  - крайний срок;
  - идентификатор пользователя;
  - идентификатор статуса;
  - идентификатор приоритета.

- админ
  - уникальный идентификатор;
  - имя;
  - номер телефона;
  - почта;
  - пароль в зашифрованном виде.
 
# Требования
- пользователь
  - регистрация и авторизация;
  - добавление новой задачи;
  - редактирование информации о задаче;
  - удаление задачи;
  - просмотр списка всех задач;
  - просмотри информации о конкретной задаче;
  - добавление задачи в проект;
  - удаление задачи из проекта;
  - создание нового проекта;
  - удаление проекта.
- администратор
  - просмотр всей информации;
  - блокировка пользователей.
