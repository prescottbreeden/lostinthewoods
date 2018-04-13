CREATE TABLE trails 
	(
		id INT AUTO_INCREMENT PRIMARY KEY,
		name VARCHAR(50) NOT NULL,
		description TEXT NOT NULL,
		elevation INT NOT NULL,
		length FLOAT NOT NULL,
        longitude FLOAT NOT NULL,
        latitude FLOAT NOT NULL,
		created_at DATETIME DEFAULT NOW(),
		updated_at DATETIME DEFAULT NOW()
	);

