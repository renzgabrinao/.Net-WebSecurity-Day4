using SendGrid;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IEmailService
    {
        Task<Response> SendSingleEmail(ComposeEmailModel payload);
    }

}
