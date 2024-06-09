using System.Net;

namespace ChatApp.Models;

public class ReturnModel
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public int TotalCount { get; set; }
}
