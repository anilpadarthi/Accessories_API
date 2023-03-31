using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using POS_Accessories.Business.Helper;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using System.Data;

namespace POS_Accessories.Business.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public CommunicationService(IConfigurationRepository ConfigurationRepository)
        {
            _configurationRepository = ConfigurationRepository;
        }
        public async Task<CommonResponse> SendEmailInvoice(Configuration request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _configurationRepository.ValidateUnique(request);
                if (result != null)
                {
                    response = Utility.CreateResponse("Configuration already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    request.Status = "A";
                    request.IsActive = true;
                    await _configurationRepository.CreateAsync(request);
                    response = Utility.CreateResponse("Created successfully", HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> DownloaInvoiceWithOutVAT(Configuration request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _configurationRepository.ValidateUnique(request);
                if (result != null && result.ConfigId != request.ConfigId)
                {
                    response = Utility.CreateResponse("Name already exist", HttpStatusCode.Conflict);
                }
                else
                {
                    await _configurationRepository.UpdateAsync(request);
                    response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }
        public async Task<CommonResponse> DownloadInvoiceWithVAT(int id, string status)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                await _configurationRepository.UpdateStatusAsync(id, status);
                response = Utility.CreateResponse("Updated successfully", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        //public byte[] GeneratePDFInvoice(int shopId, string DeliveryChareges, int orderId, string requestType, bool IsComapnyDetailsInclude = true)
        //{
        //    ManageAccountBAL objManageAccountBAL = new ManageAccountBAL();
        //    var shopObj = objManageAccountBAL.GetShopDetails(shopId);
        //    DataSet ds = CommonBAL.GetOrderDetails(orderId, requestType);
        //    DataTable dtOrderDetails = ds.Tables[0];
        //    var orderDate = DateTime.Now.ToString("MMMM dd yyyy");
        //    var paymentMethod = "";
        //    var orderBy = "";

        //    if (dtOrderDetails != null && dtOrderDetails.Rows.Count > 0)
        //    {
        //        orderDate = Convert.ToDateTime(dtOrderDetails.Rows[0]["OrderDate"]).ToString("MMMM dd yyyy");
        //        paymentMethod = Convert.ToString(dtOrderDetails.Rows[0]["PaymentMethod"]);
        //        orderBy = Convert.ToString(dtOrderDetails.Rows[0]["UserName"]);
        //    }
        //    var paymentMethodCode = "";
        //    if (requestType == "ShopAccessories")
        //    {
        //        if (paymentMethod == "Bank Transfer")
        //            paymentMethodCode = "BT";
        //        else if (paymentMethod == "Against Commission")
        //            paymentMethodCode = "AC";
        //        else if (paymentMethod == "For Commission")
        //            paymentMethodCode = "FC";
        //        else if (paymentMethod == "Cash on delivery")
        //            paymentMethodCode = "COD";
        //        else if (paymentMethod == "Free")
        //            paymentMethodCode = "F";
        //        else if (paymentMethod == "Cheque")
        //            paymentMethodCode = "CQ";
        //        else if (paymentMethod == "Cash Paid")
        //            paymentMethodCode = "CP";
        //        else if (paymentMethod == "Voucher")
        //            paymentMethodCode = "V";
        //        else
        //            paymentMethodCode = paymentMethod;
        //    }

        //    MemoryStream workStream = new MemoryStream();
        //    Document document = new Document(PageSize.A4, 5f, 5f, 15f, 15f);
        //    Font NormalFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
        //    PdfWriter writer = PdfWriter.GetInstance(document, workStream);

        //    document.Open();
        //    PdfPTable table = null;
        //    var hasPages = false;
        //    hasPages = true;
        //    table = new PdfPTable(2);
        //    table.TotalWidth = 550f;
        //    table.LockedWidth = true;

        //    if (IsComapnyDetailsInclude)
        //    {
        //        var cell0 = PhraseCell(new Phrase("Leap", FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.RED)), PdfPCell.ALIGN_LEFT);
        //        cell0.PaddingTop = 10f;
        //        cell0.Rowspan = 4;
        //        table.AddCell(cell0);
        //    }
        //    else
        //    {
        //        var cell1 = PhraseCell(new Phrase(paymentMethodCode, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        cell1.PaddingTop = 15f;
        //        cell1.Rowspan = 4;
        //        table.AddCell(cell1);
        //    }

        //    if (requestType != "ShopAccessories")
        //    {
        //        var cell2 = PhraseCell(new Phrase(requestType + " INVOICE : INV" + orderId, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.RED)), PdfPCell.ALIGN_RIGHT);
        //        table.AddCell(cell2);
        //    }
        //    else
        //    {
        //        var cell3 = PhraseCell(new Phrase("INVOICE : INV" + orderId, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.RED)), PdfPCell.ALIGN_RIGHT);
        //        table.AddCell(cell3);
        //    }

        //    var cell = PhraseCell(new Phrase("OrderId : 100" + orderId, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT);
        //    table.AddCell(cell);
        //    if (requestType == "ShopAccessories")
        //    {
        //        var cell2 = PhraseCell(new Phrase("Type : " + paymentMethodCode, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT);
        //        table.AddCell(cell2);
        //    }
        //    cell = PhraseCell(new Phrase(orderDate, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT);
        //    table.AddCell(cell);

        //    //if (IsComapnyDetailsInclude)
        //    //{
        //    //    cell = PhraseCell(new Phrase(paymentMethod, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT);
        //    //    cell.PaddingBottom = 20f;
        //    //    table.AddCell(cell);
        //    //}

        //    cell = PhraseCell(new Phrase(orderBy + "/" + shopObj.AreaCode, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT);
        //    cell.Colspan = 2;
        //    cell.PaddingBottom = 20f;
        //    table.AddCell(cell);
        //    document.Add(table);

        //    if (requestType == "ShopAccessories")
        //    {
        //        LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
        //        document.Add(line);

        //        table = new PdfPTable(2);
        //        table.TotalWidth = 550f;
        //        table.LockedWidth = true;

        //        if (!IsComapnyDetailsInclude)
        //        {
        //            cell = PhraseCell(new Phrase("DELIVERY NOTE", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
        //            cell.PaddingTop = 20f;
        //            cell.Colspan = 2;
        //            table.AddCell(cell);
        //        }

        //        cell = PhraseCell(new Phrase("Customer: " + shopId, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        cell.PaddingTop = 20f;
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "Seller:" : " ", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        cell.PaddingTop = 20f;
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase(shopObj.ShopName, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.RED)), PdfPCell.ALIGN_LEFT);
        //        cell.PaddingTop = 10f;
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "M Comm Solutions Ltd" : " ", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.RED)), PdfPCell.ALIGN_LEFT);
        //        cell.PaddingTop = 10f;
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase(shopObj.ContactName, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        cell.Colspan = 2;
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(shopObj.Address1, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "The Charter News, 18A Beehive Ln" : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase(shopObj.City + ", " + shopObj.PostCode, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "Ilford, IG1 3RD" : "", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase("United Kingdom", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "United Kingdom" : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase(shopObj.ContactNumber, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "03330119880" : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase(shopObj.ShopOwnerEmail, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "orders@mcommsolutions.co.uk" : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "Vat No: 182581101" : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        table.AddCell(cell);

        //        cell = PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        cell.PaddingBottom = 20f;
        //        table.AddCell(cell);
        //        cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "Reg No: 8060121" : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //        cell.PaddingBottom = 20f;
        //        table.AddCell(cell);
        //        document.Add(table);
        //    }

        //    table = new PdfPTable(5);
        //    table.TotalWidth = 550f;
        //    table.LockedWidth = true;
        //    var widths = new float[] { 90f, 190f, 90f, 90f, 90f };
        //    table.SetWidths(widths);

        //    List<Product> cartItems = new List<Product>();
        //    decimal orderAmount = 0, discountAmount = 0, bundleAmount = 0, bundleTotal = 0, bundlediscount = 0;
        //    string discount = "";

        //    if (dtOrderDetails != null)
        //    {
        //        foreach (DataRow row in dtOrderDetails.Rows)
        //        {
        //            Product product = new Product();
        //            product.ProductId = Convert.ToInt32(row[0]);
        //            product.ProductName = Convert.ToString(row[1]);
        //            product.ProductQantity = Convert.ToInt32(row[2]);
        //            product.ProductCost = Convert.ToDecimal(row[3]);
        //            product.TotalAmount = Convert.ToDecimal(product.ProductQantity * product.ProductCost);
        //            product.ProductCode = Convert.ToString(row["ProductCode"]);
        //            product.IsManinBundleProduct = Convert.ToBoolean(row["IsBundle"]);
        //            cartItems.Add(product);

        //            if (product.IsManinBundleProduct)
        //            {
        //                var bundleQuantity = product.ProductQantity;
        //                var dtBundleDetails = CommonBAL.GetBundleDetails(product.ProductId ?? 0).Tables[0];
        //                foreach (DataRow drow in dtBundleDetails.Rows)
        //                {
        //                    product = new Product();
        //                    product.ProductId = Convert.ToInt32(drow[0]);
        //                    product.ProductName = Convert.ToString(drow[1]);
        //                    product.ProductQantity = bundleQuantity * Convert.ToInt32(drow[2]);
        //                    product.ProductCost = Convert.ToDecimal(drow[3]);
        //                    product.TotalAmount = Convert.ToDecimal(product.ProductQantity * product.ProductCost);
        //                    product.ProductCode = Convert.ToString(drow["ProductCode"]);
        //                    product.IsBundleProduct = true;
        //                    cartItems.Add(product);
        //                }
        //            }

        //            if (requestType == "ShopAccessories")
        //            {
        //                discount = Convert.ToString(row["discount"]);
        //                discountAmount = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(row["discountAmount"])) ? "0" : Convert.ToString(row["discountAmount"]));
        //            }
        //        }
        //    }

        //    cell = new PdfPCell(new Phrase("Product Code", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE)));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.PaddingBottom = 5f;
        //    cell.PaddingTop = 3f;
        //    cell.BackgroundColor = BaseColor.RED;
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("Product Name", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE)));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.PaddingBottom = 5f;
        //    cell.PaddingTop = 3f;
        //    cell.BackgroundColor = BaseColor.RED;
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("Quantity", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.PaddingBottom = 5f;
        //    cell.PaddingTop = 3f;
        //    cell.BackgroundColor = BaseColor.RED;
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("Price", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.PaddingBottom = 5f;
        //    cell.PaddingTop = 3f;
        //    cell.BackgroundColor = BaseColor.RED;
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.PaddingBottom = 5f;
        //    cell.PaddingTop = 3f;
        //    cell.BackgroundColor = BaseColor.RED;
        //    table.AddCell(cell);

        //    for (var i = 0; i < cartItems.Count; i++)
        //    {
        //        cell = new PdfPCell(new Phrase(Convert.ToString(cartItems[i].ProductCode), FontFactory.GetFont("Arial", 10, (cartItems[i].IsManinBundleProduct ? Font.BOLD : Font.NORMAL), BaseColor.BLACK)));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        cell = new PdfPCell(new Phrase(cartItems[i].ProductName, FontFactory.GetFont("Arial", 10, (cartItems[i].IsManinBundleProduct ? Font.BOLD : Font.NORMAL), BaseColor.BLACK)));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        cell = new PdfPCell(new Phrase(cartItems[i].ProductQantity.ToString(), FontFactory.GetFont("Arial", 10, (cartItems[i].IsManinBundleProduct ? Font.BOLD : Font.NORMAL), BaseColor.BLACK)));
        //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        cell = new PdfPCell(new Phrase("£ " + cartItems[i].ProductCost.ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
        //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        if (cartItems[i].IsManinBundleProduct)
        //        {
        //            cell = new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);
        //            bundleAmount += cartItems[i].TotalAmount;
        //        }
        //        else
        //        {
        //            cell = new PdfPCell(new Phrase("£ " + cartItems[i].TotalAmount.ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);
        //            if (cartItems[i].IsBundleProduct)
        //            {
        //                bundleTotal += cartItems[i].TotalAmount;
        //            }
        //            orderAmount += cartItems[i].TotalAmount;
        //        }
        //    }

        //    var deliveryAmount = Convert.ToDecimal(string.IsNullOrEmpty(DeliveryChareges) ? "0.00" : DeliveryChareges);

        //    if (bundleAmount > 0)
        //    {
        //        bundlediscount = bundleTotal - bundleAmount;
        //    }
        //    var vatAmount = Convert.ToDecimal((orderAmount - discountAmount - bundlediscount) * 20 / 100);
        //    cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    cell.Colspan = 4;
        //    cell.PaddingBottom = 3f;
        //    cell.PaddingTop = 3f;
        //    table.AddCell(cell);

        //    cell = new PdfPCell(new Phrase("£ " + orderAmount.ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.PaddingBottom = 3f;
        //    cell.PaddingTop = 3f;
        //    table.AddCell(cell);

        //    if (requestType == "ShopAccessories")
        //    {
        //        if (IsComapnyDetailsInclude)
        //        {
        //            cell = new PdfPCell(new Phrase(IsComapnyDetailsInclude ? "Vat 20%" : "Tax", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cell.Colspan = 4;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);

        //            cell = new PdfPCell(new Phrase("£ " + vatAmount.ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.RED)));
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);
        //        }

        //        cell = new PdfPCell(new Phrase("Delivery Charges", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //        cell.Colspan = 4;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        cell = new PdfPCell(new Phrase("£ " + deliveryAmount.ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.RED)));
        //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        if (discountAmount > 0)
        //        {
        //            cell = new PdfPCell(new Phrase("Discount " + discount + "%", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cell.Colspan = 4;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);

        //            cell = new PdfPCell(new Phrase("£ " + discountAmount.ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLUE)));
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);
        //        }

        //        if (bundlediscount > 0)
        //        {
        //            cell = new PdfPCell(new Phrase("Bundle Discount ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cell.Colspan = 4;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);

        //            cell = new PdfPCell(new Phrase("£ " + bundlediscount.ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLUE)));
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);
        //        }

        //        cell = new PdfPCell(new Phrase("Total Amount", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //        cell.Colspan = 4;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        if (IsComapnyDetailsInclude)
        //        {
        //            cell = new PdfPCell(new Phrase("£ " + (orderAmount + vatAmount + deliveryAmount - discountAmount - bundlediscount).ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.RED)));
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);
        //        }
        //        else
        //        {
        //            cell = new PdfPCell(new Phrase("£ " + (orderAmount + deliveryAmount - discountAmount - bundlediscount).ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.RED)));
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.PaddingBottom = 3f;
        //            cell.PaddingTop = 3f;
        //            table.AddCell(cell);
        //        }
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("Total Amount", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //        cell.Colspan = 4;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);

        //        cell = new PdfPCell(new Phrase("£ " + (orderAmount).ToString("0.00"), FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.RED)));
        //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        cell.PaddingBottom = 3f;
        //        cell.PaddingTop = 3f;
        //        table.AddCell(cell);
        //    }

        //    cell = PhraseCell(new Phrase(" ", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    cell.Colspan = 5;
        //    table.AddCell(cell);
        //    document.Add(table);

        //    table = new PdfPTable(1);
        //    table.TotalWidth = 550f;
        //    table.LockedWidth = true;

        //    cell = PhraseCell(new Phrase(IsComapnyDetailsInclude ? "Any shortages must be notified immediately. Title of goods remain the property of M Comm Solutions Limited until payment is received in full." : " ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
        //    cell.PaddingTop = 30f;
        //    table.AddCell(cell);

        //    document.Add(table);

        //    if (hasPages)
        //    {
        //        document.Close();
        //        byte[] byteInfo = workStream.ToArray();
        //        return byteInfo;
        //    }
        //    return new byte[4];
        //}

        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }


    }
}
