--USE master;
--ALTER TABLE ad_images DROP CONSTRAINT FK_ad_images_listing_id;
--ALTER TABLE Interact ALTER COLUMN Rating INT;
SELECT AVG(rating) AS rating FROM interact WHERE listing_id = 1;