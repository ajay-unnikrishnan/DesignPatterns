using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public class ValidateBridge
    {
        Payment order = new CardPayment();        
        
    }
    public interface IpaymentSystem
    {
        public void ProcessPayment();
    }
    public class CityPayment : IpaymentSystem
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment Processed through City bank");
        }
    }
    public class PaypalPayment : IpaymentSystem
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment Processed through Paypal");
        }
    }
    public abstract class Payment
    {
        private IpaymentSystem _iPaymentSystem;   
        public Payment(IpaymentSystem ipaymentSystem)
        {
            _iPaymentSystem = ipaymentSystem;
        }
        public abstract void MakePayment();
    }
    public class CardPayment : Payment
    {
        public CardPayment(IpaymentSystem ipaymentSystem): base(ipaymentSystem)
        {

        }
        public override void MakePayment()
        {
            Console.WriteLine("Card Payment");
        }
    }
}
