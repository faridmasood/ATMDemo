using ATM.Core.Application;
using ATM.Core.Data;
using ATM.Core.Entities;
using ATM.Core.Enums;
using System;
using AutoMapper;
using System.Threading.Tasks;

namespace ATM.Services
{
    class DepositService : BaseServiceClass, IDepositService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapp { get; set; }
        public DepositService(IUnitOfWork unitOfWork, IMapper mapp) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapp = mapp;

        }

        public async Task<bool> DepositAsync(string cardNumber, decimal amount)
        {
            var card = _unitOfWork.CardRepository.GetByCardNumber(cardNumber);
            var balance = card.Balance;
            var dto = new Transaction
            {
                Amount = amount,
                Dated = DateTime.Now,
                Type = TransactionType.Deposit,
                Balance = balance + amount

            };
            // no transaction after 10.Or closed for service
            var entity = _mapp.Map<Transaction>(dto);
            entity.Card = card;
            _unitOfWork.TransactionRepository.Add(entity);
            if (amount != 0)
                card.Balance += amount;
            await _unitOfWork.SaveChanges();
            return true;
        }
    }
}
