
 -- INSERT DATA
  
        
        
        
        
        
            -- INSERT: Galaxy
            --  STATIC: 
            --  Rows: 3
            --  only-static-data: false
            
        
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT GalaxyId FROM Galaxy WHERE GalaxyId = 'recH4wXkMEd5S4pUf')
                    BEGIN
                        INSERT INTO [Galaxy] ([GalaxyId] , [createdTime] , [Name] , [HaveVisited] , [Notes] ) VALUES (
                        
                                'recH4wXkMEd5S4pUf', 
                        
                                '2018-05-15T16:19:00Z', 
                        
                                'Milky Way', 
                        
                                'true', 
                        
                                'This is the milky way...
');
                    END ELSE BEGIN
                        UPDATE  [Galaxy] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:00Z', 
                                [Name] = 'Milky Way', 
                                [HaveVisited] = 'true', 
                                [Notes] = 'This is the milky way...
'
                        WHERE GalaxyId = 'recH4wXkMEd5S4pUf';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT GalaxyId FROM Galaxy WHERE GalaxyId = 'reco5yAJlcUMSsWyf')
                    BEGIN
                        INSERT INTO [Galaxy] ([GalaxyId] , [createdTime] , [Name] , [HaveVisited] , [Notes] ) VALUES (
                        
                                'reco5yAJlcUMSsWyf', 
                        
                                '2018-05-15T16:19:00Z', 
                        
                                'Andromeda', 
                        
                                NULL, 
                        
                                'asdfasd
');
                    END ELSE BEGIN
                        UPDATE  [Galaxy] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:00Z', 
                                [Name] = 'Andromeda', 
                                [HaveVisited] = NULL, 
                                [Notes] = 'asdfasd
'
                        WHERE GalaxyId = 'reco5yAJlcUMSsWyf';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT GalaxyId FROM Galaxy WHERE GalaxyId = 'recxdClgul2sqgv4i')
                    BEGIN
                        INSERT INTO [Galaxy] ([GalaxyId] , [createdTime] , [Name] , [HaveVisited] , [Notes] ) VALUES (
                        
                                'recxdClgul2sqgv4i', 
                        
                                '2018-05-25T22:27:55Z', 
                        
                                'Some Other Galax', 
                        
                                NULL, 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Galaxy] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:55Z', 
                                [Name] = 'Some Other Galax', 
                                [HaveVisited] = NULL, 
                                [Notes] = NULL
                        WHERE GalaxyId = 'recxdClgul2sqgv4i';
                    END
                
            
 
        
        
        
        
        
            -- INSERT: Astronomer
            --  STATIC: 
            --  Rows: 3
            --  only-static-data: false
            
        
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT AstronomerId FROM Astronomer WHERE AstronomerId = 'rec9gnOWBVCMa3zwB')
                    BEGIN
                        INSERT INTO [Astronomer] ([AstronomerId] , [createdTime] , [DOB] , [Name] ) VALUES (
                        
                                'rec9gnOWBVCMa3zwB', 
                        
                                '2018-06-18T00:48:05Z', 
                        
                                NULL, 
                        
                                'Someone Else');
                    END ELSE BEGIN
                        UPDATE  [Astronomer] 
                            SET 
                                [createdTime] = '2018-06-18T00:48:05Z', 
                                [DOB] = NULL, 
                                [Name] = 'Someone Else'
                        WHERE AstronomerId = 'rec9gnOWBVCMa3zwB';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT AstronomerId FROM Astronomer WHERE AstronomerId = 'reccqYz7vYutdrXWQ')
                    BEGIN
                        INSERT INTO [Astronomer] ([AstronomerId] , [createdTime] , [DOB] , [Name] ) VALUES (
                        
                                'reccqYz7vYutdrXWQ', 
                        
                                '2018-06-18T00:48:05Z', 
                        
                                NULL, 
                        
                                'Another Guy');
                    END ELSE BEGIN
                        UPDATE  [Astronomer] 
                            SET 
                                [createdTime] = '2018-06-18T00:48:05Z', 
                                [DOB] = NULL, 
                                [Name] = 'Another Guy'
                        WHERE AstronomerId = 'reccqYz7vYutdrXWQ';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT AstronomerId FROM Astronomer WHERE AstronomerId = 'recuwCgXwqQFaLgym')
                    BEGIN
                        INSERT INTO [Astronomer] ([AstronomerId] , [createdTime] , [DOB] , [Name] ) VALUES (
                        
                                'recuwCgXwqQFaLgym', 
                        
                                '2018-06-18T00:48:05Z', 
                        
                                '5/2/1580', 
                        
                                'Galilao');
                    END ELSE BEGIN
                        UPDATE  [Astronomer] 
                            SET 
                                [createdTime] = '2018-06-18T00:48:05Z', 
                                [DOB] = '5/2/1580', 
                                [Name] = 'Galilao'
                        WHERE AstronomerId = 'recuwCgXwqQFaLgym';
                    END
                
            
 
        
        
        
        
        
            -- INSERT: Star
            --  STATIC: 
            --  Rows: 6
            --  only-static-data: false
            
        
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'rec4OZu12JfXa8NhZ')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [Name] , [Notes] ) VALUES (
                        
                                'rec4OZu12JfXa8NhZ', 
                        
                                '2018-05-15T16:19:47Z', 
                        
                                'Earths Sun', 
                        
                                'fdfdsfdsf
');
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:47Z', 
                                [Name] = 'Earths Sun', 
                                [Notes] = 'fdfdsfdsf
'
                        WHERE StarId = 'rec4OZu12JfXa8NhZ';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'rec99vLonTpbG6fZS')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [Name] , [Notes] ) VALUES (
                        
                                'rec99vLonTpbG6fZS', 
                        
                                '2018-05-15T16:19:47Z', 
                        
                                'Alpha Centauri', 
                        
                                'dfdfd
');
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:47Z', 
                                [Name] = 'Alpha Centauri', 
                                [Notes] = 'dfdfd
'
                        WHERE StarId = 'rec99vLonTpbG6fZS';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'recgMrUvkZ0XAlHax')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [Name] , [Notes] ) VALUES (
                        
                                'recgMrUvkZ0XAlHax', 
                        
                                '2018-05-25T22:27:07Z', 
                        
                                'Star 5', 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:07Z', 
                                [Name] = 'Star 5', 
                                [Notes] = NULL
                        WHERE StarId = 'recgMrUvkZ0XAlHax';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'reckXigFuEaoPr8k8')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [Name] , [Notes] ) VALUES (
                        
                                'reckXigFuEaoPr8k8', 
                        
                                '2018-05-15T16:19:47Z', 
                        
                                'Some Other Star', 
                        
                                'fdfds');
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:47Z', 
                                [Name] = 'Some Other Star', 
                                [Notes] = 'fdfds'
                        WHERE StarId = 'reckXigFuEaoPr8k8';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'recutl0fSpATFivMb')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [Name] , [Notes] ) VALUES (
                        
                                'recutl0fSpATFivMb', 
                        
                                '2018-05-25T22:27:04Z', 
                        
                                'Some Other Galax', 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:04Z', 
                                [Name] = 'Some Other Galax', 
                                [Notes] = NULL
                        WHERE StarId = 'recutl0fSpATFivMb';
                    END
                

                    -- INSERT VALUES
                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'recxrcWyXxL6KA83R')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [Name] , [Notes] ) VALUES (
                        
                                'recxrcWyXxL6KA83R', 
                        
                                '2018-05-25T22:27:07Z', 
                        
                                'Another galaxy', 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:07Z', 
                                [Name] = 'Another galaxy', 
                                [Notes] = NULL
                        WHERE StarId = 'recxrcWyXxL6KA83R';
                    END
                
            
 

-- ADD RELATIONSHIPS
   
        
        
        
        
        
            -- ADD ALL DATA FOR: Galaxy
            --  STATIC: 
            --  Rows: 3
            --  only-static-data: false
            
        
                

                    IF NOT EXISTS (SELECT GalaxyId FROM Galaxy WHERE GalaxyId = 'recH4wXkMEd5S4pUf')
                    BEGIN
                        INSERT INTO [Galaxy] ([GalaxyId] , [createdTime] , [Name] , [HaveVisited] , [Notes] ) VALUES (
                        
                                'recH4wXkMEd5S4pUf', 
                        
                                '2018-05-15T16:19:00Z', 
                        
                                'Milky Way', 
                        
                                'true', 
                        
                                'This is the milky way...
');
                    END ELSE BEGIN
                        UPDATE  [Galaxy] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:00Z', 
                                [Name] = 'Milky Way', 
                                [HaveVisited] = 'true', 
                                [Notes] = 'This is the milky way...
'
                        WHERE GalaxyId = 'recH4wXkMEd5S4pUf';
                    END
                

                    IF NOT EXISTS (SELECT GalaxyId FROM Galaxy WHERE GalaxyId = 'reco5yAJlcUMSsWyf')
                    BEGIN
                        INSERT INTO [Galaxy] ([GalaxyId] , [createdTime] , [Name] , [HaveVisited] , [Notes] ) VALUES (
                        
                                'reco5yAJlcUMSsWyf', 
                        
                                '2018-05-15T16:19:00Z', 
                        
                                'Andromeda', 
                        
                                NULL, 
                        
                                'asdfasd
');
                    END ELSE BEGIN
                        UPDATE  [Galaxy] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:00Z', 
                                [Name] = 'Andromeda', 
                                [HaveVisited] = NULL, 
                                [Notes] = 'asdfasd
'
                        WHERE GalaxyId = 'reco5yAJlcUMSsWyf';
                    END
                

                    IF NOT EXISTS (SELECT GalaxyId FROM Galaxy WHERE GalaxyId = 'recxdClgul2sqgv4i')
                    BEGIN
                        INSERT INTO [Galaxy] ([GalaxyId] , [createdTime] , [Name] , [HaveVisited] , [Notes] ) VALUES (
                        
                                'recxdClgul2sqgv4i', 
                        
                                '2018-05-25T22:27:55Z', 
                        
                                'Some Other Galax', 
                        
                                NULL, 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Galaxy] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:55Z', 
                                [Name] = 'Some Other Galax', 
                                [HaveVisited] = NULL, 
                                [Notes] = NULL
                        WHERE GalaxyId = 'recxdClgul2sqgv4i';
                    END
                
            
 
        
        
        
        
        
            -- ADD ALL DATA FOR: Astronomer
            --  STATIC: 
            --  Rows: 3
            --  only-static-data: false
            
        
                

                    IF NOT EXISTS (SELECT AstronomerId FROM Astronomer WHERE AstronomerId = 'rec9gnOWBVCMa3zwB')
                    BEGIN
                        INSERT INTO [Astronomer] ([AstronomerId] , [createdTime] , [DOB] , [Name] ) VALUES (
                        
                                'rec9gnOWBVCMa3zwB', 
                        
                                '2018-06-18T00:48:05Z', 
                        
                                NULL, 
                        
                                'Someone Else');
                    END ELSE BEGIN
                        UPDATE  [Astronomer] 
                            SET 
                                [createdTime] = '2018-06-18T00:48:05Z', 
                                [DOB] = NULL, 
                                [Name] = 'Someone Else'
                        WHERE AstronomerId = 'rec9gnOWBVCMa3zwB';
                    END
                

                    IF NOT EXISTS (SELECT AstronomerId FROM Astronomer WHERE AstronomerId = 'reccqYz7vYutdrXWQ')
                    BEGIN
                        INSERT INTO [Astronomer] ([AstronomerId] , [createdTime] , [DOB] , [Name] ) VALUES (
                        
                                'reccqYz7vYutdrXWQ', 
                        
                                '2018-06-18T00:48:05Z', 
                        
                                NULL, 
                        
                                'Another Guy');
                    END ELSE BEGIN
                        UPDATE  [Astronomer] 
                            SET 
                                [createdTime] = '2018-06-18T00:48:05Z', 
                                [DOB] = NULL, 
                                [Name] = 'Another Guy'
                        WHERE AstronomerId = 'reccqYz7vYutdrXWQ';
                    END
                

                    IF NOT EXISTS (SELECT AstronomerId FROM Astronomer WHERE AstronomerId = 'recuwCgXwqQFaLgym')
                    BEGIN
                        INSERT INTO [Astronomer] ([AstronomerId] , [createdTime] , [DOB] , [Name] ) VALUES (
                        
                                'recuwCgXwqQFaLgym', 
                        
                                '2018-06-18T00:48:05Z', 
                        
                                '5/2/1580', 
                        
                                'Galilao');
                    END ELSE BEGIN
                        UPDATE  [Astronomer] 
                            SET 
                                [createdTime] = '2018-06-18T00:48:05Z', 
                                [DOB] = '5/2/1580', 
                                [Name] = 'Galilao'
                        WHERE AstronomerId = 'recuwCgXwqQFaLgym';
                    END
                
            
 
        
        
        
        
        
            -- ADD ALL DATA FOR: Star
            --  STATIC: 
            --  Rows: 6
            --  only-static-data: false
            
        
                

                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'rec4OZu12JfXa8NhZ')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [FoundBy] , [Galaxy] , [Name] , [Notes] ) VALUES (
                        
                                'rec4OZu12JfXa8NhZ', 
                        
                                '2018-05-15T16:19:47Z', 
                        
                                'recuwCgXwqQFaLgym', 
                        
                                'recH4wXkMEd5S4pUf', 
                        
                                'Earths Sun', 
                        
                                'fdfdsfdsf
');
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:47Z', 
                                [FoundBy] = 'recuwCgXwqQFaLgym', 
                                [Galaxy] = 'recH4wXkMEd5S4pUf', 
                                [Name] = 'Earths Sun', 
                                [Notes] = 'fdfdsfdsf
'
                        WHERE StarId = 'rec4OZu12JfXa8NhZ';
                    END
                

                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'rec99vLonTpbG6fZS')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [FoundBy] , [Galaxy] , [Name] , [Notes] ) VALUES (
                        
                                'rec99vLonTpbG6fZS', 
                        
                                '2018-05-15T16:19:47Z', 
                        
                                'rec9gnOWBVCMa3zwB', 
                        
                                'reco5yAJlcUMSsWyf', 
                        
                                'Alpha Centauri', 
                        
                                'dfdfd
');
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:47Z', 
                                [FoundBy] = 'rec9gnOWBVCMa3zwB', 
                                [Galaxy] = 'reco5yAJlcUMSsWyf', 
                                [Name] = 'Alpha Centauri', 
                                [Notes] = 'dfdfd
'
                        WHERE StarId = 'rec99vLonTpbG6fZS';
                    END
                

                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'recgMrUvkZ0XAlHax')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [FoundBy] , [Galaxy] , [Name] , [Notes] ) VALUES (
                        
                                'recgMrUvkZ0XAlHax', 
                        
                                '2018-05-25T22:27:07Z', 
                        
                                NULL, 
                        
                                NULL, 
                        
                                'Star 5', 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:07Z', 
                                [FoundBy] = NULL, 
                                [Galaxy] = NULL, 
                                [Name] = 'Star 5', 
                                [Notes] = NULL
                        WHERE StarId = 'recgMrUvkZ0XAlHax';
                    END
                

                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'reckXigFuEaoPr8k8')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [FoundBy] , [Galaxy] , [Name] , [Notes] ) VALUES (
                        
                                'reckXigFuEaoPr8k8', 
                        
                                '2018-05-15T16:19:47Z', 
                        
                                'recuwCgXwqQFaLgym', 
                        
                                'recH4wXkMEd5S4pUf', 
                        
                                'Some Other Star', 
                        
                                'fdfds');
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-15T16:19:47Z', 
                                [FoundBy] = 'recuwCgXwqQFaLgym', 
                                [Galaxy] = 'recH4wXkMEd5S4pUf', 
                                [Name] = 'Some Other Star', 
                                [Notes] = 'fdfds'
                        WHERE StarId = 'reckXigFuEaoPr8k8';
                    END
                

                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'recutl0fSpATFivMb')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [FoundBy] , [Galaxy] , [Name] , [Notes] ) VALUES (
                        
                                'recutl0fSpATFivMb', 
                        
                                '2018-05-25T22:27:04Z', 
                        
                                NULL, 
                        
                                'recxdClgul2sqgv4i', 
                        
                                'Some Other Galax', 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:04Z', 
                                [FoundBy] = NULL, 
                                [Galaxy] = 'recxdClgul2sqgv4i', 
                                [Name] = 'Some Other Galax', 
                                [Notes] = NULL
                        WHERE StarId = 'recutl0fSpATFivMb';
                    END
                

                    IF NOT EXISTS (SELECT StarId FROM Star WHERE StarId = 'recxrcWyXxL6KA83R')
                    BEGIN
                        INSERT INTO [Star] ([StarId] , [createdTime] , [FoundBy] , [Galaxy] , [Name] , [Notes] ) VALUES (
                        
                                'recxrcWyXxL6KA83R', 
                        
                                '2018-05-25T22:27:07Z', 
                        
                                NULL, 
                        
                                'reco5yAJlcUMSsWyf', 
                        
                                'Another galaxy', 
                        
                                NULL);
                    END ELSE BEGIN
                        UPDATE  [Star] 
                            SET 
                                [createdTime] = '2018-05-25T22:27:07Z', 
                                [FoundBy] = NULL, 
                                [Galaxy] = 'reco5yAJlcUMSsWyf', 
                                [Name] = 'Another galaxy', 
                                [Notes] = NULL
                        WHERE StarId = 'recxrcWyXxL6KA83R';
                    END
                
            
 
                