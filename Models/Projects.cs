// Models/Project.cs
using System;
using System.ComponentModel.DataAnnotations; // DateTime için
using System.ComponentModel.DataAnnotations.Schema;
namespace BlogOS.Web.Models // <-- Buradaki namespace'i kendi projenizin adıyla eşleştirin
{
    public class Project
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details{ get; set; }
        public string Category { get; set; } // "web", "mobile", "other"
        public DateTime CompletionDate { get; set; }
        public string? Technologies { get; set; }
       
        // Frontend'de data-date niteliği için uygun formatı sağlar
        public string FormattedCompletionDate => CompletionDate.ToString("yyyy-MM-dd");
    }
}