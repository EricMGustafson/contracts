namespace contracts.Models
{
  public class Company
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class JobViewModel : Company
  {
    public int Job { get; set; }
  }
}