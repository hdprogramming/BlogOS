using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogOS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Technologies = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
                migrationBuilder.Sql(@"
        INSERT INTO Projects (Name, Description, Category, CompletionDate, Technologies)
        VALUES
        ('Web Tasarım Projesi', 'Bu proje, BlogOS web sitesinin görsel tasarımının ve kullanıcı arayüzünün modernleştirilmesini hedeflemektedir. Bootstrap 5, SASS ve JavaScript kullanılarak responsive bir yapı oluşturuldu.', 'web', '2025-04-15', 'HTML5, CSS3, Bootstrap 5, JavaScript, SASS'),
        ('Mobil Uygulama Projesi', 'Bu proje, BlogOS içeriklerini mobil cihazlardan erişilebilir kılmak için geliştirilen bir native mobil uygulamadır. Hem iOS hem de Android platformları için optimize edilmiştir.', 'mobile', '2025-07-20', 'React Native, Node.js (API için), MongoDB (Veritabanı)'),
        ('Veritabanı Optimizasyonu', 'Mevcut veritabanı performansını artırmak ve sorgu sürelerini kısaltmak için yapılan detaylı bir optimizasyon projesidir.', 'other', '2024-11-01', 'SQL, NoSQL (Redis), Performans Analiz Araçları')
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
