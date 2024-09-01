using ABC_Car_Traders.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ABC_Car_Traders.Utils;
using System.Xml.Linq;

namespace ABC_Car_Traders
{
    public partial class RejectOrder : Form
    {


        private AppDbContext _context;
        private Guid _selectedOrderIndex;
        private string _orderType;
        private int _rowIndex;
        private Admin_dashboard _adminDashboard;

        public RejectOrder(Guid selectedOrderIndex, string orderType, Admin_dashboard adminDashboard, int rowIndex)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _selectedOrderIndex = selectedOrderIndex;
            _orderType = orderType;
            _adminDashboard = adminDashboard;
            _rowIndex = rowIndex;
        }

        private void RejectOrder_Load(object sender, EventArgs e)
        {
        }

        public class OrderDisplayModel
        {
            public Guid OrderId { get; set; }
            public string OrderType { get; set; }
            public string ItemName { get; set; }
            public string ImagePath { get; set; }
            public int Quantity { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerPhone { get; set; }
            public DateTime OrderedDate { get; set; }
            public DateTime CancelDate { get; set; }
            public decimal Price { get; set; }
            public string Status { get; set; }
        }

        public OrderDisplayModel GetSelectedOrderDetails()
        {
            if (_orderType == "Car Order")
            {
                var carOrder = _context.Orders.FirstOrDefault(x => x.Id == _selectedOrderIndex);
                if (carOrder != null)
                {
                    return new OrderDisplayModel
                    {
                        OrderId = carOrder.Id,
                        OrderType = "Car Order",
                        ItemName = carOrder.Car.CarMake.Make,
                        CustomerName = carOrder.User.Name,
                        CustomerEmail = carOrder.User.Email,
                        OrderedDate = carOrder.CreatedDate,
                    };
                }
            }
            else if (_orderType == "Spare Part Order")
            {
                var sparePartOrder = _context.Orders.FirstOrDefault(x => x.Id == _selectedOrderIndex);
                if (sparePartOrder != null)
                {
                    return new OrderDisplayModel
                    {
                        OrderId = sparePartOrder.Id,
                        OrderType = "Spare Part Order",
                        ItemName = sparePartOrder.CarSparePart.PartName,
                        CustomerName = sparePartOrder.User.Name,
                        CustomerEmail = sparePartOrder.User.Email,
                        OrderedDate = sparePartOrder.CreatedDate,
                    };
                }
            }

            return null; // Return null if the order is not found
        }


        public (string reason, string description) GetReason()
        {
            if (rbtnOutofStock.Checked)
            {
                return (rbtnOutofStock.Text, "The item is currently unavailable and cannot be fulfilled at this time.");
            }
            else if (rbtnDeleiveryAddNotAvai.Checked)
            {
                return (rbtnDeleiveryAddNotAvai.Text, "Unfortunately, the delivery address you provided is outside our serviceable area. We are unable to complete deliveries to this location.");
            }
            else if (rbtnQuantityExceed.Checked)
            {
                return (rbtnQuantityExceed.Text, "Unfortunately, the quantity you requested exceeds the allowable limit for this item. This limit is in place to ensure fair availability of our products to all customers.");
            }
            else if (rbtnProductDis.Checked)
            {
                return (rbtnProductDis.Text, "The product you ordered has been discontinued and is no longer available for purchase. We apologize for any inconvenience this may cause.");
            }
            else if (rbtnUnableContanct.Checked)
            {
                return (rbtnUnableContanct.Text, "We were unable to contact you to obtain necessary details to process your order. Without this information, we cannot proceed with the order.");
            }
            else if (rbtnDupliOrder.Checked)
            {
                return (rbtnDupliOrder.Text, "This order appears to be a duplicate of a previous one, and as a result, it has been rejected.");
            }
            return (string.Empty, string.Empty);
        }


        private void btnConfirmRejection_Click(object sender, EventArgs e)
        {
            RejectedOrder();
        }

        private void RejectedOrder()
        {
            var order = GetSelectedOrderDetails();
            var email = order.CustomerEmail;
            var name = order.CustomerName;

            if (order != null)
            {
                var result = MessageBox.Show("Are you sure you want to Reject this order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool orderRejected = false;

                    if (order.OrderType == "Car Order")
                    {
                        var carOrder = _context.Orders.FirstOrDefault(co => co.Id == order.OrderId);
                        if (carOrder != null)
                        {
                            carOrder.Option = "Rejected";
                            _context.SaveChanges();
                            orderRejected = true;
                            SendmailOrderRejection(email, name);
                            MessageBox.Show("Car order rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Car order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        var sparePartOrder = _context.Orders.FirstOrDefault(spo => spo.Id == order.OrderId);
                        if (sparePartOrder != null)
                        {
                            sparePartOrder.Option = "Rejected";
                            _context.SaveChanges();
                            orderRejected = true;
                            SendmailOrderRejection(email, name);
                            MessageBox.Show("Spare part order rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Spare part order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (orderRejected)
                    {
                        //_adminDashboard.RemoveOrderRow(_rowIndex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid row index.");
            }
        }

        public void SendmailOrderRejection(string email, string name)
        {
            var orderDetails = GetSelectedOrderDetails();
            email = orderDetails.CustomerEmail;
            name = orderDetails.CustomerName;
            var (reason, description) = GetReason();

            if (orderDetails != null && !string.IsNullOrEmpty(reason) && !string.IsNullOrEmpty(description))
            {
                MailSender mailSender = new MailSender();
                mailSender.SendMail(email, name, MailSender.EmailType.OrderRejection, orderDetails.ItemName, orderDetails.OrderedDate, reason, description);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a reason for rejection or ensure the order exists.");
            }
        }
    }
}
