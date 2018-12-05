using System;
using Card.IO;
using UIKit;

namespace cardscanner.iOS
{
    public class CardIO : CardIOPaymentViewControllerDelegate, ICardIO
    {
        public CardIO()
        {

        }


        public event EventHandler<CardInfoEventArgs> ScanningDone;


        CardIOPaymentViewController paymentViewController; 
        public void Present()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }
           
            paymentViewController = new CardIOPaymentViewController(this);

            vc.PresentViewController(paymentViewController, true, null); 
        }

        public override void UserDidCancelPaymentViewController(CardIOPaymentViewController paymentViewController)
        {
            paymentViewController.DismissViewController(true, null); 
            ScanningDone?.BeginInvoke(this, new CardInfoEventArgs
            {
                CardInfo = null
            }, null, null);

        }

        public override void UserDidProvideCreditCardInfo(CreditCardInfo cardInfo, CardIOPaymentViewController paymentViewController)
        {
            paymentViewController.DismissViewController(true, null);
            ScanningDone?.BeginInvoke(this, new CardInfoEventArgs
            {
                CardInfo = new CardInfo
                {
                    PAN = cardInfo.CardNumber,
                    CVV = cardInfo.Cvv,
                    Expiry = cardInfo.ExpiryMonth + "/" + cardInfo.ExpiryYear,
                    Name = cardInfo.CardholderName
                }
            }, null, null);
        }
    }
}
