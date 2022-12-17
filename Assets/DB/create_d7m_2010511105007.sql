CREATE TABLE gun_type(
	type_id INTEGER,
	name VARCHAR(50) NOT NULL UNIQUE,
	PRIMARY KEY(type_id)
);
INSERT INTO gun_type(type_id,name)VALUES
(1, 'Sniper Rifle'),
(2, 'Assault Rifle'),
(3, 'Rocket Launcher'),
(4, 'Shotgun'),
(5, 'SMG');

CREATE TABLE character(
	character_id INTEGER,
	name VARCHAR(50)NOT NULL UNIQUE,
	type_id INTEGER,
	hp INTEGER,
	atk INTEGER,
	defend INTEGER,
	grade VARCHAR(50)NOT NULL,
	PRIMARY KEY (character_id)
	CONSTRAINT FK_Guntype FOREIGN KEY (type_id) REFERENCES gun_type(type_id)
);
INSERT INTO character(name,type_id,hp,atk,defend,grade)VALUES
('Helm',1,5800,255,35,'SRR'),
('Privaty',2,5800,240,41,'SRR'),
('Rapunzel',3,6474,213,44,'SRR'),
('Rapi',2,2528,129,21,'SR'),
('Neon',4,2800,108,22,'SR'),
('Volume',5,5837,250,36,'SSR'),
('Product 08',1,834,29,4,'R'),
('Soldier EG',2,750,34,5,'R');



CREATE TABLE transactions_type(
	transtype_id INTEGER,
	name VARCHAR(50)NOT NULL,
	PRIMARY KEY (transtype_id)
);
INSERT INTO	transactions_type(name)VALUES
('Gacha Draw'),
('Upgrade Card');

CREATE TABLE currency_type(
	currency_id INTEGER,
	name VARCHAR(50)NOT NULL,
	PRIMARY KEY (currency_id)
);
INSERT INTO currency_type(name)VALUES
('Silver Coin'),
('Gold Coin'),
('Diamond');

CREATE TABLE transactions(
	player_id INTEGER,
	transtype_id INTEGER,
	currency_id INTEGER,
	cost INTEGER,
	CONSTRAINT FK_Player FOREIGN KEY (player_id) REFERENCES players(player_id)
	CONSTRAINT FK_Trans FOREIGN KEY (transtype_id) REFERENCES transactions_type(transtype_id)
	CONSTRAINT FK_Currency FOREIGN KEY (currency_id) REFERENCES currency_type(currency_id)
);

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
	silver_coin INTEGER,
	gold_coin INTEGER,
	diamond INTEGER,
	PRIMARY KEY (player_id)
);
INSERT INTO players(username,silver_coin,gold_coin,diamond)VALUES
('paual',5000,1000,600),
('bzerio',5000,1000,600);

