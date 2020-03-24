﻿/*
Deployment script for Kanini.ECommerce.EShopiee.Entity

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Kanini.ECommerce.EShopiee.Entity"
:setvar DefaultFilePrefix "Kanini.ECommerce.EShopiee.Entity"
:setvar DefaultDataPath "C:\Users\Divhya.bharathy\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\localdb"
:setvar DefaultLogPath "C:\Users\Divhya.bharathy\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\localdb"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Delivery]...';


GO
CREATE TABLE [dbo].[Delivery] (
    [DeliveryId]     INT          IDENTITY (1, 1) NOT NULL,
    [ProductId]      INT          NOT NULL,
    [OrderId]        INT          NOT NULL,
    [DeliveryStatus] VARCHAR (20) NOT NULL,
    [DeliveryDate]   DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([DeliveryId] ASC)
);


GO
PRINT N'Creating [dbo].[Feedback]...';


GO
CREATE TABLE [dbo].[Feedback] (
    [FeedbackId] INT            NOT NULL,
    [ProductId]  INT            NOT NULL,
    [UserId]     INT            NOT NULL,
    [Feedback]   VARCHAR (MAX)  NOT NULL,
    [Rating]     DECIMAL (2, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([FeedbackId] ASC)
);


GO
PRINT N'Creating [dbo].[OrderDetails]...';


GO
CREATE TABLE [dbo].[OrderDetails] (
    [OrderId]   INT             IDENTITY (1, 1) NOT NULL,
    [ProductId] INT             NOT NULL,
    [Quantity]  INT             NOT NULL,
    [Price]     DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);


GO
PRINT N'Creating [dbo].[Orders]...';


GO
CREATE TABLE [dbo].[Orders] (
    [OrderId]   INT  NOT NULL,
    [UserId]    INT  NOT NULL,
    [PaymentId] INT  NOT NULL,
    [OrderDate] DATE NOT NULL
);


GO
PRINT N'Creating [dbo].[PaymentDetails]...';


GO
CREATE TABLE [dbo].[PaymentDetails] (
    [PaymentId]     INT             IDENTITY (1, 1) NOT NULL,
    [PaymentTypeId] INT             NOT NULL,
    [CardNumber]    VARCHAR (16)    NOT NULL,
    [ExpiryDate]    DATE            NOT NULL,
    [CVV]           INT             NOT NULL,
    [Amount]        DECIMAL (18, 2) NOT NULL,
    [DateOfPayment] DATE            NULL,
    PRIMARY KEY CLUSTERED ([PaymentId] ASC)
);


GO
PRINT N'Creating [dbo].[PaymentType]...';


GO
CREATE TABLE [dbo].[PaymentType] (
    [PaymentTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [PaymentType]   VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([PaymentTypeId] ASC)
);


GO
PRINT N'Creating [dbo].[Product]...';


GO
CREATE TABLE [dbo].[Product] (
    [ProductId]        INT             IDENTITY (1, 1) NOT NULL,
    [Name ]            VARCHAR (30)    NOT NULL,
    [Rating]           DECIMAL (2, 1)  NOT NULL,
    [ManufactureDate]  DATE            NOT NULL,
    [CartDescription]  VARCHAR (100)   NOT NULL,
    [ShortDescription] VARCHAR (MAX)   NOT NULL,
    [Image]            VARCHAR (100)   NOT NULL,
    [MRP]              DECIMAL (18, 2) NOT NULL,
    [DealPrice]        DECIMAL (18, 2) NOT NULL,
    [SavePrice]        DECIMAL (18, 2) NOT NULL,
    [NoOfStock]        INT             NOT NULL,
    [ProductIsActive]  BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);


GO
PRINT N'Creating [dbo].[UserAddress]...';


GO
CREATE TABLE [dbo].[UserAddress] (
    [UserId]   INT           NOT NULL,
    [Address1] VARCHAR (100) NOT NULL,
    [Address2] VARCHAR (100) NOT NULL,
    [City]     VARCHAR (20)  NOT NULL,
    [State]    VARCHAR (30)  NOT NULL,
    [PinCode]  VARCHAR (20)  NOT NULL
);


GO
PRINT N'Creating [dbo].[UserRoles]...';


GO
CREATE TABLE [dbo].[UserRoles] (
    [RoleId]          INT          IDENTITY (1, 1) NOT NULL,
    [RoleDescription] VARCHAR (20) NOT NULL,
    [RoleNumber]      INT          NOT NULL,
    [CreatedDate]     DATE         NOT NULL,
    [ModifiedDate]    DATE         NOT NULL,
    [RoleIsActive]    BIT          NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [UserId]       INT          IDENTITY (1, 1) NOT NULL,
    [RoleId]       INT          NOT NULL,
    [Name]         VARCHAR (30) NOT NULL,
    [MobileNumber] VARCHAR (15) NOT NULL,
    [DateOfBirth]  DATE         NOT NULL,
    [Gender]       VARCHAR (10) NOT NULL,
    [EmailId]      VARCHAR (30) NOT NULL,
    [Password]     VARCHAR (20) NOT NULL,
    [CreatedDate]  DATE         NOT NULL,
    [ModifiedDate] DATE         NOT NULL,
    [UserIsActive] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    UNIQUE NONCLUSTERED ([EmailId] ASC)
);


GO
PRINT N'Creating [dbo].[WishList]...';


GO
CREATE TABLE [dbo].[WishList] (
    [CartId]        INT  IDENTITY (1, 1) NOT NULL,
    [UserId]        INT  NOT NULL,
    [ProductId]     INT  NOT NULL,
    [DateOfCartAdd] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([CartId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Delivery_Product]...';


GO
ALTER TABLE [dbo].[Delivery]
    ADD CONSTRAINT [FK_Delivery_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]);


GO
PRINT N'Creating [dbo].[FK_Delivery_OrderDetails]...';


GO
ALTER TABLE [dbo].[Delivery]
    ADD CONSTRAINT [FK_Delivery_OrderDetails] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[OrderDetails] ([OrderId]);


GO
PRINT N'Creating [dbo].[FK_Feedback_Product]...';


GO
ALTER TABLE [dbo].[Feedback]
    ADD CONSTRAINT [FK_Feedback_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]);


GO
PRINT N'Creating [dbo].[FK_Feedback_Users]...';


GO
ALTER TABLE [dbo].[Feedback]
    ADD CONSTRAINT [FK_Feedback_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_OrderDetails_Product]...';


GO
ALTER TABLE [dbo].[OrderDetails]
    ADD CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]);


GO
PRINT N'Creating [dbo].[FK_Orders_OrderDetails]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_OrderDetails] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[OrderDetails] ([OrderId]);


GO
PRINT N'Creating [dbo].[FK_Orders_Users]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_Orders_PaymentDetails]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_PaymentDetails] FOREIGN KEY ([PaymentId]) REFERENCES [dbo].[PaymentDetails] ([PaymentId]);


GO
PRINT N'Creating [dbo].[FK_PaymentDetails_PaymentMode]...';


GO
ALTER TABLE [dbo].[PaymentDetails]
    ADD CONSTRAINT [FK_PaymentDetails_PaymentMode] FOREIGN KEY ([PaymentTypeId]) REFERENCES [dbo].[PaymentType] ([PaymentTypeId]);


GO
PRINT N'Creating [dbo].[FK_UserAddress_Users]...';


GO
ALTER TABLE [dbo].[UserAddress]
    ADD CONSTRAINT [FK_UserAddress_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_Users_UserRoles]...';


GO
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[UserRoles] ([RoleId]);


GO
PRINT N'Creating [dbo].[FK_WishList_Users]...';


GO
ALTER TABLE [dbo].[WishList]
    ADD CONSTRAINT [FK_WishList_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_WishList_Product]...';


GO
ALTER TABLE [dbo].[WishList]
    ADD CONSTRAINT [FK_WishList_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]);


GO
PRINT N'Creating [dbo].[AddProduct]...';


GO
CREATE PROCEDURE [dbo].[AddProduct]
	@Name varchar(30),
	@Rating decimal(2,1),
	@ManufactureDate date,
	@CartDescription varchar(100),
	@ShortDescription varchar(MAX),
	@Image varchar(100),
	@MRP decimal(18,2),
	@DealPrice decimal(18,2),
	@SavePrice decimal(10,2),
	@NoOfStock int
	
AS
	INSERT into Product values(@Name,@Rating,@ManufactureDate,@CartDescription,@ShortDescription,
	@Image,@MRP,@DealPrice,@SavePrice,@NoOfStock)
RETURN
GO
PRINT N'Creating [dbo].[DeleteProduct]...';


GO
CREATE PROCEDURE [dbo].[DeleteProduct]
	@ProductId int
AS
	DELETE from [dbo].[Product] where ProductId=@ProductId
RETURN
GO
PRINT N'Creating [dbo].[DeleteRoleIdFromUserRoles]...';


GO
CREATE PROCEDURE [dbo].[DeleteRoleIdFromUserRoles]
	@RoleId int
AS
	DELETE from [dbo].[UserRoles] where RoleId=@RoleId
RETURN 0
GO
PRINT N'Creating [dbo].[DeleteRoleIdFromUsers]...';


GO
CREATE PROCEDURE [dbo].[DeleteRoleIdFromUsers]
	@RoleId int
AS
	DELETE from [dbo].[Users] where RoleId=@RoleId
RETURN 0
GO
PRINT N'Creating [dbo].[DeleteUserIdFromUserAddress]...';


GO
CREATE PROCEDURE [dbo].[DeleteUserIdFromUserAddress]
	@RoleId int
AS
	DELETE from [dbo].[UserAddress] where UserId in(select UserId
	from [dbo].[Users] where RoleId=@RoleId)
RETURN
GO
PRINT N'Creating [dbo].[GetByPaymentTypeId]...';


GO
CREATE PROCEDURE [dbo].[GetByPaymentTypeId]
	@PaymentType varchar(20)
AS
	SELECT PaymentTypeId from [dbo].[PaymentType]
	where PaymentType=@PaymentType

	
RETURN
GO
PRINT N'Creating [dbo].[InsertFeedback]...';


GO
CREATE PROCEDURE [dbo].[InsertFeedback]
	@ProductId int,
	@UserId int,
	@Feedback varchar(MAX),
	@Rating decimal(2,1)
AS
	INSERT into [dbo].[Feedback] values(@ProductId,@UserId,@Feedback,@Rating)
RETURN
GO
PRINT N'Creating [dbo].[InsertIntoWishList]...';


GO
CREATE PROCEDURE [dbo].[InsertIntoWishList]
	@UserId int,
	@ProductId int,
	@DateofCartAdd int
AS
	INSERT into [dbo].[WishList] values(
	@UserId,
	@ProductId,
	GETDATE())
RETURN
GO
PRINT N'Creating [dbo].[InsertPayments]...';


GO
CREATE PROCEDURE [dbo].[InsertPayments]
	@PaymentTypeId int,
	@CardNumber varchar(16),
	@ExpiryDate date,
	@CVV int,
	@Amount decimal(18,2),
	@DateOfPayment date

AS
	IF @PaymentTypeId=1

	BEGIN
	insert into [dbo].[PaymentDetails] values(@CardNumber,
	@PaymentTypeId,@ExpiryDate,@CVV,@Amount,GETDATE())
	END

	IF @PaymentTypeId=2

	BEGIN
	insert into [dbo].[PaymentDetails] values(@CardNumber,
	@PaymentTypeId,@ExpiryDate,@CVV,@Amount,GETDATE())
	END

	IF @PaymentTypeId=3

	BEGIN
	insert into [dbo].PaymentDetails values('','','','',@Amount,GETDATE())
	END
RETURN
GO
PRINT N'Creating [dbo].[InsertPaymentType]...';


GO
CREATE PROCEDURE [dbo].[InsertPaymentType]
	@PaymentType varchar(20)
AS
	INSERT into [dbo].[PaymentType] values(@PaymentType)
RETURN
GO
PRINT N'Creating [dbo].[InsertUserRoles]...';


GO
CREATE PROCEDURE [dbo].[InsertUserRoles]
	@RoleDescription varchar(20),
	@RoleNumber int,
	@CreatedDate date,
	@ModifiedDate date,
	@RoleIsActive bit
AS
	INSERT into [dbo].[UserRoles] values (@RoleDescription,@RoleNumber,GETDATE(),
	Getdate(),@RoleIsActive)
RETURN 0
GO
PRINT N'Creating [dbo].[Register]...';


GO
CREATE PROCEDURE [dbo].[Register]
	@Name varchar(30),
	@RoleId int,
	@MobileNumber varchar(15),
	@DateOfBirth date,
	@Gender varchar(10),
	@EmailId varchar(30),
	@Password varchar(20),
	@CreatedDate date,
	@ModifiedDate date,
	@UserIsActive bit
AS
	INSERT into Product values(@Name,@RoleId,@MobileNumber,@DateOfBirth,@Gender,
	@EmailId,@Password,GETDATE(),GETDATE(),@UserIsActive)
RETURN 0
GO
PRINT N'Creating [dbo].[RemoveFromWishList]...';


GO
CREATE PROCEDURE [dbo].[RemoveFromWishList]
	@UserId int,
	@ProdcutId int
AS
	DELETE from [dbo].[WishList] where UserId=@UserId and 
	ProductId=@ProdcutId
RETURN
GO
PRINT N'Creating [dbo].[SearchProduct]...';


GO
CREATE PROCEDURE [dbo].[SearchProduct]
	@ProductName varchar(30)
AS
	SELECT * from [dbo].[Product] where [Name ] like '%' 
	+@ProductName+ '%'
RETURN
GO
PRINT N'Creating [dbo].[UpdateNewPassword]...';


GO
CREATE PROCEDURE [dbo].[UpdateNewPassword]
	@NewPassword varchar(20),
	@EmailId varchar(30),
	@MobileNumber varchar(15),
	@UserId int
AS
	UPDATE [dbo].[Users] set Password=@NewPassword
	where UserId=@UserId and EmailId=@EmailId OR 
	MobileNumber=@MobileNumber
RETURN 0
GO
PRINT N'Creating [dbo].[UpdateProduct]...';


GO
CREATE PROCEDURE [dbo].[UpdateProduct]
	@Name varchar(30),
	@Rating decimal(2,1),
	@ManufactureDate date,
	@CartDescription varchar(100),
	@ShortDescription varchar(MAX),
	@Image varchar(100),
	@MRP decimal(18,2),
	@DealPrice decimal(18,2),
	@SavePrice decimal(10,2),
	@NoOfStock int
AS
	update [dbo].[Product] set 
	[Name ]=@Name,
	[Rating]=@Rating,
	[ManufactureDate]=@ManufactureDate,
	[CartDescription]=@CartDescription,
	[ShortDescription]=@ShortDescription,
	[Image]=@Image,
	[MRP]=@MRP,
	[DealPrice]=@DealPrice,
	[SavePrice]=@SavePrice,
	[NoOfStock]=@NoOfStock
RETURN
GO
PRINT N'Creating [dbo].[UserLogin]...';


GO
CREATE PROCEDURE [dbo].[UserLogin]
	@EmailId varchar(30),
	@MobileNumber varchar(15),
	@Password varchar(20)
AS
	SELECT * from [dbo].[Users] where EmailId=@EmailId
	AND Password=@Password OR
	MobileNumber=@MobileNumber
	AND Password=@Password
RETURN 0
GO
PRINT N'Creating [dbo].[ViewProductById]...';


GO
CREATE PROCEDURE [dbo].[ViewProductById]
	@ProductId int
AS
	SELECT * from [dbo].[Product] where ProductId=@ProductId
RETURN 0
GO
PRINT N'Creating [dbo].[ViewProducts]...';


GO
CREATE PROCEDURE [dbo].[ViewProducts]
	
AS
	SELECT * from [dbo].[Product]
RETURN 0
GO
PRINT N'Creating [dbo].[ViewUsers]...';


GO
CREATE PROCEDURE [dbo].[ViewUsers]
	@RoleNumber int
AS
	SELECT * from [dbo].[UserAddress] userAddress 
	INNER JOIN [dbo].[Users] users on userAddress.UserId=users.UserId
	INNER JOIN [dbo].[UserRoles] userRoles on users.RoleId=userRoles.RoleId
	where RoleNumber=@RoleNumber
RETURN
GO
PRINT N'Creating [dbo].[ViewWishList]...';


GO
CREATE PROCEDURE [dbo].[ViewWishList]
	@UserId int
AS
	SELECT * from [dbo].[Product] product 
	INNER JOIN [dbo].[WishList] wishList on product.ProductId=wishList.ProductId
where UserId=@UserId
RETURN 0
GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '58e54d96-3a5b-4309-ab34-32a00f308e8d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('58e54d96-3a5b-4309-ab34-32a00f308e8d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b1b6d2d1-c7e1-47d4-be32-3ad864420744')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b1b6d2d1-c7e1-47d4-be32-3ad864420744')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ad72d6f8-8497-4ade-89f5-417a8c7e078f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ad72d6f8-8497-4ade-89f5-417a8c7e078f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '17ee80ea-b52f-4fde-b85e-437957400b3b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('17ee80ea-b52f-4fde-b85e-437957400b3b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a675e0f5-ab04-412e-9f42-7fda088ca6ba')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a675e0f5-ab04-412e-9f42-7fda088ca6ba')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a2a5070f-ffee-435b-9298-d3cded1f7f75')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a2a5070f-ffee-435b-9298-d3cded1f7f75')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '21549744-6062-4201-bfbf-d3472c8a913a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('21549744-6062-4201-bfbf-d3472c8a913a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e716a0cc-23b4-40d9-b78c-1f1a00fc56c9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e716a0cc-23b4-40d9-b78c-1f1a00fc56c9')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'fcca03b3-e866-43a3-8075-4a78f1144ce0')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('fcca03b3-e866-43a3-8075-4a78f1144ce0')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '20f1a651-766f-4580-8c7b-20305c8b9a73')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('20f1a651-766f-4580-8c7b-20305c8b9a73')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8c243622-365a-4684-b320-12b2b8744334')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8c243622-365a-4684-b320-12b2b8744334')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f2746ab4-9dfe-4f95-8751-2f1be5688253')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f2746ab4-9dfe-4f95-8751-2f1be5688253')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a9d1d803-a871-4b02-867a-dbea37f4f609')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a9d1d803-a871-4b02-867a-dbea37f4f609')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd37cf8b5-a829-4177-aad8-106734735464')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d37cf8b5-a829-4177-aad8-106734735464')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e9ec6e91-150d-4b10-9825-a59a9d9b2d82')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e9ec6e91-150d-4b10-9825-a59a9d9b2d82')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '703b811d-bd8c-440b-ad40-e81f6467f4d7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('703b811d-bd8c-440b-ad40-e81f6467f4d7')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5da5d7d2-2756-440d-b6c4-8d8d947739ca')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5da5d7d2-2756-440d-b6c4-8d8d947739ca')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6dc5ab6a-6582-45bf-8e5f-d7145814892e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6dc5ab6a-6582-45bf-8e5f-d7145814892e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'fb3315e6-1a03-436d-b39a-fea49c252a41')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('fb3315e6-1a03-436d-b39a-fea49c252a41')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e1475697-2a21-44de-826a-7079f078fbde')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e1475697-2a21-44de-826a-7079f078fbde')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f8db7497-4379-4334-82fd-4362f4ef2276')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f8db7497-4379-4334-82fd-4362f4ef2276')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5f12160e-5541-4ed3-8a77-8a47dcced97a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5f12160e-5541-4ed3-8a77-8a47dcced97a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9c2eff06-e11b-42c7-8f65-269c7053a46f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9c2eff06-e11b-42c7-8f65-269c7053a46f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '852f6370-1445-4028-a118-467d7a916532')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('852f6370-1445-4028-a118-467d7a916532')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6994001d-62db-43ac-86d8-6fcfff41dba7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6994001d-62db-43ac-86d8-6fcfff41dba7')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4b0bef29-612d-4fad-bbc5-b3da0b1576eb')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4b0bef29-612d-4fad-bbc5-b3da0b1576eb')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e802d517-c5dd-412a-832c-ccce280451cc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e802d517-c5dd-412a-832c-ccce280451cc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7e411333-152b-4305-bf74-c5350d9eb234')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7e411333-152b-4305-bf74-c5350d9eb234')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'dfeebb1c-b29c-45a5-87aa-7df110d16fe4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('dfeebb1c-b29c-45a5-87aa-7df110d16fe4')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
