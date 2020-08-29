USE BugTrackerDb;
GO

INSERT INTO Tickets.TicketPriority
    ([Name])
VALUES
    ('Low');

INSERT INTO Tickets.TicketPriority
    ([Name])
VALUES
    ('Medium');

INSERT INTO Tickets.TicketPriority
    ([Name])
VALUES
    ('High');


INSERT INTO Tickets.TicketStatus
    ([Name])
VALUES
    ('New');

INSERT INTO Tickets.TicketStatus
    ([Name])
VALUES
    ('Open');

INSERT INTO Tickets.TicketStatus
    ([Name])
VALUES
    ('In Progress');

INSERT INTO Tickets.TicketStatus
    ([Name])
VALUES
    ('Resolved');

INSERT INTO Tickets.TicketStatus
    ([Name])
VALUES
    ('Additional Info Required');


INSERT INTO Tickets.TicketType
    ([Name])
VALUES
    ('Bug/Error');

INSERT INTO Tickets.TicketType
    ([Name])
VALUES
    ('Feature Request');

INSERT INTO Tickets.TicketType
    ([Name])
VALUES
    ('Documentation Request');

INSERT INTO Tickets.TicketType
    ([Name])
VALUES
    ('Other Comments');


INSERT INTO Users.UserRole
    ([Name])
VALUES
    ('Submitter');

INSERT INTO Users.UserRole
    ([Name])
VALUES
    ('Developer');

INSERT INTO Users.UserRole
    ([Name])
VALUES
    ('Project Manager');

INSERT INTO Users.UserRole
    ([Name])
VALUES
    ('Admin');


INSERT INTO Users.Users
    (RoleId, FirstName, LastName, Email)
VALUES
    (1, 'Demo', 'Submitter', 'email1');

INSERT INTO Users.Users
    (RoleId, FirstName, LastName, Email)
VALUES
    (2, 'Demo', 'Developer', 'email2');

INSERT INTO Users.Users
    (RoleId, FirstName, LastName, Email)
VALUES
    (3, 'Demo', 'Project Manager', 'email3');

INSERT INTO Users.Users
    (RoleId, FirstName, LastName, Email)
VALUES
    (4, 'Demo', 'Admin', 'email4');

GO


CREATE FUNCTION Tickets.fn_getTicketHistory(@id INT)
RETURNS TABLE
AS
RETURN
    SELECT *
FROM Tickets.Ticket
        FOR SYSTEM_TIME
            ALL
WHERE TicketId = @id
GO



-- Testing


-- INSERT INTO Projects.Project
--     (Title, [Description], ManagerId)
-- VALUES
--     ('title', 'description', 1);


-- INSERT INTO Tickets.Ticket
--     (Title, [Description], DevId, SubmitterId, ProjectId, PriorityId, StatusId, TypeId)
-- VALUES
--     ('title', 'description', 2, 3, 1, 1, 1, 1);

-- GO


-- update Tickets.Ticket
-- set PriorityId = 2, UpdaterId = 1
-- WHERE TicketId = 1;
-- GO

-- update Tickets.Ticket
-- set StatusId = 2, UpdaterId = 2
-- WHERE TicketId = 1;
-- GO


-- select *
-- from Tickets.Ticket;
-- GO

-- SELECT *
-- from Tickets.fn_getTicketHistory(1)
-- ORDER BY ValidFrom;
-- GO


-- select *
-- from Tickets.TicketPriority;

-- select *
-- from Tickets.TicketStatus;

-- select * from Tickets.TicketType;

-- select * from Users.Users;

-- select * from Users.UserRole;