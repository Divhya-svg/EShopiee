// <copyright file="IPaymentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.Payment
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IPaymentRepository.
    /// </summary>
    public interface IPaymentRepository
    {
        /// <summary>
        /// Insert Method.
        /// </summary>
        /// <param name="paymentType">Param1.</param>
        /// <returns>Returns Interger.</returns>
        int InsertPaymentType(Payment paymentType);

        /// <summary>
        /// Insert Payment.
        /// </summary>
        /// <param name="payment">Param1.</param>
        /// <returns>Returns integer.</returns>
        int InsertPayment(Payment payment);
    }

    /// <summary>
    /// Class PaymentRepository implements IPaymentRepository.
    /// </summary>
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IBaseRepo baseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRepository"/> class.
        /// Constructor Injection.
        /// </summary>
        /// <param name="repo">Param1.</param>
        public PaymentRepository(IBaseRepo repo)
        {
            this.baseRepo = repo;
        }

        /// <summary>
        /// Insert PaymentType Method.
        /// </summary>
        /// <param name="paymentType">Param1.</param>
        /// <returns>Returns integer.</returns>
        public int InsertPaymentType(Payment paymentType)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@PaymentType", paymentType.PaymentType, SqlDbType.VarChar));
            this.baseRepo.Insert("InsertPaymentType", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;
        }

        /// <summary>
        /// InsertPayment Method.
        /// </summary>
        /// <param name="payment">Param1.</param>
        /// <returns>Returns integer.</returns>
        public int InsertPayment(Payment payment)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@PaymentTypeId", payment.PaymentTypeId, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@CardNUmber", payment.CardNumber, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@ExpiryDate", payment.ExpiryDate, SqlDbType.DateTime));
            parameters.Add(this.baseRepo.CreateParameter("@CVV", payment.CVV, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@Amount", payment.Amount, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@DateOfPayment", payment.DateOfPayment, SqlDbType.DateTime));
            this.baseRepo.Insert("InsertPayments", CommandType.StoredProcedure, parameters.ToArray(), out int lastId);
            return lastId;
        }
    }
}
