USE master;
GO

CREATE DATABASE BugTrackerDb;
GO

USE BugTrackerDb;
GO

CREATE SCHEMA Projects;
GO

CREATE SCHEMA Tickets;
GO

CREATE SCHEMA Users;
GO

CREATE TABLE Projects.Project
(
    ProjectId INT NOT NULL IDENTITY(1, 1),
    Title NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    ManagerId INT NOT NULL,
    CONSTRAINT PK_ProjectId PRIMARY KEY (ProjectId)
);

CREATE TABLE Tickets.Ticket
(
    TicketId INT NOT NULL IDENTITY(1, 1),
    Title NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    DevId INT NULL,
    SubmitterId INT NOT NULL,
    UpdaterId INT NULL,
    ProjectId INT NOT NULL,
    PriorityId INT NOT NULL,
    StatusId INT NOT NULL,
    TypeId INT NOT NULL,
    DateCreated DATETIME2 NOT NULL DEFAULT GetDate(),
    ValidFrom DATETIME2 GENERATED ALWAYS AS ROW START,
    ValidTo DATETIME2 GENERATED ALWAYS AS ROW END,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
    CONSTRAINT PK_TicketId PRIMARY KEY (TicketId)
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Tickets.TicketHistory));

CREATE TABLE Tickets.TicketPriority
(
    PriorityId INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT PK_PriorityId PRIMARY KEY (PriorityId)
);

CREATE TABLE Tickets.TicketStatus
(
    StatusId INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT PK_StatusId PRIMARY KEY (StatusId)
);

CREATE TABLE Tickets.TicketType
(
    TypeId INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT PK_TypeId PRIMARY KEY (TypeId)
);

CREATE TABLE Tickets.Comment
(
    CommentId INT NOT NULL IDENTITY(1, 1),
    CommenterId INT NOT NULL,
    TicketId INT NOT NULL,
    DateCreated DATETIME2 NOT NULL,
    [Text] NVARCHAR(500) NOT NULL,
    CONSTRAINT PK_CommentId PRIMARY KEY (CommentId)
);

CREATE TABLE Users.Users
(
    UserId INT NOT NULL IDENTITY(1, 1),
    RoleId INT NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT PK_UserId PRIMARY KEY (UserId)
);

CREATE TABLE Users.UserProject
(
    -- UserProjectId INT NOT NULL IDENTITY(1, 1),
    UserId INT NOT NULL,
    ProjectId INT NOT NULL,
    CONSTRAINT PK_UserProjectId PRIMARY KEY (UserId, ProjectId)
);

CREATE TABLE Users.UserRole
(
    RoleId INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT PK_RoleId PRIMARY KEY (RoleId)
);

GO


-- Project Constraints

-- ALTER TABLE Projects.Project
-- ADD CONSTRAINT PK_ProjectId PRIMARY KEY (ProjectId);

ALTER TABLE Projects.Project
ADD CONSTRAINT FK_ManagerId FOREIGN KEY (ManagerId) REFERENCES Users.Users(UserId);


-- Ticket Constraints

-- ALTER TABLE Tickets.Ticket
-- ADD CONSTRAINT PK_TicketId PRIMARY KEY (TicketId);

ALTER TABLE Tickets.Ticket
ADD CONSTRAINT FK_DevId FOREIGN KEY (DevId) REFERENCES Users.Users(UserId);

ALTER TABLE Tickets.Ticket
ADD CONSTRAINT FK_SubmitterId FOREIGN KEY (SubmitterId) REFERENCES Users.Users(UserId);

ALTER TABLE Tickets.Ticket
ADD CONSTRAINT FK_ProjectId FOREIGN KEY (ProjectId) REFERENCES Projects.Project(ProjectId);

ALTER TABLE Tickets.Ticket
ADD CONSTRAINT FK_PriorityId FOREIGN KEY (PriorityId) REFERENCES Tickets.TicketPriority(PriorityId);

ALTER TABLE Tickets.Ticket
ADD CONSTRAINT FK_StatusId FOREIGN KEY (StatusId) REFERENCES Tickets.TicketStatus(StatusId);

ALTER TABLE Tickets.Ticket
ADD CONSTRAINT FK_TypeId FOREIGN KEY (TypeId) REFERENCES Tickets.TicketType(TypeId);

ALTER TABLE Tickets.Ticket
ADD CONSTRAINT FK_UpdaterId FOREIGN KEY (UpdaterId) REFERENCES Users.Users(UserId);


-- Priority Constraints

-- ALTER TABLE Ticekts.TicketPriority
-- ADD CONSTRAINT PK_PriorityId PRIMARY KEY (PriorityId);


-- Status Constraints

-- ALTER TABLE Ticekts.TicketStatus
-- ADD CONSTRAINT PK_StatusId PRIMARY KEY (StatusId);


-- Type Constraints

-- ALTER TABLE Ticekts.TicketType
-- ADD CONSTRAINT PK_TypeId PRIMARY KEY (TypeId);


-- Comment Constraints

-- ALTER TABLE Ticekts.Comment
-- ADD CONSTRAINT PK_CommentId PRIMARY KEY (CommentId);

ALTER TABLE Tickets.Comment
ADD CONSTRAINT FK_CommenterId FOREIGN KEY (CommenterId) REFERENCES Users.Users(UserId);

ALTER TABLE Tickets.Comment
ADD CONSTRAINT FK_TicketId FOREIGN KEY (TicketId) REFERENCES Tickets.Ticket(TicketId);


-- User Constraints

-- ALTER TABLE Users.Users
-- ADD CONSTRAINT PK_UserId PRIMARY KEY (UserId);

ALTER TABLE Users.Users
ADD CONSTRAINT FK_RoleId FOREIGN KEY (RoleId) REFERENCES Users.UserRole(RoleId);


-- UserProject Constraints

-- ALTER TABLE Users.UserProject
-- ADD CONSTRAINT PK_UserProjectId PRIMARY KEY (UserId, ProjectId);

ALTER TABLE Users.UserProject
ADD CONSTRAINT FK_UserId FOREIGN KEY (UserId) REFERENCES Users.Users(UserId);

ALTER TABLE Users.UserProject
ADD CONSTRAINT FK_ProjectId FOREIGN KEY (ProjectId) REFERENCES Projects.Project(ProjectId);


-- UserRole Constraints

-- ALTER TABLE Users.UserRole
-- ADD CONSTRAINT PK_RoleId PRIMARY KEY (RoleId);

GO

-- use master
-- go

-- drop database BugTrackerDb;