// <copyright file="IPaymentRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.BL.Payment
{
    using Kanini.ECommerce.EShopiee.DAL.Payment;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// IPaymentRepo Interface.
    /// </summary>
    public interface IPaymentRepo
    {
        /// <summary>
        /// InsertPPayementType Method.
        /// </summary>
        /// <param name="paymentType">payementType.</param>
        /// <returns>Returns integer.</returns>
        int InsertPaymentType(Payment paymentType);

        /// <summary>
        /// Insert Method.
        /// </summary>
        /// <param name="payment">Param.</param>
        /// <returns>Returns Integer.</returns>
        int InsertPayment(Payment payment);
    }

    /// <summary>
    /// Class PaymentsBl implements IPaymentsBl.
    /// </summary>
    public class PaymentRepo : IPaymentRepo
    {
        private readonly IPaymentRepository paymentsDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRepo"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="dal">dal parameter.</param>
        public PaymentRepo(IPaymentRepository dal)
        {
            this.paymentsDal = dal;
        }

        /// <summary>
        /// InsertPayemtType Method.
        /// </summary>
        /// <param name="paymentType">payementType param.</param>
        /// <returns>Returns integer.</returns>
        public int InsertPaymentType(Payment paymentType)
        {
            return this.paymentsDal.InsertPaymentType(paymentType);
        }

        /// <summary>
        /// InsertPayments Method.
        /// </summary>
        /// <param name="payment">Param1.</param>
        /// <returns>Returns integer.</returns>
        public int InsertPayment(Payment payment)
        {
            return this.paymentsDal.InsertPayment(payment);
        }
    }
}
