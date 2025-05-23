﻿using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinBridge.Data.EntityConfiguration
{
    internal class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
            builder
                .HasKey(th => new { th.BankAccountId, th.TransactionId });

            builder
                .HasOne(th => th.BankAccount)
                .WithMany(ba => ba.TransactionHistories)
                .HasForeignKey(th => th.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(th => th.Transaction)
                .WithMany(t => t.TransactionHistories)
                .HasForeignKey(th => th.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
