﻿using Grand.Business.Core.Commands.Catalog;
using Grand.Business.Core.Interfaces.Messages;
using Grand.Domain.Catalog;
using Grand.Domain.Localization;
using Grand.Module.ScheduledTasks.Commands.Handlers.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Grand.Modules.Tests.Commands;

[TestClass]
public class SendQuantityBelowStoreOwnerNotificationCommandHandlerTests
{
    private SendQuantityBelowStoreOwnerNotificationCommandHandler _handler;
    private Mock<IMessageProviderService> _messageProviderMock;
    private LanguageSettings _settings;

    [TestInitialize]
    public void Init()
    {
        _messageProviderMock = new Mock<IMessageProviderService>();
        _settings = new LanguageSettings();
        _handler = new SendQuantityBelowStoreOwnerNotificationCommandHandler(_messageProviderMock.Object, _settings);
    }

    [TestMethod]
    public async Task Handle_InvokeExpectedMethods()
    {
        _settings.DefaultAdminLanguageId = "1";
        var command = new SendQuantityBelowStoreOwnerCommand {
            Product = new Product(),
            ProductAttributeCombination = null
        };

        await _handler.Handle(command, default);
        _messageProviderMock.Verify(c => c.SendQuantityBelowStoreOwnerMessage(It.IsAny<Product>(), It.IsAny<string>()),
            Times.Once);
        command.ProductAttributeCombination = new ProductAttributeCombination();
        await _handler.Handle(command, default);
        _messageProviderMock.Verify(
            c => c.SendQuantityBelowStoreOwnerMessage(It.IsAny<Product>(), It.IsAny<ProductAttributeCombination>(),
                It.IsAny<string>()), Times.Once);
    }
}