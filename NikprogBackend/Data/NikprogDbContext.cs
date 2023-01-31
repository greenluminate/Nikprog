using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NikprogServerClient.Models.CourseMaterials;
using NikprogServerClient.Models.UserHandling;

namespace NikprogServerClient.Data
{
    public class NikprogDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<NikprogUser> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<MaterialInfo> MaterialInfos { get; set; }

        public NikprogDbContext(DbContextOptions<NikprogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //PasswordHasher<NikprogUser> pwHasher = new PasswordHasher<NikprogUser>();

            NikprogUser moni = new NikprogUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "q4nisq@stud.uni-obuda.hu",
                EmailConfirmed = true,
                FirstName = "Mónika",
                LastName = "Tóth",
                UserName = "q4nisq@stud.uni-obuda.hu",
                NormalizedUserName = "Q4NSIQ@STUD.UNI-OBUDA.HU",
                LoginMode = LoginMode.microsoft
            };
            //moni.PasswordHash = pwHasher.HashPassword(moni, "Almafa123"); //Environment.GetEnvironmentVariable("NIKPROG_ADMIN_PW");

            builder.Entity<NikprogUser>().HasData(moni);

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Student", NormalizedName = "STUDENT" },
                new { Id = "3", Name = "Teacher", NormalizedName = "TEACHER" }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = moni.Id
            });

            builder.Entity<Course>()
               .HasMany(c => c.Modules)
               .WithOne(m => m.Course)
               .HasForeignKey(m => m.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Module>()
                .HasMany(m => m.MaterialInfos)
                .WithOne(mat => mat.Module)
                .HasForeignKey(mat => mat.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            //ToDo: WIP : nextcloudApi instead of public url-s.
            #region CourseHasSets
            Course stf1 = new Course()//ToDo: builder method, I do not think it is necessary
            {
                Id = "1e95a891-7f0c-408b-b473-1b7ce4db0272",
                Name = "Szoftvertervezés és -fejlesztés I.",
                Difficulty = (DifficultyEnum)1,
                Description = "Oktatási cél: A hallgatók algoritmikus gondolkodásának fejlesztése, algoritmus-alkotási készség kialakítása, gyakran használt algoritmusok megismerése. Ennek érdekében a hallgatók megismerkednek a strukturált és az objektum-orientált programozás alapelveivel és módszereivel, valamint egy konkrét objektum-orientált programnyelv használatával.\r\nTematika: Algoritmusok felépítése, vezérlési szerkezetek. Az algoritmus leírásának eszközei. Egyszerű programozási tételek: sorozatszámítás, eldöntés, kiválasztás, lineáris keresés, megszámlálás, maximumkiválasztás. Összetett programozási tételek: másolás, kiválogatás, szétválogatás, metszet, egyesítés, összefuttatás. Programozási tételek összeépítése. Az objektumorientált paradigma elemei: objektum, osztály, osztályok közötti kapcsolatok. Az OOP megvalósítások általános jellemzői: egységbezárás, adatrejtés, öröklés, többalakúság, kód újrafelhasználás. Rendezések: egyszerű cserés, kiválasztásos, buborék, beillesztéses. Tesztelés és hibakeresés. Keresések és programozási tételek rendezett tömbökben. Halmazok reprezentációja és műveletei. Rekurzív algoritmusok, programozási tételek rekurzív megvalósítása. „Oszd meg és uralkodj!” elvű algoritmusok, gyorsrendezés és összefésülő rendezés. Optimalizálási problémák megoldása dinamikus programozás és mohó stratégia alkalmazásával.",
                PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/jQgsmTtyXan9bo5?file=/&fileId=437&x=1920&y=1080&a=true",
                IsHidden = false
            };

            Course javaWeb = new Course()
            {
                Id = "2e95a891-7f0c-408b-b473-1b7ce4db0332",
                Name = "JAVA alapú webfejlesztés",
                Difficulty = (DifficultyEnum)4,
                Description = "Oktatási cél: A gyakorlatok során a hallgatók megismerkednek a Java nyelven történo programfejlesztési technológiákkal.\r\nTematika: Programozás Java nyelvben, webalkalmazások fejlesztése (Osztályok, kivételkezelés, gyűjtemények, kliens-szerver kommunikáció, szerializáció, szervletek, formok, session kezelés, JSP). A laborfoglalkozások elméleti alapjai közös előadásként jelennek meg. Az előadásokban elhangzott ismereteket a laborokon alkalmazzák a hallgatók és az elméleti ismeretanyag a zárthelyiben számonkérésre kerül.",
                PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/poWrw49PZ94iY7k?file=/&fileId=437&x=1920&y=1080&a=true",
                IsHidden = false
            };

            Course hft = new Course()
            {
                Id = "2e95a891-7f0c-408b-b473-1b7ce4db045b",
                Name = "Haladó Fejlesztési Technikák",
                Difficulty = (DifficultyEnum)4,
                Description = "Oktatási cél: A gyakorlatok során a hallgatók megismerkednek a C# nyelven történő haladó programfejlesztési technológiákkal. A heti három órából az egyik előadásként, és nem minden héten kerül megtartásra.\r\nTematika: A C# nyelv haladó eszközei (Lambda kifejezések, LINQ, Entity Framework, Attribútumok, Reflexió, DLL készítése és használata, Unit tesztelés, Mock, Folyamatok és szálak kezelése)",
                PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/fSaF2t4NnfJJCQe?file=/&fileId=437&x=1920&y=1080&a=true",
                IsHidden = false
            };

            Course softTech = new Course()
            {
                Id = "2e95a891-7f0c-408b-b473-1b7ce4db0610",
                Name = "Szoftvertechnológia",
                Difficulty = (DifficultyEnum)5,
                Description = "Oktatási cél: Az előadáson a hallgatóság megismerkedik a szoftverfejlesztés modern eszközeivel és módszertanaival, haladó verziókövetési ismeretekkel és az iparban népszerű tervezési mintákkal.",
                PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/osenbzbQqmtcgEz?file=/&fileId=437&x=1920&y=1080&a=true",
                IsHidden = false
            };

            Course gui = new Course()
            {
                Id = "2e95a891-7f0c-408b-b473-1b7ce4db0978",
                Name = "GUI tervezés",
                Difficulty = (DifficultyEnum)4,
                Description = "Oktatási cél: A gyakorlatok során megtanulnak asztali alkalmazásokat fejleszteni WPF keretrendszerben és webes alkalmazásokat fejleszteni Javascript nyelven.\r\n\r\nTematika: Az MVVM tervezési minta használata WPF keretrendszerben (vezérlők, események, adatkötés). Egyszerű játékfejlesztés WPF keretrendszerben. Javascript alapjai, DOM manipulációk, események, webapi felhasználás.\r\n",
                PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/afsDr66BLrryzSJ?file=/&fileId=437&x=1920&y=1080&a=true",
                IsHidden = false
            };

            Course serverSide = new Course()
            {
                Id = "2e95a891-7f0c-408b-b473-1b7ce4db4442",
                Name = "Szerveroldali fejlesztés",
                Difficulty = (DifficultyEnum)5,
                Description = "Oktatási cél: A tantárgy keretein belül a hallgatók megismerkednek a modern webalkalmazások szerveroldali fejlesztésének technikáival. A tárgy első részében megismerik az MVC tervezési minta alkalmazási lehetőségeit, a felhasználó és jogosultságkezelést, a session kezelést és a modern adattárolás lehetőségeit. A tárgy további részeiben API alapú technikákat sajátítanak el, illetve kipróbálják a korszerű alkalmazás hosztolási módszereket felhő és konténer technológiákkal.",
                PhotoUrl = "http://localhost:8080/apps/files_sharing/publicpreview/JmBcHZAoLEjAZDR?file=/&fileId=437&x=1920&y=1080&a=true",
                IsHidden = false
            };
            #endregion

            #region ModuleHasSets
            Module module1 = new Module()
            {
                Id = "2e94a891-7g0c-408b-b473-1b7ce4db0352",
                Name = "JAVA alapismeretek",
                SequenceNum = 1,
                CourseId = "2e95a891-7f0c-408b-b473-1b7ce4db0332"
            };

            Module module2 = new Module()
            {
                Id = "3e95a891-7f0c-408b-b473-1b7ce4db0344",
                Name = "Gyűjtemények, Stream API, kivételkezelés",
                SequenceNum = 2,
                CourseId = "2e95a891-7f0c-408b-b473-1b7ce4db0332"
            };
            #endregion

            #region MaterialHasSets
            MaterialInfo document1 = new DocumentInfo()
            {
                Id = "6b96a891-7f0c-408b-b473-1b7ce4db0421",
                Title = "The document",
                SequenceNum = 1,
                ModuleId = "2e94a891-7g0c-408b-b473-1b7ce4db0352",
                Url = "http://localhost:8080/s/rjQYxa8mbM6MXtE"
            };

            MaterialInfo video1 = new VideoInfo()
            {
                Id = "7c88a891-7f0c-638b-b473-1b7ce4db3245",
                Title = "The video",
                SequenceNum = 2,
                ModuleId = "2e94a891-7g0c-408b-b473-1b7ce4db0352",
                Url = "http://localhost:8080/s/rjQYxa8mbM6MXtE"
            };

            MaterialInfo text1 = new MessageInfo()
            {
                Id = "8a98a891-7f0c-638b-b473-1b7ce4db32ce",
                Title = "Assignment message",
                SequenceNum = 3,
                ModuleId = "3e95a891-7f0c-408b-b473-1b7ce4db0344",
                Url = "", // Image could be added
                Message = "Hi Guys, this is only a short message about the projectwork!\nIT STARTS END ENDS TOMORROW MUHAHAHAHA!!!"
            };
            #endregion

            builder.Entity<Course>().HasData(stf1, javaWeb, hft, softTech, gui, serverSide);
            builder.Entity<Module>().HasData(module1, module2);
            builder.Entity<DocumentInfo>().HasData(document1);
            builder.Entity<VideoInfo>().HasData(video1);
            builder.Entity<MessageInfo>().HasData(text1);

            base.OnModelCreating(builder);
        }
    }
}