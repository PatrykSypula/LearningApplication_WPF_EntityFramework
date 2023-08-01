Create database LEARNING
GO

USE LEARNING
GO

CREATE TABLE CardStacks (
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	CardStackName VARCHAR(50) NOT NULL,
	IsDefaultCardStack INTEGER NOT NULL);

CREATE TABLE Words (
    Id INTEGER IDENTITY(1,1) PRIMARY KEY,
    WordPolish VARCHAR(50) NOT NULL,
    WordTranslated VARCHAR(50) NOT NULL,
    CardStackId INTEGER NOT NULL,
    FOREIGN KEY (CardStackId) REFERENCES CardStacks(Id));

CREATE TABLE SessionStatistics (
    Id INTEGER IDENTITY(1,1) PRIMARY KEY,
    SessionDate DATETIME NOT NULL,
    Difficulty VARCHAR(18) NOT NULL,
    GoodAnswers INTEGER NOT NULL,
    AllAnswers INTEGER NOT NULL,
    Percentage VARCHAR(6) NOT NULL,
    CardStackId INTEGER NOT NULL,
    FOREIGN KEY (CardStackId) REFERENCES CardStacks(Id));


--S³owniki
INSERT INTO CardStacks(cardStackName, isDefaultCardStack) VALUES('Czêœci cia³a',1);
INSERT INTO CardStacks(cardStackName, isDefaultCardStack) VALUES('Czynnoœci',1);
INSERT INTO CardStacks(cardStackName, isDefaultCardStack) VALUES('Jedzenie i picie',1);
INSERT INTO CardStacks(cardStackName, isDefaultCardStack) VALUES('Kolory',1);
INSERT INTO CardStacks(cardStackName, isDefaultCardStack) VALUES('Miejsce zamieszkania',1);
INSERT INTO CardStacks(cardStackName, isDefaultCardStack) VALUES('Natura',1);

--S³owa
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('g³owa','head',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ucho','ear',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('oko','eye',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('nos','nose',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('usta','mouth',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('gard³o','throat',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('rêka','arm',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('noga','leg',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('d³oñ','hand',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('palec','finger',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('stopa','foot',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('plecy','back',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('klatka piersiowa','chest',1);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('krêgos³up','spine',1);

INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('jeœæ','eat',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('spaæ','sleep',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('patrzeæ','look',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('dotykaæ','touch',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('uœmiechaæ siê','smile',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('iœæ','walk',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('biec','run',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('pisaæ','write',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('pisaæ na klawiaturze','type',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('czytaæ','read',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('æwiczyæ','exercise',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('rysowaæ','draw',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('mówiæ','speak',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('s³uchaæ','listen',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('graæ','play',2);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('œpiewaæ','sing',2);

INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('warzywa','vegetables',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('owoce','fruits',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('chleb','bread',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('miêso','meat',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ryba','fish',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ser','cheese',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ry¿','rice',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('jajko','egg',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('cukier','sugar',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('lody','ice cream',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('czekolada','chocolate',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ciastko','biscuit',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('cukierek','candy',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('napój','drink',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('woda','water',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('mleko','milk',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('kawa','coffee',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('herbata','tea',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('sok','juice',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('napój gazowany','fizzy drink',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('piwo','beer',3);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('wino','wine',3);

INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ró¿owy','pink',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('czerwony','red',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('pomarañczowy','orange',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('¿ó³ty','yellow',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('zielony','green',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('niebieski','blue',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('fioletowy','purple',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('bia³y','white',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('czarny','black',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('br¹zowy','brown',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('szary','grey',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('be¿owy','beige',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ciemnoniebieski','dark blue',4);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('jasnoniebieski','light blue',4);

INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('brama','gate',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('drzwi wejœciowe','front door',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('schody','stairs',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('balkon','balcony',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('salon','living room',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('okno','window',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('³azienka','bathroom',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('jadalnia','dining room',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('sypialnia','bedroom',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('kuchnia','kitchen',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('œciana','wall',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('pod³oga','floor',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('dywan','carpet',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('sufit','ceiling',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('œwiat³o','light',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('w³¹cznik','switch',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('gniazdko','socket',5);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('kaloryfer','radiator',5);

INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('roœlina','plant',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('kwiat','flower',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('las','forest',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('drzewo','tree',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('krzak','bush',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('trawa','grass',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('góra','mountain',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('ska³a','rock',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('wyspa','island',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('morze','sea',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('rzeka','river',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('jezioro','lake',6);
INSERT INTO Words(wordPolish, WordTranslated, cardStackId) VALUES('staw','pond',6);
