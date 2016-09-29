CREATE TABLE categoria (
    id bigint AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) not null UNIQUE
    


);

CREATE TABLE articulo (
	id bigint AUTO_INCREMENT primary key,
    	nombre varchar(50) not null unique,
    	precio decimal(10,2),
	categoria bigint
)
alter table articulo add foreign key (categoria) references categoria (id);

insert into articulo (nombre,precio,categoria) values ("articulo 1",15.0,1);
insert into articulo (nombre,precio,categoria) values ("articulo 2",9.95,2);
insert into articulo (nombre,precio,categoria) values ("articulo 3",10.80,3);
insert into articulo (nombre,precio,categoria) values ("articulo 4",900.99,4);
