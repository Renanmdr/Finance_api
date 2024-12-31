﻿using Bogus;
using Finance.Communication.Enums;
using Finance.Communication.Requests;

namespace CommomTestUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        return new Faker<RequestExpenseJson>()
        .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
        .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
        .RuleFor(r => r.Date, faker => faker.Date.Past())
        .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
        .RuleFor(r => r.Amount, faker => faker.Random.Decimal());
        
    }
}