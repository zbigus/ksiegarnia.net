namespace BookStore.Logic.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}