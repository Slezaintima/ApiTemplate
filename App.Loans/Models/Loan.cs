namespace App.Loans.Models
{
    public class Loan
    {
        private readonly double money;
        public int time { get; set; }
        public double moneyTaked { get; set; }
        public double moneyBack { get; set; }
        public double moneyLeft { get { return money; } }
        public double percent { get; set; }

        public Loan(double moneyTake, double percent, int time)
        {
            this.time = time;
            this.moneyTaked = moneyTake;
            this.percent = percent;
            this.moneyBack = 0;
            money = moneyTaked + (moneyTaked * (time / 12) * percent) - moneyBack;
        }
        public void GetMoneyBack(int money)
        {
            if (money >= moneyLeft / time)
                moneyBack += money;
        }
        public override string ToString() => "Money taked: " + moneyTaked + "for time: " + time + "month by " + percent + " percent";
    }
}
