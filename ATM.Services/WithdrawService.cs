using ATM.Core.Application;
using ATM.Core.Data;
using ATM.Core.Entities;
using ATM.Core.Enums;
using AutoMapper;
using System;


namespace ATM.Services
{
    class WithdrawService : BaseServiceClass, IWithdrawService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapp { get; set; }
        public WithdrawService(IUnitOfWork unitOfWork, IMapper mapp) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapp = mapp;

        }

        public void Withdraw(string cardNumber, decimal amount)
        {

            var card = _unitOfWork.CardRepository.GetByCardNumber(cardNumber);
            var balance = card.Balance;
            var dto = new Transaction
            {
                Amount = amount,
                Dated = DateTime.Now,
                Type = TransactionType.Withdraw,
                Balance = balance - amount

            };
            // no transaction after 10.Or closed for service
            var entity = _mapp.Map<Transaction>(dto);
            entity.Card = card;
            _unitOfWork.TransactionRepository.Add(entity);
            //_unitOfWork.SaveChanges();
            if (amount != 0)
                card.Balance -= amount;
            _unitOfWork.SaveChanges();
        }
    }
}
