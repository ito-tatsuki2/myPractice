using System;

namespace BankAccountNS
{
    /// <summary>   
    /// Bank Account demo class.   
    /// </summary>   
    public class BankAccount
    {
        private string m_customerName;

        private double m_balance;

        /// <summary>
        /// m_flozenは凍結状態を示す
        /// </summary>
        private bool m_frozen = false;

        private BankAccount()
        {
        }

        /// <summary>
        /// アカウント作成処理
        /// </summary>
        /// <param name="customerName">customerNameはアカウント名</param>
        /// <param name="balance">balanceは預金額</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
            Console.WriteLine("1-1");
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerName
        {
            get{return m_customerName;}
        }

        public double Balance
        {
            get {return m_balance;}
        }

        public void Debit(double amount)
        {
            Console.WriteLine("3-1");
            if (m_frozen)
            {
                Console.WriteLine("3-3");
                throw new Exception("Account frozen");
            }

            if (amount > m_balance)
            {
                Console.WriteLine("3-4");
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                Console.WriteLine("3-5");
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance -= amount; // intentionally incorrect code +=
            Console.WriteLine("3-2");
        }

        public void Credit(double amount)
        {
            Console.WriteLine("2-1");
            if (m_frozen)
            {
                Console.WriteLine("2-3");
                throw new Exception("Account frozen");
                Console.WriteLine("2-3-1");//到達不能コード上のthrowで呼び出し元に返る
            }

            if (amount < 0)
            {
                Console.WriteLine("2-4");
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
            Console.WriteLine("2-2");
        }

        /// <summary>
        /// あいうえお
        /// </summary>
        private void FreezeAccount()
        {
            m_frozen = true;
            Console.WriteLine("4-1");
        }

        /**
         * あいうえお
         */
        private void UnfreezeAccount()
        {
            m_frozen = false;
            Console.WriteLine("5-1");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vall"></param>
        /// <returns></returns>
        private int getValue(int vall)
        {

            return(vall + 1);
        }

        
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            try
            {
                ba.Credit(5.77);
            } catch(Exception)
            {
                Console.WriteLine("exception catch");
            }
            
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);

            Console.WriteLine("{0}", ba.CustomerName);
        }

    }
}
