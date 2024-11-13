using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Idea.Models
{
    public enum Gender { Female, Male }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public string? SSN { get; set; }
        [Display(Name = "Passport ID")]
        public string? PassportID { get; set; }
        public string? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        [Display(Name = "Alternative Email")]
        public string? AlternativeEmail { get; set; }
        [Display(Name = "Alternative Phone")]
        public string? AlternativePhone { get; set; }
        public string? Address { get; set; }
        public string? Others { get; set; }

        public virtual ICollection<NIdea> Ideas { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NIdea> Ideas { get; set; }
    }

    public class Submission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Deadline 1")]
        public DateTime Deadline_1 { get; set; }
        [Display(Name = "Deadline 2")]
        public DateTime Deadline_2 { get; set; }
        // ...

        public virtual ICollection<NIdea> Ideas { get; set; }
    }

    public class NIdea
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Brief { get; set; }
        public string? Content { get; set; }
        public string? FilePath { get; set; }
        public int View { get; set; }
        // ...

        public int SubmissionId { get; set; }
        public virtual Submission Submission { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Reaction> Reactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Reaction
    {
        public int Id { get; set; }
        public int Type { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int IdeaId { get; set; }
        public virtual NIdea Idea { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created_Date { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int IdeaId { get; set; }
        public virtual NIdea Idea { get; set; }
    }
}