using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikprogServerClient.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoginMode = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Sex = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    difficulty = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    photo_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    is_hidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "module",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sequence_num = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.id);
                    table.ForeignKey(
                        name: "FK_module_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "material_info",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sequence_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_material_info_module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Student", "STUDENT" },
                    { "3", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "LoginMode", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e4d062b-3910-47b3-b58a-7dcab51f9c07", 0, null, "7112befb-138b-412b-9f35-601102357852", "NikprogUser", "Q4NSIQ@stud.uni-obuda.hu", true, "Mónika", "Tóth", null, false, null, 0, null, "Q4NSIQ@STUD.UNI-OBUDA.HU", null, null, false, "cb14355d-ce75-48f4-a9d7-d7b56a5109d0", null, false, "q4nisq@stud.uni-obuda.hu" });

            migrationBuilder.InsertData(
                table: "course",
                columns: new[] { "id", "description", "difficulty", "is_hidden", "name", "photo_url" },
                values: new object[,]
                {
                    { "1e95a891-7f0c-408b-b473-1b7ce4db0272", "Oktatási cél: A hallgatók algoritmikus gondolkodásának fejlesztése, algoritmus-alkotási készség kialakítása, gyakran használt algoritmusok megismerése. Ennek érdekében a hallgatók megismerkednek a strukturált és az objektum-orientált programozás alapelveivel és módszereivel, valamint egy konkrét objektum-orientált programnyelv használatával.\r\nTematika: Algoritmusok felépítése, vezérlési szerkezetek. Az algoritmus leírásának eszközei. Egyszerű programozási tételek: sorozatszámítás, eldöntés, kiválasztás, lineáris keresés, megszámlálás, maximumkiválasztás. Összetett programozási tételek: másolás, kiválogatás, szétválogatás, metszet, egyesítés, összefuttatás. Programozási tételek összeépítése. Az objektumorientált paradigma elemei: objektum, osztály, osztályok közötti kapcsolatok. Az OOP megvalósítások általános jellemzői: egységbezárás, adatrejtés, öröklés, többalakúság, kód újrafelhasználás. Rendezések: egyszerű cserés, kiválasztásos, buborék, beillesztéses. Tesztelés és hibakeresés. Keresések és programozási tételek rendezett tömbökben. Halmazok reprezentációja és műveletei. Rekurzív algoritmusok, programozási tételek rekurzív megvalósítása. „Oszd meg és uralkodj!” elvű algoritmusok, gyorsrendezés és összefésülő rendezés. Optimalizálási problémák megoldása dinamikus programozás és mohó stratégia alkalmazásával.", 1, false, "Szoftvertervezés és -fejlesztés I.", "http://localhost:8080/apps/files_sharing/publicpreview/jQgsmTtyXan9bo5?file=/&fileId=437&x=1920&y=1080&a=true" },
                    { "2e95a891-7f0c-408b-b473-1b7ce4db0332", "Oktatási cél: A gyakorlatok során a hallgatók megismerkednek a Java nyelven történo programfejlesztési technológiákkal.\r\nTematika: Programozás Java nyelvben, webalkalmazások fejlesztése (Osztályok, kivételkezelés, gyűjtemények, kliens-szerver kommunikáció, szerializáció, szervletek, formok, session kezelés, JSP). A laborfoglalkozások elméleti alapjai közös előadásként jelennek meg. Az előadásokban elhangzott ismereteket a laborokon alkalmazzák a hallgatók és az elméleti ismeretanyag a zárthelyiben számonkérésre kerül.", 4, false, "JAVA alapú webfejlesztés", "http://localhost:8080/apps/files_sharing/publicpreview/poWrw49PZ94iY7k?file=/&fileId=437&x=1920&y=1080&a=true" },
                    { "2e95a891-7f0c-408b-b473-1b7ce4db045b", "Oktatási cél: A gyakorlatok során a hallgatók megismerkednek a C# nyelven történő haladó programfejlesztési technológiákkal. A heti három órából az egyik előadásként, és nem minden héten kerül megtartásra.\r\nTematika: A C# nyelv haladó eszközei (Lambda kifejezések, LINQ, Entity Framework, Attribútumok, Reflexió, DLL készítése és használata, Unit tesztelés, Mock, Folyamatok és szálak kezelése)", 4, false, "Haladó Fejlesztési Technikák", "http://localhost:8080/apps/files_sharing/publicpreview/fSaF2t4NnfJJCQe?file=/&fileId=437&x=1920&y=1080&a=true" },
                    { "2e95a891-7f0c-408b-b473-1b7ce4db0610", "Oktatási cél: Az előadáson a hallgatóság megismerkedik a szoftverfejlesztés modern eszközeivel és módszertanaival, haladó verziókövetési ismeretekkel és az iparban népszerű tervezési mintákkal.", 5, false, "Szoftvertechnológia", "http://localhost:8080/apps/files_sharing/publicpreview/osenbzbQqmtcgEz?file=/&fileId=437&x=1920&y=1080&a=true" },
                    { "2e95a891-7f0c-408b-b473-1b7ce4db0978", "Oktatási cél: A gyakorlatok során megtanulnak asztali alkalmazásokat fejleszteni WPF keretrendszerben és webes alkalmazásokat fejleszteni Javascript nyelven.\r\n\r\nTematika: Az MVVM tervezési minta használata WPF keretrendszerben (vezérlők, események, adatkötés). Egyszerű játékfejlesztés WPF keretrendszerben. Javascript alapjai, DOM manipulációk, események, webapi felhasználás.\r\n", 4, false, "GUI tervezés", "http://localhost:8080/apps/files_sharing/publicpreview/afsDr66BLrryzSJ?file=/&fileId=437&x=1920&y=1080&a=true" },
                    { "2e95a891-7f0c-408b-b473-1b7ce4db4442", "Oktatási cél: A tantárgy keretein belül a hallgatók megismerkednek a modern webalkalmazások szerveroldali fejlesztésének technikáival. A tárgy első részében megismerik az MVC tervezési minta alkalmazási lehetőségeit, a felhasználó és jogosultságkezelést, a session kezelést és a modern adattárolás lehetőségeit. A tárgy további részeiben API alapú technikákat sajátítanak el, illetve kipróbálják a korszerű alkalmazás hosztolási módszereket felhő és konténer technológiákkal.", 5, false, "Szerveroldali fejlesztés", "http://localhost:8080/apps/files_sharing/publicpreview/JmBcHZAoLEjAZDR?file=/&fileId=437&x=1920&y=1080&a=true" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "4e4d062b-3910-47b3-b58a-7dcab51f9c07" });

            migrationBuilder.InsertData(
                table: "module",
                columns: new[] { "id", "CourseId", "name", "sequence_num" },
                values: new object[] { "2e94a891-7g0c-408b-b473-1b7ce4db0352", "2e95a891-7f0c-408b-b473-1b7ce4db0332", "JAVA alapismeretek", 1 });

            migrationBuilder.InsertData(
                table: "module",
                columns: new[] { "id", "CourseId", "name", "sequence_num" },
                values: new object[] { "3e95a891-7f0c-408b-b473-1b7ce4db0344", "2e95a891-7f0c-408b-b473-1b7ce4db0332", "Gyűjtemények, Stream API, kivételkezelés", 2 });

            migrationBuilder.InsertData(
                table: "material_info",
                columns: new[] { "id", "Discriminator", "ModuleId", "sequence_num", "title", "url" },
                values: new object[] { "6b96a891-7f0c-408b-b473-1b7ce4db0421", "DocumentInfo", "2e94a891-7g0c-408b-b473-1b7ce4db0352", 1, "The document", "http://localhost:8080/s/rjQYxa8mbM6MXtE" });

            migrationBuilder.InsertData(
                table: "material_info",
                columns: new[] { "id", "Discriminator", "message", "ModuleId", "sequence_num", "title", "url" },
                values: new object[] { "8a98a891-7f0c-638b-b473-1b7ce4db32ce", "MessageInfo", "Hi Guys, this is only a short message about the projectwork!\nIT STARTS END ENDS TOMORROW MUHAHAHAHA!!!", "3e95a891-7f0c-408b-b473-1b7ce4db0344", 3, "Assignment message", "" });

            migrationBuilder.InsertData(
                table: "material_info",
                columns: new[] { "id", "Discriminator", "ModuleId", "sequence_num", "title", "url" },
                values: new object[] { "7c88a891-7f0c-638b-b473-1b7ce4db3245", "VideoInfo", "2e94a891-7g0c-408b-b473-1b7ce4db0352", 2, "The video", "http://localhost:8080/s/rjQYxa8mbM6MXtE" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_material_info_ModuleId",
                table: "material_info",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_module_CourseId",
                table: "module",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "material_info");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "module");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
