
-- DROP the database if it exists
DROP DATABASE IF EXISTS tma3;
-- CREATE THE DATABASE
CREATE DATABASE tma3;
-- SHOW DATABASES;
-- Use the database
USE tma3;

DROP TABLE IF EXISTS slideshow;
CREATE TABLE slideshow
(
	Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Name text NOT NULL,
	Url text NOT NULL,
	Description text
);

INSERT INTO slideshow (Name, Url, Description) Values("img1", "../images/part2/img1.jpg", "1. Stanley Part Totem Poles");
INSERT INTO slideshow (Name, Url, Description) Values("img2", "../images/part2/img2.jpg", "2.Hidden Secret in Stanley Park");
INSERT INTO slideshow (Name, Url, Description) Values("img3", "../images/part2/img3.jpg", "3. Jericho Beach Pier");
INSERT INTO slideshow (Name, Url, Description) Values("img4", "../images/part2/img4.jpg", "4. Jericho Beach Look Out Point");
INSERT INTO slideshow (Name, Url, Description) Values("img5", "../images/part2/img5.jpg", "5. Crab Fishing");
INSERT INTO slideshow (Name, Url, Description) Values("img6", "../images/part2/img6.jpg", "6. Looking for Fish");
INSERT INTO slideshow (Name, Url, Description) Values("img7", "../images/part2/img7.jpg", "7. Walk to the Pier");
INSERT INTO slideshow (Name, Url, Description) Values("img8", "../images/part2/img8.jpg", "8. Unknown Ocean Specimen Washed Up on Shore");
INSERT INTO slideshow (Name, Url, Description) Values("img9", "../images/part2/img9.jpg", "9. Best Spot in BC, Horseshoe Bay");
INSERT INTO slideshow (Name, Url, Description) Values("img10", "../images/part2/img10.jpg", "10. Beautiful Drive up to Horseshoe Bay");
INSERT INTO slideshow (Name, Url, Description) Values("img11", "../images/part2/img11.jpg", "11. English Bay Puppy");
INSERT INTO slideshow (Name, Url, Description) Values("img12", "../images/part2/img12.jpg", "12. Destination to Lindeman Lake, After a Long Hike");
INSERT INTO slideshow (Name, Url, Description) Values("img13", "../images/part2/img13.jpg", "13. Horseshoe Bay Lookout");
INSERT INTO slideshow (Name, Url, Description) Values("img14", "../images/part2/img14.jpg", "14. Climb to the Top on Sundown");
INSERT INTO slideshow (Name, Url, Description) Values("img15", "../images/part2/img15.jpg", "15. Serene Dam at Capilano");
INSERT INTO slideshow (Name, Url, Description) Values("img16", "../images/part2/img16.jpg", "16. Lions Gate Bridge");
INSERT INTO slideshow (Name, Url, Description) Values("img17", "../images/part2/img17.jpg", "17. Canada 150!");
INSERT INTO slideshow (Name, Url, Description) Values("img18", "../images/part2/img18.jpg", "18. On Board to Victoria");
INSERT INTO slideshow (Name, Url, Description) Values("img19", "../images/part2/img19.jpg", "19. Arriving at Victoria");
INSERT INTO slideshow (Name, Url, Description) Values("img20", "../images/part2/img20.jpg", "20. Free Dragonette Concert at the Richmond World Fest");

DROP TABLE IF EXISTS computers;
CREATE TABLE computers
(
	Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Name text NOT NULL,
	Price double NOT NULL,
	ImageUrl text NOT NULL
);

INSERT INTO computers (Name, Price, ImageUrl) VALUES("Macbook Pro", 700.00, "../images/part3_4/macbook.png");
INSERT INTO computers (Name, Price, ImageUrl) VALUES("Lenovo", 400.00, "../images/part3_4/lenovo.png");
INSERT INTO computers (Name, Price, ImageUrl) VALUES("HP Notebook", 345.00, "../images/part3_4/hp.png");
INSERT INTO computers (Name, Price, ImageUrl) VALUES("Microsoft Surface", 1699.00, "../images/part3_4/microsoft-surface.jpg");

DROP TABLE IF EXISTS components;
CREATE TABLE components
(
	Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Name text NOT NULL,
	Price double NOT NULL,
	ComponentType text NOT NULL,
	ImageUrl text NOT NULL,
	IsDefault int NOT NULL
);

INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("11 inch.", 111.99, "Display", "../images/part3_4/11.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("13 inch.", 161.99, "Display", "../images/part3_4/13.png", 1);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("15 inch.", 199.99, "Display", "../images/part3_4/15.png", 0);

INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("HDD 256GB", 49.99, "Drive", "../images/part3_4/hdd256.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("HDD 500GB", 50.00, "Drive", "../images/part3_4/hdd500.png", 1);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("HDD 750GB", 69.99, "Drive", "../images/part3_4/hdd750.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("SSD 128GB", 89.99, "Drive", "../images/part3_4/ssd128.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("SSD 256GB", 119.99, "Drive", "../images/part3_4/ssd256.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("SSD 500GB", 169.99, "Drive", "../images/part3_4/ssd500.png", 0);

INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("4GB", 25.99, "Ram", "../images/part3_4/ram4.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("8GB", 79.00, "Ram", "../images/part3_4/ram8.png",1);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("16GB", 139.99, "Ram", "../images/part3_4/ram16.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("32GB", 200.00, "Ram", "../images/part3_4/ram32.png", 0);

INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("Intel i3", 111.99, "Cpu", "../images/part3_4/i3.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("Intel i5", 159.99, "Cpu", "../images/part3_4/i5.png",1);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("Intel i7", 250.00, "Cpu", "../images/part3_4/i7.png", 0);

INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("Windows 10", 19.99, "Os", "../images/part3_4/win7.png",1);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("Windows 11", 49.99, "Os", "../images/part3_4/win10.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("Mac High Sierra", 60.00, "Os", "../images/part3_4/macsierra.png", 0);
INSERT INTO components (Name, Price, ComponentType, ImageUrl, IsDefault) VALUES("Ubuntu 17.10", 29.99, "Os", "../images/part3_4/ubuntu.png", 0);

-- Quiz Tables //////////////////////////////////////////////
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS customers;
CREATE TABLE customers
(
	Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Username text NOT NULL,
	Password text NOT NULL
);

CREATE TABLE orders
(
	Id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Price decimal NOT NULL, 
	Detail text NOT NULL,
	ImageUrl text NOT NULL,
	Qty int NOT NULL,
	CustomerId int NOT NULL,
	ComponentId int,
	ComputerId int,
	FOREIGN KEY (CustomerId) REFERENCES customers(Id)
);