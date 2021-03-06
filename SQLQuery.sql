CREATE TABLE ROOM(
RoomId BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
FloorNo INT,
Name VARCHAR(50),
Type VARCHAR(50),
IsKitchen BIT,
EntryDate Date NOT NULL
)
GO
Create Table Member(
MemberId BIGINT PRIMARY KEY IDENTITY(1,1),
IdToken varchar(50) NOT NULL,
Name varchar(50) NULL,
Email VARCHAR(50),
ImageURL VARCHAR(MAX)
)
GO
CREATE TABLE Bookings(
BookingId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
MemberId BIGINT FOREIGN KEY REFERENCES Member(MemberId) NOT NULL,
RoomId BIGINT FOREIGN KEY REFERENCES Room(RoomId) NOT NULL,
FromDate date,
ToDate Date,
FromTime time(7) NULL,
ToTime time(7) NULL,
EntryDate DateTime Not NULL
)
GO
CREATE TABLE Users(
UserId BIGINT PRIMARY KEY IDENTITY(1,1),
Email VARCHAR(50) NOT NULL,
Password VARCHAR(MAX) NOT NULL,
EntryDate DATETIME NOT NULL
)
 

