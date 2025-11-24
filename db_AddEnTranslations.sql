START TRANSACTION;

ALTER TABLE `Sliders` ADD `KickerEn` varchar(100) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Sliders` ADD `SubtitleEn` varchar(250) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Sliders` ADD `TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `Item1TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `Item1TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `Item2TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `Item2TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `Item3TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `Item3TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `SubtitleEn` varchar(500) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `ReferenceSectionContents` ADD `TitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Products` ADD `DescriptionEn` varchar(1000) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Products` ADD `DetailedDescriptionEn` varchar(2000) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Products` ADD `FeaturesEn` varchar(1000) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Products` ADD `NameEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem1TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem1TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem2TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem2TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem3TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem3TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem4TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryItem4TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryText1En` varchar(800) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryText2En` varchar(800) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `HistoryTitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `MissionTextEn` varchar(800) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `MissionTitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value1TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value1TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value2TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value2TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value3TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value3TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value4TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `Value4TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `ValuesSubtitleEn` varchar(500) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `ValuesTitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `VisionTextEn` varchar(800) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `CorporatePageContents` ADD `VisionTitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Categories` ADD `DescriptionEn` varchar(500) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Categories` ADD `NameEn` varchar(100) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Catalogs` ADD `DescriptionEn` varchar(500) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Catalogs` ADD `TitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `BlogPosts` ADD `ContentEn` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `BlogPosts` ADD `SummaryEn` varchar(500) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `BlogPosts` ADD `TitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `Item1TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `Item1TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `Item2TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `Item2TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `Item3TextEn` varchar(300) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `Item3TitleEn` varchar(150) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `SubtitleEn` varchar(500) CHARACTER SET utf8mb4 NULL;

ALTER TABLE `AboutSectionContents` ADD `TitleEn` varchar(200) CHARACTER SET utf8mb4 NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251124205507_AddEnTranslations', '8.0.7');

COMMIT;

