using JustMyResumeApi.Models;
using System;
using System.Linq;

namespace JustMyResumeApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(JustMyResumeContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var Users = new User[]
            {
                new User{ FirstName = "Thomas", LastName = "Woodward", StreetAddress = "809 E. Bellville St.", City = "Marion", State = "KY", Phone = "615.517.5194", Email = "tom_woodward7@hotmail.com" }
            };
            foreach (User s in Users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var userId = context.Users.FirstOrDefault(item => item.LastName == "Woodward").Id;

            var jobs = new Job[]
            {
                new JustMyResumeApi.Models.Job{UserId = userId, Employer = "Data Dimensions Corp.", Title = "Systems Analyst III", Role = "Full Stack Developer", StartDate = "Aug 2002", EndDate = "Oct 2015", Description = "<ul><li>Designed, developed, maintained, and migrated internal accounting package responsible for employee incentive-based pay calculation, AR, AP, and Profit/Loss. Used Windows Forms, VB.NET, SQL Server.</li><li>Implemented and maintained intranet end-to-end workflow tracking that enabled piece-incentive pay resulting in 200% productivity increase. Used IIS, C#, ASP.NET, SQL Server.</li><li>Designed, implemented, and maintained package tracking portal for clients as an internet solution with nearly 1,000 registered users. Used IIS, C#, ASP.NET, SQL Server.</li><li>Created a REST service to interface with an Android application I built to provide tablet access to the production rate system.</li></ul>"},
                new JustMyResumeApi.Models.Job{UserId = userId, Employer = "Investment Scorecard", Title = "Programmer Analyst", Role = "Full Stack Microsoft Developer", StartDate = "Apr 2001", EndDate = "Mar 2003", Description = "<ul><li>Maintained a classic ASP web application with thousands of users for investment performance reporting. Used ASP, DCOM, SQL Server, IIS, Active Directory.</li><li>Replaced Active Directory with SQL Server user authentication resulting in greater features and vastly improved scalability.</li><li>Implemented advanced financial analysis and charting feature set which resulted in large new sales.</li></ul>"},
                new JustMyResumeApi.Models.Job{UserId = userId, Employer = "Progressive Design Software (Insync, Inc.)", Title = "Business Partner", Role = "Java Developer", StartDate = "Dec 1999", EndDate = "Apr 2001", Description = "<ul><li>Designed n-tiered platform to support web and internet applications.</li><li>Designed and coded CASE tool to automate the majority of application creation.</li><li>Interfaced with clients and coded a large n-tiered, object-oriented development effort in Visual Basic 6 and SQL Server to replace a legacy system.</li></ul>"},
                new JustMyResumeApi.Models.Job{UserId = userId, Employer = "United Systems and Software", Title = "Programmer Analyst", Role = "Full Stack Microsoft Developer", StartDate = "May 1997", EndDate = "Dec 1999", Description = "<ul><li>Designed, built and maintained multiple object-oriented Visual Basic/SQL Server Line-of-business accounting solutions.</li><li>Designed an n-tiered object-oriented infrastructure and architecture which served as the basis for re-development of the company’s entire product line. Trained and assisted other developers in the use of that architecture.</li></ul>"},
                new JustMyResumeApi.Models.Job{UserId = userId, Employer = "Pure Air Internet", Title = "Founder", Role = "Network Designer/Entrepreneur", StartDate = "Jan 2016", EndDate = "May 2018", Description = "<ul><li>Created business plan and pro forma financials based on demographic and statistical data.</li><li>Designed a Fixed Wireless network to service all of western Kentucky.</li><li>Interfaced with vendors and government funding sources.</li></ul>"},
            };
            foreach (JustMyResumeApi.Models.Job job in jobs)
            {
                context.Jobs.Add(job);
            }
            context.SaveChanges();

            var skillCategories = new SkillCategory[] {
                new SkillCategory{Name = "Languages"},
                new SkillCategory{Name = "APIs"},
                new SkillCategory{Name = "Databases"}
            };
            foreach (SkillCategory skillCategory in skillCategories)
            {
                context.SkillCategories.Add(skillCategory);
            }
            context.SaveChanges();

            var lang = context.SkillCategories.FirstOrDefault(item => item.Name.Equals("Languages")).Id;
            var api = context.SkillCategories.FirstOrDefault(item => item.Name.Equals("APIs")).Id;
            var db = context.SkillCategories.FirstOrDefault(item => item.Name.Equals("Databases")).Id;

            var techSkills = new TechSkill[] {
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "C#", SkillLevel = "Expert"},
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "Java", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "Visual Basic/VB.NET", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "Javascript", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "SQL", SkillLevel = "Expert"},
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "HTML", SkillLevel = "Expert"},
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "CSS", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = lang, Name = "TypeScript", SkillLevel = "Entry"},
                              
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "ASP.NET", SkillLevel = "Expert"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "ASP.NET MVC", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "Core ASP.NET", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "Windows Forms", SkillLevel = "Expert"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "Angular 7", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "AJAX", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "JQuery", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "Entity Framework", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "REST Services", SkillLevel = "Expert"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "Android", SkillLevel = "Entry"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "LINQ", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "WebAPI", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "Angular", SkillLevel = "Entry"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "Angular Material", SkillLevel = "Entry"},
              new TechSkill {UserId = userId, SkillCategoryId = api, Name = "JSON", SkillLevel = "Proficient"},

              new TechSkill {UserId = userId, SkillCategoryId = db, Name = "Microsoft SQL Server", SkillLevel = "Expert"},
              new TechSkill {UserId = userId, SkillCategoryId = db, Name = "MySQL", SkillLevel = "Proficient"},
              new TechSkill {UserId = userId, SkillCategoryId = db, Name = "Oracle", SkillLevel = "Entry"}
            };

            foreach (var item in techSkills)
            {
                context.TechSkills.Add(item);
            }
            context.SaveChanges();

            var educationItems = new EducationItem[] {
                new EducationItem {UserId = userId, Description = "Harvard University", Degree = "One year, studied economics and some computer science."},
                new EducationItem {UserId = userId, Description = "Vanderbilt University School of Engineering", Degree = "One and a half years, completed computer science curriculum but not degree requirements."}
            };
            foreach (var item in educationItems)
            {
                context.EducationItems.Add(item);
            }
            context.SaveChanges();

            var projects = new Project[] {
                new Project { UserId = userId, Name = "Dynamic Resume", Description = "A dynamically built resume application capable of hosting multiple resumes. The front end is built using Angular 7 and Angular 7 Material. The business object and data service tier is built using C# for .Net Core 2.2. The business and data tiers employe WepAPI and Entity Framework Core. The database is hosted in Microsoft SQL Server.", DemoUrl = "https://www.justmyresume.com", GitHubUrl = "https://somegithub.com" }
            };
            foreach (var item in projects)
            {
                context.Projects.Add(item);
            }
            context.SaveChanges();
        }
    }
}