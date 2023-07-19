using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Microsoft.Extensions.DependencyInjection;
using SearchProductCatalogue.Core;
using SearchProductCatalogue.Domain;
using SearchProductCatalogue.Domain.Events;
using SearchProductCatalogue.Infrastructure;
using System.Text.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SearchProductCatalogue;

public class Function
{
    private readonly ProductAddedHandler _productAddedHandler;
    private readonly ServiceProvider _serviceProvider;

    /// <summary>
    /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
    /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
    /// region the Lambda function is executed in.
    /// </summary>
    public Function()
    {
        // Without using Dependency Injection
        //_productAddedHandler = new ProductAddedHandler(new ProductRepository(new Database()));

        // With using dependency injection
        var services = new ServiceCollection();
        services.AddSingleton<IDatabase, Database>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ProductAddedHandler>();

        _serviceProvider = services.BuildServiceProvider();
    }


    /// <summary>
    /// This method is called for every Lambda invocation. This method takes in an SNS event object and can be used 
    /// to respond to SNS messages.
    /// </summary>
    /// <param name="evnt"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task FunctionHandler(SNSEvent evnt, ILambdaContext context)
    {
        foreach (var record in evnt.Records)
        {
            await ProcessRecordAsync(record, context);
        }
    }



    private async Task ProcessRecordAsync(SNSEvent.SNSRecord record, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed record {record.Sns.Message}");

        //_productAddedHandler.Handle(JsonSerializer.Deserialize<ProductAddedEvent>(record.Sns.Message));
        //// TODO: Do interesting work based on the new message
        //await Task.CompletedTask;

        using (var scope = _serviceProvider.CreateScope())
        {
            var productAddedHandler = scope.ServiceProvider.GetRequiredService<ProductAddedHandler>();
            productAddedHandler.Handle(JsonSerializer.Deserialize<ProductAddedEvent>(record.Sns.Message));
        }
    }
}