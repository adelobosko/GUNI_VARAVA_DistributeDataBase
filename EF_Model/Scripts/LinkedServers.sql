EXEC sp_addlinkedserver 'Global', '', 'SQLNCLI', '93.74.213.211,31340'
GO
EXEC sp_addlinkedsrvlogin 'Global', 'FALSE', NULL, 'sa', '2584744'
GO
EXEC sp_addlinkedserver 'Local', '', 'SQLNCLI', '192.168.1.100,31340'
GO
EXEC sp_addlinkedsrvlogin 'Local', 'FALSE', NULL, 'sa', '2584744'
GO
EXEC sp_addlinkedserver 'Host', '', 'SQLNCLI', '127.0.0.1,31340'
GO
EXEC sp_addlinkedsrvlogin 'Host', 'FALSE', NULL, 'sa', '2584744'
GO