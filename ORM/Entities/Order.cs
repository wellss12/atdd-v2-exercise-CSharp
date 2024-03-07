namespace ATDD.V2.Exercise.CSharp.ORM.Entities;

public class Order
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string DeliverNo { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string ProductName { get; set; }
    public string RecipientAddress { get; set; }
    public string RecipientMobile { get; set; }
    public string RecipientName { get; set; }
    public string Status { get; set; }
    public decimal Total { get; set; }
}