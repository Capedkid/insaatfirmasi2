using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsaatFirmasi.Migrations
{
    /// <inheritdoc />
    public partial class AddEnTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KickerEn",
                table: "Sliders",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SubtitleEn",
                table: "Sliders",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "Sliders",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item1TextEn",
                table: "ReferenceSectionContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item1TitleEn",
                table: "ReferenceSectionContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item2TextEn",
                table: "ReferenceSectionContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item2TitleEn",
                table: "ReferenceSectionContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item3TextEn",
                table: "ReferenceSectionContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item3TitleEn",
                table: "ReferenceSectionContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SubtitleEn",
                table: "ReferenceSectionContents",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "ReferenceSectionContents",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescriptionEn",
                table: "Products",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FeaturesEn",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Products",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem1TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem1TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem2TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem2TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem3TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem3TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem4TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryItem4TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryText1En",
                table: "CorporatePageContents",
                type: "varchar(800)",
                maxLength: 800,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryText2En",
                table: "CorporatePageContents",
                type: "varchar(800)",
                maxLength: 800,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoryTitleEn",
                table: "CorporatePageContents",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MissionTextEn",
                table: "CorporatePageContents",
                type: "varchar(800)",
                maxLength: 800,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MissionTitleEn",
                table: "CorporatePageContents",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value1TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value1TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value2TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value2TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value3TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value3TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value4TextEn",
                table: "CorporatePageContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Value4TitleEn",
                table: "CorporatePageContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ValuesSubtitleEn",
                table: "CorporatePageContents",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ValuesTitleEn",
                table: "CorporatePageContents",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "VisionTextEn",
                table: "CorporatePageContents",
                type: "varchar(800)",
                maxLength: 800,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "VisionTitleEn",
                table: "CorporatePageContents",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Categories",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Categories",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Catalogs",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "Catalogs",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContentEn",
                table: "BlogPosts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SummaryEn",
                table: "BlogPosts",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "BlogPosts",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item1TextEn",
                table: "AboutSectionContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item1TitleEn",
                table: "AboutSectionContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item2TextEn",
                table: "AboutSectionContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item2TitleEn",
                table: "AboutSectionContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item3TextEn",
                table: "AboutSectionContents",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Item3TitleEn",
                table: "AboutSectionContents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SubtitleEn",
                table: "AboutSectionContents",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "AboutSectionContents",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KickerEn",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SubtitleEn",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Item1TextEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "Item1TitleEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "Item2TextEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "Item2TitleEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "Item3TextEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "Item3TitleEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "SubtitleEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "ReferenceSectionContents");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DetailedDescriptionEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FeaturesEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HistoryItem1TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryItem1TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryItem2TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryItem2TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryItem3TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryItem3TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryItem4TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryItem4TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryText1En",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryText2En",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "HistoryTitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "MissionTextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "MissionTitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value1TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value1TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value2TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value2TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value3TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value3TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value4TextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "Value4TitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "ValuesSubtitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "ValuesTitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "VisionTextEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "VisionTitleEn",
                table: "CorporatePageContents");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "ContentEn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "SummaryEn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Item1TextEn",
                table: "AboutSectionContents");

            migrationBuilder.DropColumn(
                name: "Item1TitleEn",
                table: "AboutSectionContents");

            migrationBuilder.DropColumn(
                name: "Item2TextEn",
                table: "AboutSectionContents");

            migrationBuilder.DropColumn(
                name: "Item2TitleEn",
                table: "AboutSectionContents");

            migrationBuilder.DropColumn(
                name: "Item3TextEn",
                table: "AboutSectionContents");

            migrationBuilder.DropColumn(
                name: "Item3TitleEn",
                table: "AboutSectionContents");

            migrationBuilder.DropColumn(
                name: "SubtitleEn",
                table: "AboutSectionContents");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "AboutSectionContents");
        }
    }
}
