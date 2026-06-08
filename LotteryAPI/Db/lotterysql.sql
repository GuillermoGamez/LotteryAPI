-- PostgreSQL commands used to create initial db
CREATE TABLE statuses (
    StatusId INT PRIMARY KEY,
    Category VARCHAR(25) NOT NULL,
    StatusName VARCHAR(25) NOT NULL
);

INSERT INTO statuses (StatusId, Category, StatusName) VALUES (1, 'User', 'Active');
INSERT INTO statuses (StatusId, Category, StatusName) VALUES (2, 'User', 'Inactive');
INSERT INTO statuses (StatusId, Category, StatusName) VALUES (3, 'Ticket', 'Pending');
INSERT INTO statuses (StatusId, Category, StatusName) VALUES (4, 'Ticket', 'Completed');

CREATE TABLE users (
    UserId INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Email VARCHAR(200) UNIQUE NOT NULL,
    Password VARCHAR(200) NOT NULL,
    StatusId INT NOT NULL REFERENCES Statuses(StatusId),
    CreatedOn DATE NOT NULL DEFAULT current_date,
    LastLogin DATE
);

CREATE TABLE permissions (
    PermissionId INT PRIMARY KEY NOT NULL,
    PermissionName VARCHAR(25) NOT NULL
);

INSERT INTO permissions (PermissionId, PermissionName) VALUES (1, 'User');
INSERT INTO permissions (PermissionId, PermissionName) VALUES (2, 'Admin');

CREATE TABLE user_permissions (
    UserId INT NOT NULL REFERENCES Users(UserId),
    PermissionId INT NOT NULL REFERENCES Permissions(PermissionId),
    PRIMARY KEY (UserId, PermissionId)
);

CREATE TABLE tickets (
    TicketId INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    UserId INT NOT NULL REFERENCES Users(UserId),
    StatusId INT NOT NULL REFERENCES Statuses(StatusId),
    TicketDate DATE NOT NULL,
    CreatedOn DATE NOT NULL default current_date
);


SELECT * FROM statuses;
SELECT * FROM users;
SELECT * FROM permissions;
SELECT * FROM user_permissions;
SELECT * FROM tickets;