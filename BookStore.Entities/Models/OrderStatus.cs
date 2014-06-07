using BookStore.Entities.Helpers;

namespace BookStore.Entities.Models
{
    public enum OrderStatus
    {
        [ResxAttribute("Zamówione")]
        Ordered = 0,
        [ResxAttribute("Gotowe do odbioru")]
        Ready = 1,
        [ResxAttribute("Zrealizowane")]
        Executed = 2,
        [ResxAttribute("Anulowane")]
        Canceled = 3
    }
}