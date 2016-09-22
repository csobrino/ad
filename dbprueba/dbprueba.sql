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
