CREATE TABLE TodoList(
        Id int not null identity primary key,
        Todomessage nvarchar(200) not null,
        TodoDescription nvarchar(max) not null,
        TodoDateTime datetime
)

DROP TABLE TodoList