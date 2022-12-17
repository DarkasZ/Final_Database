CREATE TABLE gun_type(
	guntype_id INTEGER,
	name VARCHAR(50) NOT NULL UNIQUE,
	reload INTEGER,
	PRIMARY KEY(guntype_id)
);
INSERT INTO gun_type(guntype_id,name,reload)VALUES
(1, 'Sniper Rifle', 2.5),
(2, 'Assault Rifle', 1.5),
(3, 'Rocket Launcher', 3),
(4, 'Shotgun', 2),
(5, 'SMG', 1);

CREATE TABLE character(
	character_id INTEGER,
	name VARCHAR(50)NOT NULL UNIQUE,
	guntype_id INTEGER,
	level INTEGER DEFAULT 1,
	hp INTEGER,
	atk INTEGER,
	defend INTEGER,
	grade VARCHAR(50)NOT NULL,
	PRIMARY KEY (character_id)
	CONSTRAINT FK_Guntype FOREIGN KEY (guntype_id) REFERENCES gun_type(guntype_id)
);
INSERT INTO character(name,guntype_id,hp,atk,defend,grade)VALUES
('Helm',1,5800,255,35,'SRR'),
('Privaty',2,5800,240,41,'SRR'),
('Rapunzel',3,6474,213,44,'SRR'),
('Rapi',2,2528,129,21,'SR'),
('Neon',4,2800,108,22,'SR'),
('Volume',5,5837,250,36,'SSR'),
('Product 08',1,834,29,4,'R'),
('Soldier EG',2,750,34,5,'R');

CREATE TABLE deck(
	deck_id INTEGER,
	player_id INTEGER,
	character_id INTEGER,
	level INTEGER DEFAULT 1,
	hp INTEGER,
	atk INTEGER,
	defend INTEGER,
	PRIMARY KEY	(deck_id)
	CONSTRAINT FK_Player FOREIGN KEY (player_id) REFERENCES players(player_id)
	CONSTRAINT FK_Character FOREIGN KEY (character_id) REFERENCES character(character_id)
);

CREATE TABLE players(
	player_id INTEGER,
	username VARCHAR(50)NOT NULL UNIQUE,
	silver_coin INTEGER DEFAULT 0,
	gold_coin INTEGER DEFAULT 0,
	diamond INTEGER DEFAULT 0,
	PRIMARY KEY (player_id)
);
INSERT INTO players(username)VALUES
('paual');

CREATE TABLE mail(
	mail_id INTEGER,
	player_id INTEGER,
	title TEXT NOT NULL,
	reward TEXT NOT NULL,
	PRIMARY KEY (mail_id)
	CONSTRAINT FK_Player FOREIGN KEY (player_id) REFERENCES players(player_id)
	
);
INSERT INTO mail (player_id, title, reward) VALUES
(1, 'Welcome New Player', 'Gacha Ticket'),
(1, 'Pocket Gift Reward', 'Silver'),
(1, 'Pocket Gift Reward', 'Diamond');

CREATE TABLE item(
	item_id INTEGER,
	name TEXT NOT NULL,
	
	PRIMARY KEY(item_id)
);
INSERT INTO item(name) VALUES
('Gacha TIcket'),
('Flash Drive x 100'),
('Silver x 200'),
('Gold x 50');

CREATE TABLE shop(
	item_id INTEGER,
	name TEXT NOT NULL,
	silver_coin INTEGER,
	gold_coin INTEGER,
	diamond INTEGER,
	CONSTRAINT FK_Item FOREIGN KEY (item_id) REFERENCES item(item_id)
);
INSERT INTO shop(item_id,name, silver_coin, gold_coin, diamond)VALUES
(1, 'Gacha Ticket ', 0, 0, 300),
(2, 'Flashdrive x 100',0, 100, 0),
(3, 'Pack Silver x 200', 0, 0, 200),
(4, 'Pack Gold x 50', 0, 0, 200);

CREATE TABLE inventory(
	player_id INTEGER,
	item_id INTEGER,
	amount INTEGER,
	CONSTRAINT FK_Player FOREIGN KEY (player_id) REFERENCES players(player_id)
	CONSTRAINT FK_Item FOREIGN KEY (item_id) REFERENCES item(item_id)
);


