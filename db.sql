CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `BlogPosts` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Summary` varchar(500) CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ImagePath` varchar(200) CHARACTER SET utf8mb4 NULL,
    `ImageUrl` varchar(200) CHARACTER SET utf8mb4 NULL,
    `Tags` varchar(100) CHARACTER SET utf8mb4 NULL,
    `SeoTitle` varchar(100) CHARACTER SET utf8mb4 NULL,
    `SeoDescription` varchar(200) CHARACTER SET utf8mb4 NULL,
    `SeoKeywords` varchar(100) CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `IsPublished` tinyint(1) NOT NULL,
    `IsFeatured` tinyint(1) NOT NULL,
    `Category` varchar(100) CHARACTER SET utf8mb4 NULL,
    `Author` varchar(100) CHARACTER SET utf8mb4 NULL,
    `ReadTime` int NOT NULL,
    `ViewCount` int NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `UpdatedDate` datetime(6) NULL,
    `PublishedDate` datetime(6) NULL,
    CONSTRAINT `PK_BlogPosts` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Catalogs` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Title` varchar(200) CHARACTER SET utf8mb4 NULL,
    `Description` varchar(500) CHARACTER SET utf8mb4 NULL,
    `FilePath` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `FileUrl` varchar(200) CHARACTER SET utf8mb4 NULL,
    `FileSize` varchar(50) CHARACTER SET utf8mb4 NULL,
    `FileExtension` varchar(10) CHARACTER SET utf8mb4 NULL,
    `CoverImagePath` varchar(200) CHARACTER SET utf8mb4 NULL,
    `CoverImageUrl` varchar(200) CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `DownloadCount` int NOT NULL,
    `FileSizeBytes` bigint NOT NULL,
    `SortOrder` int NOT NULL,
    `SeoTitle` varchar(100) CHARACTER SET utf8mb4 NULL,
    `SeoDescription` varchar(200) CHARACTER SET utf8mb4 NULL,
    `SeoKeywords` varchar(100) CHARACTER SET utf8mb4 NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_Catalogs` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Categories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(500) CHARACTER SET utf8mb4 NULL,
    `ImagePath` varchar(200) CHARACTER SET utf8mb4 NULL,
    `ImageUrl` varchar(200) CHARACTER SET utf8mb4 NULL,
    `SortOrder` int NOT NULL,
    `SeoTitle` varchar(100) CHARACTER SET utf8mb4 NULL,
    `SeoDescription` varchar(200) CHARACTER SET utf8mb4 NULL,
    `SeoKeywords` varchar(100) CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_Categories` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ContactMessages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FullName` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(100) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Phone` varchar(20) CHARACTER SET utf8mb4 NULL,
    `Company` varchar(100) CHARACTER SET utf8mb4 NULL,
    `IpAddress` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Subject` varchar(100) CHARACTER SET utf8mb4 NULL,
    `Message` varchar(1000) CHARACTER SET utf8mb4 NOT NULL,
    `IsRead` tinyint(1) NOT NULL,
    `IsReplied` tinyint(1) NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `ReadDate` datetime(6) NULL,
    `ReplyDate` datetime(6) NULL,
    CONSTRAINT `PK_ContactMessages` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Username` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Email` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `PasswordHash` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `FirstName` varchar(100) CHARACTER SET utf8mb4 NULL,
    `LastName` varchar(100) CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `IsAdmin` tinyint(1) NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `LastLoginDate` datetime(6) NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Products` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(1000) CHARACTER SET utf8mb4 NULL,
    `DetailedDescription` varchar(2000) CHARACTER SET utf8mb4 NULL,
    `ModelNumber` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Color` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Size` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Material` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Price` decimal(10,2) NULL,
    `MainImagePath` varchar(200) CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `IsFeatured` tinyint(1) NOT NULL,
    `SortOrder` int NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `UpdatedDate` datetime(6) NULL,
    `ViewCount` int NOT NULL,
    `Features` varchar(1000) CHARACTER SET utf8mb4 NULL,
    `Tags` varchar(200) CHARACTER SET utf8mb4 NULL,
    `SeoTitle` varchar(100) CHARACTER SET utf8mb4 NULL,
    `SeoDescription` varchar(200) CHARACTER SET utf8mb4 NULL,
    `SeoKeywords` varchar(100) CHARACTER SET utf8mb4 NULL,
    `CategoryId` int NOT NULL,
    CONSTRAINT `PK_Products` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Products_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `ProductImages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ImagePath` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `ImageUrl` varchar(200) CHARACTER SET utf8mb4 NULL,
    `AltText` varchar(100) CHARACTER SET utf8mb4 NULL,
    `IsMainImage` tinyint(1) NOT NULL,
    `IsMain` tinyint(1) NOT NULL,
    `SortOrder` int NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `ProductId` int NOT NULL,
    CONSTRAINT `PK_ProductImages` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ProductImages_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_ProductImages_ProductId` ON `ProductImages` (`ProductId`);

CREATE INDEX `IX_Products_CategoryId` ON `Products` (`CategoryId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251121135007_InitialCreate', '8.0.7');

