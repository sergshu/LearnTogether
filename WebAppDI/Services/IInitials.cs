using WebAppDI.Models;

namespace WebAppDI.Services
{
    public interface IInitials
    {
        string Get(TestItemView item);
    }
}