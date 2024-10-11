namespace Company.Generic_Approval_App.Model;

public class Approval
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class ApprovalDetails : Approval
{
    public string FullDescription { get; set; }
}