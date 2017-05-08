﻿using System.Collections.Generic;
using System.Linq;
using NetTelegramBot.Framework.Abstractions;
using NetTelegramBotApi.Types;

namespace NetTelegramBot.Framework
{
    public class UpdateParser<TBot> : IUpdateParser<TBot>
        where TBot : BotBase<TBot>
    {
        protected IEnumerable<IUpdateHandler> MessageHandlers => _handlersAccessor.UpdateHandlers;

        private readonly IUpdateHandlersAccessor<TBot> _handlersAccessor;

        public UpdateParser(IUpdateHandlersAccessor<TBot> handlersAccessor)
        {
            _handlersAccessor = handlersAccessor;
        }

        public virtual IEnumerable<IUpdateHandler> FindHandlersFor(Update update)
        {
            return MessageHandlers
                .Where(x => x.CanHandle(update));
        }
    }
}
