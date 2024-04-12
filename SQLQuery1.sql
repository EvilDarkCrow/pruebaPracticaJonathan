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
insert into products values ('Arroz')
go
insert into products values ('Tomate')
go
insert into products values ('Tarta')
go
insert into products values ('Pizza')
go
insert into products values ('Pechuga')
go
insert into products values ('Jamon')
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-12 10:30:00', 1, 1)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-11 10:24:00', 1, 4)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-11 08:30:00', 1, 7)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-12 09:45:00', 2, 3)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-13 13:45:00', 2, 6)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-11 09:12:00', 2, 9)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-14 13:24:00', 3, 2)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-13 07:44:00', 3, 5)
go
insert into orders (dateOrder, MemberId, ProductId) values ('2024-04-11 12:00:00', 3, 8)
go

COMMIT TRANSACTION