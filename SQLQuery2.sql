USE LojaDeInstrumentosAPI
DECLARE @role varchar(10);
SET @role = 'Common'

SELECT i.* FROM Instrument i
JOIN AspNetUsers u ON i.createdById = u.Id
JOIN AspNetUserRoles ur ON u.Id = ur.UserId
JOIN AspNetRoles r ON ur.RoleId = r.Id
WHERE r.Name = @role


SELECT i.* FROM AspNetRoles r
JOIN AspNetUserRoles ur ON r.Id = ur.RoleId
JOIN AspNetUsers u ON ur.UserId = u.Id
JOIN Instrument i ON i.createdById = u.Id
WHERE r.Name = @role

SELECT i.* FROM Instrument i, AspNetUsers u, AspNetUserRoles ur, AspNetRoles r
WHERE 1 = 1
AND i.createdById = u.Id
AND u.Id = ur.UserId
AND ur.RoleId = r.Id
AND r.Name = @role