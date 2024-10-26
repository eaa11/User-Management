﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.API.Commom.Constants;
using UserManagement.API.Features.Commom;
using UserManagement.API.Features.Users.Entities;

namespace UserManagement.API.Infrastructure.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private static readonly ValueConverter<Name, string> NameConverter = new(
            name => name.Value,
            value => new Name(value)
        );

        private static readonly ValueConverter<Email, string> EmailConverter = new(
            email => email.Value,
            value => new Email(value)
        );

        private static readonly ValueConverter<Password, string> PasswordConverter = new(
        password => password.Value,
            value => new Password(value, null)
        );

        private static readonly ValueConverter<Token, string> TokenConverter = new(
            token => token.ToString(),
            value => new Token(value)
        );

        private static readonly ValueConverter<DateTimeValue, DateTime> DateTimeConverter = new(
            dateTimeValue => dateTimeValue.Value,
            dateTime => new DateTimeValue(dateTime)
        );

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedNever();

            builder.Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
                .HasConversion(NameConverter);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH)
                .HasConversion(EmailConverter);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(user => user.Password)
                .HasConversion(PasswordConverter);

            builder.Property(user => user.Token)
                .HasConversion(TokenConverter);

            builder.Property(user => user.Created)
                .HasConversion(DateTimeConverter);
            builder.Property(user => user.Modified)
                .HasConversion(DateTimeConverter);
            builder.Property(user => user.LastLogin)
                .HasConversion(DateTimeConverter);
            builder.Property(u => u.IsActive)
                .IsRequired();

            builder.OwnsMany(u => u.Phones, phoneBuilder =>
            {
                phoneBuilder.Property(p => p.Id)
                .IsRequired()
                .HasColumnOrder(1);

                phoneBuilder.WithOwner()
                .HasForeignKey("UserId");

                phoneBuilder.Property(p => p.CountryCode)
                .HasColumnOrder(2)
                .IsRequired();
                phoneBuilder.Property(p => p.CityCode)
                .HasColumnOrder(3)
                .IsRequired();

                phoneBuilder.HasKey("UserId", nameof(Phone.Number));
            });
        }
    }
}