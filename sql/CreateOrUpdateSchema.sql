
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO
    
    
      -- TABLE: Galaxy
      -- TABLE: Astronomer
      -- TABLE: Star

      -- CREATE DATABASE
      IF NOT EXISTS (SELECT * from sys.databases WHERE name = 'helloworld')
      BEGIN
          CREATE DATABASE [helloworld];
      END
        GO
        
     USE [helloworld];
GO
      
        -- TABLE: Galaxy
        -- ****** Object:  Table [dbo].[Galaxy]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Galaxy]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Galaxy] (
          [GalaxyId] NVARCHAR(150) NOT NULL
          -- TEXT.
        ,
          [createdTime] DATETIME NULL
          -- DATETIME.
        ,
          [FirstSeen] INT NULL
          -- SHORT.
        ,
          [Name] NVARCHAR(150) NULL
          -- TEXT.
        ,
          [HaveVisited] BIT NULL
          -- BOOLEAN.
        ,
          [Notes] NVARCHAR(150) NULL
          -- TEXT.
        ,
        
        CONSTRAINT [PK_Galaxy] PRIMARY KEY CLUSTERED
          (
            [GalaxyId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Astronomer
        -- ****** Object:  Table [dbo].[Astronomer]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Astronomer]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Astronomer] (
          [AstronomerId] NVARCHAR(150) NOT NULL
          -- TEXT.
        ,
          [createdTime] DATETIME NULL
          -- DATETIME.
        ,
          [Name] NVARCHAR(150) NULL
          -- TEXT.
        ,
        
        CONSTRAINT [PK_Astronomer] PRIMARY KEY CLUSTERED
          (
            [AstronomerId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Star
        -- ****** Object:  Table [dbo].[Star]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Star]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Star] (
          [StarId] NVARCHAR(150) NOT NULL
          -- TEXT.
        ,
          [createdTime] DATETIME NULL
          -- DATETIME.
        ,
          [FoundBy] NVARCHAR(150) NULL
          -- TEXT.
        ,
          [NasaID] NVARCHAR(150) NULL
          -- TEXT.
        ,
          [Galaxy] NVARCHAR(150) NULL
          -- TEXT.
        ,
          [Name] NVARCHAR(150) NULL
          -- TEXT.
        ,
          [Notes] NVARCHAR(150) NULL
          -- TEXT.
        ,
        
        CONSTRAINT [PK_Star] PRIMARY KEY CLUSTERED
          (
            [StarId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO


      
DECLARE @ObjectName NVARCHAR(100)

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'GalaxyId' AND Object_ID = Object_ID(N'Galaxy'))
    BEGIN
            ALTER TABLE [dbo].[Galaxy] ADD [GalaxyId] NVARCHAR(150) NULL;
    END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'createdTime' AND Object_ID = Object_ID(N'Galaxy'))
    BEGIN
            ALTER TABLE [dbo].[Galaxy] ADD [createdTime] DATETIME NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Galaxy] ALTER COLUMN [createdTime] DATETIME NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'FirstSeen' AND Object_ID = Object_ID(N'Galaxy'))
    BEGIN
            ALTER TABLE [dbo].[Galaxy] ADD [FirstSeen] INT NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Galaxy] ALTER COLUMN [FirstSeen] INT NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Galaxy'))
    BEGIN
            ALTER TABLE [dbo].[Galaxy] ADD [Name] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Galaxy] ALTER COLUMN [Name] NVARCHAR(150) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'HaveVisited' AND Object_ID = Object_ID(N'Galaxy'))
    BEGIN
            ALTER TABLE [dbo].[Galaxy] ADD [HaveVisited] BIT NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Galaxy] ALTER COLUMN [HaveVisited] BIT NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Notes' AND Object_ID = Object_ID(N'Galaxy'))
    BEGIN
            ALTER TABLE [dbo].[Galaxy] ADD [Notes] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Galaxy] ALTER COLUMN [Notes] NVARCHAR(150) NULL;

    

	END

    
    -- COUNT: 4
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AstronomerId' AND Object_ID = Object_ID(N'Astronomer'))
    BEGIN
            ALTER TABLE [dbo].[Astronomer] ADD [AstronomerId] NVARCHAR(150) NULL;
    END

    
    -- COUNT: 4
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'createdTime' AND Object_ID = Object_ID(N'Astronomer'))
    BEGIN
            ALTER TABLE [dbo].[Astronomer] ADD [createdTime] DATETIME NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Astronomer] ALTER COLUMN [createdTime] DATETIME NULL;

    

	END

    
    -- COUNT: 4
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Astronomer'))
    BEGIN
            ALTER TABLE [dbo].[Astronomer] ADD [Name] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Astronomer] ALTER COLUMN [Name] NVARCHAR(150) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'StarId' AND Object_ID = Object_ID(N'Star'))
    BEGIN
            ALTER TABLE [dbo].[Star] ADD [StarId] NVARCHAR(150) NULL;
    END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'createdTime' AND Object_ID = Object_ID(N'Star'))
    BEGIN
            ALTER TABLE [dbo].[Star] ADD [createdTime] DATETIME NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Star] ALTER COLUMN [createdTime] DATETIME NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'FoundBy' AND Object_ID = Object_ID(N'Star'))
    BEGIN
            ALTER TABLE [dbo].[Star] ADD [FoundBy] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Star] ALTER COLUMN [FoundBy] NVARCHAR(150) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NasaID' AND Object_ID = Object_ID(N'Star'))
    BEGIN
            ALTER TABLE [dbo].[Star] ADD [NasaID] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Star] ALTER COLUMN [NasaID] NVARCHAR(150) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Galaxy' AND Object_ID = Object_ID(N'Star'))
    BEGIN
            ALTER TABLE [dbo].[Star] ADD [Galaxy] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Star] ALTER COLUMN [Galaxy] NVARCHAR(150) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Star'))
    BEGIN
            ALTER TABLE [dbo].[Star] ADD [Name] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Star] ALTER COLUMN [Name] NVARCHAR(150) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Notes' AND Object_ID = Object_ID(N'Star'))
    BEGIN
            ALTER TABLE [dbo].[Star] ADD [Notes] NVARCHAR(150) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Star] ALTER COLUMN [Notes] NVARCHAR(150) NULL;

    

	END

    

              -- ****** KEYS FOR Table [dbo].[Galaxy]

              -- ****** KEYS FOR Table [dbo].[Astronomer]

              -- ****** KEYS FOR Table [dbo].[Star]
          -- FK for FoundBy :: 0 :: Star :: Astronomer
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Star_Astronomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Star]'))
              IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Star_Astronomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Star]'))
                ALTER TABLE [dbo].[Star]  WITH CHECK ADD  CONSTRAINT [FK_Star_Astronomer] FOREIGN KEY([FoundBy])
                    REFERENCES [dbo].[Astronomer] (AstronomerId)
                GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Star_Astronomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Star]'))
            ALTER TABLE [dbo].[Star] CHECK CONSTRAINT [FK_Star_Astronomer]
            GO
          
          -- FK for Galaxy :: 0 :: Star :: Galaxy
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Star_Galaxy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Star]'))
              IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Star_Galaxy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Star]'))
                ALTER TABLE [dbo].[Star]  WITH CHECK ADD  CONSTRAINT [FK_Star_Galaxy] FOREIGN KEY([Galaxy])
                    REFERENCES [dbo].[Galaxy] (GalaxyId)
                GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Star_Galaxy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Star]'))
            ALTER TABLE [dbo].[Star] CHECK CONSTRAINT [FK_Star_Galaxy]
            GO
          


            SELECT 'Successful' as Value
            FROM (SELECT NULL AS FIELD) as Result
            FOR XML AUTO

          