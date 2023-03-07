CREATE DATABASE bookmanagement;
USE bookmanagement;


CREATE TABLE book
(
	id_book INT PRIMARY KEY IDENTITY,
	title NVARCHAR(255),
	author NVARCHAR(255),
	decription NVARCHAR(255),
	images nvarchar(100) NULL,
	public_date INT,
	category NVARCHAR(255)
);

CREATE TABLE users
(
	id INT PRIMARY KEY IDENTITY,
	--id_book int,
	--foreign key (MaLop) references LOP(MaLop)
	--on update cascade
	--on delete set null
	email VARCHAR(255),
	pass VARCHAR(255),
	name NVARCHAR(255),
	role BIT DEFAULT 1   -- 0: admin, 1: user
);

INSERT INTO users(email, pass, name,role) VALUES('admin@gmail.com', '123', 'admin', '0')
INSERT INTO users(email, pass, name, role) VALUES('user@gmail.com', '123', 'user', '1')

select * from book