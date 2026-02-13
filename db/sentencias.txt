# A. Los clientes que tienen contactos que su nombre empieza por carl
select c.* from Clientes c
join Contactos c2 on c.Id = c2.ClienteId 
where c2.NombreCompleto like '%Carl%'

# B. Los clientes ordenados de forma ascendente por fecha de creación
select * from Clientes c 
order by c.FechaCreacion asc

# C. Clientes con más de un contacto
select c.Id, c.NombreCompleto, COUNT(c2.Id) as TotalContactos
from Clientes c 
Join Contactos c2 
on c.Id = c2.ClienteId 
group by c.id, c.NombreCompleto 
having count(c2.Id) > 1;

# D. Eliminar los contactos de un cliente determinado
delete from Contactos
where ClienteId = 5; 

# E. Eliminar los clientes que no tiene contactos
delete from Clientes
where Id not in (select distinct ClienteId from Contactos);

# F. Insertar un cliente con un contacto determinado.

declare @NuevoClienteId INT;
insert into Clientes (NombreCompleto, Direccion, Telefono, FechaCreacion)
values ('Juan Perez', 'Calle 123', '555-0101', getdate());

set @NuevoClienteId = SCOPE_IDENTITY();

insert into Contactos (NombreCompleto, Direccion, Telefono, ClienteId)
values ('Contacto de Juan', 'Av. Siempre Viva', '555-0202', @NuevoClienteId);