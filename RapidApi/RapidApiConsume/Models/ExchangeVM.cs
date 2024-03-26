namespace RapidApiConsume.Models
{
    public class ExchangeVM
    {
        //Exchange'in Result kısmına baktığımızda IMBD gibi değil iç içe bir yapı var. (3 keys -> parametreler var.) O yüzden oradaki kodu copy dedik burada "Edit -> Paste Special -> Paste JSON as" tıklanır. Aşağıdaki yapı elde edilir. (İlk 3 prop bir class'ın içinde gelir. Biz zaten ExchangeVM oluşturduğumuz için sadece o class'ın adı silinir.)
        //Bizim amacımız "exchange_rates" içindeki "exchange_rate_buy" ve "currency" ulaşmak.

        public Exchange_Rates[] exchange_rates { get; set; }
        public string base_currency_date { get; set; }
        public string base_currency { get; set; }

        public class Exchange_Rates
        {
            public string exchange_rate_buy { get; set; }
            public string currency { get; set; }
        }
    }
}
