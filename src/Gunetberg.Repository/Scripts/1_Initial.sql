BEGIN TRANSACTION;
	CREATE TABLE Users(
		Id uniqueidentifier not null DEFAULT (NEWID()),
		Email nvarchar(150) not null,
		Password nvarchar(200) not null,
		Alias nvarchar(50) not null,
		Description nvarchar(300),
		PhotoUrl nvarchar(200),
		CreatedAt datetime not null,
		PRIMARY KEY (Id) 
	);

	CREATE UNIQUE INDEX idx_users_email ON Users (Email);
	CREATE INDEX idx_users_email_password ON Users (Email, Password);


	CREATE TABLE Posts(
		Id uniqueidentifier not null DEFAULT (NEWID()),
		Title nvarchar(150) not null,
		Language nvarchar(10) not null,
		CreatedBy uniqueidentifier not null,
		ImageUrl nvarchar(400),
		Content nvarchar(4000) not null,	
		CreatedAt datetime not null,
		PRIMARY KEY (Id), 
		FOREIGN KEY (CreatedBy) REFERENCES Users(Id)
	);

	CREATE INDEX idx_posts_title ON Posts (Title);

COMMIT;