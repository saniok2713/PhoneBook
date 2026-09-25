```
DROP DATABASE IF EXISTS phonebook;
CREATE DATABASE phonebook;
USE phonebook;

CREATE TABLE contacts(
id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
user_name VARCHAR(30),
phone_number VARCHAR(20)
);
```
