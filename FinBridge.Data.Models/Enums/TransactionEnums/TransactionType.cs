namespace FinBridge.Data.Models.TransactionEnums
{
    /// <summary>
    /// Enum representing various types of transactions that can occur in a bank account.
    /// </summary>
    /// <remarks>
    /// This enum defines different transaction types such as deposits, withdrawals, transfers, 
    /// payments, fees, and other operations. Each transaction type is associated with an integer 
    /// value for easier storage and retrieval in the database. The enum helps in categorizing 
    /// transactions based on their nature and usage, which is essential for tracking financial activities.
    /// </remarks>
    public enum TransactionType
    {
        /// <summary>
        /// A deposit transaction where funds are added to the account.
        /// </summary>
        Deposit = 0,

        /// <summary>
        /// A withdrawal transaction where funds are taken from the account.
        /// </summary>
        Withdrawal = 1,

        /// <summary>
        /// A transfer transaction where funds are moved between accounts (same bank or different banks).
        /// </summary>
        Transfer = 2,

        /// <summary>
        /// A payment transaction, typically for goods or services.
        /// </summary>
        Payment = 3,

        /// <summary>
        /// A fee transaction, typically for maintenance or service charges.
        /// </summary>
        Fee = 4,

        /// <summary>
        /// A refund transaction where previously paid funds are returned to the account.
        /// </summary>
        Refund = 5,

        /// <summary>
        /// A credit transaction, where the account is credited with funds from another source.
        /// </summary>
        Credit = 6,

        /// <summary>
        /// A debit transaction, where funds are debited from the account to settle an obligation.
        /// </summary>
        Debit = 7,

        /// <summary>
        /// A loan disbursement transaction, where loan funds are credited to the account.
        /// </summary>
        LoanDisbursement = 8,

        /// <summary>
        /// A loan repayment transaction, where funds are debited from the account for loan repayment.
        /// </summary>
        LoanRepayment = 9,

        /// <summary>
        /// A chargeback transaction, where a previously settled payment is reversed.
        /// </summary>
        Chargeback = 10,

        /// <summary>
        /// A currency conversion transaction where funds are exchanged between different currencies.
        /// </summary>
        CurrencyConversion = 11,

        /// <summary>
        /// A transfer between different branches or departments within the same organization.
        /// </summary>
        InternalTransfer = 12,

        /// <summary>
        /// A scheduled payment, such as bill pay or automatic transfer setup.
        /// </summary>
        ScheduledPayment = 13,

        /// <summary>
        /// A special withdrawal that could be linked to a credit card or loan account.
        /// </summary>
        SpecialWithdrawal = 14
    }

    /// <author>ivanov2024</author>
    /// <copyright>© 2025 FinBridge. All rights reserved.</copyright>
}
