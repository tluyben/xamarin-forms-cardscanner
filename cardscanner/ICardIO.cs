using System;

namespace cardscanner
{
    public class CardInfo
    {
        public string PAN { get; set; }
        public string Expiry { get; set;  }
        public string Name { get; set; }
        public string CVV { get; set; }
    }
    public class CardInfoEventArgs : EventArgs
    {
        public CardInfo CardInfo { get; set; }
    }
    public interface ICardIO
    {
        void Present();
        event EventHandler<CardInfoEventArgs> ScanningDone; 
    }
}
