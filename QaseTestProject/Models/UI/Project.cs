namespace QaseTestProject.Models.UI;

public class Project
{
    public string Title { get; }
    public string Code { get; }
    public string Description { get; }
    public string ProjectAccessType { get; }
    public string MemberAccessType { get; }
    

    private Project(string title, string code, string description, string projectAccessType, string memberAccessType)
    {
        Title = title;
        Code = code;
        Description = description;
        ProjectAccessType = projectAccessType;
        MemberAccessType = memberAccessType;
    }

    public class Builder
    {
        private string Title { get; set; }
        private string Code { get; set; }
        private string Description { get; set; }
        private string ProjectAccessType { get; set; }
        private string MemberAccessType { get; set; }

        public Builder SetTitle(string title)
        {
            Title = title;
            return this;
        }
        
        public Builder SetCode(string code)
        {
            Code = code;
            return this;
        }
        
        public Builder SetDescription(string description)
        {
            Description = description;
            return this;
        }
        
        public Builder SetProjectAccessType(string projectAccessType)
        {
            ProjectAccessType = projectAccessType;
            return this;
        }
        
        public Builder SetMemberAccessType(string memberAccessType)
        {
            MemberAccessType = memberAccessType;
            return this;
        }

        public Project Build()
        {
            if (string.IsNullOrEmpty(Title))
                throw new InvalidOperationException("Title must be set.");
            if (string.IsNullOrEmpty(Code))
                throw new InvalidOperationException("Code must be set.");

            return new Project(Title, Code, Description, ProjectAccessType, MemberAccessType);
        }
    }
    
}