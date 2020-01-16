CREATE TABLE produit (
	id INT PRIMARY KEY IDENTITY(1,1),
	label varchar(50) NOT NULL,
	prix decimal(10,2) NOT NULL 
);
CREATE TABLE panier(
	id INT PRIMARY KEY IDENTITY(1,1),
	nom_client varchar(50) NOT NULL,
	tel_client varchar(10) NOT NULL,
	total decimal(10,2) NOT NULL
)

CREATE TABLE panier_produit(
	Id INT PRIMARY KEY IDENTITY(1,1),
	produit_id INT NOT NULL,
	panier_id INT NOT NULL
)