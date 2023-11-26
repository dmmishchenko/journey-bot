using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;



public class InlineQueryService
{
    private readonly ILogger<InlineQueryService> _logger;
    private readonly ITelegramBotClient _client;

    public InlineQueryService(ITelegramBotClient client, ILogger<InlineQueryService> logger)
    {
        _client = client;
        _logger = logger;
    }

    // BotOnInlineQueryReceived
    public async Task HandleInlineQueryAsync(InlineQuery inlineQuery, CancellationToken cancellationToken)
    {
        InlineQueryResult[] results = {
            // displayed result
            new InlineQueryResultArticle(
                id: "1",
                title: "TgBots",
                inputMessageContent: new InputTextMessageContent("hello"))
        };

        await _client.AnswerInlineQueryAsync(
            inlineQueryId: inlineQuery.Id,
            results: results,
            cacheTime: 0,
            isPersonal: true,
            cancellationToken: cancellationToken);
    }
}