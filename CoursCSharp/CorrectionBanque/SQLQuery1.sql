CREATE TABLE compte (
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
clientId INT NOT NULL,
solde decimal(10,2) NOT NULL
)

CREATE TABLE operation(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
compteId INT NOT NULL,
montant decimal(10,2) NOT NULL,
dateOperation Datetime NOT NULL
)