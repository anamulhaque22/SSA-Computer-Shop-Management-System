using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        [Required]
        public string OrderAddress { get; set; }

        public string OrderNote { get; set; }

        public string OrderStatus { get; private set; }
        // Public methods to set the OrderStatus
        public void SetStatusPending()
        {
            OrderStatus = "Pending";
        }

        public void SetStatusConfirm()
        {
            OrderStatus = "Confirm";
        }

        public void SetStatusOnTheWay()
        {
            OrderStatus = "On The Way";
        }

        public void SetStatusDelivered()
        {
            OrderStatus = "Delivered";
        }
        public void SetStatusCancled()
        {
            OrderStatus = "Canceled";
        }

        public string PaymentStatus { get; private set; }
        public void SetPaymentStatusPending()
        {
            PaymentStatus = "Pending";
        }
        public void SetPaymentStatusCompleted()
        {
            PaymentStatus = "Completed";
        }
        public void SetPaymentStatusCancled()
        {
            PaymentStatus = "Canceled";
        }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
