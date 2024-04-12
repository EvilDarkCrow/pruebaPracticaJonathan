BEGIN TRANSACTION
insert into members values('Jonathan')
go
insert into members values('Paco')
go
insert into members values('Alvaro')
go
insert into products values ('Leche')
go
insert into products values ('Cereales')
go
insert into products values ('Macarrones')
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-12 10:30:00', 1, 1)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-11 9:45:00', 2, 3)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-11 13:24:00', 3, 2)
go
COMMIT TRANSACTION