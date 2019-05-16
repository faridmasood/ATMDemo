using ATM.Core.DTOs;
using ATM.Core.Enums;
using ATM.Core.Application;
using ATM.Core.Data;
using System;
using System.Collections.Generic;
using ATM.Core.Entities;
using System.Linq;
using AutoMapper;

namespace ATM.Services
{
    class TransactionService : BaseServiceClass, ITransactionService
    {
        List<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
        private readonly IUnitOfWork _unitOfWork;
        public Transaction transaction { get; set; }
        public IMapper _mapp { get; set; }

        private IDepositService _depositService;
        private IWithdrawService _withdrawService;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapp, IWithdrawService withdrawService, IDepositService depositService) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapp = mapp;
            _depositService = depositService;
            _withdrawService = withdrawService;
        }

        public void AddTransaction(string cardNumber, decimal amount, DateTime date, TransactionType type)
        {
            var card = _unitOfWork.CardRepository.GetByCardNumber(cardNumber);
            var balance = card.Balance;
            if (amount != 0)
            {
                if (type == TransactionType.Deposit)
                {
                    _withdrawService.WithdrawAsync(cardNumber, amount);
                    //newBalance = balance + amount;
                }
                else
                {
                    _depositService.DepositAsync(cardNumber, amount);
                    //newBalance = balance - amount;
                }
            }
            // no transaction after 10.Or closed for service
        }

        public ICollection<TransactionDTO> GetCardTransanctions(Guid CardId, int value)
        {
            var transactions = _unitOfWork.TransactionRepository.GetAllTransanctions(CardId);
            return transactions;
        }

        public decimal GetCurrentBalance(string cardNum)
        {
            var balance = _unitOfWork.CardRepository.GetByCardNumber(cardNum).Balance;
            return balance;
        }

        public decimal GetTodayWitdrawAmount(Guid CardId)
        {
            decimal limitCredit = 0;
            var transactions = _unitOfWork.TransactionRepository.GetAllTransanctions(CardId);
            var idagTransactions = transactions.Where(tran => tran.Created.Day == DateTime.Today.Day && tran.Type == TransactionType.Withdraw);
            foreach (var it in idagTransactions)
            {

                limitCredit += it.Amount;
            }
            return limitCredit;
        }
    }
}