COMMIT;

START TRANSACTION;

CREATE TABLE `Sliders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Subtitle` varchar(250) CHARACTER SET utf8mb4 NULL,
    `ImagePath` varchar(200) CHARACTER SET utf8mb4 NULL,
    `LinkUrl` varchar(300) CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `SortOrder` int NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_Sliders` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122084656_AddSlider', '8.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `Sliders` ADD `Kicker` varchar(100) CHARACTER SET utf8mb4 NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122092856_AddKickerToSlider', '8.0.7');

COMMIT;

START TRANSACTION;

CREATE TABLE `AboutImages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ImagePath` varchar(200) CHARACTER SET utf8mb4 NULL,
    `SortOrder` int NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_AboutImages` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ContactInfos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Phone` varchar(100) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(100) CHARACTER SET utf8mb4 NULL,
    `Address` varchar(500) CHARACTER SET utf8mb4 NULL,
    `Latitude` varchar(50) CHARACTER SET utf8mb4 NULL,
    `Longitude` varchar(50) CHARACTER SET utf8mb4 NULL,
    `WhatsApp` varchar(100) CHARACTER SET utf8mb4 NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_ContactInfos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122095148_AddAboutAndContactManagement', '8.0.7');

COMMIT;

START TRANSACTION;

CREATE TABLE `SiteLogos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ImagePath` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_SiteLogos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122113051_AddSiteLogoTable', '8.0.7');

COMMIT;

START TRANSACTION;

CREATE TABLE `ReferenceLogos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ImagePath` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `SortOrder` int NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_ReferenceLogos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122121055_AddReferenceLogoTable', '8.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `Sliders` ADD `Button1Type` varchar(50) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Sliders` ADD `Button2Type` varchar(50) CHARACTER SET utf8mb4 NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122140728_AddSliderButtons', '8.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `ContactInfos` ADD `FacebookUrl` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ContactInfos` ADD `InstagramUrl` varchar(200) CHARACTER SET utf8mb4 NULL;

CREATE TABLE `AboutSectionContents` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(200) CHARACTER SET utf8mb4 NULL,
    `Subtitle` varchar(500) CHARACTER SET utf8mb4 NULL,
    `Item1Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Item1Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `Item2Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Item2Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `Item3Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Item3Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_AboutSectionContents` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ReferenceSectionContents` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(200) CHARACTER SET utf8mb4 NULL,
    `Subtitle` varchar(500) CHARACTER SET utf8mb4 NULL,
    `Item1Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Item1Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `Item2Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Item2Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `Item3Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Item3Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_ReferenceSectionContents` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122142345_AddAboutReferenceContentAndSocialLinks', '8.0.7');

COMMIT;

START TRANSACTION;

CREATE TABLE `CorporatePageContents` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `HistoryTitle` varchar(200) CHARACTER SET utf8mb4 NULL,
    `HistoryText1` varchar(800) CHARACTER SET utf8mb4 NULL,
    `HistoryText2` varchar(800) CHARACTER SET utf8mb4 NULL,
    `HistoryItem1Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `HistoryItem1Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `HistoryItem2Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `HistoryItem2Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `HistoryItem3Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `HistoryItem3Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `HistoryItem4Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `HistoryItem4Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `MissionTitle` varchar(200) CHARACTER SET utf8mb4 NULL,
    `MissionText` varchar(800) CHARACTER SET utf8mb4 NULL,
    `VisionTitle` varchar(200) CHARACTER SET utf8mb4 NULL,
    `VisionText` varchar(800) CHARACTER SET utf8mb4 NULL,
    `ValuesTitle` varchar(200) CHARACTER SET utf8mb4 NULL,
    `ValuesSubtitle` varchar(500) CHARACTER SET utf8mb4 NULL,
    `Value1Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Value1Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `Value2Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Value2Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `Value3Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Value3Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `Value4Title` varchar(150) CHARACTER SET utf8mb4 NULL,
    `Value4Text` varchar(300) CHARACTER SET utf8mb4 NULL,
    `UpdatedDate` datetime(6) NULL,
    CONSTRAINT `PK_CorporatePageContents` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251122143335_AddCorporatePageContent', '8.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `Products` ADD `IsInStock` tinyint(1) NOT NULL DEFAULT FALSE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251124152111_AddProductStock', '8.0.7');

COMMIT;

