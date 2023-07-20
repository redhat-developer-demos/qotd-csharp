/*
CREATE DATABASE  `qotd` ;
*/

USE qotd;

DROP TABLE IF EXISTS qotd.qotd;
DROP TABLE IF EXISTS qotd.quotes;

CREATE TABLE qotd.quotes (
  Id        BIGINT NOT NULL AUTO_INCREMENT,
  Quotation TEXT,
  Author   VARCHAR( 256 ),
  PRIMARY KEY (Id));

  INSERT INTO quotes(Quotation, Author) values
  ("Yeah, well, that's just like, your opinion, man.","The Dude"),
("It is not only what you do but also the attitude you bring to it, that makes you a success.","Don Schenck"),
("Knowledge is power.","Sir Francis Bacon"),
("Life is really simple, but we insist on making it complicated.","Confucius"),
("This above all: To thine own self be true.","William Shakespeare"),
("I got a fever, and the only prescription is more cowbell.","Will Ferrell"),
("Anyone who has ever made anything of importance was disciplined.","Andrew Hendrixson"),
("Strive not to be a success, but rather to be of value.","Albert Einstein"),
("The greatest glory in living lies not in never falling, but in rising every time we fall.","Nelson Mandela"),
("The way to get started is to quit talking and begin doing.","Walt Disney"),
("Your time is limited so don't waste it living someone else's life. Don't be trapped by dogma – which is living with the results of other people's thinking.","Steve Jobs"),
("If life were predictable it would cease to be life, and be without flavor.","Eleanor Roosevelt"),
("If you look at what you have in life you'll always have more. If you look at what you don't have in life you'll never have enough.","Oprah Winfrey"),
("If you set your goals ridiculously high, and it's a failure, you will fail above everyone else's success.","James Cameron"),
("Life is what happens when you're busy making other plans.","John Lennon"),
("The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart.","Helen Keller");