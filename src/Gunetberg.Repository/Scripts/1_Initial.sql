BEGIN TRANSACTION;
	CREATE TABLE Users(
		Id uniqueidentifier not null DEFAULT (NEWID()),
		Email nvarchar(150) not null,
		Password nvarchar(200) not null,
		Alias nvarchar(50) not null,
		Description nvarchar(300),
		PhotoUrl nvarchar(200),
		CreatedAt datetime not null,
		PRIMARY KEY(Id) 
	);

	CREATE UNIQUE INDEX idx_users_email ON Users (Email);
	CREATE INDEX idx_users_email_password ON Users (Email, Password);
COMMIT;