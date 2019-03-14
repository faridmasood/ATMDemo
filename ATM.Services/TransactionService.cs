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

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapp) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapp = mapp;

        }

        public void AddTransaction(string cardNumber, decimal amount, DateTime date, TransactionType type)
        {
            var card = _unitOfWork.CardRepository.GetByCardNumber(cardNumber);
            var balance = _unitOfWork.TransactionRepository.GetBalance(cardNumber);
            var dto = new Transaction
            {
                Amount = amount,
                Dated = DateTime.Now,
                Type = type,
                Balance = balance + amount

            };
            // no transaction after 10.Or closed for service
            var entity = _mapp.Map<Transaction>(dto);
            entity.Card = card;
            _unitOfWork.TransactionRepository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public ICollection<TransactionDTO> GetCardTransanctions(Guid CardId, int value)
        {
            var transactions = _unitOfWork.TransactionRepository.GetAllTransanctions(CardId);
            return transactions;
        }

        public decimal GetCurrentBalance(string cardNum)
        {
            var balance = _unitOfWork.CardRepository.GetByCardNumber(cardNum).Balance;
               // TransactionRepository.GetBalance(cardNum);
            return balance;
        }
    }
}
