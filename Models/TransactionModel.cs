﻿namespace PaymentIntegration.Models
{
    public class TransactionModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name{ get; set; }
        public string Amount { get; set; }
        public string TrxRef { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
