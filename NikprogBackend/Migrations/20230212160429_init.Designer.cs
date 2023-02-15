﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NikprogServerClient.Data;

#nullable disable

namespace NikprogServerClient.Migrations
{
    [DbContext(typeof(NikprogDbContext))]
    [Migration("20230212160429_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "4e4d062b-3910-47b3-b58a-7dcab51f9c07",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasColumnName("description");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("int")
                        .HasColumnName("difficulty");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit")
                        .HasColumnName("is_hidden");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("photo_url");

                    b.HasKey("Id");

                    b.ToTable("course");

                    b.HasData(
                        new
                        {
                            Id = "1e95a891-7f0c-408b-b473-1b7ce4db0272",
                            Description = "Oktatási cél: A hallgatók algoritmikus gondolkodásának fejlesztése, algoritmus-alkotási készség kialakítása, gyakran használt algoritmusok megismerése. Ennek érdekében a hallgatók megismerkednek a strukturált és az objektum-orientált programozás alapelveivel és módszereivel, valamint egy konkrét objektum-orientált programnyelv használatával.\r\nTematika: Algoritmusok felépítése, vezérlési szerkezetek. Az algoritmus leírásának eszközei. Egyszerű programozási tételek: sorozatszámítás, eldöntés, kiválasztás, lineáris keresés, megszámlálás, maximumkiválasztás. Összetett programozási tételek: másolás, kiválogatás, szétválogatás, metszet, egyesítés, összefuttatás. Programozási tételek összeépítése. Az objektumorientált paradigma elemei: objektum, osztály, osztályok közötti kapcsolatok. Az OOP megvalósítások általános jellemzői: egységbezárás, adatrejtés, öröklés, többalakúság, kód újrafelhasználás. Rendezések: egyszerű cserés, kiválasztásos, buborék, beillesztéses. Tesztelés és hibakeresés. Keresések és programozási tételek rendezett tömbökben. Halmazok reprezentációja és műveletei. Rekurzív algoritmusok, programozási tételek rekurzív megvalósítása. „Oszd meg és uralkodj!” elvű algoritmusok, gyorsrendezés és összefésülő rendezés. Optimalizálási problémák megoldása dinamikus programozás és mohó stratégia alkalmazásával.",
                            Difficulty = 1,
                            IsHidden = false,
                            Name = "Szoftvertervezés és -fejlesztés I.",
                            PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/jQgsmTtyXan9bo5?file=/&fileId=437&x=1920&y=1080&a=true"
                        },
                        new
                        {
                            Id = "2e95a891-7f0c-408b-b473-1b7ce4db0332",
                            Description = "Oktatási cél: A gyakorlatok során a hallgatók megismerkednek a Java nyelven történo programfejlesztési technológiákkal.\r\nTematika: Programozás Java nyelvben, webalkalmazások fejlesztése (Osztályok, kivételkezelés, gyűjtemények, kliens-szerver kommunikáció, szerializáció, szervletek, formok, session kezelés, JSP). A laborfoglalkozások elméleti alapjai közös előadásként jelennek meg. Az előadásokban elhangzott ismereteket a laborokon alkalmazzák a hallgatók és az elméleti ismeretanyag a zárthelyiben számonkérésre kerül.",
                            Difficulty = 4,
                            IsHidden = false,
                            Name = "JAVA alapú webfejlesztés",
                            PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/poWrw49PZ94iY7k?file=/&fileId=437&x=1920&y=1080&a=true"
                        },
                        new
                        {
                            Id = "2e95a891-7f0c-408b-b473-1b7ce4db045b",
                            Description = "Oktatási cél: A gyakorlatok során a hallgatók megismerkednek a C# nyelven történő haladó programfejlesztési technológiákkal. A heti három órából az egyik előadásként, és nem minden héten kerül megtartásra.\r\nTematika: A C# nyelv haladó eszközei (Lambda kifejezések, LINQ, Entity Framework, Attribútumok, Reflexió, DLL készítése és használata, Unit tesztelés, Mock, Folyamatok és szálak kezelése)",
                            Difficulty = 4,
                            IsHidden = false,
                            Name = "Haladó Fejlesztési Technikák",
                            PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/fSaF2t4NnfJJCQe?file=/&fileId=437&x=1920&y=1080&a=true"
                        },
                        new
                        {
                            Id = "2e95a891-7f0c-408b-b473-1b7ce4db0610",
                            Description = "Oktatási cél: Az előadáson a hallgatóság megismerkedik a szoftverfejlesztés modern eszközeivel és módszertanaival, haladó verziókövetési ismeretekkel és az iparban népszerű tervezési mintákkal.",
                            Difficulty = 5,
                            IsHidden = false,
                            Name = "Szoftvertechnológia",
                            PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/osenbzbQqmtcgEz?file=/&fileId=437&x=1920&y=1080&a=true"
                        },
                        new
                        {
                            Id = "2e95a891-7f0c-408b-b473-1b7ce4db0978",
                            Description = "Oktatási cél: A gyakorlatok során megtanulnak asztali alkalmazásokat fejleszteni WPF keretrendszerben és webes alkalmazásokat fejleszteni Javascript nyelven.\r\n\r\nTematika: Az MVVM tervezési minta használata WPF keretrendszerben (vezérlők, események, adatkötés). Egyszerű játékfejlesztés WPF keretrendszerben. Javascript alapjai, DOM manipulációk, események, webapi felhasználás.\r\n",
                            Difficulty = 4,
                            IsHidden = false,
                            Name = "GUI tervezés",
                            PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/afsDr66BLrryzSJ?file=/&fileId=437&x=1920&y=1080&a=true"
                        },
                        new
                        {
                            Id = "2e95a891-7f0c-408b-b473-1b7ce4db4442",
                            Description = "Oktatási cél: A tantárgy keretein belül a hallgatók megismerkednek a modern webalkalmazások szerveroldali fejlesztésének technikáival. A tárgy első részében megismerik az MVC tervezési minta alkalmazási lehetőségeit, a felhasználó és jogosultságkezelést, a session kezelést és a modern adattárolás lehetőségeit. A tárgy további részeiben API alapú technikákat sajátítanak el, illetve kipróbálják a korszerű alkalmazás hosztolási módszereket felhő és konténer technológiákkal.",
                            Difficulty = 5,
                            IsHidden = false,
                            Name = "Szerveroldali fejlesztés",
                            PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/JmBcHZAoLEjAZDR?file=/&fileId=437&x=1920&y=1080&a=true"
                        });
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.MaterialInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SequenceNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sequence_num");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SequenceNum"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("title");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("material_info");

                    b.HasDiscriminator<string>("Discriminator").HasValue("MaterialInfo");
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.Module", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("SequenceNum")
                        .HasColumnType("int")
                        .HasColumnName("sequence_num");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("module");

                    b.HasData(
                        new
                        {
                            Id = "2e94a891-7g0c-408b-b473-1b7ce4db0352",
                            CourseId = "2e95a891-7f0c-408b-b473-1b7ce4db0332",
                            Name = "JAVA alapismeretek",
                            SequenceNum = 1
                        },
                        new
                        {
                            Id = "3e95a891-7f0c-408b-b473-1b7ce4db0344",
                            CourseId = "2e95a891-7f0c-408b-b473-1b7ce4db0332",
                            Name = "Gyűjtemények, Stream API, kivételkezelés",
                            SequenceNum = 2
                        });
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.DocumentInfo", b =>
                {
                    b.HasBaseType("NikprogServerClient.Models.CourseMaterials.MaterialInfo");

                    b.ToTable("material_info");

                    b.HasDiscriminator().HasValue("DocumentInfo");

                    b.HasData(
                        new
                        {
                            Id = "6b96a891-7f0c-408b-b473-1b7ce4db0421",
                            ModuleId = "2e94a891-7g0c-408b-b473-1b7ce4db0352",
                            SequenceNum = 1,
                            Title = "The document",
                            Url = "http://localhost:8080/s/rjQYxa8mbM6MXtE"
                        });
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.MessageInfo", b =>
                {
                    b.HasBaseType("NikprogServerClient.Models.CourseMaterials.MaterialInfo");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)")
                        .HasColumnName("message");

                    b.ToTable("material_info");

                    b.HasDiscriminator().HasValue("MessageInfo");

                    b.HasData(
                        new
                        {
                            Id = "8a98a891-7f0c-638b-b473-1b7ce4db32ce",
                            ModuleId = "3e95a891-7f0c-408b-b473-1b7ce4db0344",
                            SequenceNum = 3,
                            Title = "Assignment message",
                            Url = "",
                            Message = "Hi Guys, this is only a short message about the projectwork!\nIT STARTS END ENDS TOMORROW MUHAHAHAHA!!!"
                        });
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.VideoInfo", b =>
                {
                    b.HasBaseType("NikprogServerClient.Models.CourseMaterials.MaterialInfo");

                    b.ToTable("material_info");

                    b.HasDiscriminator().HasValue("VideoInfo");

                    b.HasData(
                        new
                        {
                            Id = "7c88a891-7f0c-638b-b473-1b7ce4db3245",
                            ModuleId = "2e94a891-7g0c-408b-b473-1b7ce4db0352",
                            SequenceNum = 2,
                            Title = "The video",
                            Url = "http://localhost:8080/s/rjQYxa8mbM6MXtE"
                        });
                });

            modelBuilder.Entity("NikprogServerClient.Models.UserHandling.NikprogUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LoginMode")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int?>("Sex")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("NikprogUser");

                    b.HasData(
                        new
                        {
                            Id = "4e4d062b-3910-47b3-b58a-7dcab51f9c07",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7112befb-138b-412b-9f35-601102357852",
                            Email = "Q4NSIQ@stud.uni-obuda.hu",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "Q4NSIQ@STUD.UNI-OBUDA.HU",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cb14355d-ce75-48f4-a9d7-d7b56a5109d0",
                            TwoFactorEnabled = false,
                            UserName = "q4nisq@stud.uni-obuda.hu",
                            FirstName = "Mónika",
                            LastName = "Tóth",
                            LoginMode = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.MaterialInfo", b =>
                {
                    b.HasOne("NikprogServerClient.Models.CourseMaterials.Module", "Module")
                        .WithMany("MaterialInfos")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.Module", b =>
                {
                    b.HasOne("NikprogServerClient.Models.CourseMaterials.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.Course", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("NikprogServerClient.Models.CourseMaterials.Module", b =>
                {
                    b.Navigation("MaterialInfos");
                });
#pragma warning restore 612, 618
        }
    }
}