using ATM.Core.DTOs;
using ATM.Core.Enums;
using ATM.Core.Application;
using ATM.Core.Data;
using System;
using System.Collections.Generic;
using ATM.Core.Entities;
using System.Linq;

namespace ATM.Services
{
    class TransactionService : BaseServiceClass, ITransactionService
    {
        List<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTransaction(string cardNumber, decimal amount, DateTime date, TransactionType type)
        {
            throw new NotImplementedException();
        }

        public ICollection<TransactionDTO> GetTransactions(Guid UserId, int numberOfTransactions = 5)
        {
            //var transit = _unitOfWork.TransactionRepository.GetAllTransanctions(UserId).ToList();
            //return transit;
            throw new NotImplementedException();
        }
        public ICollection<TransactionDTO> GetCardTransanctions(Guid CardId)
        {
            var transactions = _unitOfWork.TransactionRepository.GetAllTransanctions(CardId);
            return transactions;
        }
    }
}
