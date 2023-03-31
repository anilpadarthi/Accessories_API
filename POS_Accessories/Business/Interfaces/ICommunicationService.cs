using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface ICommunicationService
    {
        Task<CommonResponse> SendEmailInvoice(Configuration request);
        Task<CommonResponse> DownloaInvoiceWithOutVAT(Configuration request);
        Task<CommonResponse> DownloadInvoiceWithVAT(int id, string status);
    }
}
